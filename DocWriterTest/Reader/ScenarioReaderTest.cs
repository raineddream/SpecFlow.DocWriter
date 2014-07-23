using NUnit.Framework;

namespace Rain.SpecFlow.DocWriter.Reader
{
    [TestFixture]
    public class ScenarioReaderTest
    {
        [Test]
        public void Should_read_in_scenario_description()
        {
            string firstLine = "Scenario: The answer with the highest vote gets to the top";
            var reader = new ScenarioReader(firstLine, BufferedReaderBuilder.ReadIn(firstLine));

            Scenario scenario = reader.Read();

            Assert.That(scenario.Description, Is.EqualTo("The answer with the highest vote gets to the top"));
        }
    }
}
