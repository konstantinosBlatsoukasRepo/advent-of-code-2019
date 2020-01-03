using Day9SensorBoost;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day11SpacePolice
{

    enum Turn
    {
        Left,
        Right
    }
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum Color
    {
        Black,
        White
    }

    public class HullRobot
    {
        private IntCodeComputer _intCodeComputer;
        private Direction _currentDirection =  Direction.Up;
        private Color _currentColor;
        private int _currentY = 0;
        private int _currentX = 0;

        public readonly Dictionary<string, Color> PanelsPainted = new Dictionary<string, Color>();
        public int MaxY = int.MinValue;
        public int MinY = int.MaxValue;
        public int MaxX = int.MinValue;
        public int MinX = int.MaxValue;

        public HullRobot(IntCodeComputer intCodeComputer, int firstPanelColor)
        {
            _intCodeComputer = intCodeComputer;
            _currentColor = (Color) firstPanelColor;
        }

        public void Paint()
        {
            _intCodeComputer.Inputs = new List<long> {};

            PanelsPainted[$"({_currentX},{_currentY})"] = _currentColor;

            while (!_intCodeComputer.Finished)
            {
                if (_currentX < MinX) { MinX = _currentX; }
                if (_currentY < MinY) { MinY = _currentY; }

                if (_currentX > MaxX) { MaxX = _currentX; }
                if (_currentY > MaxY) { MaxY = _currentY; }

                if (PanelsPainted.ContainsKey($"({_currentX},{_currentY})"))
                {
                    var panelColor = PanelsPainted[$"({_currentX},{_currentY})"];
                    _intCodeComputer.Inputs.Add((long) panelColor);
                }
                else
                {
                    PanelsPainted[$"({_currentX},{_currentY})"] = (long) Color.Black;
                    _intCodeComputer.Inputs.Add((long)Color.Black);
                }

                var colorToDraw = _intCodeComputer.GetOutput();
                var leftOrRight = _intCodeComputer.GetOutput();                

                PanelsPainted[$"({_currentX},{_currentY})"] = (Color) colorToDraw;
                UpdateΧAndΥ(leftOrRight);
            }

            
        }

        private void UpdateΧAndΥ(long leftOrRight)
        {
            switch (leftOrRight)
            {
                case (long) Turn.Left:
                    UpdateOnLeftTurn();
                    break;
                case (long) Turn.Right:
                    UpdateOnRightTurn();
                    break;
            }
        }

        private void UpdateOnLeftTurn()
        {
            switch (_currentDirection)
            {
                case Direction.Up:
                    _currentDirection = Direction.Left;
                    _currentX -= 1;                    
                    break;
                case Direction.Down:
                    _currentDirection = Direction.Right;
                    _currentX += 1;
                    break;                    
                case Direction.Left:
                    _currentDirection = Direction.Down;
                    _currentY -= 1;
                    break;
                case Direction.Right:
                    _currentDirection = Direction.Up;
                    _currentY += 1;
                    break;         
            }
        }

        private void UpdateOnRightTurn()
        {
            switch (_currentDirection)
            {
                case Direction.Up:
                    _currentDirection = Direction.Right;
                    _currentX += 1;
                    break;
                case Direction.Down:
                    _currentDirection = Direction.Left;
                    _currentX -= 1;
                    break;
                case Direction.Left:
                    _currentDirection = Direction.Up;
                    _currentY += 1;
                    break;
                case Direction.Right:
                    _currentDirection = Direction.Down;
                    _currentY -= 1;
                    break;
            }
        }

        public int GetTotalPanelsPainted() => PanelsPainted.Count;

    }
}
