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

        public long GetSolution()
        {
            var program = _input.Split(",").Select(a => long.Parse(a)).ToArray();

            var thrusterSignals = new List<long>();
            foreach (var currentCombo in AllCombinations)
            {
                var externalInput = new List<long>();
                var currentSignal = Day7Utils.GetMaxThrusterSignal(program, currentCombo, externalInput);
                thrusterSignals.Add(currentSignal);
            }

            return thrusterSignals.Max();
        }



    }
}
