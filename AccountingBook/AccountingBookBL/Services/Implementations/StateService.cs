using AccountingBookBL.Services.Interfaces;
using AccountingBookData.Repositories;

namespace AccountingBookBL.Services.Implementations
{
    public class StateService : IStateService
    {
        private readonly IDataRepository _dataRepository;
        public StateService(IDataRepository dataRepository)
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
