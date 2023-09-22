using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the sub command from the VM language to assembly.
    /// </summary>
    internal interface ITranslateSub
    {
        void Translate(StringBuilder stringBuilder);
    }
}