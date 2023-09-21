using System.Text;
using VM.Interfaces;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the add command from the VM language to assembly.
    /// </summary>
    internal class TranslateAdd : ITranslateAdd
    {

        /// <summary>
        /// This method is translating the add command from the VM language to assembly.
        /// </summary>
        /// <param name="stringBuilder"></param>
        public void Translate(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("@SP      // Go to stack pointer");
            stringBuilder.AppendLine("AM=M-1   // Decrease stack pointer and go to top of stack");
            stringBuilder.AppendLine("D=M      // D = popped value");
            stringBuilder.AppendLine("A=A-1    // Point to next top of stack");
            stringBuilder.AppendLine("M=M+D    // Add D to the next top value and store it");
        }
    }
}
