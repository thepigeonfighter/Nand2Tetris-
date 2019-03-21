using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class TokenizerBase
    {
        protected Token ClassifySegment(string segment)
        {
            Token token = null;
            if (char.IsNumber(segment[0]))
            {
                token = ClassifySegmentIntToken(segment);
            }
            else if (IsSymbol(segment))
            {
                token = ClassifySymbolToken(segment);
            }
            else
            {
                token = ClassifyStringToken(segment);
            }
            token.GenericValue = segment;
            return token;
        }
        protected bool IsValidWord(string segment)
        {
            string pattern = "(" + "\"" + @"?\w*" + "\"?)";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(segment);
        }
        private Token ClassifyStringToken(string segment)
        {
            if (segment.Contains('"'))
            {
                return ClassifyStringConstantToken(segment);
            }
            else if (IsKeyWord(segment))
            {
                return ClassifyKeywordToken(segment);
            }
            else
            {
                return ClassifyIdentifierToken(segment);
            }
        }

        private Token ClassifyIdentifierToken(string segment)
        {
            Token token = new Token()
            {
                TokenType = TokenType.identifier,
                Identifier = segment
            };
            return token;
        }

        private Token ClassifyKeywordToken(string segment)
        {
            Token token = new Token()
            {
                TokenType = TokenType.keyword
            };
            return token;
        }

        private Token ClassifyStringConstantToken(string segment)
        {
            segment = segment.Trim('"');
            Token token = new Token()
            {
                TokenType = TokenType.stringConstant,
                StringConstValue = segment
            };
            return token;
        }

        private Token ClassifySymbolToken(string segment)
        {
            Token token = new Token()
            {
                TokenType = TokenType.symbol,
                Symbol = segment[0]
            };
            return token;
        }

        private Token ClassifySegmentIntToken(string segment)
        {
            Token token = new Token()
            {
                IntValue = Convert.ToInt16(segment),
                TokenType = TokenType.integerConstant
            };
            return token;
        }
        private bool IsKeyWord(string word)
        {
            string pattern = @"\b(if|class|method|function|constructor|int|bool|boolean|char|void|var|static|field|let|do|else|while|return|true|false|null|this)\b";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(word))
            {
                return true;
            }
            return false;
        }
        private bool IsSymbol(string word)
        {
            string pattern = @"(\(|\)|{|}|;|,|\[|\]|\.|\+|=|-|\*|\/|&|\||<|>|~)";
            Regex regex = new Regex(pattern);
            if(word[0] == '"' || word[word.Length -1] == '"')
            {
                return false;
            }
            if (regex.IsMatch(word))
            {
                return true;
            }
            return false;
        }
        private bool IsValidLetterType(string value)
        {
            string pattern = @"(\w|" + "\")";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(value))
            {
                return true;
            }
            return false;
        }
        protected List<string> Tokenify(string line)
        {
            List<string> tokensInLine = new List<string>();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                string token = "";
                if (char.IsNumber(c))
                {
                    token = GetIntConstToken(line.Substring(i));
                    i += token.Length - 1;

                }
                else if (IsValidLetterType(c.ToString()))
                {
                    token = GetStringToken(line.Substring(i));
                    i += token.Length - 1;
                }
                else
                {
                    token = c.ToString();
                }
                if (!string.IsNullOrWhiteSpace(token))
                {
                    tokensInLine.Add(token);
                }
            }
            return tokensInLine;
        }
        private Token BuildSymbolToken(string segment)
        {
            Token symbol = new Token()
            {
                TokenType = TokenType.symbol,
                Symbol = segment[0]
            };
            return symbol;
        }
        private string GetIntConstToken(string line)
        {
            string num = "";
            int index = 0;
            while (index < line.Length)
            {
                var c = line[index];
                if (!char.IsNumber(c))
                {
                    break;
                }
                num += c;
                index++;
            }
            return num;
        }




        private string GetStringToken(string line)
        {
            if(line[0]=='"')
            {
                return GetStringConstant(line);
            }
            else
            {
                return GetIdentifier(line);
            }
        }
        private string GetIdentifier(string line)
        {
            string word = "";
            int index = 0;
            while (index < line.Length)
            {
                var c = line[index];
                if (!IsValidLetterType(c.ToString()))
                {
                    return word;
                }
                word += c;
                index++;
            }
            return word;
        }
        private string GetStringConstant(string line)
        {
            string word = "";
            word += line[0];
            int index = 1;
            bool foundEndOfString = false;
            while (index < line.Length)
            {
                var c = line[index];
                if (foundEndOfString)                    
                {
                    return word;
                }
                if(c== '"')
                {
                    foundEndOfString = true;
                }
                word += c;
                index++;
            }
            return word;
        }
    }
}
