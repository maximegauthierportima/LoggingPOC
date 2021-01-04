using System;
using Serilog;

namespace LoggingPOC.Logging
{
    /// <summary>
    /// This service allows you to wrap or override methods of the <see cref="Log"/> static class. <br/>
    /// This service allows you to use dependency injection
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// This method is for lazy developers like me who don't like to write story. <br/>
        /// It will create an object EventProperties which will contains every properties of the object <br/>
        /// You can pass a dynamic or anonymous or a custom object to this method to write you log
        /// </summary>
        /// <param name="structuredMessage"></param>
        void Info(object structuredMessage);
        void Info(string  message);
        void Info(string  format, params object[] parameters);
        void Warn(string  message);
        void Warn(string  format, params object[] parameters);
        void Debug(string message);
        void Debug(string format,  params object[] parameters);
        void Error(string message, Exception       exc);
        void Error(string format,  params object[] parameters);
        void Error(string format,  Exception       exc, params object[] parameters);
    }
}
