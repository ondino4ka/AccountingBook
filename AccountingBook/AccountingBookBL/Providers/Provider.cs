using System.Collections.Generic;
using System.Linq;
using AccountingBookData.Repositories;
using AccountingBookCommon;

namespace AccountingBookBL.Providers
{
    public class Provider : IProvider
    {
        IDataRepository _dataRepository;
        public Provider(IDataRepository dataProvider)
        {
            _dataRepository = dataProvider;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _dataRepository.GetCategories();
        }

        public IReadOnlyList<Subject> GetSubjects()
        {
            return _dataRepository.GetSubjects();
        }

        public IReadOnlyList<Subject> GetSubjectsBySubCategories(int idSubCategories)
        {
            var subjects = _dataRepository.GetSubjects();
            return subjects.Where(x => x.IdSubCategory == idSubCategories).ToList();
        }
        public IReadOnlyList<Subject> GetSubjectsByCategories(int idCategories)
        {
            var subCategory = _dataRepository.GetCategories().Where(x => x.Id == idCategories).SingleOrDefault().SubCategories.Where(x => x.IdCategory == idCategories).ToList();
            var subjects = _dataRepository.GetSubjects().Where(x => subCategory.Exists(z => z.Id == x.IdSubCategory)).ToList();
            return subjects;
        }

        public Subject GetSubjectInformationById(int inventoryNumberSubject)
        {
            var subjects = _dataRepository.GetSubjectInformationById(inventoryNumberSubject);
            return subjects;
        }

        public string GetNameSubCategoryBySubjectId(int inventoryNumberSubject)
        {
            string nameCategory = _dataRepository.GetSubCategories().First(x => x.Id == _dataRepository.GetSubjects().First(y => y.InventoryNumber == inventoryNumberSubject).IdSubCategory).Name;
            return nameCategory;
        }
    }
}
