using System;
using System.Collections;
using System.Collections.Generic;

namespace SqlExtractor.Core
{
    public class LocalizedStringCollection : ICollection<LocalizedString>
    {
        private readonly IDictionary<string, LocalizedString> _localizedStringsDictionary;

        public LocalizedStringCollection()
        {
            _localizedStringsDictionary = new Dictionary<string, LocalizedString>();
        }

        public IEnumerable<LocalizedString> Values => _localizedStringsDictionary.Values;

        public int Count => _localizedStringsDictionary.Values.Count;

        public bool IsReadOnly => _localizedStringsDictionary.Values.IsReadOnly;

        public void Add(LocalizedString item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var key = item.Text;
            if (_localizedStringsDictionary.TryGetValue(key, out var localizedString))
            {
                localizedString.Locations.AddRange(item.Locations);
            }
            else
            {
                _localizedStringsDictionary.Add(key, item);
            }
        }

        public void Clear()
        {
            _localizedStringsDictionary.Clear();
        }

        public bool Contains(LocalizedString item) => _localizedStringsDictionary.Values.Contains(item);

        public void CopyTo(LocalizedString[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<LocalizedString> GetEnumerator() => _localizedStringsDictionary.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Remove(LocalizedString item) => _localizedStringsDictionary.Remove(item.Text);
    }
}
