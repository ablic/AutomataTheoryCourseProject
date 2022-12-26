using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ATFLCourseProject
{
    public class LexicalAnalyzer
    {
        private enum SymbolType
        {
            Letter,
            Digit,
            Separator,
            Space,
            Other
        }

        private ReadOnlyCollection<char> validDelimiterSymbols = new ReadOnlyCollection<char>(new char[] 
        {
            '+', '-', '*', '/', '=', '<', '>', '(', ')', '\n'
        });

        public ReadOnlyCollection<string> Keywords = new ReadOnlyCollection<string>(new string[]
        {
             "Dim", "as", "integer", "double", "string", "do", "while", "And", "Or", "loop"
        });

        public ReadOnlyCollection<string> Separators = new ReadOnlyCollection<string>(new string[]
        {
             "=", "(", "<", ">", ")", "+", "-", "*", "/", "<=", ">=", "\\n"
        });

        public List<string> Identifiers { get; private set; } = new List<string>();
        public List<string> Literals { get; private set; } = new List<string>();

        private List<Tuple<string, LexemeType>> tempLexemes = new List<Tuple<string, LexemeType>>();

        public void AnalyzeLine(string line)
        {
            StringBuilder buffer = new StringBuilder();
            LexemeType followLexemeType = LexemeType.SEPARATOR;

            if (line.Length == 0)
                return;

            for (int j = 0; j < line.Length; j++)
            {
                char symbol = line[j];

                switch (GetSymbolType(symbol))
                {
                    case SymbolType.Letter:

                        if (buffer.Length == 0)
                        {
                            followLexemeType = LexemeType.ID;
                            buffer.Append(symbol);
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.ID:
                                buffer.Append(symbol);
                                if (buffer.Length > 8)
                                    throw new Exception("Длина идентификатора превысила 8 символов");
                                break;

                            case LexemeType.LITERAL:
                                throw new Exception("Наименование не может начинаться с цифр");

                            case LexemeType.SEPARATOR:
                                tempLexemes.Add(new Tuple<string, LexemeType>(buffer.ToString(), followLexemeType));
                                buffer.Clear();
                                buffer.Append(symbol);
                                followLexemeType = LexemeType.ID;
                                break;
                        }

                        break;

                    case SymbolType.Digit:

                        if (buffer.Length == 0)
                        {
                            followLexemeType = LexemeType.LITERAL;
                            buffer.Append(symbol);
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.ID:
                                buffer.Append(symbol);
                                if (buffer.Length > 8)
                                    throw new Exception("Длина идентификатора превысила 8 символов");
                                break;

                            case LexemeType.LITERAL:
                                buffer.Append(symbol);
                                break;

                            case LexemeType.SEPARATOR:
                                tempLexemes.Add(new Tuple<string, LexemeType>(buffer.ToString(), followLexemeType));
                                buffer.Clear();
                                buffer.Append(symbol);
                                followLexemeType = LexemeType.LITERAL;
                                break;
                        }
                        break;

                    case SymbolType.Separator:

                        if (buffer.Length == 0)
                        {
                            followLexemeType = LexemeType.SEPARATOR;
                            buffer.Append(symbol);
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.ID:
                                tempLexemes.Add(new Tuple<string, LexemeType>(buffer.ToString(), followLexemeType));
                                buffer.Clear();
                                buffer.Append(symbol);
                                followLexemeType = LexemeType.SEPARATOR;
                                break;

                            case LexemeType.LITERAL:
                                tempLexemes.Add(new Tuple<string, LexemeType>(buffer.ToString(), followLexemeType));
                                buffer.Clear();
                                buffer.Append(symbol);
                                followLexemeType = LexemeType.SEPARATOR;
                                break;

                            case LexemeType.SEPARATOR:
                                if (buffer.Length > 1)
                                    throw new Exception("Длина разделителя не может превышать два символа");

                                buffer.Append(symbol);
                                followLexemeType = LexemeType.SEPARATOR;
                                break;
                        }
                        break;

                    case SymbolType.Space:

                        if (buffer.Length == 0)
                            break;

                        tempLexemes.Add(new Tuple<string, LexemeType>(buffer.ToString(), followLexemeType));
                        buffer.Clear();
                        break;

                    case SymbolType.Other:
                        throw new Exception("Недопустимые символы в программе");
                }
            }

            if (buffer.Length > 0)
            {
                tempLexemes.Add(new Tuple<string, LexemeType>(buffer.ToString(), followLexemeType));
                buffer.Clear();
            }

            tempLexemes.Add(new Tuple<string, LexemeType>("\\n", LexemeType.SEPARATOR));
        }

        public List<LexemeToken> GetLexemes()
        {
            List<LexemeToken> result = new List<LexemeToken>();

            foreach (var lexeme in tempLexemes)
            {
                LexemeToken token = new LexemeToken(lexeme.Item1, lexeme.Item2);
                result.Add(token);

                if (token.Type == LexemeType.ID)
                {
                    if (!Identifiers.Contains(lexeme.Item1))
                        Identifiers.Add(lexeme.Item1);
                }
                else if (token.Type == LexemeType.LITERAL)
                {
                    if (!Literals.Contains(lexeme.Item1))
                        Literals.Add(lexeme.Item1);
                }
            }

            result.Add(new LexemeToken("", LexemeType.END));
            tempLexemes.Clear();
            return result;
        }

        private SymbolType GetSymbolType(char symbol)
        {
            if (symbol == ' ')
                return SymbolType.Space;

            else if (char.IsLetter(symbol))
                return SymbolType.Letter;

            else if (char.IsDigit(symbol))
                return SymbolType.Digit;

            else if (validDelimiterSymbols.Contains(symbol))
                return SymbolType.Separator;

            return SymbolType.Other;
        }
    }
}
