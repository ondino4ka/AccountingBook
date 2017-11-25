using System;
using System.Collections.Generic;
using System.Linq;
using AccountingBookCommon;

namespace AccountingBookData.Clients
{
    public class Client : IClient
    {
        public IReadOnlyList<Category> GetCategories()
        {
            List<Category> result = new List<Category>();
            using (var client = new AccountingBookServiceReference.AccountingBookServiceClient())
            {
                client.Open();
                var data = client.GetCategories();
                result = data == null ? result : data.Select(x => new Category { Id = x.Id, Name = x.Name, SubCategories = x.SubCategories.Select(y => new SubCategory { Id = y.Id, Name = y.Name, IdCategory = y.IdCategory }).ToList() }).ToList();
                client.Close();
            }
            return result;
        }

        public IReadOnlyList<SubCategory> GetSubCategories()
        {
            List<SubCategory> result = new List<SubCategory>();
            using (var client = new AccountingBookServiceReference.AccountingBookServiceClient())
            {
                client.Open();
                var data = client.GetSubCategories();
                result = data == null ? result : data.Select(x => new SubCategory { Id = x.Id, IdCategory = x.IdCategory, Name = x.Name }).ToList();
                client.Close();
            }
            return result;
        }

        public IReadOnlyList<Subject> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Subject> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory)
        {
            List<Subject> result = new List<Subject>();
            using (var client = new AccountingBookServiceReference.AccountingBookServiceClient())
            {
                client.Open();
                var data = client.GetSubjectsByCategoryOrSubCategoryId(id, isCategory);
                result = data == null ? result : data.Select(x => new Subject { InventoryNumber = x.InventoryNumber, Name = x.Name, Photo = x.Photo, Description = x.Description }).ToList();
                client.Close();
            }
            return result;
        }
     

        public Subject GetSubjectInformationById(int inventoryNumber)
        {
            Subject result = new Subject();
            using (var client = new AccountingBookServiceReference.AccountingBookServiceClient())
            {
                client.Open();
                var data = client.GetSubjectInformationById(inventoryNumber);
                result = new Subject() { InventoryNumber = data.InventoryNumber , Name = data.Name, State = data.State, Description = data.Description, Photo = data.Photo, Location = data.Location, Category=data.Category, SubCategory = data.SubCategory};
                client.Close();
            }
            return result;
        }
    }
}
