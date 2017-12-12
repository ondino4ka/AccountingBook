using System.Collections.Generic;
using System.ServiceModel;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;

namespace AccountingBookService.Contracts.Contracts
{
    [ServiceContract]
    public interface IAccountingBookService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<CategoryDto> GetCategories();
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<SubjectDetailsDto> GetSubjects();
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<SubjectDetailsDto> GetSubjectsByCategoryId(int id);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        SubjectDetailsDto GetSubjectInformationById(int inventoryNumber);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        UserAuthorizationDto GetUserAuthorizationByName(string userName);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        bool IsValidUser(string userName, string password);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<RoleAuthorizationDto> GetRolesAuthorizationByUserId(int userId);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<CategoryDto> GetCategoriesByName(string categoryName);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<SubjectDetailsDto> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<StateDto> GetStates();
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        bool IsExistsUser(int userId, string userName);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<RoleDto> GetRoles();
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        UserDto GetUserById(int userId);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<UserDto> GetUsersByName(string userName);
    }
}
