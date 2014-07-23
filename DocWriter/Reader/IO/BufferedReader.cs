using System.Collections.Generic;
using System.IO;

namespace Rain.SpecFlow.DocWriter.Reader.IO
{
    public class BufferedReader
    {
        private readonly List<string> _lines;
        private int _readAt;

        public BufferedReader(TextReader reader)
        {
            _lines = new List<string>();

            ReadInAllLines(reader);
            _readAt = 0;
        }

        private void ReadInAllLines(TextReader reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                _lines.Add(line.Trim());

                line = reader.ReadLine();
            }
        }

        public string ReadLine()
        {
            return _readAt >= _lines.Count ? null : _lines[_readAt++];
        }

        public void BackToPrevLine()
        {
            if (_readAt > 0)
            {
                _readAt--;
            }
        }
    }
}