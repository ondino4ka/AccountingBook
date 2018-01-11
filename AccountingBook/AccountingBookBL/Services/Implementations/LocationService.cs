using AccountingBookBL.Services.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;

namespace AccountingBookBL.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            if (locationRepository == null)
            {
                throw new ArgumentNullException("locationRepository is null");
            }
            _locationRepository = locationRepository;
        }

        public void AddLocation(string address)
        {
            _locationRepository.AddLocation(address);
        }

        public void EditLocationById(int locationId, string address)
        {
            _locationRepository.EditLocationById(locationId, address);
        }

        public void DeleteLocationById(int locationId)
        {
            _locationRepository.DeleteLocationById(locationId);
        }
    }
}
