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

        public static BufferedReader ReadIn(params string[] statements)
        {
            var content = new StringBuilder();
            foreach (string line in statements)
            {
                content.AppendLine(line);
            }
            return ReadIn(content.ToString());
        }

        public static BufferedReader ReadIn(string featureDesc)
        {
            return new BufferedReader(new StringReader(featureDesc));
        }
    }
}
