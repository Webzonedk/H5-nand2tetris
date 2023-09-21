using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Tools
{
    internal class FileWriter : IFileWriter
    {

        private readonly IConfiguration _configuration;


        public FileWriter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// This method writes the content to the file.
        /// </summary>
        /// <param name="newFilePath"></param>
        /// <param name="fileContent"></param>
        public void WriteToFile(string fileNameWithoutExtension, StringBuilder fileContent)
        {
            string? newDirectory = _configuration["FilePaths:Compiled"];
            string? newFileName = $"{fileNameWithoutExtension}.txt";
            string? newFilePath = newDirectory != null ? Path.Combine(newDirectory, newFileName) : null;
            try
            {
                if (newFilePath == null)
                {
                    Console.WriteLine("Could not find the path to write to."); //TODO: Add
                    return;
                }
                using (StreamWriter writer = new StreamWriter(newFilePath))
                {
                    writer.Write(fileContent.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while trying to write to the file: {newFilePath}, Errorcode: {e}");
            }
        }
    }
}
