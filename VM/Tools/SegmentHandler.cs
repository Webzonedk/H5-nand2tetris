using VM.Interfaces;

namespace VM.Tools
{
    /// <summary>
    /// This class is responsible for translating the segment command from the vm language to assembly
    /// </summary>
    internal class SegmentHandler : ISegmentHandler
    {
        private readonly ILogFileWriter _logFileWriter;


        public SegmentHandler(ILogFileWriter logFileWriter)
        {
            _logFileWriter = logFileWriter;
        }
        /// <summary>
        /// This method is responsible for translating the segment command from the vm language to assembly
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="value"></param>
        /// <returns>Returns the translated segment</returns>
        /// <exception cref="ArgumentException"></exception>
        public string TranslateSegment(string segment, string value)
        {
            switch (segment)
            {
                case "local":
                    return "LCL";
                case "argument":
                    return "ARG";
                case "this":
                    return "THIS";
                case "pointer":
                    if (value == "0")
                    {
                        return "THIS";
                    }
                    else if (value == "1")
                    {
                        return "THAT";
                    }
                    else
                    {
                        _logFileWriter.WriteLog($"{DateTime.Now} - Error: An error occurred in the segmentHandler. Pointer value is invalid");
                        Environment.Exit(1);
                        return null;
                    }
                case "that":
                    return "THAT";
                case "temp":
                    return "5";
                case "static":
                    return "16";
                default:
                    _logFileWriter.WriteLog($"{DateTime.Now} - Error: An error occurred in the segmentHandler. No valid segment was recognized");
                    Environment.Exit(1);
                    return null;
            }
        }
    }
}
