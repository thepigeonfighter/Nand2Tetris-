using System;
using System.IO;
using System.Text.RegularExpressions;

namespace JackCompiler
{
    public class CompilationEngine:CompilerBase
    {
        private string _output;
        private string _outputFilePath;

        public CompilationEngine(Tokenizer tokenizer ,string outputFilePath) :base(tokenizer) 
        {
            _outputFilePath = outputFilePath;
            CompileClass();
            WriteFile();
        }

        private void CompileClass()
        {    
            ConsumeByType(TokenType.keyword);
            className = _tokenizer.GetCurrentToken().GenericValue;
            string parsedValue = $"//--------class {className}-----------\n";
            symbolTable = new SymbolTable(className);
            ConsumeByType(TokenType.identifier);
            ConsumeSymbol("{");
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != "field" && currentToken.GenericValue != "static")
                {
                    break;
                }
                CompileClassVarDeclarations();
            }
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != "constructor" && currentToken.GenericValue != "method" && currentToken.GenericValue != "function")
                {
                    break;
                }
                parsedValue += CompileSubroutines();
            }

            ConsumeSymbol("}");
            parsedValue += $"//-------------End class {className} Compilation---------\n";
            _output = parsedValue;
        }
        private void WriteFile()
        {
            string resultString = Regex.Replace(_output, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline);
            File.WriteAllText(_outputFilePath, resultString);
        }


    }
}
