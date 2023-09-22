using System.Text;
using VM.Interfaces;
using VM.Tools;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the push command from the vm language to assembly
    /// </summary>
    internal class TranslatePush : ITranslatePush
    {

        private readonly ISegmentHandler _segmentHandler;
        private readonly ILogFileWriter _logFileWriter;


        public TranslatePush(ISegmentHandler segmentHandler, ILogFileWriter logFileWriter)
        {
            _segmentHandler = segmentHandler;
            _logFileWriter = logFileWriter;
        }

        /// <summary>
        /// This method translates the push command from the vm language to assembly
        /// </summary>
        /// <param name="location"></param>
        /// <param name="value"></param>
        /// <param name="stringBuilder"></param>
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
                    if(!int.TryParse(segmentPointer,out int segmentPointerAsInteger))
                    {
                        _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse segmentPointer to integer in a push static instruction.");
                        Environment.Exit(1);
                    }
                    if(!int.TryParse(value,out int valueAsInteger))
                    {
                        _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse value to integer in a push static instruction.");
                        Environment.Exit(1);
                    }
                    stringBuilder.AppendLine($"@{segmentPointerAsInteger + valueAsInteger}");  // Go to the static address
                    stringBuilder.AppendLine("D=M");  // D = value at static address
                }
                else
                {
                    if (location == "temp")
                    {
                        if (!int.TryParse(segmentPointer, out int segmentPointerAsInteger))
                        {
                            _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse segmentPointer to integer in a push temp instruction.");
                            Environment.Exit(1);
                        }
                        if (!int.TryParse(value, out int valueAsInteger))
                        {
                            _logFileWriter.WriteLog($"{DateTime.Now} - Error: Failed to parse value to integer in a push temp instruction.");
                            Environment.Exit(1);
                        }
                        stringBuilder.AppendLine($"@R{segmentPointer}");  // Go to segment base address
                        stringBuilder.AppendLine("D=M");  // D = base address of segment
                        stringBuilder.AppendLine($"@{segmentPointerAsInteger + valueAsInteger}");  // Go to offset
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
