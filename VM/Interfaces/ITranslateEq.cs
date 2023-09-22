using System.Text;

namespace VM.Interfaces
{
    internal interface ITranslateEq
    {
        void Translate(int uniqueLabelId, StringBuilder stringBuilder);
    }
}