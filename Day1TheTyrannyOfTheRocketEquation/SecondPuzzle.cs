using System.Linq;

namespace Day1TheTyrannyOfTheRocketEquation
{
    public class SecondPuzzle
    {
        private readonly string _input;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution() => _input.Split("\r\n")
                .Select(mass => GetIndividualRequiredFuel(int.Parse(mass)))
                .Sum();

        public int GetIndividualRequiredFuel(int mass)
        {
            var totalRequired = Day1Utils.CalculateFuelRequired(mass);
            var currentMass = totalRequired;
            while (currentMass >= 0)
            {
                currentMass = Day1Utils.CalculateFuelRequired(currentMass);
                if (currentMass >= 0)
                {
                    totalRequired += currentMass;
                }
            }
            return totalRequired;
        }
    }


}
