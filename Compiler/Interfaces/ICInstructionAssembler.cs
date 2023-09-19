using Compiler.Tools;

namespace Compiler.Interfaces
{
    /// <summary>
    /// This interface is used to assemble the C-instruction into its binary code.
    /// </summary>
    internal interface ICInstructionAssembler
    {
        public string AssembleInstruction(CInstructionSplitter splittedInstruction);
    }
}
