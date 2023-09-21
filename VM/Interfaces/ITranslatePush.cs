using System.Text;

namespace VM.Interfaces
{
    internal interface ITranslatePush
    {
        void Translate(string location, string value, StringBuilder stringBuilder);
    }
}