using SqlExtractor.Core;

namespace SqlExtractor.CSharp
{
    public class CSharpFile : ProjectFile
    {
        public const string CSharpFileExtension = ".cs";

        public override string Extension => CSharpFileExtension;
    }
}
