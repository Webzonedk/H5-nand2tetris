using Microsoft.Extensions.Configuration;
using System.Text;
using VM.Interfaces;

namespace VM.Tools
{
    /// <summary>
    /// This class is responsible for writing the file
    /// </summary>
    internal class FileWriter : IFileWriter
    {

        private readonly IConfiguration _configuration;
        private readonly ILogFileWriter _logFileWriter;


        public FileWriter(IConfiguration configuration, ILogFileWriter logFileWriter)
        {
            _configuration = configuration;
            _logFileWriter = logFileWriter;
        }
        /// <summary>
        /// This method writes the content to the file.
        /// </summary>
        /// <param name="newFilePath"></param>
        /// <param name="fileContent"></param>
        public void WriteToFile(string fileNameWithoutExtension, StringBuilder fileContent)
        {
            string? newDirectory = _configuration["FilePaths:Compiled"];
            string? newFileName = $"{fileNameWithoutExtension}.asm";
            string? newFilePath = newDirectory != null ? Path.Combine(newDirectory, newFileName) : null;
            try
            {
                if (newFilePath == null)
                {
                    _logFileWriter.WriteLog($"{DateTime.Now} - Error: An error occurred while trying to write to the file. Could not find the path to write to. Selected file path is: {newFilePath}");
                    return;
                }
                using (StreamWriter writer = new StreamWriter(newFilePath))
                {
                    writer.Write(fileContent.ToString());
                }
            }
            catch (Exception e)
            {
                _logFileWriter.WriteLog($"{DateTime.Now} - Error: An error occurred while trying to write to the file: {newFilePath}, Error code: {e}");
            }
        }
    }
}
