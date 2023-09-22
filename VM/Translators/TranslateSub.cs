using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Translators
{
    internal class TranslateSub : ITranslateSub
    {
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
