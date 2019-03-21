using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class Tokenizer:TokenizerBase
    {
        
        private List<Token> tokens = new List<Token>();
        private Token selectedToken;
        private int currentIndex;
        public Tokenizer(string[] lines)
        {
            lines = TextCleanser.RemoveWhitespaceAndComments(lines.ToList()).ToArray();
            BuildTokenList(lines.ToList());
            selectedToken = tokens[0];
        }

        private void BuildTokenList(List<string> lines)
        {
            List<string> formattedLines = new List<string>();
            lines.ForEach(x => formattedLines.AddRange(Tokenify(x)));
            formattedLines.Where(x=>IsValidWord(x)).ToList().ForEach(x => tokens.Add(ClassifySegment(x)));
        }

        //-------PUBLIC API---------
        public bool HasMoreTokens()
        {
            return !(currentIndex == tokens.Count -1);
        }
        public void Advance()
        {
            if(HasMoreTokens())
            {
                currentIndex++;
                selectedToken = tokens[currentIndex];
            }
        }
        public Token GetCurrentToken()
        {
            return selectedToken;
        }
        public Token Peek()
        {
            if(currentIndex + 1 < tokens.Count)
            {
                Token token = tokens[currentIndex + 1];
                return token;
            }
            throw new Exception("Invalid peek");
        }
    }
} 
