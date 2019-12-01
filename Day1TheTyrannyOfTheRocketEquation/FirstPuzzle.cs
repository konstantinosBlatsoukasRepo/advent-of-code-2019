using System.Linq;

namespace Day1TheTyrannyOfTheRocketEquation
{
    public class FirstPuzzle
    {
        private readonly string _input;

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution() => _input.Split("\r\n")
                .Select(mass => Day1Utils.CalculateFuelRequired(mass))
                .Sum();

    }
}
