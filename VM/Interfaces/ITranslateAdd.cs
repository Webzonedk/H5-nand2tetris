using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the add command from the VM language to assembly.
    /// </summary>
    internal interface ITranslateAdd
    {
        void Translate(StringBuilder stringBuilder);
    }
}