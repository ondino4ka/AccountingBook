using AccountingBookCommon.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AccountingBookData.Clients
{
    public class Client : IClient
    {
        private static readonly ILog Log = LogManager.GetLogger("Client");
        public IReadOnlyList<Category> GetCategories()
        {
            var result = new List<Category>();
            var client = new AccountingBookServiceReference.GetServiceClient();
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

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId)
        {
            var result = new List<SubjectDetails>();
            var client = new AccountingBookServiceReference.GetServiceClient();
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

        public SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            var result = new SubjectDetails();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectInformationByInventoryNumber(inventoryNumber);
                result = data == null ? null : new SubjectDetails() { InventoryNumber = data.InventoryNumber, Name = data.Name, State = data.State, Description = data.Description, Photo = data.Photo, Location = data.Location, Category = data.Category };
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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

        public State GetStateById(int stateId)
        {
            var result = new State();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetStateById(stateId);
                result = data == null? null : new State() { Id = data.Id, StateName = data.StateName };
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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
            var client = new AccountingBookServiceReference.GetServiceClient();
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

        public void DeleteUserById(int userId)
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

       
        public IReadOnlyCollection<Location> GetLocations()
        {
            var result = new List<Location>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetLocations();
                result = data == null ? result : data.Select(x => new Location { Id = x.Id, Address = x.Address }).ToList();
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

        public Subject GetSubjectByInventoryNumber(int inventoryNumber)
        {
            var result = new Subject();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectByInventoryNumber(inventoryNumber);
                result = data == null ? null : new Subject() { InventoryNumber = data.InventoryNumber, Name = data.Name, CategoryId = data.CategoryId, LocationId = data.LocationId, Description = data.Description, StateId = data.StateId, Photo = data.Photo };
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

        public bool IsExistsSubject(int inventoryNumber)
        {
            var result = false;
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                result = client.IsExistsSubject(inventoryNumber);
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

        public void AddSubject(Subject subject)
        {
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                AccountingBookServiceReference.SubjectDto subjectDto = new AccountingBookServiceReference.SubjectDto()
                {
                    InventoryNumber = subject.InventoryNumber,
                    Name = subject.Name,
                    StateId = subject.StateId,
                    CategoryId = subject.CategoryId,
                    LocationId = subject.LocationId,
                    Description = subject.Description,
                    Photo = subject.Photo
                };
                client.AddSubject(subjectDto);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }


        public void EditSubjectInformation(Subject subject)
        {
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                AccountingBookServiceReference.SubjectDto subjectDto = new AccountingBookServiceReference.SubjectDto()
                {
                    InventoryNumber = subject.InventoryNumber,
                    Name = subject.Name,
                    StateId = subject.StateId,
                    CategoryId = subject.CategoryId,
                    LocationId = subject.LocationId,
                    Description = subject.Description,
                };
                client.EditSubjectInformation(subjectDto);
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
 
        public void DeleteSubjectByInventoruNumber(int inventoryNumber)
        {
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteSubjectByInventoryNumber(inventoryNumber);
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



        public void UploadPhoto(string name, byte[] photo)
        {
            var client = new AccountingBookServiceReference.FileServiceClient();
            try
            {
                client.Open();
                client.UploadPhoto(name, photo);
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
            catch (ProtocolException protocolException)
            {
                Log.Error(protocolException.Message);
                throw new Exception("Exceeded file size limit");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }


        public byte[] DownloadPhoto(string name)
        {
            var result = new byte[] { };
            var client = new AccountingBookServiceReference.FileServiceClient();
            try
            {
                client.Open();
                var data = client.DownloadPhoto(name);
                result = data == null ? result : data;
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (CommunicationException communicationException)
            {
                Log.Error(communicationException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
            return result;
        }

        public void DeletePhoto(string name)
        {
            var client = new AccountingBookServiceReference.FileServiceClient();
            try
            {
                client.Open();
                client.DeletePhoto(name);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (CommunicationException communicationException)
            {
                Log.Error(communicationException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }

        public void EditSubjectPhoto(int inventoryNumber, string photo)
        {
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditSubjectPhoto(inventoryNumber, photo);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (InvalidCastException castException)
            {
                Log.Error(castException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (CommunicationException communicationException)
            {
                Log.Error(communicationException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }


        public IReadOnlyCollection<Location> GetLocationsByAddress(string address)
        {
            var result = new List<Location>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetLocationsByAddress(address);
                result = data == null ? result : data.Select(x => new Location { Id = x.Id, Address = x.Address }).ToList();
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

        public Location GetLocationById(int locationId)
        {
            var result = new Location();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetLocationsById(locationId);
                result = data == null ? null : new Location() { Id = data.Id, Address = data.Address };
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

        public void AddtLocation(string address)
        {
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                client.AddLocation(address);
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

        public void EditLocationById(int locationId, string address)
        {
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditLocationById(locationId, address);
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

        public void DeleteLocationById(int locationId)
        {
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteLocationById(locationId);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }

        public void AddState(string stateName)
        {
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                client.AddState(stateName);
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

        public void EditStateById(int stateId, string stateName)
        {
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditStateById(stateId, stateName);
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

        public void DeleteStateById(int stateId)
        {
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteStateById(stateId);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            var result = new Category();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategoryById(categoryId);
                result = data == null ? null : new Category() { Id = data.Id, Pid = data.Pid, Name = data.Name };
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

        public void AddCategory(int? pid, string categoryName)
        {
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                client.AddCategory(pid, categoryName);
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

        public void EditCategoryById(int categoryId, int? pid, string categoryName)
        {
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditCategoryById(categoryId, pid, categoryName);
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

        public void DeleteCategoryById(int categoryId)
        {
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteCategoryById(categoryId);
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception("Now the server is unavailable. Try later");
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
                throw new Exception("Now the server is unavailable. Try later");
            }
            finally
            {
                client.Abort();
                Log.Info("Сonnection closed");
            }
        }

        public IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId)
        {
            var result = new List<Category>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategoriesBesidesCurrent(categoryId);
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
    }
}
