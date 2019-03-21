using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class XMLParser : TokenEater
    {
        private string _className;
        private SymbolTable _symbolTable;
        public XMLParser(Tokenizer tokenizer) : base(tokenizer)
        {
        }
        public string ParseExpression(string className,SymbolTable symbolTable)
        {
            _className = className;
            _symbolTable = symbolTable;
            string xmlExpression = ConsumeExpression();
            return xmlExpression;
        }
        public string ParseAssignment(string className, SymbolTable symbolTable)
        {
            _className = className;
            _symbolTable = symbolTable;
            string xmlExpression = ConsumeAssignment();
            return xmlExpression;
        }
        private string ConsumeAssignment()
        {
            string parsedValue = "<expression>\n";
            parsedValue += CompileTerm(true);
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue == ";" || currentToken.GenericValue == ")" ||
                    currentToken.GenericValue == "," || currentToken.GenericValue == "]" || currentToken.GenericValue == "=")
                {
                    break;
                }
                parsedValue += CompileTerm(true);
            }
            parsedValue += "</expression>\n";
            return parsedValue;
        }

        private string ConsumeExpression()
        {
            string parsedValue = "<expression>\n";
            parsedValue += CompileTerm(true);
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue == ";" || currentToken.GenericValue == ")" ||
                    currentToken.GenericValue == "," || currentToken.GenericValue == "]")
                {
                    break;
                }
                parsedValue += CompileTerm(false);
            }
            parsedValue += "</expression>\n";
            return parsedValue;
        }
        private string CompileTerm(bool _assigner)
        {
            string parsedValue = "<term>\n";
            Token currentToken = _tokenizer.GetCurrentToken();
            switch (currentToken.TokenType)
            {
                case TokenType.keyword:
                    parsedValue += CompileKeyWords();
                    break;
                case TokenType.identifier:
                    parsedValue += CompileIdentifiers(_assigner);
                    break;
                case TokenType.integerConstant:
                    parsedValue += CompileIntegerConstants();
                    break;
                case TokenType.stringConstant:
                    parsedValue += CompileStringConstants();
                    break;
                case TokenType.symbol:
                    parsedValue += CompileSymbols(_assigner);
                    break;
                default:
                    throw new Exception("Unhandled type encountered");
            }
            parsedValue += "</term>\n";
            return parsedValue;
        }
        private string CompileSymbols(bool firstTerm)
        {
            string parsedValue = "";
            Token currentToken = _tokenizer.GetCurrentToken();
            if (IsUnaryOp(currentToken.GenericValue) && firstTerm)
            {
                parsedValue += ConsumeUnaryOp(currentToken.GenericValue);
            }
            else if (currentToken.Symbol == '(')
            {
                ConsumeSymbol("(");
                parsedValue += ConsumeExpression();
                ConsumeSymbol(")");
            }
            else
            {
                parsedValue += ConsumeSymbol(currentToken.GenericValue);
            }
            return parsedValue;
        }

        private string CompileStringConstants()
        {
            Token token = _tokenizer.GetCurrentToken();
            return ConsumeByType(TokenType.stringConstant);
        }

        private string CompileKeyWords()
        {
            return ConsumeByType(TokenType.keyword);
        }

        private string CompileIntegerConstants()
        {
            Token currentToken = _tokenizer.GetCurrentToken();
            int num = currentToken.IntValue;
            string parsedValue = $"<integerConstant>{num}</integerConstant>\n";
            ConsumeByType(TokenType.integerConstant);
            return parsedValue;
        }
        private string CompileIdentifiers(bool assigner)
        {

            Token nextToken = _tokenizer.Peek();
            string parsedValue = "";
            if (nextToken.GenericValue == "(" || nextToken.GenericValue == ".")
            {
                parsedValue += CompileSubroutineCalls();
            }
            else if (nextToken.GenericValue == "[")
            {
                parsedValue += ConsumeArray(assigner);
            }
            else
            {
                parsedValue += ConsumeByType(TokenType.identifier);

            }

            return parsedValue;
        }
        private string ConsumeArray(bool assigner)
        {
            string parsedLines = "";
            parsedLines += "<expression>\n";
            parsedLines += "<array>\n";
            parsedLines += "<term>\n";
            parsedLines += ConsumeByType(TokenType.identifier);
            parsedLines += "</term>\n";
            parsedLines += "<term>\n";
            parsedLines += ConsumeSymbol("[");
            parsedLines += "</term>\n";
            parsedLines += "<term>\n";
            parsedLines += ConsumeExpression();
            parsedLines += "</term>\n";
            parsedLines += "<term>\n";
            parsedLines += ConsumeSymbol("]");
            parsedLines += "</term>\n";
            Token currentToken = _tokenizer.GetCurrentToken();
            if(currentToken.GenericValue != "=")
            {
                parsedLines += "<term>\n";
                parsedLines += "<literal>\n";
                parsedLines += VMTranslator.WritePop(MemorySegment.Pointer, 1);
                parsedLines += VMTranslator.WritePush(MemorySegment.That, 0);
                parsedLines += "</literal>\n";
                parsedLines += "</term>\n";
            }
            parsedLines += "</array>\n";
            if (!assigner)
            {
                parsedLines += ConsumeAdditionalArrayExpression();
                
            }
            parsedLines += "</expression>\n";
            return parsedLines;
        }
        private string ConsumeAdditionalArrayExpression()
        {
            string parsedLines = "";
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.GenericValue != ";" && currentToken.GenericValue != ")" &&
                currentToken.GenericValue != "," && currentToken.GenericValue != "]")
            {
                parsedLines += CompileTerm(false);
                parsedLines += ConsumeExpression();
            }
            return parsedLines;
        }
        private bool IsUnaryOp(string segment)
        {
            return (segment == "~" || segment == "-");
        }
        protected string CompileSubroutineCalls()
        {
            string parsedValue = "";
            parsedValue += "<expression>\n";
            Token currentToken = _tokenizer.GetCurrentToken();
            Token nextToken = _tokenizer.Peek();
            bool isObject = false;
            string methodName = "";
            //Checks for local method call
            if (nextToken.GenericValue == "(")
            {
                //Format call like do xxx();
                //Push "this"(current) object onto stack
                parsedValue += "<term>\n";
                parsedValue += "<literal>\n";
                parsedValue += VMTranslator.WritePush(MemorySegment.Pointer, 0);
                parsedValue += "</literal>\n";
                parsedValue += "</term>\n";
                methodName = _className + "." + _tokenizer.GetCurrentToken().GenericValue;
                isObject = true;
                ConsumeByType(TokenType.identifier);
            }
            //Checks for foreign method call
            else if (nextToken.GenericValue == ".")
            {
                methodName = _tokenizer.GetCurrentToken().GenericValue;
                Identifier identifier = _symbolTable.GetIdentifier(methodName);
                if (identifier != null)
                {
                    parsedValue += "push " + VMTranslator.TranslateIdentifier(identifier);
                    methodName = identifier.Type;
                    isObject = true;
                }
                ConsumeByType(TokenType.identifier);
                ConsumeSymbol(".");
                //// Formatted call do XXXX.xxx();
                methodName += "." + _tokenizer.GetCurrentToken().GenericValue;
                ConsumeByType(TokenType.identifier);
            }
            ConsumeSymbol("(");
            //Not the brightest thing
            Tuple<int, string> result = CompileExpressionList();
            parsedValue += result.Item2;
            int lclArgs = result.Item1;
            if (isObject) { lclArgs++; }
            parsedValue += "<term>\n";
            parsedValue += "<literal>\n";
            parsedValue += VMTranslator.WriteCallFunction(methodName, lclArgs);
            parsedValue += "</literal>\n";
            parsedValue += "</term>\n";
            ConsumeSymbol(")");
            parsedValue += "</expression>\n";
            return parsedValue;
        }
        //Not proud of this coding  
        protected Tuple<int, string> CompileExpressionList()
        {
            string parsedValue = "";
            int args = 0;
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue == ")")
                {
                    break;
                }
                parsedValue += ParseExpression(_className, _symbolTable);
                args++;
                currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != ",")
                {
                    break;
                }
                ConsumeSymbol(",");
            }
            Tuple<int, string> result = new Tuple<int, string>(args, parsedValue);
            return result;
        }

    }
}
