﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.SignCheck
{
    public class Utils
    {
        /// <summary>
        /// Generate a hash for a string value using a given hash algorithm.
        /// </summary>
        /// <param name="value">The value to hash.</param>
        /// <param name="hashName">The name of the <see cref="HashAlgorithm"/> to use.</param>
        /// <returns>A string containing the hash result.</returns>
        public static string GetHash(string value, string hashName)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var ha = HashAlgorithm.Create(hashName);
            var hash = ha.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            var hashString = sb.ToString();

            return hashString;
        }

        public static string ConvertToRegexPattern(string pattern)
        {
            string escapedPattern = Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", ".");

            if ((pattern.EndsWith("*")) || (pattern.EndsWith("?")))
            {
                return escapedPattern;
            }
            else
            {
                return String.Concat(escapedPattern, "$");
            }            
        }
    }
}
