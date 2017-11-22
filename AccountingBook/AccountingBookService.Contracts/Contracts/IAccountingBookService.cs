using System.Collections.Generic;
using AccountingBookService.Contracts.Models.Dto;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts
{
    [ServiceContract]
    public interface IAccountingBookService
    {
        [OperationContract]
        List<SubjectDto> GetSubjects();
        [OperationContract]
        List<CategoryDto> GetCategories();
        [OperationContract]
        List<SubCategoryDto> GetSubCategories();
        [OperationContract]
        SubjectDto GetSubjectInformationById(int inventoryNumberSubject);
    }
}
