using System.IO;
using System.Linq;
using SqlExtractor.CSharp.Views;
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
            var cSharpFiles = project.Files.OfType<CSharpFile>();

            // Assert
            Assert.NotEmpty(cSharpFiles);
            Assert.True(cSharpFiles.All(f => f.Path.EndsWith(CSharpFile.CSharpFileExtension)));
        }

        [Fact]
        public void AllRazorFilesMustEndWithCshtmlExtension()
        {
            // Arrange
            var projectRootPath = GetProjectRootPath();
            var projectPath = Path.Combine(projectRootPath, $"SqlExtractor.CSharp.Tests.csproj");
            var project = new CSharpProject(projectPath);

            // Act
            var razorFiles = project.Files.OfType<RazorFile>();

            // Assert
            Assert.NotEmpty(razorFiles);
            Assert.True(razorFiles.All(f => f.Path.EndsWith(RazorFile.RazorFileExtension)));
        }

        private string GetProjectRootPath()
        {
            var executionLocation = typeof(CSharpProjectTests).Assembly.Location;
            var rootPath = new DirectoryInfo(executionLocation).Parent.Parent.Parent.Parent.FullName;

            return rootPath;
        }
    }
}
