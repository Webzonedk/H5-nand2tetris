using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Interfaces
{
    /// <summary>
    /// This interface is used to add and read Labels locations from the dynamic label table.
    /// </summary>
    internal interface ILabelsDynamicTable
    {
        public void AddSymbol(string symbol, int address);

        public int? ReadSymbol(string symbol);

        public void ClearDictionary();
    }
}
