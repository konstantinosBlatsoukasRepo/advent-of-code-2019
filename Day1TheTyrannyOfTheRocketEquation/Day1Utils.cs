using System;
using System.Collections.Generic;
using System.Text;

namespace Day1TheTyrannyOfTheRocketEquation
{
    public class Day1Utils
    {
        public  static int CalculateFuelRequired(string mass) => (int)(double.Parse(mass) / 3) - 2;
        public static int CalculateFuelRequired(int mass) => (int)((double) mass / 3) - 2;

    }
}
