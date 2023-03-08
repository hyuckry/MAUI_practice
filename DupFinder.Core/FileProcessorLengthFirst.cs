using Microsoft.Data.Sqlite;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DupFinder.Core
{
    /// <summary>
    /// This file processor class finds duplicates by
    /// noting all groups of files with the same length
    /// then computing hashes for those files.
    /// </summary>
    public class FileProcessorLengthFirst : IFileProcessor, IDisposable
    {
        #region Ctor

        public FileProcessorLengthFirst()
        { }

        #endregion

        #region IDisposable implementation

        private bool disposed = false; // Has IDisposable.Dispose() already been called

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool calledByUserCode)
        {
            if (!this.disposed)
            {
                if (calledByUserCode)
                {
                    // Clean up managed objects here
                    if (this.databaseConnection != null)
                    {
                        try
                        {
                            if (this.databaseConnection.State != ConnectionState.Closed) this.databaseConnection.Close();
                        }
                        catch (SqliteException)
                        { }
                        if (File.Exists(this.databaseFile)) File.Delete(this.databaseFile);
                        this.databaseConnection.Dispose();
                    }
                }

                // Clean up unmanaged objects here (we don't directly have any, so no need to do anything)

                this.disposed = true;
            }

        }

        /* Destructor is not implemented because
         * we don't have any direct references to local unfinalizable unmanaged resources
         * (Yes I know SQLite has unmanaged code - but
         * let's be optimistic and hope the caller
         * calls dispose on this instance)
        /// <summary>
        /// Destructor for finalizer
        /// </summary>
        ~FileProcessorLengthFirst()
        {
            Dispose(false);
        }
        */

        #endregion

        #region Instance variables

        public string? databaseFile = null; // Fully qualified pathname of the SQLite database file
        private SqliteConnection? databaseConnection = null;

        #endregion

        #region SQL statement constants
        private const string sqlFileInformationFullRowInsert = "INSERT INTO FILEINFORMATION (FILEPATH, FILENAME, FILESIZE, LASTMODIFYDATE, FILEHASH) " +
                                                               "VALUES (@FILEPATH, @FILENAME, @FILESIZE, @LASTMODIFYDATE, @FILEHASH);";
        private const string sqlHashDupeSelect = "select FILEPATH, FILENAME, FILESIZE, FILEHASH, LASTMODIFYDATE from FILEINFORMATION where FILEHASH in " +
                                                          "(select FILEHASH from FILEINFORMATION GROUP BY FILEHASH HAVING COUNT(*) > 1);";
        private const string sqlLengthDupeSelect = "select FILEPATH, FILENAME, FILESIZE, ROWID from FILEINFORMATION where FILESIZE in " +
                                                          "(select FILESIZE from FILEINFORMATION WHERE FILESIZE > 0 GROUP BY FILESIZE HAVING COUNT(*) > 1);";
        private const string sqlFilePathParam = "@FILEPATH";
        private const string sqlFileNameParam = "@FILENAME";
        private const string sqlFileSizeParam = "@FILESIZE";
        private const string sqlLastModifyDateParam = "@LASTMODIFYDATE";
        private const string sqlFileHashParam = "@FILEHASH";
        private const string sqlRowIdParamsqlRowIdParam = "@ROWID";

        private const string sqlFileInformationFileHashUpdate = "update FILEINFORMATION set FILEHASH = @FILEHASH where ROWID = @ROWID";

        private const string sqlColumnFilePath = "FILEPATH";
        private const string sqlColumnFileName = "FILENAME";
        private const string sqlColumnFileSize = "FILESIZE";
        private const string sqlColumnLastModifyDate = "LASTMODIFYDATE";
        private const string sqlColumnFileHash = "FILEHASH";

        #endregion

        #region IFileProcessor implementation

        /// <summary>
        /// Returns a collection of <see cref="ProcessedFileInfo"/> objects
        /// containing any duplicates found
        /// </summary>
        public Collection<ProcessedFileInfo> DuplicateFiles
        {
            get { return RetrieveDuplicates(); }
        }
        public void Close()
        {
            //this.Dispose();
            if (this.databaseConnection != null &&
                this.databaseConnection.State != ConnectionState.Closed)
            {
                try
                {
                    this.databaseConnection.Close();
                }
                catch (SqliteException)
                { }
            }
        }

        /// <summary>
        /// Initializes the SQLite database in a temp
        /// location determined by Windows
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        public bool Initialize()
        {
            return Initialize(null);
        }

        /// <summary>
        /// Initializes the SQLite database
        /// </summary>
        /// <param name="databaseFilePath">The fully qualifed filename to use for the database file</param>
        /// <returns>true if successful, false otherwise</returns>
        public bool Initialize(string? databaseFilePath)
        {
            bool initializedOk = false;
            try
            {
                if (string.IsNullOrEmpty(databaseFilePath) ||
                    string.IsNullOrWhiteSpace(databaseFilePath))
                {
                    databaseFilePath = Path.GetTempFileName();
                    this.databaseFile = databaseFilePath;
                }
                File.Delete(databaseFilePath);
                string connectString = string.Format("Data Source={0}", databaseFilePath);
                this.databaseConnection = new SqliteConnection(connectString);
                this.databaseConnection.Open();
                PerformanceTweaks(this.databaseConnection);
                CreateDatabaseObjects(this.databaseConnection);
                initializedOk = true;
            }
            catch (SqliteException)
            { }
            catch (IOException)
            { }
            catch (UnauthorizedAccessException)
            { }
            return initializedOk;
        }

        private void PerformanceTweaks(SqliteConnection databaseConnection)
        {
            // Turn off journaling and allow async writes -
            // databases are temporary so we don't care if we
            // lose data during a crash
            using (SqliteCommand pragmaCommand = databaseConnection.CreateCommand())
            {
                pragmaCommand.CommandText = "PRAGMA journal_mode = OFF;";
                pragmaCommand.ExecuteNonQuery();
                pragmaCommand.CommandText = "PRAGMA synchronous = OFF;";
                pragmaCommand.ExecuteNonQuery();
            }
        }

        private void CreateDatabaseObjects(SqliteConnection databaseConnection)
        {
            using (SqliteCommand ddlCommand = databaseConnection.CreateCommand())
            {
                ddlCommand.CommandText = "CREATE TABLE FILEINFORMATION (FILEPATH TEXT, FILENAME TEXT, FILESIZE INTEGER, LASTMODIFYDATE TEXT, FILEHASH TEXT);";
                ddlCommand.ExecuteNonQuery();
                ddlCommand.CommandText = "CREATE INDEX IDXFILESIZES ON FILEINFORMATION (FILESIZE);";
                ddlCommand.ExecuteNonQuery();
                ddlCommand.CommandText = "CREATE INDEX IDXFILENAMES ON FILEINFORMATION (FILENAME);";
                ddlCommand.ExecuteNonQuery();
                ddlCommand.CommandText = "CREATE INDEX IDXFILEPATHS ON FILEINFORMATION (FILEPATH);";
                ddlCommand.ExecuteNonQuery();
                ddlCommand.CommandText = "CREATE INDEX IDXFILEHASHES ON FILEINFORMATION (FILEHASH);";
                ddlCommand.ExecuteNonQuery();
            }
        }

        public void ProcessFile(FileInfo fileInformation)
        {
            if (this.databaseConnection == null) return;
            using (SqliteCommand insertCommand = this.databaseConnection.CreateCommand())
            {
                insertCommand.CommandText = sqlFileInformationFullRowInsert;
                insertCommand.Parameters.AddWithValue(sqlFilePathParam, fileInformation.DirectoryName);
                insertCommand.Parameters.AddWithValue(sqlFileNameParam, fileInformation.Name);
                insertCommand.Parameters.AddWithValue(sqlFileSizeParam, fileInformation.Length);
                insertCommand.Parameters.AddWithValue(sqlLastModifyDateParam, fileInformation.LastWriteTime);
                insertCommand.Parameters.AddWithValue(sqlFileHashParam, null);
                insertCommand.ExecuteNonQuery();
            }
        }

       
        private Collection<ProcessedFileInfo> RetrieveDuplicates()
        {
            Collection<ProcessedFileInfo> duplicateFiles = new Collection<ProcessedFileInfo>();
            ComputeHashesForLengthDuplicates();
            if (this.databaseConnection == null) return duplicateFiles;
            using (SqliteCommand selectCommand = this.databaseConnection.CreateCommand())
            {
                selectCommand.CommandText = sqlHashDupeSelect;
                using (SqliteDataReader hashDupeReader = selectCommand.ExecuteReader())
                { 
                    while (hashDupeReader.Read())
                    {
                        ProcessedFileInfo hashDuplicate = new ProcessedFileInfo(hashDupeReader[sqlColumnFilePath] as string,
                                                                                hashDupeReader[sqlColumnFileName] as string,
                                                                                hashDupeReader[sqlColumnFileSize] as long?,
                                                                                Convert.ToDateTime(hashDupeReader[sqlColumnLastModifyDate]) as DateTime?,
                                                                                hashDupeReader[sqlColumnFileHash] as string);
                        duplicateFiles.Add(hashDuplicate);
                    }
                }
            }
            return duplicateFiles;
        }


        private void ComputeHashesForLengthDuplicates()
        {
            if (databaseConnection == null) return;
            using (SqliteCommand selectCommand = databaseConnection.CreateCommand())
            {
                selectCommand.CommandText = sqlLengthDupeSelect;
                using (SqliteDataReader lengthDupeReader = selectCommand.ExecuteReader())
                {
                    using (SqliteCommand updateCommand = this.databaseConnection.CreateCommand())
                    {
                        updateCommand.CommandText = sqlFileInformationFileHashUpdate;
                        StringBuilder filePath = new StringBuilder();
                        while (lengthDupeReader.Read())
                        {
                            filePath.Clear();
                            filePath.Append(lengthDupeReader[sqlColumnFilePath] as string);
                            if (!filePath.ToString().EndsWith("\\")) filePath.Append("\\");
                            filePath.Append(lengthDupeReader[sqlColumnFileName] as string);
                            if (File.Exists(filePath.ToString()))
                            {
                                try
                                {
                                    IFileProcessor fileProcessor = this;
                                    string fileHash = fileProcessor.ComputeFileHash(filePath.ToString());
                                    updateCommand.Parameters.Clear();
                                    updateCommand.Parameters.AddWithValue(sqlFileHashParam, fileHash);
                                    updateCommand.Parameters.AddWithValue(sqlRowIdParamsqlRowIdParam, lengthDupeReader["ROWID"]);
                                    updateCommand.ExecuteNonQuery();
                                }
                                catch (IOException)
                                { }
                                catch (UnauthorizedAccessException)
                                { }
                            }
                        }
                    }
                }
            }
        }
        #endregion
         
    }

}