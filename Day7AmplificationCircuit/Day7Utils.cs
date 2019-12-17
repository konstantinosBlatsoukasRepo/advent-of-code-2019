using Day5SunnyWithAChanceOfAsteroids;
using System.Collections.Generic;
using System.Linq;

namespace Day7AmplificationCircuit
{
    public class Day7Utils
    {
        public static int GetMaxThrusterSignal(int[] input, string phaseSettings, List<int> externalInput)
        {
            externalInput.Add(0);
            externalInput.Add(0);

            var firstExternalInput = 0;
            var thrusterSignlas = new List<int>();

            for (int currentAmp = 0; currentAmp < 5; currentAmp++)
            {
                externalInput[1] = firstExternalInput;
                externalInput[0] = int.Parse(phaseSettings[currentAmp].ToString());

                var currentThrusterSignal = Day5Utils.RunProgram(input, externalInput);

                thrusterSignlas.Add(currentThrusterSignal);
                firstExternalInput = currentThrusterSignal;
            }

            return thrusterSignlas.Max();
        }

        public static int GetMaxThrusterSignalFeedback(int[] input, string phaseSettings, List<int> externalInput)
        {
            var firstExternalInput = 0;
            var thrusterSignlas = new List<int>();

            for (int currentAmp = 0; currentAmp < 5; currentAmp++)
            {
                externalInput.Add(int.Parse(phaseSettings[currentAmp].ToString()));
                externalInput.Add(firstExternalInput);
 
                var currentThrusterSignal = Day5Utils.RunProgram(input, externalInput);

                thrusterSignlas.Add(currentThrusterSignal);
                firstExternalInput = currentThrusterSignal;
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
