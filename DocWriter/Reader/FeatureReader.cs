using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class FeatureReader : IReader<Feature>
    {
        private const int KeywordFeatureLength = 7;
        private readonly TextReader _reader;
        private bool _isInFeatureDesc;
        private bool _needToExtractFeatureKeyword;

        public FeatureReader(TextReader reader)
        {
            _reader = reader;
        }

        public Feature Read()
        {
            var featureDesc = new StringBuilder();

            string line = _reader.ReadLine();
            var scenarios = new List<Scenario>();
            while (line != null)
            {
                if (ScenarioReader.CanReadIn(line))
                {
                    scenarios.Add(new ScenarioReader(line, _reader).Read());
                }
                else if (IsFeatureDescription(line))
                {
                    featureDesc.Append(ExtractFeatureDescription(line));
                } 

                line = _reader.ReadLine();
            }


            var feature = new Feature(featureDesc.ToString());
            foreach (var scenario in scenarios)
            {
                feature.AddScenario(scenario);
            }
            return feature;
        }

        private bool IsFeatureDescription(string line)
        {
            if (_isInFeatureDesc)
            {
                _needToExtractFeatureKeyword = false;
                return true;
            }

            if (line.StartsWith("feature", true, CultureInfo.DefaultThreadCurrentCulture))
            {
                _isInFeatureDesc = true;
                _needToExtractFeatureKeyword = true;
                return true;
            }

            return false;
        }

        private string ExtractFeatureDescription(string line)
        {
            if (!_needToExtractFeatureKeyword)
            {
                return line;
            }

            return line.Substring(KeywordFeatureLength + 1).Trim();
        }
    }
}