using Rain.SpecFlow.DocWriter.Reader;
using Rain.SpecFlow.DocWriter.Spec;

namespace Rain.SpecFlow.DocWriter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InfoSource source = new ArgumentParser(args).Parse();
            Specification specification = new SpecificationReader(source.SpecFilesParent).Read();
//            specification.Output(HtmlRender);
        }
    }
}