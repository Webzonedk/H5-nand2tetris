using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the neg command from the vm language to assembly
    /// </summary>
    internal interface ITranslateNeg
    {
        void Translate(StringBuilder stringBuilder);
    }
}