using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AccountingBookData.Clients.Implementations
{
    public class UserClient : IUserClient
    {
        private static readonly ILog Log = LogManager.GetLogger("UserClient");

        public UserAuthorization GetUserByName(string userName)
        {
            bool isClosed = false;
            var result = new UserAuthorization();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetUserAuthorizationByName(userName);
                result = new UserAuthorization() { Name = data.Name, Roles = data.Roles.Select(x => new RoleAuthorization() { RoleName = x.RoleName }).ToList() };
                client.Close();
                isClosed = true;
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
            return result;
        }

        public bool IsValidUser(string userName, string password)
        {
            bool isClosed = false;
            var result = false;
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                result = client.IsValidUser(userName, password);
                client.Close();
                isClosed = true;
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
            return result;
        }

        public bool IsExistsUser(int userId, string userName)
        {
            bool isClosed = false;
            var result = false;
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                result = client.IsExistsUser(userId, userName);
                client.Close();
                isClosed = true;
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
            return result;
        }

        public void AddUser(User user)
        {
            bool isClosed = false;
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
                client.Close();
                isClosed = true;
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
        }

        public void EditUser(User user)
        {
            bool isClosed = false;
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
                client.Close();
                isClosed = true;
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
        }

        public IReadOnlyCollection<Role> GetRoles()
        {
            bool isClosed = false;
            var result = new List<Role>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetRoles();
                result = data == null ? result : data.Select(x => new Role { Id = x.Id, Name = x.Name }).ToList();
                client.Close();
                isClosed = true;
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
            return result;
        }

        public User GetUserById(int userId)
        {
            bool isClosed = false;
            var result = new User();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetUserById(userId);
                result = data == null ? null : new User() { Id = data.Id, Name = data.Name, Email = data.Email, Roles = data.Roles };
                client.Close();
                isClosed = true;
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
            return result;
        }

        public IReadOnlyCollection<User> GetUsersByName(string userName)
        {
            bool isClosed = false;
            var result = new List<User>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetUsersByName(userName);
                result = data == null ? result : data.Select(x => new User { Id = x.Id, Name = x.Name, Email = x.Email }).ToList();
                client.Close();
                isClosed = true;
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
            return result;
        }

        public void DeleteUserById(int userId)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteUserById(userId);
                client.Close();
                isClosed = true;
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            finally
            {
                if (!isClosed)
                {
                    client.Abort();
                }
                Log.Info(Constants.CONNECTION_STATUS);
            }
        }
    }
}
