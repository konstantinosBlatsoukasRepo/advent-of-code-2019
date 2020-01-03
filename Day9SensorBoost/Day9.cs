using AdventOfCode2019;
using System;

namespace Day9SensorBoost
{
    public class Day9
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_9_input.txt").ReadInput();

            Console.WriteLine("Day 9: Sensor Boost");
            Console.WriteLine();
            
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }

    }
}
