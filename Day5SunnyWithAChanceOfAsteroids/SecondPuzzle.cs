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

        public int GetSolution()
        {
            var input = _input.Split(",").Select(a => int.Parse(a)).ToArray();

            var externalInput = new List<int> { 5 };

            var output = Day5Utils.RunProgram(input, externalInput);

            return output;
        }
    }
}
