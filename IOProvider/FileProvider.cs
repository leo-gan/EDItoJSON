using System.Collections.Generic;
using System.IO;

namespace GLD.EDItoJSON.IOProvider
{
    public class FileProvider : IProvider
    {
        /// <summary>
        /// It alwas read form InputAddress.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ReadAllLines()
        {
            return File.ReadAllLines(InputAddress);
        }

        public void WriteAllLines(string address, IEnumerable<string> lines)
        {
            File.WriteAllLines(address, lines);
        }

        public void WriteAllText(string address, string text)
        {
            File.WriteAllText(address, text);
        }

        public string InputAddress { get; set; }
        public string OutputAddress { get { return InputAddress + ".Output.js"; }  set {}}
        public string ErrorsAddress { get { return InputAddress + ".Errors.txt"; } set {} }
    }
}