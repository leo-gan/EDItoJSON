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
        ///     Parse input EDI file and convert it into JSON file.
        /// </summary>
        /// <param name="inputFileName"></param>
        public void Parse(string inputFileName)
        {
            //if (args == null || args.Length != 1)
            //{
            //    Console.WriteLine("Wrong call. Usage: >Parser inputEDIfile");
            //    return;
            //}
            //Console.WriteLine("Parser Started: Input file:{0}", args[0]);
            //var inputFileName = args[0];
            var outputFileName = inputFileName + ".Output.js";
            var errorsFileName = inputFileName + ".errors.js";

            var errors = new Errors();

            var interchange = new Interchange
            {
                SegmentSeparator = GetSegmentSeparator(inputFileName),
                DataElementSeparator = GetDataElementSeparator(inputFileName),
                DataComponentSeparator = GetDataComponentSeparator(inputFileName)
            };

            var segments = ReadAllSegments(inputFileName, interchange.SegmentSeparator, interchange.DataElementSeparator,
                errors);

            TraversAllSegments(interchange, segments, errors);

            // Check if errors happened and Assert the top level EDI structure, like missed IEA segment.
            if (errors.Logs.Count != 0)
            {
                errors.Report();
                File.WriteAllText(errorsFileName, JsonConvert.SerializeObject(errors.Logs));
                return;
            }

            // create JSON:
            var serializedInterchange = JsonConvert.SerializeObject(interchange, Formatting.Indented);

            // output JSON:
            File.WriteAllText(outputFileName, serializedInterchange);

            Console.WriteLine("Success.");
            //Console.WriteLine("Press Enter to finish.");
            //Console.ReadLine();
        }

        private static void TraversAllSegments(Interchange interchange, IReadOnlyList<Segment> segments, Errors errors)
        {
            Group currentGroup = null;
            Document currentDocument = null;

            if (
                !errors.Assert(() => segments[0].Name == "ISA",
                    "FATAL Error: The first segment ('" + segments[0].Name + "') is not ISA segment."))
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
                        if (currentDocument != null)
                        {
                            currentDocument.SESegment = new SESegment(segments[i].Elements);
                            if (currentGroup != null)
                                currentGroup.Documents.Add(currentDocument);
                            else
                                errors.NewError(string.Format("Segment:'{0}' placed before GS segment",
                                    segments[i].AsString));
                            currentDocument = null;
                        }
                        else
                            errors.NewError(string.Format("Segment:'{0}' placed before ST segment", segments[i].AsString));
                        break;
                    case "GS":
                        currentGroup = new Group();
                        currentGroup.GSSegment = new GSSegment(segments[i].Elements);
                        break;
                    case "GE":
                        if (currentGroup != null)
                        {
                            currentGroup.GESegment = new GESegment(segments[i].Elements);
                            interchange.Groups.Add(currentGroup);
                            currentGroup = null;
                        }
                        else
                            errors.NewError(string.Format("Segment:'{0}' placed before GS segment", segments[i].AsString));
                        break;
                    case "IEA":
                        interchange.IEASegment = new IEASegment(segments[i].Elements);
                        break;
                    default:
                        if (currentDocument != null)
                            currentDocument.Segments.Add(segments[i]);
                        else
                            errors.NewError(string.Format("Segment:'{0}' placed before ST segment", segments[i].AsString));
                        break;
                }
            }

            // Validate a new interchange:
            interchange.Validate(errors);
        }

        private static List<Segment> ReadAllSegments(string fileName, char segmentSeparator, char dataElementSeparator,
            Errors errors)
        {
            var allLines = File.ReadAllLines(fileName); // TODO: use segmentSeparator
            return allLines.Select(line => ParseSegment(line, dataElementSeparator, errors)).ToList();
        }

        private static Segment ParseSegment(string line, char dataElementSeparator, Errors errors)
        {
            var elements = line.Split(dataElementSeparator);
            errors.Assert(() => elements.Length != 0,
                string.Format("Line {0} cannot be parsed. It cannot be split with {1} separator.", line,
                    dataElementSeparator));
            errors.Assert(() => elements.Length != 1,
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