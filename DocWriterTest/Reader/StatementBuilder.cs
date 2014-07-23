namespace Rain.SpecFlow.DocWriter.Reader
{
    public class StatementBuilder
    {
        public static IStatement Given(string statement)
        {
            return new GivenStatement(statement);
        }
    }
}
