# jcLSL
A super lean scripting language written in C#

To install via NuGet:
```html
PM> Install-Package jcLSL
```

Example of usage is in the jcLSL.ConsoleTests project or here:

```csharp
private const string TEST_STRING = "Hello {Name} This is a test of awesomness on {CurrentDate}.";

public class TESTCLASS {
    [jcLSLMember]
    public string Name { get; set; }

    [jcLSLMember]
    public DateTime CurrentDate { get; set; }
}

static void Main(string[] args) {
    var parser = new jcLSLStringParser();

    parser.OnStringMergeField += Parser_OnMergeField;

    Console.WriteLine(
        $"Original: {TEST_STRING} {System.Environment.NewLine} Parsed: {parser.Run(TEST_STRING)} {System.Environment.NewLine}");

    var testClass = new TESTCLASS();

    testClass.CurrentDate = DateTime.Now;
    testClass.Name = "Testing";

    var gParser = new jcLSLGenericParser<TESTCLASS>();

    gParser.OnObjectMergeField += GParser_OnObjectMergeField;
            
    Console.WriteLine(
        $"Original: {TEST_STRING} {System.Environment.NewLine} Parsed: {gParser.Run(TEST_STRING, testClass)} {System.Environment.NewLine}");

    Console.ReadKey();
}

private static void GParser_OnObjectMergeField(object sender, jcLSLObjectMergeFieldArgs<TESTCLASS> args) {
    args.MergeReplace();
}

private static void Parser_OnMergeField(object sender, jcLSLStringMergeFieldArgs args) {
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
```
