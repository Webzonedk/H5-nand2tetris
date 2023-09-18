using Compiler.Interfaces;

namespace Compiler.Tools
{
    /// <summary>
    /// This class is used to split the C-Instruction into its components.
    /// </summary>
    internal class CInstructionSplitter : ICInstructionSplitter
    {
        public string? Dest { get; set; }
        public string? Comp { get; set; }
        public string? Jump { get; set; }


        /// <summary>
        /// This method splits the C-Instruction into its components.
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns>Returns a CInstructionSplitter object.</returns>
        public CInstructionSplitter SplitLine(string instruction)
        {
            Dest = "null";
            Comp = "null";
            Jump = "null";

            if (instruction.Contains('='))
            {
                var split = instruction.Split('=');
                Dest = split[0];
                instruction = split[1];
            }

            if (instruction.Contains(';'))
            {
                var split = instruction.Split(';');
                Comp = split[0];
                Jump = split[1];
            }
            else
            {
                Comp = instruction;
            }

            return this;
        }

    }
}
