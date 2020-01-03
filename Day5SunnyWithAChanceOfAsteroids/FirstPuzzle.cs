using System.Collections.Generic;
using System.Linq;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class FirstPuzzle
    {
        private readonly string _input;

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public long GetSolution()
        {
            var program = _input.Split(",").Select(a => long.Parse(a)).ToArray();

            var externalInput = new List<long> { 1 };

            var output = Day5Utils.RunProgram(program, externalInput);

            return output.Last();
        }
    }
}
