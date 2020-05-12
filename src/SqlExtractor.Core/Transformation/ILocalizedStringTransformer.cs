using System.Collections.Generic;

namespace SqlExtractor.Core.Transformation
{
    public interface ILocalizedStringTransformer
    {
        IEnumerable<string> Transform(IEnumerable<LocalizedString> localizedStrings, LocalizedStringTransformationDelegate localizedStringTransformation);
    }
}
