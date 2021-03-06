﻿using System;
using System.Collections.Generic;
using System.Net;

namespace PhnTnTi.Common.Extensions
{
    public static class UriExtensions
    {
        public static string ToMaskedString(this Uri source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ToMaskedUri().ToString();
        }

        public static Uri ToMaskedUri(this Uri source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrEmpty(source.UserInfo))
            {
                return source;
            }

            var builder = new UriBuilder(source)
            {
                UserName = "****",
#pragma warning disable S2068 // Credentials should not be hard-coded
                Password = "****"
#pragma warning restore S2068 // Credentials should not be hard-coded
            };

            return builder.Uri;
        }

        /// <summary>
        /// Parse a querystring into a dictionary of key value pairs
        /// </summary>
        /// <param name="querystring">The querystring to parse</param>
        /// <returns>Pairs of keys and values</returns>
        public static Dictionary<string, string> ParseQuerystring(string querystring)
        {
            var result = new Dictionary<string, string>();
            foreach (var pair in querystring.Split('&'))
            {
                if (!string.IsNullOrEmpty(pair))
                {
                    var kvp = pair.Split('=');
                    result.Add(WebUtility.UrlDecode(kvp[0]), WebUtility.UrlDecode(kvp[1]));
                }
            }

            return result;
        }
    }
}
