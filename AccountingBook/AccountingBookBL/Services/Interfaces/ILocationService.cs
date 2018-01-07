
namespace AccountingBookBL.Services.Interfaces
{
    public interface ILocationService
    {
        void AddLocation(string address);
        void EditLocationById(int locationId, string address);
        void DeleteLocationById(int locationId);
    }
}
