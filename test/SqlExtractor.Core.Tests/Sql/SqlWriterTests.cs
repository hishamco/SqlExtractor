using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SqlExtractor.Core.Sql;
using Xunit;

namespace SqlExtractor.Core.Tests.Sql
{
    public class SqlWriterTests
    {
        [Fact]
        public async Task WriteSingleSqlStatement()
        {
            // Arrange
            var sqlStatement = "Select * From Cultures";
            var path = "test.sql";
            var sqlWriter = new SqlWriter(path);

            // Act
            await sqlWriter.WriteLineAsync(sqlStatement);

            // Assert
            var content = await File.ReadAllTextAsync(path);
            Assert.Contains(sqlStatement, content);

            File.Delete(path);
        }

        [Fact]
        public async Task WriteMultipleSqlStatements()
        {
            // Arrange
            var sqlStatements = new[] { "Select * From Cultures", "Select * From Languages" };
            var path = "test.sql";
            var sqlWriter = new SqlWriter(path);

            // Act
            await sqlWriter.WriteLineAsync(sqlStatements);

            // Assert
            var content = await File.ReadAllTextAsync(path);
            Assert.True(sqlStatements.All(s => content.Contains(s)));

            File.Delete(path);
        }
    }
}
