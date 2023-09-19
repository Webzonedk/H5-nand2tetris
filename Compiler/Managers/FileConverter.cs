using Compiler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Managers
{
    internal class FileConverter : IFileConverter
    {
        private readonly IFileReader _fileReader;
        private readonly ISymbolsPredefinedTable _symbolsPredefinedTable;
        private readonly ISymbolsDynamicTable _symbolsDynamicTable;
        private readonly ICInstructionConverter _cInstructionConverter;

        public FileConverter(
            IFileReader fileReader,
            ISymbolsPredefinedTable symbolsPredefinedTable,
            ISymbolsDynamicTable symbolsDynamicTable,
            ICInstructionConverter cInstructionConverter)
        {
            _fileReader = fileReader;
            _symbolsPredefinedTable = symbolsPredefinedTable;
            _symbolsDynamicTable = symbolsDynamicTable;
            _cInstructionConverter = cInstructionConverter;
        }

        public void Compiler()
        {
            ConvertFiles(ReadFile());
        }


        public void ConvertFiles(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                string? fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string? directory = Path.GetDirectoryName(filePath);
                if (directory == null)
                {
                    Console.WriteLine($"Could not find directory for file: {Path.GetFileName(filePath)}");
                    continue;
                }
                // Create the new file name with .txt extension
                string? newFileName = $"{fileNameWithoutExtension}.txt";
                string? newFilePath = Path.Combine(directory, newFileName);


                StringBuilder fileContent = new StringBuilder();

                AddLabelsToDynamicTable(filePath);

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? line;
                    Console.WriteLine($"Reading file: {Path.GetFileName(filePath)}");
                    while ((line = reader.ReadLine()!) != null)
                    {
                        // Trim leading and trailing white spaces
                        line = line.Trim();

                        // Remove inline comments starting with '//'
                        int commentIndex = line.IndexOf("//", StringComparison.Ordinal);
                        if (commentIndex >= 0)
                        {
                            line = line.Substring(0, commentIndex).Trim();
                        }

                        // Ignore lines that now become empty or start with '//' 
                        if (String.IsNullOrWhiteSpace(line) || line.StartsWith("//") || line.StartsWith("("))
                        {
                            continue;
                        }

                        //if line begins with @ and the following is an integer, then convert to 16 bit binary number
                        if (line.StartsWith("@"))
                        {
                            string? address = line.Substring(1);
                            if (_symbolsPredefinedTable.ReadSymbol(address) != null)
                            {
                                string? addressBinary = Convert.ToString(_symbolsPredefinedTable.ReadSymbol(address)!.Value, 2).PadLeft(16, '0');
                                fileContent.AppendLine(addressBinary);
                            }
                            //try parse address to int. if it is an int, then convert to binary
                            else if (int.TryParse(address, out int addressInt))
                            {
                                string? addressBinary = Convert.ToString(addressInt, 2).PadLeft(16, '0');
                                fileContent.AppendLine(addressBinary);
                            }
                            else
                            {
                                // if address exists in _symbolTable use key. else add to _symbolTable
                                if (_symbolsDynamicTable.ReadSymbol(address) != null)
                                {
                                    string? addressBinary = Convert.ToString(_symbolsDynamicTable.ReadSymbol(address)!.Value, 2).PadLeft(16, '0');
                                    fileContent.AppendLine(addressBinary);
                                }
                                else
                                {
                                    int nextAvailableAddress = _symbolsDynamicTable.GetNextAvailableAddress();
                                    _symbolsDynamicTable.AddSymbol(address, nextAvailableAddress);
                                    string? addressBinary = Convert.ToString(nextAvailableAddress, 2).PadLeft(16, '0');
                                    fileContent.AppendLine(addressBinary);
                                }
                            }
                        }
                        else
                        {
                            string? instructionBinary = _cInstructionConverter.ConvertCInstruction(line);
                            fileContent.AppendLine(instructionBinary);
                        }
                    }
                    WriteToFile(newFilePath, fileContent);
                }
                Console.WriteLine($" New file with name: {newFileName} has been created.\n");
            }
        }

        string[] ReadFile()
        {
            return _fileReader.GetFilesFromFolder();
        }
        

        void AddLabelsToDynamicTable(string filePath)
        {
            // Initialize current line number as 0
            int currentLineNumber = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                Console.WriteLine($"Reading file: {Path.GetFileName(filePath)}");
                while ((line = reader.ReadLine()!) != null)
                {
                    // Trim leading and trailing white spaces
                    line = line.Trim();

                    // Remove inline comments starting with '//'
                    int commentIndex = line.IndexOf("//", StringComparison.Ordinal);
                    if (commentIndex >= 0)
                    {
                        line = line.Substring(0, commentIndex).Trim();
                    }

                    // Ignore lines that now become empty or start with '//' 
                    if (String.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
                    {
                        continue;
                    }

                    if (line.StartsWith("("))
                    {
                        //if line begins with "(" then it is a label. Set the value of the label to the number of the current line and do not write the labet to the file
                        string? label = line.Substring(1, line.Length - 2);
                        _symbolsDynamicTable.AddSymbol(label, currentLineNumber);
                        currentLineNumber--;
                    }
                    currentLineNumber++;
                }
            }
        }

        void WriteToFile(string newFilePath, StringBuilder fileContent)
        {
            using (StreamWriter writer = new StreamWriter(newFilePath))
            {
                writer.Write(fileContent.ToString());
            }
        }
    }
}
