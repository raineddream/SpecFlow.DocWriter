namespace Rain.SpecFlow.DocWriter.Reader
{
    public class Feature
    {
        public Feature(string fullNme, string description)
        {
            FullName = fullNme;
            Description = description;
        }

        public object FullName { get; private set; }
        public object Description { get; private set; }
    }
}