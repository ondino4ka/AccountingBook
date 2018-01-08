using AccountingBookBL.Services.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.IO;
using System.Web;

namespace AccountingBookBL.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            if (fileRepository == null)
            {
                throw new ArgumentException("fileRepository is null");
            }
            _fileRepository = fileRepository;
        }
        public byte[] DownloadPhoto(string name)
        {
            return _fileRepository.DownloadPhoto(name);
        }

        public void UploadPhoto(string name, HttpPostedFileBase upload)
        {
            string extension = Path.GetExtension(upload.FileName);
            byte[] arrayBytePhoto = new byte[upload.ContentLength];
            upload.InputStream.Read(arrayBytePhoto, 0, upload.ContentLength);
            _fileRepository.UploadPhoto(name + extension, arrayBytePhoto);
        }

        public void DeletePhoto(string name)
        {
            _fileRepository.DeletePhoto(name);
        }
    }
}
