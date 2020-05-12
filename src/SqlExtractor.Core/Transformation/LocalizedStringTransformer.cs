using System.Collections.Generic;

namespace SqlExtractor.Core.Transformation
{
    public class LocalizedStringTransformer : ILocalizedStringTransformer
    {
        public IEnumerable<string> Transform(IEnumerable<LocalizedString> localizedStrings, LocalizedStringTransformationDelegate localizedStringTransformation)
        {
            var transformedStrings = new List<string>();
            foreach (var localizedString in localizedStrings)
            {
                var transformedString = localizedStringTransformation.Invoke(localizedString);
                transformedStrings.Add(transformedString);
            }

            return transformedStrings;
        }
    }
}
