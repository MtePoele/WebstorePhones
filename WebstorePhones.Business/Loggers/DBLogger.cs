using System;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Loggers
{
    public class DBLogger : ILogger
    {
        private readonly IRepository<Log> _logRepository;

        public DBLogger(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        public void Log(WhatHappened whatHappened, string message)
        {
            Log log = new()
            {
                NameOfEvent = whatHappened.ToString(),
                DateTimeOfEvent = DateTime.Now.ToString(),
                Details = message
            };

            _logRepository.Create(log);
        }
    }
}
