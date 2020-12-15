using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhnTnTi.Common.Converter
{
    public abstract class AbstractConverter<S, T> : AbstractGenericConditionalConverter, IConverter<S, T>
    {
        protected AbstractConverter()
            : base(new HashSet<(Type Source, Type Target)>() { (typeof(S), typeof(T)) })
        {
        }

        public override bool Matches(Type sourceType, Type targetType)
        {
            if (typeof(T) != targetType)
            {
                return false;
            }

            return true;
        }

        public abstract T Convert(S source);

        public override object Convert(object source, Type sourceType, Type targetType)
        {
            if (source == null)
            {
                return null;
            }

            if (!typeof(S).IsAssignableFrom(source.GetType()))
            {
                throw new ArgumentException("'source' type invalid");
            }

            return Convert((S)source);
        }
    }
}
