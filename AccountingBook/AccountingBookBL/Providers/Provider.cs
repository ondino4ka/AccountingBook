using System.Collections.Generic;
using System.Linq;
using AccountingBookData.Repositories;
using AccountingBookCommon;
using System;

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
            IReadOnlyList<Category> categories = _dataRepository.GetCategories();
            IReadOnlyList<SubCategory> subCategories = GetSubCategories();
            foreach (var category in categories)
            {
                foreach (var subCategory in subCategories)
                {
                    if (category.Id == subCategory.IdCategory)
                    {
                        category.SubCategories.Add(subCategory);
                    }
                }           
            }
            return categories;
        }

        public IReadOnlyList<SubCategory> GetSubCategories()
        {
            return _dataRepository.GetSubCategories();
        }

        public IReadOnlyList<Subject> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Subject> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory)
        {
            return _dataRepository.GetSubjectsByCategoryOrSubCategoryId(id, isCategory);
        }

        public Subject GetSubjectInformationById(int inventoryNumber)
        {
            var subjects = _dataRepository.GetSubjectInformationById(inventoryNumber);
            return subjects;
        } 
    }
}
