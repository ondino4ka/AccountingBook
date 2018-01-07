
namespace AccountingBookBL.Services.Interfaces
{
    public interface IStateService
    {
        void AddState(string stateName);
        void EditState(int stateId, string stateName);
        void DeleteStateById(int stateId);
    }
}
