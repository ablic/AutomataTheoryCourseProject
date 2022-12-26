using System.Collections.Generic;

namespace ATFLCourseProject
{
    class SyntacticalAnalyzer
    {
        public struct OperationInfo
        {
            public LexemeToken Operation { get; private set; }
            public LexemeToken Operand1 { get; private set; }
            public LexemeToken Operand2 { get; private set; }
            public LexemeToken Result { get; private set; }

            public OperationInfo(LexemeToken operation, LexemeToken operand1, LexemeToken operand2, LexemeToken result)
            {
                Operation = operation;
                Operand1 = operand1;
                Operand2 = operand2;
                Result = result;
            }
        }

        private List<LexemeToken> lexemes;
        private int currentLexemeIndex;
        private LexemeToken currentLexeme;

        private Stack<LexemeToken> exprOperands = new Stack<LexemeToken>();
        private Stack<LexemeToken> exprSeparators = new Stack<LexemeToken>();
        private int exprCounter = 1;

        public readonly List<OperationInfo> operations = new List<OperationInfo>();

        public void Analyze(List<LexemeToken> lexemes)
        {
            this.lexemes = lexemes;
            currentLexemeIndex = 0;
            currentLexeme = lexemes[currentLexemeIndex];
            exprOperands.Clear();
            exprSeparators.Clear();
            exprOperands.Clear();
            exprCounter = 1;
            operations.Clear();
            OperatorList();
        }

        private void Next()
        {
            currentLexemeIndex++;
            currentLexeme = lexemes[currentLexemeIndex];
        }

        private void OperatorList()
        {
            if (currentLexeme.Type == LexemeType.END)
                return;

            Operator();
            EmptyOrNextLineOperatorList();
        }

        private void Operator()
        {
            switch (currentLexeme.Type)
            {
                case LexemeType.KEYWORD_Dim: 
                    Declaration(); break;

                case LexemeType.ID: 
                    Assignment(); break;

                case LexemeType.KEYWORD_Do: 
                    Cycle(); break;

                default:
                    throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "Dim", "id", "do");
            }
        }

        private void EmptyOrNextLineOperatorList()
        {
            if (currentLexeme.Type != LexemeType.SEPARATOR_LineBreak)
                return;

            if (lexemes[currentLexemeIndex + 1].Type != LexemeType.KEYWORD_Loop)
            {
                Next();
                OperatorList();
            }
        }

        private void Declaration()
        {
            if (currentLexeme.Type != LexemeType.KEYWORD_Dim)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "Dim");

            Next();
            VariableList();

