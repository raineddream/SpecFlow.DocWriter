using Rain.SpecFlow.DocWriter.IO;

namespace Rain.SpecFlow.DocWriter
{
    public class ArgumentParser
    {
        private readonly string[] _args;

        public ArgumentParser(string[] args)
        {
            _args = args;
        }

        public InfoSource Parse()
        {
            string specFolder = null;

            OptionSet options = new OptionSet()
                .Add("spec=", "The folder path that contains all specifications", v => specFolder = v);

            options.Parse(_args);

            return new InfoSource(specFolder);
        }
    }
}