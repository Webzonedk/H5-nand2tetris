using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Tables
{
    internal class CommandTable
    {
        private readonly Dictionary<string, Action<string, int, StringBuilder>> commandsDictionary;
        //private int _sp; //Stack pointer


        public CommandTable()
        {
            //_sp = 256;

            commandsDictionary = new Dictionary<string, Action<string, int, StringBuilder>>
            {
                {"push", HandlePush },
                {"pop", HandlePop},
                {"add", HandleAdd},
                {"sub", HandleSub},
                {"neg", HandleNeg},
                {"eq", HandleEq},
                {"gt", HandleGt},
                {"lt", HandleLt},
                {"and", HandleAnd},
                {"or", HandleOr},
                {"not", HandleNot},
                {"label", HandleLabel},
                {"goto", HandleGoto},
                {"if-goto", HandleIfGoto},
                {"function", HandleFunction},
                {"call", HandleCall},
                {"return", HandleReturn}
            };
        }


        private void HandlePush(string location, int value, StringBuilder sb)
        {
            // Generate Hack Assembly-code for 'push'
            sb.AppendLine($"@{value}   // Read value {value}");
            sb.AppendLine("D=A         // Set D-register to value");
            sb.AppendLine("@SP         // Goto stackpointer");
            sb.AppendLine("A=M         // point to top of stack");
            sb.AppendLine("M=D         // push value to stack");
            sb.AppendLine("@SP         // go back to stack pointeren");
            sb.AppendLine("M=M+1       // increase stack pointeren");
        }

        private void HandlePop(string location, int value, StringBuilder sb)
        {
           
        }

        private void HandleAdd(string location, int value, StringBuilder sb)
        {
            sb.AppendLine("@SP         // Goto stackpointer");
            sb.AppendLine("M=M-1       // decrease stack pointeren");
            sb.AppendLine("A=M         // point to top of stack");
            sb.AppendLine("D=M         // pop value from stack");
            sb.AppendLine("@A=A-1      // point to next value in stack");
            sb.AppendLine("M=M+D       // add value to stack");
        }

        private void HandleSub(string location, int value, StringBuilder sb)
        {
            sb.AppendLine("@SP         // Goto stackpointer");
            sb.AppendLine("M=M-1       // decrease stack pointeren");
            sb.AppendLine("A=M         // point to top of stack");
            sb.AppendLine("D=M         // pop value from stack");
            sb.AppendLine("@A=A-1      // point to next value in stack");
            sb.AppendLine("M=M-D       // subtract value from stack");
        }

        private void HandleNeg(string location, int value, StringBuilder sb)
        {

        }

        private void HandleEq(string location, int value, StringBuilder sb)
        {

        }

        private void HandleGt(string location, int value, StringBuilder sb)
        {

        }

        private void HandleLt(string location, int value, StringBuilder sb)
        {

        }

        private void HandleAnd(string location, int value, StringBuilder sb)
        {

        }

        private void HandleOr(string location, int value, StringBuilder sb)
        {

        }

        private void HandleNot(string location, int value, StringBuilder sb)
        {

        }

        private void HandleLabel(string location, int value, StringBuilder sb)
        {

        }

        private void HandleGoto(string location, int value, StringBuilder sb)
        {

        }

        private void HandleIfGoto(string location, int value, StringBuilder sb)
        {

        }

        private void HandleFunction(string location, int value, StringBuilder sb)
        {

        }

        private void HandleCall(string location, int value, StringBuilder sb)
        {

        }

        private void HandleReturn(string location, int value, StringBuilder sb)
        {

        }
    }
}
