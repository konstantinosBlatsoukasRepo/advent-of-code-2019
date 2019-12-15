using AdventOfCode2019;
using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class Day5
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_5_input.txt").ReadInput();

            Console.WriteLine("Day 5: Sunny With A Chance Of Asteroids");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }
    }
}
