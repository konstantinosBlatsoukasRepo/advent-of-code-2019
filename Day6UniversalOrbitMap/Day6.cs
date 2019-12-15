using AdventOfCode2019;
using System;

namespace Day6UniversalOrbitMap
{
    public class Day6
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_6_input.txt").ReadInput();

            Console.WriteLine("Day 6: Universal Orbit Map");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }
    }
}
