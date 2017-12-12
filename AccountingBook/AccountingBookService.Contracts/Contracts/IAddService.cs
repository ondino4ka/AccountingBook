using System.ServiceModel;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;

namespace AccountingBookService.Contracts.Contracts
{
    [ServiceContract]
    public interface IAddService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void AddUser(UserDto userDto);    
    }
}
