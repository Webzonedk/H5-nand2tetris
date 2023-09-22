using System.Text;
using VM.Interfaces;
using VM.Tools;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the pop command from the vm language to assembly
    /// </summary>
    internal class TranslatePop : ITranslatePop
    {
        private readonly ISegmentHandler _segmentHandler;
        private readonly ILogFileWriter _logFileWriter;

        public TranslatePop(ISegmentHandler segmentHandler, ILogFileWriter logFileWriter)
        {
            _segmentHandler = segmentHandler;
            _logFileWriter = logFileWriter;
        }

        /// <summary>
        /// This method translates the pop command from the vm language to assembly
        /// </summary>
        /// <param name="location"></param>
        /// <param name="value"></param>
        /// <param name="stringBuilder"></param>
        public void Translate(string location, string value, StringBuilder stringBuilder)
        {

            //Skipping constant, as it can not be popped
            if (location != "constant")
            {
                // Translate the segment and load its base address into D
                string segmentPointer = _segmentHandler.TranslateSegment(location, value);
                if (location == "static")
                {
                    if (!int.TryParse(segmentPointer, out int segmentPointerAsInteger))
                    {
                        _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse segmentPointer to integer in a pop static instruction.");
                        Environment.Exit(1);
                    }
                    if (!int.TryParse(value, out int valueAsInteger))
                    {
                        _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse value to integer in a pop static instruction.");
                        Environment.Exit(1);
                    }
                    stringBuilder.AppendLine($"@{segmentPointerAsInteger + valueAsInteger}");  // Go to the static address
                    stringBuilder.AppendLine("D=A");  // D = static address
                }
                else if (location == "pointer")
                {
                    stringBuilder.AppendLine($"@{segmentPointer}");  // Go to segment base address (THIS or THAT)
                    stringBuilder.AppendLine("D=A");  // D = base address of segment
                }
                else if (location == "temp")
                {
                    if (!int.TryParse(segmentPointer, out int segmentPointerAsInteger))
                    {
                        _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse segmentPointer to integer in a pop temp instruction.");
                        Environment.Exit(1);
                    }
                    if (!int.TryParse(value, out int valueAsInteger))
                    {
                        _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse value to integer in a pop temp instruction.");
                        Environment.Exit(1);
                    }
                    stringBuilder.AppendLine($"@R{segmentPointer}");  // Go to segment base address
                    stringBuilder.AppendLine("D=M");  // D = base address of segment
                    stringBuilder.AppendLine($"@{segmentPointerAsInteger + valueAsInteger}");  // Go to offset
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
