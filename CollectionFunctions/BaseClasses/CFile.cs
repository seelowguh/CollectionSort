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
                .Select(f => f.Name);

            foreach (var file in FileQ)
                yield return file;

            var FolderQ = new DirectoryInfo(sDirectory)
                .GetFiles()
                .Where(f => f.Name.ToUpper().Contains("DVD"))
                .Select(f => f.Name);

            foreach (var folder in FolderQ)
                yield return folder;

        }

    }

    public static class CFileExtentions
    {
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


    }
}
