
using AccountingBookData.Repositories;
using System;

namespace AccountingBookBL.Operations
{
    public class StateOperation : IStateOperation
    {
        private readonly IDataRepository _dataRepository;
        public StateOperation(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public void AddState(string stateName)
        {
            _dataRepository.AddState(stateName);
        }
        public void EditState(int stateId, string stateName)
        {
            _dataRepository.EditStateById(stateId, stateName);
        }

        public void DeleteStateById(int stateId)
        {
            _dataRepository.DeleteStateById(stateId);
        }       
    }
}
