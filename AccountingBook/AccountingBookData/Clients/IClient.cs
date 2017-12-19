using AccountingBookCommon;
using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Clients
{
    public interface IClient
    {
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId);
        SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber);
        UserAuthorization GetUserByName(string userName);
        bool IsValidUser(string userName, string password);


        #region Categories Operations
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId);
        IReadOnlyCollection<Category> GetCategoriesByName(string categoryName);
        Category GetCategoryById(int categoryId);
        void AddCategory(int? pid, string categoryName);
        void EditCategoryById(int categoryId, int? pid, string categoryName);      
        void DeleteCategoryById(int categoryId);
        #endregion

        #region State Opearations
        IReadOnlyCollection<State> GetStates();
        State GetStateById(int stateId);
        void AddState(string stateName);
        void EditStateById(int stateId, string stateName);
        void DeleteStateById(int stateId);
        #endregion

        #region User Operations
        void AddUser(User user);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyCollection<Role> GetRoles();
        User GetUserById(int userId);
        void EditUser(User user);
        IReadOnlyCollection<User> GetUsersByName(string userName);
        void DeleteUserById(int userId);
        #endregion

        #region Subject Operations
        Subject GetSubjectByInventoryNumber(int inventoryNumber);
        bool IsExistsSubject(int inventoryNumber);
        void AddSubject(Subject subject);
        void EditSubjectInformation(Subject subject);
        void EditSubjectPhoto(int inventoryNumber, string photo);
        void DeleteSubjectByInventoruNumber(int inventoryNumber);
        IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        #endregion

        #region Location Operations
        IReadOnlyCollection<Location> GetLocations();
        IReadOnlyCollection<Location> GetLocationsByAddress(string address);
        Location GetLocationById(int locationId);
        void AddtLocation(string address);
        void EditLocationById(int locationId, string address);
        void DeleteLocationById(int locationId);
        #endregion

        #region File Operations
        void UploadPhoto(string name, byte[] photo);
        void DeletePhoto(string name);
        byte[] DownloadPhoto(string name);
        #endregion
    }
}
