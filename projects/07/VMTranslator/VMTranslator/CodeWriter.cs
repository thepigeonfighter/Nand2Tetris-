using System;
using System.Collections.Generic;
using System.IO;
using static VMTranslator.StackCommands;
namespace VMTranslator
{

    public class CodeWriter
    {
        private Dictionary<string, int> _symbolTable = new Dictionary<string, int>();
        private int labelCount = 0;
        public void WriteCodeToFile(string filePath, List<LineCommand> commands)
        {
            List<string> lines = new List<string>();
            lines.Add("//This is generated code\n//Provided by a generous grant from the brain of the OG thepigeonfighter\n");
            foreach (var command in commands)
            {
                if (command.CommandType == CommandType.Push)
                {
                    string line = ConvertPushCommands(command);
                    lines.Add(line);
                }
                else if(command.CommandType == CommandType.Pop)
                {
                    string line = ConvertPopCommands(command);
                    lines.Add(line);
                }
                else 
                {
                    if (command != null)
                    {
                        string line = ConvertOtherCommands(command);
                        lines.Add(line);
                    }
                }

            }
            lines.Add("\n//This concludes the asm file. ");
            File.WriteAllLines(filePath, lines);
        }

        private string ConvertPopCommands(LineCommand command)
        {
            string asmCode = $"\n";
            switch (command.MemoryLocation)
            {
                case CommandMemoryLocation.Local:
                case CommandMemoryLocation.Argument:
                case CommandMemoryLocation.This:
                case CommandMemoryLocation.That:
                    asmCode += PopToMemory(command.MemoryLocation, command.Value);
                    break;
                case CommandMemoryLocation.Temp:
                    asmCode += PopToTempStack(command.Value);
                    break;
                case CommandMemoryLocation.Pointer:
                    asmCode += HandlePopPointerCommands(command);
                    break;
                case CommandMemoryLocation.Static:
                    asmCode += PopToStaticVar(GetStaticVarName(command.Value));
                    break;
                default:
                    throw new Exception("Cannot pop without a memory location specified.");
            }
            return asmCode;
        }
        private string HandlePushPointerCommands(LineCommand command)
        {
            string msg = "//Pointer Push Command\n";
            if(command.Value == 0)
            {
                command.MemoryLocation = CommandMemoryLocation.This;
                
            }
            else
            {
                command.MemoryLocation = CommandMemoryLocation.That;
            }
            msg += PointerPush(command);
            return msg;
        }
        private string HandlePopPointerCommands(LineCommand command)
        {
            string msg = "//Pointer Pop Command\n";
            if (command.Value == 0)
            {
                command.MemoryLocation = CommandMemoryLocation.This;
            }
            else
            {
                command.MemoryLocation = CommandMemoryLocation.That;                
            }
            msg += PointerPop(command);
            return msg;
        }
        private string ConvertPushCommands(LineCommand command)
        {
            string asmCode = $"\n ";
            switch (command.MemoryLocation)
            {
                case CommandMemoryLocation.None:
                    throw new Exception("There was no memory location selected.");               
                case CommandMemoryLocation.Static:
                    asmCode += PushStaticVar(GetStaticVarName(command.Value));
                    break;
                case CommandMemoryLocation.Constant:
                    asmCode += Push(command.Value);
                    break;
                case CommandMemoryLocation.Temp:
                    asmCode += PushFromTempStack(command.Value);
                    break;
                case CommandMemoryLocation.Pointer:
                    asmCode += HandlePushPointerCommands(command);
                    break;
                default:
                    asmCode += PushFromMemory(command.MemoryLocation, command.Value);
                    break;
            }
           
            


            return asmCode;
        }

        private string Add()
        {
            string msg = "//Adding numbers from stack\n" +
                Pop() +
                SetDFromM() +
                Pop()+
                "M=D+M\n"
                +IncrementStackPointer();
            return msg;
        }
        private string Negate()
        {
            string msg = "//Performing Negation\n" +
                Pop() + SetDFromM() +
                "D=-D\n" + PushFromDReg();
            return msg;
        }
        private string Not()
        {
            string msg = "//Performing Not\n" +
                Pop() + SetDFromM() +
                "D=!D\n" + PushFromDReg();
            return msg;
        }
        private string And()
        {
            string msg = "//Performing an And opertation\n" +
                Pop() + SetDFromM() + Pop() +
                "M=D&M\n" + IncrementStackPointer();
            return msg;
        }
        private string Or()
        {
            string msg = "//Performing an Or opertation\n" +
                Pop() + SetDFromM() + Pop() +
                "M = D|M\n" + IncrementStackPointer();
            return msg;
        }
        private string Subtract()
        {
            string msg = "//Performing a  subtraction\n" +
                Pop() + SetDFromM() + Pop() +
                "M = M-D\n" + IncrementStackPointer();
            return msg;
        }

        private string CheckEquality(LineCommand command)
        {
            string jumpType = GetJumpType(command);
            string msg = "//Checking for equality\n";
            msg += Pop() + SetDFromM() + Pop();
            msg += "D=D-M\n" +
                $"@TRUE.{labelCount}\n" +
                $"D;{jumpType}   // x==0 \n" +
                "D=0       // Set Result to false\n" +
                PushFromDReg() +
                $"@RESULT.{labelCount}\n" +
                $"0;JMP\n"+
                $"(TRUE.{labelCount})\n" +
                "D=-1      // Set Result to true\n" +
                PushFromDReg() +
                $"(RESULT.{labelCount})   // On Exit\n";
            labelCount++;
            return msg;

        }
        private string GetStaticVarName(int value)
        {
            return $"var.{value}";
        }
        
        private string ConvertOtherCommands(LineCommand command)
        {
            string asm = "";
            switch (command.CommandType)
            {
                case CommandType.None:
                    throw new Exception("Invalid command type");

                case CommandType.Add:
                    asm += Add();
                    break;
                case CommandType.Subtract:
                    asm += Subtract();
                    break;
                case CommandType.Negate:
                    asm += Negate();
                    break;
                case CommandType.Equals:
                case CommandType.GreaterThan:
                case CommandType.LessThan:
                    asm += CheckEquality(command);
                    break;
                case CommandType.And:
                    asm += And();
                    break;
                case CommandType.Or:
                    asm += Or();
                    break;
                case CommandType.Not:
                    asm += Not();
                    break;
                default:
                    break;
            }
            return asm;
        }

    }
}
