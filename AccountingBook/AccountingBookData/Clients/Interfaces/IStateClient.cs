using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Clients.Interfaces
{
    public interface IStateClient
    {
        IReadOnlyCollection<State> GetStates();
        State GetStateById(int stateId);
        void AddState(string stateName);
        void EditStateById(int stateId, string stateName);
        void DeleteStateById(int stateId);
    }
}
