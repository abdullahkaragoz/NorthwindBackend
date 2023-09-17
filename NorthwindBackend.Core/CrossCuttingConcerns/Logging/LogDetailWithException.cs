using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionLogMessage { get; set; }
    }
}
