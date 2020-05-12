using System.Text.RegularExpressions;

namespace SqlExtractor.Core
{
    public abstract class ProjectFile : IProjectFile
    {
        internal static readonly Regex DefaultLocalizerPattern = default;

        public abstract string Extension { get; }

        public string Path { get; set; }

        public virtual Regex LocalizerPattern => DefaultLocalizerPattern;
    }
}
