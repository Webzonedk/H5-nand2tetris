using Microsoft.Extensions.Configuration;
using VM.Interfaces;

namespace VM.Tools
{
    /// <summary>
    /// This class is used to read the files from the folder.
    /// </summary>
    internal class FileReader : IFileReader
    {
        private readonly IConfiguration _configuration;


        public FileReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        /// <summary>
        /// This method is used to get the files from the folder.
        /// </summary>
        /// <returns></returns>
        public string[] GetFilesFromFolder()
        {
            string? folderPath = _configuration["FilePaths:ToCompile"];
            if (folderPath == null)
            {
                Console.WriteLine("Folder path not found in configuration.");
                return Array.Empty<string>();
            }
            try
            {
                string[] filePaths = Directory.GetFiles(folderPath, "*.vm");

                filePaths = filePaths.Where(path => Path.GetExtension(path).Equals(".vm", StringComparison.OrdinalIgnoreCase)).ToArray();

                return filePaths;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not read files", e.ToString());
                return Array.Empty<string>();
            }
        }
    }
}