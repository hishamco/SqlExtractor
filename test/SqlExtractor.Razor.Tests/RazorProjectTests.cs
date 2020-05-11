using System.IO;
using System.Linq;
using Xunit;

namespace SqlExtractor.Razor.Tests
{
    public class RazorProjectTests
    {
        [Fact]
        public void ValidateProjectInfo()
        {
            // Arrange
            var projectRootPath = GetProjectRootPath();
            var projectPath = Path.Combine(projectRootPath, $"SqlExtractor.Razor.Tests.csproj");

            // Act
            var project = new RazorProject(projectPath);

            // Assert
            Assert.Equal(projectPath, project.Path);
            Assert.Equal(".csproj", project.Extension);
            Assert.True(project.Files.Count() > 0);
        }

        [Fact]
        public void AllRazorFilesMustEndWithCshtmlExtension()
        {
            // Arrange
            var projectRootPath = GetProjectRootPath();
            var projectPath = Path.Combine(projectRootPath, $"SqlExtractor.Razor.Tests.csproj");
            var project = new RazorProject(projectPath);

            // Act
            var projectFiles = project.Files;

            // Assert
            Assert.True(projectFiles.All(f => f.EndsWith(RazorProject.RazorFileExtension)));
        }

        private string GetProjectRootPath()
        {
            var executionLocation = typeof(RazorProjectTests).Assembly.Location;
            var rootPath = new DirectoryInfo(executionLocation).Parent.Parent.Parent.Parent.FullName;

            return rootPath;
        }
    }
}
