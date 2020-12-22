using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PhnTnTi.Extensions.Configuration
{
    [Serializable]
    [TypeConverter(typeof(CredentialConverter))]
    public class Credential : Dictionary<string, Credential>
    {
        public Credential()
        {
        }

        public Credential(string value)
        {
            Value = value;
        }

        public string Value { get; }

        protected Credential(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
