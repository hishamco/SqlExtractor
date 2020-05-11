using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlExtractor.Core
{
    public interface ILocalizedStringExtractor
    {
        Task<IEnumerable<LocalizedString>> ExtractAsync();
    }
}
