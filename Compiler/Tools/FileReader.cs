using Compiler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tools
{
    internal class FileReader : IFileReader
    {
        public string[] GetFilesFromFolder()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string folderPath = Path.Combine(desktopPath, "CompilerFiles");
            try
            {
                string[] filePaths = Directory.GetFiles(folderPath);

                return filePaths;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not read files", e.ToString());
                return null;
            }
        }
    }
}
