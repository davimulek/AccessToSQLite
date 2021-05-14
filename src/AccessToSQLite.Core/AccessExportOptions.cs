using System.IO;

namespace AccessToSQLite.Core
{
    public class AccessExportOptions
    {
        private string accessFileName;

        public string AccessFileName
        {
            get { return accessFileName; }
            set
            {
                accessFileName = value;
                SqLiteFileName = Path.Combine(SqLiteInitialDirectory, SqLiteDefaultFileName);
            }
        }

        public string AccessPassword { get; set; }

        public string SqLiteFileName { get; set; }

        public bool Executing { get; set; }
        
        public bool CanExport => File.Exists(AccessFileName) && !Executing && !string.IsNullOrEmpty(SqLiteFileName);

        public bool SqLiteFileExists => File.Exists(SqLiteFileName);

        public string SqLiteInitialDirectory => Path.GetDirectoryName(AccessFileName);

        public string SqLiteDefaultFileName => $"{Path.GetFileNameWithoutExtension(AccessFileName)}.sqlite3";
    }
}
