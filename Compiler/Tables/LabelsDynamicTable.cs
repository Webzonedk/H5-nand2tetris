using Compiler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tables
{
    internal class LabelsDynamicTable : ILabelsDynamicTable
    {
        private Dictionary<string, int> _dynamicLabelTable = new Dictionary<string, int>();

        /// <summary>
        /// Adds a symbol to the table.
        /// </summary>
        /// <param name="symbol">The symbol to add.</param>
        /// <param name="address">The address for the symbol.</param>
        public void AddSymbol(string symbol, int address)
        {
            // Checks if the symbol already exists, and if not, adds it
            if (!_dynamicLabelTable.ContainsKey(symbol))
            {
                _dynamicLabelTable.Add(symbol, address);
            }
        }



        /// <summary>
        /// Reads the address of a given symbol.
        /// </summary>
        /// <param name="symbol">The symbol to look for.</param>
        /// <returns>The address associated with the symbol, or null if it doesn't exist.</returns>
        public int? ReadSymbol(string symbol)
        {
            if (_dynamicLabelTable.TryGetValue(symbol, out int address))
            {
                return address;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// This method clears the dictionary.
        /// </summary>
        public void ClearDictionary()
        {
            _dynamicLabelTable.Clear();
        }
    }
}
