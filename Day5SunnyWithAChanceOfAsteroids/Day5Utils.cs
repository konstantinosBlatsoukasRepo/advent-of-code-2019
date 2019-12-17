using System.Collections.Generic;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class Day5Utils
    {
        public static int RunProgram(int[] input, List<int> externalInput)
        {
            var output = new int[input.Length];
            input.CopyTo(output, 0);

            var opcodeIndex = 0;
            var opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

            var externalInputIndex = 0;
            var prints = new List<int>();
            while (true)
            {
                switch (opcodeAndModes.Opcode)
                {
                    case (int)Instructions.Add:
                        ExecuteAddOrMultiply((int)Instructions.Add, output, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.Multiply:
                        ExecuteAddOrMultiply((int)Instructions.Multiply, output, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.Save:
                        output[output[opcodeIndex + 1]] = externalInput[externalInputIndex];
                        opcodeIndex += 2;
                        externalInputIndex += 1;
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.Output:
                        var outputValue = GetParamValue(output, opcodeIndex + 1, opcodeAndModes.FirstParamMode);
                        prints.Add(outputValue);

                        opcodeIndex += 2;
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.JumpIfTrue:
                        opcodeIndex = GetOpcodeIndexAfterJumpIf((int)Instructions.JumpIfTrue, output, opcodeIndex, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.JumpIfFalse:
                        opcodeIndex = GetOpcodeIndexAfterJumpIf((int)Instructions.JumpIfFalse, output, opcodeIndex, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.LessThan:
                        ExecuteLessThanOrEquals((int)Instructions.LessThan, output, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.Equals:
                        ExecuteLessThanOrEquals((int)Instructions.Equals, output, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(output, opcodeIndex);

                        break;
                    case (int)Instructions.Halt:
                        return prints[prints.Count - 1];
                }

            }
        }
        private static int GetParamValue(int[] output, int position, ParameterMode parameterMode)
        {
            return parameterMode == ParameterMode.POSITION ? output[output[position]] : output[position];
        }

        private static int GetOpcodeIndexAfterJumpIf(int jumpIfCode, int[] output, int opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var jumpIfFirstPosition = opcodeIndex + 1;
            var jumpIfSecondPosition = jumpIfFirstPosition + 1;

            var firstJumpIfParamValue = GetParamValue(output, jumpIfFirstPosition, opcodeAndModes.FirstParamMode);
            var secondJumpIfParamValue = GetParamValue(output, jumpIfSecondPosition, opcodeAndModes.SecondParamMode);

            opcodeIndex += 3;
            var jumpIfTrueCriterion = (int)Instructions.JumpIfTrue == jumpIfCode && firstJumpIfParamValue != 0;
            var jumpIfFalseCriterion = (int)Instructions.JumpIfFalse == jumpIfCode && firstJumpIfParamValue == 0;

            if (jumpIfTrueCriterion || jumpIfFalseCriterion)
            {
                opcodeIndex = secondJumpIfParamValue;
            }

            return opcodeIndex;
        }

        private static void ExecuteAddOrMultiply(int jumpIfCode, int[] output, int opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var storePosition = secondPosition + 1;

            var firstParamValue = GetParamValue(output, firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(output, secondPosition, opcodeAndModes.SecondParamMode);

            output[output[storePosition]] = firstParamValue + secondParamValue;
            if ((int)Instructions.Multiply == jumpIfCode)
            {
                output[output[storePosition]] = firstParamValue * secondParamValue;
            }
        }
        private static void ExecuteLessThanOrEquals(int jumpIfCode, int[] output, int opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var thirdPosition = secondPosition + 1;

            var firstParamValue = GetParamValue(output, firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(output, secondPosition, opcodeAndModes.SecondParamMode);

            var lessThanCriterion = (int)Instructions.LessThan == jumpIfCode && firstParamValue < secondParamValue;
            var equalsCriterion = (int)Instructions.Equals == jumpIfCode && firstParamValue == secondParamValue;

            output[output[thirdPosition]] = 0;

            if (lessThanCriterion || equalsCriterion)
            {
                output[output[thirdPosition]] = 1;
            }
        }
    }
}
