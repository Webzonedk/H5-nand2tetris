namespace VM.Interfaces
{
    /// <summary>
    /// This interface is used to read the files from the folder.
    /// </summary>
    internal interface IFileReader
    {
        public string[] GetFilesFromFolder();
    }
}
