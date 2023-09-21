using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Interfaces
{
    internal interface ICommandTable
    {
        public void HandlePush(int value, StringBuilder sb);
        public void HandlePop(int value, StringBuilder sb);
        public void HandleAdd(int value, StringBuilder sb);
        public void HandleSub(int value, StringBuilder sb);
        public void HandleNeg(int value, StringBuilder sb);
        public void HandleEq(int value, StringBuilder sb);
        public void HandleGt(int value, StringBuilder sb);
        public void HandleLt(int value, StringBuilder sb);
        public void HandleAnd(int value, StringBuilder sb);
        public void HandleOr(int value, StringBuilder sb);
        public void HandleNot(int value, StringBuilder sb);
        public void HandleLabel(int value, StringBuilder sb);
        public void HandleGoto(int value, StringBuilder sb);
        public void HandleIfGoto(int value, StringBuilder sb);
        public void HandleFunction(int value, StringBuilder sb);
        public void HandleCall(int value, StringBuilder sb);
        public void HandleReturn(int value, StringBuilder sb);
    }
}
