using AccountingBookService.Contracts.Models.DtoException;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts.Interface
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void UploadPhoto(string name, byte[] photo);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        byte[] DownloadPhoto(string name);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void DeletePhoto(string name);
    }
}
