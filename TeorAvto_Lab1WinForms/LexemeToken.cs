using System.Collections.Generic;

namespace TeorAvto_Lab
{
    public class LexemeToken
    {
        private Dictionary<string, LexemeType> dictionary = new Dictionary<string, LexemeType>()
        {
            { "Dim", LexemeType.KEYWORD_Dim },
            { "as", LexemeType.KEYWORD_As },
            { "integer", LexemeType.KEYWORD_Integer },
            { "double", LexemeType.KEYWORD_Double },
            { "string", LexemeType.KEYWORD_String },
            { "do", LexemeType.KEYWORD_Do },
            { "while", LexemeType.KEYWORD_While },
            { "And", LexemeType.KEYWORD_And },
            { "Or", LexemeType.KEYWORD_Or },
            { "loop", LexemeType.KEYWORD_Loop },
            { "=", LexemeType.SEPARATOR_Equals },
            { "==", LexemeType.SEPARATOR_DoubleEquals },
            { "(", LexemeType.SEPARATOR_LBracket },
            { ")", LexemeType.SEPARATOR_RBracket },
            { "<", LexemeType.SEPARATOR_Less },
            { ">", LexemeType.SEPARATOR_Greater },
            { "+", LexemeType.SEPARATOR_Plus },
            { "-", LexemeType.SEPARATOR_Minus },
            { "*", LexemeType.SEPARATOR_Multiply },
            { "/", LexemeType.SEPARATOR_Split },
            { "\\n", LexemeType.SEPARATOR_LineBreak },
            { ",", LexemeType.SEPARATOR_Comma }
        };

        public LexemeType Type { get; private set; }
        public string Value { get; private set; }

        public LexemeToken(string value, LexemeType lexemeType)
        {
            Value = value;
            Type = dictionary.ContainsKey(value) ? dictionary[value] : lexemeType;
        }
    }
}
