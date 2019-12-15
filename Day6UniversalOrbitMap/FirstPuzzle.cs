namespace Day6UniversalOrbitMap
{
    public class FirstPuzzle
    {
        private readonly string _input;

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution() => CountTotalOrbits();

        private int CountTotalOrbits()
        {
            var totalOrbits = 0;
            var orbitRelations = Day6Utils.BuildOrbitRelations(_input);
            foreach (var orbitRelation in orbitRelations)
            {
                var currentPlanet = orbitRelation.Key;
                var totalPlanetOrbits = Day6Utils.CountTotalPlanetOrbits(currentPlanet, Day6Utils.CenterOfMass, orbitRelations);
                totalOrbits += totalPlanetOrbits;
            }
            return totalOrbits;
        }
    }
}
