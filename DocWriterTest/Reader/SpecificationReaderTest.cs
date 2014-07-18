using NUnit.Framework;

namespace Rain.SpecFlow.DocWriter.Reader
{
    [TestFixture]
    public class SpecificationReaderTest
    {
        [Test]
        public void Should_read_in_all_specifications_in_folder()
        {
            var reader = new SpecificationReader(ResourcePath.Sub("Spec"));

            Specification spec = reader.Read();

            Assert.That(spec.Features.Count, Is.EqualTo(1));
            Assert.That(spec.Features[0].FullName, Is.EqualTo(ResourcePath.Sub(@"Spec\Question\Answers.feature")));
        }
    }
}
