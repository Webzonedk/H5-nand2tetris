using Compiler.Interfaces;
using Compiler.Tables;
using System.Text;

namespace Compiler.Tools
{
    internal class CInstructionAssembler : ICInstructionAssembler
    {
        private readonly ICInstructionTable _instructionTable;

        public CInstructionAssembler(ICInstructionTable instructionTable)
        {
            _instructionTable = instructionTable;
        }

        public string AssembleInstruction(CInstructionSplitter splittedInstruction)
        {
            // Attempt to convert mnemonics to binary codes, default if null.
            // Note: Ensure that these methods can handle null values gracefully, or add checks inside them.
            string? comp = _instructionTable.ConvertComp(splittedInstruction.Comp);
            string? dest = _instructionTable.ConvertDest(splittedInstruction.Dest);
            string? jump = _instructionTable.ConvertJump(splittedInstruction.Jump);

            // If any of the conversions returned null, default to specified strings.
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

            // Assemble the instruction using StringBuilder for better performance.
            StringBuilder instructionBuilder = new StringBuilder();
            instructionBuilder.Append("111");
            instructionBuilder.Append(comp);
            instructionBuilder.Append(dest);
            instructionBuilder.Append(jump);

            return instructionBuilder.ToString();
        }

    }
}
