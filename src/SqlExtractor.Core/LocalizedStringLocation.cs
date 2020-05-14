namespace SqlExtractor.Core
{
    public class LocalizedStringLocation
    {
        public IProjectFile File { get; set; }

        public int Column { get; set; }

        public int Line { get; set; }
    }
}
