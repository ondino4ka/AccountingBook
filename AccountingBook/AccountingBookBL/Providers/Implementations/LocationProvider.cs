using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class LocationProvider: ILocationProvider
    {
        private readonly IDataRepository _dataRepository;
        public LocationProvider(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IReadOnlyCollection<Location> GetLocations()
        {
            return _dataRepository.GetLocations();
        }

        public IReadOnlyCollection<Location> GetLocationsByAddress(string address)
        {
            return _dataRepository.GetLocationsByAddress(address);
        }

        public Location GetLocationById(int locationId)
        {
            return _dataRepository.GetLocationsById(locationId);
        }
    }
}
