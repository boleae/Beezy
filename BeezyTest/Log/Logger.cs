using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Log
{
    public class Log4NetLogger:ILogger
    {
        #region Fields

        private readonly ILog log = LogManager.GetLogger(typeof(Log4NetLogger));

        #endregion

        public Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void WriteVerbose(string message)
        {
            if (log != null)
                log.Debug(message);
        }

        public void WriteInfo(string message)
        {
            if (log != null)
                log.Info(message);
        }

        public void WriteWarning(string message)
        {
            if (log != null)
                log.Warn(message);
        }

        public void WriteError(string message)
        {
            if (log != null)
                log.Error(message);
        }

        public void PublishException(Exception exception)
        {
            if (log != null)
                log.Error("Exception", exception);
        }

      

        public void WriteFatal(string message)
        {
            if (log != null)
                log.Fatal(message);
            
        }

        public void Write(TraceLevel level, string message)
        {
            switch(level)
            {
                case TraceLevel.Error:
                    WriteError(message);
                    break;
                case TraceLevel.Fatal:
                    WriteError(message);
                    break;
                case TraceLevel.Info:
                    WriteInfo(message);
                    break;
                case TraceLevel.Verbose:
                    WriteVerbose(message);
                    break;
                case TraceLevel.Warning:
                default:
                    WriteWarning(message);
                    break;
            }
            
        }
    }
}