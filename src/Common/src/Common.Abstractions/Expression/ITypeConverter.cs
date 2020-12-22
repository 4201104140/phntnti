using PhnTnTi.Common.Converter;
using System;

namespace PhnTnTi.Common.Expression
{
    /// <summary>
    /// A type converter can convert values between different types encountered during expression
    /// evaluation.
    /// TODO:  This interface is not complete
    /// </summary>
    public interface ITypeConverter
    {
        public IConversionService ConversionService { get; set; }

        bool CanConvert(Type source, Type target);

        object ConvertValue(object value, Type source, Type target);
    }
}
