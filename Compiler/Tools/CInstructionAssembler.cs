using Compiler.Interfaces;
using Compiler.Tables;
using System.Text;

namespace Compiler.Tools
{
    /// <summary>
    /// This class is used to assemble the C-instruction into its binary code.
    /// </summary>
    internal class CInstructionAssembler : ICInstructionAssembler
    {
        private readonly ICInstructionTable _instructionTable;

        public CInstructionAssembler(ICInstructionTable instructionTable)
        {
            _instructionTable = instructionTable;
        }



        /// <summary>
        /// This method assembles the C-instruction into its binary code.
        /// </summary>
        /// <param name="splittedInstruction"></param>
        /// <returns>Returns a binary C-instruction.</returns>
        public string AssembleInstruction(CInstructionSplitter splittedInstruction)
        {
            try
            {
                string? comp = splittedInstruction?.Comp != null ? _instructionTable.ConvertComp(splittedInstruction.Comp) : null;
                string? dest = splittedInstruction?.Dest != null ? _instructionTable.ConvertDest(splittedInstruction.Dest) : null;
                string? jump = splittedInstruction?.Jump != null ? _instructionTable.ConvertJump(splittedInstruction.Jump) : null;

                if (comp == null)
                {
                    comp = "0000000";
                }
                if (dest == null)
                {
                    dest = "000";
                }
                if (jump == null)
                {
                    jump = "000";
                }

                StringBuilder instructionBuilder = new StringBuilder();
                instructionBuilder.Append("111");
                instructionBuilder.Append(comp);
                instructionBuilder.Append(dest);
                instructionBuilder.Append(jump);

                return instructionBuilder.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while assembling c-instructions. Errorcode: {e}");
                throw;
            }
        }
    }
}
