using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public class LineCommand
    {
        public CommandType CommandType { get; set; }
        public CommandMemoryLocation MemoryLocation { get; set; }
        public int Value { get; set; }
    }
}
