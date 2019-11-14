using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeezyTest.Log
{
    public enum TraceLevel
    {
        Verbose,
        Info,
        Warning,
        Error,
        Fatal
    }

    public interface ILogger
    {
        void WriteVerbose(string message);
        void WriteInfo(string message);
        void WriteWarning(string message);
        void WriteError(string message);
        void WriteFatal(string message);
        void PublishException(Exception ex);
        void Write(TraceLevel level, string message);

    }
}
