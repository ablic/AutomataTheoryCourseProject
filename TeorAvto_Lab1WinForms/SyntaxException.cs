using System;

namespace TeorAvto_Lab
{
    class SyntaxException : Exception
    {
        private int receivedIndex = -1;
        private string received;
        private string[] expected;

        public override string Message
        {
            get
            {
                if (receivedIndex == -1)
                    return received;

                string result = "";
                string expectedList = expected[0];

                for (int i = 1; i < expected.Length; i++)
                    expectedList += " или " + expected[i];

                result += $"{(received == "" ? "О" : $"Получено: [{received}], о")}жидалось: [{expectedList}] (index: {receivedIndex})";
                return result;
            }
        }

        public SyntaxException(string message)
        {
            received = message;
        }

        public SyntaxException(int receivedIndex, string received, params string[] expected)
        {
            this.receivedIndex = receivedIndex;
            this.received = received;
            this.expected = expected;
        }
    }
}
