using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VMTranslator.StackCommands;
namespace VMTranslator
{
    public static class LogicArithmeticCommands
    {
        public static string Add()
        {
            string msg =
                Pop() +
                SetDFromM() +
                Pop() +
                "M=D+M\n"
                + IncrementStackPointer();
            return msg;
        }
        public static string Negate()
        {
            string msg =
                Pop() + SetDFromM() +
                "D=-D\n" + PushFromDReg();
            return msg;
        }
        public static string Not()
        {
            string msg =
                Pop() + SetDFromM() +
                "D=!D\n" + PushFromDReg();
            return msg;
        }
        public static string And()
        {
            string msg =
                Pop() + SetDFromM() + Pop() +
                "M=D&M\n" + IncrementStackPointer();
            return msg;
        }
        public static string Or()
        {
            string msg =
                Pop() + SetDFromM() + Pop() +
                "M = D|M\n" + IncrementStackPointer();
            return msg;
        }
        public static string Subtract()
        {
            string msg = 
                Pop() + SetDFromM() + Pop() +
                "M=M-D\n" + IncrementStackPointer();
            return msg;
        }

        public static string CheckEquality(LineCommand command, int labelCount)
        {
            string jumpType = GetJumpType(command);
            string msg = "";
            msg += Pop() + SetDFromM() + Pop();
            msg += "D=M-D\n" +
                $"@TRUE.{labelCount}\n" +
                $"D;{jumpType}   // x==0 \n" +
                "D=-1       // Set Result to false\n" +
                PushFromDReg() +
                $"@RESULT.{labelCount}\n" +
                $"0;JMP\n" +
                $"(TRUE.{labelCount})\n" +
                "D=1      // Set Result to true\n" +
                PushFromDReg() +
                $"(RESULT.{labelCount})   // On Exit\n";
            return msg;

        }
    }
}
