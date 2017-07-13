using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLCode.BaseClasses
{
    public class CStructures
    {
        public class MovePairings
        {
            public string FromValue { get; set; }
            public string ToValue { get; set; }
        }

        public class Configuration
        {
            public string LastFolder { get; set; }
        }
    }
}
