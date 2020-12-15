using Microsoft.Extensions.Configuration;
using System;

namespace PhnTnTi.Common.Options
{
    public abstract class AbstractOptions
    {
        // This constructor is for use with IOptions
        protected AbstractOptions()
        {
        }

        protected AbstractOptions(IConfiguration root, string sectionPrefix = null)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (!string.IsNullOrEmpty(sectionPrefix))
            {
                var section = root.GetSection(sectionPrefix);
                section.Bind(this);
            }
            else
            {
                root.Bind(this);
            }
        }
    }
}
