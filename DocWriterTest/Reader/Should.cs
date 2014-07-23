using NUnit.Framework.Constraints;

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