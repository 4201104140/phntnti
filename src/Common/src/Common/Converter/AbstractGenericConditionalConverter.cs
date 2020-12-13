using System;
using System.Collections.Generic;

namespace PhnTnTi.Common.Converter
{
    public abstract class AbstractGenericConditionalConverter : AbstractGenericConverter, IConditionalGenericConverter
    {
        protected AbstractGenericConditionalConverter(ISet<(Type Source, Type Target)> convertableTypes)
            : base(convertableTypes)
        {
        }

        public abstract bool Matches(Type sourceType, Type targetType);
    }
}
