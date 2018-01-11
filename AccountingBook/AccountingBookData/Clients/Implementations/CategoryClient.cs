using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AccountingBookData.Clients.Implementations
{
    public class CategoryClient : ICategoryClient
    {
        private static readonly ILog Log = LogManager.GetLogger("CategoryClient"); 

        public IReadOnlyList<Category> GetCategories()
        {
            bool isClosed = false;
            var result = new List<Category>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategories();
                result = data == null ? result : data.Select(x => new Category { Id = x.Id, Pid = x.Pid, Name = x.Name }).ToList();
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

        public IReadOnlyList<Category> GetCategoriesByName(string categoryName)
        {
            bool isClosed = false;
            var result = new List<Category>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategoriesByName(categoryName);
                result = data == null ? result : data.Select(x => new Category { Id = x.Id, Name = x.Name }).ToList();
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

        public Category GetCategoryById(int categoryId)
        {
            bool isClosed = false;
            var result = new Category();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategoryById(categoryId);
                result = data == null ? null : new Category() { Id = data.Id, Pid = data.Pid, Name = data.Name };
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

        public void AddCategory(int? pid, string categoryName)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                client.AddCategory(pid, categoryName);
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

        public void EditCategoryById(int categoryId, int? pid, string categoryName)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditCategoryById(categoryId, pid, categoryName);
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

        public void DeleteCategoryById(int categoryId)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteCategoryById(categoryId);
                client.Close();
                isClosed = true;
            }
            catch (FaultException<AccountingBookServiceReference.ServiceFault> faultException)
            {
                Log.Error(faultException.Detail.ErrorMessage);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (EndpointNotFoundException endPointNotFoundException)
            {
                Log.Error(endPointNotFoundException.Message);
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

        public IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId)
        {
            bool isClosed = false;
            var result = new List<Category>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetCategoriesBesidesCurrent(categoryId);
                result = data == null ? result : data.Select(x => new Category { Id = x.Id, Pid = x.Pid, Name = x.Name }).ToList();
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
    }
}
