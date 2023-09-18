using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Interfaces
{
    internal interface ICInstructionConverter
    {
        public string ConvertCInstruction(string instruction);
    }
}
