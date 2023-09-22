using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Tools
{
    internal class SegmentHandler : ISegmentHandler
    {
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
                        return "THIS";
                    else if (value == "1")
                        return "THAT";
                    else
                        throw new ArgumentException("Invalid pointer value");
                case "that":
                    return "THAT";
                case "temp":
                    return "5";
                case "static":
                    return "16";
                default:
                    throw new ArgumentException("Invalid segment");
            }
        }
    }
}
