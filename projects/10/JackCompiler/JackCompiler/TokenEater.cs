﻿using System;
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
            return $"<symbol> {symbol} </symbol>\n";
        }
        private string ConvertSymbols(string symbol)
        {
            switch (symbol)
            {
                case "<":
                    return "&lt;";
                case ">":
                    return "&gt;";
                case "&":
                    return "&amp;";
                case "\"":
                    return "&quot;";
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
