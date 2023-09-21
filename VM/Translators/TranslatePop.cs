using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;
using VM.Tools;

namespace VM.Translators
{
    internal class TranslatePop : ITranslatePop
    {
        private readonly ISegmentHandler _segmentHandler;

        public TranslatePop(ISegmentHandler segmentHandler)
        {
            _segmentHandler = segmentHandler;
        }

        public void Translate(string location, string value, StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("@SP         // Go to stack pointer");
            stringBuilder.AppendLine("M=M-1       // Decrease stack pointer");
            stringBuilder.AppendLine("A=M         // Point to top of stack");
            stringBuilder.AppendLine("D=M         // Pop value into D-register");

            if (location == "constant")
            {
                stringBuilder.AppendLine($"@{value}   // Go to constant location {value}");
                stringBuilder.AppendLine("M=D         // Store popped value");
            }
            else
            {
                string segmentPointer = _segmentHandler.TranslateSegment(location);
                stringBuilder.AppendLine($"@{segmentPointer} // Go to segment {location}");
                stringBuilder.AppendLine("D=M           // D = base address of segment");
                stringBuilder.AppendLine($"@{value}      // Go to offset {value}");
                stringBuilder.AppendLine("A=D+A         // A = base address + offset");
                stringBuilder.AppendLine("M=D           // Store popped value");
            }
        }
    }

}
