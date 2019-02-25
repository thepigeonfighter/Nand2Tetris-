using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackCompiler
{
    public class CompilerBase :ExpressiveTokens
    {
        public CompilerBase(Tokenizer tokenizer) :base(tokenizer)
        {
        }
        protected string CompileStatements()
        {
            string parsedLines = "<statements>\n";
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue == "}")
                {
                    break;
                }
                switch (currentToken.GenericValue)
                {
                    case "let":
                        parsedLines += CompileLetStatement();
                        break;
                    case "do":
                        parsedLines += CompileDoStatement();
                        break;
                    case "if":
                        parsedLines += CompileIfStatement();
                        break;
                    case "while":
                        parsedLines += CompileWhileStatement();
                        break;
                    case "return":
                        parsedLines += CompileReturnStatement();
                        break;
                    case "}":
                        break;
                    default:
                        throw new Exception("Expected to find a do,let,if,while, or return command.");
                }

            }
            parsedLines += "</statements>\n";
            return parsedLines;
        }
        private string CompileLocalVarDeclarations()
        {
            string parsedValue = "";
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != "var")
                {
                    break;
                }
                parsedValue += "<varDec>\n";
                parsedValue += ConsumeByType(TokenType.keyword);
                currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.TokenType == TokenType.keyword)
                {
                    parsedValue += ConsumeByType(TokenType.keyword);
                }
                else
                {
                    parsedValue += ConsumeByType(TokenType.identifier);
                }
                parsedValue += ConsumeByType(TokenType.identifier);
                //Any extra vars of the same type getting declared on the same line
                
                while (true)
                {
                    currentToken = _tokenizer.GetCurrentToken();
                    if (currentToken.Symbol != ',')
                    {
                        break;
                    }
                    parsedValue += ConsumeSymbol(",");
                    parsedValue += ConsumeByType(TokenType.identifier);
                }
                parsedValue += ConsumeSymbol(";");
                parsedValue += "</varDec>\n";
            }
            return parsedValue;
        }
        private string CompileLetStatement()
        {
            string parsedValue = "<letStatement>\n";
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += ConsumeByType(TokenType.identifier);
            //Check for array acess
            Token currentToken = _tokenizer.GetCurrentToken();
            if(currentToken.GenericValue == "[")
            {
                parsedValue += ConsumeIndexExpression();
            }
            parsedValue += ConsumeSymbol("=");
            parsedValue += ConsumeExpression();
            parsedValue += ConsumeSymbol(";");
            parsedValue += "</letStatement>\n";
            return parsedValue;
        }

        private string CompileIfStatement()
        {
            string parsedValue = "<ifStatement>\n";
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += ConsumeSymbol("(");
            parsedValue += ConsumeExpression();
            parsedValue += ConsumeSymbol(")");
            parsedValue += CompileBracketedStatement();
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.GenericValue != "else")
            {
                parsedValue += "</ifStatement>\n";
                return parsedValue;
            }
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += CompileBracketedStatement();
            parsedValue += "</ifStatement>\n";
            return parsedValue;
        }
        private string CompileWhileStatement()
        {
            string parsedValue = "<whileStatement>\n";
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += ConsumeSymbol("(");
            parsedValue += ConsumeExpression();
            parsedValue += ConsumeSymbol(")");
            parsedValue += CompileBracketedStatement();
            parsedValue += "</whileStatement>\n";
            return parsedValue;
        }
        private string CompileDoStatement()
        {
            string parsedValue = "<doStatement>\n";
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += CompileSubroutineCalls();
            parsedValue += ConsumeSymbol(";");
            parsedValue += "</doStatement>\n";
            return parsedValue;
        }
        private string CompileReturnStatement()
        {
            string parsedValue = "<returnStatement>\n" +
            ConsumeByType(TokenType.keyword);
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.GenericValue != ";")
            {
                parsedValue += ConsumeExpression();
            }
            parsedValue += ConsumeSymbol(";");
            parsedValue += "</returnStatement>\n";
            return parsedValue;
        }
        private string CompileMethods()
        {
            string parsedValue = "";
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += ConsumeByType(TokenType.identifier);
            parsedValue += ConsumeSymbol("(");
            parsedValue += CompileParameterList();
            parsedValue += ConsumeSymbol(")");
            parsedValue += CompileSubroutineBody();
            return parsedValue;
        }

        private string CompileConstructors()
        {
            string parsedValue = "";
            parsedValue += ConsumeByType(TokenType.keyword);
            parsedValue += ConsumeByType(TokenType.identifier);
            parsedValue += ConsumeByType(TokenType.identifier);
            parsedValue += ConsumeSymbol("(");
            parsedValue += CompileParameterList();
            parsedValue += ConsumeSymbol(")");
            parsedValue += CompileSubroutineBody();
            return parsedValue;
        }
        private string CompileParameterList()
        {
            string parsedValue = "<parameterList>\n";
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.Symbol == ')')
                {
                    break;
                }
                else if (currentToken.TokenType == TokenType.keyword)
                {
                    parsedValue += ConsumeByType(TokenType.keyword);                   

                }
                else if (currentToken.TokenType == TokenType.identifier)
                {
                    parsedValue += ConsumeByType(TokenType.identifier);
                }
                parsedValue += ConsumeByType(TokenType.identifier);
                currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != ",")
                {
                    break;
                }
                parsedValue += ConsumeSymbol(",");

            }
            parsedValue += "</parameterList>\n";
            return parsedValue;
        }
        protected string CompileClassVarDeclarations()
        {
            string parsedValue = "<classVarDec>\n";
            parsedValue += ConsumeByType(TokenType.keyword);
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.TokenType == TokenType.identifier || currentToken.TokenType == TokenType.keyword)
            {
                parsedValue += ConsumeByType(currentToken.TokenType);
            }
            else
            {
                throw new Exception("Invalid class var declaration");
            }
            parsedValue += ConsumeByType(TokenType.identifier);
            while (true)
            {
                currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue == ";")
                {
                    parsedValue += ConsumeSymbol(";");
                    break;
                }
                else
                {
                    parsedValue += ConsumeSymbol(",");
                    parsedValue += ConsumeByType(TokenType.identifier);
                }
            }

            parsedValue += "</classVarDec>\n";
            return parsedValue;
        }
       
        protected string CompileSubroutines()
        {
            string parsedValue = "<subroutineDec>\n";
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.GenericValue == "constructor")
            {
                parsedValue += CompileConstructors();
            }
            else
            {
                parsedValue += CompileMethods();
            }
            parsedValue += "</subroutineDec>\n";
            return parsedValue;
        }
        private string CompileSubroutineBody()
        {
            string parsedValue = "<subroutineBody>\n";
            parsedValue += CompileBracketedStatement();
            parsedValue += "</subroutineBody>\n";
            return parsedValue;
        }
        private string CompileBracketedStatement()
        {
            string parsedValue = "";
            parsedValue += ConsumeSymbol("{");
            parsedValue += CompileLocalVarDeclarations();
            parsedValue += CompileStatements();
            parsedValue += ConsumeSymbol("}");
            return parsedValue;
        }



    }
}
