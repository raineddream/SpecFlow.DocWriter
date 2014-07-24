using NUnit.Framework;
using Rain.SpecFlow.DocWriter.Reader.IO;

namespace Rain.SpecFlow.DocWriter.Reader
{
    [TestFixture]
    public class ScenarioReaderTest
    {
        [Test]
        public void Should_read_in_scenario_description()
        {
            string firstLine = "Scenario: The answer with the highest vote gets to the top";
            var reader = new ScenarioReader(BufferedReaderBuilder.ReadIn(firstLine));

            Scenario scenario = reader.Read();

            Assert.That(scenario.Description, Is.EqualTo("The answer with the highest vote gets to the top"));
        }

        [Test]
        public void Should_read_in_given_statement()
        {
            BufferedReader bufferedReader = BufferedReaderBuilder.ReadIn(
                "Scenario: The answer with the highest vote gets to the top",
                "    Given there is a question \"What's your favorite colour?\" with the answers"
                );
            var reader = new ScenarioReader(bufferedReader);

            Scenario scenario = reader.Read();

            Assert.That(scenario.Statements[0], Should.EqualTo(StatementBuilder.Given("there is a question \"What's your favorite colour?\" with the answers")));
        }
    }
}
