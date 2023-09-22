using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Interfaces;
using VM.Tools;

namespace VM.Translators
{
    internal class TranslatePush : ITranslateWithLocationAndValue
    {

        private readonly ISegmentHandler _segmentHandler;


        public TranslatePush(ISegmentHandler segmentHandler)
        {
            _segmentHandler = segmentHandler;
        }


        public void Translate(string location, string value, StringBuilder stringBuilder)
        {
            // If the location is a constant, directly load the value into D
            if (location == "constant")
            {
                stringBuilder.AppendLine($"@{value}");
                stringBuilder.AppendLine("D=A");
            }
            else
            {
                // Translate the segment and load its base address into D
                string segmentPointer = _segmentHandler.TranslateSegment(location);
                stringBuilder.AppendLine($"@{segmentPointer}");
                stringBuilder.AppendLine("D=M");

                // Add the offset to the base address and load the value into D
                stringBuilder.AppendLine($"@{value}");
                stringBuilder.AppendLine("A=D+A");
                stringBuilder.AppendLine("D=M");
            }

            // Push the value in D onto the stack
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M");
            stringBuilder.AppendLine("M=D");

            // Increment the stack pointer
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("M=M+1");
        }

    }
}
