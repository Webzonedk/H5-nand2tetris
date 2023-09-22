using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Translators
{
    internal class TranslateLt : ITranslateLt
    {
        public void Translate(int uniqueLabelId, StringBuilder stringBuilder)
        {
            // Generate unique labels for this operation
            string falseLabel = $"FALSE{uniqueLabelId}";
            string continueLabel = $"CONTINUE{uniqueLabelId}";

            // Decrease stack pointer and pop value into D-register
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("AM=M-1");
            stringBuilder.AppendLine("D=M");

            // Point to the next top of stack and subtract D from it
            stringBuilder.AppendLine("A=A-1");
            stringBuilder.AppendLine("D=M-D");

            // Conditional jump to FALSE label if D >= 0
            stringBuilder.AppendLine($"@{falseLabel}");
            stringBuilder.AppendLine("D;JGE");

            // Set the top of stack to True (-1)
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M-1");
            stringBuilder.AppendLine("M=-1");

            // Unconditional jump to CONTINUE label
            stringBuilder.AppendLine($"@{continueLabel}");
            stringBuilder.AppendLine("0;JMP");

            // FALSE label: Set the top of stack to False (0)
            stringBuilder.AppendLine($"({falseLabel})");
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M-1");
            stringBuilder.AppendLine("M=0");

            // CONTINUE label
            stringBuilder.AppendLine($"({continueLabel})");
        }
    }
}
