using System.Text;
using VM.Interfaces;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the sub command from the vm language to assembly
    /// </summary>
    internal class TranslateSub : ITranslateSub
    {
        /// <summary>
        /// This method translates the sub command from the vm language to assembly
        /// </summary>
        /// <param name="stringBuilder"></param>
        public void Translate(StringBuilder stringBuilder)
        {
            // Go to stack pointer and decrease it to pop the first value into D
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("AM=M-1");

            // Store the popped value into D
            stringBuilder.AppendLine("D=M");

            // Point to the next top of the stack
            stringBuilder.AppendLine("A=A-1");

            // Subtract D from the next top value and store it
            stringBuilder.AppendLine("M=M-D");
        }
    }
}
