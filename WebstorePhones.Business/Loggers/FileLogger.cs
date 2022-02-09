using System;
using System.Configuration;
using System.IO;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Loggers
{
    public class FileLogger : ILogger
    {
        public void Log(WhatHappened whatHappened, string value)
        {
            string filepath = ConfigurationManager.AppSettings.Get("filelogger");

            if (value != string.Empty)
            {
                using StreamWriter streamWriter = new(filepath, append: true);
                streamWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} -> {whatHappened} with value \"{value}\".");
            }
        }
    }
}
