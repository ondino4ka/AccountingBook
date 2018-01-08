using AccountingBookService.Contracts.Contracts.Interface;
using AccountingBookService.Contracts.Models.DtoException;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService : IFileService
    {
        private static readonly string path = Path.GetDirectoryName(HttpContext.Current.Server.MapPath(".")) + "/Photo/";
        private static readonly string[] extensions = new string[] { ".png", ".jpg", ".jpeg" };
        public void UploadPhoto(string name, byte[] photo)
        {
            if (string.IsNullOrEmpty(name) && photo != null)
            {
                Log.Error("photo is null or empty");
                throw new FaultException<ServiceFault>(new ServiceFault("Name required"), new FaultReason(ERROR_MESSAGE_REASON));
            }
            if (!extensions.Contains(Path.GetExtension(name)))
            {
                Log.Error("file of an invalid type" + name);
                throw new FaultException<ServiceFault>(new ServiceFault(name + "Invalid file type"), new FaultReason(ERROR_MESSAGE_REASON));
            }
            try
            {
                File.WriteAllBytes(path + name, photo);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                Log.Error(directoryNotFoundException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
            catch (ArgumentException argumentException)
            {
                Log.Error(argumentException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }

            catch (PathTooLongException pathToLongException)
            {
                Log.Error(pathToLongException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
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
                    throw new FaultException<ServiceFault>(new ServiceFault(argumentException.Message), new FaultReason(ERROR_MESSAGE_REASON));
                }
                catch (PathTooLongException pathToLongException)
                {
                    Log.Error(pathToLongException.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(pathToLongException.Message), new FaultReason(ERROR_MESSAGE_REASON));
                }
                catch (DirectoryNotFoundException directoryNotFoundException)
                {
                    Log.Error(directoryNotFoundException.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(directoryNotFoundException.Message), new FaultReason(ERROR_MESSAGE_REASON));
                }
                catch (FileNotFoundException fileNotFound)
                {
                    Log.Error(fileNotFound.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(fileNotFound.Message), new FaultReason(ERROR_MESSAGE_REASON));
                }
                catch (IOException ioException)
                {
                    Log.Error(ioException.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(ioException.Message), new FaultReason(ERROR_MESSAGE_REASON));
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
                Log.Error("name is null or empty");
                throw new FaultException<ServiceFault>(new ServiceFault("Name required"), new FaultReason(ERROR_MESSAGE_REASON));
            }
            try
            {
                File.Delete(path + name);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                Log.Error(directoryNotFoundException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
            catch (ArgumentNullException argumentNullException)
            {
                Log.Error(argumentNullException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
            catch (ArgumentException argumentException)
            {
                Log.Error(argumentException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }

            catch (PathTooLongException pathToLongException)
            {
                Log.Error(pathToLongException.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
        }
    }
}
