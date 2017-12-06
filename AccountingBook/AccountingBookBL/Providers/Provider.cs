using System;
using System.Linq;
using System.Collections.Generic;
using AccountingBookData.Repositories;
using AccountingBookCommon.Models;

namespace AccountingBookBL.Providers
{
    public class Provider : IProvider
    {
        private readonly IDataRepository _dataRepository;
        public Provider(IDataRepository dataProvider)
        {
            _dataRepository = dataProvider;
        }

        public IReadOnlyList<Category> GetCategories()
        {  
            return _dataRepository.GetCategories();
        }


        public IReadOnlyList<SubjectDetails> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId)
        {
            return _dataRepository.GetSubjectsByCategoryId(categoryId);
        }

        public SubjectDetails GetSubjectInformationById(int inventoryNumber)
        {
            var subjects = _dataRepository.GetSubjectInformationById(inventoryNumber);
            return subjects;
        }

        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _dataRepository.GetCategoriesByName(categoryName);
        }

        public IReadOnlyCollection<SubjectDetails> GetSubjectByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _dataRepository.GetSubjectByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }

        public IReadOnlyCollection<State> GetStates()
        {
            return _dataRepository.GetStates();
        }
    }
}
