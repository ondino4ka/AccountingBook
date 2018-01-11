using AccountingBookCommon.Models;
using AccountingBookData.Clients;
using AccountingBookData.Clients.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Implementations
{
    public class SubjectRepository: ISubjectRepository
    {
        private readonly ISubjectClient _subjectClient;
        public SubjectRepository(ISubjectClient subjectClient)
        {
            if (subjectClient == null)
            {
                throw new ArgumentNullException("subjectClient is null");
            }
            _subjectClient = subjectClient;
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int? categoryId)
        {
            return _subjectClient.GetSubjectsByCategoryId(categoryId);
        }

        public SubjectDetails GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            return _subjectClient.GetSubjectInformationByInventoryNumber(inventoryNumber);
        }
        public Subject GetSubjectByInventoryNumber(int inventoryNumber)
        {
            return _subjectClient.GetSubjectByInventoryNumber(inventoryNumber);
        }

        public bool IsExistsSubject(int inventoryNumber)
        {
            return _subjectClient.IsExistsSubject(inventoryNumber);
        }

        public void AddSubject(Subject subject)
        {
            _subjectClient.AddSubject(subject);
        }

        public void EditSubjectInformation(Subject subject)
        {
            _subjectClient.EditSubjectInformation(subject);
        }

        public void DeleteSubjectByInventoryNumber(int inventoryNumber)
        {
            _subjectClient.DeleteSubjectByInventoruNumber(inventoryNumber);
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _subjectClient.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }

        public void EditSubjectPhoto(int inventoryNumber, string photo)
        {
            _subjectClient.EditSubjectPhoto(inventoryNumber, photo);
        }
    }
}
