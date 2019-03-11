using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public enum TokenType { keyword, symbol,identifier,integerConstant, stringConstant}
    public enum IdentifierType { STATIC,FIELD, ARG, VAR}
}
