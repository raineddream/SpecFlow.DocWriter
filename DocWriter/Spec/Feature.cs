using System.Collections.Generic;
using Rain.SpecFlow.DocWriter.Reader;

namespace Rain.SpecFlow.DocWriter.Spec
{
    public class Feature
    {
        public Feature(string description)
        {
            Description = description;
            Scenarios = new List<Scenario>();
        }

        public object Description { get; private set; }
        public IList<Scenario> Scenarios { get; private set; }

        public void AddScenario(Scenario scenario)
        {
            Scenarios.Add(scenario);
        }
    }
}