using System.Collections.Generic;

namespace Day8SpaceImageFormat
{
    public class Layers
    {
        public List<Layer> layers { get; set; }

        public Layers(int[] input, int width, int height)
        {
            var pixels = new int[height, width];
            layers = new List<Layer>();

            int row = 0;
            int column = 0;
            for (int index = 1; index <= input.Length; index++)
            {
                if (index % width == 0)
                {
                    pixels[row, column] = input[index - 1];
                    row += 1;
                    column = 0;
                }
                else
                {
                    pixels[row, column] = input[index - 1];
                    column += 1;
                }

                if (index % (width * height) == 0)
                {
                    layers.Add(new Layer(pixels));
                    row = 0;
                    column = 0;
                    pixels = new int[height, width];
                }
            }

        }

    }
}
