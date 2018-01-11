using AccountingBookBL.Services.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;

namespace AccountingBookBL.Services.Implementations
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            if (stateRepository == null)
            {
                throw new ArgumentNullException("stateRepository is null");
            }
            _stateRepository = stateRepository;
        }
        public void AddState(string stateName)
        {
            _stateRepository.AddState(stateName);
        }
        public void EditState(int stateId, string stateName)
        {
            _stateRepository.EditStateById(stateId, stateName);
        }

        public void DeleteStateById(int stateId)
        {
            _stateRepository.DeleteStateById(stateId);
        }       
    }
}
