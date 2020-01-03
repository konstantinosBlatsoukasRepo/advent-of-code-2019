using AdventOfCode2019;
using System;

namespace Day12TheNBodyProblem
{
    public class Day12
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_12_input.txt").ReadInput();

            Console.WriteLine("Day 12: The N-Body Problem");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }

    }
}
