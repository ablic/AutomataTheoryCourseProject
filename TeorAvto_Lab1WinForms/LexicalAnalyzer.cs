using System;
using System.Collections.Generic;

namespace TeorAvto_Lab
{
    public class LexicalAnalyzer
    {
        public enum LexemeType
        {
            I,
            L,
            R
        }

        public enum SymbolType
        {
            Letter,
            Digit,
            Separator,
            Space,
            Other
        }

        private List<char> validDelimiters = new List<char>() 
        { 
            '+', '-', '*', '/', '=', '<', '>', '(', ')', '\n'
        };

        public List<Tuple<string, LexemeType>> Analyze(string text)
        {
            List<Tuple<string, LexemeType>> lexemes = new List<Tuple<string, LexemeType>>();

            string buffer = "";
            LexemeType followLexemeType = LexemeType.R;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (followLexemeType == LexemeType.I && buffer.Length > 8)
                {
                    throw new Exception("Длина идентификатора превысила 8 символов");
                }

                switch (GetSymbolType(text[i]))
                {
                    case SymbolType.Letter:

                        if (buffer == "")
                        {
                            followLexemeType = LexemeType.I;
                            buffer += symbol;
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.I:
                                buffer += symbol;
                                break;

                            case LexemeType.L:
                                throw new Exception("Наименование не может начинаться с цифр");

                            case LexemeType.R:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.I;
                                break;
                        }
                        break;

                    case SymbolType.Digit:

                        if (buffer == "")
                        {
                            followLexemeType = LexemeType.L;
                            buffer += symbol;
                            break;
                        }

                        switch (followLexemeType)
                        {
                            case LexemeType.I:
                                buffer += symbol;
                                break;

                            case LexemeType.L:
                                buffer += symbol;
                                break;

                            case LexemeType.R:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.L;
                                break;
                        }
                        break;

                    case SymbolType.Separator:

                        if (symbol == '\n')
                        {
                            lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                            lexemes.Add(new Tuple<string, LexemeType>("\\n", LexemeType.R));
                            buffer = "";
                            break;
                        }

                        if (buffer == "")
                        {
                            followLexemeType = LexemeType.R;
                            buffer += symbol;
                            break;
                        }

                        switch (followLexemeType)
                        {

                            case LexemeType.I:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.R;
                                break;

                            case LexemeType.L:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, followLexemeType));
                                buffer = symbol.ToString();
                                followLexemeType = LexemeType.R;
                                break;

                            case LexemeType.R:
                                if (buffer.Length > 1)
                                {
                                    throw new Exception("Длина разделителя не может превышать два символа");
                                }
                                buffer += symbol;
                                followLexemeType = LexemeType.R;
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
                            case LexemeType.I:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.I));
                                break;

                            case LexemeType.L:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.L));
                                break;

                            case LexemeType.R:
                                lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.R));
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
                case LexemeType.I:
                    lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.I));
                    break;

                case LexemeType.L:
                    lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.L));
                    break;

                case LexemeType.R:
                    lexemes.Add(new Tuple<string, LexemeType>(buffer, LexemeType.R));
                    break;
            }

            return lexemes;
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
            else if (validDelimiters.Contains(symbol))
            {
                return SymbolType.Separator;
            }

            return SymbolType.Other;
        }
    }
}
