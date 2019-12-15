using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4SecureContainer
{
    public class SecondPuzzle
    {
        private readonly string _input;

        public SecondPuzzle(string input)
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
            return originalDigits == sortedDigits && sortedDigits.Distinct().Count() < 6 && thereIsADouble(sortedDigitsChars);
        }

        private bool thereIsADouble(IOrderedEnumerable<char> sortedDigitsChars)
        {
            var characterCount = new Dictionary<char, int>();
            foreach (var c in sortedDigitsChars)
            {
                if (characterCount.ContainsKey(c))
                    characterCount[c]++;
                else
                    characterCount[c] = 1;
            }

            foreach (var currentCount in characterCount)
            {
                if (currentCount.Value == 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
