using System.Collections.Generic;
using System.IO;
using System.Linq;
using SqlExtractor.Core;
using SqlExtractor.CSharp.Views;

namespace SqlExtractor.CSharp
{
    public class CSharpProject : Project
    {
        private IEnumerable<IProjectFile> _files;

        public CSharpProject(string path) : base(path)
        {
            LoadFiles();
        }

        public override string Extension => ".csproj";

        public override IEnumerable<IProjectFile> Files => _files;

        private void LoadFiles()
        {
            var projectDirectoryPath = new FileInfo(Path).Directory.FullName;
            var cSharpFiles = Directory.EnumerateFiles(projectDirectoryPath, $"*{CSharpFile.CSharpFileExtension}", SearchOption.AllDirectories)
                .Select(f => new CSharpFile { Path = f});
            var razorFiles = Directory.EnumerateFiles(projectDirectoryPath, $"*{RazorFile.RazorFileExtension}", SearchOption.AllDirectories)
                .Select(f => new RazorFile { Path = f });
            _files = cSharpFiles.Union<IProjectFile>(razorFiles);
        }
    }
}
