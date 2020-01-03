using Day9SensorBoost;
using System.Collections.Generic;
using System.Linq;


namespace Day11SpacePolice
{
    class FirstPuzzle
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

            var hullRobot = new HullRobot(intCodeComputer, (int) Color.Black);

            hullRobot.Paint();
            
            return hullRobot.GetTotalPanelsPainted();
        }
    }
}
