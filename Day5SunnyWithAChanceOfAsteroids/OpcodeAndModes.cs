using System;


namespace Day5SunnyWithAChanceOfAsteroids
{
    public class OpcodeAndModes
    {
        public int Opcode { get; set; }

        public ParameterMode FirstParamMode { get; set; }

        public ParameterMode SecondParamMode { get; set; }

        public OpcodeAndModes(int[] output, int opcodeIndex)
        {
            var opcodeAndModes = output[opcodeIndex].ToString().PadLeft(5, '0');
            Opcode = int.Parse(String.Concat(opcodeAndModes[3], opcodeAndModes[4]));

            FirstParamMode = GetParameterMode(opcodeAndModes[2]);
            SecondParamMode = GetParameterMode(opcodeAndModes[1]);
        }

        private ParameterMode GetParameterMode(char mode)
        {
            return mode == '0' ? ParameterMode.POSITION : ParameterMode.IMMEDIATE;
        }

    }
}
