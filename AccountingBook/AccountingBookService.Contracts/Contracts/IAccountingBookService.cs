using System.Collections.Generic;
using AccountingBookService.Contracts.Models.Dto;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts
{
    [ServiceContract]
    public interface IAccountingBookService
    {       
        [OperationContract]
        List<CategoryDto> GetCategories();
        [OperationContract]
        List<SubCategoryDto> GetSubCategories();
        [OperationContract]
        List<SubjectDetailsDto> GetSubjects();
        [OperationContract]
        List<SubjectDetailsDto> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory);  
        [OperationContract]
        SubjectDetailsDto GetSubjectInformationById(int inventoryNumber);
    }
}
