using System;
using System.Linq;
using System.ServiceModel;
using log4net;
using System.Collections.Generic;
using AccountingBookCommon;
using AccountingBookCommon.Models;

namespace AccountingBookData.Clients
{
    public class Client : IClient
    {
        private static readonly ILog Log = LogManager.GetLogger("Client");
        public IReadOnlyList<Category> GetCategories()
        {
            var result = new List<Category>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategories();
                result = data == null ? result : data.Select(x => new Category { Id = x.Id, Pid = x.Pid, Name = x.Name }).ToList();
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId)
        {
            var result = new List<SubjectDetails>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectsByCategoryId(categoryId);
                result = data == null ? result : data.Select(x => new SubjectDetails { InventoryNumber = x.InventoryNumber, Name = x.Name, Photo = x.Photo, Description = x.Description }).ToList();
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public SubjectDetails GetSubjectInformationById(int inventoryNumber)
        {
            var result = new SubjectDetails();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectInformationById(inventoryNumber);
                result = new SubjectDetails() { InventoryNumber = data.InventoryNumber, Name = data.Name, State = data.State, Description = data.Description, Photo = data.Photo, Location = data.Location, Category = data.Category };
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public UserAuthorization GetUserByName(string userName)
        {
            var result = new UserAuthorization();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetUserAuthorizationByName(userName);
                result = new UserAuthorization() { Name = data.Name, Roles = data.Roles.Select(x => new RoleAuthorization() { RoleName = x.RoleName }).ToList() };
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public bool IsValidUser(string userName, string password)
        {
            var result = false;
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                result = client.IsValidUser(userName, password);
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public bool IsExistsUser(int userId, string userName)
        {
            var result = false;
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                result = client.IsExistsUser(userId, userName);
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }


        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            var result = new List<Category>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategoriesByName(categoryName);
                result = data == null ? result : data.Select(x => new Category { Id = x.Id, Name = x.Name }).ToList();
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }


        public IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            var result = new List<SubjectDetails>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
                result = data == null ? result : data.Select(x => new SubjectDetails { InventoryNumber = x.InventoryNumber, Name = x.Name, Photo = x.Photo, Description = x.Description }).ToList();
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public IReadOnlyCollection<State> GetStates()
        {
            var result = new List<State>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetStates();
                result = data == null ? result : data.Select(x => new State { Id = x.Id, StateName = x.StateName }).ToList();
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public void AddUser(User user)
        {
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                AccountingBookServiceReference.UserDto userDto = new AccountingBookServiceReference.UserDto()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Roles = user.Roles,
                };
                client.AddUser(userDto);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }

        public void EditUser(User user)
        {
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                AccountingBookServiceReference.UserDto userDto = new AccountingBookServiceReference.UserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Roles = user.Roles,
                };
                client.EditUser(userDto);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }


        public IReadOnlyCollection<Role> GetRoles()
        {
            var result = new List<Role>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetRoles();
                result = data == null ? result : data.Select(x => new Role { Id = x.Id, Name = x.Name }).ToList();
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public User GetUserById(int userId)
        {
            var result = new User();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetUserById(userId);
                result = data == null ? null : new User() { Id = data.Id, Name = data.Name, Email = data.Email, Password = data.Password, Roles = data.Roles };
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public IReadOnlyCollection<User> GetUsersByName(string userName)
        {
            var result = new List<User>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetUsersByName(userName);
                result = data == null ? result : data.Select(x => new User { Id = x.Id, Name = x.Name, Email = x.Email, Password = x.Password }).ToList();
                client.Close();
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public void DeleteUser(int userId)
        {
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteUserById(userId);
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }
    }
}
