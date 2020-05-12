namespace SqlExtractor.Core
{
    public interface IProjectFile : ILocalizableFile
    {
        string Extension { get; }
        
        string Path { get; set; }
    }
}
