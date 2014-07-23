using System.IO;
using System.Text;
using Rain.SpecFlow.DocWriter.Reader.IO;

namespace Rain.SpecFlow.DocWriter.Reader
{
    class BufferedReaderBuilder
    {
        public static BufferedReader ReadIn(StringBuilder featureDesc)
        {
            return ReadIn(featureDesc.ToString());
        }

        public static BufferedReader ReadIn(string featureDesc)
        {
            return new BufferedReader(new StringReader(featureDesc));
        }
    }
}
