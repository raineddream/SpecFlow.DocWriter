using System.IO;
using System.Text;
using NUnit.Framework;

namespace Rain.SpecFlow.DocWriter.Reader.IO
{
    [TestFixture]
    public class BufferedReaderTest
    {
        [Test]
        public void Should_read_all_lines()
        {
            var content = new StringBuilder();
            content.AppendLine("line 1");
            content.AppendLine("line 2");

            var reader = new BufferedReader(new StringReader(content.ToString()));

            Assert.That(reader.ReadLine(), Is.EqualTo("line 1"));
            Assert.That(reader.ReadLine(), Is.EqualTo("line 2"));
        }

        [Test]
        public void Should_return_null_when_read_to_end()
        {
            var reader = new BufferedReader(new StringReader("one line"));
            reader.ReadLine();

            Assert.That(reader.ReadLine(), Is.Null);
        }

        [Test]
        public void Should_back_to_prev_line()
        {
            var content = new StringBuilder();
            content.AppendLine("line 1");
            content.AppendLine("line 2");
            var reader = new BufferedReader(new StringReader(content.ToString()));
            reader.ReadLine();

            reader.BackToPrevLine();

            Assert.That(reader.ReadLine(), Is.EqualTo("line 1"));
        }

        [Test]
        public void Should_only_back_to_start()
        {
            var reader = new BufferedReader(new StringReader("one line"));
            
            reader.BackToPrevLine();

            Assert.That(reader.ReadLine(), Is.EqualTo("one line"));
        }
    }
}
