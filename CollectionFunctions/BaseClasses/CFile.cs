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

    public class CFileExtentions
    {

    }
}
