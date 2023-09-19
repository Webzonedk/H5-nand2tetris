namespace Compiler.Interfaces
{
    /// <summary>
    /// This interface is used to convert the C instructions to binary.
    /// </summary>
    internal interface ICInstructionTable
    {
        public string? ConvertDest(string dest);
        public string? ConvertComp(string comp);
        public string? ConvertJump(string jump);
    }
}
