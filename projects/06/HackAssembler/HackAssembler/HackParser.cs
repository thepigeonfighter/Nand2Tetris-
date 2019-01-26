using System;
using System.Collections.Generic;

namespace HackAssembler
{
    public static class HackParser
    {
        private static Dictionary<string, int> _symbolTable = new Dictionary<string, int>();
        private static int _whiteSpaceLines;
        public static string[] Parse(string[] input)
        {
            //Since this is a static class the state must be reset to ensure valid data
            ResetInternals();
            //Insert Default Symbols
            InitializeSymbolTable();
            var lines = new string[input.Length]; 
            
            lines = RemoveWhitespace(input);
            //This number is used and kept up to date for debuging purposes
            //to provide user with accurate line error readings
            _whiteSpaceLines = input.Length - lines.Length;

            //Find all labels and add them to symbol table
            lines = DefineLabels(lines);
            _whiteSpaceLines = input.Length - lines.Length;

            //Convert labels and vars to memory addresses
            lines = RefactorVariables(lines);
            _whiteSpaceLines = input.Length - lines.Length;

            //Loop through all lines and parse the commands
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    if (lines[i].Contains("@"))
                    {
                        lines[i] = ParseAInstruction(lines[i].Substring(1));
                    }
                    else
                    {
                        lines[i] = ParseCInstruction(lines[i]);
                    }
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message + $"\nLine number {i+_whiteSpaceLines}");
                }

            }            
            return lines;

        }
        private static void ResetInternals()
        {
            _symbolTable = new Dictionary<string, int>();
            _whiteSpaceLines = 0;
        }
        #region  Format File
        private static void InitializeSymbolTable()
        {
            _symbolTable.Add("SP", 0);
            _symbolTable.Add("LCL", 1);
            _symbolTable.Add("ARG", 2);
            _symbolTable.Add("THIS", 3);
            _symbolTable.Add("THAT", 4);
            _symbolTable.Add("R0", 0);
            _symbolTable.Add("R1", 1);
            _symbolTable.Add("R2", 2);
            _symbolTable.Add("R3", 3);
            _symbolTable.Add("R4", 4);
            _symbolTable.Add("R5", 5);
            _symbolTable.Add("R6", 6);
            _symbolTable.Add("R7", 7);
            _symbolTable.Add("R8", 8);
            _symbolTable.Add("R9", 9);
            _symbolTable.Add("R10", 10);
            _symbolTable.Add("R11", 11);
            _symbolTable.Add("R12", 12);
            _symbolTable.Add("R13", 13);
            _symbolTable.Add("R14", 14);
            _symbolTable.Add("R15", 15);
            _symbolTable.Add("SCREEN", 16384);
            _symbolTable.Add("KBD", 24576);
        }
        private static string[] RemoveWhitespace(string[] lines)
        {
            var modifiedLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("//"))
                {
                    int index = lines[i].IndexOf("//");
                    lines[i] = lines[i].Remove(index);
                }
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    lines[i] = lines[i].Trim();
                    modifiedLines.Add(lines[i]);
                }
            }
            return modifiedLines.ToArray();
        }
        private static string[] DefineLabels(string[] lines)
        {
            var modifiedLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Contains("("))
                {
                   
                    int openingBracketIndex = lines[i].IndexOf('(');
                    int closingBracketIndex = lines[i].IndexOf(')');
                    if(closingBracketIndex ==-1)
                    {
                        throw new Exception($"No Closing bracket found on line.\nLine Number {i+_whiteSpaceLines +1}");
                    }
                    int length = closingBracketIndex - openingBracketIndex -1;
                    string varName = lines[i].Substring(openingBracketIndex + 1, length);
                    varName = varName.Trim();
                    if(!_symbolTable.ContainsKey(varName))
                    {
                        _symbolTable.Add(varName, modifiedLines.Count);
                    }
                    else
                    {
                        throw new Exception($"Cannot define the same label twice.\nLine Number {i+_whiteSpaceLines +1}");
                    }

                }
                else
                {
                    modifiedLines.Add(lines[i]);
                }
            }
            return modifiedLines.ToArray();
        }
        private static string [] RefactorVariables(string[] lines)
        {
            int memAlloc = 16;
            for (int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Contains("@"))
                {
                    int index = lines[i].IndexOf('@');
                    string varName = lines[i].Substring(index + 1);
                    if (!int.TryParse(varName, out int n))
                    {
                        if (_symbolTable.ContainsKey(varName))
                        {
                            int value = _symbolTable[varName];
                            lines[i] = $"@{value}";
                        }
                        else
                        {
                            _symbolTable.Add(varName, memAlloc);
                            lines[i] = $"@{memAlloc}";
                            memAlloc++;
                        }
                    }
                }
            }
            return lines;
        }
        #endregion
        #region A Instruction
        private static string ParseAInstruction(string line)
        {
            int num = int.Parse(line);
            string binaryAddress = Convert.ToString(num, 2);
            int numberOfZerosToAdd = 16 - binaryAddress.Length;
            for (int i = 0; i < numberOfZerosToAdd; i++)
            {
                binaryAddress = binaryAddress.Insert(0, "0");
            }
            return binaryAddress;


        }
        #endregion
        #region C Instruction
        private static string ParseCInstruction(string line)
        {
            string instruction = "111";
            int equalSignIndex = line.IndexOf('=');
            int semicolonIndex = line.IndexOf(';');
            string dest;
            string comp = line;
            string jmp;
            if (equalSignIndex == -1)
            {
                dest = "000";
            }
            else
            {
                dest = line.Substring(0, equalSignIndex);
                dest = GetDestString(dest);
                comp = comp.Remove(0, equalSignIndex + 1);
            }
            if (semicolonIndex == -1)
            {
                jmp = "000";
            }
            else
            {
                jmp = line.Substring(semicolonIndex + 1);
                jmp = GetJumpString(jmp);
                comp = comp.Remove(semicolonIndex);
            }
            string aValue = GetValueofA(comp);
            comp = GetCompString(comp);

            instruction += aValue + comp + dest + jmp;
            return instruction;
        }
        private static string GetValueofA(string line)
        {
            if (line.Contains("M"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private static string GetJumpString(string jump)
        {
            string jmp = jump.Trim(';');
            switch (jmp)
            {
                case "JGT":
                    return "001";
                case "JEQ":
                    return "010";
                case "JGE":
                    return "011";
                case "JLT":
                    return "100";
                case "JNE":
                    return "101";
                case "JLE":
                    return "110";
                case "JMP":
                    return "111";
                default:
                    throw new Exception($"Jump phrase '{jump}' invalid");
            }
        }
        private static string GetDestString(string dest)
        {
            switch (dest)
            {
                case "A":
                    return "100";
                case "D":
                    return "010";
                case "M":
                    return "001";
                case "AD":
                    return "110";
                case "AM":
                    return "101";
                case "AMD":
                    return "111";
                case "MD":
                    return "011";
                default:
                    throw new Exception($"'{dest}' is an invalid dest string input");
            }
        }
        private static string GetCompString(string line)
        {
            switch (line)
            {
                case "0":
                    return "101010";
                case "1":
                    return "111111";
                case "-1":
                    return "111010";
                case "D":
                    return "001100";
                case "A":
                case "M":
                    return "110000";
                case "!D":
                    return "001101";
                case "!A":
                case "!M":
                    return "110001";
                case "-D":
                    return "001111";
                case "-A":
                case "-M":
                    return "110011";
                case "D+1":
                    return "011111";
                case "A+1":
                case "M+1":
                    return "110111";
                case "D-1":
                    return "001110";
                case "A-1":
                case "M-1":
                    return "110010";
                case "D+A":
                case "D+M":
                    return "000010";
                case "D-A":
                case "D-M":
                    return "010011";
                case "A-D":
                case "M-D":
                    return "000111";
                case "D&A":
                case "D&M":
                    return "000000";
                case "D|A":
                case "D|M":
                    return "010101";
                default:
                    throw new Exception($"'{line}' is a invalid comp command.");
            }

        }
#endregion
    }
}
