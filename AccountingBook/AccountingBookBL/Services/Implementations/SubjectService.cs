using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories.Interfaces;
using System;

namespace AccountingBookBL.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            if (subjectRepository == null)
            {
                throw new ArgumentException("subjectRepository is null");
            }
            _subjectRepository = subjectRepository;
        }
        public void AddSubject(Subject subject)
        {
            _subjectRepository.AddSubject(subject);
        }

        public void EditSubjectInformation(Subject subject)
        {
            _subjectRepository.EditSubjectInformation(subject);
        }
        public void EditSubjectPhoto(int inventoryNumber, string photo)
        {
            _subjectRepository.EditSubjectPhoto(inventoryNumber, photo);
        }
        public void DeleteSubjectByInventoryNumber(int inventoryNumber)
        {
            _subjectRepository.DeleteSubjectByInventoryNumber(inventoryNumber);
        }
    }
}
