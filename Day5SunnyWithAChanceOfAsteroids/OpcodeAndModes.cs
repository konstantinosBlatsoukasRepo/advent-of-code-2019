using System;


namespace Day5SunnyWithAChanceOfAsteroids
{
    public class OpcodeAndModes
    {
        public long Opcode { get; set; }

        public ParameterMode FirstParamMode { get; set; }

        public ParameterMode SecondParamMode { get; set; }

        public ParameterMode ThirdParamMode { get; set; }

        public OpcodeAndModes(long[] output, long opcodeIndex)
        {        
            var opcodeAndModes = output[opcodeIndex].ToString().PadLeft(5, '0');
            Opcode = long.Parse(String.Concat(opcodeAndModes[3], opcodeAndModes[4]));

            FirstParamMode = GetParameterMode(opcodeAndModes[2]);
            SecondParamMode = GetParameterMode(opcodeAndModes[1]);
            ThirdParamMode = GetParameterMode(opcodeAndModes[0]);
        }

        private ParameterMode GetParameterMode(char mode)
        {
            return mode switch
            {
                '0' => ParameterMode.POSITION,
                '1' => ParameterMode.IMMEDIATE,
                '2' => ParameterMode.RELATIVE,
                _ => throw new Exception("not a known paramter mode"),
            };
        }

    }
}
