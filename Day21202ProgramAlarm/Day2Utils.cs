namespace Day21202ProgramAlarm
{
    public class Day2Utils
    {
        public static int[] RunProgram(int[] input)
        {
            var output = new int[input.Length];
            input.CopyTo(output, 0);

            var opcodeIndex = 0;

            while (true)
            {
                var firstPosition = opcodeIndex + 1;
                var secondPosition = firstPosition + 1;
                var storePosition = secondPosition + 1;

                switch (output[opcodeIndex])
                {
                    case (int) Instructions.Add:
                        output[output[storePosition]] = output[output[firstPosition]] + output[output[secondPosition]];
                        break;
                    case (int) Instructions.Multiply:
                        output[output[storePosition]] = output[output[firstPosition]] * output[output[secondPosition]];
                        break;
                    case (int)Instructions.Halt:
                        return output;

                }

                opcodeIndex += 4;
            }
        }

    }
}
