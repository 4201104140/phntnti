using System;
using System.Collections.Generic;
using System.Text;

namespace PhnTnTi.Common.Attributes
{
    /// <summary>
    /// This abstract attribute can be used to quickly identify assemblies containing desired types
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public abstract class AssemblyContainsTypeAttribute : Attribute
    {
        public Type ContainedType { get; private set; }

        protected AssemblyContainsTypeAttribute(Type type)
        {
            ContainedType = type;
        }
    }
}
