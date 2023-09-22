using System.Text;

namespace VM.Translators
{
    /// <summary>
    /// This class is responsible for translating the end-loop command from the vm language to assembly
    /// </summary>
    internal class TranslateEndLoop : ITranslateEndLoop
    {
        /// <summary>
        /// This method is responsible for translating the end-loop command from the vm language to assembly
        /// </summary>
        /// <param name="stringBuilder"></param>
        public void Translate(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("(END)");
            stringBuilder.AppendLine("@END");
            stringBuilder.AppendLine("0;JMP");
        }
    }
}
