using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlExtractor.Core.Extraction
{
    public interface ILocalizedStringExtractor
    {
        Task<IEnumerable<LocalizedString>> ExtractAsync();
    }
}
