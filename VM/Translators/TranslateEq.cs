using System.Text;
using VM.Interfaces;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the eq command from the vm language to assembly
    /// </summary>
    internal class TranslateEq : ITranslateEq
    {
        /// <summary>
        /// This method is responsible for translating the eq command from the vm language to assembly
        /// </summary>
        /// <param name="uniqueLabelId"></param>
        /// <param name="stringBuilder"></param>
        public void Translate(int uniqueLabelId, StringBuilder stringBuilder)
        {
            // Generate unique labels for this specific EQ operation
            string falseLabel = $"FALSE{uniqueLabelId}";
            string continueLabel = $"CONTINUE{uniqueLabelId}";

            // Go to stack pointer and decrease it to pop the first value into D
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("AM=M-1");
            stringBuilder.AppendLine("D=M");

            // Point to the next top of the stack and subtract D from it
            stringBuilder.AppendLine("A=A-1");
            stringBuilder.AppendLine("D=M-D");

            // Jump to FALSE label if D is not zero (i.e., the two values are not equal)
            stringBuilder.AppendLine($"@{falseLabel}");
            stringBuilder.AppendLine("D;JNE");

            // Set the top of the stack to -1 (True)
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M-1");
            stringBuilder.AppendLine("M=-1");

            // Jump to CONTINUE label
            stringBuilder.AppendLine($"@{continueLabel}");
            stringBuilder.AppendLine("0;JMP");

            // FALSE label: set the top of the stack to 0 (False)
            stringBuilder.AppendLine($"({falseLabel})");
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M-1");
            stringBuilder.AppendLine("M=0");

            // CONTINUE label
            stringBuilder.AppendLine($"({continueLabel})");
        }

    }
}
