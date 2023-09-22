using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the and command from the vm language to assembly
    /// </summary>
    internal interface ITranslateAnd
    {
        void Translate(StringBuilder stringBuilder);
    }
}