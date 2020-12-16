using System;

namespace PhnTnTi.Common.Expression
{
    public class EvaluationException : ExpressionException
    {
        public EvaluationException(string message)
        : base(message)
        {
        }

        public EvaluationException(string message, Exception cause)
        : base(message, cause)
        {
        }

        public EvaluationException(int position, string message)
        : base(position, message)
        {
        }

        public EvaluationException(string expressionstring, string message)
        : base(expressionstring, message)
        {
        }

        public EvaluationException(int position, string message, Exception cause)
        : base(position, message, cause)
        {
        }
    }
}
