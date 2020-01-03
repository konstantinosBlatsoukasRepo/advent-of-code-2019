using AdventOfCode2019;
using System;

namespace Day13CarePackage
{
    public class Day13
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_13_input.txt").ReadInput();

            Console.WriteLine("Day 13: Care Package");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }
    }
}
