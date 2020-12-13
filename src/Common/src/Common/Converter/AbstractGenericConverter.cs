using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Converter
{
    public abstract class AbstractGenericConverter : IGenericConverter
    {
        protected AbstractGenericConverter(ISet<(Type Source, Type Target)> convertableTypes)
        {
            ConvertibleTypes = convertableTypes;
        }

        public ISet<(Type Source, Type Target)> ConvertibleTypes { get; }

        public abstract object Convert(object source, Type sourceType, Type targetType);
    }
}
