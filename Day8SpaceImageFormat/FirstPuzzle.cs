using System.Linq;

namespace Day8SpaceImageFormat
{
    public class FirstPuzzle
    {
        private readonly string _input;
        private const int WIDTH = 25;
        private const int HEIGHT = 6;

        public FirstPuzzle(string input)
        {
            _input = input;
        }

        public int GetSolution()
        {
            var input = _input
                .Select(p => int.Parse(p.ToString()))
                .ToArray();

            var layers = new Layers(input, HEIGHT, WIDTH);

            var minimumZerosLayer = layers.layers[0];
            var minimumTotalZeros = int.MaxValue;
            foreach (var layer in layers.layers)
            {
                var currentTotalZeros = CountNumberOccurences(layer, 0);
                if (currentTotalZeros < minimumTotalZeros)
                {
                    minimumTotalZeros = currentTotalZeros;
                    minimumZerosLayer = layer;
                }
            }

            var result = CountNumberOccurences(minimumZerosLayer, 1) * CountNumberOccurences(minimumZerosLayer, 2);

            return result;
        }

        private int CountNumberOccurences(Layer layer, int number)
        {
            var pixels = layer.pixels;
            var totalNumberOccurences = 0;
            for (int row = 0; row < layer.pixels.GetLength(0); row++)
            {
                for (int column = 0; column < layer.pixels.GetLength(1); column++)
                {
                    if (pixels[row, column] == number)
                    {
                        totalNumberOccurences += 1;
                    }
                }
            }
            return totalNumberOccurences;
        }

    }
}
