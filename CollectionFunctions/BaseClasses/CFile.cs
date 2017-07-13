using System;
using System.Collections.Generic;
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
                .Where(f => f.Name.Contains(".") || f.Name.Contains("-") || f.Name.Contains("_"))
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

    }

    public static class CFileExtentions
    {
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
            int _return = _source.Length;
            int _temp = _source.Length;

            _temp = _source.IndexOf('_');
            if(_temp <= 0)
                _temp = _source.IndexOf('-');

            if(_temp <= 0)
                _temp = _source.IndexOf(']');

            if (_temp <= 0)
                _temp = _source.IndexOf('.');

            if (_temp <= 0)
                _temp = _source.Length;

            _return = _temp;
            
            return _return;
        }

    }

}
