using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhnTnTi.Common.Converter
{
    public abstract class AbstractConverter<S, T> : AbstractGenericConditionalConverter, IConvert
    {
    }
}
