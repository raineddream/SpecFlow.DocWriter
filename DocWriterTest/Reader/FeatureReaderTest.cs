using System.IO;
using System.Text;
using NUnit.Framework;

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

        private StringReader ReadIn(string featureDesc)
        {
            return new StringReader(featureDesc);
        }
    }
}
