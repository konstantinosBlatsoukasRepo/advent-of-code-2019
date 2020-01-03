using Day5SunnyWithAChanceOfAsteroids;
using System.Collections.Generic;
using System.Linq;

namespace Day9SensorBoost
{
    public class FirstPuzzle
    {
        private readonly string _input;

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public long GetSolution()
        {            
            var program = _input.Split(",").Select(a => long.Parse(a)).ToArray();

            var intCodeComputer = new IntCodeComputer(program)
            {
                Inputs = new List<long> { 1 }
            };

            var output = intCodeComputer.Run();

            return output;
        }
    }
}