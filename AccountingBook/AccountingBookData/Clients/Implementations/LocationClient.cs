using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AccountingBookData.Clients.Implementations
{
    public class LocationClient: ILocationClient
    {
        private static readonly ILog Log = LogManager.GetLogger("LocationClient");

        public IReadOnlyCollection<Location> GetLocations()
        {
            bool isClosed = false;
            var result = new List<Location>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetLocations();
                result = data == null ? result : data.Select(x => new Location { Id = x.Id, Address = x.Address }).ToList();
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

        public IReadOnlyCollection<Location> GetLocationsByAddress(string address)
        {
            bool isClosed = false;
            var result = new List<Location>();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetLocationsByAddress(address);
                result = data == null ? result : data.Select(x => new Location { Id = x.Id, Address = x.Address }).ToList();
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

        public Location GetLocationById(int locationId)
        {
            bool isClosed = false;
            var result = new Location();
            var client = new AccountingBookServiceReference.GetServiceClient();
            try
            {
                client.Open();
                var data = client.GetLocationsById(locationId);
                result = data == null ? null : new Location() { Id = data.Id, Address = data.Address };
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

        public void AddtLocation(string address)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.AddServiceClient();
            try
            {
                client.Open();
                client.AddLocation(address);
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

        public void EditLocationById(int locationId, string address)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.EditServiceClient();
            try
            {
                client.Open();
                client.EditLocationById(locationId, address);
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

        public void DeleteLocationById(int locationId)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.DeleteServiceClient();
            try
            {
                client.Open();
                client.DeleteLocationById(locationId);
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
