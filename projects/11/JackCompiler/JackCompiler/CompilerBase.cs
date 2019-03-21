using System;

namespace JackCompiler
{
    public class CompilerBase : ExpressiveTokens
    {

        public CompilerBase(Tokenizer tokenizer) : base(tokenizer)
        {
        }
        protected string CompileStatements()
        {
            string parsedLines = "";
            while (true)
            {
                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue == "}" || currentToken.GenericValue == "return")
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
                    case "}":
                        break;
                    default:
                        throw new Exception("Expected to find a do,let,if,while, or return command.");
                }

            }
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
                //Expected Var
                ConsumeByType(TokenType.keyword);
                IdentifierType type = IdentifierType.VAR;
                currentToken = _tokenizer.GetCurrentToken();
                string valueType = currentToken.GenericValue;
                //Expects either ref or value type 
                if (currentToken.TokenType == TokenType.keyword)
                {
                    ConsumeByType(TokenType.keyword);
                }
                else
                {
                    ConsumeByType(TokenType.identifier);
                }
                string name = _tokenizer.GetCurrentToken().GenericValue;
                ConsumeByType(TokenType.identifier);
                //Stores var in symbol table for future use
                parsedValue += symbolTable.DefineLocalIdentifier(name, valueType, type);

                //Any extra vars of the same type getting declared on the same line                
                while (true)
                {
                    currentToken = _tokenizer.GetCurrentToken();
                    if (currentToken.Symbol != ',')
                    {
                        break;
                    }
                    ConsumeSymbol(",");
                    name = _tokenizer.GetCurrentToken().GenericValue;
                    //Stores any extra vars of the same type
                    parsedValue += symbolTable.DefineLocalIdentifier(name, valueType, type);
                    ConsumeByType(TokenType.identifier);
                }
                ConsumeSymbol(";");
            }
            return parsedValue;
        }
        private string CompileLetStatement()
        {
            string parsedValue = "";
            ConsumeByType(TokenType.keyword);
            string varName = _tokenizer.GetCurrentToken().GenericValue;
            Token nextToken = _tokenizer.Peek();
            if(nextToken.GenericValue == "[")
            {
                return CompileLetArrayStatement();
            }
            ConsumeByType(TokenType.identifier);
            Identifier identifier = symbolTable.GetIdentifier(varName);
            ConsumeSymbol("=");
            nextToken = _tokenizer.Peek();
            if (nextToken.GenericValue == ".")
            {
                parsedValue += CompileSubroutineCalls();
            }
            else
            {
                parsedValue += WriteExpression();
            }
            ConsumeSymbol(";");
            parsedValue += "pop " + VMTranslator.TranslateIdentifier(identifier);

            return parsedValue;
        }
        private string CompileArrayStatement(bool assignment)
        {
            string parsedValue = "";
            if (assignment)
            {
                parsedValue += WriteAssignment();                
            }
            else
            {
                parsedValue += WriteExpression();
                
            }
            return parsedValue;
        }
        private string CompileLetArrayStatement()
        {
            string parsedValue = "";
            parsedValue += CompileArrayStatement(true);            
            ConsumeSymbol("=");
            Token nextToken = _tokenizer.Peek();
            if (nextToken.GenericValue == "[")
            {
                parsedValue += CompileArrayStatement(false);
            }
            else
            {
                parsedValue += WriteExpression();
            }
           
            //store result in temp var
            parsedValue += VMTranslator.WritePop(MemorySegment.Temp, 0);
            //set pointer one to array on the left of equation
            parsedValue += VMTranslator.WritePop(MemorySegment.Pointer, 1);
            //pushes temp var onto stack
            parsedValue += VMTranslator.WritePush(MemorySegment.Temp, 0);
            //sets the array on the lefthand side of equation to the temp var that was taken from the right
            parsedValue += VMTranslator.WritePop(MemorySegment.That, 0);
            
            ConsumeSymbol(";");
            return parsedValue;
        }

        private string CompileIfStatement()
        {
            string parsedValue = "";
            string label1 = symbolTable.GenerateLabelName();
            string label2 = symbolTable.GenerateLabelName();
            string endStatement = symbolTable.GenerateLabelName();
            ConsumeByType(TokenType.keyword);
            ConsumeSymbol("(");
            parsedValue += WriteExpression();
            parsedValue += VMTranslator.WriteIfStatement(label1);
            parsedValue += VMTranslator.WriteGoTo(label2);

            ConsumeSymbol(")");

            //statements 1
            parsedValue += "label " + label1 + "\n";
            parsedValue += CompileBracketedStatement();
            parsedValue += VMTranslator.WriteGoTo(endStatement);
            Token currentToken = _tokenizer.GetCurrentToken();            
            //statements 2
            parsedValue += "label " + label2 + "\n";
            if (currentToken.GenericValue == "else")
            {
                ConsumeByType(TokenType.keyword);
                parsedValue += CompileBracketedStatement();
            }
            

            //exit statement
            parsedValue += "label " + endStatement + "\n";
            return parsedValue;
        }
        private string CompileWhileStatement()
        {
            string parsedValue = "";
            string label1 = symbolTable.GenerateLabelName();
            string label2 = symbolTable.GenerateLabelName();

            ConsumeByType(TokenType.keyword);
            ConsumeSymbol("(");
            // evaluate condition in while(condition)
            parsedValue += "label " + label1 + "\n";
            parsedValue += WriteExpression();
            parsedValue += VMTranslator.WriteArithmeticCommand(ArithmeticCommand.Not);
            //if condition not true do jump to exit
            parsedValue += VMTranslator.WriteIfStatement(label2);

            ConsumeSymbol(")");

            parsedValue += CompileBracketedStatement();
            //jump back to condition evaluation 
            parsedValue += VMTranslator.WriteGoTo(label1);
            // jump here to exit loop
            parsedValue += "label " + label2 + "\n";
            return parsedValue;
        }
        private string CompileDoStatement()
        {
            string parsedValue = "";
            ConsumeByType(TokenType.keyword);
            parsedValue += CompileSubroutineCalls();
            parsedValue += "pop temp 0\n";
            ConsumeSymbol(";");
            return parsedValue;
        }
        private string CompileReturnStatement(bool isVoid)
        {
            string parsedValue = "";
            ConsumeByType(TokenType.keyword);
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.GenericValue != ";")
            {
                parsedValue += WriteExpression();
            }
            ConsumeSymbol(";");
            if (isVoid)
            {
                parsedValue += "push constant 0\n";
            }
            parsedValue += VMTranslator.WriteReturnStatement();
            return parsedValue;
        }
        private string CompileMethods()
        {
            string parsedValue = "";
            bool isFunc = _tokenizer.GetCurrentToken().GenericValue == "function";
            ConsumeByType(TokenType.keyword);
            string returnType = _tokenizer.GetCurrentToken().GenericValue;
            bool isVoid = returnType == "void";
            ConsumeByType(_tokenizer.GetCurrentToken().TokenType);
            string methodName = _tokenizer.GetCurrentToken().GenericValue;
            symbolTable.OnNewMethodStarted(methodName, isFunc);
            SetLocalMethodType(isVoid);
            ConsumeByType(TokenType.identifier);
            ConsumeSymbol("(");
            CompileParameterList();
            ConsumeSymbol(")");
            int insertIndex = 0;
            if (isVoid)
            {
                parsedValue += $"//----Compiling Void Method {methodName}----\n";
                insertIndex += parsedValue.Length;
            }
            else
            {
                parsedValue += $"//----Compiling Method {methodName} which returns  a {returnType} to stack----\n";
                insertIndex += parsedValue.Length;
            }
            if (!isFunc)
            {
                parsedValue += "push argument 0\n";
                parsedValue += "pop pointer 0 \n";
            }
            parsedValue += CompileBracketedStatement();
            int args = symbolTable.GetLocalArgumentCount();
            parsedValue = parsedValue.Insert(insertIndex, VMTranslator.WriteFunctionDeclaration(className + "." + methodName, args));
            return parsedValue;
        }
        private void SetLocalMethodType(bool isVoid)
        {
            if (isVoid)
            {
                symbolTable.SetLocalMethodType(SymbolTable.MethodType.Void);
            }
            else
            {
                symbolTable.SetLocalMethodType(SymbolTable.MethodType.Function);
            }
        }
        private string CompileConstructors()
        {
            string parsedValue = "";
            parsedValue += VMTranslator.WriteFunctionDeclaration($"{className}.new", 0);
            ConsumeByType(TokenType.keyword);
            ConsumeByType(TokenType.identifier);
            ConsumeByType(TokenType.identifier);
            int classLevelVarCount = symbolTable.GetClassLevelSymbolCount();
            parsedValue += VMTranslator.WritePush(MemorySegment.Constant, classLevelVarCount);
            parsedValue += "call Memory.alloc 1\n";
            parsedValue += VMTranslator.WritePop(MemorySegment.Pointer, 0);            
            ConsumeSymbol("(");
            parsedValue += CompileParameterList();
            ConsumeSymbol(")");
            parsedValue += CompileBracketedStatement();
            return parsedValue;
        }
        private string CompileParameterList()
        {
            string parsedValue = "";
            while (true)
            {

                Token currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.Symbol == ')')
                {
                    break;
                }

                IdentifierType type = IdentifierType.ARG;
                string valueType = currentToken.GenericValue;


                if (currentToken.TokenType == TokenType.keyword)
                {
                    ConsumeByType(TokenType.keyword);

                }
                else if (currentToken.TokenType == TokenType.identifier)
                {
                    ConsumeByType(TokenType.identifier);
                }
                string name = _tokenizer.GetCurrentToken().GenericValue;
                symbolTable.DefineLocalIdentifier(name, valueType, type);
                ConsumeByType(TokenType.identifier);
                currentToken = _tokenizer.GetCurrentToken();
                if (currentToken.GenericValue != ",")
                {
                    break;
                }
                ConsumeSymbol(",");

            }
            return parsedValue;
        }
        protected string CompileClassVarDeclarations()
        {
            string parsedValue = "<classVarDec>\n";
            IdentifierType identifierType = GetIdentifierType(_tokenizer.GetCurrentToken().GenericValue);
            parsedValue += ConsumeByType(TokenType.keyword);
            Token currentToken = _tokenizer.GetCurrentToken();
            string valueType = "";
            if (currentToken.TokenType == TokenType.identifier || currentToken.TokenType == TokenType.keyword)
            {
                valueType = currentToken.GenericValue;
                parsedValue += ConsumeByType(currentToken.TokenType);
            }
            else
            {
                throw new Exception("Invalid class var declaration");
            }
            string name = _tokenizer.GetCurrentToken().GenericValue;
            parsedValue += symbolTable.DefineClassLevelIdentifier(name, valueType, identifierType);
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
                    name = _tokenizer.GetCurrentToken().GenericValue;
                    parsedValue += symbolTable.DefineClassLevelIdentifier(name, valueType, identifierType);
                    parsedValue += ConsumeByType(TokenType.identifier);
                }
            }

            parsedValue += "</classVarDec>\n";
            return parsedValue;
        }

        protected string CompileSubroutines()
        {
            string parsedValue = "";
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.GenericValue == "constructor")
            {
                parsedValue += CompileConstructors();
            }
            else
            {
                parsedValue += CompileMethods();
            }
            parsedValue += "//----End Subroutine----\n";
            return parsedValue;
        }
        private IdentifierType GetIdentifierType(string type)
        {
            switch (type)
            {
                case "field":
                    return IdentifierType.FIELD;
                case "arg":
                    return IdentifierType.ARG;
                case "var":
                    return IdentifierType.VAR;
                case "static":
                    return IdentifierType.STATIC;
                default:
                    throw new Exception($"'{type}' is not a valid identifier type.");
            }
        }

        private bool IsVoidMethod()
        {
            switch (symbolTable.GetLocalMethodType())
            {
                case SymbolTable.MethodType.Function:
                    return false;
                case SymbolTable.MethodType.Void:
                    return true;
                case SymbolTable.MethodType.Undefined:
                default:
                    throw new Exception("Undefined method state!");
            }
        }
        private string CompileBracketedStatement()
        {
            string parsedValue = "";
            ConsumeSymbol("{");
            parsedValue += CompileLocalVarDeclarations();
            parsedValue += CompileStatements();
            Token currentToken = _tokenizer.GetCurrentToken();
            if (currentToken.GenericValue == "return")
            {
                parsedValue += CompileReturnStatement(IsVoidMethod());
            }
            ConsumeSymbol("}");
            return parsedValue;
        }




    }
}
