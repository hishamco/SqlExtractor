using System.Linq;
using Xunit;

namespace SqlExtractor.Core.Tests
{
    public class LocalizedStringCollectionTests
    {
        [Fact]
        public void LocalizedStringCollectionStoreUniqueStrings()
        {
            // Arrange
            var localizedStrings = new LocalizedStringCollection();

            // Act
            localizedStrings.Add(new LocalizedString("Hello"));
            localizedStrings.Add(new LocalizedString("Hello, {0}"));
            localizedStrings.Add(new LocalizedString("Hello"));
            localizedStrings.Add(new LocalizedString("Hello"));
            localizedStrings.Add(new LocalizedString("Hello"));
            localizedStrings.Add(new LocalizedString("Hello, {0}"));

            // Assert
            Assert.Single(localizedStrings, s => s.Text == "Hello");
            Assert.Single(localizedStrings, s => s.Text == "Hello, {0}");
        }

        [Fact]
        public void LocalizedStringCollectionShouldKeepTrackForStringOccurences()
        {
            // Arrange
            var localizedStrings = new LocalizedStringCollection();

            // Act
            localizedStrings.Add(new LocalizedStringOccurence { Text = "Hello", Location = new LocalizedStringLocation() });
            localizedStrings.Add(new LocalizedStringOccurence { Text = "Hello, {0}", Location = new LocalizedStringLocation() });
            localizedStrings.Add(new LocalizedStringOccurence { Text = "Hello", Location = new LocalizedStringLocation() });
            localizedStrings.Add(new LocalizedStringOccurence { Text = "Hello", Location = new LocalizedStringLocation() });
            localizedStrings.Add(new LocalizedStringOccurence { Text = "Hello, {0}", Location = new LocalizedStringLocation() });
            localizedStrings.Add(new LocalizedStringOccurence { Text = "Hello", Location = new LocalizedStringLocation() });

            // Assert
            Assert.Equal(4, localizedStrings.Single(s => s.Text == "Hello").Locations.Count);
            Assert.Equal(2, localizedStrings.Single(s => s.Text == "Hello, {0}").Locations.Count);
        }
    }
}
