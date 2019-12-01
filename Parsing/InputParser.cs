using System.IO;

namespace AdventOfCode2019
{
    public class InputParser
    {
        private readonly string _fileName;

        public InputParser(string fileName)
        {
            _fileName = fileName;
        }

        public string ReadInput()
        {
            using (StreamReader sr = new StreamReader(_fileName))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
