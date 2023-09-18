namespace Compiler.Interfaces
{
    internal interface ISymbolsDynamicTable
    {
        public void AddSymbol(string symbol, int address);

        public int? ReadSymbol(string symbol);
        public int GetNextAvailableAddress();
    }
}
