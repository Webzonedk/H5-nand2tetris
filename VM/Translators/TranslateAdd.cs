using System.Text;
using VM.Interfaces;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the add command from the VM language to assembly.
    /// </summary>
    internal class TranslateAdd : ITranslateAdd
    {

        /// <summary>
        /// This method is translating the add command from the VM language to assembly.
        /// </summary>
        /// <param name="stringBuilder"></param>
        public void Translate(StringBuilder stringBuilder)
        {
            // Decrease stack pointer and pop value into D-register
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("AM=M-1");
            stringBuilder.AppendLine("D=M");

            // Point to the next top of stack and add D to it
            stringBuilder.AppendLine("A=A-1");
            stringBuilder.AppendLine("M=M+D");
        }

    }
}
