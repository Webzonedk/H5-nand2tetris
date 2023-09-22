using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the gt command from the vm language to assembly
    /// </summary>
    internal interface ITranslateGt
    {
        void Translate(int uniqueLabelId, StringBuilder stringBuilder);
    }
}