using System.Text;

namespace VM.Interfaces
{
    internal interface ITranslateGt
    {
        void Translate(int uniqueLabelId, StringBuilder stringBuilder);
    }
}