using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Implementations
{
    public class LocationRepository: ILocationRepository
    {
        private readonly ILocationClient _locationClient;
        public LocationRepository(ILocationClient locationClient)
        {
            if (locationClient == null)
            {
                throw new ArgumentException("locationClient is null");
            }
            _locationClient = locationClient;
        }

        public IReadOnlyCollection<Location> GetLocations()
        {
            return _locationClient.GetLocations();
        }

        public IReadOnlyCollection<Location> GetLocationsByAddress(string address)
        {
            return _locationClient.GetLocationsByAddress(address);
        }

        public Location GetLocationsById(int locationId)
        {
            return _locationClient.GetLocationById(locationId);
        }

        public void AddLocation(string address)
        {
            _locationClient.AddtLocation(address);
        }

        public void EditLocationById(int locationId, string address)
        {
            _locationClient.EditLocationById(locationId, address);
        }

        public void DeleteLocationById(int locationId)
        {
            _locationClient.DeleteLocationById(locationId);
        }
    }
}
