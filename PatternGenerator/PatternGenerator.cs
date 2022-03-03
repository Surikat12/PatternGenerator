using System.IO;

namespace PatternGeneratorApp
{
    public class PatternGenerator
    {
        private readonly string _compositePath;
        private readonly string _visitorPath;

        public PatternGenerator(string compositePath, string visitorPath)
        {
            _compositePath = compositePath;
            _visitorPath = visitorPath;
        }

        private static string ReadFromFile(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public string GenerateComposite(string componentName, string leafName, string namespaceName)
        {
            var template = ReadFromFile(_compositePath);
            template = template.Replace("{0}", componentName);
            template = template.Replace("{1}", leafName);
            template = template.Replace("{2}", namespaceName);
            return template;
        }

        public string GenerateVisitor(string iComponentName, string iVisitorName, string visitorName,
            string namespaceName)
        {
            var template = ReadFromFile(_visitorPath);
            template = template.Replace("{0}", iComponentName);
            template = template.Replace("{1}", iVisitorName);
            template = template.Replace("{2}", visitorName);
            template = template.Replace("{3}", namespaceName);
            return template;
        }
    }
}
