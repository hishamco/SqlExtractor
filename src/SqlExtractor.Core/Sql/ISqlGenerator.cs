namespace SqlExtractor.Core.Sql
{
    public interface ISqlGenerator
    {
        string Generate(LocalizedString localizedString);
    }
}
