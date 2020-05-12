using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SqlExtractor.Core.Extraction
{
    public class LocalizedStringComparer : IEqualityComparer<LocalizedString>
    {
        public bool Equals([AllowNull] LocalizedString x, [AllowNull] LocalizedString y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }       

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Text == y.Text;
        }

        public int GetHashCode([DisallowNull] LocalizedString obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 0;
            }

            return obj.Text == null ? 0 : obj.Text.GetHashCode();
        }
    }
}
