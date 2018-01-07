using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class SubjectProvider : ISubjectProvider
    {
        private readonly IDataRepository _dataRepository;
        public SubjectProvider(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
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

        public Subject GetSubjectByInventoryNumber(int inventoryNumber)
        {
            return _dataRepository.GetSubjectByInventoryNumber(inventoryNumber);
        }

        public bool IsExistsSubject(int inventoryNumber)
        {
            return _dataRepository.IsExistsSubject(inventoryNumber);
        }

        public IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _dataRepository.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }
    }
}
