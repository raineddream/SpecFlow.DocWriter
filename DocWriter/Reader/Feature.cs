namespace Rain.SpecFlow.DocWriter.Reader
{
    public class Feature
    {
        public Feature(string description)
        {
            Description = description;
        }

        public object Description { get; private set; }
    }
}