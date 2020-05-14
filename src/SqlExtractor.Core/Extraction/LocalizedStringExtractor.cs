using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task<IEnumerable<LocalizedString>> ExtractAsync()
        {
            var localizedStrings = new List<LocalizedString>();
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
                            var localizedString = new LocalizedString
                            {
                                Text = match.Groups[1].Value
                            };
                            var location = new LocalizedStringLocation
                            {
                                File = file,
                                Line = i + 1,
                                Column = line.IndexOf(localizedString.Text) + 1
                            };
                            localizedString.Locations.Add(location);

                            localizedStrings.Add(localizedString);
                        }
                    }
                }
            }

            return localizedStrings.Distinct(_localizedStringComparer);
        }
    }
}
