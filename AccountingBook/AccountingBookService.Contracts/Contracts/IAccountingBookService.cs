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
        List<SubjectDto> GetSubjects();
        [OperationContract]
        List<SubjectDto> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory);  
        [OperationContract]
        SubjectDto GetSubjectInformationById(int inventoryNumber);
    }
}
