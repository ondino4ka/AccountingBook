using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Clients.Interfaces
{
    public interface ILocationClient
    {
        IReadOnlyList<Location> GetLocations();
        IReadOnlyList<Location> GetLocationsByAddress(string address);
        Location GetLocationById(int locationId);
        void AddtLocation(string address);
        void EditLocationById(int locationId, string address);
        void DeleteLocationById(int locationId);
    }
}
