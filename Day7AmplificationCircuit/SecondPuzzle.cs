using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day7AmplificationCircuit
{
    public class SecondPuzzle
    {
        private readonly string _input;

        private static readonly IEnumerable<string> AllCombinations = Day7Utils.Permutate("56789");

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public long GetSolution()
        {            
            var program = _input.Split(",").Select(a => long.Parse(a)).ToList();

            return AllCombinations
                .Select(combo => RunAmplifiers(program, combo))
                .Max(); 
        }

        private long RunAmplifiers(List<long> program, string phases)
        {
            var amplfiers = new List<Amplifier>();            
            for (var i = 0; i < phases.Length; i++)
            {
                var phase = long.Parse(phases[i].ToString());
                amplfiers.Add(new Amplifier(program.ToArray(), phase, 0));          
            }

            var n = amplfiers.Count();
            var numFinished = 0;

            var lastOutput = 0L;
            var lastNonNoneOutput = -1L;
            var aid = 0;

            while (numFinished < n)
            {
                lastOutput = amplfiers[aid].RunProgram(lastOutput);
                if (lastOutput == -1)
                {
                    numFinished += 1;
                }                
                else
                {
                    lastNonNoneOutput = lastOutput;
                    aid = (aid + 1) % n;
                }
            }
            return lastNonNoneOutput;
        }
    }
}
