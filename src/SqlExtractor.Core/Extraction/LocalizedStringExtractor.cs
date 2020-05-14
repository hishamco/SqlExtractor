using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlExtractor.Core.Extraction
{
    public class LocalizedStringExtractor : ILocalizedStringExtractor
    {
        private static readonly LocalizedStringComparer _localizedStringComparer = new LocalizedStringComparer();

        private readonly IEnumerable<IProject> _projects;

        public LocalizedStringExtractor(IEnumerable<IProject> projects)
        {
            _projects = projects ?? throw new ArgumentNullException(nameof(projects));
        }

        public async Task<IEnumerable<LocalizedStringOccurence>> ExtractAsync()
        {
            var localizedStringOccurences = new List<LocalizedStringOccurence>();
            foreach (var project in _projects)
            {
                foreach (var file in project.Files)
                {
                    if (file.LocalizerPattern == ProjectFile.DefaultLocalizerPattern)
                    {
                        continue;
                    }

                    var fileLines = await File.ReadAllLinesAsync(file.Path);
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        var line = fileLines[i];
                        foreach (Match match in file.LocalizerPattern.Matches(line))
                        {
                            var value = match.Groups[1].Value;
                            var occurence = new LocalizedStringOccurence
                            {
                                Location = new LocalizedStringLocation
                                {
                                    File = file,
                                    Line = i + 1,
                                    Column = line.IndexOf(value) + 1
                                },
                                Text = value
                            };

                            localizedStringOccurences.Add(occurence);
                        }
                    }
                }
            }

            return localizedStringOccurences;
        }
    }
}
