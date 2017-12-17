
namespace AccountingBookBL.Operations
{
    public interface IStateOperation
    {
        void AddState(string stateName);
        void EditState(int stateId, string stateName);
        void DeleteStateById(int stateId);
    }
}
