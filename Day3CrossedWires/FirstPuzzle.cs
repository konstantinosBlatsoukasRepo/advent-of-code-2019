using System;
using System.Collections.Generic;

namespace Day3CrossedWires
{
    public class FirstPuzzle
    {
        private readonly string _input;

        public FirstPuzzle(string input)
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
            // in highlights, when you want to take leverage of fast search (if something is in a set)
            var secondUniqueWirePoints = new HashSet<string>(secondWirePoints);

            var commonPoints = Day3Utils.GetCommonPoints(firstUniqueWirePoints, secondUniqueWirePoints);

            return ComputeMinDistance(commonPoints);
        }

        private int ComputeManhattanDistance(string commonPoint)
        {
            var rowAndColumn = commonPoint.Split(",");
            return Math.Abs(int.Parse(rowAndColumn[0])) + Math.Abs(int.Parse(rowAndColumn[1]));
        }

        private int ComputeMinDistance(HashSet<string> commonPoints)
        {
            var minDistance = int.MaxValue;
            foreach (var commonPoint in commonPoints)
            {
                var manhattanDistance = ComputeManhattanDistance(commonPoint);
                if (manhattanDistance < minDistance)
                {
                    minDistance = manhattanDistance;
                }
            }
            return minDistance;
        }

    }
}
