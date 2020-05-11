using System.Collections.Generic;
using System.IO;
using SqlExtractor.Core;

namespace SqlExtractor.CSharp
{
    public class CSharpProject : IProject
    {
        public const string CSharpFileExtension = ".cs";

        public CSharpProject(string path)
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
            var csFilesPattern = "*" + CSharpFileExtension;
            Files = Directory.EnumerateFiles(projectDirectoryPath, csFilesPattern, SearchOption.AllDirectories);
        }
    }
}
