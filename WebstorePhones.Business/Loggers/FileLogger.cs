using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Loggers
{
    // Not worth the time investment to write a test for this that doesn't include writing to a file.
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
