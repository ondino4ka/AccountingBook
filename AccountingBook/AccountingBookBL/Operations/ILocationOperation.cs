
namespace AccountingBookBL.Operations
{
    public interface ILocationOperation
    {
        void AddLocation(string address);
        void EditLocationById(int locationId, string address);
        void DeleteLocationById(int locationId);
    }
}
