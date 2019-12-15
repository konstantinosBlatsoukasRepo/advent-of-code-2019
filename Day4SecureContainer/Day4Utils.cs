using System;

namespace Day4SecureContainer
{
    public class Day4Utils
    {
        public static int CountDifferentPasswords(string input, Func<int, bool> AreCriteriaMet)
        {
            var range = input.Split("-");

            int lowBound = int.Parse(range[0]);
            int highBound = int.Parse(range[1]);

            var count = 0;
            for (var number = lowBound; number <= highBound; number++)
            {
                if (AreCriteriaMet(number))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
