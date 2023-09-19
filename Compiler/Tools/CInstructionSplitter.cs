using Compiler.Interfaces;
using System;

namespace Compiler.Tools
{
    /// <summary>
    /// This class is used to split the C-instruction into its parts.
    /// </summary>
    internal class CInstructionSplitter : ICInstructionSplitter
    {
        public string? Dest { get; private set; }
        public string? Comp { get; private set; }
        public string? Jump { get; private set; }



        /// <summary>
        /// This method is used to split the C-instruction into its parts.
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns>Returns a CInstructionSplitter object.</returns>
        public CInstructionSplitter SplitLine(string instruction)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while splitting the C-instruction. Error code: {e}");
                throw;
            }
        }
    }
}
