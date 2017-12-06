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

        public IReadOnlyList<SubjectDetails> GetSubjects()
        {
            throw new NotImplementedException();
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

        public User GetUserByName(string userName)
        {
            var result = new User();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetUserByName(userName);
                result = new User() { UserName = data.UserName, Roles = data.Roles.Select(x => new Role() { RoleName = x.RoleName }).ToList() };
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


        public IReadOnlyCollection<SubjectDetails> GetSubjectByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            var result = new List<SubjectDetails>();
            var client = new AccountingBookServiceReference.AccountingBookServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
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
    }
}
