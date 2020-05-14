using System;
using System.Collections.Generic;

namespace SqlExtractor.Core
{
    public static class LocalizedStringCollectionExtensions
    {
        public static void Add(this LocalizedStringCollection collection, LocalizedStringOccurence value)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            collection.Add(new LocalizedString(value));
        }

        public static void AddRange(this LocalizedStringCollection collection, IEnumerable<LocalizedString> values)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (var value in values)
            {
                collection.Add(value);
            }
        }

        public static void AddRange(this LocalizedStringCollection collection, IEnumerable<LocalizedStringOccurence> values)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (var value in values)
            {
                collection.Add(value);
            }
        }
    }
}
