using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class StateProvider: IStateProvider
    {
        private readonly IStateRepository _stateRepository;
        public StateProvider(IStateRepository stateRepository)
        {
            if (stateRepository == null)
            {
                throw new ArgumentException("stateRepository is null");
            }
            _stateRepository = stateRepository;
        }
        public IReadOnlyCollection<State> GetStates()
        {
            return _stateRepository.GetStates();
        }

        public State GetStateById(int stateId)
        {
            return _stateRepository.GetStateById(stateId);
        }
    }
}
