using System.Text;

namespace VM.Interfaces
{
    internal interface ITranslatePop
    {
        void Translate(string location, string value, StringBuilder stringBuilder);
    }
}