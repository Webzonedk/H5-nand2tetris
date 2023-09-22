using System.Text;
using VM.Interfaces;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the not command from the vm language to assembly
    /// </summary>
    internal class TranslateNot : ITranslateNot
    {
        /// <summary>
        /// This method translates the not command from the vm language to assembly
        /// </summary>
        /// <param name="stringBuilder"></param>
        public void Translate(StringBuilder stringBuilder)
        {
            // Point to the top of the stack
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M-1");

            // Perform NOT on the top of the stack
            stringBuilder.AppendLine("M=!M");
        }
    }
}
