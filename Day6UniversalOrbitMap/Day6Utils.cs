using System.Collections.Generic;

namespace Day6UniversalOrbitMap
{
    public class Day6Utils
    {
        public const string CenterOfMass = "COM";

        public static int CountTotalPlanetOrbits(string planet, string destinationPlanet, Dictionary<string, string> orbitsRelations)
        {
            var totalOrbits = 1;
            var currentPlanet = orbitsRelations[planet];

            while (currentPlanet != destinationPlanet)
            {
                totalOrbits += 1;
                currentPlanet = orbitsRelations[currentPlanet];
            }

            return totalOrbits;
        }

        public static Dictionary<string, string> BuildOrbitRelations(string input)
        {
            // how you would do the follwoing using linq?
            var orbits = input.Split("\r\n");
            var orbitsRelations = new Dictionary<string, string>();
            foreach (var orbit in orbits)
            {
                var planets = orbit.Split(")");
                orbitsRelations[$"{planets[1]}"] = planets[0];
            }
            return orbitsRelations;
        }

    }
}
