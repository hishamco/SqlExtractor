using System.Text.RegularExpressions;
using SqlExtractor.Core;

namespace SqlExtractor.CSharp.Views
{
    public class RazorFile : ProjectFile
    {
        public const string RazorFileExtension = ".cshtml";

        private static readonly Regex _localizerRegularExpression = new Regex(@$"@{LocalizerIdentifierName.ViewLocalizer}\[""([\w\s\.!@,{{}}]+)""(,[\w\s]+)?\]", RegexOptions.Compiled);
        
        public override string Extension => RazorFileExtension;

        public override Regex LocalizerPattern => _localizerRegularExpression;
    }
}
