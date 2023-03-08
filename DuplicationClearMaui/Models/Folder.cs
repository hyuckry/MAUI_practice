using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicationClearMaui.Models
{
    public class FolderItem
    {
        [PrimaryKey, Indexed]
        public string FilePath { get; set; }
    }

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

    public class FileDetails
    {
        public FileDetails(string filename, long size, DateTimeOffset timestamp, ulong hash = 0)
        {
            Filename = filename;
            Size = size;
            Timestamp = timestamp;
            Hash = hash;
        }

        public string Filename { get; }
        public long Size { get; }
        public DateTimeOffset Timestamp { get; }
        public ulong Hash { get; set; }

        public override string ToString()
        {
            return $"{Filename} || {Size} || {Timestamp} || {Hash}";
        }
    }
}
