using System;
using System.Collections.Generic;

namespace TeorAvto_Lab
{
    public class LexemClassifier
    {
        public List<string> Keywords { get; private set; } = new List<string>()
        {
            "Dim", "as", "integer", "do", "while", "or", "loop"
        };

        public List<string> Separators { get; private set; } = new List<string>()
        {
            "=", "(", "<", ">", ")", "+", "\\n"
        };

        public List<string> Identifiers { get; private set; } = new List<string>();
        public List<string> Literals { get; private set; } = new List<string>();

        public List<Tuple<string, int>> Classify(List<Tuple<string, LexicalAnalyzer.LexemeType>> lexemes)
        {
            List<string> identifiers = new List<string>();
            List<string> literals = new List<string>();

            List<Tuple<string, int>> result = new List<Tuple<string, int>>();

            foreach (var lexem in lexemes)
            {
                string lexemStr = lexem.Item1;
                LexicalAnalyzer.LexemeType lexemType = lexem.Item2;

                switch (lexemType)
                {
                    case LexicalAnalyzer.LexemeType.I:
                        if (Keywords.Contains(lexemStr))
                        {
                            result.Add(new Tuple<string, int>("Ключевое слово", Keywords.IndexOf(lexemStr)));
                        }
                        else
                        {
                            if (!identifiers.Contains(lexemStr))
                            {
                                identifiers.Add(lexemStr);
                            }

                            result.Add(new Tuple<string, int>("Идентификатор", identifiers.IndexOf(lexemStr)));
                        }

                        break;

                    case LexicalAnalyzer.LexemeType.L:
                        if (!literals.Contains(lexemStr))
                        {
                            literals.Add(lexemStr);
                        }

                        result.Add(new Tuple<string, int>("Литерал", literals.IndexOf(lexemStr)));
                        break;

                    case LexicalAnalyzer.LexemeType.R:
                        if (Separators.Contains(lexemStr))
                        {
                            result.Add(new Tuple<string, int>("Разделитель", Separators.IndexOf(lexemStr)));
                        }
                        break;
                }
            }

            return result;
        }

        public List<LexemToken> Classify1(List<Tuple<string, LexicalAnalyzer.LexemeType>> lexemes)
        {
            List<LexemToken> result = new List<LexemToken>();

            foreach (var lexeme in lexemes)
            {
                LexemToken token = new LexemToken(lexeme.Item1, lexeme.Item2);
                result.Add(token);

                if (token.LexemType == LexemToken.Type.ID)
                {
                    if (!Identifiers.Contains(lexeme.Item1))
                        Identifiers.Add(lexeme.Item1);
                }
                else if (token.LexemType == LexemToken.Type.LITERAL)
                {
                    if (!Literals.Contains(lexeme.Item1))
                        Literals.Add(lexeme.Item1);
                }
            }

            return result;
        }
    }
}
