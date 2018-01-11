using AccountingBookData.Clients.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;

namespace AccountingBookData.Repositories.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly IFileClient _fileClient;
        public FileRepository(IFileClient fileClient)
        {
            if (fileClient == null)
            {
                throw new ArgumentNullException("fileClient is null");
            }
            _fileClient = fileClient;
        }

        public void UploadPhoto(string name, byte[] photo)
        {
            _fileClient.UploadPhoto(name, photo);
        }
        public byte[] DownloadPhoto(string name)
        {
            return _fileClient.DownloadPhoto(name);
        }

        public void DeletePhoto(string name)
        {
            _fileClient.DeletePhoto(name);
        }
    }
}
