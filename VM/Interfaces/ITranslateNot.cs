using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the not command from the vm language to assembly
    /// </summary>
    internal interface ITranslateNot
    {
        void Translate(StringBuilder stringBuilder);
    }
}