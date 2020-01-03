using System;
using System.Collections.Generic;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class Day5Utils
    {
        static long relativeBase = 0;
        public static List<long> RunProgram(long[] program, List<long> externalInput)
        {
            relativeBase = 0;
            var programCopy = new long[program.Length * 100];
            program.CopyTo(programCopy, 0);

            long opcodeIndex = 0;       
            var externalInputIndex = 0;

            var opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);
            var outputs = new List<long>();
            while (true)
            {            
                switch (opcodeAndModes.Opcode)
                {
                    case (int)Instructions.Add:
                        ExecuteAddOrMultiply((int)Instructions.Add, programCopy, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.Multiply:
                        ExecuteAddOrMultiply((int)Instructions.Multiply, programCopy, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.Save:

                        if (opcodeAndModes.FirstParamMode == ParameterMode.RELATIVE)
                        {
                            var relativePosition = programCopy[opcodeIndex + 1] + relativeBase;
                            programCopy[relativePosition] = externalInput[externalInputIndex];
                        }
                        else
                        {
                            programCopy[programCopy[opcodeIndex + 1]] = externalInput[externalInputIndex];
                        }
                        
                        opcodeIndex += 2;
                        externalInputIndex += 1;
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.Output:
                        var outputValue = GetParamValue(programCopy, opcodeIndex + 1, opcodeAndModes.FirstParamMode);
                        outputs.Add(outputValue);

                        opcodeIndex += 2;
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.JumpIfTrue:
                        opcodeIndex = GetOpcodeIndexAfterJumpIf((int)Instructions.JumpIfTrue, programCopy, opcodeIndex, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.JumpIfFalse:
                        opcodeIndex = GetOpcodeIndexAfterJumpIf((int)Instructions.JumpIfFalse, programCopy, opcodeIndex, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.LessThan:
                        ExecuteLessThanOrEquals((int)Instructions.LessThan, programCopy, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.Equals:
                        ExecuteLessThanOrEquals((int)Instructions.Equals, programCopy, opcodeIndex, opcodeAndModes);

                        opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.AdjustRelativeBase:
                        var outputVal = GetParamValue(programCopy, opcodeIndex + 1, opcodeAndModes.FirstParamMode);

                        relativeBase += outputVal;
                        opcodeIndex += 2;
                        opcodeAndModes = new OpcodeAndModes(programCopy, opcodeIndex);

                        break;
                    case (int)Instructions.Halt:
                        return outputs;
                }

            }
        }
        private static long GetParamValue(long[] programCopy, long position, ParameterMode parameterMode)
        {
            switch (parameterMode)
            {
                case ParameterMode.POSITION:
                    return programCopy[programCopy[position]];
                case ParameterMode.IMMEDIATE:
                    return programCopy[position];
                case ParameterMode.RELATIVE:
                    var relativePosition = relativeBase + programCopy[position];
                    return programCopy[relativePosition];
                default:
                    throw new Exception("Unknown parameter mode");
            }
        }

        private static long GetOpcodeIndexAfterJumpIf(int jumpIfCode, long[] programCopy, long opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var jumpIfFirstPosition = opcodeIndex + 1;
            var jumpIfSecondPosition = jumpIfFirstPosition + 1;

            var firstJumpIfParamValue = GetParamValue(programCopy, jumpIfFirstPosition, opcodeAndModes.FirstParamMode);
            var secondJumpIfParamValue = GetParamValue(programCopy, jumpIfSecondPosition, opcodeAndModes.SecondParamMode);

            opcodeIndex += 3;
            var jumpIfTrueCriterion = (int)Instructions.JumpIfTrue == jumpIfCode && firstJumpIfParamValue != 0;
            var jumpIfFalseCriterion = (int)Instructions.JumpIfFalse == jumpIfCode && firstJumpIfParamValue == 0;

            if (jumpIfTrueCriterion || jumpIfFalseCriterion)
            {
                opcodeIndex = secondJumpIfParamValue;
            }

            return opcodeIndex;
        }

        private static void ExecuteAddOrMultiply(int jumpIfCode, long[] programCopy, long opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var storePosition = secondPosition + 1;

            var firstParamValue = GetParamValue(programCopy, firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(programCopy, secondPosition, opcodeAndModes.SecondParamMode);
            var thirdParamValue = programCopy[storePosition];

            if (opcodeAndModes.ThirdParamMode == ParameterMode.RELATIVE)
            {
                thirdParamValue = GetParamValue(programCopy, secondPosition, opcodeAndModes.ThirdParamMode);
            }

            programCopy[thirdParamValue] = firstParamValue + secondParamValue;
            if ((int)Instructions.Multiply == jumpIfCode)
            {
                programCopy[thirdParamValue] = firstParamValue * secondParamValue;
            }
        }
        private static void ExecuteLessThanOrEquals(int jumpIfCode, long[] programCopy, long opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var thirdPosition = secondPosition + 1;

            var firstParamValue = GetParamValue(programCopy, firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(programCopy, secondPosition, opcodeAndModes.SecondParamMode);
            var thirdParamValue = programCopy[thirdPosition];

            if (opcodeAndModes.ThirdParamMode == ParameterMode.RELATIVE)
            {
                thirdParamValue = GetParamValue(programCopy, secondPosition, opcodeAndModes.ThirdParamMode);
            }

            var lessThanCriterion = (int)Instructions.LessThan == jumpIfCode && firstParamValue < secondParamValue;
            var equalsCriterion = (int)Instructions.Equals == jumpIfCode && firstParamValue == secondParamValue;

            programCopy[thirdParamValue] = 0;

            if (lessThanCriterion || equalsCriterion)
            {
                programCopy[thirdParamValue] = 1;
            }
        }
    }
}
