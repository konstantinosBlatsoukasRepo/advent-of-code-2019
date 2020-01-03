using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10MonitoringStation
{
    public class SecondPuzzle
    {
        private const int ColumnReference = 11;
        private const int RowReference = 13;
        private static int TotalAsteroidsVaporized = 0;

        private readonly string _input;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            var lines = _input.Split("\r\n").ToList();

            List<Point> points = Day10Utils.ParseMap(lines);
            var asteroids = points.Where(p => p.IsAsteroid).ToList();

            var polarizedAsteroids = ConvertToPolarCoordinates(asteroids);

            Dictionary<Quadrants, List<PolarCoordinate>> polarsPerQuadrants = GetPolarPerQuadrants(polarizedAsteroids);


            var quadrants = new List<Quadrants> {
                Quadrants.XZeroYPositive,
                Quadrants.FirstQuadrant,
                Quadrants.YZeroXPositive,
                Quadrants.ForthQuadrant,
                Quadrants.XZeroYNegative,
                Quadrants.ThirdQuadrant,
                Quadrants.YZeroXNegative,
                Quadrants.SecondQuadrant
            };

            while (polarsPerQuadrants.Count != 0)
            {
                foreach (var quadrant in quadrants)
                {
                    var vaporizedResult = Vaporize(polarsPerQuadrants, quadrant);
                    if (vaporizedResult != 0)
                    {
                        return vaporizedResult;
                    }
                }          
            }

            return 0;
        }

        private int Vaporize(Dictionary<Quadrants, List<PolarCoordinate>> polarsPerQuadrants, Quadrants quadrant)
        {
            if (polarsPerQuadrants.ContainsKey(quadrant))
            {
                var seenAngles = new HashSet<double>();
                
                var ordered = OrderByAngle(polarsPerQuadrants, quadrant);

                foreach (var currentAsteroid in ordered)
                {
                    if (!seenAngles.Contains(currentAsteroid.Angle))
                    {
                        seenAngles.Add(currentAsteroid.Angle);

                        var asteroidToBeVaporized = polarsPerQuadrants[quadrant]
                            .Where(a => a.Angle.CompareTo(currentAsteroid.Angle) == 0)
                            .OrderBy(a => a.Radius)
                            .First();

                        polarsPerQuadrants[quadrant].Remove(asteroidToBeVaporized);

                        TotalAsteroidsVaporized += 1;                 

                        if (TotalAsteroidsVaporized == 201)
                        {
                            return asteroidToBeVaporized.Point.Column * 100 + asteroidToBeVaporized.Point.Row;
                        }
                    }

                    if (polarsPerQuadrants[quadrant].Count == 0)
                    {
                        polarsPerQuadrants.Remove(quadrant);
                    }
                }
            }

            return 0;
        }

        private IEnumerable<PolarCoordinate> OrderByAngle(Dictionary<Quadrants, List<PolarCoordinate>> polarsPerQuadrants, Quadrants quadrant)
        {
            return quadrant switch
            {
                Quadrants.YZeroXPositive => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle),
                Quadrants.YZeroXNegative => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle),
                Quadrants.XZeroYPositive => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle),
                Quadrants.XZeroYNegative => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle),
                Quadrants.FirstQuadrant => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle).Reverse(),
                Quadrants.SecondQuadrant => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle).Reverse(),
                Quadrants.ThirdQuadrant => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle).Reverse(),
                Quadrants.ForthQuadrant => polarsPerQuadrants[quadrant].OrderBy(p => p.Angle),
                _ => throw new Exception("impossible to happen"),
            };
        }

        private Dictionary<Quadrants, List<PolarCoordinate>> GetPolarPerQuadrants(List<PolarCoordinate> polarizedAsteroids)
        {
            var grouped = polarizedAsteroids.GroupBy(a => a.Quadrant);

            var polarsPerQuadrants = new Dictionary<Quadrants, List<PolarCoordinate>>();
            foreach (var currentGroup in grouped)
            {
                var currentQuadrant = currentGroup.Key;
                polarsPerQuadrants[currentQuadrant] = currentGroup.ToList();
            }

            return polarsPerQuadrants;
        }

        private List<PolarCoordinate> ConvertToPolarCoordinates(List<Point> asteroids)
        {
             return asteroids
                .Select(a => new CartesianCoordinate(a, ColumnReference, RowReference))
                .Select(c => new PolarCoordinate(c))
                .ToList();
        }

    }
}
