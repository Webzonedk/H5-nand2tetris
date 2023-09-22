using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the pop command from the vm language to assembly
    /// </summary>
    internal interface ITranslatePop
    {
        void Translate(string location, string value, StringBuilder stringBuilder);
    }
}