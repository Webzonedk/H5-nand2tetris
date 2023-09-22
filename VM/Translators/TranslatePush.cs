using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;
using VM.Tools;

namespace VM.Translators
{
    internal class TranslatePush : ITranslatePush
    {

        private readonly ISegmentHandler _segmentHandler;


        public TranslatePush(ISegmentHandler segmentHandler)
        {
            _segmentHandler = segmentHandler;
        }


        public void Translate(string location, string value, StringBuilder stringBuilder)
        {
            // If the location is a constant, load the constant value into D-register
            if (location == "constant")
            {
                stringBuilder.AppendLine($"@{value}");  // Load constant value into A-register
                stringBuilder.AppendLine("D=A");  // Store constant in D-register
            }
            else if (location == "pointer")
            {
                // Translate the segment and load its base address into D
                string segmentPointer = _segmentHandler.TranslateSegment(location, value);
                stringBuilder.AppendLine($"@{segmentPointer}");  // Go to segment base address (THIS or THAT)
                stringBuilder.AppendLine("D=M");  // D = base address of segment
            }
            else
            {
                // Translate the segment and load its base address into D
                string segmentPointer = _segmentHandler.TranslateSegment(location, value);
                if (location == "static")
                {
                    stringBuilder.AppendLine($"@{int.Parse(segmentPointer) + int.Parse(value)}");  // Go to the static address
                    stringBuilder.AppendLine("D=M");  // D = value at static address
                }
                else
                {
                    if (location == "temp")
                    {
                        stringBuilder.AppendLine($"@R{segmentPointer}");  // Go to segment base address
                        stringBuilder.AppendLine("D=M");  // D = base address of segment
                        stringBuilder.AppendLine($"@{int.Parse(value) + int.Parse(segmentPointer)}");  // Go to offset
                    }
                    else
                    {
                        stringBuilder.AppendLine($"@{segmentPointer}");  // Go to segment base address
                        stringBuilder.AppendLine("D=M");  // D = base address of segment
                        stringBuilder.AppendLine($"@{value}");  // Go to offset
                    }
                    stringBuilder.AppendLine("A=D+A");  // A = base address + offset
                    stringBuilder.AppendLine("D=M");  // D = value to push
                }
            }

            // Push the value from D-register to the top of the stack
            stringBuilder.AppendLine("@SP");  // Go to stack pointer
            stringBuilder.AppendLine("A=M");  // Point to top of stack
            stringBuilder.AppendLine("M=D");  // Push value to top of stack
            stringBuilder.AppendLine("@SP");  // Go to stack pointer
            stringBuilder.AppendLine("M=M+1");  // Increase stack pointer
        }
    }
}
