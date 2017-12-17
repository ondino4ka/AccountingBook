using AccountingBookCommon.Models;
using AccountingBookData.Repositories;
using System;

namespace AccountingBookBL.Operations
{
    public class SubjectOperation : ISubjectOperation
    {
        private readonly IDataRepository _dataRepository;
        public SubjectOperation(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public void AddSubject(Subject subject)
        {
            _dataRepository.AddSubject(subject);
        }

        public void EditSubjectInformation(Subject subject)
        {
            _dataRepository.EditSubjectInformation(subject);
        }
        public void EditSubjectPhoto(int inventoryNumber, string photo)
        {
            _dataRepository.EditSubjectPhoto(inventoryNumber, photo);
        }
        public void DeleteSubjectByInventoryNumber(int inventoryNumber)
        {
            _dataRepository.DeleteSubjectByInventoryNumber(inventoryNumber);
        }
    }
}
