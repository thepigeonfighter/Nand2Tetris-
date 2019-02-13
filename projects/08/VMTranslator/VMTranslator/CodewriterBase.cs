using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public class CodewriterBase
    {
        protected Dictionary<CommandType, Func<LineCommand, string>> CommandDictionary = new Dictionary<CommandType, Func<LineCommand, string>>();
        private Dictionary<CommandMemoryLocation, Func<LineCommand, string>> PushActionDictionary = new Dictionary<CommandMemoryLocation, Func<LineCommand, string>>();
        private Dictionary<CommandMemoryLocation, Func<LineCommand, string>> PopActionDictionary = new Dictionary<CommandMemoryLocation, Func<LineCommand, string>>();
        private int labelCount = 0;
        private int returnCalls;
        #region CTOR/Initialization
        public CodewriterBase()
        {
            InitializeCommandDictionary();
            InitializePushActionDictionary();
            InitializePopActionDictionary();

        }
        private void InitializePushActionDictionary()
        {
            PushActionDictionary.Add(CommandMemoryLocation.None, HandleNoMemorySelectedError);
            PushActionDictionary.Add(CommandMemoryLocation.Local, PushFromMemory);
            PushActionDictionary.Add(CommandMemoryLocation.Static, PushStaticVar);
            PushActionDictionary.Add(CommandMemoryLocation.Constant, PushConstant);
            PushActionDictionary.Add(CommandMemoryLocation.Temp, PushFromTemp);
            PushActionDictionary.Add(CommandMemoryLocation.Pointer, HandlePushPointerCommands);
            PushActionDictionary.Add(CommandMemoryLocation.Argument, PushFromMemory);
            PushActionDictionary.Add(CommandMemoryLocation.This, PushFromMemory);
            PushActionDictionary.Add(CommandMemoryLocation.That, PushFromMemory);
        }
        private void InitializePopActionDictionary()
        {
            PopActionDictionary.Add(CommandMemoryLocation.None, HandleNoMemorySelectedError);
            PopActionDictionary.Add(CommandMemoryLocation.Local, PopToMemory);
            PopActionDictionary.Add(CommandMemoryLocation.Static, PopStaticVar);
            PopActionDictionary.Add(CommandMemoryLocation.Constant, HandleNoMemorySelectedError);
            PopActionDictionary.Add(CommandMemoryLocation.Temp, PopFromTemp);
            PopActionDictionary.Add(CommandMemoryLocation.Pointer, HandlePopPointerCommands);
            PopActionDictionary.Add(CommandMemoryLocation.Argument, PopToMemory);
            PopActionDictionary.Add(CommandMemoryLocation.This, PopToMemory);
            PopActionDictionary.Add(CommandMemoryLocation.That, PopToMemory);
        }

        private void InitializeCommandDictionary()
        {
            CommandDictionary.Add(CommandType.Push, ConvertPushCommands);
            CommandDictionary.Add(CommandType.Pop, ConvertPopCommands);
            CommandDictionary.Add(CommandType.Label, GetLabel);
            CommandDictionary.Add(CommandType.If_GOTO, FunctionalCommands.ConditionalGoto);
            CommandDictionary.Add(CommandType.GOTO, FunctionalCommands.GotoStatement);
            CommandDictionary.Add(CommandType.Function, FunctionalCommands.FunctionalStatement);
            CommandDictionary.Add(CommandType.Return, FunctionalCommands.ReturnStatement);
            CommandDictionary.Add(CommandType.Call, ExecuteMethodCall);
            CommandDictionary.Add(CommandType.Initialize, FunctionalCommands.InitializationString);
            CommandDictionary.Add(CommandType.None, HandleError);
            CommandDictionary.Add(CommandType.Add, Add);
            CommandDictionary.Add(CommandType.Subtract, Subtract);
            CommandDictionary.Add(CommandType.Negate, Negate);
            CommandDictionary.Add(CommandType.Equals, CheckEquality);
            CommandDictionary.Add(CommandType.GreaterThan, CheckEquality);
            CommandDictionary.Add(CommandType.LessThan, CheckEquality);
            CommandDictionary.Add(CommandType.And, And);
            CommandDictionary.Add(CommandType.Or, Or);
            CommandDictionary.Add(CommandType.Not, Not);
        }
        #endregion
        #region Pop Commands
        private string PopFromTemp(LineCommand arg)
        {
            return StackCommands.PopToTempStack(arg.Value);
        }

        private string PopStaticVar(LineCommand arg)
        {
            return StackCommands.PopToStaticVar(GetStaticVarName(arg));
        }

        private string PopToMemory(LineCommand arg)
        {
            return StackCommands.PopToMemory(arg.MemoryLocation, arg.Value);
        }
        #endregion
        #region Push Commands
        private string PushFromTemp(LineCommand arg)
        {
            return StackCommands.PushFromTempStack(arg.Value);
        }

        private string PushConstant(LineCommand arg)
        {
            return StackCommands.Push(arg.Value);
        }

        private string PushStaticVar(LineCommand arg)
        {
            return StackCommands.PushStaticVar(GetStaticVarName(arg));
        }
    
        private string PushFromMemory(LineCommand arg)
        {
            return StackCommands.PushFromMemorySegment(arg.MemoryLocation, arg.Value);
        }
    

        private string HandleNoMemorySelectedError(LineCommand arg)
        {
            throw new Exception("No Memory Type selected;");
        }

        #endregion
        #region Generic Actions
        private string Not(LineCommand arg)
        {
            return LogicArithmeticCommands.Not();
        }

        private string Or(LineCommand arg)
        {
            return LogicArithmeticCommands.Or();
        }

        private string And(LineCommand arg)
        {
            return LogicArithmeticCommands.And();
        }

        private string CheckEquality(LineCommand arg)
        {
            string asm = LogicArithmeticCommands.CheckEquality(arg, labelCount);
            labelCount++;
            return asm;
        }

        private string Negate(LineCommand arg)
        {
            return LogicArithmeticCommands.Negate();
        }

        private string ExecuteMethodCall(LineCommand arg)
        {
            returnCalls++;
            return FunctionalCommands.CallCommand(arg, returnCalls);
        }

        private string Subtract(LineCommand arg)
        {
            return LogicArithmeticCommands.Subtract();
        }

        private string Add(LineCommand arg)
        {
            return LogicArithmeticCommands.Add();
        }

        private string HandleError(LineCommand arg)
        {
            throw new Exception("Invalid line command!");
        }

        protected string GetLabel(LineCommand command)
        {

            return $"({command.LabelName})\n";
        }

        protected string GetStaticVarName(LineCommand command)
        {
            return $"{command.FileName}.var.{command.Value}";
        }
        private string ConvertPopCommands(LineCommand command)
        {
            string asmCode = $"\n";
            asmCode += PopActionDictionary[command.MemoryLocation](command);
            return asmCode;
        }
        private string HandlePushPointerCommands(LineCommand command)
        {
            string msg = "//Pointer Push Command\n";
            if (command.Value == 0)
            {
                command.MemoryLocation = CommandMemoryLocation.This;

            }
            else
            {
                command.MemoryLocation = CommandMemoryLocation.That;
            }
            msg += StackCommands.PointerPush(command);
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
            msg += StackCommands.PointerPop(command);
            return msg;
        }

        private string ConvertPushCommands(LineCommand command)
        {
            string asmCode = $"\n";
            asmCode += PushActionDictionary[command.MemoryLocation](command);
            return asmCode;
        }
        #endregion
    }
}
