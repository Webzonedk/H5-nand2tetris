using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;

namespace VM.Translators
{
    internal class TranslateNeg : ITranslateWithCommandOnly
    {

        public void Translate(StringBuilder stringBuilder)
        {
            // Set D-register to 0
            stringBuilder.AppendLine("D=0");

            // Point to the top of the stack
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M-1");

            // Negate the top of the stack
            stringBuilder.AppendLine("M=D-M");
        }

    }
}
