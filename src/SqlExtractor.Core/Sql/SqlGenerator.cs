namespace SqlExtractor.Core.Sql
{
    public class SqlGenerator : ISqlGenerator
    {
        public string Generate(LocalizedString localizedString)
            => $"INSERT [dbo].[Localization_Resource] ([CultureId], [Key], [Value]) VALUES ('en-US', N'{localizedString.Text}', N'{localizedString.Text}');";
    }
}
