using Compiler.Interfaces;
using System;
using System.Collections.Generic;

namespace Compiler.Tables
{
    internal class SymbolsDynamicTable : ISymbolsDynamicTable
    {
        // Initialize an empty dictionary to store symbols
        private readonly Dictionary<string, int> _dynamicSymbolTable = new Dictionary<string, int>();

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
            // Since we're keeping track of the highest address,
            // the next available address would be _highestAddress + 1
            return _highestAddress + 1;
        }
    }
}
