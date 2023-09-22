using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for writing the assembly code to a file
    /// </summary>
    internal interface IFileWriter
    {
        public void WriteToFile(string fileNameWithoutExtension, StringBuilder fileContent);
    }
}
