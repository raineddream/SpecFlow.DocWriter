using NUnit.Framework.Constraints;
using Rain.SpecFlow.DocWriter.Spec;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class StatementEqualityConstraint : Constraint
    {
        private readonly IStatement _expected;

        public StatementEqualityConstraint(IStatement expected)
        {
            _expected = expected;
        }

        public override bool Matches(object actual)
        {
            IStatement actualStatement = (IStatement) actual;
            return _expected.GetType() == actualStatement.GetType();
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}