using SqlExtractor.Core.Sql;
using Xunit;

namespace SqlExtractor.Core.Tests.Sql
{
    public class SqlGeneratorTests
    {
        [Fact]
        public void GenerateSqlStatementForLocalizedString()
        {
            // Arrange
            var generator = new SqlGenerator();
            var localizedString = new LocalizedString { Text = "Hello" };

            // Act
            var sql = generator.Generate(localizedString);

            // Assert
            Assert.Equal("INSERT [dbo].[Localization_Resource] ([CultureId], [Key], [Value]) VALUES ('en-US', N'Hello');", sql);
        }
    }
}
