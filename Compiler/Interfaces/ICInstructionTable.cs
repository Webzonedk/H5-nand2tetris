namespace Compiler.Interfaces
{
    internal interface ICInstructionTable
    {
        public string? ConvertDest(string dest);
        public string? ConvertComp(string comp);
        public string? ConvertJump(string jump);
    }
}
