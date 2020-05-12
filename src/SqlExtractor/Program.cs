using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SqlExtractor.Core;
using SqlExtractor.Core.Extraction;
using SqlExtractor.Core.Sql;
using SqlExtractor.Core.Transformation;
using SqlExtractor.CSharp;

namespace SqlExtractor
{
    class Program
    {
        private const string DefaultCultureName = "en-US";

        private static readonly LocalizedStringComparer _localizedStringComparer = new LocalizedStringComparer();

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                PrintHelp();

                return;
            }

            var sourcePath = args[0];
            var destinationPath = args[1];
            if (Directory.Exists(sourcePath))
            {
                var extractedLocalizedStrings = new List<LocalizedString>();
                var projectPaths = Directory.EnumerateFiles(sourcePath, $"*.csproj", SearchOption.AllDirectories);
                foreach (var projectPath in projectPaths)
                {
                    var projects = new List<IProject>{
                        new CSharpProject(projectPath)
                    };
                    var localizedStringExtractor = new LocalizedStringExtractor(projects);
                    var localizedStrings = localizedStringExtractor.ExtractAsync().GetAwaiter().GetResult();
                    extractedLocalizedStrings.AddRange(localizedStrings);

                    PrintProjectStats(projectPath, localizedStrings.Count());
                }

                if (extractedLocalizedStrings.Count() > 0)
                {
                    var localizedStringTransformer = new LocalizedStringTransformer();
                    var sqlGenerator = new SqlGenerator();
                    var transformedStrings = localizedStringTransformer.Transform(extractedLocalizedStrings
                        .Distinct(_localizedStringComparer), sqlGenerator.Generate);   
                    var sqlScriptName = string.Concat(DefaultCultureName, SqlWriter.SqlScriptFileExtension);
                    var sqlScriptPath = Path.Combine(destinationPath, sqlScriptName);
                    var sqlWriter = new SqlWriter(sqlScriptPath);
                    sqlWriter.WriteLineAsync(transformedStrings).GetAwaiter().GetResult();
                }
            }
            else
            {
                Console.WriteLine("The folder doesn't contains any projects.");
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Usage: extract <SOURCE_PATH> <DESTINATION_PATH>");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("  <SOURCE_PATH>        The path to the source directory, that contains all projects to be scanned.");
            Console.WriteLine("  <DESTINATION_PATH>   The path to a directory where SQL scripts will be generated.");
        }

        private static void PrintProjectStats(string projectPath, int localizedStringsCount)
        {
            var defaultConsoleColor = Console.ForegroundColor;
            Console.Write($"{Path.GetFileName(projectPath)}: Found ");
            Console.ForegroundColor = localizedStringsCount == 0 ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(localizedStringsCount);
            Console.ForegroundColor = defaultConsoleColor;
            Console.Write(" strings.");
            Console.WriteLine();
        }
    }
}
