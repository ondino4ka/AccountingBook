using System.Collections.Generic;
using System.Linq;
using AccountingBookCommon;

namespace AccountingBookData.Clients
{
    public class Client : IClient
    {
        public IReadOnlyList<Category> GetCategories()
        {
            var result = new List<Category>();
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
            var result = new List<SubCategory>();
            using (var client = new AccountingBookServiceReference.AccountingBookServiceClient())
            {
                client.Open();
                var data = client.GetSubCategories();
                result = data == null ? result : data.Select(x => new SubCategory { Id = x.Id, IdCategory = x.IdCategory, Name = x.Name }).ToList();
                client.Close();
            }
            return result;
        }

        public Subject GetSubjectInformationById(int inventoryNumberSubject)
        {
            var result = new Subject();
            using (var client = new AccountingBookServiceReference.AccountingBookServiceClient())
            {
                client.Open();
                var data = client.GetSubjectInformationById(inventoryNumberSubject);
                result = new Subject() { Name = data.Name, State = data.State, Description = data.Description, Photo = data.Photo, Location = data.Location, IdSubCategory = data.IdSubCategory, InventoryNumber = data.InventoryNumber };
                client.Close();
            }
            return result;
        }

        public IReadOnlyList<Subject> GetSubjects()
        {
            var result = new List<Subject>();
            using (var client = new AccountingBookServiceReference.AccountingBookServiceClient())
            {
                client.Open();
                var data = client.GetSubjects();
                result = data == null ? result : data.Select(z => new Subject { Name = z.Name, Description = z.Description, IdSubCategory = z.IdSubCategory, InventoryNumber = z.InventoryNumber, Location = z.Location, Photo = z.Photo, State = z.State }).ToList();
                client.Close();
            }
            return result;
        }
    }
}
