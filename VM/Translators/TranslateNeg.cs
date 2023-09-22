using System.Text;
using VM.Interfaces;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the neg command from the vm language to assembly
    /// </summary>
    internal class TranslateNeg : ITranslateNeg
    {
        /// <summary>
        /// This method translates the neg command from the vm language to assembly
        /// </summary>
        /// <param name="stringBuilder"></param>
        public void Translate(StringBuilder stringBuilder)
        {
            // Set D-register to 0
            stringBuilder.AppendLine("D=0");

            // Point to the top of the stack
            stringBuilder.AppendLine("@SP");
            stringBuilder.AppendLine("A=M-1");

            // Negate the top of the stack
            stringBuilder.AppendLine("M=D-M");
        }

    }
}
