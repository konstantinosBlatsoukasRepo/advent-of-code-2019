using Day9SensorBoost;
using System.Collections.Generic;
using System.Linq;

namespace Day13CarePackage
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
            var program = _input.Split(",").Select(a => long.Parse(a)).ToArray();

            var intCodeComputer = new IntCodeComputer(program);

            var tiles = new List<Tile>();

            while (!intCodeComputer.Finished)
            {
                var distanceFromLeft = intCodeComputer.GetOutput();
                var distanceFromTop = intCodeComputer.GetOutput();
                var tileType = (TileType) intCodeComputer.GetOutput();

                var tile = new Tile() { DistanceFromLeft = distanceFromLeft, DistanceFromTop = distanceFromTop, TileType = tileType};

                tiles.Add(tile);
            }


            return tiles.Where(k => k.TileType == TileType.Block).Count();
        }
    }
}
