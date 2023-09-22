using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Translators
{
    internal class TranslateNot : ITranslateNot
    {
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
