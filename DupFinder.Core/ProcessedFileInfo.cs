namespace DupFinder.Core
{
    public class ProcessedFileInfo
    {

        #region Ctor
        public ProcessedFileInfo()
        {

        }

        public ProcessedFileInfo(string? path,
                                 string? name,
                                 long? length,
                                 DateTime? modificationTime,
                                 string? hash)
        {
            this.FilePath = path;
            this.Name = name;
            this.Length = length;
            this.LastModified = modificationTime;
            this.FileHash = hash;
        }
        #endregion

        #region Public Properties

        public string? FilePath { get; set; }

        /// <summary>
        /// The filename, including extension
        /// </summary>
        public string? Name { get; set; }
         
        /// <summary>
        /// File length, in bytes
        /// </summary>
        public long? Length { get; set; }
         
        /// <summary>
        /// File's last modified date/time
        /// </summary>
        public DateTime? LastModified { get; set; }
         
        /// <summary>
        /// File hash value, as a hex string
        /// </summary>
        public string? FileHash { get; set; }
        #endregion

    }



}