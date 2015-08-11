using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLD.EDItoJSON.ErrorHandling;
using GLD.EDItoJSON.Model;
using Newtonsoft.Json;

namespace GLD.EDItoJSON.Parser
{
    public class Parser
    {

        /// <summary>
        /// It is a test method. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(params string[] args)
        {
            if (args == null || args.Length != 2)
            {
                Console.WriteLine("Wrong call. Usage: >Parser inputEDIfile outputJSONfile");
                return;
            }
            Console.WriteLine("Parser Started: Input file:{0}, OutputFile{1}", args[0], args[1]);
            var inputFileName = args[0];
            var outputFileName = args[1];

            var interchange = new Interchange {SegmentSeparator = GetSegmentSeparator(inputFileName), DataElementSeparator = GetDataElementSeparator(inputFileName), DataComponentSeparator = GetDataComponentSeparator(inputFileName)};

            List<Segment> segments = ReadAllSegments(inputFileName, interchange.SegmentSeparator, interchange.DataElementSeparator);

            var currentGroup = new Group();
            var currentDocument = new Document();

            // traverse all segments:
            interchange.ISASegment = new ISASegment(segments[0]);

            for (var i = 1; i < segments.Count; i++)
            {
                switch (segments[i].Name)
                {
                    case "ST":
                        currentDocument = new Document(); 
                        currentDocument.STSegment = new STSegment(segments[i]);
                        break;
                    case "SE":
                        currentDocument.SESegment = new SESegment(segments[i]);
                        currentGroup.Documents.Add(currentDocument);
                        break;
                    case "GS":
                        currentGroup = new Group(); 
                        currentGroup.GSSegment = new GSSegment(segments[i]);
                        break;
                    case "GE":
                        currentGroup.GESegment = new GESegment(segments[i]);
                        interchange.Groups.Add(currentGroup);
                        break;
                    case "IEA":
                        interchange.IEASegment = new IEASegment(segments[i]);
                        break;
                    default:
                        currentDocument.Segments.Add(segments[i]);
                        break;
                }
            }
            // Check if errors happened and Validate the top level EDI structure, like missed IEA segment.
            if (!interchange.IsValid() || Errors.Log.Count != 0)
            {
                Errors.Report();
                return;
            }

            // create JSON:
            var serializedInterchange = JsonConvert.SerializeObject(interchange);

            // output JSON:
            File.WriteAllText(outputFileName, serializedInterchange);
        }

    
       


        private static List<Segment> ReadAllSegments(string fileName, char segmentSeparator, char dataElementSeparator)
        {
            var allLines = File.ReadAllLines(fileName); // TODO: use segmentSeparator
            return allLines.Select(line => ParseSegment(line, dataElementSeparator)).ToList();
        }

        private static Segment ParseSegment(string line, char dataElementSeparator)
        {
            var elements = line.Split(dataElementSeparator);
            Errors.Validate(() => elements.Length == 0, string.Format("Line {0} cannot be parsed. It cannot be splitted with {1} separator.", line, dataElementSeparator));
            Errors.Validate(() => elements.Length == 1,
                string.Format("Line {0} cannot be parsed. With {1} separator it has only one element.", line,
                    dataElementSeparator));
            
            var segment = new Segment(elements[0]);
            segment.Elements = new string[elements.Length];
            Array.Copy(elements, 1, segment.Elements, 0, elements.Length - 1);
            return segment;
        }

        private static char GetSegmentSeparator(string fileName)
        {
            return '~'; // TODO read it from ISA
        }

        /// Data Element Separator follows after 'ISA' and usually it equals '*' 
       public static char GetDataElementSeparator(string fileName)
       {
           return '*';
       }
    private static char GetDataComponentSeparator(string inputFileName)
        {
            return ':'; // TODO read it from ISA
        }
    }
}
