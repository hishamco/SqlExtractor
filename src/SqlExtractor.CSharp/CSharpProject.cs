using System.Collections.Generic;
using System.IO;
using SqlExtractor.Core;

namespace SqlExtractor.CSharp
{
    public class CSharpProject : Project
    {
        public const string CSharpFileExtension = ".cs";

        private IEnumerable<string> _files;

        public CSharpProject(string path) : base(path)
        {
            LoadFiles();
        }

        public override string Extension => ".csproj";

        public override IEnumerable<string> Files => _files;

        private void LoadFiles()
        {
            var projectDirectoryPath = new FileInfo(Path).Directory.FullName;
            var csFilesPattern = "*" + CSharpFileExtension;
            _files = Directory.EnumerateFiles(projectDirectoryPath, csFilesPattern, SearchOption.AllDirectories);
        }
    }
}
