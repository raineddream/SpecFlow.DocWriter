using System.Collections.Generic;

namespace Rain.SpecFlow.DocWriter.Spec
{
    public class Scenario
    {
        private List<IStatement> _statements = new List<IStatement>(); 

        public string Description { get; set; }

        public IStatement[] Statements 
        {
            get { return _statements.ToArray(); }
        }

        public void AddStatement(IStatement statement)
        {
            _statements.Add(statement);
        }
    }
}