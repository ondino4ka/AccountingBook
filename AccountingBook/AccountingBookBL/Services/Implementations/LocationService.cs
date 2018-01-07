using AccountingBookBL.Services.Interfaces;
using AccountingBookData.Repositories;

namespace AccountingBookBL.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly IDataRepository _dataRepository;
        public LocationService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void AddLocation(string address)
        {
            _dataRepository.AddLocation(address);
        }

        public void EditLocationById(int locationId, string address)
        {
            _dataRepository.EditLocationById(locationId, address);
        }

        public void DeleteLocationById(int locationId)
        {
            _dataRepository.DeleteLocationById(locationId);
        }
    }
}
