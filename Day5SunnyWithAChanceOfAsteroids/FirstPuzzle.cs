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

        public int GetSolution()
        {
            var input = _input.Split(",").Select(a => int.Parse(a)).ToArray();

            var output = Day5Utils.RunProgram(input, 1);

            return output;
        }
    }
}
