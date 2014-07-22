namespace Rain.SpecFlow.DocWriter.Reader
{
    public class Scenario
    {
        public Scenario(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}