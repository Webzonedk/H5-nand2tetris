using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;
using VM.Tools;

namespace VM.Translators
{
    internal class TranslateAdd : ITranslateAdd
    {


        public void Translate(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("@SP         // Go to stack pointer");
            stringBuilder.AppendLine("AM=M-1      // Decrease stack pointer and go to top of stack");
            stringBuilder.AppendLine("D=M         // D = popped value");

            stringBuilder.AppendLine("@SP         // Go to stack pointer");
            stringBuilder.AppendLine("AM=M-1      // Decrease stack pointer and go to top of stack");
            stringBuilder.AppendLine("D=D+M       // D = D + popped value");

            stringBuilder.AppendLine("@SP         // Go to stack pointer");
            stringBuilder.AppendLine("A=M         // Point to top of stack");
            stringBuilder.AppendLine("M=D         // Push D onto stack");

            stringBuilder.AppendLine("@SP         // Go to stack pointer");
            stringBuilder.AppendLine("M=M+1       // Increment stack pointer");
        }
    }
}
