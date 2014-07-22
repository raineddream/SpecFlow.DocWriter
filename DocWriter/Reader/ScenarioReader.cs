using System.Globalization;
using System.IO;
using System.Text;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class ScenarioReader : IReader<Scenario>
    {
        private readonly string _currentLine;
        private readonly TextReader _reader;

        public ScenarioReader(string currentLine, TextReader reader)
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

            return null;
        }

        private bool IsScenarioDescription(string line)
        {
            return line.StartsWith("scenario", true, CultureInfo.DefaultThreadCurrentCulture);
        }

        private string ExtractScenarioDescription(string line)
        {
            return line.Substring("scenario".Length + 1).Trim();
        }
    }
}