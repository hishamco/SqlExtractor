using SqlExtractor.Core;
using System.Text.RegularExpressions;

namespace SqlExtractor.CSharp.Views
{
    public class HtmlFile : ProjectFile
    {
        public const string HtmlFileExtension = ".html";

        private static readonly Regex _angularJslocalizerPattern = new Regex(@"{{::vm\.translate\.get\('([\w\s\.!@,]+)'\)}}", RegexOptions.Compiled);

        public override string Extension => HtmlFileExtension;

        public override Regex LocalizerPattern => _angularJslocalizerPattern;
    }
}
