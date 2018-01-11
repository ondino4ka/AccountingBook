using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        IReadOnlyList<Location> GetLocations();
        IReadOnlyList<Location> GetLocationsByAddress(string address);
        Location GetLocationsById(int locationId);
        void AddLocation(string address);
        void EditLocationById(int locationId, string address);
        void DeleteLocationById(int locationId);
    }
}
