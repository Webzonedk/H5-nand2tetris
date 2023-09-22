using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the or command from the vm language to assembly
    /// </summary>
    internal interface ITranslateOr
    {
        void Translate(StringBuilder stringBuilder);
    }
}