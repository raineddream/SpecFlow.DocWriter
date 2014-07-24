using NUnit.Framework.Constraints;
using Rain.SpecFlow.DocWriter.Spec;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class Should
    {
        public static IResolveConstraint EqualTo(IStatement statement)
        {
            return new StatementEqualityConstraint(statement);
        }
    }
}