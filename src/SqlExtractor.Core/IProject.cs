using System.Collections.Generic;

namespace SqlExtractor.Core
{
    public interface IProject
    {
        string Path { get; }

        string Extension { get; }

        IEnumerable<IProjectFile> Files { get; }
    }
}
