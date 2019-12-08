using System.Collections.Generic;
using System.Linq;

namespace Day3CrossedWires
{
    public class Day3Utils
    {
        public static HashSet<string> GetCommonPoints(HashSet<string> firstWirePoints, HashSet<string> secondWirePoints)
        {
            //var commonPoints = new HashSet<string>();
            //foreach (var secondWirePoint in secondWirePoints)
            //{
            //    if (firstWirePoints.Contains(secondWirePoint))
            //    {
            //        commonPoints.Add(secondWirePoint);
            //    }
            //}
            return secondWirePoints
                .Where(p => firstWirePoints.Contains(p))
                .ToHashSet();
        }
        
        public static List<string> GetWirePoints(string[] wire)
        {
            var row = 0;
            var column = 0;
            var wirePoints = new List<string>();
            foreach (var direction in wire)
            {
                var directionNumber = int.Parse(direction.Substring(1));
                switch (direction[0])
                {
                    case 'R':
                        for (int newColumn = column + 1; newColumn <= column + directionNumber; newColumn++)
                        {
                            wirePoints.Add($"{row},{newColumn}");
                        }
                        column = column + directionNumber;
                        break;
                    case 'U':
                        for (int newRow = row + 1; newRow <= row + directionNumber; newRow++)
                        {
                            wirePoints.Add($"{newRow},{column}");
                        }
                        row = row + directionNumber;
                        break;
                    case 'D':
                        for (int newRow = row - 1; newRow >= row - directionNumber; newRow--)
                        {
                            wirePoints.Add($"{newRow},{column}");
                        }
                        row = row - directionNumber;
                        break;
                    case 'L':
                        for (int newColumn = column - 1; newColumn >= column - directionNumber; newColumn--)
                        {
                            wirePoints.Add($"{row},{newColumn}");
                        }
                        column = column - directionNumber;
                        break;
                }
            }
            return wirePoints;
        }
    }
}
