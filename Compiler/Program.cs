using Compiler.Interfaces;
using Compiler.Tables;
using Compiler.Tools;
using System;
using System.Net;
using System.Text;

namespace Compiler
{
    class Program
    {

        private readonly IFileReader _fileReader;
        private readonly ISymbolsDynamicTable _symbolsDynamicTable;
        private readonly ISymbolsPredefinedTable _symbolsPredefinedTable;

        public Program(IFileReader fileReader, ISymbolsDynamicTable symbolsDynamicTable, ISymbolsPredefinedTable symbolsPredefinedTable)
        {
            _fileReader = fileReader;
            _symbolsDynamicTable = symbolsDynamicTable;
            _symbolsPredefinedTable = symbolsPredefinedTable;
        }

        static void Main(string[] args)
        {
            SymbolsPredefinedTable predefinedTable = new SymbolsPredefinedTable();

            IFileReader fileReader = new FileReader();
            ISymbolsDynamicTable symbolsDynamicTable = new SymbolsDynamicTable();


            Program program = new Program(fileReader, symbolsDynamicTable, predefinedTable);
            program.Run();
        }

        public void Run()
        {
            string[] filePaths = _fileReader.GetFilesFromFolder();
            ConvertFiles(filePaths);
            Console.WriteLine("Press any key to exit...");
        }



        void ConvertFiles(string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string? directory = Path.GetDirectoryName(filePath);

                // Create the new file name with .txt extension
                string newFileName = $"{fileNameWithoutExtension}.txt";
                string newFilePath = Path.Combine(directory, newFileName);


                StringBuilder fileContent = new StringBuilder();

                // Initialize current line number as 0
                int currentLineNumber = 0;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    Console.WriteLine($"Reading file: {Path.GetFileName(filePath)}");

                    while ((line = reader.ReadLine()!) != null)
                    {
                        // Ignore comments starting with '//'
                        if (!line.TrimStart().StartsWith("//"))
                        {
                            // This line counts as a "useful" line, so increment the line number
                            if (!String.IsNullOrWhiteSpace(line)) //If line is not empty or whitespace
                            {
                                //if line begins with @ and the following is an integer, then convert to 16 bit binary number
                                if (line.StartsWith("@"))
                                {
                                    string address = line.Substring(1);
                                    if (_symbolsPredefinedTable.ReadSymbol(address) != null)
                                    {
                                        string addressBinary = Convert.ToString(_symbolsPredefinedTable.ReadSymbol(address)!.Value, 2).PadLeft(16, '0');
                                        fileContent.AppendLine(addressBinary);
                                    }
                                    //try parse address to int. if it is an int, then convert to binary
                                    else if (int.TryParse(address, out int addressInt))
                                    {
                                        string addressBinary = Convert.ToString(addressInt, 2).PadLeft(16, '0');
                                        fileContent.AppendLine(addressBinary);
                                    }
                                    else
                                    {
                                        // if address exists in _symbolTable use key. else add to _symbolTable
                                        if (_symbolsDynamicTable.ReadSymbol(address) != null)
                                        {
                                            string addressBinary = Convert.ToString(_symbolsDynamicTable.ReadSymbol(address)!.Value, 2).PadLeft(16, '0');
                                            fileContent.AppendLine(addressBinary);
                                        }
                                        else
                                        {
                                            int nextAvailableAddress = _symbolsDynamicTable.GetNextAvailableAddress();
                                            _symbolsDynamicTable.AddSymbol(address, nextAvailableAddress);
                                            string addressBinary = Convert.ToString(nextAvailableAddress, 2).PadLeft(16, '0');
                                            fileContent.AppendLine(addressBinary);
                                        }
                                    }
                                }
                                else if (line.StartsWith("("))
                                {
                                    //if line begins with ( then it is a label. Set the value of the label to the number of the current line and do not write the labet to the file
                                    string label = line.Substring(1, line.Length - 2);
                                    _symbolsDynamicTable.AddSymbol(label, currentLineNumber);
                                }
                                else
                                {
                                    //// If the line is not a comment or an address, then it is an instruction
                                    //// and should be converted to binary
                                    //string binaryInstruction = InstructionConverter.ConvertInstructionToBinary(line);
                                    //fileContent.AppendLine(binaryInstruction);
                                    fileContent.AppendLine(line);
                                }
                                currentLineNumber++;
                            }
                        }
                    }

                    //bool test = TryParse(address, out int addressInt);


                }

                using (StreamWriter writer = new StreamWriter(newFilePath))
                {
                    writer.Write(fileContent.ToString());
                }
                Console.WriteLine($" New file with name: {newFileName} has been created.\n");
            }

        }
    }
}






