using System.ServiceModel;
using AccountingBookService.Contracts.Models.DtoException;


namespace AccountingBookService.Contracts.Contracts
{
    [ServiceContract]
    interface IDeleteService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void DeleteUserById(int userId);
    }
}
