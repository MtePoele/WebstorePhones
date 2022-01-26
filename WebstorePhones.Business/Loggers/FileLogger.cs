using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebstorePhones.Domain.Interfaces;
using System.Configuration;
using System.Collections.Specialized;

namespace WebstorePhones.Business.Loggers
{
    public class FileLogger : ILogger
    {

        public void Log(string message)
        {
            string filepath = ConfigurationManager.AppSettings.Get("filelogger");

            using (StreamWriter streamWriter = new(filepath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
