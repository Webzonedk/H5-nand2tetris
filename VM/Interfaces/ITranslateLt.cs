using System.Text;

namespace VM.Interfaces
{
    internal interface ITranslateLt
    {
        void Translate(int uniqueLabelId, StringBuilder stringBuilder);
    }
}