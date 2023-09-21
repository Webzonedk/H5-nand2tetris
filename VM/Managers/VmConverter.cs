using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;
using Microsoft.Extensions.Configuration;
using Compiler.Interfaces;

namespace VM.Managers
{
    internal class VmConverter : IVmConverter
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly ICommandTable _commandTable;

        public VmConverter(
            IFileReader fileReader,
            IFileWriter fileWriter,
            ICommandTable commandTable)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _commandTable = commandTable;
        }

        public void Convert()
        {
            ConvertVmToAssembly(ReadFile());
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
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] splitLine = line.Split(" ");
                        string command = splitLine[0];
                        string location = splitLine[1];
                        int value;
                        if (!int.TryParse(splitLine[2], out value))
                        {
                            value = 0;
                        }


                        switch (command)
                        {
                            case "push":
                                _commandTable.HandlePush(location, value);
                                break;
                            case "pop":
                                stringBuilder.Append(Pop(location, value));
                                break;
                            case "add":
                                stringBuilder.Append(Add());
                                break;
                            case "sub":
                                stringBuilder.Append(Sub());
                                break;
                            case "neg":
                                stringBuilder.Append(Neg());
                                break;
                            case "eq":
                                stringBuilder.Append(Eq());
                                break;
                            case "gt":
                                stringBuilder.Append(Gt());
                                break;
                            case "lt":
                                stringBuilder.Append(Lt());
                                break;
                            case "and":
                                stringBuilder.Append(And());
                                break;
                            case "or":
                                stringBuilder.Append(Or());
                                break;
                            case "not":
                                stringBuilder.Append(Not());
                                break;
                            default:
                                Console.WriteLine("Command not found");
                                break;
                        }
                    }
                }



                WriteToFile(fileNameWithoutExtension, stringBuilder);
            }


            WriteToFile("test", new StringBuilder());
        }
        /// <summary>
        /// This method reads the files from the folder.
        /// </summary>
        /// <returns>Returns an array of strings containing the file paths.</returns>
        private string[] ReadFile()
        {
            return _fileReader.GetFilesFromFolder();
        }

        private void WriteToFile(string fileNameWithoutExtension, StringBuilder fileContent)
        {
            _fileWriter.WriteToFile(fileNameWithoutExtension, fileContent);
        }
    }
}
