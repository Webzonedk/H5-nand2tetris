using Compiler.Interfaces;

namespace Compiler.Tables
{
    /// <summary>
    /// This class is used to read the predefined symbols.
    /// </summary>
    internal class SymbolsPredefinedTable : ISymbolsPredefinedTable
    {
        private readonly Dictionary<string, int> _predefinedTable = new Dictionary<string, int>
        {
            {"R0", 0 },
            {"R1", 1 },
            {"R2", 2 },
            {"R3", 3 },
            {"R4", 4 },
            {"R5", 5 },
            {"R6", 6 },
            {"R7", 7 },
            {"R8", 8 },
            {"R9", 9 },
            {"R10", 10 },
            {"R11", 11 },
            {"R12", 12 },
            {"R13", 13 },
            {"R14", 14 },
            {"R15", 15 },
            {"SCREEN", 16384 },
            {"KBD", 24576 },
            {"SP", 0 },
            {"LCL", 1 },
            {"ARG", 2 },
            {"THIS", 3 },
            {"THAT", 4 }
        };



        /// <summary>
        /// Reads the address of a given symbol.
        /// </summary>
        /// <param name="symbol">The symbol to look for.</param>
        /// <returns>The address associated with the symbol, or null if it doesn't exist.</returns>
        public int? ReadSymbol(string symbol)
        {
            if (_predefinedTable.TryGetValue(symbol, out int address))
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
