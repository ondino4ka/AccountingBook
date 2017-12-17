using System.Web;

namespace AccountingBookBL.Services
{
    public interface IFileService
    {
        void UploadPhoto(string name, HttpPostedFileBase upload);
        byte[] DownloadPhoto(string name);
        void DeletePhoto(string name);
    }
}
