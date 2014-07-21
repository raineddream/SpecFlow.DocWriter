namespace Rain.SpecFlow.DocWriter.Reader
{
    public class FeatureReader : IReader<Feature>
    {
        private readonly string _specFullName;

        public FeatureReader(string specFullName)
        {
            _specFullName = specFullName;
        }

        public Feature Read()
        {
            return new Feature(_specFullName);
        }
    }
}