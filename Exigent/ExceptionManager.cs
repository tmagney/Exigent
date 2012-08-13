namespace Exigent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public static class ExceptionManager
    {
        private static Dictionary<int, Ex> exceptions;

        static ExceptionManager()
        {
            exceptions = new Dictionary<int, Ex>();
        }
        
        //internal static Ex Get()
        //{
        //    //TODO: How to override indexer?
        //    //NOTE: Is that a good idea?

        //    Ex ex = new Ex();
        //    if(exceptions.Keys.Contains(Exigent.ThreadId) == false)
        //    {
        //        exceptions.Add(Exigent.ThreadId, ex);
        //    }
        //    else
        //    {
        //        ex = exceptions[Exigent.ThreadId];
        //    }

        //    return ex;
        //}

        //public static void AddData(dynamic data)
        //{
        //    var ex = Get();
        //    ex.Data = data;
        //}

        //public static void AddInnerException(Exception inner)
        //{
        //    var ex = Get();
        //    ex.InnerException = inner;
        //}

        //public static void AddMessage(string message, params object[] args)
        //{
        //    var ex = Get();
        //    ex.Message = String.Format(message, args);
        //}
        
        //public static void Remove()
        //{
        //    exceptions.Remove(Exigent.ThreadId);
        //}
    }
}
