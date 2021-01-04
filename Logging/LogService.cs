using System;
using Serilog;

namespace LoggingPOC.Logging
{
    public class LogService : ILogService
    {
        public void Info(object structuredMessage)
        {
            Log.Logger.Information("{@EventProperties}", structuredMessage);
        }
        public void Info(string message)
        {
            Log.Logger.Information(message);
        }

        public void Info(string format, params object[] parameters)
        {
            Log.Logger.Information(format, parameters);
        }

        public void Warn(string message)
        {
            Log.Logger.Warning(message);
        }

        public void Warn(string format, params object[] parameters)
        {
            Log.Logger.Warning(format, parameters);
        }

        public void Debug(string message)
        {
            Log.Logger.Debug(message);
        }

        public void Debug(string format, params object[] parameters)
        {
            Log.Logger.Debug(format, parameters);
        }

        public void Error(string message, Exception exc)
        {
            Log.Logger.Error(exc, message);
        }

        public void Error(string format, params object[] parameters)
        {
            Log.Logger.Error(format, parameters);
        }

        public void Error(string format, Exception exc, params object[] parameters)
        {
            Log.Logger.Error(exc, format, parameters);
        }
    }
}
