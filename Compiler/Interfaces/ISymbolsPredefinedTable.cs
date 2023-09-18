using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Interfaces
{
    internal interface ISymbolsPredefinedTable
    {
        public int? ReadSymbol(string symbol);
    }
}
