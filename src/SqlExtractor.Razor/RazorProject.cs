using System.Collections.Generic;
using System.IO;
using SqlExtractor.Core;

namespace SqlExtractor.Razor
{
    public class RazorProject : Project
    {
        public const string RazorFileExtension = ".cshtml";

        private IEnumerable<string> _files;

        public RazorProject(string path) : base(path)
        {
            LoadFiles();
        }

        public override string Extension => ".csproj";

        public override IEnumerable<string> Files => _files;

        private void LoadFiles()
        {
            var projectDirectoryPath = new FileInfo(Path).Directory.FullName;
            var razorFilesPattern = "*" + RazorFileExtension;
            _files = Directory.EnumerateFiles(projectDirectoryPath, razorFilesPattern, SearchOption.AllDirectories);
        }
    }
}
