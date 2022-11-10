using System.Collections.Generic;

namespace TeorAvto_Lab
{
    public class LexemToken
    {
        private Dictionary<string, LexemeType> dictionary = new Dictionary<string, LexemeType>()
        {
            { "Dim", LexemeType.KEYWORD_Dim },
            { "as", LexemeType.KEYWORD_As },
            { "integer", LexemeType.KEYWORD_Integer },
            { "do", LexemeType.KEYWORD_Do },
            { "while", LexemeType.KEYWORD_While },
            { "or", LexemeType.KEYWORD_Or },
            { "loop", LexemeType.KEYWORD_Loop },

            { "=", LexemeType.SEPARATOR_Equals },
            { "(", LexemeType.SEPARATOR_LBracket },
            { ")", LexemeType.SEPARATOR_RBracket },
            { "<", LexemeType.SEPARATOR_Less },
            { ">", LexemeType.SEPARATOR_Greater },
            { "+", LexemeType.SEPARATOR_Plus },
            { "\\n", LexemeType.SEPARATOR_LineBreak }
        };

        public LexemeType LexemeType { get; private set; }
        public string Value { get; private set; }

        public LexemToken(string value, LexemeType lexemeType)
        {
            Value = value;
            LexemeType = dictionary.ContainsKey(value) ? dictionary[value] : lexemeType;
        }
    }
}
