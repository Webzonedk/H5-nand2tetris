using Compiler.Tools;

namespace Compiler.Interfaces
{
    /// <summary>
    /// This interface is used to split the C-instruction into its parts.
    /// </summary>
    internal interface ICInstructionSplitter
    {
        public CInstructionSplitter SplitLine(string instruction);
    }
}
