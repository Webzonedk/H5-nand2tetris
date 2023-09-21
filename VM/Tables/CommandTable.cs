using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Tables
{
    internal class CommandTable
    {

        private void HandlePush(string location, string value, StringBuilder sb)
        {
            sb.AppendLine($"@{value}   // Read value {value}");
            sb.AppendLine("D=A         // Set D-register to value");
            sb.AppendLine("@SP         // Goto stackpointer");
            sb.AppendLine("A=M         // point to top of stack");
            sb.AppendLine("M=D         // push value to stack");
            sb.AppendLine("@SP         // go back to stack pointeren");
            sb.AppendLine("M=M+1       // increase stack pointeren");
        }

        private void HandlePop(string location, string value, StringBuilder sb)
        {
            sb.AppendLine("@SP         // Goto stackpointer");
            sb.AppendLine("M=M-1       // decrease stack pointeren");
            sb.AppendLine("A=M         // point to top of stack");
            sb.AppendLine("D=M         // pop value from stack");
            sb.AppendLine($"@{value}   // Read value {value}");
            sb.AppendLine("M=D         // pop value to stack");
           
        }

        private void HandleAdd(string location, string value, StringBuilder sb)
        {
            sb.AppendLine("@SP         // Goto stackpointer");
            sb.AppendLine("M=M-1       // decrease stack pointeren");
            sb.AppendLine("A=M         // point to top of stack");
            sb.AppendLine("D=M         // pop value from stack");
            sb.AppendLine("@A=A-1      // point to next value in stack");
            sb.AppendLine("M=M+D       // add value to stack");
        }

        private void HandleSub(string location, string value, StringBuilder sb)
        {
            sb.AppendLine("@SP         // Goto stackpointer");
            sb.AppendLine("M=M-1       // decrease stack pointeren");
            sb.AppendLine("A=M         // point to top of stack");
            sb.AppendLine("D=M         // pop value from stack");
            sb.AppendLine("@A=A-1      // point to next value in stack");
            sb.AppendLine("M=M-D       // subtract value from stack");
        }

        private void HandleNeg(string location, string value, StringBuilder sb)
        {

        }

        private void HandleEq(string location, string value, StringBuilder sb)
        {

        }

        private void HandleGt(string location, string value, StringBuilder sb)
        {

        }

        private void HandleLt(string location, string value, StringBuilder sb)
        {

        }

        private void HandleAnd(string location, string value, StringBuilder sb)
        {

        }

        private void HandleOr(string location, string value, StringBuilder sb)
        {

        }

        private void HandleNot(string location, string value, StringBuilder sb)
        {

        }

        private void HandleLabel(string location, string value, StringBuilder sb)
        {

        }

        private void HandleGoto(string location, string value, StringBuilder sb)
        {

        }

        private void HandleIfGoto(string location, string value, StringBuilder sb)
        {

        }

        private void HandleFunction(string location, string value, StringBuilder sb)
        {

        }

        private void HandleCall(string location, string value, StringBuilder sb)
        {


        }

        private void HandleReturn(string location, string value, StringBuilder sb)
        {

        }
    }
}
