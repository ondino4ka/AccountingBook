using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Repositories
{
    public interface IDataRepository
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId);
        SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber);
        UserAuthorization GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        IReadOnlyCollection<Category> GetCategoriesByName(string category);
        IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);


        #region State Operations
        IReadOnlyCollection<State> GetStates();
        State GetStateById(int stateId);
        void AddState(string stateName);
        void EditStateById(int stateId, string stateName);
        void DeleteStateById(int stateId);
        #endregion

        #region User Operations
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUserById(int userId);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyCollection<Role> GetRoles();
        User GetUserById(int userId);
        IReadOnlyCollection<User> GetUsersByName(string userName);
        #endregion

        #region Location Operations

        IReadOnlyCollection<Location> GetLocations();
        IReadOnlyCollection<Location> GetLocationsByAddress(string address);
        Location GetLocationsById(int locationId);
        void AddLocation(string address);
        void EditLocationById(int locationId, string address);
        void DeleteLocationById(int locationId);
        #endregion

        #region SubjectOperation
        Subject GetSubjectByInventoryNumber(int inventoryNumber);
        bool IsExistsSubject(int inventoryNumber);
        void AddSubject(Subject subject);
        void EditSubjectInformation(Subject subject);
        void EditSubjectPhoto(int inventoryNumber, string photo);
        void DeleteSubjectByInventoryNumber(int inventoryNumber);
        #endregion

        #region File Operations
        void UploadPhoto(string name, byte[] photo);
        void DeletePhoto(string name);
        byte[] DownloadPhoto(string name);
        #endregion
    }
}
