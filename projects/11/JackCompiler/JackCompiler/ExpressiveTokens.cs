using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace JackCompiler
{
    public class ExpressiveTokens : TokenEater
    {
        protected SymbolTable symbolTable;        
        protected string className;
        private XMLParser _xmlParser;
        public ExpressiveTokens(Tokenizer tokenizer) : base(tokenizer)
        {
            _xmlParser = new XMLParser(tokenizer);
        }
        protected string WriteExpression()
        {
            string xmlExpression = _xmlParser.ParseExpression(className, symbolTable);
            string parsedXML = XMLParse(xmlExpression);
            return parsedXML;
        }
        protected string WriteAssignment()
        {
            string xmlExpression = _xmlParser.ParseAssignment(className, symbolTable);
            string parsedXML = XMLParse(xmlExpression);
            return parsedXML;
        }



        private string XMLParse(string xml)
        {
            XDocument xDocument = XDocument.Parse(xml);
            var exp = xDocument.XPathSelectElement("/expression");
            return ParseExpressiveElement(exp);
        }
        private List<XElement> GetTerms(XPathNavigator parentNavigator)
        {
            var terms = new List<XElement>();
            if (parentNavigator.Name == "term")
            {
                var term =  XElement.Parse(parentNavigator.OuterXml);
                terms.Add(term);
                return terms;
            }
            var splitTerms = SplitTerms(parentNavigator);

            foreach (var item in splitTerms)
            {
                terms.Add(XElement.Parse(item));
            }
            return terms;
        }
        private List<string> SplitTerms(XPathNavigator parentNavigator)
        {
            List<string> terms = new List<string>();
            parentNavigator.MoveToFirstChild();
            terms.Add(parentNavigator.OuterXml);
            string lastChild = parentNavigator.InnerXml;
            while (true)
            {
                parentNavigator.MoveToNext();
                if (parentNavigator.InnerXml == lastChild)
                {
                    break;
                }                
                lastChild = parentNavigator.InnerXml;
                if (parentNavigator.Name == "term")
                {
                    terms.Add(parentNavigator.OuterXml);
                }
            }
            return terms;
        }

        private string ParseExpressiveElement(XElement exp)
        {

            var terms = GetTerms(exp.CreateNavigator());
            string parsedLines = "";
            for (int i = 0; i < terms.Count; i++)
            {
                if (terms[i].Descendants().Count() == 0)
                {
                    parsedLines += terms[i].Value;
                    continue;
                }
                XElement term = terms[i];
                
                if (IsExpression(term))
                {
                    parsedLines += ParseExpressionNode( terms, ref i, term);
                }

                else if (IsOperator(term))
                {
                    parsedLines += ParseOperatorNode(terms, ref i, term);
                }
                else
                {
                    parsedLines += ParseTermNode( terms, ref i);
                }

            }

            return parsedLines;
        }

        private string  ParseTermNode(List<XElement> terms, ref int i)
        {
            string parsedLines = "";
            bool isArray = IsArray(terms[i]);
            if(isArray)
            {
                return ParseArrayNode(terms, ref i);
            }
            bool hasRoomForExp = (i + 1) < terms.Count();
            if (hasRoomForExp)
            {
                
                
                var expectedOp = terms[i + 1];
                if (!IsOperator(expectedOp))
                {
                    throw new Exception("Expected operator");
                }
                var nextTerm = terms[i + 2];
                bool nextTermIsArray = IsArray(nextTerm);
                parsedLines += ParseTerm(terms[i]);
                if(nextTermIsArray)
                {
                    parsedLines += ParseArray(nextTerm);
                }
                else if (IsExpression(nextTerm))
                {
                    parsedLines += ParseExpressiveElement(nextTerm);
                }
                else
                {
                    parsedLines += ParseTerm(nextTerm);
                }
                parsedLines += ConvertOp(expectedOp.Value);
                i += 2;

            }
            else
            {

                parsedLines += ParseTerm(terms[i]);
            }
            return parsedLines;
        }

        private string ParseArrayNode(List<XElement> terms, ref int i)
        {
            string parsedLines = "";
            parsedLines += ParseArray(terms[i]);
            i++;
            bool hasRoomForExp = (i + 1) < terms.Count();
            if(hasRoomForExp)
            {
                var expectedOp = terms[i];
                if (!IsOperator(expectedOp))
                {
                    throw new Exception("Expected operator");
                }
                var nextTerm = terms[i + 1];
                if (IsExpression(nextTerm))
                {
                    parsedLines += ParseExpressiveElement(nextTerm);
                }
                else
                {
                    parsedLines += ParseTerm(nextTerm);
                }
                parsedLines += ConvertOp(expectedOp.Value);                
                i += 2;
            }
            return parsedLines;
        }

        private string ParseArray(XElement term)
        {
            string parsedLines = "";
            var terms = GetTerms(term.CreateNavigator());
            parsedLines += ParseTerm(terms[0]);
            parsedLines += ParseExpressiveElement(terms[2]);
            parsedLines += VMTranslator.WriteArithmeticCommand(ArithmeticCommand.Add);
            int termCount = terms.Count;
            if(termCount == 5)
            {
                parsedLines += ParseTerm(terms[4]);
            }
            return parsedLines;
        }
        private bool IsArray(XElement term)
        {
            return term.Name.LocalName == "array";
        }
        private string ParseOperatorNode(List<XElement> terms, ref int i, XElement term)
        {
            string parsedLines = "";
            bool hasRoomForExp = (i + 1) < terms.Count();
            if (hasRoomForExp)
            {
                XElement exp1 = terms[i + 1];
                if (!IsExpression(exp1))
                {
                    parsedLines += ParseTerm(terms[i + 1]);
                }
                else
                {
                    parsedLines += ParseExpressiveElement(exp1);
                }
            }
            else
            {
                parsedLines += ParseExpressiveElement(terms[i]);
            }
            if (IsUnaryOp(term.Value))
            {
                parsedLines += ConvertUnaryOp(term.Value);
            }
            else
            {
                parsedLines += ConvertOp(term.Value);
            }
            i++;
            return parsedLines;
        }

        private string ParseExpressionNode( List<XElement> terms, ref int i, XElement term)
        {
            string parsedLines = "";
            bool hasRoomForExp = (i + 1) < terms.Count();
            if (hasRoomForExp)
            {

                XElement op = terms[i + 1];
                if (!IsOperator(op))
                {
                    if(op.Descendants().ToList()[0].Name.LocalName == "literal")
                    {
                        var grandchild = term.Descendants().ToList()[0];
                        parsedLines += ParseExpressiveElement(grandchild);
                        parsedLines += ParseTerm(op);
                        i += 2;
                        return parsedLines;
                    }
                }
                XElement exp1 = terms[i + 2];
                if (!IsExpression(exp1)) //// exp1 op term
                {
                    var grandchild = term.Descendants().ToList()[0];
                    parsedLines += ParseExpressiveElement(grandchild);
                    parsedLines += ParseTerm(exp1);
                    parsedLines += ConvertOp(op.Value);
                }
                else ////// exp1 op exp2
                {
                    var grandchild = term.Descendants().ToList()[0];
                    var grandchild1 = exp1.Descendants().ToList()[0];
                    parsedLines += ParseExpressiveElement(grandchild);
                    parsedLines += ParseExpressiveElement(grandchild1);
                    parsedLines += ConvertOp(op.Value);
                }
                i += 2;
            }
            else
            {
                parsedLines += ParseExpressiveElement(term.Descendants().ToList()[0]);
            }
            return parsedLines;
        }

        private string ConvertUnaryOp(string opValue)
        {
            switch (opValue)
            {
                case "negate":
                    return "not\n";
                case "negative":                
                    return "neg\n";
                default:
                    throw new Exception("Unrecognized unary operator");
            }
        }
        private bool IsExpression(XElement element)
        {
            var children = element.Descendants();
            if (children.Count() == 0)
            {
                return false;
            }
            string localName = children.ToList()[0].Name.LocalName;
            string currentName = element.Name.LocalName;
            return localName == "expression" || currentName == "expression";
        }
        private bool IsOperator(XElement element)
        {
            if (element.Descendants() == null)
            {
                return false;
            }
            var grandChild = element.Descendants().ToList().Descendants().ToList();
            if (grandChild.Count == 0)
            {
                return false;

            }
            string localName = grandChild[0].Name.LocalName;
            return localName == "op";
        }

        private string ParseTerm(XElement term)
        {
            if (term.Descendants().Count() == 0)
            {
                return term.Value;
            }
            string name = term.Descendants().ToList()[0].Name.LocalName;
            switch (name)
            {
                case "integerConstant":
                    return ParseNumber(term.Value);
                case "keyword":
                    return ParseKeyWord(term.Value);
                case "identifier":
                    return ParseVariableName(term.Value);
                case "stringConstant":
                    return ParseStringConstant(term.Value);
                case "literal":
                    return term.Value;
                default:
                    break;
            }


            throw new Exception("Unidentified identifier!");

        }

        private string ParseStringConstant(string value)
        {
            string parsedLines = "";
            int stringLength = value.Length;
            parsedLines += VMTranslator.WritePush(MemorySegment.Constant, stringLength);
            parsedLines += "call String.new 1\n";
            foreach (var c in value)
            {
                int num = c;
                parsedLines += VMTranslator.WritePush(MemorySegment.Constant, num);
                parsedLines += "call String.appendChar 2\n";

            }
            return parsedLines;
        }

        private string ParseKeyWord(string keyWordName)
        {
            switch (keyWordName)
            {
                case "true":
                    return "push constant 0\nnot\n";
                case "false":
                    return "push constant 0\n";
                case "null":
                    return "push constant 0\n";
                case "this":
                    return "push pointer 0\n";
                default:
                    throw new Exception("Invalid keyword");

            }
        }

        private string ParseVariableName(string name)
        {
            Identifier identifier = symbolTable.GetIdentifier(name);
            if (identifier != null)
            {
                string parsedLine = VMTranslator.TranslateIdentifier(identifier);
                return $"push {parsedLine}";
            }
            throw new Exception("Unidentified identifier!");
        }
        private string ParseNumber(string num)
        {
            return $"push constant {num}\n";
        }
        private string ConvertOp(string op)
        {
            switch (op)
            {
                case "+":
                    return "add\n";
                case "*":
                    return "call Math.multiply 2\n";
                case "-":
                    return "sub\n";
                case "~":
                    return "not\n";
                case "lt":
                    return "lt\n";
                case "gt":
                    return "gt\n";
                case "amp":
                    return "and\n";
                case "=":
                    return "eq\n";
                case "|":
                    return "or\n";
                case "/":
                    return "call Math.divide 2\n";
                default:
                    break;
            }
            throw new Exception($"{op} is an unhandled operator");
        }

        private bool IsUnaryOp(string segment)
        {
            return (segment == "~" || segment == "-");
        }
        protected string ConsumeIndexExpression()
        {
            string parsedValue = "";
            ConsumeSymbol("[");
            parsedValue += WriteExpression();
            ConsumeSymbol("]");
            return parsedValue;
        }
        protected string CompileSubroutineCalls()
        {
            string parsedValue = "";
            Token currentToken = _tokenizer.GetCurrentToken();
            Token nextToken = _tokenizer.Peek();
            bool isObject = false;
            string methodName = "";
            //Checks for local method call
            if (nextToken.GenericValue == "(")
            {
                //Format call like do xxx();
                //Push "this"(current) object onto stack
                parsedValue += VMTranslator.WritePush(MemorySegment.Pointer, 0);
                methodName = className + "." + _tokenizer.GetCurrentToken().GenericValue;
                isObject = true;
                ConsumeByType(TokenType.identifier);
            }
            //Checks for foreign method call
            else if (nextToken.GenericValue == ".")
            {
                methodName = _tokenizer.GetCurrentToken().GenericValue;
                Identifier identifier = symbolTable.GetIdentifier(methodName);
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
            parsedValue += VMTranslator.WriteCallFunction(methodName, lclArgs);
            ConsumeSymbol(")");
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
                parsedValue += WriteExpression();
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
