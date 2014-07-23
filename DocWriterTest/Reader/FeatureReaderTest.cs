using System.IO;
using System.Text;
using NUnit.Framework;
using Rain.SpecFlow.DocWriter.Reader.IO;

namespace Rain.SpecFlow.DocWriter.Reader
{
    [TestFixture]
    public class FeatureReaderTest
    {
        [Test]
        public void Should_read_in_feature_description_without_blank_prefix()
        {
            string featureDesc = "Feature: Ording answers";
            var reader = new FeatureReader(ReadIn(featureDesc));

            Feature feature = reader.Read();

            Assert.That(feature.Description, Is.EqualTo("Ording answers"));
        }

        [Test]
        public void Should_read_in_feature_description_with_multi_lines_format()
        {
            var featureDesc = new StringBuilder();
            featureDesc.AppendLine("Feature: Ording answers");
            featureDesc.AppendLine("	about voting");
            var reader = new FeatureReader(ReadIn(featureDesc.ToString()));

            Feature feature = reader.Read();

            Assert.That(feature.Description, Is.EqualTo("Ording answers\tabout voting"));
        }

        [Test]
        public void Should_read_in_scenario()
        {
            var featureDesc = new StringBuilder();
            featureDesc.AppendLine("Feature: Ording answers");
            featureDesc.AppendLine("Scenario: The answer with the highest vote gets to the top");
            var reader = new FeatureReader(ReadIn(featureDesc.ToString()));

            Feature feature = reader.Read();

            Assert.That(feature.Scenarios.Count, Is.EqualTo(1));
            Assert.That(feature.Scenarios[0].Description, Is.EqualTo("The answer with the highest vote gets to the top"));
        }

        [Test]
        public void Should_ignore_blank_line()
        {
            var featureDesc = new StringBuilder();
            featureDesc.AppendLine("Feature: Ording answers");
            featureDesc.AppendLine("    "); // Blank space
            featureDesc.AppendLine("    "); // Tab
            featureDesc.AppendLine("Scenario: The answer with the highest vote gets to the top");
            var reader = new FeatureReader(ReadIn(featureDesc.ToString()));

            Feature feature = reader.Read();

            Assert.That(feature.Scenarios.Count, Is.EqualTo(1));
        }

        private BufferedReader ReadIn(string featureDesc)
        {
            return new BufferedReader(new StringReader(featureDesc));
        }
    }
}
