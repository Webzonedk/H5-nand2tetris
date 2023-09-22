using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Translators
{
    internal class TranslateAnd : ITranslateAnd
    {

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
