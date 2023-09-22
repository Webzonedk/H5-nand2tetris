using System.Text;
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

        private int _tempRegisterIndex = 13;  // Start with R13 for use as temporary register

        public void Translate(string location, string value, StringBuilder stringBuilder)
        {

            //Skipping constant, as it can not be popped
            if (location != "constant")
            {
                // Translate the segment and load its base address into D
                string segmentPointer = _segmentHandler.TranslateSegment(location, value);
                if (location == "static")
                {
                    stringBuilder.AppendLine($"@{int.Parse(segmentPointer) + int.Parse(value)}");  // Go to the static address
                    stringBuilder.AppendLine("D=A");  // D = static address
                }
                else if (location == "pointer")
                {
                    stringBuilder.AppendLine($"@{segmentPointer}");  // Go to segment base address (THIS or THAT)
                    stringBuilder.AppendLine("D=A");  // D = base address of segment
                }
                else if (location == "temp")
                {
                    stringBuilder.AppendLine($"@R{segmentPointer}");  // Go to segment base address
                    stringBuilder.AppendLine("D=M");  // D = base address of segment
                    stringBuilder.AppendLine($"@{int.Parse(value) + int.Parse(segmentPointer)}");  // Go to offset
                    stringBuilder.AppendLine("D=D+A");  // D = base address + offset
                }
                else
                {
                    stringBuilder.AppendLine($"@{segmentPointer}");  // Go to segment base address
                    stringBuilder.AppendLine("D=M");  // D = base address of segment
                    stringBuilder.AppendLine($"@{value}");  // Go to offset
                    stringBuilder.AppendLine("D=D+A");  // D = base address + offset
                }

                // Store the address for later use
                stringBuilder.AppendLine("@R13");  // Use R13 as a temporary register
                stringBuilder.AppendLine("M=D");  // R13 = address to pop to

                // Pop the value from the stack into D-register
                stringBuilder.AppendLine("@SP");  // Go to stack pointer
                stringBuilder.AppendLine("AM=M-1");  // Decrease stack pointer and point to top of stack
                stringBuilder.AppendLine("D=M");  // D = popped value

                // Move the popped value to the target address
                stringBuilder.AppendLine("@R13");  // Go to the address stored in R13
                stringBuilder.AppendLine("A=M");  // Dereference R13 to get the target address
                stringBuilder.AppendLine("M=D");  // Store the popped value at the target address
            }
        }
    }
}
