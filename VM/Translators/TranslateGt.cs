using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Translators
{
    internal class TranslateGt : ITranslateGt
    {

        public void Translate(int uniqueLabelId, StringBuilder stringBuilder)
        {
            // Unique labels for this specific "gt" operation
            string falseLabel = $"FALSE{uniqueLabelId}";
            string continueLabel = $"CONTINUE{uniqueLabelId}";

            // Decrease stack pointer and pop value into D-register
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("AM=M-1");
            stringBuilder.AppendLine("D=M");

            // Point to the next top of stack and subtract D from it
            stringBuilder.AppendLine("A=A-1");
            stringBuilder.AppendLine("D=M-D");

            // Jump to FALSE label if D <= 0
            stringBuilder.AppendLine($"@{falseLabel}");
            stringBuilder.AppendLine("D;JLE");

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
