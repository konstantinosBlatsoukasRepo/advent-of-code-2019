using Day5SunnyWithAChanceOfAsteroids;
using System;
using System.Collections.Generic;

namespace Day9SensorBoost
{
    public class IntCodeComputer
    {
        private readonly long[] _program;

        public List<long> Inputs = new List<long>();

        public List<long> Outputs = new List<long>();

        private long _relativeBase = 0;

        private long _opcodeIndex = 0;

        private long _lastOutput = 0;

        public bool Finished = false;

        private int externalInputIndex = 0;

        private OpcodeAndModes opcodeAndModes;

        public IntCodeComputer(long[] program)
        {
            _program = new long[program.Length * 100];
            program.CopyTo(_program, 0);
            opcodeAndModes = new OpcodeAndModes(_program, 0);
        }

        public long GetOutput()
        {                                                                        
            while (true)
            {
                switch (opcodeAndModes.Opcode)
                {
                    case (int)Instructions.Add:
                        ExecuteAddOrMultiply((int)Instructions.Add, opcodeAndModes);

                        _opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        break;
                    case (int)Instructions.Multiply:
                        ExecuteAddOrMultiply((int)Instructions.Multiply, opcodeAndModes);

                        _opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        break;
                    case (int)Instructions.Save:

                        if (opcodeAndModes.FirstParamMode == ParameterMode.RELATIVE)
                        {
                            var relativePosition = _program[_opcodeIndex + 1] + _relativeBase;
                            _program[relativePosition] = Inputs[externalInputIndex];
                        }
                        else
                        {
                            _program[_program[_opcodeIndex + 1]] = Inputs[externalInputIndex];
                        }
                        
                        _opcodeIndex += 2;
                        externalInputIndex += 1;
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        break;
                    case (int)Instructions.Output:
                        var output = GetParamValue(_opcodeIndex + 1, opcodeAndModes.FirstParamMode);
                        _opcodeIndex += 2;
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        Outputs.Add(output);

                        _lastOutput = output;
                        return output;

                    case (int)Instructions.JumpIfTrue:                        
                        UpdateOpcodeIndexAfterJumpIf((int)Instructions.JumpIfTrue, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        break;
                    case (int)Instructions.JumpIfFalse:
                        UpdateOpcodeIndexAfterJumpIf((int)Instructions.JumpIfFalse, opcodeAndModes);
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        break;
                    case (int)Instructions.LessThan:
                        ExecuteLessThanOrEquals((int)Instructions.LessThan, opcodeAndModes);

                        _opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        break;
                    case (int)Instructions.Equals:
                        ExecuteLessThanOrEquals((int)Instructions.Equals, opcodeAndModes);

                        _opcodeIndex += 4;
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);

                        break;
                    case (int)Instructions.AdjustRelativeBase:
                        var outputValue = GetParamValue(_opcodeIndex + 1, opcodeAndModes.FirstParamMode);

                        _relativeBase += outputValue;
                        _opcodeIndex += 2;
                        opcodeAndModes = new OpcodeAndModes(_program, _opcodeIndex);
                        
                        break;
                    case (int)Instructions.Halt:                                              
                        Finished = true;
                        return -1;
                }

            }
        }
        private long GetParamValue(long position, ParameterMode parameterMode)
        {
            switch (parameterMode)
            {
                case ParameterMode.POSITION:
                    return _program[_program[position]];
                case ParameterMode.IMMEDIATE:
                    return _program[position];
                case ParameterMode.RELATIVE:
                    var relativePosition = _relativeBase + _program[position];
                    return _program[relativePosition];
                default:
                    throw new Exception("Unknown parameter mode");
            }
        }

        private void UpdateOpcodeIndexAfterJumpIf(int instructionCode, OpcodeAndModes opcodeAndModes)
        {
            var jumpIfFirstPosition = _opcodeIndex + 1;
            var jumpIfSecondPosition = jumpIfFirstPosition + 1;

            var firstJumpIfParamValue = GetParamValue(jumpIfFirstPosition, opcodeAndModes.FirstParamMode);
            var secondJumpIfParamValue = GetParamValue(jumpIfSecondPosition, opcodeAndModes.SecondParamMode);

            _opcodeIndex += 3;
            var jumpIfTrueCriterion = (int)Instructions.JumpIfTrue == instructionCode && firstJumpIfParamValue != 0;
            var jumpIfFalseCriterion = (int)Instructions.JumpIfFalse == instructionCode && firstJumpIfParamValue == 0;

            if (jumpIfTrueCriterion || jumpIfFalseCriterion)
            {
                _opcodeIndex = secondJumpIfParamValue;
            }
        }

        private void ExecuteAddOrMultiply(int instructionCode, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = _opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var storePosition = secondPosition + 1;

            var firstParamValue = GetParamValue(firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(secondPosition, opcodeAndModes.SecondParamMode);

            var thirdParamValue = _program[storePosition];
            if (opcodeAndModes.ThirdParamMode == ParameterMode.RELATIVE)
            {
                thirdParamValue = _program[storePosition] + _relativeBase;
            }

            _program[thirdParamValue] = firstParamValue + secondParamValue;
            if ((int)Instructions.Multiply == instructionCode)
            {
                _program[thirdParamValue] = firstParamValue * secondParamValue;
            }
        }
        private void ExecuteLessThanOrEquals(int jumpIfCode, OpcodeAndModes opcodeAndModes)
        {
            var firstPosition = _opcodeIndex + 1;
            var secondPosition = firstPosition + 1;
            var thirdPosition = secondPosition + 1;

            var firstParamValue = GetParamValue(firstPosition, opcodeAndModes.FirstParamMode);
            var secondParamValue = GetParamValue(secondPosition, opcodeAndModes.SecondParamMode);

            var thirdParamValue = _program[thirdPosition];
            if (opcodeAndModes.ThirdParamMode == ParameterMode.RELATIVE)
            {
                thirdParamValue = _program[thirdPosition] + _relativeBase;
            }

            var lessThanCriterion = (int)Instructions.LessThan == jumpIfCode && firstParamValue < secondParamValue;
            var equalsCriterion = (int)Instructions.Equals == jumpIfCode && firstParamValue == secondParamValue;

            _program[thirdParamValue] = 0;

            if (lessThanCriterion || equalsCriterion)
            {
                _program[thirdParamValue] = 1;
            }
        }

        public long Run()
        {
            while (!Finished)
            {
                GetOutput();
            }

            return _lastOutput;        
        }
    }
}
