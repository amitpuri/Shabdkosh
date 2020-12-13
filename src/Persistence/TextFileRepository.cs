using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Shabdkosh.Persistence
{
    public class TextFileRepository: ITextFileRepository
    {
        public string ReadTextFile()
        {
            string text = string.Empty;
            var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().First(s => s.EndsWith("songhiawathathe00longrich_djvu.txt", StringComparison.CurrentCultureIgnoreCase));

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("Could not load text file.");
                }
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }


    public interface ITextFileRepository
    {
        string ReadTextFile();
    }
}
