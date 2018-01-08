using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AccountingBookData.Clients.Implementations
{
    public class SubjectClient: ISubjectClient
    {
        private static readonly ILog Log = LogManager.GetLogger("SubjectClient");

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId)
        {
            bool isClosed = false;
            var result = new List<SubjectDetails>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectsByCategoryId(categoryId);
                result = data == null ? result : data.Select(x => new SubjectDetails { InventoryNumber = x.InventoryNumber, Name = x.Name, Photo = x.Photo, Description = x.Description }).ToList();
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
        public SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            bool isClosed = false;
            var result = new SubjectDetails();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectInformationByInventoryNumber(inventoryNumber);
                result = data == null ? null : new SubjectDetails() { InventoryNumber = data.InventoryNumber, Name = data.Name, State = data.State, Description = data.Description, Photo = data.Photo, Location = data.Location, Category = data.Category };
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
        public IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            bool isClosed = false;
            var result = new List<SubjectDetails>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
                result = data == null ? result : data.Select(x => new SubjectDetails { InventoryNumber = x.InventoryNumber, Name = x.Name, Photo = x.Photo, Description = x.Description }).ToList();
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

        public Subject GetSubjectByInventoryNumber(int inventoryNumber)
        {
            bool isClosed = false;
            var result = new Subject();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetSubjectByInventoryNumber(inventoryNumber);
                result = data == null ? null : new Subject() { InventoryNumber = data.InventoryNumber, Name = data.Name, CategoryId = data.CategoryId, LocationId = data.LocationId, Description = data.Description, StateId = data.StateId, Photo = data.Photo };
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

        public bool IsExistsSubject(int inventoryNumber)
        {
            bool isClosed = false;
            var result = false;
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                result = client.IsExistsSubject(inventoryNumber);
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

        public void AddSubject(Subject subject)
        {
            bool isClosed = false;
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

        public void EditSubjectInformation(Subject subject)
        {
            bool isClosed = false;
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

        public void DeleteSubjectByInventoruNumber(int inventoryNumber)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteSubjectByInventoryNumber(inventoryNumber);
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

        public void EditSubjectPhoto(int inventoryNumber, string photo)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditSubjectPhoto(inventoryNumber, photo);
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
            catch (InvalidCastException castException)
            {
                Log.Error(castException.Message);
                throw new Exception(Constants.ERROR_MESSAGE);
            }
            catch (CommunicationException communicationException)
            {
                Log.Error(communicationException.Message);
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
