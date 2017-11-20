using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingBookData.Repositories;
using AccountingBookCommon;

namespace AccountingBookBL
{
    public class Provider : IProvider
    {
        IDataProvider dataProvider;
        public Provider(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return dataProvider.GetCategories();
        }

        public IReadOnlyList<Subject> GetSubjects()
        {
            return dataProvider.GetSubjects();
        }

        public IReadOnlyList<Subject> GetSubjectsBySubCategories(int idSubCategories)
        {
            var subjects = dataProvider.GetSubjects();
            return subjects.Where(x => x.IdSubCategory == idSubCategories).ToList();
        }
        public IReadOnlyList<Subject> GetSubjectsByCategories(int idCategories)
        {          
            var subCategory = dataProvider.GetCategories().Where(x => x.Id == idCategories).SingleOrDefault().SubCategories.Where(x=>x.IdCategory==idCategories).ToList();
            var subjects = dataProvider.GetSubjects().Where(x => subCategory.Exists(z => z.Id == x.IdSubCategory)).ToList();
            return subjects;
        }



        public Subject GetSubjectInformationById(int inventoryNumberSubject)
        {
            var subjects = dataProvider.GetSubjectInformationById(inventoryNumberSubject);
            return subjects;
        }

        public string GetNameSubCategoryBySubjectId(int inventoryNumberSubject)
        {        
            string nameCategory = dataProvider.GetSubCategories().First(x => x.Id == dataProvider.GetSubjects().First(y => y.InventoryNumber == inventoryNumberSubject).IdSubCategory).Name;
            return nameCategory;
        }
    }
}
