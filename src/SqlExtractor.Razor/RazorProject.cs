using System.Collections.Generic;
using System.IO;
using SqlExtractor.Core;

namespace SqlExtractor.Razor
{
    public class RazorProject : IProject
    {
        public const string RazorFileExtension = ".cshtml";

        public RazorProject(string path)
        {
            Path = path;
            LoadFiles();
        }

        public string Path { get; }

        public string Extension => ".csproj";

        public IEnumerable<string> Files { get; private set; }

        private void LoadFiles()
        {
            var projectDirectoryPath = new FileInfo(Path).Directory.FullName;
            var razorFilesPattern = "*" + RazorFileExtension;
            Files = Directory.EnumerateFiles(projectDirectoryPath, razorFilesPattern, SearchOption.AllDirectories);
        }
    }
}
