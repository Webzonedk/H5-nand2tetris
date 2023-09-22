using System.Text;
using VM.Interfaces;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the and command from the vm language to assembly
    /// </summary>
    internal class TranslateAnd : ITranslateAnd
    {
        /// <summary>
        /// This method is responsible for translating the and command from the vm language to assembly
        /// </summary>
        /// <param name="stringBuilder"></param>
        public void Translate(StringBuilder stringBuilder)
        {
            // Point to the stack pointer and decrease it
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("AM=M-1");

            // Pop the top value into D-register
            stringBuilder.AppendLine("D=M");

            // Point to the next top of the stack
            stringBuilder.AppendLine("A=A-1");

            // Perform bitwise AND and store the result
            stringBuilder.AppendLine("M=M&D");
        }


    }
}
