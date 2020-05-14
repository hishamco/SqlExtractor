using System;
using System.Collections.Generic;

namespace SqlExtractor.Core
{
    public class LocalizedString
    {
        public LocalizedString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Text can't be null or empty.", nameof(text));
            }

            Text = text;
            Locations = new List<LocalizedStringLocation>();
        }

        internal LocalizedString(LocalizedStringOccurence localizedStringOccurence) :this(localizedStringOccurence.Text)
        {
            if (localizedStringOccurence is null)
            {
                throw new ArgumentNullException(nameof(localizedStringOccurence));
            }

            Locations.Add(localizedStringOccurence.Location);
        }

        public List<LocalizedStringLocation> Locations { get; }

        public string Text { get; }
    }
}
