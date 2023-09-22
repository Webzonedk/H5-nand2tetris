using System.Text;
using VM.Interfaces;
using VM.Tools;
using VM.Translators;

namespace VM.Managers
{
    /// <summary>
    /// This class is responsible for converting the vm files to assembly
    /// </summary>
    internal class VmConverter : IVmConverter
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly ICommandMapper _commandMapper;
        private readonly ILogFileWriter _logFileWriter;
        private readonly ITranslateEndLoop _translateEndLoop;



        public VmConverter(
            IFileReader fileReader,
            IFileWriter fileWriter,
            ICommandMapper commandMapper,
            ILogFileWriter logFileWriter,
            ITranslateEndLoop translateEndLoop
            )
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _commandMapper = commandMapper;
            _logFileWriter = logFileWriter;
            _translateEndLoop = translateEndLoop;
        }


        /// <summary>
        /// This method calls the method ConvertVmToAssembly including the files from the folder
        /// </summary>
        public void Convert()
        {
            ConvertVmToAssembly(_fileReader.GetFilesFromFolder());
        }



        /// <summary>
        /// This method converts the vm files to assembly
        /// </summary>
        /// <param name="filePaths"></param>
        private void ConvertVmToAssembly(string[] filePaths)
        {
            if (filePaths.Length == 0)
            {
                _logFileWriter.WriteLog($"{DateTime.Now} - Error: VmConverter No files found to convert.");
                Environment.Exit(1);
            }

            foreach (string filePath in filePaths)
            {
                string? directory = Path.GetDirectoryName(filePath);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string[] fileContent = File.ReadAllLines(filePath);
                StringBuilder stringBuilder = new StringBuilder();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    int uniqueCounter = 0;
                    string line;
                    while ((line = reader.ReadLine()!) != null)
                    {
                        string[] splitLine = line.Split(" ");
                        string command = splitLine.Length > 0 ? splitLine[0] : string.Empty;
                        string location = splitLine.Length > 1 ? splitLine[1] : string.Empty;
                        string value = splitLine.Length > 2 ? splitLine[2] : string.Empty;

                        if (String.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
                        {
                            continue;
                        }
                        else if (_commandMapper.CommandMap.ContainsKey(command))
                        {
                            _commandMapper.CommandMap[command](stringBuilder);
                        }
                        else if (_commandMapper.CommandMapWithUniqueCounter.ContainsKey(command))
                        {
                            _commandMapper.CommandMapWithUniqueCounter[command](uniqueCounter, stringBuilder);
                            uniqueCounter++;
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
                            _logFileWriter.WriteLog($"{DateTime.Now} - Error: Unknown command in file:{filePath} The error occurred in this command: {line}");
                            Environment.Exit(1);
                        }
                    }
                    _translateEndLoop.Translate(stringBuilder);
                }
                _fileWriter.WriteToFile(fileNameWithoutExtension, stringBuilder);
            }
        }
    }
}
