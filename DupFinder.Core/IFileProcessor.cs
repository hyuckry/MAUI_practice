using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace DupFinder.Core
{
    public interface IFileProcessor
    {
        bool Initialize();
        void Close();
        void ProcessFile(FileInfo fileInformation);

        public string ComputeFileHash(string filePath)
        { 
            string? fileHashAsString = null;
            using (StreamReader fileStream = new StreamReader(filePath))
            {
                using (SHA512 hash = SHA512.Create())
                {
                    fileHashAsString = BitConverter.ToString(hash.ComputeHash(fileStream.BaseStream));
                }

            }
            return fileHashAsString;
        }    

        Collection<ProcessedFileInfo> DuplicateFiles { get; }
    }

}