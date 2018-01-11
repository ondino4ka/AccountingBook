using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Implementations
{
    public class StateRepository: IStateRepository
    {
        private readonly IStateClient _stateClient;
        public StateRepository(IStateClient stateClient)
        {
            if (stateClient == null)
            {
                throw new ArgumentNullException("stateClient is null");
            }
            _stateClient = stateClient;
        }

        public IReadOnlyList<State> GetStates()
        {
            return _stateClient.GetStates();
        }
        public State GetStateById(int stateId)
        {
            return _stateClient.GetStateById(stateId);
        }

        public void EditStateById(int stateId, string stateName)
        {
            _stateClient.EditStateById(stateId, stateName);
        }

        public void AddState(string stateName)
        {
            _stateClient.AddState(stateName);
        }

        public void DeleteStateById(int stateId)
        {
            _stateClient.DeleteStateById(stateId);
        }
    }
}
