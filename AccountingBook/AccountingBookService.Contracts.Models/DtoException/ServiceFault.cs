using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
