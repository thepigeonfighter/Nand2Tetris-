using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class Token
    {
        public TokenType TokenType { get; set; }
        public char Symbol { get; set; }
        public string Identifier { get; set; }
        public int IntValue { get; set; }
        public string StringConstValue { get; set; }
        public string GenericValue { get; set; }
    }
}
