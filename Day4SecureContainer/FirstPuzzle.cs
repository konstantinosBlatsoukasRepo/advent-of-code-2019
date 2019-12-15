using System;
using System.Linq;

namespace Day4SecureContainer
{
    public class FirstPuzzle
    {
        private readonly string _input;

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            return Day4Utils.CountDifferentPasswords(_input, AreCriteriaMet);
        }

        private bool AreCriteriaMet(int number)
        {
            var originalDigits = number.ToString();
            var sortedDigitsChars = originalDigits.OrderBy(c => c);
            var sortedDigits = String.Concat(sortedDigitsChars);
            return originalDigits == sortedDigits && sortedDigits.Distinct().Count() < 6;
        }
    }

}