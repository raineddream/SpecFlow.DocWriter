using System.IO;
using System.Text;
using NUnit.Framework;
using Rain.SpecFlow.DocWriter.Reader.IO;
using Rain.SpecFlow.DocWriter.Spec;

namespace Rain.SpecFlow.DocWriter.Reader
{
    [TestFixture]
    public class FeatureReaderTest
    {
        [Test]
        public void Should_read_in_feature_description_without_blank_prefix()
        {
            var reader = new FeatureReader(BufferedReaderBuilder.ReadIn("Feature: Ording answers"));

            Feature feature = reader.Read();

            Assert.That(feature.Description, Is.EqualTo("Ording answers"));
        }

        [Test]
        public void Should_read_in_feature_description_with_multi_lines_format()
        {
            var reader = new FeatureReader(BufferedReaderBuilder.ReadIn(
                    "Feature: Ording answers",
                    "	about voting"
                ));

            Feature feature = reader.Read();

            Assert.That(feature.Description, Is.EqualTo("Ording answers\tabout voting"));
        }

        [Test]
        public void Should_read_in_scenario()
        {
            var reader = new FeatureReader(BufferedReaderBuilder.ReadIn(
                    "Feature: Ording answers",
                    "Scenario: The answer with the highest vote gets to the top"
                ));

            Feature feature = reader.Read();

            Assert.That(feature.Scenarios.Count, Is.EqualTo(1));
            Assert.That(feature.Scenarios[0].Description, Is.EqualTo("The answer with the highest vote gets to the top"));
        }

        [Test]
        public void Should_ignore_blank_line()
        {
            var reader = new FeatureReader(BufferedReaderBuilder.ReadIn(
                    "Feature: Ording answers",
                    "    ", // Blank spaces
                    "    ", // Tab
                    "Scenario: The answer with the highest vote gets to the top"
                ));

            Feature feature = reader.Read();

            Assert.That(feature.Scenarios.Count, Is.EqualTo(1));
        }

        [Test]
        public void Should_read_in_multi_scenarios()
        {
            var featureDesc = new StringBuilder();
            featureDesc.AppendLine("Feature: Ording answers");
            featureDesc.AppendLine("Scenario: The answer with the highest vote gets to the top");
            featureDesc.AppendLine("Scenario: The answer with the lowest vote gets to the bottom");

            var reader = new FeatureReader(BufferedReaderBuilder.ReadIn(
                    "Feature: Ording answers",
                    "Scenario: The answer with the highest vote gets to the top",
                    "Scenario: The answer with the lowest vote gets to the bottom"
                ));

            Feature feature = reader.Read();

            Assert.That(feature.Scenarios.Count, Is.EqualTo(2));
            Assert.That(feature.Scenarios[0].Description, Is.EqualTo("The answer with the highest vote gets to the top"));
            Assert.That(feature.Scenarios[1].Description, Is.EqualTo("The answer with the lowest vote gets to the bottom"));
        }
    }
}
