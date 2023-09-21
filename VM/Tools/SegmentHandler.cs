using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Tools
{
    internal class SegmentHandler : ISegmentHandler
    {
        public string TranslateSegment(string segment)
        {
            switch (segment)
            {
                case "local":
                    return "LCL";
                case "argument":
                    return "ARG";
                case "this":
                    return "THIS";
                case "that":
                    return "THAT";
                case "temp":
                    return "5";
                default:
                    throw new ArgumentException("Invalid segment");
            }
        }
    }
}
