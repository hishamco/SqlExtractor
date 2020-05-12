using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SqlExtractor.Core.Sql
{
    public class SqlWriter
    {
        public const string SqlScriptFileExtension = ".sql";

        private readonly string _path;

        public SqlWriter(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("The path can't be null or empty.", nameof(path));
            }

            _path = path;
        }

        public async Task WriteLineAsync(string contents) => await File.WriteAllTextAsync(_path, contents);

        public async Task WriteLineAsync(IEnumerable<string> contents) => await File.WriteAllLinesAsync(_path, contents);
    }
}
