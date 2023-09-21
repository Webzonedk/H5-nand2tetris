using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Models
{
    internal class VMInstruction
    {
        public string? Command { get; set; }
        public string? Location { get; set; }
        public string? Value { get; set; }

    }
}
