using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class SubjectProvider : ISubjectProvider
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectProvider(ISubjectRepository subjectRepository)
        {
            if (subjectRepository == null)
            {
                throw new ArgumentNullException("subjectRepository is null");
            }
            _subjectRepository = subjectRepository;
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId)
        {
            return _subjectRepository.GetSubjectsByCategoryId(categoryId);
        }

        public SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            var subjects = _subjectRepository.GetSubjectInformationByInventoryNumber(inventoryNumber);
            return subjects;
        }

        public Subject GetSubjectByInventoryNumber(int inventoryNumber)
        {
            return _subjectRepository.GetSubjectByInventoryNumber(inventoryNumber);
        }

        public bool IsExistsSubject(int inventoryNumber)
        {
            return _subjectRepository.IsExistsSubject(inventoryNumber);
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _subjectRepository.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }
    }
}
