namespace Compiler.Interfaces
{
    /// <summary>
    /// This interface is used to convert the C-instruction into its binary representation.
    /// </summary>
    internal interface ICInstructionConverter
    {
        public string ConvertCInstruction(string instruction);
    }
}
