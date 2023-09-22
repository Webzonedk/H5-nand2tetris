using System.Text;

namespace VM.Interfaces
{
    /// <summary>
    /// This interface is responsible for translating the push command from the vm language to assembly
    /// </summary>
    internal interface ITranslatePush
    {
        void Translate(string location, string value, StringBuilder stringBuilder);
    }
}