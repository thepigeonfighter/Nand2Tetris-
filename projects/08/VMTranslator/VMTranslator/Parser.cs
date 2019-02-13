using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public class Parser:ParserLogicCommands
    {
        private LineCommand _lastFunction = null;
        private string _fileName;
        private Dictionary<string, Func<string, LineCommand>> _functionalCommandDictionary = new Dictionary<string, Func<string, LineCommand>>();
        private Dictionary<string, CommandMemoryLocation> _memLocDictionary = new Dictionary<string, CommandMemoryLocation>();
        #region Initialization
        public Parser()
        {
            InitializeCommandDictionary();
            InitializeMemLocDictionary();
        }
        private void InitializeCommandDictionary()
        {
            _functionalCommandDictionary.Add("pop", ConvertPopCommand);
            _functionalCommandDictionary.Add("push", ConvertPushCommand);
            _functionalCommandDictionary.Add("label", ConvertLabelCommand);
            _functionalCommandDictionary.Add("if-goto", ConvertConditionalGoto);
            _functionalCommandDictionary.Add("goto", ConvertGoto);
            _functionalCommandDictionary.Add("function", ConvertFunction);
            _functionalCommandDictionary.Add("return", ConvertReturnStatement);
            _functionalCommandDictionary.Add("pop", ConvertPopCommand);
            _functionalCommandDictionary.Add("call", ConvertCallStatement);
            _functionalCommandDictionary.Add("add", ConvertAddCommand);
            _functionalCommandDictionary.Add("eq", ConvertEqualsCommand);
            _functionalCommandDictionary.Add("lt", ConvertLessThanCommand);
            _functionalCommandDictionary.Add("gt", ConvertGreaterThanCommand);
            _functionalCommandDictionary.Add("sub", ConvertSubtractionCommand);
            _functionalCommandDictionary.Add("neg", ConvertNegationCommand);
            _functionalCommandDictionary.Add("and", ConvertAndCommand);
            _functionalCommandDictionary.Add("or", ConvertOrCommand);
            _functionalCommandDictionary.Add("not", ConvertNotCommand);
        }
        private void InitializeMemLocDictionary()
        {
            _memLocDictionary.Add("static", CommandMemoryLocation.Static);
            _memLocDictionary.Add("local", CommandMemoryLocation.Local);
            _memLocDictionary.Add("constant", CommandMemoryLocation.Constant);
            _memLocDictionary.Add("argument", CommandMemoryLocation.Argument);
            _memLocDictionary.Add("this", CommandMemoryLocation.This);
            _memLocDictionary.Add("that", CommandMemoryLocation.That);
            _memLocDictionary.Add("temp", CommandMemoryLocation.Temp);
            _memLocDictionary.Add("pointer", CommandMemoryLocation.Pointer); 
     
            
        }
        #endregion
        
        public List<LineCommand> Parse(List<string> lines, string fileName, bool isInitializer)
        {
            _fileName = fileName;
            List<string> parsedLines = new List<string>();
            parsedLines = RemoveWhitespace(lines);
            List<LineCommand> commands = new List<LineCommand>();
            if (isInitializer) { commands.Add(SetInitializationCommand()); }
            parsedLines.ForEach(x => commands.Add(ConvertToLineCommand(x)));
            ResetState();
                return commands;
        }
        private void ResetState()
        {
            _lastFunction = null;
            _fileName = null;
        }
        private LineCommand SetInitializationCommand()
        {
            LineCommand command = new LineCommand
            {
                CommandType = CommandType.Initialize,
                LabelName = "Sys.init"
            };
            return command;
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
            string[] commandParts = line.Split(' ');
            LineCommand command = null;
            command = _functionalCommandDictionary[line](line);                      
            command.Comment = $"//(----VMCOMMAND--------)\n//----{line}----//";
            command.FileName = _fileName;
            return command;
        }

        private LineCommand ConvertCallStatement(string line)
        {
            LineCommand command = new LineCommand();
            command.CommandType = CommandType.Call;
            List<string> commandParts = line.Split(' ').ToList();
            command.LabelName = commandParts[1];
            command.Value = int.Parse(commandParts[2]);
            _lastFunction = command;
            return command;
        }

        private LineCommand ConvertReturnStatement(string line)
        {
            if(_lastFunction == null)
            {
                throw new Exception("There was no function associated with this return call.");
            }
            else
            {
                LineCommand command = new LineCommand();
                command.CommandType = CommandType.Return;
                command.LabelName = command.LabelName;
                _lastFunction = null;
                return command;
            }
        }

        private LineCommand ConvertFunction(string line)
        {
            LineCommand command = new LineCommand();
            command.CommandType = CommandType.Function;
            List<string> commandParts = line.Split(' ').ToList();
            command.LabelName = commandParts[1];
            command.Value = int.Parse(commandParts[2]);
            _lastFunction = command;
            return command;
        }

        private LineCommand ConvertGoto(string line)
        {
            LineCommand command = new LineCommand();
            command.CommandType = CommandType.GOTO;
            List<string> commandParts = line.Split(' ').ToList();
            command.LabelName = commandParts[1];
            return command;
        }

        private LineCommand ConvertConditionalGoto(string line)
        {
            LineCommand command = new LineCommand();
            command.CommandType = CommandType.If_GOTO;
            List<string> commandParts = line.Split(' ').ToList();
            command.LabelName = commandParts[1];
            return command;
        }

        private LineCommand ConvertLabelCommand(string line)
        {
            List<string> commandParts = line.Split(' ').ToList();
            LineCommand command = new LineCommand();
            command.CommandType = CommandType.Label;
            command.LabelName = commandParts[1];
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

        private CommandMemoryLocation GetMemoryLocationtype(string line)
        {
            return _memLocDictionary[line];
        }
    }
}
