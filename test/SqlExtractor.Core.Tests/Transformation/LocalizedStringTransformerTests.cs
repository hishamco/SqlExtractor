using System.Collections.Generic;
using System.Linq;
using SqlExtractor.Core.Transformation;
using Xunit;

namespace SqlExtractor.Core.Tests.Transformation
{
    public class LocalizedStringTransformerTests
    {
        [Fact]
        public void TransformLocalizedStrings()
        {
            // Arrange
            var transformer = new LocalizedStringTransformer();
            var localizedStrings = new List<LocalizedString>
            {
                new LocalizedString { Text = "Hello" },
                new LocalizedString { Text = "Hello, {0}" }
            };

            // Act
            var transformedStrings = transformer.Transform(localizedStrings, CustomTransformation);

            // Assert
            Assert.True(transformedStrings.All(s => s.StartsWith("-= ") && s.EndsWith(" =-")));
        }

        private string CustomTransformation(LocalizedString localizedString)
            => $"-= {localizedString.Text} =-";
    }
}
