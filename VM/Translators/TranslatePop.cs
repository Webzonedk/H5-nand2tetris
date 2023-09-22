using System.Text;
using VM.Interfaces;
using VM.Tools;

namespace VM.Translators
{
    internal class TranslatePop : ITranslateWithLocationAndValue
    {
        private readonly ISegmentHandler _segmentHandler;

        public TranslatePop(ISegmentHandler segmentHandler)
        {
            _segmentHandler = segmentHandler;
        }

        public void Translate(string location, string value, StringBuilder stringBuilder)
        {
            // Decrease stack pointer and pop value into D-register
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("M=M-1");
            stringBuilder.AppendLine("A=M");
            stringBuilder.AppendLine("D=M");

            // If the location is a constant, store the popped value directly
            if (location == "constant")
            {
                stringBuilder.AppendLine($"@{value}");
                stringBuilder.AppendLine("M=D");
            }
            else
            {
                // Translate the segment and load its base address into D
                string segmentPointer = _segmentHandler.TranslateSegment(location);
                stringBuilder.AppendLine($"@{segmentPointer}");
                stringBuilder.AppendLine("D=M");

                // Add the offset to the base address and store the popped value
                stringBuilder.AppendLine($"@{value}");
                stringBuilder.AppendLine("A=D+A");
                stringBuilder.AppendLine("M=D");
            }
        }

    }

}
