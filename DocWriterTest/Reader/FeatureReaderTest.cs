using System.IO;
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
            var reader = new FeatureReader(new StringReader(featureDesc));

            Feature feature = reader.Read();

            Assert.That(feature.Description, Is.EqualTo("Ording answers"));
        }
    }
}
