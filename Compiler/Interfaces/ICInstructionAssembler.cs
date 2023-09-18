using Compiler.Tools;

namespace Compiler.Interfaces
{
    internal interface ICInstructionAssembler
    {
        public string AssembleInstruction(CInstructionSplitter splittedInstruction);
    }
}
