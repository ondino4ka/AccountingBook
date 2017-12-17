using AccountingBookService.Contracts.Models.DtoException;
using System.ServiceModel;


namespace AccountingBookService.Contracts.Contracts.Interface
{
    [ServiceContract]
    public interface IDeleteService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void DeleteUserById(int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void DeleteSubjectByInventoryNumber(int inventoryNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void DeleteLocationById(int locationId);
    }
}
