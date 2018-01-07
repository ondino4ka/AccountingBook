using AccountingBookCommon.Models;

namespace AccountingBookBL.Services.Interfaces
{
    public interface ISubjectService
    {
        void AddSubject(Subject user);
        void EditSubjectInformation(Subject subject);
        void EditSubjectPhoto(int inventoryNumber, string photo);
        void DeleteSubjectByInventoryNumber(int inventoryNumber);
    }
}
