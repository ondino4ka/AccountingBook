using AccountingBookService.Contracts.Contracts.Interface;
using AccountingBookService.Contracts.Models.DtoException;
using System;
using System.IO;
using System.ServiceModel;
using System.Web;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService : IFileService
    {
        static readonly string path = Path.GetDirectoryName(HttpContext.Current.Server.MapPath(".")) + "/Photo/";
        public void UploadPhoto(string name, byte[] photo)
        {
            if (string.IsNullOrEmpty(name) && photo != null)
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Name required"), new FaultReason("Internal error"));
            }
            try
            {
                File.WriteAllBytes(path + name, photo);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                Log.Error(directoryNotFoundException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
            catch (ArgumentException argumentException)
            {
                Log.Error(argumentException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }

            catch (PathTooLongException pathToLongException)
            {
                Log.Error(pathToLongException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
        }

        public byte[] DownloadPhoto(string name)
        {
            byte[] photo;
            if (name != null)
            {
                try
                {
                    photo = File.ReadAllBytes(path + name);
                }
                catch (ArgumentException argumentException)
                {
                    Log.Error(argumentException.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(argumentException.Message), new FaultReason("Internal error"));
                }
                catch (PathTooLongException pathToLongException)
                {
                    Log.Error(pathToLongException.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(pathToLongException.Message), new FaultReason("Internal error"));
                }
                catch (DirectoryNotFoundException directoryNotFoundException)
                {
                    Log.Error(directoryNotFoundException.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(directoryNotFoundException.Message), new FaultReason("Internal error"));
                }
                catch (FileNotFoundException fileNotFound)
                {
                    Log.Error(fileNotFound.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(fileNotFound.Message), new FaultReason("Internal error"));
                }
                catch (IOException ioException)
                {
                    Log.Error(ioException.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(ioException.Message), new FaultReason("Internal error"));
                }
            }
            else
            {
                photo = new byte[] { };
            }
            return photo;
        }

        public void DeletePhoto(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Name required"), new FaultReason("Internal error"));
            }
            try
            {
                File.Delete(path + name);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                Log.Error(directoryNotFoundException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
            catch (ArgumentNullException argumentNullException)
            {
                Log.Error(argumentNullException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
            catch (ArgumentException argumentException)
            {
                Log.Error(argumentException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }

            catch (PathTooLongException pathToLongException)
            {
                Log.Error(pathToLongException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
        }
    }
}
