using Microsoft.Extensions.Configuration;
using VM.Interfaces;

namespace VM.Tools
{
    /// <summary>
    /// This class is responsible for writing the log file
    /// But it is not implemented, but ready if needed
    /// </summary>
    internal class LogFileWriter : ILogFileWriter
    {
        private readonly IConfiguration _configuration;
        private readonly string _logFilePath;

        public LogFileWriter(IConfiguration configuration)
        {
            _configuration = configuration;
            string? logFolder = _configuration["FilePaths:LogFolder"];
            _logFilePath = Path.Combine(logFolder, "logfile.txt");
        }

        public void WriteLog(string errorMessage)
        {
            try
            {
                // Open the log file for appending text and write the log
                using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
                {
                    writer.WriteLine($"{DateTime.UtcNow}: ERROR - {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the logging process
                Console.WriteLine($"Failed to log error:{errorMessage}\n Reason: {ex.Message}\nPlease contact God and ask for forgiveness!");
            }
        }
    }
}
