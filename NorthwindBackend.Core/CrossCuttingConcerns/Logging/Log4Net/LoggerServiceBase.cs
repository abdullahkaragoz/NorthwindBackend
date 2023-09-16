using log4net;
using log4net.Repository;
using System.IO;
using System.Reflection;
using System.Xml;

namespace NorthwindBackend.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

            _log = LogManager.GetLogger(loggerRepository.Name, name);

        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (_log.IsInfoEnabled)
            _log.Info(logMessage);
        }

        public void Debug(object logMessage)
        {
            if (_log.IsDebugEnabled)
                _log.Debug(logMessage);
        }
        public void Warn(object logMessage)
        {
            if (_log.IsWarnEnabled)
                _log.Warn(logMessage);
        }
        public void Fatal(object logMessage)
        {
            if (_log.IsFatalEnabled)
                _log.Fatal(logMessage);
        }
        public void Error(object logMessage)
        {
            if (_log.IsErrorEnabled)
                _log.Error(logMessage);
        }

    }
}
