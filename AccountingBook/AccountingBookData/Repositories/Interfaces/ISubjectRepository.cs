using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId);
        SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber);
        Subject GetSubjectByInventoryNumber(int inventoryNumber);
        bool IsExistsSubject(int inventoryNumber);
        void AddSubject(Subject subject);
        void EditSubjectInformation(Subject subject);
        void EditSubjectPhoto(int inventoryNumber, string photo);
        void DeleteSubjectByInventoryNumber(int inventoryNumber);
        IReadOnlyList<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
    }
}
