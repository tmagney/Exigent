namespace Exigent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Ex
    {
        internal string Message;
        internal Exception InnerException;
        internal string StackTrace
        {
            get
            {
                //Build the correct stack trace into by looking up the current stack trace
                //for the first call outside of the Exigent assembly.
                return String.Empty;
            }
        }
    }
}
