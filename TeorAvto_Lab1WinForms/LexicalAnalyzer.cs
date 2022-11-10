using System;
using System.Collections.Generic;

namespace TeorAvto_Lab
{
    public class LexicalAnalyzer
    {
        public enum SymbolType
        {
            Letter,
            Digit,
            Separator,
            Space,
            Other
        }

        private readonly List<char> validDelimiterSymbols = new List<char>
        { 
            '+', '-', '*', '/', '=', '<', '>', '(', ')', '\n'
        };

        public readonly List<string> Keywords = new List<string>()
        {
            "Dim", "as", "integer", "do", "while", "or", "loop"
        };

        public readonly List<string> Separators = new List<string>()
        {
            "=", "(", "<", ">", ")", "+", "<=", ">=", "\\n"
        };

        public List<string> Identifiers { get; private set; } = new List<string>();
        public List<string> Literals { get; private set; } = new List<string>();

        public List<LexemToken> Analyze(string text)
        {
            List<Tuple<string, LexemeType>> result = PrimaryAnalyze(text);
            return FinalClassify(result);
        }

        private List<Tuple<string, LexemeType>> PrimaryAnalyze(string text)
        {
            List<Tuple<string, LexemeType>> lexemes = new List<Tuple<string, LexemeType>>();

            string buffer = "";
            LexemeType followLexemeType = LexemeType.SEPARATOR;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (followLexemeType == LexemeType.ID && buffer.Length > 8)
                {
                    throw new Exception("Длина идентификатора превысила 8 символов");
                }

                switch (GetSymbolType(text[i]))
                {
                    case SymbolType.Letter:

                        if (buffer == "")
                        {
                            followLexemeType = LexemeType.ID;
                            buffer += symbol;
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.ID:
                                buffer += symbol;
                                break;

                            case LexemeType.LITERAL:
                                throw new Exception("Наименование не может начинаться с цифр");

                            case LexemeType.SEPARATOR:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.ID;
                                break;
                        }
                        break;

                    case SymbolType.Digit:

                        if (buffer == "")
                        {
                            followLexemeType = LexemeType.LITERAL;
                            buffer += symbol;
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.ID:
                                buffer += symbol;
                                break;

                            case LexemeType.LITERAL:
                                buffer += symbol;
                                break;

                            case LexemeType.SEPARATOR:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.LITERAL;
                                break;
                        }
                        break;

                    case SymbolType.Separator:

                        if (symbol == '\n')
                        {
                            lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                            lexemes.Add(new Tuple<string, LexemeType>("\\n", LexemeType.SEPARATOR));
                            buffer = "";
                            break;
                        }

                        if (buffer == "")
                        {
                            followLexemeType = LexemeType.SEPARATOR;
                            buffer += symbol;
                            break;
                        }

                        switch (followLexemeType)
                        {

                            case LexemeType.ID:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.SEPARATOR;
                                break;

                            case LexemeType.LITERAL:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.SEPARATOR;
                                break;

                            case LexemeType.SEPARATOR:
                                if (buffer.Length > 1)
                                {
                                    throw new Exception("Длина разделителя не может превышать два символа");
                                }
                                buffer += symbol;
                                followLexemeType = LexemeType.SEPARATOR;
                                break;
                        }
                        break;

                    case SymbolType.Space:

                        if (buffer == "")
                        {
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.ID:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.ID));
                                break;

                            case LexemeType.LITERAL:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.LITERAL));
                                break;

                            case LexemeType.SEPARATOR:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.SEPARATOR));
                                break;
                        }
                        buffer = "";
                        break;

                    case SymbolType.Other:
                        throw new Exception("Недопустимые символы в программе");
                }
            }

            switch (followLexemeType)
            {
                case LexemeType.ID:
                    lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.ID));
                    break;

                case LexemeType.LITERAL:
                    lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.LITERAL));
                    break;

                case LexemeType.SEPARATOR:
                    lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.SEPARATOR));
                    break;
            }

            return lexemes;
        }

        private List<LexemToken> FinalClassify (List<Tuple<string, LexemeType>> lexemes)
        {
            List<LexemToken> result = new List<LexemToken>();

            foreach (var lexeme in lexemes)
            {
                LexemToken token = new LexemToken(lexeme.Item1, lexeme.Item2);
                result.Add(token);

                if (token.LexemeType == LexemeType.ID)
                {
                    if (!Identifiers.Contains(lexeme.Item1))
                        Identifiers.Add(lexeme.Item1);
                }
                else if (token.LexemeType == LexemeType.LITERAL)
                {
                    if (!Literals.Contains(lexeme.Item1))
                        Literals.Add(lexeme.Item1);
                }
            }

            return result;
        }

        private SymbolType GetSymbolType(char symbol)
        {
            if (symbol == ' ')
            {
                return SymbolType.Space;
            }
            else if (char.IsLetter(symbol))
            {
                return SymbolType.Letter;
            }
            else if (char.IsDigit(symbol))
            {
                return SymbolType.Digit;
            }
            else if (validDelimiterSymbols.Contains(symbol))
            {
                return SymbolType.Separator;
            }

            return SymbolType.Other;
        }
    }
}
