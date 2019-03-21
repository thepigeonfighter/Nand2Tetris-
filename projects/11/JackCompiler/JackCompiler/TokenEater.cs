using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class TokenEater
    {
        protected Tokenizer _tokenizer;

        public TokenEater(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        private void Eat(TokenType tokenType)
        {
            Token selectedToken = _tokenizer.GetCurrentToken();
            if (tokenType == selectedToken.TokenType)
            {
                _tokenizer.Advance();
            }
            else
            {
                throw new Exception("Incorrect token type");
            }
        }
        private void Eat(string expectedString)
        {
            Token selectedToken = _tokenizer.GetCurrentToken();
            if (expectedString == selectedToken.GenericValue)
            {
                _tokenizer.Advance();
            }
            else
            {
                throw new Exception("Chipped a tooth.");
            }

        }
        protected string ConsumeSymbol(string symbol)
        {
            Eat(symbol);
            symbol = ConvertSymbols(symbol);
            return $"<symbol>{symbol}</symbol>\n";
        }
        protected string ConsumeUnaryOp(string op)
        {
            Eat(op);
            switch (op)
            {
                case "-":
                    return "<symbol><op>negative</op></symbol>\n";
                case "~":
                    return "<symbol><op>negate</op></symbol>\n";
                default:
                    throw new Exception("Invalid unary op");
            }
        }
        private string ConvertSymbols(string symbol)
        {
            switch (symbol)
            {
                case "<":
                    return "<op>lt</op>";
                case ">":
                    return "<op>gt</op>";
                case "&":
                    return "<op>amp</op>";
                case "/":
                    return "<op>/</op>";
                case "+":
                    return "<op>+</op>";
                case "-":
                    return "<op>-</op>";
                case "~":
                    return "<op>~</op>";
                case "*":
                    return "<op>*</op>";
                case "=":
                    return "<op>=</op>";
                case "|":
                    return "<op>|</op>";
                case "[":
                    return "<arr>[</arr>";
                case "]":
                    return "<arr>]</arr>";
                default:
                    return symbol;
            }
        }
        protected string ConsumeByType(TokenType tokenType)
        {
            //string tokenTypeName = tokenType.ToString().ToLower();
            string tokenValue = _tokenizer.GetCurrentToken().GenericValue;
            tokenValue = tokenValue.Trim('"');
            Eat(tokenType);
            return $"<{tokenType}>{tokenValue}</{tokenType}>\n";
        }

    }
}
