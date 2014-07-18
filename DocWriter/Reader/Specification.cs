using System.Collections.Generic;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class Specification
    {
        private IList<Feature> _features = new List<Feature>();

        public IList<Feature> Features
        {
            get { return _features; }
        }

        public void AddFeature(Feature feature)
        {
            _features.Add(feature);
        }
    }
}