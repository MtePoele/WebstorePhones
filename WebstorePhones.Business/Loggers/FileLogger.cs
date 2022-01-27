﻿using System;
using System.Configuration;
using System.IO;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.Business.Loggers
{
    public class FileLogger : ILogger
    {

        public void Log(string whatHappened, string value)
        {
            string filepath = ConfigurationManager.AppSettings.Get("filelogger");

            if (value != string.Empty)
            {
                using (StreamWriter streamWriter = new(filepath, append: true))
                {
                    
                    streamWriter.WriteLine($"{whatHappened} at {DateTime.Now.ToLongTimeString()} with value \"{value}\".");
                    streamWriter.Close();
                }
            }

        }
    }
}
