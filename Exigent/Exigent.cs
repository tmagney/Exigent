
namespace Exigent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public static class Exigent
    {
        internal static int ThreadId
        {
            get
            {
                return Thread.CurrentThread.ManagedThreadId;
            }
        }

        public static void WithInnerException(Exception innerException)
        {
            ExceptionManager.AddInnerException(innerException);
        }

        public static void WithMessage(string message, params object[] args)
        {
            ExceptionManager.AddMessage(message, args);
        }

        public static TException Throw<TException>() where TException : Exception
        {
            throw Create<TException>();
        }

        public static TException Create<TException>() where TException : Exception
        {
            //Create stack trace.

            var ex = ExceptionManager.Get();

            //Now turn ex into type TException and throw.
            
            ExceptionManager.Remove();

            return null;
        }
    }
}
