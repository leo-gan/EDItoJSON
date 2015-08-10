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

            var interchange = new Interchange {SegmentSeparator = GetSegmentSeparator(inputFileName)};

            List<Segment> segments = ReadAllSegments(inputFileName, interchange.SegmentSeparator);

            var currentGroup = new Group();
            var currentDocument = new Document();

            // traverse all segments:
            interchange.ISASegment = ISASegment.Parse(segments[0]);

            for (int i = 1; i < segments.Count; i++)
            {
                switch (segments[i].Name)
                {
                    case "ST":
                        currentDocument = new Document(); 
                        currentDocument.STSegment = ParseST(segments[i]);
                        break;
                    case "SE":
                        currentDocument.SESegment = ParseSE(segments[i]);
                        currentGroup.Documents.Add(currentDocument);
                        break;
                    case "GS":
                        currentGroup = new Group(); 
                        currentGroup.GSSegment = ParseGS(segments[i]);
                        break;
                    case "GE":
                        currentGroup.GESegment = ParseGE(segments[i]);
                        interchange.Groups.Add(currentGroup);
                        break;
                    case "IEA":
                        interchange.IEASegment.Parse(segments[i]);
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

        private static SESegment ParseSE(Segment segment)
        {
            throw new NotImplementedException();
        }

        private static STSegment ParseST(Segment segment)
        {
            throw new NotImplementedException();
        }

        private static GESegment ParseGE(Segment segment)
        {
            throw new NotImplementedException();
        }

        private static GSSegment ParseGS(Segment segment)
        {
            throw new NotImplementedException();
        }

  
  
        private static List<Segment> ReadAllSegments(string fileName, char segmentSeparator)
        {
            var segments = new List<Segment>();
            using (var stream = new StreamReader(fileName))
            {
                segments.Add(ParseSegment(stream.ReadLine(), segmentSeparator)); // TODO: read a segment with a segment separator specified. Not it is CR LF
            }
            return segments;
        }

        private static Segment ParseSegment(string line, char segmentSeparator)
        {
            var elements = line.Split(segmentSeparator);
            Errors.Validate(() => elements.Length == 0, string.Format("Line {0} cannot be parsed. It cannot be splitted with {1} separator.", line, segmentSeparator));
            Errors.Validate(() => elements.Length == 1,
                string.Format("Line {0} cannot be parsed. With {1} separator it has only one element.", line,
                    segmentSeparator));
            
            var segment = new Segment(elements[0]);
            Array.Copy(elements, 1, segment.Elements, 0, elements.Length - 1);
            return segment;
        }

        private static char GetSegmentSeparator(string fileName)
        {
            return '~'; // TODO read it from ISA
        }

        /// Data Element Separator follows after 'ISA' and usually it equals '*' 
       public char GetDataElementSeparator()
       {
           return '*';
       }
        
    }
}
