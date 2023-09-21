﻿using System;
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
            if (location == "constant")
            {
                stringBuilder.AppendLine($"@{value}   // Read value {value}");
                stringBuilder.AppendLine("D=A         // Set D-register to value");
            }
            else
            {
                string segmentPointer = _segmentHandler.TranslateSegment(location);
                stringBuilder.AppendLine($"@{segmentPointer} // Go to segment {location}");
                stringBuilder.AppendLine("D=M           // D = base address of segment");
                stringBuilder.AppendLine($"@{value}      // Read value {value}");
                stringBuilder.AppendLine("A=D+A         // A = base address + offset");
                stringBuilder.AppendLine("D=M           // D = value to push");
            }
            stringBuilder.AppendLine("@SP         // Go to stack pointer");
            stringBuilder.AppendLine("A=M         // Point to top of stack");
            stringBuilder.AppendLine("M=D         // Push value to stack");
            stringBuilder.AppendLine("@SP         // Go back to stack pointer");
            stringBuilder.AppendLine("M=M+1       // Increase stack pointer");
        }
    }
}
