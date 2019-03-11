using System;
using System.IO;

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
            string parsedValue = "<class>\n";
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += ConsumeByType(TokenType.identifier);
            parsedValue += ConsumeSymbol("{");
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != "field" && currentToken.GenericValue != "static")
                {
                    break;
                }
                parsedValue += CompileClassVarDeclarations();
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

            parsedValue += ConsumeSymbol("}");
            parsedValue += "</class>\n";
            _output = parsedValue;
        }
        private void WriteFile()
        {
            File.WriteAllText(_outputFilePath, _output);
        }


    }
}
