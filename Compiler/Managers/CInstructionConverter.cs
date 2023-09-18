using Compiler.Interfaces;
using Compiler.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Managers
{
    internal class CInstructionConverter : ICInstructionConverter
    {
        private readonly ICInstructionAssembler _instructionAssembler;
        private readonly ICInstructionSplitter _instructionSplitter;

        public CInstructionConverter(ICInstructionSplitter instructionSplitter, ICInstructionAssembler instructionAssembler)
        {
            _instructionSplitter = instructionSplitter;
            _instructionAssembler = instructionAssembler;
        }


        /// <summary>
        /// This method converts a C-instruction to a binary instruction
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns>Returns a binary C-instruction</returns>
        public string ConvertCInstruction(string instruction)
        {
            CInstructionSplitter splittedInstruction = _instructionSplitter.SplitLine(instruction);
            return _instructionAssembler.AssembleInstruction(splittedInstruction);
        }
    }
}
