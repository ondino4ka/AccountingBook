using System.ServiceModel;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;

namespace AccountingBookService.Contracts.Contracts
{
    [ServiceContract]
    public interface IEditService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void EditUser(UserDto userDto);
    }
}
