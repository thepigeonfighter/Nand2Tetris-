using System;
using System.Xml.Linq;

namespace JackCompiler
{
    public static class VMTranslator
    {
        public static string WritePush(MemorySegment memorySegment, int index)
        {
            return $"push {memorySegment.ToString().ToLower()} {index}\n";
        }
        public static string WritePop(MemorySegment memorySegment, int index)
        {
            return $"pop {memorySegment.ToString().ToLower()} {index}\n";
        }
        public static string WriteArithmeticCommand(ArithmeticCommand command)
        {
            switch (command)
            {
                case ArithmeticCommand.Add:
                    return "add\n";
                case ArithmeticCommand.Subtract:
                    return "sub\n";
                case ArithmeticCommand.Equal:
                    return "eq\n";
                case ArithmeticCommand.GreatThan:
                    return "gt\n";
                case ArithmeticCommand.LessThan:
                    return "lt\n";
                case ArithmeticCommand.And:
                    return "and\n";
                case ArithmeticCommand.Or:
                    return "or\n";
                case ArithmeticCommand.Not:
                    return "not\n";
                case ArithmeticCommand.Negate:
                    return "neg\n";
                default:
                    throw new Exception("Invalid arithmetic command");
            }

        }
        public static string WriteFunctionDeclaration(string labelName, int args)
        {
            return $"function {labelName} {args}\n";
        }
        public static string WriteLabel(string labelName)
        {
            return $"label {labelName}\n";
        }
        public static string WriteGoTo(string labelName)
        {
            return $"goto {labelName}\n";
        }
        public static string WriteIfStatement(string labelName)
        {
            return $"if-goto {labelName}\n";
        }
        public static string WriteCallFunction(string funcName, int localArgs)
        {
            return $"call {funcName} {localArgs}\n";
        }
        public static string WriteReturnStatement()
        {
            return "return\n";
        }
        public static string TranslateIdentifier(Identifier identifier)
        {
            switch (identifier.IdentifierType)
            {
                case IdentifierType.STATIC:
                    return $"static {identifier.Number}\n";
                case IdentifierType.FIELD:
                    return $"this {identifier.Number}\n";
                case IdentifierType.ARG:
                    return $"argument {identifier.Number}\n";
                case IdentifierType.VAR:
                    return $"local {identifier.Number}\n";
                default:
                    return $"---FIX THIS ---Unrecognized identifier\n";
            }
        }

    }
}
