using Day5SunnyWithAChanceOfAsteroids;
using System;
using System.Collections.Generic;


namespace Day7AmplificationCircuit
{
    public class Amplifier
    {
        public long[] Program { get; set; }

        public long OpcodeIndex { get; set; } = 0;

        private readonly List<long> Inputs;

        public Amplifier(long[] program, long phase, long opcodeIndex)
        {
            Program = new long[program.Length * 100];
            program.CopyTo(Program, 0);

            Inputs = new List<long>{ phase };

            Program = Program;
            OpcodeIndex = opcodeIndex;
        }        

        public long RunProgram(long inputValue)
        {
            Inputs.Add(inputValue);
            var externalInputIndex = 0;

            var opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

            while (true)
            {         
                switch (opcodeAndModes.Opcode)
                {
                    case (int)Instructions.Add:
                        ExecuteAddOrMultiply((int)Instructions.Add, OpcodeIndex, opcodeAndModes);

                        OpcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

                        break;
                    case (int)Instructions.Multiply:
                        ExecuteAddOrMultiply((int)Instructions.Multiply, OpcodeIndex, opcodeAndModes);

                        OpcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

                        break;
                    case (int)Instructions.Save:                        
                        Program[Program[OpcodeIndex + 1]] = Inputs[0];
                        Inputs.RemoveAt(0);

                        OpcodeIndex += 2;
                        externalInputIndex += 1;
                        opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

                        break;
                    case (int)Instructions.Output:
                        var outputValue = GetParamValue(OpcodeIndex + 1, opcodeAndModes.FirstParamMode);                        

                        OpcodeIndex += 2;
                        return outputValue;
                    case (int)Instructions.JumpIfTrue:
                        OpcodeIndex = GetOpcodeIndexAfterJumpIf((int)Instructions.JumpIfTrue, OpcodeIndex, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

                        break;
                    case (int)Instructions.JumpIfFalse:
                        OpcodeIndex = GetOpcodeIndexAfterJumpIf((int)Instructions.JumpIfFalse, OpcodeIndex, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

                        break;
                    case (int)Instructions.LessThan:
                        ExecuteLessThanOrEquals((int)Instructions.LessThan, OpcodeIndex, opcodeAndModes);

                        OpcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

                        break;
                    case (int)Instructions.Equals:
                        ExecuteLessThanOrEquals((int)Instructions.Equals, OpcodeIndex, opcodeAndModes);

                        OpcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(Program, OpcodeIndex);

                        break;               
                    case (int)Instructions.Halt:
                        return -1;
                }
            }
        }

        private long GetParamValue(long position, ParameterMode parameterMode)
        {
            return parameterMode switch
            {
                ParameterMode.POSITION => Program[Program[position]],
                ParameterMode.IMMEDIATE => Program[position],
                _ => throw new Exception("Unknown parameter mode"),
            };
        }

        private long GetOpcodeIndexAfterJumpIf(int jumpIfCode, long opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var jumpIfFirstPosition = opcodeIndex + 1;
            var jumpIfSecondPosition = jumpIfFirstPosition + 1;

            var firstJumpIfParamValue = GetParamValue(jumpIfFirstPosition, opcodeAndModes.FirstParamMode);
            var secondJumpIfParamValue = GetParamValue(jumpIfSecondPosition, opcodeAndModes.SecondParamMode);

            opcodeIndex += 3;
            var jumpIfTrueCriterion = (int)Instructions.JumpIfTrue == jumpIfCode && firstJumpIfParamValue != 0;
            var jumpIfFalseCriterion = (int)Instructions.JumpIfFalse == jumpIfCode && firstJumpIfParamValue == 0;

            if (jumpIfTrueCriterion || jumpIfFalseCriterion)
            {
                opcodeIndex = secondJumpIfParamValue;
            }

            return opcodeIndex;
        }

        private void ExecuteAddOrMultiply(int jumpIfCode, long opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var storePosition = secondPosition + 1;

            var firstParamValue = GetParamValue(firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(secondPosition, opcodeAndModes.SecondParamMode);
            var thirdParamValue = Program[storePosition];

            Program[thirdParamValue] = firstParamValue + secondParamValue;
            if ((int)Instructions.Multiply == jumpIfCode)
            {
                Program[thirdParamValue] = firstParamValue * secondParamValue;
            }
        }

        private void ExecuteLessThanOrEquals(int jumpIfCode, long opcodeIndex, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var thirdPosition = secondPosition + 1;

            var firstParamValue = GetParamValue(firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(secondPosition, opcodeAndModes.SecondParamMode);
            var thirdParamValue = Program[thirdPosition];            

            var lessThanCriterion = (int)Instructions.LessThan == jumpIfCode && firstParamValue < secondParamValue;
            var equalsCriterion = (int)Instructions.Equals == jumpIfCode && firstParamValue == secondParamValue;

            Program[thirdParamValue] = 0;

            if (lessThanCriterion || equalsCriterion)
            {
                Program[thirdParamValue] = 1;
            }
        }
    }
}
