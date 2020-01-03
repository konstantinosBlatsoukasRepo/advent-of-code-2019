using Day5SunnyWithAChanceOfAsteroids;
using System.Collections.Generic;
using System.Linq;

namespace Day7AmplificationCircuit
{
    public class Day7Utils
    {
        public static long GetMaxThrusterSignal(long[] program, string phaseSettings, List<long> externalInput)
        {
            externalInput.Add(0);
            externalInput.Add(0);

            long firstExternalInput = 0;
            var thrusterSignlas = new List<long>();

            for (int currentAmp = 0; currentAmp < 5; currentAmp++)
            {
                externalInput[1] = firstExternalInput;
                externalInput[0] = int.Parse(phaseSettings[currentAmp].ToString());

                var currentThrusterSignals = Day5Utils.RunProgram(program, externalInput);
                var producedThursterSignal = currentThrusterSignals.Last();

                thrusterSignlas.Add(producedThursterSignal);
                firstExternalInput = producedThursterSignal;
            }

            return thrusterSignlas.Max();
        }

        public static IEnumerable<string> Permutate(string source)
        {
            if (source.Length == 1) return new List<string> { source };

            var permutations = from c in source
                               from p in Permutate(new string(source.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }
    }
}
