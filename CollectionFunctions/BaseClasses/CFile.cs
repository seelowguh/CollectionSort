using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLCode.BaseClasses
{
    public abstract class CFile
    {
        public IEnumerable<string> GetFileNames(string sDirectory)
        {
            var FQ = new DirectoryInfo(sDirectory)
                .GetFiles()
                .Where(f => f.Name.Substring(0, f.Name.Length - (f.Extension.Length + 1)).Contains(".") 
                    | f.Name.Contains("-") | f.Name.Contains("_"))
                .Select(f => f.Name);

            foreach (var file in FQ)
                yield return file;
        }

        public IEnumerable<string> GetFolderNames(string sDirectory)
        {
            var FQ = new DirectoryInfo(sDirectory)
                .GetDirectories()
                .Where(f => f.Name.Contains(".") || f.Name.Contains("-") || f.Name.Contains("_"))
                .Select(f => f.Name);

            foreach (var Folder in FQ)
                yield return Folder;
        }

        public IEnumerable<string> GetDVDFilesAndFolders(string sDirectory)
        {
            var FileQ = new DirectoryInfo(sDirectory)
                .GetFiles()
                .Where(f => f.Name.ToUpper().Contains("DVD"))
                .Select(f => f.FullName);

            foreach (var file in FileQ)
                yield return file;

            var FolderQ = new DirectoryInfo(sDirectory)
                .GetDirectories()
                .Where(f => f.Name.ToUpper().Contains("DVD") && f.Name.ToUpper() != "DVD")
                .Select(f => f.FullName);

            foreach (var folder in FolderQ)
                yield return folder;

        }

        public IEnumerable<string> GetDisplayFileAndFolderNames(string sDirectory)
        {
            List<string> _yeilds = new List<string>();

            _yeilds.AddRange(GetFileNames(sDirectory));
            _yeilds.AddRange(GetFolderNames(sDirectory));

            foreach (var s in _yeilds
                .Select(x=> x.Substring(0, x.GetFirstIndex()).StandardReplace())
                .Distinct()
                .OrderBy(x=>x))
            {
                yield return s;
            }
        }

        public void MoveFileOrFolder(string sDirectory, string sTitle)
        {
            if (sDirectory.Substring(sDirectory.Length - 2, 1) != "\\")
                sDirectory += "\\";

            string _NewDir = $"{sDirectory}{sTitle}\\";

            var FileQ = new DirectoryInfo(sDirectory).GetFiles()
                .Where(x => x.Name.Substring(0, x.Name.GetFirstIndex())
                                .StandardReplace().ToLower() == sTitle.ToLower())
                .Select(x => x);

            //  Create directory if not there
            if (FileQ.Count() > 0)
                if (!Directory.Exists(_NewDir))
                    Directory.CreateDirectory(_NewDir);

            foreach (var x in FileQ)
            {
                string _newFilePath = $"{_NewDir}{x.Name}";
                if(!File.Exists(_newFilePath))
                    x.MoveTo(_newFilePath);
            }

            var FolderQ = new DirectoryInfo(sDirectory).GetDirectories()
                .Where(x => x.Name.ToLower() != sTitle.ToLower() &&
                                x.Name.Substring(0, x.Name.GetFirstIndex())
                                .StandardReplace().ToLower() == sTitle.ToLower()
                                )
                .Select(x => x);

            //  Create directory if not there
            if (FolderQ.Count() > 0)
                if (!Directory.Exists(_NewDir))
                    Directory.CreateDirectory(_NewDir);

            foreach (var x in FolderQ)
            {
                string _newFolderPath = $"{_NewDir}{x.Name}";
                if(!Directory.Exists(_newFolderPath))
                    x.MoveTo(_newFolderPath);
            }

        }

    }

    public static class CFileExtentions
    {
        public enum _Case
        {
            TitleCase = 1, CamelCase = 2
        }

        public static bool FileExists(this string _source)
        {
            return File.Exists(_source);
        }

        public static bool FolderExists(this string _source)
        {
            return Directory.Exists(_source);
        }

        public static void MoveFile(this string _source, string _destinationFolder)
        {
            if (!Directory.Exists(_destinationFolder))
                Directory.CreateDirectory(_destinationFolder);

            string _destFile = string.Format("{0}{1}{2}", _destinationFolder, _destinationFolder.Substring(_destinationFolder.Length - 1) == "\\" ? "" : "\\", new FileInfo(_source).Name);

            if (File.Exists(_source))
                if(!File.Exists(_destFile))
                    File.Move(_source, _destFile);
        }

        public static void MoveFolder(this string _source, string _destinationFolder)
        {
            if (!Directory.Exists(_destinationFolder))
                Directory.CreateDirectory(_destinationFolder);

            string _destFolder = string.Format("{0}{1}{2}", _destinationFolder, _destinationFolder.Substring(_destinationFolder.Length - 1) == "\\" ? "" : "\\", new DirectoryInfo(_source).Name);

            if (Directory.Exists(_source))
                if(!Directory.Exists(_destFolder))
                    Directory.Move(_source, _destFolder);
        }

        public static void DeleteFolder(this string _source)
        {
            if(Directory.Exists(_source))
                Directory.Delete(_source);
        }

        public static void DeleteFile(this string _source)
        {
            if (File.Exists(_source))
                File.Delete(_source);
        }

        public static string StandardReplace(this string _Source)
        {
            return _Source.Replace(".", "").Replace(" ", "").Replace("[", "").Replace("]", "");
        }

        public static int GetFirstIndex(this string _source)
        {
            string x = string.Empty;
            if (_source.ToLower().Contains("blacksonblondes"))
                x = _source;

            int _return = _source.Length;
            int _temp = _source.Length;

            _temp = _source.IndexOf('_');

            if(_temp <= 0 || _temp > _source.IndexOf('-'))
                _temp = _source.IndexOf('-') < 0 ? _temp : _source.IndexOf('-');

            if(_temp <= 0 || _temp > _source.IndexOf(']'))
                _temp = _source.IndexOf(']') < 0 ? _temp : _source.IndexOf(']');

            if (_temp <= 0 || _temp > _source.IndexOf('.'))
                _temp = _source.IndexOf('.') < 0 ? _temp : _source.IndexOf('.');

            if (_temp <= 0)
                _temp = _source.Length;

            _return = _temp;
            
            return _return;
        }

        private static string FormatToCase(this string s, _Case c, bool _replaceSpaces)
        {
            string _return = string.Empty;
            TextInfo tI = new CultureInfo("en-us", false).TextInfo;
            switch (c)
            {
                case _Case.CamelCase:
                    _return = s.Substring(0, 1).ToLower() + tI.ToTitleCase(s.Substring(1));
                    break;
                case _Case.TitleCase:
                    _return = tI.ToTitleCase(s);
                    break;
            }

            if (_replaceSpaces)
                _return = _return.Replace(" ", "");

            return _return;
        }
    }

}
