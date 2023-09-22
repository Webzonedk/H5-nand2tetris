using System.Text;

namespace VM.Interfaces
{
    internal interface ITranslateWithLocationAndValue
    {
        void Translate(string location, string value, StringBuilder stringBuilder);
    }
}