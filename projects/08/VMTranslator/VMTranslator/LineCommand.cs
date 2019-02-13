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
        public int StaticVarNumber { get; set; }
        public string Comment { get; set; }
        public string LabelName { get; set; }
        public string ReturnAddressLabel { get; set; }
        public string FileName { get; set; }

    }
}
