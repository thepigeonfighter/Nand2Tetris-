using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class SymbolTable
    {
        public enum MethodType { Function, Void, Undefined};
        private MethodType localMethodType;
        private Dictionary<string, Identifier> classLevelDictionary = new Dictionary<string, Identifier>();
        private Dictionary<string, Identifier> localLevelDictionary = new Dictionary<string, Identifier>();
        private int argCount;
        private int varCount;
        private int staticCount;
        private int fieldCount;
        private string _className;
        private string _methodName;
        private int labelCount;
        public SymbolTable(string className)
        {
            _className = className;
        }
        public string OnNewMethodStarted(string methodName, bool isStatic)
        {
            localLevelDictionary.Clear();            
            argCount = 0;
            varCount = 0;
            labelCount = 0;
            if (!isStatic)
            {
                DefineLocalIdentifier("this", _className, IdentifierType.ARG);
            }
            localMethodType= MethodType.Undefined;
            _methodName = methodName;
            return "//----Have Reset the local level symbol table-----\n";
        }
        public MethodType GetLocalMethodType()
        {
            return localMethodType;
        }
        public string GenerateLabelName()
        {
            labelCount++;
            return $"{_className}_{_methodName}_{labelCount}";
        }
        public void SetLocalMethodType(MethodType methodType)
        {
            localMethodType = methodType;
        }
        public int GetLocalArgumentCount()
        {
            int args = localLevelDictionary.Where(x=> x.Value.IdentifierType == IdentifierType.VAR).Count();
            return args;
        }
        public int GetClassLevelSymbolCount()
        {
            return classLevelDictionary.Count;
        }
        public string DefineClassLevelIdentifier(string name,string valueType, IdentifierType type)
        {
            if(type == IdentifierType.VAR || type == IdentifierType.ARG)
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
            return $"// -----Added a {type} {valueType} named {name} to the class level symbol table----\n";
        }
        public string DefineLocalIdentifier(string name, string valueType, IdentifierType type)
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
            return $"//---- Added a {type} {valueType} named {name} to the local level symbol table----\n";

        }
        public Identifier GetIdentifier(string name)
        {
            bool classVar = classLevelDictionary.ContainsKey(name);
            if(classVar)
            {
                return classLevelDictionary[name];
            }
            bool localVar = localLevelDictionary.ContainsKey(name);
            if(localVar)
            {
                return localLevelDictionary[name];
            }
            return null;
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
            localLevelDictionary.Add(name, identifier);
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
            localLevelDictionary.Add(name, identifier);
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
            classLevelDictionary.Add(name, staticIdentifier);
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
            classLevelDictionary.Add(name, fieldIdentifier);
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
