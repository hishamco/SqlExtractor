using System.Text.RegularExpressions;

namespace SqlExtractor.Core
{
    public interface ILocalizableFile
    {
        Regex LocalizerPattern { get; }
    }
}
