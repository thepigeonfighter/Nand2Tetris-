using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class SymbolTable
    {
        private Dictionary<string, Identifier> classLevelDictionary = new Dictionary<string, Identifier>();
        private Dictionary<string, Identifier> localLevelDictionary = new Dictionary<string, Identifier>();
        private int argCount;
        private int varCount;
        private int staticCount;
        private int fieldCount;
        public void ResetLocalTable()
        {
            localLevelDictionary.Clear();
            argCount = 0;
            varCount = 0;
        }
        public void DefineClassLevelIdentifier(string name,string valueType, IdentifierType type)
        {
            if(type != IdentifierType.STATIC || type != IdentifierType.STATIC)
            {
                throw new Exception("Invalid Class level identifier!");
            }
            if(type == IdentifierType.STATIC)
            {
                AddStaticIdentifier(name, valueType);
            }
            else
            {
                AddFieldIdentifier(name, valueType);
            }

        }
        public void DefineLocalIdentifier(string name, string valueType, IdentifierType type)
        {
            if(type == IdentifierType.STATIC || type == IdentifierType.FIELD)
            {
                throw new Exception("Invalid local identifier!");
            }
            if (type == IdentifierType.ARG)
            {
                AddArgIdentifier(name, valueType); 
            }
            else
            {
                AddVarIdentifier(name, valueType);
            }
           
        }
        public int GetVarCount(IdentifierType type)
        {
            switch (type)
            {
                case IdentifierType.STATIC:
                    return staticCount;
                case IdentifierType.FIELD:
                    return fieldCount;
                case IdentifierType.ARG:
                    return argCount;
                case IdentifierType.VAR:
                    return varCount;
                default:
                    throw new Exception("Invalid identifier type");
            }
        }
        
        private void AddVarIdentifier(string name, string valueType)
        {
            Identifier identifier = new Identifier()
            {
                Name = name,
                Type  = valueType,
                IdentifierType = IdentifierType.VAR,
                Number = varCount
            };
            varCount++;
        }

        private void AddArgIdentifier(string name, string valueType)
        {
            Identifier identifier = new Identifier()
            {
                Name = name,
                Type = valueType,
                IdentifierType = IdentifierType.ARG,
                Number = argCount
            };
            argCount++;
        }

        private void AddStaticIdentifier(string name, string valueType)
        {
            Identifier staticIdentifier = new Identifier()
            {
                Name = name,
                IdentifierType = IdentifierType.STATIC,
                Number = staticCount,
                Type = valueType
            };
            staticCount++;
        }
        private void AddFieldIdentifier(string name, string valueType)
        {
            Identifier fieldIdentifier = new Identifier()
            {
                Name = name,
                IdentifierType = IdentifierType.FIELD,
                Number = fieldCount,
                Type = valueType
            };
            fieldCount++;
        }
    }

    public class Identifier
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IdentifierType IdentifierType { get; set; }
        public int Number { get; set; }
    }
}
