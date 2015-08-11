using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GLD.EDItoJSON.ErrorHandling;
using GLD.EDItoJSON.Model;
using Newtonsoft.Json;

namespace GLD.EDItoJSON.Parser
{
    public class Parser
    {
        /// <summary>
        ///     It is a test method.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(params string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("Wrong call. Usage: >Parser inputEDIfile");
                return;
            }
            Console.WriteLine("Parser Started: Input file:{0}", args[0]);
            var inputFileName = args[0];
            var outputFileName = inputFileName + ".Output.js";
            var errorsFileName = inputFileName + ".Errors.js";

            var interchange = new Interchange
            {
                SegmentSeparator = GetSegmentSeparator(inputFileName),
                DataElementSeparator = GetDataElementSeparator(inputFileName),
                DataComponentSeparator = GetDataComponentSeparator(inputFileName)
            };

            var segments = ReadAllSegments(inputFileName, interchange.SegmentSeparator, interchange.DataElementSeparator);

            TraversAllSegments(interchange, segments);

            // Check if errors happened and Assert the top level EDI structure, like missed IEA segment.
            if (Errors.Logs.Count != 0)
            {
                Errors.Report();
                File.WriteAllText(errorsFileName, JsonConvert.SerializeObject(Errors.Logs));
                return;
            }

            // create JSON:
            var serializedInterchange = JsonConvert.SerializeObject(interchange, Formatting.Indented);

            // output JSON:
            File.WriteAllText(outputFileName, serializedInterchange);

            Console.WriteLine("Success.");
            Console.WriteLine("Press Enter to finish.");
            Console.ReadLine();
        }

        private static void TraversAllSegments(Interchange interchange, List<Segment> segments)
        {
            var currentGroup = new Group();
            var currentDocument = new Document();

            if( !Errors.Assert(() => segments[0].Name == "ISA", "FATAL Error: The first segment ('" + segments[0].Name + "') is not ISA segment.") )
                return; // FATAL error

            interchange.ISASegment = new ISASegment(segments[0].Elements);

            for (var i = 1; i < segments.Count; i++)
            {
                switch (segments[i].Name)
                {
                    case "ST":
                        currentDocument = new Document();
                        currentDocument.STSegment = new STSegment(segments[i].Elements);
                        break;
                    case "SE":
                        currentDocument.SESegment = new SESegment(segments[i].Elements);
                        currentGroup.Documents.Add(currentDocument);
                        break;
                    case "GS":
                        currentGroup = new Group();
                        currentGroup.GSSegment = new GSSegment(segments[i].Elements);
                        break;
                    case "GE":
                        currentGroup.GESegment = new GESegment(segments[i].Elements);
                        interchange.Groups.Add(currentGroup);
                        break;
                    case "IEA":
                        interchange.IEASegment = new IEASegment(segments[i].Elements);
                        break;
                    default:
                        currentDocument.Segments.Add(segments[i]);
                        break;
                }
            }
        }

        private static List<Segment> ReadAllSegments(string fileName, char segmentSeparator, char dataElementSeparator)
        {
            var allLines = File.ReadAllLines(fileName); // TODO: use segmentSeparator
            return allLines.Select(line => ParseSegment(line, dataElementSeparator)).ToList();
        }

        private static Segment ParseSegment(string line, char dataElementSeparator)
        {
            var elements = line.Split(dataElementSeparator);
            Errors.Assert(() => elements.Length != 0,
                string.Format("Line {0} cannot be parsed. It cannot be split with {1} separator.", line,
                    dataElementSeparator));
            Errors.Assert(() => elements.Length != 1,
                string.Format("Line {0} cannot be parsed. With {1} separator it has only one element.", line,
                    dataElementSeparator));
            for (var index = 0; index < elements.Length; index++)
                elements[index] = elements[index].Trim();

            return new Segment(elements);
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