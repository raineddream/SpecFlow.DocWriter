using System.Globalization;
using System.Text;
using Rain.SpecFlow.DocWriter.IO;

namespace Rain.SpecFlow.DocWriter.Spec
{
    public class ScenarioReader : IReader<Scenario>
    {
        private const int KeywordScenarioLength = 8;
        private readonly BufferedReader _reader;
        private bool _hasReadInThisScenario;

        public ScenarioReader(BufferedReader reader)
        {
            _reader = reader;
        }

        public Scenario Read()
        {
            var scenarioDesc = new StringBuilder();
            _hasReadInThisScenario = false;

            var scenario = new Scenario();

            string line = _reader.ReadLine();
            while (line != null)
            {
                if (IsGivenStatement(line))
                {
                    scenario.AddStatement(CreateGivenStatement(line));
                }
                else if (IsScenarioDescription(line))
                {
                    if (_hasReadInThisScenario)
                    {
                        _reader.BackToPrevLine();
                        break;
                    }
                    else
                    {
                        _hasReadInThisScenario = true;
                        scenarioDesc.Append(ExtractScenarioDescription(line));
                    }
                }

                line = _reader.ReadLine();
            }

            scenario.Description = scenarioDesc.ToString();

            return scenario;
        }

        private IStatement CreateGivenStatement(string line)
        {
            return new GivenStatement(line);
        }

        private bool IsGivenStatement(string line)
        {
            return line.StartsWith("given", true, CultureInfo.DefaultThreadCurrentCulture);
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