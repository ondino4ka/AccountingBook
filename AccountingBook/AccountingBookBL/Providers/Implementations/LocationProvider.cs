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
                throw new ArgumentNullException("locationRepository is null");
            }
            _locationRepository = locationRepository;
        }

        public IReadOnlyList<Location> GetLocations()
        {
            return _locationRepository.GetLocations();
        }

        public IReadOnlyList<Location> GetLocationsByAddress(string address)
        {
            return _locationRepository.GetLocationsByAddress(address);
        }

        public Location GetLocationById(int locationId)
        {
            return _locationRepository.GetLocationsById(locationId);
        }
    }
}
