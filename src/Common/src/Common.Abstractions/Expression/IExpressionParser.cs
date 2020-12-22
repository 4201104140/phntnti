namespace PhnTnTi.Common.Expression
{
    /// <summary>
    /// Parses expression strings into compiled expressions that can be evaluated.
    /// Supports parsing templates as well as standard expression strings.
    /// TODO:  This interface is not complete
    /// </summary>
    public interface IExpressionParser
    {
        IExpression ParseExpression(string expressionString);

        IExpression ParseExpression(string expressionString, IParserContext context);
    }
}
