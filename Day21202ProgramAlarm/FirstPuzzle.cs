using System.Linq;

namespace Day21202ProgramAlarm
{
    class FirstPuzzle
    {
        private readonly string _input;

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            var input = _input.Split(",").Select(a => int.Parse(a)).ToArray();

            input[1] = 12;
            input[2] = 2;

            var output = Day2Utils.RunProgram(input);

            return output[0];
        }

    }
}
