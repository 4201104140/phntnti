using System;

namespace PhnTnTi.Common.Expression
{
    public class ParseException : ExpressionException
    {
        public ParseException(string expressionString, int position, string message)
           : base(expressionString, position, message)
        {
        }

        public ParseException(int position, string message, Exception cause)
        : base(position, message, cause)
        {
        }

        public ParseException(int position, string message)
        : base(position, message)
        {
        }
    }
}
