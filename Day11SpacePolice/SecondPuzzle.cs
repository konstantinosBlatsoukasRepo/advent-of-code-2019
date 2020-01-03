using Day9SensorBoost;
using System;
using System.Linq;

namespace Day11SpacePolice
{
    class SecondPuzzle
    {
        private readonly string _input;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            var program = _input.Split(",").Select(a => long.Parse(a)).ToArray();

            var intCodeComputer = new IntCodeComputer(program);

            var hullRobot = new HullRobot(intCodeComputer, (int) Color.White);

            hullRobot.Paint();

            for (int y = hullRobot.MaxY; y >= hullRobot.MinY; y--)
            {
                for (int x = hullRobot.MinX; x <= hullRobot.MaxX; x++)
                {

                    if (hullRobot.PanelsPainted.ContainsKey($"({x},{y})") && hullRobot.PanelsPainted[$"({x},{y})"] == Color.White)
                    {
                        Console.Write(string.Format("{0} ", "#"));
                    }
                    else 
                    {
                        Console.Write(string.Format("{0} ", " "));
                    }                   

                }
                Console.Write(Environment.NewLine);
            }

            return hullRobot.GetTotalPanelsPainted();
        }
    }
}
