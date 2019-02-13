using System;
using System.Collections.Generic;
using System.IO;
using static VMTranslator.StackCommands;
using static VMTranslator.LogicArithmeticCommands;
namespace VMTranslator
{

    public class CodeWriter:CodewriterBase
    {
        
        public List<string> FormatParsedLines(string filePath, List<LineCommand> commands)
        {
            List<string> lines = new List<string>();
            lines.Add("//This is generated code\n//Provided by a generous grant from the OG AKA thepigeonfighter\n");
            foreach (var command in commands)
            {
                string vmCodeComment = command.Comment;
                lines.Add(vmCodeComment);
                string asmCode = CommandDictionary[command.CommandType](command);
                

            }
            lines.Add("\n//This concludes the asm file. ");
            return lines;
        }





        


    }
}
