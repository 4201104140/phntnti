namespace PhnTnTi.Common.Expression
{
    /// <summary>
    /// Expressions are executed in an evaluation context. It is in this context that
    /// references are resolved when encountered during expression evaluation.
    /// TODO:  This interface is not complete
    /// </summary>
    public interface IEvaluationContext
    {
        ITypeConverter TypeConverter { get; set; }
    }
}
