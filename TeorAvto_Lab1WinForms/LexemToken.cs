using System.Collections.Generic;

namespace TeorAvto_Lab
{
    public class LexemToken
    {
        public enum Type
        {
            ID,
            LITERAL,

            KEYWORD_Dim,
            KEYWORD_As,
            KEYWORD_Integer,
            KEYWORD_Do,
            KEYWORD_While,
            KEYWORD_Or,
            KEYWORD_Loop,

            SEPARATOR_Equals,
            SEPARATOR_LBracket,
            SEPARATOR_RBracket,
            SEPARATOR_Less,
            SEPARATOR_Greater,
            SEPARATOR_Plus,
            SEPARATOR_LineBreak
        }

        private Dictionary<string, Type> dictionary = new Dictionary<string, Type>()
        {
            { "Dim", Type.KEYWORD_Dim },
            { "as", Type.KEYWORD_As },
            { "integer", Type.KEYWORD_Integer },
            { "do", Type.KEYWORD_Do },
            { "while", Type.KEYWORD_While },
            { "or", Type.KEYWORD_Or },
            { "loop", Type.KEYWORD_Loop },

            { "=", Type.SEPARATOR_Equals },
            { "(", Type.SEPARATOR_LBracket },
            { ")", Type.SEPARATOR_RBracket },
            { "<", Type.SEPARATOR_Less },
            { ">", Type.SEPARATOR_Greater },
            { "+", Type.SEPARATOR_Plus },
            { "\\n", Type.SEPARATOR_LineBreak }
        };

        private List<string> keywords = new List<string>()
        {
            "Dim", "as", "integer", "do", "while", "or", "loop"
        };

        private List<string> separators = new List<string>()
        {
            "=", "(", "<", ">", ")", "+"
        };

        public Type LexemType { get; private set; }
        public string Value { get; private set; }

        public LexemToken(string value, LexicalAnalyzer.LexemeType lexemeType)
        {
            Value = value;

            if (dictionary.ContainsKey(value))
            {
                LexemType = dictionary[value];
            }
            else
            {
                switch (lexemeType)
                {
                    case LexicalAnalyzer.LexemeType.I: LexemType = Type.ID; break;
                    case LexicalAnalyzer.LexemeType.L: LexemType = Type.LITERAL; break;
                }
            }
        }
    }
}
