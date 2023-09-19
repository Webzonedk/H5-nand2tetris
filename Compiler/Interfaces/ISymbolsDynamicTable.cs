namespace Compiler.Interfaces
{
    /// <summary>
    /// This interface is used to read, write and get next available address for the the symbols from the table.
    /// </summary>
    internal interface ISymbolsDynamicTable
    {
        public void AddSymbol(string symbol, int address);

        public int? ReadSymbol(string symbol);
        public int GetNextAvailableAddress();
        public void ClearDictionary();
    }
}
