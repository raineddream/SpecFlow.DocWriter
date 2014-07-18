namespace Rain.SpecFlow.DocWriter.Reader
{
    public class Feature
    {
        public Feature(string fullNme)
        {
            FullName = fullNme;
        }

        public object FullName { get; private set; }
    }
}