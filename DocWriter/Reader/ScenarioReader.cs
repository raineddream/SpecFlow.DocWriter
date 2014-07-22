using System;
using System.Globalization;
using System.IO;
using System.Text;
using Rain.SpecFlow.DocWriter.Reader.IO;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class ScenarioReader : IReader<Scenario>
    {
        private const int KeywordScenarioLength = 8;
        private readonly string _currentLine;
        private readonly BufferedReader _reader;

        public ScenarioReader(string currentLine, BufferedReader reader)
        {
            _currentLine = currentLine;
            _reader = reader;
        }

        public Scenario Read()
        {
            var scenarioDesc = new StringBuilder();

            string line = _currentLine;
            while (line != null)
            {
                if (IsScenarioDescription(line))
                {
                    scenarioDesc.Append(ExtractScenarioDescription(line));
                }

                line = _reader.ReadLine();
            }

            return new Scenario(scenarioDesc.ToString());
        }

        public static bool CanReadIn(string line)
        {
            return line.StartsWith("scenario", true, CultureInfo.DefaultThreadCurrentCulture);
        }

        private bool IsScenarioDescription(string line)
        {
            return CanReadIn(line);
        }

        private string ExtractScenarioDescription(string line)
        {
            return line.Substring(KeywordScenarioLength + 1).Trim();
        }
    }
}