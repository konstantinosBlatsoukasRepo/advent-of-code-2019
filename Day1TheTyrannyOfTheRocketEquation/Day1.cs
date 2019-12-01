using AdventOfCode2019;
using System;

namespace Day1TheTyrannyOfTheRocketEquation
{
    public class Day1
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("FirstPartInput.txt").ReadInput();

            Console.WriteLine("Day 1: The Tyranny Of TheRocket Equation");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }
    }
}
