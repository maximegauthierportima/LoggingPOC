using System;

namespace LoggingPOC.BL
{
    public class ErrorBl : IErrorBl
    {
        public void ThrowingArgumentNullException()
        {
            throw new ArgumentNullException("ArgumentNullException thrown from business logic");
        }

        public void ThrowingException()
        {
            throw new Exception("Exception thrown from business logic");
        }
    }
}
