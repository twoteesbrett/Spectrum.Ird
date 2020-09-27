using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Spectrum.Ird
{
    /// <summary>
    /// Validates New Zealand bank account numbers.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Validates bank account numbers according to the "Resident Withholding Tax (RWT)
    /// and Non-Resident Withholding Tax (NRWT)" specification published by the New Zealand
    /// Inland Revenue Department (IRD).
    /// </para>
    /// <para>
    /// The specification used in this implementation is
    /// <a href="https://www.ird.govt.nz/-/media/project/ir/documents/income-tax/withholding-taxes/rwt-nrwt-withholding-tax-certificate/2020-rwt-and-nrwt-certificate-filing-specification.pdf">here</a>.
    /// </para>
    /// </remarks>
    public partial class NZBankAccount
    {
        private static readonly Regex AccountNumberRegex = new Regex(@"^(\d{2})[ -\.](\d{4})[ -\.](\d{7})[ -\.](\d{2,3})$");

        private readonly int[] _accountNumber;

        /// <summary>
        /// Gets the bank ID of the instance.
        /// </summary>
        public int Bank { get; }

        /// <summary>
        /// Gets the bank branch of the instance.
        /// </summary>
        public int Branch { get; }

        /// <summary>
        /// Gets the account base number of the instance.
        /// </summary>
        public int AccountBase { get; }

        /// <summary>
        /// Gets the account suffix of the instance.
        /// </summary>
        public int Suffix { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="NZBankAccount"/> class
        /// to the specified bank, branch, account base and suffix.
        /// </summary>
        /// <param name="bank">The bank ID.</param>
        /// <param name="branch">The bank branch.</param>
        /// <param name="accountBase">The account base number.</param>
        /// <param name="suffix">The account suffix.</param>
        public NZBankAccount(int bank, int branch, int accountBase, int suffix)
        {
            Bank = bank;
            Branch = branch;
            AccountBase = accountBase;
            Suffix = suffix;

            _accountNumber = $"{bank:D2}{branch:D4}{accountBase:D8}{suffix:D4}".ToNumericValues();
        }

        /// <summary>
        /// Converts the string representation of an account number to its
        /// <see cref="NZBankAccount"/> equivalent.
        /// </summary>
        /// <param name="accountNumber">The string containing an account number to convert, in
        /// an accepted format.</param>
        /// <returns>A <see cref="NZBankAccount"/> equivalent of the specified
        /// account number.</returns>
        /// <remarks>
        /// <para>This creates a new instance of the <see cref="NZBankAccount"/> class,
        /// but does not validate it.
        /// </para>
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
        public static NZBankAccount Parse(string accountNumber)
            => ParseThrowIf(accountNumber, true);

        /// <summary>
        /// Converts the string representation of an account number to its
        /// <see cref="NZBankAccount"/> equivalent. A return value indicates whether
        /// the operation succeeded.
        /// </summary>
        /// <param name="accountNumber">The string containing an account number to convert, in
        /// an accepted format.</param>
        /// <param name="account">When this method returns, a <see cref="NZBankAccount"/>
        /// equivalent of the specified account number, if the conversion succeeded, or <see langword="null"/>
        /// if the conversion failed. The conversion fails if the account number is <see langword="null"/>,
        /// <see langword="Empty"/> or not one of the accepted formats. This parameter is passed uninitialized;
        /// any value originally supplied in account will be overwritten.
        /// </param>
        /// <returns><see langword="true"/> if the conversion succeeded, otherwise <see langword="false"/>.</returns>
        /// <remarks>
        /// <para>This creates a new instance of the <see cref="NZBankAccount"/> class,
        /// but does not validate it.
        /// </para>
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
        public static bool TryParse(string accountNumber, out NZBankAccount account)
        {
            account = ParseThrowIf(accountNumber, false);

            return account != null;
        }

        private static NZBankAccount ParseThrowIf(string accountNumber, bool throwException)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                if (throwException)
                {
                    throw new FormatException("The account number is null or empty.");
                }

                return null;
            }

            var match = AccountNumberRegex.Match(accountNumber);

            if (!match.Success)
            {
                if (throwException)
                {
                    throw new FormatException("The account number is malformed.");
                }

                return null;
            }

            var bank = Convert.ToInt32(match.Groups[1].Value);
            var branch = Convert.ToInt32(match.Groups[2].Value);
            var accountBase = Convert.ToInt32(match.Groups[3].Value);
            var suffix = Convert.ToInt32(match.Groups[4].Value);

            var account = new NZBankAccount(bank, branch, accountBase, suffix);

            return account;
        }

        /// <summary>
        /// Indicates whether the specified bank account number is valid.
        /// </summary>
        /// <param name="bank">The bank ID.</param>
        /// <param name="branch">The bank branch.</param>
        /// <param name="accountBase">The account base number.</param>
        /// <param name="suffix">The account suffix.</param>
        /// <returns><see langword="true"/> if the bank account number is valid, otherwise <see langword="false"/>.</returns>
        /// <example>
        /// The following example validates a bank account number using the static method <see cref="IsValid(int, int, int, int)"/>.
        /// <code>
        /// var bank = 1;
        /// var branch = 902;
        /// var accountBase = 68389;
        /// var suffix = 0;
        ///
        /// var isValid = NZBankAccount.IsValid(bank, branch, accountBase, suffix);
        /// </code>
        /// </example>
        public static bool IsValid(int bank, int branch, int accountBase, int suffix)
        {
            var account = new NZBankAccount(bank, branch, accountBase, suffix);
            var isValid = account.IsValid();

            return isValid;
        }

        /// <summary>
        /// Indicates whether the bank account number of the instance is valid.
        /// </summary>
        /// <returns><see langword="true"/> if the bank account number is valid, otherwise <see langword="false"/>.</returns>
        /// <example>
        /// The following example validates the bank account number of the instance using the method <see cref="IsValid()"/>.
        /// <code>
        /// var bank = 1;
        /// var branch = 902;
        /// var accountBase = 68389;
        /// var suffix = 0;
        ///
        /// var account = new NZBankAccount(bank, branch, accountBase, suffix);
        /// var isValid = account.IsValid();
        /// </code>
        /// </example>
        public bool IsValid()
        {
            // is the account number all zeroes?
            if (_accountNumber.All(n => n == 0))
            {
                return false;
            }

            // are the lengths of each constituent correct?
            if (Bank > 99 ||
                Branch > 9999 ||
                AccountBase > 99999999 ||
                Suffix > 9999)
            {
                return false;
            }

            var banks = BranchRangeSets.Select(d => d.Bank).ToList();

            // is the bank valid?
            if (!banks.Contains(Bank))
            {
                return false;
            }

            // is the branch valid?
            var branches = BranchRangeSets.Where(d => d.Bank == Bank).SelectMany(d => d.BranchRanges).ToList();

            if (!branches.Any(b => Branch >= b.Start && Branch <= b.End))
            {
                return false;
            }

            // is the check digit valid?
            if (!IsCheckDigitValid())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a string of the account number in a format typically
        /// used in practice.
        /// </summary>
        /// <returns>The formatted account number.</returns>
        public override string ToString()
            => $"{Bank:D2}-{Branch:D4}-{AccountBase:D7}-{Suffix:D2}";

        private bool IsCheckDigitValid()
        {
            var weightings = GetWeightings();

            var products = 0;

            for (var i = 0; i < _accountNumber.Length; i++)
            {
                products += _accountNumber[i] * weightings[i];
            }

            var modulo = GetModulo();
            var remainder = products % modulo;

            return remainder == 0;
        }

        private int[] GetWeightings()
        {
            switch (Bank)
            {
                case 8:
                    return new[] { 0, 0, 0, 0, 0, 0, 0, 7, 6, 5, 4, 3, 2, 1, 0, 0, 0, 0 };
                case 9:
                    return new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 4, 3, 2, 0, 0, 0, 1 };
                case 25:
                case 33:
                    return new[] { 0, 0, 0, 0, 0, 0, 0, 1, 7, 3, 1, 7, 3, 1, 0, 0, 0, 0 };
                case 26:
                case 28:
                case 29:
                    return new[] { 0, 0, 0, 0, 0, 0, 0, 1, 3, 7, 1, 3, 7, 1, 0, 3, 7, 1 };
                case 31:
                    return new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                default:
                    if (AccountBase < 990000)
                    {
                        return new[] { 0, 0, 6, 3, 7, 9, 0, 0, 10, 5, 8, 4, 2, 1, 0, 0, 0, 0 };
                    }

                    return new[] { 0, 0, 0, 0, 0, 0, 0, 0, 10, 5, 8, 4, 2, 1, 0, 0, 0, 0 };
            }
        }

        private int GetModulo()
        {
            switch (Bank)
            {
                case 25:
                case 33:
                case 26:
                case 28:
                case 29:
                    return 10;
                case 31:
                    return 1;
                default:
                    return 11;
            }
        }
    }
}
