using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AccountingBookData.Clients.Implementations
{
    public class StateClient: IStateClient
    {
        private static readonly ILog Log = LogManager.GetLogger("StateClient");

        public IReadOnlyCollection<State> GetStates()
        {
            bool isClosed = false;
            var result = new List<State>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetStates();
                result = data == null ? result : data.Select(x => new State { Id = x.Id, StateName = x.StateName }).ToList();
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

        public State GetStateById(int stateId)
        {
            bool isClosed = false;
            var result = new State();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetStateById(stateId);
                result = data == null ? null : new State() { Id = data.Id, StateName = data.StateName };
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

        public void AddState(string stateName)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                client.AddState(stateName);
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

        public void EditStateById(int stateId, string stateName)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditStateById(stateId, stateName);
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

        public void DeleteStateById(int stateId)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteStateById(stateId);
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
    }
}
