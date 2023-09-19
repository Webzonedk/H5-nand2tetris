using Compiler.Interfaces;
using Compiler.Managers;
using Compiler.Tables;
using Compiler.Tools;
using System.Text;

namespace Compiler
{
    class Program
    {

        private readonly IFileReader _fileReader;
        private readonly ISymbolsDynamicTable _symbolsDynamicTable;
        private readonly ISymbolsPredefinedTable _symbolsPredefinedTable;
        private readonly ICInstructionTable _cInstructionTable;
        private readonly ICInstructionSplitter _cInstructionSplitter;
        private readonly ICInstructionAssembler _cInstructionAssembler;
        private readonly ICInstructionConverter _cInstructionConverter;


        public Program(
            IFileReader fileReader,
            ISymbolsPredefinedTable symbolsPredefinedTable,
            ISymbolsDynamicTable symbolsDynamicTable,
            ICInstructionTable cInstructionTable,
            ICInstructionSplitter cInstructionSplitter,
            ICInstructionAssembler cInstructionAssembler,
            ICInstructionConverter cInstructionConverter)
        {
            _fileReader = fileReader;
            _symbolsDynamicTable = symbolsDynamicTable;
            _symbolsPredefinedTable = symbolsPredefinedTable;
            _cInstructionSplitter = cInstructionSplitter;
            _cInstructionAssembler = cInstructionAssembler;
            _cInstructionConverter = cInstructionConverter;
            _cInstructionTable = cInstructionTable;
        }

        static void Main(string[] args)
        {
            IFileReader fileReader = new FileReader();
            ISymbolsPredefinedTable predefinedTable = new SymbolsPredefinedTable();
            ISymbolsDynamicTable symbolsDynamicTable = new SymbolsDynamicTable();
            ICInstructionTable cInstructionTable = new CInstructionTable();
            ICInstructionSplitter cInstructionSplitter = new CInstructionSplitter();
            ICInstructionAssembler cInstructionAssembler = new CInstructionAssembler(cInstructionTable);
            ICInstructionConverter cInstructionConverter = new CInstructionConverter(cInstructionSplitter, cInstructionAssembler);


            Program program = new Program(fileReader, predefinedTable, symbolsDynamicTable, cInstructionTable, cInstructionSplitter, cInstructionAssembler, cInstructionConverter);
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
                string? fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string? directory = Path.GetDirectoryName(filePath);

                // Create the new file name with .txt extension
                string? newFileName = $"{fileNameWithoutExtension}.txt";
                string? newFilePath = Path.Combine(directory, newFileName);


                StringBuilder fileContent = new StringBuilder();

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
                //using (StreamWriter writer = new StreamWriter(newFilePath))
                //{
                //    writer.Write(fileContent.ToString());
                //}
                Console.WriteLine($" New file with name: {newFileName} has been created.\n");
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