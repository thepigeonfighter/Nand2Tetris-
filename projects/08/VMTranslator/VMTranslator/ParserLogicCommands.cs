using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public class ParserLogicCommands
    {
        protected LineCommand ConvertOrCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.Or };
        }

        protected LineCommand ConvertNotCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.Not };
        }

        protected LineCommand ConvertAndCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.And };
        }

        protected LineCommand ConvertNegationCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.Negate };
        }

        protected LineCommand ConvertSubtractionCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.Subtract };
        }

        protected LineCommand ConvertGreaterThanCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.GreaterThan };
        }

        protected LineCommand ConvertLessThanCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.LessThan };
        }

        protected LineCommand ConvertEqualsCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.Equals };
        }

        protected LineCommand ConvertAddCommand(string arg)
        {
            return new LineCommand() { CommandType = CommandType.Add };
        }
    }
}
