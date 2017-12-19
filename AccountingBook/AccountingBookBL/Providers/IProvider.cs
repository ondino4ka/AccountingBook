using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookBL.Providers
{
    public interface IProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId);
        IReadOnlyCollection<Category> GetCategoriesByName(string category);
        Category GetCategoryById(int categoryId);

        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId);
        SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber);
        IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        Subject GetSubjectByInventoryNumber(int inventoryNumber);
        bool IsExistsSubject(int inventoryNumber);

        IReadOnlyCollection<State> GetStates();
        State GetStateById(int stateId);


        IReadOnlyCollection<Location> GetLocations();
        IReadOnlyCollection<Location> GetLocationsByAddress(string address);
        Location GetLocationById(int locationId);


    }
}
