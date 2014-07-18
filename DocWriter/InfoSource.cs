namespace Rain.SpecFlow.DocWriter
{
    public class InfoSource
    {
        public InfoSource(string specFilesParent)
        {
            SpecFilesParent = specFilesParent;
        }

        public string SpecFilesParent { get; private set; }
    }
}