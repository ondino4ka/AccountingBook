using AccountingBookCommon;
using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Clients
{
    public interface IClient
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId);
        SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber);
        UserAuthorization GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        IReadOnlyCollection<Category> GetCategoriesByName(string categoryName);
        IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        IReadOnlyCollection<State> GetStates();


        void AddUser(User user);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyCollection<Role> GetRoles();
        User GetUserById(int userId);
        void EditUser(User user);
        IReadOnlyCollection<User> GetUsersByName(string userName);
        void DeleteUserById(int userId);
        IReadOnlyCollection<Location> GetLocations();


        Subject GetSubjectByInventoryNumber(int inventoryNumber);
        bool IsExistsSubject(int inventoryNumber);
        void AddSubject(Subject subject);
        void EditSubjectInformation(Subject subject);
        void EditSubjectPhoto(int inventoryNumber, string photo);
        void DeleteSubjectByInventoruNumber(int inventoryNumber);


        void UploadPhoto(string name, byte[] photo);
        void DeletePhoto(string name);
        byte[] DownloadPhoto(string name);
    }
}
