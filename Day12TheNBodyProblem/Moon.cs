using System;

namespace Day12TheNBodyProblem
{
    public class Moon
    {
        public int Id { get; set; }

        public int XPosition { get; set; } = 0;

        public int YPosition { get; set; } = 0;

        public int ZPosition { get; set; } = 0;

        public int XVelocity { get; set; } = 0;

        public int YVelocity { get; set; } = 0;

        public int ZVelocity { get; set; } = 0;

        public int ComputePotentialEnergy(Moon moon) => Math.Abs(moon.XPosition) + Math.Abs(moon.YPosition) + Math.Abs(moon.ZPosition);

        public int ComputeKineticEnergy(Moon moon) => Math.Abs(moon.XVelocity) + Math.Abs(moon.YVelocity) + Math.Abs(moon.ZVelocity);
        public int ComputeTotalEnergy(Moon moon) => ComputePotentialEnergy(moon) * ComputeKineticEnergy(moon);
    }
}
