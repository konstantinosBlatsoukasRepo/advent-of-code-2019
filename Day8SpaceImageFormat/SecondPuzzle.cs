using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8SpaceImageFormat
{
    public class SecondPuzzle
    {
        private readonly string _input;
        private const int WIDTH = 25;
        private const int HEIGHT = 6;

        public SecondPuzzle(string input)
        {
            _input = input;
        }

        public void GetSolution()
        {
            var input = _input
                .Select(p => int.Parse(p.ToString()))
                .ToArray();

            var layers = new Layers(input, WIDTH, HEIGHT);
            var allLayers = layers.layers;

            var decodedImage = new int[HEIGHT, WIDTH];
            for (var row = 0; row < HEIGHT; row++)
            {
                for (var column = 0; column < WIDTH; column++)
                {
                    var previousColor = (int)PixelColors.TRANSPARENT;
                    previousColor = DecodePixel(allLayers, decodedImage, row, column, previousColor);
                }
            }

            Console.WriteLine($"Second puzzle: ");
            PrintResult(decodedImage);
        }

        private static int DecodePixel(List<Layer> allLayers, int[,] decodedImage, int row, int column, int previousColor)
        {
            for (int layerIndex = allLayers.Count - 1; layerIndex >= 0; layerIndex--)
            {
                var currentColor = allLayers[layerIndex].pixels[row, column];
                switch (currentColor)
                {
                    case (int)PixelColors.TRANSPARENT:
                        decodedImage[row, column] = previousColor;
                        break;
                    case (int)PixelColors.BLACK:
                        decodedImage[row, column] = (int)PixelColors.BLACK;
                        previousColor = (int)PixelColors.BLACK;
                        break;
                    case (int)PixelColors.WHITE:
                        decodedImage[row, column] = (int)PixelColors.WHITE;
                        previousColor = (int)PixelColors.WHITE;
                        break;
                    default:
                        break;
                }
            }
            return previousColor;
        }

        private void PrintResult(int[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        Console.Write(string.Format("{0} ", " "));
                    }
                    else
                    {
                        Console.Write(string.Format("{0} ", arr[i, j]));
                    }
                    
                }
                Console.Write(Environment.NewLine);
            }
        }

    }
}
