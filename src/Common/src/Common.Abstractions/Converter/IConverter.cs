namespace PhnTnTi.Common.Converter
{
    /// <summary>
    /// A converter converts from a source object of type S to a target object of type T.
    /// </summary>
    /// <typeparam name="S">type of the source object</typeparam>
    /// <typeparam name="T">type of the target object</typeparam>
    public interface IConverter<in S, out T>
    {
        /// <summary>
        /// Convert the source object of type S to a target object of type T.
        /// </summary>
        /// <param name="source">the source object to convert; can not be null</param>
        /// <returns>the converted object which must be type T</returns>
        T Convert(S source);
    }
}
