using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLCode.BaseClasses.CStructures;

namespace CLCode.BaseClasses
{
    public class CRegistry : CLogger
    {
        private string LogName { get { return "Log"; } }
        private RegistryKey rKey = Registry.CurrentConfig.OpenSubKey("CL").OpenSubKey("MediaSorter");
        internal RegistryKey BaseKey { get { return rKey; } }

        public RegistryKey GetBaseKey()
        {
            return BaseKey;
        }

        public RegistryKey GetLogKey()
        {
            return BaseKey.OpenSubKey("Logs");
        }

        public RegistryKey GetDefaultsKey()
        {
            return BaseKey.OpenSubKey("Defaults");
        }

        public override void Log(string Message)
        {
            string NextLogName = GetNextLogName(GetLogKey());
            GetLogKey().WriteValue(NextLogName, Message);
        }

        private string GetNextLogName(RegistryKey objKey)
        {
            var NextNumber = objKey.GetValueNames()
                .Where(x => x.ToLower() != "(default)")
                .OrderBy(x => Convert.ToInt32(x.Replace(LogName, "")))
                .Select(x => (Convert.ToInt32(x.Replace(LogName, "")) + 1).ToString("000"))
                .Last();

            return LogName + NextNumber == null ? "000" : NextNumber;
        }
                
        private IEnumerable<MovePairings> GetMovePairings()
        {
            RegistryKey key = BaseKey;
            var RQ = key.GetValueNames()
                .Where(x => x.ToLower() != "(default)")
                .Select(x => new MovePairings
                {
                    FromValue = x,
                    ToValue = key.ReadValue(x)
                });

            foreach (var mp in RQ)
                yield return mp;

        }
    }

    public static class CRegistryExtentions
    {
        public static string ReadValue(this RegistryKey objKey, string sHeader, string sDefaultValue = null)
        {
            if (sDefaultValue == null)
                return objKey.GetValue(sHeader).ToString();

            return objKey.GetValue(sHeader, sDefaultValue).ToString();
        }

        public static void WriteValue(this RegistryKey objKey, string sHeader, string sValue)
        {
            objKey.SetValue(sHeader, sValue);
        }
        
        
    }
}
