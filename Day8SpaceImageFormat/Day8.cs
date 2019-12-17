using AdventOfCode2019;
using System;

namespace Day8SpaceImageFormat
{
    public class Day8
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_8_input.txt").ReadInput();

            Console.WriteLine("Day 8: Space Image Format");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            new SecondPuzzle(parsedInput).GetSolution();
            Console.WriteLine();
        }
    }
}
