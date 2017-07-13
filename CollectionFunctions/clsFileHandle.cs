using CLCode.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CLCode
{
    public class clsFileHandle : CFile
    {
        private CLogger objLogger = null;

        public clsFileHandle(CLogger PassedLogger)
        {
            objLogger = PassedLogger;
        }

        

    }
}
