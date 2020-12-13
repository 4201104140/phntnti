namespace PhnTnTi.Common.Converter
{
    /// <summary>
    /// A generic converter that may conditionally execute based on the source type and
    /// target types.
    /// </summary>
    public interface IConditionalGenericConverter : IConditionalConverter, IGenericConverter
    {
    }
}
