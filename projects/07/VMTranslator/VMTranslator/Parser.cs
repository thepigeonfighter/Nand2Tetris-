using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public class Parser
    {
        public List<LineCommand> Parse(List<string> lines)
        {
            List<string> parsedLines = new List<string>();
            parsedLines = RemoveWhitespace(lines);
            List<LineCommand> commands = new List<LineCommand>();
            parsedLines.ForEach(x => commands.Add(ConvertToLineCommand(x)));
                return commands;
        }
        private List<string> RemoveWhitespace(List<string>lines)
        {
            var modifiedLines = new List<string>();
            for (int i = 0; i < lines.Count; i++)
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
            return modifiedLines;
        }
        private LineCommand ConvertToLineCommand(string line)
        {
            LineCommand command = new LineCommand();
            if(line.Contains("pop"))
            {
                command = ConvertPopCommand(line);
            }
            else if(line.Contains("push"))
            {
                command = ConvertPushCommand(line);
            }
            else
            {
                command = ConvertOtherCommand(line);
            }
            return command;
        }
        private LineCommand ConvertPushCommand(string line)
        {
            LineCommand command = new LineCommand();
            command.CommandType = CommandType.Push;
            List<string> commandParts = line.Split(' ').ToList();
            command.MemoryLocation = GetMemoryLocationtype(commandParts[1]);
            command.Value = int.Parse(commandParts[2]);
            return command;
        }
        private LineCommand ConvertPopCommand(string line)
        {
            LineCommand command = new LineCommand();
            command.CommandType = CommandType.Pop;
            List<string> commandParts = line.Split(' ').ToList();
            command.MemoryLocation = GetMemoryLocationtype(commandParts[1]);
            command.Value = int.Parse(commandParts[2]);
            return command;
        }
        private LineCommand ConvertOtherCommand(string line)
        {
            LineCommand command = new LineCommand();


            switch (line)
            {
                case "add":
                    command.CommandType = CommandType.Add;
                    break;
                case "eq":
                    command.CommandType = CommandType.Equals;
                    break;
                case "lt":
                    command.CommandType = CommandType.LessThan;
                    break;
                case "gt":
                    command.CommandType = CommandType.GreaterThan;
                    break;
                case "sub":
                    command.CommandType = CommandType.Subtract;
                    break;
                case "neg":
                    command.CommandType = CommandType.Negate;
                    break;
                case "and":
                    command.CommandType = CommandType.And;
                    break;
                case "or":
                    command.CommandType = CommandType.Or;
                    break;
                case "not":
                    command.CommandType = CommandType.Not;
                    break;
                default:
                    throw new Exception("Not recognized");
            }

            return command;
        }
        private CommandMemoryLocation GetMemoryLocationtype(string line)
        {
            switch (line)
            {
                case "local":
                    return CommandMemoryLocation.Local;
                case "static":
                    return CommandMemoryLocation.Static;
                case "constant":
                    return CommandMemoryLocation.Constant;
                case "argument":
                    return CommandMemoryLocation.Argument;
                case "this":
                    return CommandMemoryLocation.This;
                case "that":
                    return CommandMemoryLocation.That;
                case "temp":
                    return CommandMemoryLocation.Temp;
                case "pointer":
                    return CommandMemoryLocation.Pointer;
                default:
                    return CommandMemoryLocation.None;
            }
        }
    }
}
