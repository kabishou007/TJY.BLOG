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

        #region 实现接口
        public void LogTrace(Exception exp, string msg)
        {
            _logger.Error(exp, msg);
        }

        public void LogDebug(Exception exp, string msg)
        {
            _logger.Error(exp, msg);
        }

        public void LogInfo(Exception exp, string msg)
        {
            _logger.Error(exp, msg);
        }

        public void LogWarn(Exception exp, string msg)
        {
            _logger.Error(exp, msg);
        }

        public void LogError(Exception exp, string msg)
        {
            _logger.Error(exp, msg);
        }

        public void LogFatal(Exception exp, string url)
        {
            _logger.Error(exp, url);
        }

        public void LogTrace(string msg)
        {
            _logger.Trace(msg);
        }

        public void LogDebug(string msg)
        {
            _logger.Debug(msg);
        }

        public void LogInfo(string msg)
        {
            _logger.Info(msg);
        }

        public void LogWarn(string msg)
        {
            _logger.Warn(msg);
        }

        public void LogError(string msg)
        {
            _logger.Error(msg);
        }

        public void LogFatal(string msg)
        {
            _logger.Fatal(msg);
        } 
        #endregion
    }
}

