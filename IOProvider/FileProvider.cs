using System.Collections.Generic;
using System.IO;

namespace GLD.EDItoJSON.IOProvider
{
    public class FileProvider : IProvider
    {
        public IEnumerable<string> ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public void WriteAllLines(string address, IEnumerable<string> lines)
        {
            File.WriteAllLines(address, lines);
        }

        public void WriteAllText(string address, string text)
        {
            File.WriteAllText(address, text);
        }
    }
}