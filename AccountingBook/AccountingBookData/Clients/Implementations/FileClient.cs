using AccountingBookData.Clients.Interfaces;
using log4net;
using System;
using System.ServiceModel;

namespace AccountingBookData.Clients.Implementations
{
    public class FileClient : IFileClient
    {
        private static readonly ILog Log = LogManager.GetLogger("FileClient");

        public void UploadPhoto(string name, byte[] photo)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.FileServiceClient();
            try
            {
                client.Open();
                client.UploadPhoto(name, photo);
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
            catch (ProtocolException protocolException)
            {
                Log.Error(protocolException.Message);
                throw new Exception("Exceeded file size limit");
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

        public byte[] DownloadPhoto(string name)
        {
            bool isClosed = false;
            var result = new byte[] { };
            var client = new AccountingBookServiceReference.FileServiceClient();
            try
            {
                client.Open();
                var data = client.DownloadPhoto(name);
                result = data == null ? result : data;
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
            return result;
        }

        public void DeletePhoto(string name)
        {
            bool isClosed = false;
            var client = new AccountingBookServiceReference.FileServiceClient();
            try
            {
                client.Open();
                client.DeletePhoto(name);
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
