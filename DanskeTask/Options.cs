using CommandLine;
using CommandLine.Text;

namespace DanskeTask
{
    [Verb("search", HelpText = "Search")]
    internal class SearchOptions
    {

        [Option('q', "query", Required = true, HelpText = "Search query")]
        public required string Query { get; set; }

        [Usage(ApplicationAlias = "")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() { new Example("Convert file to a trendy format", new SearchOptions { Query = "Property='value'" })
            };
            }
        }
    }

    [Verb("import", HelpText = "Import file")]
    internal class ImportOptions
    {

        [Option('r', "read", Required = true, HelpText = "Path to file ready to import")]
        public required IEnumerable<string> Path { get; set; }

        [Option('n', "notify", Required = false, HelpText = "Lowest severity level to notify")]
        public required int Severity { get; set; }

        [Usage(ApplicationAlias = "")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() { new Example("Import log file", new SearchOptions { Query = "FileName" })
            };
            }
        }
    }
}
