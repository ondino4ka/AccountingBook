namespace AccountingBookData.Clients.Interfaces
{
    public interface IFileClient
    {
        void UploadPhoto(string name, byte[] photo);
        void DeletePhoto(string name);
        byte[] DownloadPhoto(string name);
    }
}
