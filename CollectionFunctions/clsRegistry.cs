using CLCode.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static CLCode.BaseClasses.CStructures;

namespace CLCode
{
    public class clsRegistry : CRegistry
    {
        public Configuration GetConfig()
        {
            Configuration cfg = new Configuration();
            foreach(var _prop in typeof(Configuration).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance))
            {
               cfg.GetType().GetProperty(_prop.Name).SetValue(cfg, GetDefaultsKey().ReadValue(_prop.Name));
            }
            return cfg;
        }

        
    }
}
