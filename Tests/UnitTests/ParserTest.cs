using System.IO;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        [TestCase(@"835.Success.txt")]
        public void Success(string inputFilePath)
        {
            inputFilePath = @"..\..\Samples\" + inputFilePath;
            // remove output Files
            var outputJsonFile = inputFilePath + ".Output.js";
            var outputErrorsFile = inputFilePath + ".Errors.js";
            if (File.Exists(outputJsonFile)) File.Delete(outputJsonFile);
            if (File.Exists(outputErrorsFile)) File.Delete(outputErrorsFile);

            var parser = new GLD.EDItoJSON.Parser.Parser();
            parser.Parse(inputFilePath);

            Assert.IsTrue( File.Exists(outputJsonFile));
            Assert.IsTrue(!File.Exists(outputErrorsFile));
        }

        private string OutputJsonFile(ref string inputFilePath, out string outputErrorsFile)
        {
            inputFilePath = @"..\..\Samples\" + inputFilePath;
            // remove output Files
            var outputJsonFile = inputFilePath + ".Output.js";
            outputErrorsFile = inputFilePath + ".Errors.js";
            if (File.Exists(outputJsonFile)) File.Delete(outputJsonFile);
            if (File.Exists(outputErrorsFile)) File.Delete(outputErrorsFile);
            return outputJsonFile;
        }

        [Test]
        [TestCase(@"835.LostGA.txt")]
        [TestCase(@"835.LostGS.txt")]
        [TestCase(@"835.LostST.txt")]
        [TestCase(@"835.LostSE.txt")]
        [TestCase(@"835.LostISA.txt")]
        [TestCase(@"835.LostIEA.txt")]
        [TestCase(@"835.Wrong.ControlNumber.Document.txt")]
        [TestCase(@"835.Wrong.ControlNumber.Group.txt")]
        [TestCase(@"835.Wrong.ControlNumber.Interchange.txt")]
        [TestCase(@"835.Wrong.ElementSeparator.txt")]
        [TestCase(@"835.Wrong.HasEmptyLine.txt")]
        public void Failure(string inputFilePath)
        {
            inputFilePath = @"..\..\Samples\" + inputFilePath;
            // remove output Files
            var outputJsonFile = inputFilePath + ".Output.js";
            var outputErrorsFile = inputFilePath + ".Errors.js";
            if (File.Exists(outputJsonFile)) File.Delete(outputJsonFile);
            if (File.Exists(outputErrorsFile)) File.Delete(outputErrorsFile);

            var parser = new GLD.EDItoJSON.Parser.Parser();
            parser.Parse(inputFilePath);

            Assert.IsTrue(!File.Exists(outputJsonFile));
            Assert.IsTrue( File.Exists(outputErrorsFile));
        }
    }
}