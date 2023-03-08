namespace DupFinder.Core
{
    /// <summary>
    /// 
    /// </summary>
    public enum DirectoryWalkObjectType
    {
        Undefined = 0,
        File,
        Directory
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DirectoryWalkOperationResult
    {
        NotApplicable = 0,
        Success,
        Failure,
        Error
    }

    /// <summary>
    /// Contains data for events raised by
    /// the <see cref="DirectoryWalker"/> class.
    /// Inherits from the <see cref="EventArgs"/> class.
    /// </summary>
    public class DirectoryWalkEventArgs : EventArgs
    {

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="fileSystemObjectPath"></param>
        /// <param name="fileSystemObjectName"></param>
        /// <param name="fileSystemObjectType">Type of object</param>
        /// <param name="resultCode"></param>
        /// <param name="message">A human readable description of the event</param>
        public DirectoryWalkEventArgs(string fileSystemObjectPath,
                                      string fileSystemObjectName,
                                      DirectoryWalkObjectType fileSystemObjectType,
                                      DirectoryWalkOperationResult resultCode,
                                      string message)
        {
            this.objectFullPath = fileSystemObjectPath;
            this.objectName = fileSystemObjectName;
            this.objectDirectoryWalkType = fileSystemObjectType;
            this.operationResultCode = resultCode;
            this.eventMessage = message;
        }

        #endregion

        #region Public properties

        private string objectFullPath;
        /// <summary>
        /// The fully qualified path to the object.
        /// </summary>
        public string FullPath
        {
            get { return this.objectFullPath; }
        }

        private string objectName;
        /// <summary>
        /// Name of the object. Will be empty
        /// if the object is a directory.
        /// </summary>
        public string Name
        {
            get { return this.objectName; }
        }

        private DirectoryWalkObjectType objectDirectoryWalkType;
        /// <summary>
        /// The object's type. Will be a <see cref="DirectoryWalkObjectType"/> value.
        /// </summary>
        public DirectoryWalkObjectType ObjectType
        {
            get { return this.objectDirectoryWalkType; }
        }

        private DirectoryWalkOperationResult operationResultCode;
        /// <summary>
        /// Result of the operation. Will be a <see cref="DirectoryWalkOperationResult"/> value.
        /// </summary>
        public DirectoryWalkOperationResult Result
        {
            get { return this.operationResultCode; }
        }

        private string eventMessage;
        /// <summary>
        /// A human readable message about the raised event.
        /// </summary>
        public string Message
        {
            get { return this.eventMessage; }
        }

        #endregion

    }
}