using System;
using System.IO;
using System.Reflection;

namespace Rain.SpecFlow.DocWriter
{
    public class ResourcePath
    {
        private static ResourcePath resource = new ResourcePath();

        private ResourcePath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string path = Uri.UnescapeDataString(new UriBuilder(codeBase).Path);
            string assemblyPath = Path.GetDirectoryName(path);
            
            Base = Path.Combine(assemblyPath, "Resource");
        }

        public static string Sub(string subPath)
        {
            return Path.Combine(resource.Base, subPath);
        }

        public string Base { get; private set; }
    }
}
