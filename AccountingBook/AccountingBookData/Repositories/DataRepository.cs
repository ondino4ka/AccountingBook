using AccountingBookCommon.Models;
using AccountingBookData.Clients;
using System.Collections.Generic;
using System;

namespace AccountingBookData.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly IClient _client;
        public DataRepository(IClient client)
        {
            _client = client;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _client.GetCategories();
        }


        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId)
        {
            return _client.GetSubjectsByCategoryId(categoryId);
        }

        public SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            return _client.GetSubjectInformationByInventoryNumber(inventoryNumber);
        }

        public UserAuthorization GetUserByName(string userName)
        {
            return _client.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _client.IsValidUser(userName, password);
        }

        public bool IsExistsUser(int userId, string userName)
        {
            return _client.IsExistsUser(userId, userName);
        }

        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _client.GetCategoriesByName(categoryName);
        }

        public IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _client.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }


        #region State Operation
        public IReadOnlyCollection<State> GetStates()
        {
            return _client.GetStates();
        }
        public State GetStateById(int stateId)
        {
            return _client.GetStateById(stateId);
        }

        public void EditStateById(int stateId, string stateName)
        {
            _client.EditStateById(stateId, stateName);
        }

        public void AddState(string stateName)
        {
            _client.AddState(stateName);
        }

        public void DeleteStateById(int stateId)
        {
            _client.DeleteStateById(stateId);
        }
        #endregion

        #region User Operation

        public void AddUser(User user)
        {
            _client.AddUser(user);
        }
        public void EditUser(User user)
        {
            _client.EditUser(user);
        }
        public IReadOnlyCollection<Role> GetRoles()
        {
            return _client.GetRoles();
        }
        public User GetUserById(int userId)
        {
            return _client.GetUserById(userId);
        }

        public IReadOnlyCollection<User> GetUsersByName(string userName)
        {
            return _client.GetUsersByName(userName);
        }

        public void DeleteUserById(int userId)
        {
            _client.DeleteUserById(userId);
        }
        #endregion

        #region Location Operations
        public IReadOnlyCollection<Location> GetLocations()
        {
            return _client.GetLocations();
        }
        public IReadOnlyCollection<Location> GetLocationsByAddress(string address)
        {
            return _client.GetLocationsByAddress(address);
        }
        public Location GetLocationsById(int locationId)
        {
            return _client.GetLocationById(locationId);
        }
        public void AddLocation(string address)
        {
            _client.AddtLocation(address);
        }

        public void EditLocationById(int locationId, string address)
        {
            _client.EditLocationById(locationId, address);
        }

        public void DeleteLocationById(int locationId)
        {
            _client.DeleteLocationById(locationId);
        }
        #endregion

        #region Subject Operations
        public Subject GetSubjectByInventoryNumber(int inventoryNumber)
        {
            return _client.GetSubjectByInventoryNumber(inventoryNumber);
        }

        public bool IsExistsSubject(int inventoryNumber)
        {
            return _client.IsExistsSubject(inventoryNumber);
        }

        public void AddSubject(Subject subject)
        {
            _client.AddSubject(subject);
        }


        public void EditSubjectInformation(Subject subject)
        {
            _client.EditSubjectInformation(subject);
        }

        public void DeleteSubjectByInventoryNumber(int inventoryNumber)
        {
            _client.DeleteSubjectByInventoruNumber(inventoryNumber);
        }
        #endregion

        #region File Operations
        public void UploadPhoto(string name, byte[] photo)
        {
            _client.UploadPhoto(name, photo);
        }
        public byte[] DownloadPhoto(string name)
        {
            return _client.DownloadPhoto(name);
        }

        public void DeletePhoto(string name)
        {
            _client.DeletePhoto(name);
        }

        public void EditSubjectPhoto(int inventoryNumber, string photo)
        {
            _client.EditSubjectPhoto(inventoryNumber, photo);
        }
        #endregion
    }
}
