using Compiler.Interfaces;

namespace Compiler.Tables
{
    internal class CInstructionTable : ICInstructionTable
    {
        private readonly Dictionary<string, string> _destTable = new Dictionary<string, string>
        {
            { "null", "000" },
            { "M", "001" },
            { "D", "010" },
            { "MD", "011" },
            { "A", "100" },
            { "AM", "101" },
            { "AD", "110" },
            { "AMD", "111" },
        };

        private readonly Dictionary<string, string> _jumpTable = new Dictionary<string, string>
        {
            { "null", "000" },
            { "JGT", "001" },
            { "JEQ", "010" },
            { "JGE", "011" },
            { "JLT", "100" },
            { "JNE", "101" },
            { "JLE", "110" },
            { "JMP", "111" },
        };

        private readonly Dictionary<string, string> _compTable = new Dictionary<string, string>
        {
            { "0" , "0101010" },
            { "1" , "0111111" },
            { "-1" , "0111010" },
            { "D" , "0001100" },
            { "A" , "0110000" },
            { "!D" , "0001101" },
            { "!A" , "0110001" },
            { "-D" , "0001111" },
            { "-A" , "0110011" },
            { "D+1" , "0011111" },
            { "A+1" , "0110111" },
            { "D-1" , "0001110" },
            { "A-1" , "0110010" },
            { "D+A" , "0000010" },
            { "D-A" , "0010011" },
            { "A-D" , "0000111" },
            { "D&A" , "0000000" },
            { "D|A" , "0010101" },
            { "M" , "1110000" },
            { "!M" , "1110001" },
            { "-M" , "1110011" },
            { "M+1" , "1110111" },
            { "M-1" , "1110010" },
            { "D+M" , "1000010" },
            { "D-M" , "1010011" },
            { "M-D" , "1000111" },
            { "D&M" , "1000000" },
            { "D|M" , "1010101" },
        };


        /// <summary>
        /// This method reads the instruction and returns the binary code for the dest part of the instruction.
        /// </summary>
        /// <param name="dest"></param>
        /// <returns>returns the binary code for the dest part of the instruction.</returns>
        public string? ConvertDest(string dest)
        {
            if (_destTable.TryGetValue(dest, out string? address))
            {
                return address;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This method reads the instruction and returns the binary code for the comp part of the instruction.
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="comp"></param>
        /// <param name="jump"></param>
        /// <returns>Returns the binary code for the comp part of the instruction.</returns>
        public string? ConvertJump(string jump)
        {
            if (_jumpTable.TryGetValue(jump, out string? address))
            {
                return address;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This method reads the instruction and returns the binary code for the dest part of the instruction.
        /// </summary>
        /// <param name="comp"></param>
        /// <returns>returns the binary code for the dest part of the instruction.</returns>
        public string? ConvertComp(string comp)
        {
            if (_compTable.TryGetValue(comp, out string? address))
            {
                return address;
            }
            else
            {
                return null;
            }
        }
    }
}
