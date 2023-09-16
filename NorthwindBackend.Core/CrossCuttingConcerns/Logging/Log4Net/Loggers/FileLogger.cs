using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {

        }
    }
}
