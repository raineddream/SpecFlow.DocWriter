using System;
using System.Collections.Generic;
using Mono.Options;

namespace Rain.SpecFlow.DocWriter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InfoSource source = new ArgumentParser(args).Parse();
            string specFilesTopFolder = source.SpecFilesParent;
        }
    }
}