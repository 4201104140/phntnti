using System;

namespace PhnTnTi.Common.Converter
{
    /// <summary>
    ///  Allows a converter to conditionally execute based on the types of the source and target
    /// </summary>
    public interface IConditionalConverter
    {
        /// <summary>
        /// Can the conversion from source type to target type be performed by this converter
        /// </summary>
        /// <param name="sourceType">the type of the source object to convert from</param>
        /// <param name="targetType">the type of the target object to conver to</param>
        /// <returns>true if the conversion can be performed</returns>
        bool Matches(Type sourceType, Type targetType);
    }
}
