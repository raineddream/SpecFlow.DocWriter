using NUnit.Framework;
using Rain.SpecFlow.DocWriter;

namespace DocWriterTest
{
    [TestFixture]
    public class ArgumentParserTest
    {
        private string[] _args;

        [SetUp]
        public void SetUp()
        {
            _args = new[]{@"--spec=C:\eXpandGST\IntegrationTest"};
        }

        [Test]
        public void Should_parse_args_to_get_folder_path_of_all_specs()
        {
            var parser = new ArgumentParser(_args);

            InfoSource infoSource = parser.Parse();

            Assert.That(infoSource.SpecFilesParent, Is.EqualTo(@"C:\eXpandGST\IntegrationTest"));
        }
    }
}
