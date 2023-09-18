using Compiler.Tools;

namespace Compiler.Interfaces
{
    internal interface ICInstructionSplitter
    {
        public CInstructionSplitter SplitLine(string instruction);
    }
}
