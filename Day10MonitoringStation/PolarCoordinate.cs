using System;

namespace Day10MonitoringStation
{
    public class PolarCoordinate
    {
        public CartesianCoordinate CartesianCoordinate { get; }

        public  double Radius { get; }

        public double Angle { get; }

        public Quadrants Quadrant { get; }

        public Point Point { get; }

        public PolarCoordinate(CartesianCoordinate cartesianCoordinate)
        {
            CartesianCoordinate = cartesianCoordinate;
            var x = cartesianCoordinate.X;
            var y = cartesianCoordinate.Y;            

            Point = cartesianCoordinate.Point;

            Radius = Math.Sqrt((x * x) + (y * y));

            if (y == 0 && x > 0)
            {
                Angle = 0.0;
                Quadrant = Quadrants.YZeroXPositive;
            }
            else if (y == 0 && x < 0)
            {
                Angle = Math.PI;
                Quadrant = Quadrants.YZeroXNegative;
            }
            else if (x == 0 && y > 0)
            {
                Angle = Math.PI / 2;
                Quadrant = Quadrants.XZeroYPositive;
            }
            else if (x == 0 && y < 0)
            {
                Angle = -(Math.PI / 2);
                Quadrant = Quadrants.XZeroYNegative;
            }
            else 
            {
                Angle = Math.Atan2(y, x);
                if (Angle > 0 && Angle < Math.PI / 2)
                {
                    Quadrant = Quadrants.FirstQuadrant;
                }
                else if (Angle > Math.PI / 2 && Angle <= Math.PI)
                {
                    Quadrant = Quadrants.SecondQuadrant;
                }
                else if (Angle > -Math.PI && Angle < -(Math.PI / 2) )
                {
                    Quadrant = Quadrants.ThirdQuadrant;
                }
                else
                {
                    Quadrant = Quadrants.ForthQuadrant;
                }
            }                          
        }
    }
}
