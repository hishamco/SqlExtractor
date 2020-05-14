using SqlExtractor.CSharp;
using Xunit;

namespace SqlExtractor.Core.Tests
{
    public class LocalizedStringTests
    {
        [Fact]
        public void ConstructorWithTextParamPopulatesProperties()
        {
            // Arrange
            var text = "Home";

            // Act
            var localizedString = new LocalizedString(text);

            // Assert
            Assert.Equal(localizedString.Text, text);
            Assert.Empty(localizedString.Locations);
        }

        [Fact]
        public void ConstructorWithLocalizedStringOccurenceParamPopulatesProperties()
        {
            // Arrange
            var occurence = new LocalizedStringOccurence
            {
                Text = "Home",
                Location = new LocalizedStringLocation
                {
                    File = new CSharpFile { Path = "Test.cs" },
                    Line = 12,
                    Column = 56
                }
            };

            // Act
            var localizedString = new LocalizedString(occurence);

            // Assert
            Assert.Equal(localizedString.Text, occurence.Text);
            Assert.Single(localizedString.Locations, occurence.Location);

            var location = localizedString.Locations[0];
            Assert.Equal(location.File.Path, occurence.Location.File.Path);
            Assert.Equal(location.Line, occurence.Location.Line);
            Assert.Equal(location.Column, occurence.Location.Column);
        }
    }
}
