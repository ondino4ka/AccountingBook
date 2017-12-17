using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;
using System.Collections.Generic;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts.Interface
{
    [ServiceContract]
    public interface IGetService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<CategoryDto> GetCategories();

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<SubjectDetailsDto> GetSubjectsByCategoryId(int? categoryId);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        SubjectDetailsDto GetSubjectInformationByInventoryNumber(int inventoryNumber);

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
        StateDto GetStateById(int stateId);


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
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<LocationDto> GetLocations();

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        SubjectDto GetSubjectByInventoryNumber(int inventoryNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        bool IsExistsSubject(int inventoryNumber);

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        List<LocationDto> GetLocationsByAddress(string address);
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        LocationDto GetLocationsById(int locationId);

    }
}
