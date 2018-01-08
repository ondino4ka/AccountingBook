namespace AccountingBookData.Repositories.Interfaces
{
    public interface IFileRepository
    {
        void UploadPhoto(string name, byte[] photo);
        void DeletePhoto(string name);
        byte[] DownloadPhoto(string name);
    }
}
