using System.Collections.Generic;

namespace SqlExtractor.Core
{
    public abstract class Project : IProject
    {
        public Project(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public abstract string Extension { get; }


        public virtual IEnumerable<string> Files { get; } = new List<string>();
    }
}
