using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace TJY.Blog.Common
{
    internal class NLogLogger : ILogger
    {
        private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();


        public void LogTrace(string logMsg, params object[] parameters)
        {
            _logger.Trace(logMsg, parameters);
        }

        public void LogDebug(string logMsg, params object[] parameters)
        {
            _logger.Debug(logMsg, parameters);
        }

        public void LogInfo(string logMsg, params object[] parameters)
        {
            _logger.Info(logMsg, parameters);
        }

        public void LogWarn(string logMsg, params object[] parameters)
        {
            _logger.Warn(logMsg, parameters);
        }

        public void LogError(string logMsg, params object[] parameters)
        {
            _logger.Error(logMsg, parameters);
        }

        public void LogFatal(string logMsg, params object[] parameters)
        {
            _logger.Fatal(logMsg, parameters);
        }
    }
}

