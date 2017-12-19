﻿using AccountingBookData.Repositories;
using System;

namespace AccountingBookBL.Operations
{
    public class CategoryOperation : ICategoryOperation
    {
        private readonly IDataRepository _dataRepository;
        public CategoryOperation(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public void AddCategory(int? pid, string categoryName)
        {
            _dataRepository.AddCategory(pid, categoryName);
        }

        public void EditCategoryById(int categoryId, int? pid, string categoryName)
        {
            _dataRepository.EditCategoryById(categoryId, pid, categoryName);
        }

        public void DeleteCategoryByID(int categoryId)
        {
            _dataRepository.DeleteCategoryById(categoryId);
        }

    }
}
