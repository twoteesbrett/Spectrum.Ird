using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Spectrum.Ird
{
    /// <summary>
    /// Extension methods for the <see cref="IrdNumber"/> and
    /// <see cref="NZBankAccount"/> classes.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Indicates whether the specified IRD number is valid.
        /// </summary>
        /// <param name="irdNumber"></param>
        /// <returns><see langword="true"/> if the IRD number is valid, otherwise <see langword="false"/>.</returns>
        /// <example>
        /// The following example validates the specified IRD number using the method <see cref="IsValidIrdNumber(long)"/>.
        /// <code>
        /// var irdNumber = 49091850;
        /// var isValid = irdNumber.IsValidIrdNumber();
        /// </code>
        /// </example>
        public static bool IsValidIrdNumber(this long irdNumber)
            => new IrdNumber(irdNumber).IsValid();

        /// <summary>
        /// Indicates whether the specified bank account number is valid.
        /// </summary>
        /// <param name="accountNumber">The string containing an account number to convert, in
        /// an accepted format.</param>
        /// <returns><see langword="true"/> if the bank account number is valid, otherwise <see langword="false"/>.</returns>
        /// <remarks>
        /// <para>The accepted formats are:
        /// <list type="bullet">
        /// <item>XX XXXX XXXXXXX XX(X)</item>
        /// <item>XX-XXXX-XXXXXXX-XX(X)</item>
        /// <item>XX.XXXX.XXXXXXX.XX(X)</item>
        /// </list>
        /// where X represents a digit. The groupings represent the bank, branch, account base and suffix,
        /// respectively. The suffix can be either 2 or 3 digits.
        /// </para>
        /// </remarks>
        /// <example>
        /// The following example validates a bank account number using the method <see cref="IsValidNZBankAccount(string)"/>.
        /// <code>
        /// var account = "26-2600-0320871-32";
        /// var isValid = account.IsValidNZBankAccount();
        /// </code>
        /// </example>
        public static bool IsValidNZBankAccount(this string accountNumber)
        {
            var account = NZBankAccount.Parse(accountNumber);

            return account?.IsValid() ?? false;
        }
    }
}
