using AccountingBookCommon.Models;
using AccountingBookData.Repositories;
using System;
using System.Collections.Generic;

namespace AccountingBookBL.Providers
{
    public class Provider : IProvider
    {
        private readonly IDataRepository _dataRepository;
        public Provider(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _dataRepository.GetCategories();
        }
        public IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId)
        {
            return _dataRepository.GetCategoriesBesidesCurrent(categoryId);
        }
        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _dataRepository.GetCategoriesByName(categoryName);
        }
        public Category GetCategoryById(int categoryId)
        {
            return _dataRepository.GetCategoryById(categoryId);
        }

        public IReadOnlyList<SubjectDetails> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId)
        {
            return _dataRepository.GetSubjectsByCategoryId(categoryId);
        }

        public SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            var subjects = _dataRepository.GetSubjectInformationByInventoryNumber(inventoryNumber);
            return subjects;
        }


        public IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _dataRepository.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }

        public IReadOnlyCollection<State> GetStates()
        {
            return _dataRepository.GetStates();
        }

        public IReadOnlyCollection<Location> GetLocations()
        {
            return _dataRepository.GetLocations();
        }

        public Subject GetSubjectByInventoryNumber(int inventoryNumber)
        {
            return _dataRepository.GetSubjectByInventoryNumber(inventoryNumber);
        }

        public bool IsExistsSubject(int inventoryNumber)
        {
            return _dataRepository.IsExistsSubject(inventoryNumber);
        }

        public IReadOnlyCollection<Location> GetLocationsByAddress(string address)
        {
            return _dataRepository.GetLocationsByAddress(address);
        }

        public Location GetLocationById(int locationId)
        {
            return _dataRepository.GetLocationsById(locationId);
        }

        public State GetStateById(int stateId)
        {
            return _dataRepository.GetStateById(stateId);
        }

    }
}
