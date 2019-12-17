using System.Collections.Generic;
using System.Linq;

namespace Day7AmplificationCircuit
{
    class FirstPuzzle
    {
        private readonly string _input;

        private static readonly IEnumerable<string> AllCombinations = Day7Utils.Permutate("01234");

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            var input = _input.Split(",").Select(a => int.Parse(a)).ToArray();

            var thrusterSignals = new List<int>();
            foreach (var currentCombo in AllCombinations)
            {
                var externalInput = new List<int>();
                var currentSignal = Day7Utils.GetMaxThrusterSignal(input, currentCombo, externalInput);
                thrusterSignals.Add(currentSignal);
            }

            return thrusterSignals.Max();
        }

    }
}
