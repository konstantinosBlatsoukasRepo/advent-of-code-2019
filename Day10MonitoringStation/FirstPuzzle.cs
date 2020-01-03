using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10MonitoringStation
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
            var lines = _input.Split("\r\n").ToList();

            List<Point> points = Day10Utils.ParseMap(lines);
            var asteroids = points.Where(p => p.IsAsteroid).ToList();

            var max = int.MinValue;
            var maxAsteroid = new Point();
            foreach (var asteroid in asteroids)
            {
                var currentMax = CountTotalAsteroidsInView(asteroid, asteroids);
                if (currentMax > max)
                {
                    max = currentMax;
                    maxAsteroid = asteroid;
                }
            }

            Console.WriteLine($"column: {maxAsteroid.Column}");
            Console.WriteLine($"row: {maxAsteroid.Row}");
         
            return max;
        }

        private int CountTotalAsteroidsInView(Point asteroid, List<Point> asteroids)
        {
            var referenceColumn = asteroid.Column;
            var referenceRow = asteroid.Row;

            var uniqueAngles = new HashSet<double>();
            foreach (var currentAsteroid in asteroids)
            {
                var currentColumn = currentAsteroid.Column;
                var currentRow = currentAsteroid.Row;

                if (referenceColumn == currentColumn && currentRow == referenceRow)
                {
                    continue;
                }

                var inferedColumn = referenceColumn - currentColumn;
                var inferedRow = referenceRow - currentRow;                

                uniqueAngles.Add(Math.Atan2(inferedColumn, inferedRow));
            }
            
            return uniqueAngles.Count;
        }

    }
}
