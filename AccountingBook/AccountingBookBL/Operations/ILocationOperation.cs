
namespace AccountingBookBL.Operations
{
    public interface ILocationOperation
    {
        void AddLocation(string address);
        void EditLocation(int locationId, string address);
        void DeleteLocationById(int locationId);
    }
}
