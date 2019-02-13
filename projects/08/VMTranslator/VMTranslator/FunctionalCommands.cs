using static VMTranslator.StackCommands;
namespace VMTranslator
{
    public static class FunctionalCommands
    {
        public static string ConditionalGoto(LineCommand command)
        {
            //Get Correct jump type set to label
            string msg = Pop() + SetDFromM() + $"@{command.LabelName}\nD;JGT\n";
            return msg;
        }
        public static string GotoStatement(LineCommand command)
        {
            return $"@{command.LabelName}\n0;JMP\n";
        }
        public static string FunctionalStatement(LineCommand command)
        {
            string msg = $"({command.LabelName})\n" +
                $"D=0\n";
            for (int i = 0; i < command.Value; i++)
            {
                msg += PushFromDReg();
            }
            return msg;
        }
        public static string ReturnStatement(LineCommand command)
        {
            string msg = "@LCL\n" +
            "D=M\n" +
            "@endframe\n" +
            "M=D\n" +
            "@5\n" +
            "A=D-A\n" +
            "D=M\n" +
            "@retAddress\n" +
            "M=D\n"
            + Pop() + SetDFromM() +
            "@ARG\n" +
            "A=M\n" +
            "M=D\n" +
            "D=A\n" +
            "@SP\n" +
            "M=D+1\n" +
            DRegToEndFrameVar() +
            "A=D-1\n" +
            "D=M\n" +
            "@THAT     //Resets THAT\n" +
            "M=D\n" +
            SetDRegToNumber(2) +
            "@endframe\n" +
            "A=M-D\n" +
            "D=M\n" +
            "@THIS     //Resets THIS\n" +
            "M=D\n" +
            SetDRegToNumber(3) +
            "@endframe\n" +
            "A=M-D\n" +
            "D=M\n" +
            "@ARG     //Resets ARG\n" +
            "M=D\n" +
            SetDRegToNumber(4) +
            "@endframe\n" +
            "A=M-D\n" +
            "D=M\n" +
            "@LCL    //Resets LCL\n" +
            "M=D\n" +
            "@retAddress\n" +
            "A=M\n" +
            "0;JMP\n";
            return msg;
        }
        public static string CallCommand(LineCommand command, int returnCalls)
        {
            string returnAddress = $"{ command.FileName }$ret.{ returnCalls}";
            string msg = $"//--------CALLING {command.FileName}-----\n" +
                $"//Pushing Stack Snapshot to Stack\n" +
                $"@{returnAddress}\n" +
                "D=A\n"+
                PushFromDReg() +
                "@LCL\n" +
                "D=M\n" +
                PushFromDReg() +
                "@ARG\n" +
                "D=M\n" +
                PushFromDReg() +
                "@THIS\n" +
                "D=M\n" +
                PushFromDReg() +
                "@THAT\n" +
                "D=M\n" +
                PushFromDReg() +
                "//---------Stack Snapshot Complete ------\n";
            int argPointerOffset = 5 + command.Value;
            msg += $"@{argPointerOffset}\n" +
            "D=A\n" +
            "@SP\n" +
            "D=M-D\n" +
            "@ARG\n" +
            "M=D\n" +
            "@SP\n" +
            "D=M\n" +
            "@LCL\n" +
            "M=D\n" +
            $"@{command.LabelName}\n" +
            $"0;JMP\n" +
            $"({returnAddress})\n";
            return msg;
        }
        private static string DRegToEndFrameVar()
        {
            return "@endframe\n" +
            "D=M\n";
        }
        public static string InitializationString(LineCommand command)
        {
            return "//--------Initializing -----------\n" +
                "//@256\n" +
                "//D=A\n" +
                "//@SP\n" +
                "//M=D\n";
        }
        private static string SetDRegToNumber(int num)
        {
            string msg = $"@{num}\n" +
                "D=A\n";
            return msg;
        }

    }
}
