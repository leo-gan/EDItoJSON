using System;
using System.Collections.Generic;
using System.Linq;
using GLD.EDItoJSON.ErrorHandling;
using GLD.EDItoJSON.IOProvider;
using GLD.EDItoJSON.Model;
using Newtonsoft.Json;

namespace GLD.EDItoJSON.Parser
{
    public class Parser
    {
        internal Errors errors = new Errors();
        internal IProvider fileProvider = new FileProvider();

        /// <summary>
        ///     Parse input EDI file and convert it into JSON file.
        /// </summary>
        /// <param name="inputFileName"></param>
        public void Parse(string inputFileName)
        {
            fileProvider.InputAddress = inputFileName;
 
            char segmentSeparator, dataElementSeparator, dataComponentSeparator;

            var lines = GetLinesAndSeparators(fileProvider, errors, out segmentSeparator,
                out dataElementSeparator,
                out dataComponentSeparator);

            // Separator errors are FATAL errors!
            if (errors.Logs.Count != 0)
            {
                errors.Report();
                fileProvider.WriteAllLines(fileProvider.ErrorsAddress, errors.Logs);
                return;
            }

            var interchange = new Interchange
            {
                SegmentSeparator = segmentSeparator,
                DataElementSeparator = dataElementSeparator,
                DataComponentSeparator = dataComponentSeparator
            };

            var segments = ReadAllSegments(lines, interchange.SegmentSeparator, interchange.DataElementSeparator,
                errors);

            TraversAllSegments(interchange, segments, errors);

            // Check if errors happened and Assert the top level EDI structure, like missed IEA segment.
            if (errors.Logs.Count != 0)
            {
                errors.Report();
                fileProvider.WriteAllLines(fileProvider.ErrorsAddress, errors.Logs);
                return;
            }

            // create JSON:
            var serializedInterchange = JsonConvert.SerializeObject(interchange, Formatting.Indented);

            // output JSON:
            fileProvider.WriteAllText(fileProvider.OutputAddress, serializedInterchange);

            Console.WriteLine("Success.");
            //Console.WriteLine("Press Enter to finish.");
            //Console.ReadLine();
        }

        /// <summary>
        ///     It works as a fully autonomus function regards to reading from EDI file,
        ///     because the real EDI file parsing is possible only after the separator parsing.
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <param name="errors"></param>
        /// <param name="segmentSeparator">
        ///     It can be a magic value 'C'. It means CR+LF line separator. We use CR+LF by default.
        ///     If it is NOT 'C', we use the value of segmentSeparator.
        /// </param>
        /// <param name="dataElementSeparator"></param>
        /// <param name="dataComponentSeparator"></param>
        private static string[] GetLinesAndSeparators(IProvider fileProvider, Errors errors,
            out char segmentSeparator,
            out char dataElementSeparator, out char dataComponentSeparator)
        {
            segmentSeparator = '~';
            dataElementSeparator = '*';
            dataComponentSeparator = ':';

            // Segment separator is placed right after "ISA" tag of the first segment.
            var lines = fileProvider.ReadAllLines().ToArray();
            if (lines.Length == 0)
            {
                errors.NewError(string.Format("No text provided for parsing in the EDI file:'{0}'", fileProvider.InputAddress));
                return null;
            }

            var symbols = lines[0].ToCharArray();
            if (symbols.Length < 105)
            {
                errors.NewError(
                    string.Format("The first line of the text '{0}' is too short to get a sub-element separator",
                        lines[0]));
                return null;
            }

            dataElementSeparator = symbols[103];
            dataComponentSeparator = symbols[104];
            segmentSeparator = lines.Length > 1 ? 'C' : symbols[105];

            return lines;
        }

        private static void TraversAllSegments(Interchange interchange, IReadOnlyList<Segment> segments, Errors errors)
        {
            if (segments == null || segments.Count == 0)
            {
                errors.NewError("No segments provided for parsing.");
                return;
            }

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

        private static List<Segment> ReadAllSegments(string[] allLines, char segmentSeparator, char dataElementSeparator,
            Errors errors)
        {
            var segmentLines = allLines;
            // by default segments are separated by CR+LF and allLines represent the segment lines.
            // But if allLines is one line, it must be separated by the segmentSeparator.
            if (allLines.Length == 1)
                segmentLines = allLines[0].Split(segmentSeparator);

            if (segmentLines == null || segmentLines.Length < 4)
            {
                errors.NewError(
                    string.Format(
                        "FATAL ERROR: EDI file cannot be parsed. The segment separator is '{0}' and it cannot separate text on segments. ",
                        segmentSeparator));
                return null;
            }

            for (var index = 0; index < segmentLines.Length; index++)
                if (string.IsNullOrWhiteSpace(segmentLines[index]))
                    errors.NewError(string.Format("Line[{0}] is Empty. It cannot be parsed.", index + 1));

            return segmentLines.Select(line => ParseSegment(line, dataElementSeparator, errors)).ToList();
        }

        private static Segment ParseSegment(string line, char dataElementSeparator, Errors errors)
        {
            var elements = line.Split(dataElementSeparator);
            errors.Assert(() => elements.Length != 0,
                string.Format("Line '{0}' cannot be parsed. Is it empty?", line));

            errors.Assert(() => elements.Length != 1,
                string.Format("Line '{0}' cannot be parsed. With '{1}' separator it has only one element.", line,
                    dataElementSeparator));
            for (var index = 0; index < elements.Length; index++)
                elements[index] = elements[index].Trim();

            return new Segment(elements);
        }
    }
}