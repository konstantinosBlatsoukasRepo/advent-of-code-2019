using AdventOfCode2019;
using System;

namespace Day3CrossedWires
{
    public class Day3
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_3_input.txt").ReadInput();

            Console.WriteLine("Day 3: Crossed Wires");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }
    }
}
