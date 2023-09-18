using Compiler.Interfaces;

namespace Compiler.Tools
{
    internal class FileReader : IFileReader
    {
        public string[] GetFilesFromFolder()
        {
            // Specify the folder path to look into the C: drive under Dev/CompilerFiles
            string folderPath = @"C:\Dev\nand2tetris\projects\H5-nand2tetris\Compiler\FilesToCompile";

            try
            {
                // Use the search pattern to get only .asm files
                string[] filePaths = Directory.GetFiles(folderPath, "*.asm");

                // Additional filter using LINQ to ensure only .asm files are considered
                filePaths = filePaths.Where(path => Path.GetExtension(path).Equals(".asm", StringComparison.OrdinalIgnoreCase)).ToArray();

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