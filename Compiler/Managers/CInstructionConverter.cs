using Compiler.Interfaces;
using Compiler.Tools;

namespace Compiler.Managers
{
    /// <summary>
    /// This class converts a C-instruction to a binary instruction
    /// </summary>
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
