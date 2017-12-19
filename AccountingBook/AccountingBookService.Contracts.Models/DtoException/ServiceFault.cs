using System.Runtime.Serialization;

namespace AccountingBookService.Contracts.Models.DtoException
{
    [DataContract]
    public class ServiceFault
    {
        [DataMember]
        public string ErrorMessage { get; private set; }
        public ServiceFault(string exceptionErrorMessage)
        {
            ErrorMessage = exceptionErrorMessage;
        }
    }
}
