namespace Compiler.Interfaces
{
    /// <summary>
    /// This interface is used to read the predefined symbols from the table.
    /// </summary>
    internal interface ISymbolsPredefinedTable
    {
        public int? ReadSymbol(string symbol);
    }
}
