using System;
using System.Collections.Generic;

namespace Day6UniversalOrbitMap
{
    public class SecondPuzzle
    {
        private readonly string _input;
        private const string MyPlanet = "YOU";
        private const string SantasPlanet = "SAN";

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution() => ComputeMinimumOrbitalTransfers();

        private int ComputeMinimumOrbitalTransfers()
        {
            var orbitRelations = Day6Utils.BuildOrbitRelations(_input);

            var meToComRoute = GetPlanetsRouteTillDestination(MyPlanet, Day6Utils.CenterOfMass, orbitRelations);
            var santaToComRoute = GetPlanetsRouteTillDestination(SantasPlanet, Day6Utils.CenterOfMass, orbitRelations);

            var commonPlanet = GetFirstCommonPlanet(meToComRoute, santaToComRoute);

            var meToCommonPlanet = Day6Utils.CountTotalPlanetOrbits(MyPlanet, commonPlanet, orbitRelations) - 1;
            var santaToCommonPlanet = Day6Utils.CountTotalPlanetOrbits(SantasPlanet, commonPlanet, orbitRelations) - 1;

            var minimumOrbitalTransfers = santaToCommonPlanet + meToCommonPlanet;

            return minimumOrbitalTransfers;
        }

        private List<string> GetPlanetsRouteTillDestination(string planet, string destinationPlanet, Dictionary<string, string> orbitsRelations)
        {
            var totalOrbits = 1;
            var currentPlanet = orbitsRelations[planet];

            var planetsVisited = new List<string>
            {
                currentPlanet
            };

            while (currentPlanet != destinationPlanet)
            {
                totalOrbits += 1;
                currentPlanet = orbitsRelations[currentPlanet];
                planetsVisited.Add(currentPlanet);
            }

            return planetsVisited;
        }

        private string GetFirstCommonPlanet(List<string> meToComRoute, List<string> santaToComRoute)
        {
            foreach (var currentPlanet in meToComRoute)
            {
                if (santaToComRoute.Contains(currentPlanet))
                {
                    return currentPlanet;
                }
            }
            throw new Exception("not possible to happen");
        }
    }
}
