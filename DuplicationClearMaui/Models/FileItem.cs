using SQLite;

namespace DuplicationClearMaui.Models
{
    public class FileItem
    {
        [Indexed]
        public string FileName { get; set; }
        [Indexed]
        public long FileSize { get; set; }
        [PrimaryKey, Indexed]
        public string FilePath { get; set; }
        [Indexed]
        public string FileHash { get; set; }
    }
}
