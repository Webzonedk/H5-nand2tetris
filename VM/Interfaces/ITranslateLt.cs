using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the lt command from the vm language to assembly
    /// </summary>
    internal interface ITranslateLt
    {
        void Translate(int uniqueLabelId, StringBuilder stringBuilder);
    }
}