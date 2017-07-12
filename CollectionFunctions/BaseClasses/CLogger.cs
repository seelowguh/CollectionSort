using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLCode.BaseClasses
{
    public class CLogger
    {
        public event EventHandler<string> LogOutput;

        public virtual void Log(string Message)
        {
            //  Do something to log it


            //  Raise it to anything thats listening
            if (LogOutput != null)
                LogOutput.Invoke(this, Message);
        }
    }
}
