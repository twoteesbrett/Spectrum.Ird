using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectrum.Ird
{
    /// <summary>
    /// Validates New Zealand Inland Revenue Department (IRD) numbers.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Validates IRD numbers according to the "Resident Withholding Tax (RWT)
    /// and Non-Resident Withholding Tax (NRWT)" specification published by the New Zealand
    /// Inland Revenue Department (IRD).
    /// </para>
    /// <para>
    /// The specification used in this implementation is
    /// <a href="https://www.ird.govt.nz/-/media/project/ir/documents/income-tax/withholding-taxes/rwt-nrwt-withholding-tax-certificate/2020-rwt-and-nrwt-certificate-filing-specification.pdf">here</a>.
    /// </para>
    /// </remarks>
    public class IrdNumber
    {
        private const long LowerLimit = 10000000;
        private const long UpperLimit = 150000000;

        private static readonly int[] PrimaryWeightings = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] SecondaryWeightings = new int[] { 7, 4, 3, 2, 5, 2, 7, 6 };

        /// <summary>
        /// Gets the IRD number of the instance.
        /// </summary>
        public long Value { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="IrdNumber"/> class
        /// to the specified value.
        /// </summary>
        /// <param name="irdNumber">A number that represents an IRD number.</param>
        public IrdNumber(long irdNumber)
        {
            Value = irdNumber;
        }

        /// <summary>
        /// Indicates whether the IRD number of the instance is valid.
        /// </summary>
        /// <returns><see langword="true"/> if the IRD number is valid, otherwise <see langword="false"/>.</returns>
        /// <example>
        /// The following example validates the IRD number of the instance using the method <see cref="IsValid()"/>.
        /// <code>
        /// var irdNumber = new IrdNumber(49091850);
        /// var isValid = irdNumber.IsValid();
        /// </code>
        /// </example>
        public bool IsValid()
        {
            if (Value < LowerLimit || Value > UpperLimit)
            {
                return false;
            }

            var irdNumber = Value.ToString("000000000").ToNumericValues();
            var baseNumber = irdNumber.Take(irdNumber.Length - 1).ToArray();
            var checkDigit = irdNumber.Last();

            var primary = GetCheckDigit(baseNumber, PrimaryWeightings);

            if (primary >= 0 && primary <= 9)
            {
                return primary == checkDigit;
            }

            var secondary = GetCheckDigit(baseNumber, SecondaryWeightings);

            if (secondary >= 0 && secondary <= 9)
            {
                return secondary == checkDigit;
            }

            return false;
        }

        private int GetCheckDigit(int[] baseNumber, int[] weightings)
        {
            var products = 0;

            for (int i = 0; i < weightings.Length; i++)
            {
                products += baseNumber[i] * weightings[i];
            }

            var remainder = products % 11;

            return remainder == 0 ? 0 : 11 - remainder;
        }
    }
}
