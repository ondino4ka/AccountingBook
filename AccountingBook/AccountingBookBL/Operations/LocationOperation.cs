using AccountingBookData.Repositories;
using System;

namespace AccountingBookBL.Operations
{
    public class LocationOperation : ILocationOperation
    {

        private readonly IDataRepository _dataRepository;
        public LocationOperation(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void AddLocation(string address)
        {
            _dataRepository.AddLocation(address);
        }

        public void EditLocation(int locationId, string address)
        {
            _dataRepository.EditLocation(locationId, address);
        }

        public void DeleteLocationById(int locationId)
        {
            _dataRepository.DeleteLocationById(locationId);
        }
    }
}
