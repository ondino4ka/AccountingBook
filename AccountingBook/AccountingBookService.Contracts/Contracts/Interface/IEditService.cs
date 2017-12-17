using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts.Interface
{
    [ServiceContract]
    public interface IEditService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void EditUser(UserDto userDto);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void EditSubjectInformation(SubjectDto subjectDto);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void EditSubjectPhoto(int inventoryNumber, string photo);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void EditLocationById(int locationId, string address);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        void EditStateById(int stateId, string stateName);
    }
}
