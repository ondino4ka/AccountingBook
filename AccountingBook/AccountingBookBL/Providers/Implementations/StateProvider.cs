using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class StateProvider: IStateProvider
    {
        private readonly IDataRepository _dataRepository;
        public StateProvider(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public IReadOnlyCollection<State> GetStates()
        {
            return _dataRepository.GetStates();
        }

        public State GetStateById(int stateId)
        {
            return _dataRepository.GetStateById(stateId);
        }
    }
}
