using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Interfaces
{
    public interface IStateProvider
    {
        IReadOnlyList<State> GetStates();
        State GetStateById(int stateId);
    }
}
