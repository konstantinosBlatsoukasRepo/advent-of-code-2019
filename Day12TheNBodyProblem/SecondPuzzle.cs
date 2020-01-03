using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day12TheNBodyProblem
{
    public class SecondPuzzle
    {

        private readonly string _input;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public BigInteger GetSolution()
        {
            FirstPuzzle firstPuzzle = new FirstPuzzle(_input);

            var lines = _input.Split("\r\n").ToList();

            var moonsForX = firstPuzzle.ParseMoons(lines);
            var moonsForY = moonsForX.ConvertAll(x => new Moon { XPosition = x.XPosition, YPosition = x.YPosition, ZPosition = x.ZPosition, XVelocity = x.XVelocity, YVelocity = x.YVelocity, ZVelocity = x.ZVelocity });
            var moonsForZ = moonsForY.ConvertAll(x => new Moon { XPosition = x.XPosition, YPosition = x.YPosition, ZPosition = x.ZPosition, XVelocity = x.XVelocity, YVelocity = x.YVelocity, ZVelocity = x.ZVelocity });

            var stepsX = 0;
            var currentXPosVel = "";
            var seenX = new HashSet<string>();
            while (!seenX.Contains(currentXPosVel))
            {
                seenX.Add(currentXPosVel);
                firstPuzzle.SimulateSingleStep(moonsForX);
                currentXPosVel = $"{moonsForX[0].XPosition}{moonsForX[1].XPosition}{moonsForX[2].XPosition}{moonsForX[3].XPosition}{moonsForX[0].XVelocity}{moonsForX[1].XVelocity}{moonsForX[2].XVelocity}{moonsForX[3].XVelocity}";             
                stepsX += 1;
            }
            Console.WriteLine(stepsX);

            var stepsY = 0;
            var currentYPosVel = "";
            var seenY = new HashSet<string>();
            while (!seenY.Contains(currentYPosVel))
            {
                seenY.Add(currentYPosVel);
                firstPuzzle.SimulateSingleStep(moonsForY);
                currentYPosVel = $"{moonsForY[0].YPosition}{moonsForY[1].YPosition}{moonsForY[2].YPosition}{moonsForY[3].YPosition}{moonsForY[0].YVelocity}{moonsForY[1].YVelocity}{moonsForY[2].YVelocity}{moonsForY[3].YVelocity}";
                stepsY += 1;        
            }

            Console.WriteLine(stepsY);

            var stepsZ = 0;
            var currentZPosVel = "";
            var seenZ = new HashSet<string>();
            while (!seenZ.Contains(currentZPosVel))
            {
                seenZ.Add(currentZPosVel);
                firstPuzzle.SimulateSingleStep(moonsForZ);
                currentZPosVel = $"{moonsForZ[0].ZPosition}{moonsForZ[1].ZPosition}{moonsForZ[2].ZPosition}{moonsForZ[3].ZPosition}{moonsForZ[0].ZVelocity}{moonsForZ[1].ZVelocity}{moonsForZ[2].ZVelocity}{moonsForZ[3].ZVelocity}";             
                stepsZ += 1;
            }
            Console.WriteLine(stepsZ);

            var xyLcm = stepsX * stepsY / BigInteger.GreatestCommonDivisor(stepsX, stepsY);
            var xyzLcm = xyLcm * new BigInteger(stepsZ) / BigInteger.GreatestCommonDivisor(xyLcm, new BigInteger(stepsZ));


            return xyLcm * xyzLcm;
        }


    }
}
