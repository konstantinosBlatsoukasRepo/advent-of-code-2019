using AdventOfCode2019;
using System;

namespace Day7AmplificationCircuit
{
    public class Day7
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("day_7_input.txt").ReadInput();

            Console.WriteLine("Day 7: Amplification Circuit");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }
    }
}
