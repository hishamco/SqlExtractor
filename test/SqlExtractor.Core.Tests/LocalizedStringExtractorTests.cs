using SqlExtractor.Razor;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SqlExtractor.Core.Tests
{
    public class LocalizedStringExtractorTests
    {
        [Fact]
        public async Task ExtractLocalizedStrings()
        {
            // Arrange
            var projectName = "SqlExtractor.Razor.Tests";
            var projectFolderPath = Path.Combine(GetTestFolderPath(), projectName);
            var projectPath = Path.Combine(projectFolderPath, $"{projectName}.csproj");
            var projects = new List<IProject>
            {
                new RazorProject(projectPath)
            };
            var extractor = new LocalizedStringExtractor(projects);

            // Act
            var localizedStrings = await extractor.ExtractAsync();

            // Assert
            Assert.True(localizedStrings.Count() > 0);
            Assert.Equal("About", localizedStrings.ElementAt(0).Text);
            Assert.Equal("Home", localizedStrings.ElementAt(1).Text);
            Assert.Equal("Hello, SQL Extractor", localizedStrings.ElementAt(2).Text);
        }

        private string GetTestFolderPath()
        {
            var executionLocation = typeof(LocalizedStringExtractorTests).Assembly.Location;
            var rootPath = new DirectoryInfo(executionLocation).Parent.Parent.Parent.Parent.Parent.FullName;

            return rootPath;
        }
    }
}
