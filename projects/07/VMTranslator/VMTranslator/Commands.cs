using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public enum CommandType
    {
        None,
        Add,
        Subtract,
        Negate,
        Equals,
        GreaterThan,
        LessThan,
        And,
        Or,
        Not,
        Push,
        Pop,

    }

    public enum CommandMemoryLocation
    {
        None,
        Local,
        Static,
        Constant,
        Argument,
        This,
        That,
        Temp,
        Pointer
    }
}
