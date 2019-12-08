using System.Collections.Generic;
using System.Linq;

namespace Day3CrossedWires
{
    public class SecondPuzzle
    {
        private readonly string _input;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            var wiresDirections = _input.Split("\n");

            var firstWireDirections = wiresDirections[0].Split(",");
            var secondWireDirections = wiresDirections[1].Split(",");

            var firstWirePoints = Day3Utils.GetWirePoints(firstWireDirections);
            var firstUniqueWirePoints = new HashSet<string>(firstWirePoints);

            var secondWirePoints = Day3Utils.GetWirePoints(secondWireDirections);
            var secondUniqueWirePoints = new HashSet<string>(secondWirePoints);

            var commonPoints = Day3Utils.GetCommonPoints(firstUniqueWirePoints, secondUniqueWirePoints);

            var firstWireStepsToCommonPoints = ComputeStepsToCommonPoints(commonPoints, firstWirePoints);
            var secondWireStepsToCommonPoints = ComputeStepsToCommonPoints(commonPoints, secondWirePoints);

            var minimumStepsSum = ComputeMinimumStepsSum(firstWireStepsToCommonPoints, secondWireStepsToCommonPoints, commonPoints);

            return minimumStepsSum;
        }

        private Dictionary<string, int> ComputeStepsToCommonPoints(HashSet<string> commonPoints, List<string> wirePoints)
        {
            var stepsToCommonPoints = new Dictionary<string, int>();
            foreach (var commonPoint in commonPoints)
            {
                var totalStepsToCommonPoint = ComputeStepsToPoint(commonPoint, wirePoints);
                stepsToCommonPoints.Add(commonPoint, totalStepsToCommonPoint);
            }
            return stepsToCommonPoints;
        }

        private int ComputeStepsToPoint(string commonPoint, List<string> wirePoints)
        {
            var totalSteps = 0;
            foreach (var wirePoint in wirePoints)
            {
                totalSteps++;
                if (wirePoint == commonPoint)
                {
                    return totalSteps;
                }
            }
            throw new System.Exception("not possible ot happen");
        }

        private int ComputeMinimumStepsSum(Dictionary<string, int> firstWireStepsToCommonPoints, Dictionary<string, int> secondWireStepsToCommonPoints, HashSet<string> commonPoints)
        {
            var totalMinimumSumSteps = int.MaxValue;
            foreach (var commonPoint in commonPoints)
            {
                var totalSumSteps = firstWireStepsToCommonPoints[commonPoint] + secondWireStepsToCommonPoints[commonPoint];
                if (totalSumSteps < totalMinimumSumSteps)
                {
                    totalMinimumSumSteps = totalSumSteps;
                }
            }
            return totalMinimumSumSteps;
        }

    }
}
