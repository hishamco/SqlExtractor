using System.Collections.Generic;

namespace SqlExtractor.Core
{
    public class LocalizedString
    {
        public LocalizedString()
        {
            Locations = new List<LocalizedStringLocation>();
        }

        public IList<LocalizedStringLocation> Locations { get; }

        public string Text { get; set; }
    }
}
