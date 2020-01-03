using System.Collections.Generic;

namespace Day10MonitoringStation
{
    public class Day10Utils
    {
        public static List<Point> ParseMap(List<string> lines)
        {
            var points = new List<Point>();
            for (var row = 0; row < lines.Count; row++)
            {
                var currentline = lines[row];
                for (var column = 0; column < lines[row].Length; column++)
                {
                    var currentCoordinate = $"({column.ToString()},{row.ToString()})";
                    var isAsteroid = currentline[column] == '#';

                    Point currentPoint = new Point { Coordinates = currentCoordinate, IsAsteroid = isAsteroid, Column = column, Row = row };
                    points.Add(currentPoint);
                }
            }
            return points;
        }
    }
}
