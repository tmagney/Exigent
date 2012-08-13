
namespace Exigent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Reflection;
    using System.Diagnostics;

    public static class Exigent
    {

        private enum ExceptionFields
        {
            _className = 0,
            _exceptionMethod = 1,
            _exceptionMethodString = 2,
            _message = 3,
            _data = 4,
            _innerException = 5, 
            _helpURL = 6,
            _stackTrace = 7,
            _watsonBuckets = 8,
            _stackTraceString = 9,
            _remoteStackTraceString = 10,
            _remoteStackIndex = 11,
            _dynamicMethods = 12,
            _HResult = 13,
            _source = 14,
            _xptrs = 15,
            _xcode = 16,
            _ipForWatsonBuckets = 17,
            _safeSerializationManager = 18,
        }

        private static Func<ExceptionFields, FieldInfo>FieldInfo
        {
            get
            {
                return (ef) =>
                    {
                        return typeof(Exception).GetField(ef.ToString(), BindingFlags.Instance | BindingFlags.NonPublic);
                    };
            }
        }

        private static Func<StackTrace, StackFrame[]> StackFrames
        {
            get
            {
                return (stackTrace) =>
                    {
                        var frames = stackTrace.GetFrames();
                        List<StackFrame> keep = frames.ToList();
                        for (int i = 0; i < frames.Count(); i++)
                        {
                            if (frames[i].GetMethod().DeclaringType.Assembly.Equals(Assembly.GetExecutingAssembly()) == false)
                            {
                                break;
                            }
                            else
                            {
                                keep.RemoveAt(0);
                            }
                        }
                        return keep.ToArray();
                    };
            }
        }

        private static Func<StackTrace, StackFrame> TargetFrame
        {
            get
            {
                return (stackTrace) =>
                    {
                        return StackFrames(stackTrace)[0];
                    };
            }
        }

        private static Func<StackTrace, string> Source
        {
            get
            {
                return (stackTrace) =>
                {
                    Module module = TargetFrame(stackTrace).GetMethod().Module;

                    return module.Assembly.GetName().Name;
                };
            }
        }
        

        public static void Throw<TException>() 
            where TException : Exception, new()
        {
            //So we don't throw recursively.
            InternalThrow<TException>();
        }

        public static void Throw<TException>(string message, params object[] args)
            where TException : Exception, new()
        {
            InternalThrow<TException>(message: message, args: args);
        }

        public static void Throw<TException>(Exception innerException, string message, params object[] args)
            where TException : Exception, new()
        {

        }

        public static void Throw<TException>(Exception innerException, object data, string helpUrl, string message, params object[] args)
            where TException : Exception, new()
        {

        }

        private static void InternalThrow<TException>(
            Exception innerException = null, 
            object data = null,  
            string helpUrl = null, 
            string message = null, 
            params object[] args)
            where TException : Exception, new()    
        {

            try
            {
                throw new Exception();
            }
            catch(Exception ex)
            {
                if (innerException != null)
                {
                    FieldInfo(ExceptionFields._innerException).SetValue(ex, innerException);
                }

                if (data != null)
                {
                    //get Dictionary from dictionary.
                    // ex.Data
                }

                if (String.IsNullOrEmpty(message) == false)
                {
                    var msg = String.Format(message, args);
                    FieldInfo(ExceptionFields._message).SetValue(ex, msg);
                }

                if (String.IsNullOrEmpty(helpUrl) == false)
                {
                    FieldInfo(ExceptionFields._helpURL).SetValue(ex, helpUrl);
                }

                var stackTrace = new StackTrace(true);

                var targetFrame = TargetFrame(stackTrace);

                FieldInfo(ExceptionFields._stackTrace).SetValue(ex, new StackTrace(targetFrame));

                FieldInfo(ExceptionFields._stackTraceString).SetValue(ex, new StackTrace(targetFrame).ToString());
                //FieldInfo(ExceptionFields._remoteStackTraceString).SetValue(ex, new StackTrace(targetFrame).ToString());

                FieldInfo(ExceptionFields._source).SetValue(ex, Source(stackTrace));

                FieldInfo(ExceptionFields._className).SetValue(ex, targetFrame.GetMethod().DeclaringType.Name);
                         
                
                //MethodBase mb = null;
                //System.Runtime.IRuntimeMethodInfo methodFromStackTrace = Exception.GetMethodFromStackTrace(new StackTrace(targetFrame));
                //mb = RuntimeType.GetMethodBase(methodFromStackTrace);

                //FieldInfo(ExceptionFields._exceptionMethod).SetValue(ex, TargetFrame.GetMethodInf

                //set source
                //set target
                //set stacktrace

                throw;
            }
        }
        
        //public static void WithData(dynamic data)
        //{
        //    ExceptionManager.AddData(data);
        //}

        //public static void WithInnerException(Exception innerException)
        //{
        //    ExceptionManager.AddInnerException(innerException);
        //}

        //public static void WithMessage(string message, params object[] args)
        //{
        //    ExceptionManager.AddMessage(message, args);
        //}

        //public static TException Throw<TException>() where TException : Exception
        //{
        //    throw Create<TException>();
        //}

        public static TException Create<TException>() where TException : Exception
        {
            //Create stack trace.

            //var ex = ExceptionManager.Get();

            //Exception e = new Exception();

            ////This is how to set variable of private members. Now, what is the internal name
            ////of StackTrace for the Exception class?
            ////typeof(Foo)
            ////.GetField("bar", BindingFlags.Instance | BindingFlags.NonPublic)
            ////.SetValue(foo, 567);

            //ExceptionManager.Remove();

            return null;
        }
    }
}
