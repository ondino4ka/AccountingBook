using AccountingBookData.Repositories;
using System;
using System.IO;
using System.Web;

namespace AccountingBookBL.Services
{
    public class FileService : IFileService
    {
        private readonly IDataRepository _dataRepository;
        public FileService(IDataRepository dataProvider)
        {
            _dataRepository = dataProvider;
        }
        public byte[] DownloadPhoto(string name)
        {
            return _dataRepository.DownloadPhoto(name);
        }

        public void UploadPhoto(string name, HttpPostedFileBase upload)
        {
            string extension = Path.GetExtension(upload.FileName);
            byte[] arrayBytePhoto = new byte[upload.ContentLength];
            upload.InputStream.Read(arrayBytePhoto, 0, upload.ContentLength);
            _dataRepository.UploadPhoto(name + extension, arrayBytePhoto);
        }

        public void DeletePhoto(string name)
        {
            _dataRepository.DeletePhoto(name);
        }
    }
}
