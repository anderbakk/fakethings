using System;
using System.Text.RegularExpressions;

namespace FakeThings
{
    public class NorwegianSsnValidator
    {
        private const string Pattern = @"^\d+$";
        private static readonly int[] controlDigitMultipliers1 = new int[] { 3, 7, 6, 1, 8, 9, 4, 5, 2 };
        private static readonly int[] controlDigitMultipliers2 = new int[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        public bool IsValid(string ssn)
        {
            if (string.IsNullOrWhiteSpace(ssn) || ssn.Length != 11)
                return false;

            if (Regex.IsMatch(ssn, Pattern) == false)
                return false;

            var allDigits = new int[11];
            for (var i = 0; i < ssn.Length; i++)
            {
                allDigits[i] = (int)Char.GetNumericValue(ssn[i]);
            }

            var controlDigit1 = CalculateControlDigit(controlDigitMultipliers1, allDigits);
            
            var controlDigit2 = CalculateControlDigit(controlDigitMultipliers2, allDigits);
            
            if (allDigits[9] != controlDigit1)
                return false;
            if (controlDigit2 != allDigits[10])
                return false;

            return true;

        }

        private static int CalculateControlDigit(int[] controlDigitMultipliers, int[] ssn)
        {
            var sum = 0;
            for (int i = 0; i < controlDigitMultipliers.Length; i++)
            {
                sum += controlDigitMultipliers[i] * ssn[i];
            }
            return 11 - sum % 11;
        }
    }
}
