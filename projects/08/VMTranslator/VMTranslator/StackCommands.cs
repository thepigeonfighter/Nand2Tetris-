using System;
using System.Collections.Generic;
using static VMTranslator.LogicArithmeticCommands;
namespace VMTranslator
{
    public static class StackCommands
    {
        private static readonly Dictionary<CommandMemoryLocation, int> memLocDictionary = new Dictionary<CommandMemoryLocation, int>
        {
            {CommandMemoryLocation.Local , 1},
            {CommandMemoryLocation.Argument,2},
            {CommandMemoryLocation.This ,3},
            {CommandMemoryLocation.That,4},
            {CommandMemoryLocation.Temp,5 }
        };

        public static string IncrementStackPointer()
        {
            string msg =
                "@SP\n" +
                "M=M+1\n";
            return msg;
        }
        public static string DecrementStackPointer()
        {
            string msg =
                "@SP\n" +
                "M=M-1\n";
            return msg;
        }
        public static string Pop()
        {
            string msg = "//Popping from stack\n" +
            DecrementStackPointer();
            msg += "A=M\n";
            return msg;
        }
        public static string IncrementPointer(string pointerName)
        {
            string msg =
               $"@{pointerName}\n" +
               "M=M+1\n";
            return msg;
        }
        public static string DecrementPointer(string pointerName)
        {
            string msg =
                $"@{pointerName}\n" +
                "M=M-1\n";
            return msg;
        }
        public static string PopToMemory(CommandMemoryLocation location, int value)
        {
            if(value == 0) { return PopToMemoryValueFirstValue(location); }
            string msg = "";
            int pointer = memLocDictionary[location];
            msg += $"@{pointer} // {location} pointer\n";
            msg += "D=M\n";
            msg += PushFromDReg();
            msg += Push(value);
            msg += Add();
            msg += Pop();
            msg += Pop();
            msg += SetDFromM();
            msg += IncrementStackPointer();
            msg += "A=M\n";
            msg += "A=M\n";
            msg += "M=D\n";
            msg += DecrementStackPointer();
            return msg;
        }
        private static string PopToMemoryValueFirstValue(CommandMemoryLocation location)
        {
            int pointer = memLocDictionary[location];
            string msg = Pop()+SetDFromM() +
                $"@{pointer}\n" +
                $"A=M\n" +
                $"M=D\n";
            return msg;

        }
        public static string Push(int value)
        {
            string msg = 
                $"@{value}\n" +
                $"D=A\n" +
                $"@SP       //SP = {value}\n" +
                $"A=M\n" +
                $"M=D\n" +
                $"@SP       //SP++\n" +
                $"M=M+1\n";
            return msg;
        }
        public static string PushFromMemorySegment(CommandMemoryLocation location, int value)
        {
            if(value == 0) { return PushFromFirstValueInMemorySegment(location); }
            int pointerLocation = memLocDictionary[location];
            string msg = "";
            msg += $"@{pointerLocation}\n";
            msg += SetDFromM();
            msg += PushFromDReg();
            msg += Push(value);
            msg += Add();
            msg += Pop();
            msg += "A=M\n";
            msg += SetDFromM();
            msg += PushFromDReg();
            return msg;
        }
        private static string PushFromFirstValueInMemorySegment(CommandMemoryLocation location)
        {
            int pointer = memLocDictionary[location];
            string msg =
                $"@{pointer}\n" +
                $"A=M\n" +
                $"D=M\n" +
                PushFromDReg();
            return msg;
        }
        public static string PopToTempStack(int value)
        {
            int address = 5 + value;
            string msg = "";
            msg += Pop();
            msg += SetDFromM();
            msg += $"@{address}\n";
            msg += "M=D\n";
            return msg;
        }
        public static string PushFromTempStack(int value)
        {
            int address = 5 + value;
            string msg = "";
            msg += $"@{address}\n";
            msg += SetDFromM();
            msg += PushFromDReg();
            return msg;
        }
        public static string PushStaticVar(string varName)
        {
            string msg =  
                $"@{varName}\n" +
                $"D=M\n" +
                PushFromDReg();
            return msg;
        }

        public static string SetDFromM()
        {
            return "D=M\n";
        }
        public static string PushFromDReg()
        {
            return "@SP\n"+
                "A=M\n" +
                "M=D\n" + IncrementStackPointer();
        }
        public static string GetJumpType(LineCommand command)
        {
            switch (command.CommandType)
            {

                case CommandType.Equals:
                    return "JEQ";
                case CommandType.GreaterThan:
                    return "JGT";
                case CommandType.LessThan:
                    return "JLT";

                default:
                    throw new Exception("Invalid Jump term");
            }
        }
        public static string PointerPush(LineCommand command)
        {
            int address = memLocDictionary[command.MemoryLocation];
            string msg = $"@{address}\n";
            msg += SetDFromM() + PushFromDReg();
            return msg;

        }
        public static string PointerPop(LineCommand command)
        {
            int address = memLocDictionary[command.MemoryLocation];
            string msg = Pop() +
                SetDFromM() +
                $"@{address}\n";
                msg += "M=D\n";
            return msg;
        }
        public static string PopToStaticVar(string varName)
        {
            string msg = Pop();
            msg += SetDFromM();
            msg += $"@{varName}\n";
            msg += "M=D\n";
            return msg;
        }

    }
}
