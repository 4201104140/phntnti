using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Converter
{
    public abstract class AbstractToCollectionConverter : AbstractGenericConditionalConverter
    {
        protected readonly IConversionService _conversionService;

        protected AbstractToCollectionConverter(IConversionService conversionService)
            : base(null)
        {
            _conversionService = conversionService;
        }

        protected AbstractToCollectionConverter(ISet<(Type Source, Type Target)> convertableTypes, IConversionService conversionService)
            : base(convertableTypes)
        {
            _conversionService = conversionService;
        }
    }
}
