using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class LocationProvider: ILocationProvider
    {
        private readonly ILocationRepository _locationRepository;
        public LocationProvider(ILocationRepository locationRepository)
        {
            if (locationRepository == null)
            {
                throw new ArgumentException("locationRepository is null");
            }
            _locationRepository = locationRepository;
        }

        public IReadOnlyCollection<Location> GetLocations()
        {
            return _locationRepository.GetLocations();
        }

        public IReadOnlyCollection<Location> GetLocationsByAddress(string address)
        {
            return _locationRepository.GetLocationsByAddress(address);
        }

        public Location GetLocationById(int locationId)
        {
            return _locationRepository.GetLocationsById(locationId);
        }
    }
}
