using System.Globalization;
using System.IO;
using System.Text;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class FeatureReader : IReader<Feature>
    {
        private readonly TextReader _reader;
        private static readonly int KEYWORD_FEATURE_LENGTH = 7;
        private readonly string _specFullName;
        private bool isInFeatureDesc;
        private bool needToExtractFeatureKeyword;

        public FeatureReader(TextReader reader)
        {
            _reader = reader;
        }

        public Feature Read()
        {
            var featureDesc = new StringBuilder();

            string line = _reader.ReadLine();
            while (line != null)
            {
                if (IsFeatureDescription(line))
                {
                    featureDesc.Append(ExtractFeatureDescription(line));
                }

                line = _reader.ReadLine();
            }


            return new Feature(featureDesc.ToString());
        }

        private bool IsFeatureDescription(string line)
        {
            if (isInFeatureDesc)
            {
                needToExtractFeatureKeyword = false;
                return true;
            }

            if (line.StartsWith("feature", true, CultureInfo.DefaultThreadCurrentCulture))
            {
                isInFeatureDesc = true;
                needToExtractFeatureKeyword = true;
                return true;
            }

            return false;
        }

        private string ExtractFeatureDescription(string line)
        {
            if (!needToExtractFeatureKeyword)
            {
                return line;
            }

            return line.Substring(KEYWORD_FEATURE_LENGTH + 1).Trim();
        }
    }
}