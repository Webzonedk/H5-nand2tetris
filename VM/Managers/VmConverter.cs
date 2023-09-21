using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;
using Microsoft.Extensions.Configuration;
using VM.Mappers;

namespace VM.Managers
{
    internal class VmConverter : IVmConverter
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly ICommandMapper _commandMapper;



        public VmConverter(
            IFileReader fileReader,
            IFileWriter fileWriter,
            ICommandMapper commandMapper
            )
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _commandMapper = commandMapper;
        }

        public void Convert()
        {
            ConvertVmToAssembly(_fileReader.GetFilesFromFolder());
        }


        private void ConvertVmToAssembly(string[] filePaths)
        {
            if (filePaths.Length == 0)
            {
                Console.WriteLine("No files found to convert. Have you added files to the directory?");
                return;
            }

            foreach (string filePath in filePaths)
            {
                string? directory = Path.GetDirectoryName(filePath);


                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string[] fileContent = File.ReadAllLines(filePath);
                StringBuilder stringBuilder = new StringBuilder();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()!) != null)
                    {
                        string[] splitLine = line.Split(" ");
                        string command = splitLine.Length > 0 ? splitLine[0] : string.Empty;
                        string location = splitLine.Length > 1 ? splitLine[1] : string.Empty;
                        string value = splitLine.Length > 2 ? splitLine[2] : string.Empty;


                        if (_commandMapper.CommandMap.ContainsKey(command))
                        {
                            _commandMapper.CommandMap[command](stringBuilder);
                        }
                        else if (_commandMapper.CommandWithLocationAndValueMap.ContainsKey(command))
                        {
                            _commandMapper.CommandWithLocationAndValueMap[command](location, value, stringBuilder);
                        }
                        else if (_commandMapper.CommandWithLocationMap.ContainsKey(command))
                        {
                            _commandMapper.CommandWithLocationMap[command](location, stringBuilder);
                        }
                        else
                        {
                            stringBuilder.AppendLine($"// unknown command: {line}"); //TODO: Add error to log instead of adding it to the file
                        }
                    }
                }
                _fileWriter.WriteToFile(fileNameWithoutExtension, stringBuilder);
            }
        }
    }
}
