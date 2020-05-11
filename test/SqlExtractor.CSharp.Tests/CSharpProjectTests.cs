using System.IO;
using System.Linq;
using Xunit;

namespace SqlExtractor.CSharp.Tests
{
    public class CSharpProjectTests
    {
        [Fact]
        public void ValidateProjectInfo()
        {
            // Arrange
            var projectRootPath = GetProjectRootPath();
            var projectPath = Path.Combine(projectRootPath, $"SqlExtractor.CSharp.Tests.csproj");

            // Act
            var project = new CSharpProject(projectPath);

            // Assert
            Assert.Equal(projectPath, project.Path);
            Assert.Equal(".csproj", project.Extension);
            Assert.True(project.Files.Count() > 0);
        }

        [Fact]
        public void AllCSharpProjectFilesMustEndWithCsExtension()
        {
            // Arrange
            var projectRootPath = GetProjectRootPath();
            var projectPath = Path.Combine(projectRootPath, $"SqlExtractor.CSharp.Tests.csproj");
            var project = new CSharpProject(projectPath);

            // Act
            var projectFiles = project.Files;

            // Assert
            Assert.True(projectFiles.All(f => f.EndsWith(CSharpProject.CSharpFileExtension)));
        }

        private string GetProjectRootPath()
        {
            var executionLocation = typeof(CSharpProjectTests).Assembly.Location;
            var rootPath = new DirectoryInfo(executionLocation).Parent.Parent.Parent.Parent.FullName;

            return rootPath;
        }
    }
}
