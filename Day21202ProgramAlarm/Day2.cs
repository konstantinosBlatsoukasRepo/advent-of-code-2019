using AdventOfCode2019;
using System;

namespace Day21202ProgramAlarm
{
    public class Day2
    {
        static void Main(string[] args)
        {
            ShowSolutions();
        }
        public static void ShowSolutions()
        {
            var parsedInput = new InputParser("input.txt").ReadInput();

            Console.WriteLine("Day 2: 1202 Program Alarm");
            Console.WriteLine();
            Console.WriteLine($"First puzzle: {new FirstPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine($"Second puzzle: {new SecondPuzzle(parsedInput).GetSolution()}");
            Console.WriteLine();
        }
    }

}
