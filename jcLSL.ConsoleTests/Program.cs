using System;
using System.Collections.Generic;
using System.Globalization;

using jcLSL.PCL;

namespace jcLSL.ConsoleTests {
    class Program {
        private const string TEST_STRING = "Hello {Name} This is a test of awesomness on {CurrentDate}.";
        
        static void Main(string[] args) {
            var parser = new jcLSLParser();

            parser.OnMergeField += Parser_OnMergeField;

            Console.WriteLine(
                $"Original: {TEST_STRING} {System.Environment.NewLine} Parsed: {parser.Run(TEST_STRING)} {System.Environment.NewLine}");

            Console.ReadKey();
        }

        private static void Parser_OnMergeField(object sender, MergeFieldArgs args) {
            var MergeFields = new List<string>();

            MergeFields.Add("Name");
            MergeFields.Add("CurrentDate");
            
            foreach (var mergeField in MergeFields) {
                switch (mergeField) {
                    case "Name":
                        args.MergeReplace(mergeField, "Test Name");
                        break;
                    case "CurrentDate":
                        args.MergeReplace(mergeField, DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        break;
                }
            }
        }
    }
}
