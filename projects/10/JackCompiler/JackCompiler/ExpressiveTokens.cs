using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class ExpressiveTokens : TokenEater
    {

        public ExpressiveTokens(Tokenizer tokenizer) : base(tokenizer)
        {
        }
        protected string ConsumeExpression()
        {
            string parsedValue = "<expression>\n";
            parsedValue += CompileTerm();
            while(true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if(currentToken.GenericValue == ";" || currentToken.GenericValue == ")" || currentToken.GenericValue =="," || currentToken.GenericValue == "]")
                {
                    break;
                }
                string symbol = currentToken.GenericValue;
                parsedValue += ConsumeSymbol(symbol);
                parsedValue += CompileTerm();
            }
            parsedValue += "</expression>\n";
            return parsedValue;
        }
        private string CompileTerm()
        {
            string parsedValue = "<term>\n";
            Token currentToken = _tokenizer.GetCurrentToken();
            switch (currentToken.TokenType)
            {
                case TokenType.keyword:
                    parsedValue += CompileKeyWords();
                    break;
                case TokenType.identifier:
                    parsedValue += CompileIdentifiers();
                    break;
                case TokenType.integerConstant:
                    parsedValue += CompileIntegerConstants();
                    break;
                case TokenType.stringConstant:
                    parsedValue += CompileStringConstants();
                    break;
                case TokenType.symbol:
                    parsedValue += CompileSymbols();
                    break;
                default:
                    throw new Exception("Unhandled type encountered");
            }
            parsedValue += "</term>\n";
            return parsedValue;
        }

        private string CompileSymbols()
        {
            string parsedValue = "";
            Token currentToken = _tokenizer.GetCurrentToken();
            if(IsUnaryOp(currentToken.GenericValue))
            {
                parsedValue += ConsumeSymbol(currentToken.GenericValue);
                parsedValue += CompileTerm();
            }
            else if( currentToken.Symbol == '(')
            {
                parsedValue += ConsumeSymbol("(");
                parsedValue += ConsumeExpression();
                parsedValue += ConsumeSymbol(")");
            }
            else
            {
                parsedValue += ConsumeSymbol(currentToken.GenericValue);
            }
            return parsedValue;
        }

        private string CompileStringConstants()
        {
            
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
        private string CompileIdentifiers()
        {
            
            Token nextToken = _tokenizer.Peek();
            string parsedValue = "";
            if(nextToken.GenericValue == "(" || nextToken.GenericValue == ".")
            {
                parsedValue += CompileSubroutineCalls();

            }
            else if(nextToken.GenericValue == "[")
            {
                parsedValue += ConsumeByType(TokenType.identifier);
                parsedValue += ConsumeIndexExpression();
            }
            else
            {
                parsedValue += ConsumeByType(TokenType.identifier);
                
            }
            
            return parsedValue;
        }
        private bool IsUnaryOp(string segment)
        {
            return (segment == "~" || segment == "-");
        }
        protected string CompileSubroutineCalls()
        {
            string parsedValue = "";
            Token currentToken = _tokenizer.GetCurrentToken();
            Token nextToken = _tokenizer.Peek();
            if (nextToken.GenericValue == "(")
            {
                parsedValue += ConsumeByType(TokenType.identifier);

            }
            else if (nextToken.GenericValue == ".")
            {
                parsedValue += ConsumeByType(TokenType.identifier);
                parsedValue += ConsumeSymbol(".");
                parsedValue += ConsumeByType(TokenType.identifier);
            }
            parsedValue += ConsumeSymbol("(");
            parsedValue += CompileExpressionList();
            parsedValue += ConsumeSymbol(")");
            return parsedValue;
        }
        protected string CompileExpressionList()
        {
            string parsedValue = "<expressionList>\n";
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue == ")")
                {
                    break;
                }
                parsedValue += ConsumeExpression();
                currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != ",")
                {
                    break;
                }
                parsedValue += ConsumeSymbol(",");
            }
            parsedValue += "</expressionList>\n";
            return parsedValue;
        }
        protected string ConsumeIndexExpression()
        {
            string parsedValue = ConsumeSymbol("[");
            parsedValue += ConsumeExpression();
            parsedValue += ConsumeSymbol("]");
            return parsedValue;
        }
    }
}
