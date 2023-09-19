using Compiler.Interfaces;
using System.Text;

namespace Compiler.Managers
{
    /// <summary>
    /// This class converts the files to binary.
    /// </summary>
    internal class FileConverter : IFileConverter
    {
        private readonly IFileReader _fileReader;
        private readonly ISymbolsPredefinedTable _symbolsPredefinedTable;
        private readonly ILabelsDynamicTable _labelsDynamicTable;
        private readonly ISymbolsDynamicTable _symbolsDynamicTable;
        private readonly ICInstructionConverter _cInstructionConverter;

        public FileConverter(
            IFileReader fileReader,
            ISymbolsPredefinedTable symbolsPredefinedTable,
            ILabelsDynamicTable labelsDynamicTable,
            ISymbolsDynamicTable symbolsDynamicTable,
            ICInstructionConverter cInstructionConverter)
        {
            _fileReader = fileReader;
            _symbolsPredefinedTable = symbolsPredefinedTable;
            _labelsDynamicTable = labelsDynamicTable;
            _symbolsDynamicTable = symbolsDynamicTable;
            _cInstructionConverter = cInstructionConverter;
        }


        /// <summary>
        /// This method executes the rest of the method.
        /// </summary>
        public void Compiler()
        {
            ConvertFiles(ReadFile());
        }



        /// <summary>
        /// This method converts the files to binary.
        /// </summary>
        /// <param name="filePaths"></param>
        public void ConvertFiles(string[] filePaths)
        {
            if (filePaths.Length == 0)
            {
                Console.WriteLine("No files found to convert. Have you added files to the directory?");
                return;
            }
            foreach (string filePath in filePaths)
            {
                try
                {
                    string? fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string? directory = Path.GetDirectoryName(filePath);
                    if (directory == null)
                    {
                        Console.WriteLine($"Could not find directory for file: {Path.GetFileName(filePath)}");
                        continue;
                    }
                    // TODO: add to appsettings.json
                    string newDirectory = @"C:\Dev\nand2tetris\projects\H5-nand2tetris\Compiler\FilesCompiled";
                    string? newFileName = $"{fileNameWithoutExtension}.txt";
                    string? newFilePath = Path.Combine(newDirectory, newFileName);

                    AddLabelsToDynamicTable(filePath);

                    StringBuilder fileContent = new StringBuilder();

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
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

                            ConvertToBinary(line, fileContent);
                        }
                        WriteToFile(newFilePath, fileContent);
                    }
                    ClearDictionaries();
                    Console.WriteLine($" New file with name: {newFileName} has been created.\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occured while trying to convert the file: {filePath}, Errorcode: {e}");
                }
            }
        }



        /// <summary>
        /// This method reads the files from the folder.
        /// </summary>
        /// <returns>Returns an array of strings containing the file paths.</returns>
        string[] ReadFile()
        {
            return _fileReader.GetFilesFromFolder();
        }



        /// <summary>
        /// This method converts the instruction to binary.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="fileContent"></param>
        void ConvertToBinary(string? line, StringBuilder fileContent)
        {
            try
            {
                //if line begins with @ and the following is an integer, then convert to 16 bit binary number
                if (!string.IsNullOrWhiteSpace(line) && line.StartsWith("@"))
                {
                    string? address = line.Substring(1);
                    if (_symbolsPredefinedTable.ReadSymbol(address) != null)
                    {
                        string? addressBinary = Convert.ToString(_symbolsPredefinedTable.ReadSymbol(address)!.Value, 2).PadLeft(16, '0');
                        fileContent.AppendLine(addressBinary);
                    }
                    else if (_labelsDynamicTable.ReadSymbol(address) != null)
                    {
                        string? addressBinary = Convert.ToString(_labelsDynamicTable.ReadSymbol(address)!.Value, 2).PadLeft(16, '0');
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
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    string instructionBinary = _cInstructionConverter.ConvertCInstruction(line);
                    fileContent.AppendLine(instructionBinary);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in line: {line} due to the following error {e}");
            }
        }



        /// <summary>
        /// This method adds labels to the dynamic table.
        /// </summary>
        /// <param name="filePath"></param>
        void AddLabelsToDynamicTable(string filePath)
        {
            // Initialize current line number as 0
            int currentLineNumber = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                try
                {
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
                            _labelsDynamicTable.AddSymbol(label, currentLineNumber);
                        }
                        else
                        {
                            currentLineNumber++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occured while trying to add labels to the dynamic table. The corrupt file is: {filePath}, Errorcode: {e}");
                }
            }
        }



        /// <summary>
        /// This method writes the content to the file.
        /// </summary>
        /// <param name="newFilePath"></param>
        /// <param name="fileContent"></param>
        void WriteToFile(string newFilePath, StringBuilder fileContent)
        {
            try
            {
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



        /// <summary>
        /// This method clears the dynamic dictionaries.
        /// </summary>
        void ClearDictionaries()
        {
            _labelsDynamicTable.ClearDictionary();
            _symbolsDynamicTable.ClearDictionary();
        }
    }
}
