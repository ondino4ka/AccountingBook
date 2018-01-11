using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Interfaces
{
    public interface ILocationProvider
    {
        IReadOnlyList<Location> GetLocations();
        IReadOnlyList<Location> GetLocationsByAddress(string address);
        Location GetLocationById(int locationId);
    }
}
