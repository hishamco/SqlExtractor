using SqlExtractor.CSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SqlExtractor.Core.Extraction.Tests
{
    public class LocalizedStringExtractorTests
    {
        [Fact]
        public async Task ExtractLocalizedStrings()
        {
            // Arrange
            var projectName = "SqlExtractor.CSharp.Tests";
            var projectFolderPath = Path.Combine(GetTestFolderPath(), projectName);
            var projectPath = Path.Combine(projectFolderPath, $"{projectName}.csproj");
            var projects = new List<IProject>
            {
                new CSharpProject(projectPath)
            };
            var extractor = new LocalizedStringExtractor(projects);

            // Act
            var localizedStrings = await extractor.ExtractAsync();

            // Assert
            Assert.True(localizedStrings.Count() > 0);
            Assert.Contains(localizedStrings, s => s.Text == "About");
            Assert.Contains(localizedStrings, s => s.Text == "Hello, SQL Extractor");
            Assert.Contains(localizedStrings, s => s.Text == "Hello, {0}");
            Assert.Contains(localizedStrings, s => s.Text == "Hello, AngularJS");
        }

        [Fact]
        public async Task ExtractShouldRemoveDuplicates()
        {
            // Arrange
            var projectName = "SqlExtractor.CSharp.Tests";
            var projectFolderPath = Path.Combine(GetTestFolderPath(), projectName);
            var projectPath = Path.Combine(projectFolderPath, $"{projectName}.csproj");
            var projects = new List<IProject>
            {
                new CSharpProject(projectPath)
            };
            var extractor = new LocalizedStringExtractor(projects);

            // Act
            var localizedStrings = await extractor.ExtractAsync();

            // Assert
            Assert.Single(localizedStrings, s => s.Text == "Hello, SQL Extractor");
        }

        [Fact]
        public async Task GetExtractedLocalizedStringsLocationMetadata()
        {
            // Arrange
            var projectName = "SqlExtractor.CSharp.Tests";
            var projectFolderPath = Path.Combine(GetTestFolderPath(), projectName);
            var projectPath = Path.Combine(projectFolderPath, $"{projectName}.csproj");
            var projects = new List<IProject>
            {
                new CSharpProject(projectPath)
            };
            var extractor = new LocalizedStringExtractor(projects);

            // Act
            var localizedStrings = await extractor.ExtractAsync();

            // Assert
            var location = localizedStrings.Single(s => s.Text == "Home").Locations.First();
            Assert.Equal("Index.cshtml", Path.GetFileName(location.File.Path));
            Assert.Equal(1, location.Line);
            Assert.Equal(13, location.Column);
        }


        private string GetTestFolderPath()
        {
            var executionLocation = typeof(LocalizedStringExtractorTests).Assembly.Location;
            var rootPath = new DirectoryInfo(executionLocation).Parent.Parent.Parent.Parent.Parent.FullName;

            return rootPath;
        }
    }
}
