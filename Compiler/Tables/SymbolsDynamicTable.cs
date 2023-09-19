using Compiler.Interfaces;

namespace Compiler.Tables
{

    /// <summary>
    /// This class is used to store symbols and their addresses.
    /// </summary>
    internal class SymbolsDynamicTable : ISymbolsDynamicTable
    {

        private Dictionary<string, int> _dynamicSymbolTable = new Dictionary<string, int>();

        // Variable to keep track of the highest address used
        private int _highestAddress = 15;



        /// <summary>
        /// Adds a symbol to the table.
        /// </summary>
        /// <param name="symbol">The symbol to add.</param>
        /// <param name="address">The address for the symbol.</param>
        public void AddSymbol(string symbol, int address)
        {
            // Checks if the symbol already exists, and if not, adds it
            if (!_dynamicSymbolTable.ContainsKey(symbol))
            {
                _dynamicSymbolTable.Add(symbol, address);

                // Update highest address if the newly added address is higher
                if (address > _highestAddress)
                {
                    _highestAddress = address;
                }
            }
        }



        /// <summary>
        /// Reads the address of a given symbol.
        /// </summary>
        /// <param name="symbol">The symbol to look for.</param>
        /// <returns>The address associated with the symbol, or null if it doesn't exist.</returns>
        public int? ReadSymbol(string symbol)
        {
            if (_dynamicSymbolTable.TryGetValue(symbol, out int address))
            {
                return address;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// Finds and returns the next available address.
        /// </summary>
        /// <returns>The next available address.</returns>
        public int GetNextAvailableAddress()
        {
            return _highestAddress + 1;
        }


        /// <summary>
        /// This method clears the dictionary.
        /// </summary>
        public void ClearDictionary()
        {
            _dynamicSymbolTable.Clear();
            _highestAddress = 15;
        }
    }
}
