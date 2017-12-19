using AccountingBookCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBookBL.Operations
{
    public interface ISubjectOperation
    {
        void AddSubject(Subject user);
        void EditSubjectInformation(Subject subject);
        void EditSubjectPhoto(int inventoryNumber, string photo);
        void DeleteSubjectByInventoryNumber(int inventoryNumber);
    }
}
