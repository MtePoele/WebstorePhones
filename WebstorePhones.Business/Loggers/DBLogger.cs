using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Log(string whatItIs, string message)
        {

        }
    }
}
