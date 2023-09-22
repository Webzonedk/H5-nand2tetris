namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for writing to the log file
    /// </summary>
    internal interface ILogFileWriter
    {
        void WriteLog(string errorMessage);
    }
}