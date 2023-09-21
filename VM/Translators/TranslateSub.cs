using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Translators
{
    internal class TranslateSub
    {

        public void Translate(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("@SP      // Go to stack pointer");
            stringBuilder.AppendLine("AM=M-1   // Decrease stack pointer and go to top of stack");
            stringBuilder.AppendLine("D=M      // D = popped value");
            stringBuilder.AppendLine("A=A-1    // Point to next top of stack");
            stringBuilder.AppendLine("M=M-D    // substracts D from the next top value and store it");
        }
    }
}
