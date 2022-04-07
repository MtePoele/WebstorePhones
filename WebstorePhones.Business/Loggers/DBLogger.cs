using System;
using System.Threading.Tasks;
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

        public async Task LogAsync(WhatHappened whatHappened, string message)
        {
            Log log = new()
            {
                NameOfEvent = whatHappened.ToString(),
                DateTimeOfEvent = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                Details = message
            };

            await _logRepository.CreateAsync(log);
        }
    }
}