            if (currentLexeme.Type != LexemeType.KEYWORD_As)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "as");

            Next();
            Type();
        }

        private void VariableList()
        {
            if (currentLexeme.Type != LexemeType.ID)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "id");

            Next();
            EmptyOrCommaVariableList();
        }

        private void EmptyOrCommaVariableList()
        {
            if (currentLexeme.Type == LexemeType.KEYWORD_As)
                return;

            if (currentLexeme.Type != LexemeType.SEPARATOR_Comma)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, ",");

            Next();
            VariableList();
        }

        private void Type()
        {
            if (currentLexeme.Type != LexemeType.KEYWORD_Integer &&
                currentLexeme.Type != LexemeType.KEYWORD_Double &&
                currentLexeme.Type != LexemeType.KEYWORD_String)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "integer", "double", "string");

            Next();
        }

        private void Assignment()
        {
            if (currentLexeme.Type != LexemeType.ID)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "id");

            Next();

            if (currentLexeme.Type != LexemeType.SEPARATOR_Equals)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "=");

            Next();
            Operand();
            EmptyOrSignOperand();
        }

        private void Operand()
        {
            if (currentLexeme.Type != LexemeType.ID &&
                currentLexeme.Type != LexemeType.LITERAL)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "id", "lit");

            Next();
        }

        private void EmptyOrSignOperand()
        {
            if (currentLexeme.Type == LexemeType.SEPARATOR_LineBreak ||
                currentLexeme.Type == LexemeType.END)
                return;

            Sign();
            Operand();
        }

        private void Sign()
        {
            if (currentLexeme.Type != LexemeType.SEPARATOR_Plus &&
                currentLexeme.Type != LexemeType.SEPARATOR_Minus &&
                currentLexeme.Type != LexemeType.SEPARATOR_Multiply &&
                currentLexeme.Type != LexemeType.SEPARATOR_Split)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "+", "-", "*", "/");

            Next();
        }

        private void Cycle()
        {
            if (currentLexeme.Type != LexemeType.KEYWORD_Do)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "do");

            Next();

            if (currentLexeme.Type != LexemeType.KEYWORD_While)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "while");

            Next();
            Expression();

            if (currentLexeme.Type != LexemeType.SEPARATOR_LineBreak)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "\\n");

            Next();
            OperatorList();

            if (currentLexeme.Type != LexemeType.SEPARATOR_LineBreak)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "\\n");

            Next();

            if (currentLexeme.Type != LexemeType.KEYWORD_Loop)
                throw new SyntaxException(currentLexemeIndex, currentLexeme.Value, "loop");

            Next();
        }

        private void Expression()
        {
            while (true)//currentLexeme.Type != LexemeType.SEPARATOR_LineBreak)
            {
                if (IsExprOperand())
                {
                    exprOperands.Push(currentLexeme);
                    Next();
                }
                else if (IsExprSeparator())
                {
                    var peek = exprSeparators.Count > 0 ? exprSeparators.Peek() : null;

                    if (peek == null)
                    {
                        if (currentLexeme.Type == LexemeType.SEPARATOR_LineBreak)
                        {
                            D6();
                            break;
                        }
                        else if (currentLexeme.Type == LexemeType.SEPARATOR_LBracket)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Less ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Greater ||
                            currentLexeme.Type == LexemeType.SEPARATOR_DoubleEquals)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Plus ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Minus ||
                            currentLexeme.Type == LexemeType.KEYWORD_Or)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Multiply ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Split ||
                            currentLexeme.Type == LexemeType.KEYWORD_And)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_RBracket)
                        {
                            D5();
                        }
                    }
                    else if (peek.Type == LexemeType.SEPARATOR_LBracket)
                    {
                        if (currentLexeme.Type == LexemeType.SEPARATOR_LineBreak)
                        {
                            D5();
                        }
                        else if (currentLexeme.Type == LexemeType.SEPARATOR_LBracket)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Less ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Greater ||
                            currentLexeme.Type == LexemeType.SEPARATOR_DoubleEquals)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Plus ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Minus ||
                            currentLexeme.Type == LexemeType.KEYWORD_Or)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Multiply ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Split ||
                            currentLexeme.Type == LexemeType.KEYWORD_And)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_RBracket)
                        {
                            D3();
                        }
                    }
                    else if (
                        peek.Type == LexemeType.SEPARATOR_Less ||
                        peek.Type == LexemeType.SEPARATOR_Greater ||
                        peek.Type == LexemeType.SEPARATOR_DoubleEquals)
                    {
                        if (currentLexeme.Type == LexemeType.SEPARATOR_LineBreak)
                        {
                            D4();
                        }
                        else if (currentLexeme.Type == LexemeType.SEPARATOR_LBracket)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Less ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Greater ||
                            currentLexeme.Type == LexemeType.SEPARATOR_DoubleEquals)
                        {
                            D2();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Plus ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Minus ||
                            currentLexeme.Type == LexemeType.KEYWORD_Or)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Multiply ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Split ||
                            currentLexeme.Type == LexemeType.KEYWORD_And)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_RBracket)
                        {
                            D4();
                        }
                    }
                    else if (
                        peek.Type == LexemeType.SEPARATOR_Plus ||
                        peek.Type == LexemeType.SEPARATOR_Minus ||
                        peek.Type == LexemeType.KEYWORD_Or)
                    {
                        if (currentLexeme.Type == LexemeType.SEPARATOR_LineBreak)
                        {
                            D4();
                        }
                        else if (currentLexeme.Type == LexemeType.SEPARATOR_LBracket)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Less ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Greater ||
                            currentLexeme.Type == LexemeType.SEPARATOR_DoubleEquals)
                        {
                            D4();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Plus ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Minus ||
                            currentLexeme.Type == LexemeType.KEYWORD_Or)
                        {
                            D2();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Multiply ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Split ||
                            currentLexeme.Type == LexemeType.KEYWORD_And)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_RBracket)
                        {
                            D4();
                        }
                    }
                    else if (
                        peek.Type == LexemeType.SEPARATOR_Multiply ||
                        peek.Type == LexemeType.SEPARATOR_Split ||
                        peek.Type == LexemeType.KEYWORD_And)
                    {
                        if (currentLexeme.Type == LexemeType.SEPARATOR_LineBreak)
                        {
                            D4();
                        }
                        else if (currentLexeme.Type == LexemeType.SEPARATOR_LBracket)
                        {
                            D1();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Less ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Greater ||
                            currentLexeme.Type == LexemeType.SEPARATOR_DoubleEquals)
                        {
                            D4();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Plus ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Minus ||
                            currentLexeme.Type == LexemeType.KEYWORD_Or)
                        {
                            D4();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_Multiply ||
                            currentLexeme.Type == LexemeType.SEPARATOR_Split ||
                            currentLexeme.Type == LexemeType.KEYWORD_And)
                        {
                            D2();
                        }
                        else if (
                            currentLexeme.Type == LexemeType.SEPARATOR_RBracket)
                        {
                            D4();
                        }
                    }
                }
                else
                {
                    throw new SyntaxException("Ошибка разбора выражения");
                }
            }

            exprSeparators.Clear();
            exprOperands.Clear();
            exprCounter++;
        }

        private bool IsExprOperand()
        {
            return
                currentLexeme.Type == LexemeType.ID ||
                currentLexeme.Type == LexemeType.LITERAL;
        }

        private bool IsExprSeparator()
        {
            return
                currentLexeme.Type == LexemeType.SEPARATOR_LineBreak ||
                currentLexeme.Type == LexemeType.SEPARATOR_LBracket ||
                currentLexeme.Type == LexemeType.SEPARATOR_Greater ||
                currentLexeme.Type == LexemeType.SEPARATOR_Less ||
                currentLexeme.Type == LexemeType.SEPARATOR_DoubleEquals ||
                currentLexeme.Type == LexemeType.SEPARATOR_Plus ||
                currentLexeme.Type == LexemeType.SEPARATOR_Minus ||
                currentLexeme.Type == LexemeType.SEPARATOR_Multiply ||
                currentLexeme.Type == LexemeType.SEPARATOR_Split ||
                currentLexeme.Type == LexemeType.KEYWORD_And ||
                currentLexeme.Type == LexemeType.KEYWORD_Or ||
                currentLexeme.Type == LexemeType.SEPARATOR_RBracket;
        }

        private void D1()
        {
            exprSeparators.Push(currentLexeme);
            Next();
        }

        private void D2()
        {
            if (exprSeparators.Count == 0)
                throw new SyntaxException("Ошибка разбора выражения");

            var separator = exprSeparators.Pop();

            K(separator);
            exprSeparators.Push(currentLexeme);

            Next();
        }

        private void D3()
        {
            if (exprSeparators.Count == 0)
                throw new SyntaxException("Ошибка разбора выражения");

            exprSeparators.Pop();
            Next();
        }

        private void D4()
        {
            if (exprSeparators.Count == 0)
                throw new SyntaxException("Ошибка разбора выражения");

            var op = exprSeparators.Pop();
            K(op);
        }

        private void D5()
        {
            throw new SyntaxException("Ошибка разбора выражения");
        }

        private void D6()
        {
            //Успешное завершение
        }

        private void K(LexemeToken operation)
        {
            if (exprOperands.Count < 2)
                throw new SyntaxException("Ошибка разбора выражения");

            LexemeToken operator1 = exprOperands.Pop();
            LexemeToken operator2 = exprOperands.Pop();
            LexemeToken result = new LexemeToken($"Op{operations.Count + 1} (Expr{exprCounter})", LexemeType.ID);

            exprOperands.Push(result);
            operations.Add(new OperationInfo(operation, operator1, operator2, result));
        }
    }
}