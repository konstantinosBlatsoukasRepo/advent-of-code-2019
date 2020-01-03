using System.Collections.Generic;
using System.Linq;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class SecondPuzzle
    {
        private readonly string _input;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public long GetSolution()
        {
            var input = _input.Split(",").Select(a => long.Parse(a)).ToArray();

            var externalInput = new List<long> { 5 };

            var output = Day5Utils.RunProgram(input, externalInput);

            return output.Last();
        }
    }
}
