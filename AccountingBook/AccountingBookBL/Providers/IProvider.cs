using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookBL.Providers
{
    public interface IProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId);
        SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber);
        IReadOnlyCollection<Category> GetCategoriesByName(string category);
        IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        IReadOnlyCollection<State> GetStates();


        IReadOnlyCollection<Location> GetLocations();
        IReadOnlyCollection<Location> GetLocationsByAddress(string address);
        Location GetLocationById(int locationId);


        Subject GetSubjectByInventoryNumber(int inventoryNumber);
        bool IsExistsSubject(int inventoryNumber);
    }
}
