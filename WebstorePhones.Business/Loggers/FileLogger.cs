using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Loggers
{
    public class FileLogger : ILogger
    {
        public async Task LogAsync(WhatHappened whatHappened, string value)
        {
            string filepath = ConfigurationManager.AppSettings.Get("filelogger");

            if (value != string.Empty)
            {
                await using StreamWriter streamWriter = new(filepath, append: true);
                streamWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} -> {whatHappened} with value \"{value}\".");
            }
        }
    }
}
