using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectrum.Ird
{
    internal static class StringExtensions
    {
        internal static int[] ToNumericValues(this string value)
        { 
            var values = value
                .ToCharArray()
                .Select(v => Convert.ToInt32(char.GetNumericValue(v)))
                .ToArray();

            if (values.Any(v => v < 0))
            {
                throw new InvalidOperationException("A character could not be converted to a numeric value.");
            }

            return values;
        }
    }
}
