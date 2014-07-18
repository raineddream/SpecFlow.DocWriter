using System;
using System.Collections.Generic;
using System.IO;

namespace Rain.SpecFlow.DocWriter.Reader
{
    public class SpecificationReader
    {
        private readonly string _specFolder;

        public SpecificationReader(string specFolder)
        {
            _specFolder = specFolder;
        }

        public Specification Read()
        {
            var spec = new Specification();

            foreach (string specFileName in FindAllSpecFiles(_specFolder))
            {
                spec.AddFeature(new Feature(specFileName));
            }

            return spec;
        }

        private IEnumerable<string> FindAllSpecFiles(string specFolder)
        {
            var fileNames = new List<string>();
            ProcessDirectory(specFolder, fileNames);

            return fileNames;
        }

        private void ProcessDirectory(string targetDirectory, List<string> fileNames)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName, fileNames);
            }

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory, fileNames);
            }
        }

        private void ProcessFile(string path, List<string> fileNames)
        {
            fileNames.Add(path);
        }
    }
}