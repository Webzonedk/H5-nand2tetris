using System.Text;

namespace VM.Interfaces
{
    internal interface ITranslateWithUniqueCounter
    {
        public void Translate(int uniqueLabelId, StringBuilder stringBuilder);
    }
}