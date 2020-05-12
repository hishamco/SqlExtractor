using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlExtractor.Core
{
    public class LocalizedStringExtractor : ILocalizedStringExtractor
    {
        private readonly IEnumerable<IProject> _projects;

        private static readonly Regex _localizerRegularExpression = new Regex(@$"@{LocalizerIdentifierName.ViewLocalizer}\[""([\w\s!@,{{}}]+)""(,[\w\s]+)?\]", RegexOptions.Compiled);

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
                    var content = await File.ReadAllTextAsync(file);

                    foreach (Match match in _localizerRegularExpression.Matches(content))
                    {
                        localizedStrings.Add(new LocalizedString { Text = match.Groups[1].Value });
                    }
                }
            }

            return localizedStrings;
        }
    }
}
