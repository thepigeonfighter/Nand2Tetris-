using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public enum TokenType { keyword, symbol,identifier,integerConstant, stringConstant}
    public enum IdentifierType { STATIC,FIELD, ARG, VAR}
    public enum MemorySegment { Constant,Local,Argument,This,That,Pointer,Temp}
    public enum ArithmeticCommand { Add,Subtract,Equal,GreatThan,LessThan,And,Or,Not,Negate}
}
