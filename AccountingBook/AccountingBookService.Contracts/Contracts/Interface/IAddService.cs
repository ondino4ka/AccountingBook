using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts.Interface
{
    [ServiceContract]
    public interface IAddService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void AddUser(UserDto userDto);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void AddSubject(SubjectDto userDto);
    }
}
