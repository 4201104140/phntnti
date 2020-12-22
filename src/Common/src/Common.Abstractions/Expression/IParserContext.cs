namespace PhnTnTi.Common.Expression
{
    /// <summary>
    /// Context that gets passed along a bean definition parsing process,
    /// encapsulating all relevant configuration as well as state.
    /// TODO:  This interface is not complete
    /// </summary>
    public interface IParserContext
    {
        bool IsTemplate { get; }

        string ExpressionPrefix { get; }

        string ExpressionSuffix { get; }
    }
}
