namespace Exigent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    internal class Ex
    {
        internal dynamic Data {get; set;}
        internal dynamic Properties {get; set;}
        internal string Message {get; set;}
        internal Exception InnerException {get; set;}
        internal string StackTrace
        {
            get
            {
                var trace = new StackTrace(true);

                int framesToSkip = 0;

                for(framesToSkip = 0; framesToSkip < trace.FrameCount; framesToSkip++)
                {
                    if(trace.GetFrames()[framesToSkip].GetMethod().DeclaringType.Assembly.GetName().Equals("Exigent") == false)
                    {
                        break;
                    }
                }

                return new StackTrace(framesToSkip).ToString();
            }
        }
    }
}
