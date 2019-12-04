using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Impl.Extensions
{
    public enum CIEqualsOption : short
    {
        Normal,
        NullEqualsEmpty
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Case-Insensitive Equals. Returns true if the two strings are equal (regardless of case).
        /// </summary>
        public static bool CIEquals(this string first, string second, CIEqualsOption option = CIEqualsOption.Normal)
        {
            if (option == CIEqualsOption.NullEqualsEmpty)
                return String.Equals(first ?? "", second ?? "", StringComparison.InvariantCultureIgnoreCase);
            else
                return String.Equals(first, second, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
