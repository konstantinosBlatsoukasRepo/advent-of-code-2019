using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day12TheNBodyProblem
{
    public class FirstPuzzle
    {
        private readonly string _input;
        private const string numbersPattern = @"[-\d]+";

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            var lines = _input.Split("\r\n").ToList();

            var moons = ParseMoons(lines);

            for (var currentStep = 0; currentStep < 1000; currentStep++)
            {
                SimulateSingleStep(moons);
            }

            return moons.Select(m => m.ComputeTotalEnergy(m)).Sum();
        }

        public void SimulateSingleStep(List<Moon> moons)
        {
            UpdateVelocity(moons);
            UpdatePosition(moons);
        }

        private void UpdateVelocity(List<Moon> moons)
        {        
            var pairsSeen = new HashSet<string>();
            for (int moonIndex = 0; moonIndex < moons.Count(); moonIndex++)
            {
                for (int otherMoonIndex = 0; otherMoonIndex < moons.Count(); otherMoonIndex++)
                {
                    var firstPossiblePair = $"{moonIndex}, {otherMoonIndex}";
                    var secondPossiblePair = $"{otherMoonIndex}, {moonIndex}";

                    if (!pairsSeen.Contains(firstPossiblePair))
                    {
                        pairsSeen.Add(firstPossiblePair);
                        pairsSeen.Add(secondPossiblePair);

                        var moon = moons[moonIndex];
                        var otherMoon = moons[otherMoonIndex];

                        ApplyGravity(moon, otherMoon);
                    }

                }
            }
        }

        private void ApplyGravity(Moon moon, Moon otherMoon)
        {
            if (moon.XPosition > otherMoon.XPosition)
            {
                moon.XVelocity -= 1;
                otherMoon.XVelocity += 1;
            }
            else if (moon.XPosition < otherMoon.XPosition)
            {
                moon.XVelocity += 1;
                otherMoon.XVelocity -= 1;
            }

            if (moon.YPosition > otherMoon.YPosition)
            {
                moon.YVelocity -= 1;
                otherMoon.YVelocity += 1;
            }
            else if (moon.YPosition < otherMoon.YPosition)
            {
                moon.YVelocity += 1;
                otherMoon.YVelocity -= 1;
            }

            if (moon.ZPosition > otherMoon.ZPosition)
            {
                moon.ZVelocity -= 1;
                otherMoon.ZVelocity += 1;

            }
            else if (moon.ZPosition < otherMoon.ZPosition)
            {
                moon.ZVelocity += 1;
                otherMoon.ZVelocity -= 1;
            }
        }

        private void UpdatePosition(List<Moon> moons)
        {
            foreach (var moon in moons)
            {
                moon.XPosition += moon.XVelocity;
                moon.YPosition += moon.YVelocity;
                moon.ZPosition += moon.ZVelocity;
            }
        }
        
        public List<Moon> ParseMoons(IEnumerable<string> lines)
        {
            Regex matchNumbersRgx = new Regex(numbersPattern);

            var moons = new List<Moon>();
            foreach (var line in lines)
            {
                var matches = matchNumbersRgx.Matches(line);
                var x = int.Parse(matches[0].Value);
                var y = int.Parse(matches[1].Value);
                var z = int.Parse(matches[2].Value);

                moons.Add(new Moon { XPosition = x, YPosition = y, ZPosition = z });
            }

            return moons;
        }

        private string ConstructState(List<Moon> moons)
        {
            return $"{moons[0].XPosition}{moons[0].YPosition}{moons[0].ZPosition}{moons[0].XVelocity}{moons[0].YVelocity}{moons[0].ZVelocity}{moons[1].XPosition}{moons[1].YPosition}{moons[1].ZPosition}{moons[1].XVelocity}{moons[1].YVelocity}{moons[1].ZVelocity}{moons[2].XPosition}{moons[2].YPosition}{moons[2].ZPosition}{moons[2].XVelocity}{moons[2].YVelocity}{moons[2].ZVelocity}{moons[3].XPosition}{moons[3].YPosition}{moons[3].ZPosition}{moons[3].XVelocity}{moons[3].YVelocity}{moons[3].ZVelocity}";                  
        }

    }
}