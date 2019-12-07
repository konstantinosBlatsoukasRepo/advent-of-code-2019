using System.Linq;

namespace Day21202ProgramAlarm
{
    public class SecondPuzzle
    {
        private readonly string _input;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        private class NounAndVerb
        {
            public int Noun { get; set; }
            public int Verb { get; set; }
        }

        public int GetSolution()
        {
            var input = _input.Split(",").Select(a => int.Parse(a)).ToArray();

            var nounAndVerb = FindNounAndVerb(input);

            return int.Parse($"{nounAndVerb.Noun.ToString()}{nounAndVerb.Verb.ToString()}");
        }

        private NounAndVerb FindNounAndVerb(int[] input)
        {
            var nounAndVerb = new NounAndVerb();

            for (int nounValue = 0; nounValue < 100; nounValue++)
            {
                for (int verbValue = 0; verbValue < 100; verbValue++)
                {
                    input[NounPosition] = nounValue;
                    input[VerbPosition] = verbValue;
                    var output = Day2Utils.RunProgram(input);

                    if (output[OutputPosition] == TargetOutput)
                    {
                        nounAndVerb.Noun = nounValue;
                        nounAndVerb.Verb = verbValue;
                        return nounAndVerb;
                    }
                }
            }
            return nounAndVerb;
        }

        private const int TargetOutput = 19690720;
        private const int OutputPosition = 0;
        private const int NounPosition = 1;
        private const int VerbPosition = 2;
    }

}