using System.Collections.Generic;
using System.Linq;
using AccountingBookService.Contracts.Models.Dto;

namespace AccountingBookService.Contracts.Contracts
{
    public class AccountingBookService : IAccountingBookService
    {
        List<SubjectDto> subjects = new List<SubjectDto>() {
            new SubjectDto { InventoryNumber = 1, Name = "LG 43UJ639V", Location = "Warehouse 1", State = "Working", Photo = "https://avatars.mds.yandex.net/get-mpic/195452/img_id6827025122946540772/orig", Description = "works properly", IdSubCategory = 1 },
            new SubjectDto { InventoryNumber = 2, Name = "Samsung UE22H5600", Location = "Warehouse 1", State = "Working", Photo = "https://avatars.mds.yandex.net/get-mpic/200316/img_id7148496232302937310/orig", Description = "description", IdSubCategory = 1 },
            new SubjectDto { InventoryNumber = 3, Name = "Sony Xperia P", Location = "Warehouse 1", State = "Working", Photo = "https://avatars.mds.yandex.net/get-mpic/195452/img_id3100006917154969440/orig", Description = "description", IdSubCategory = 2 },
            new SubjectDto { InventoryNumber = 4, Name = "Sony Xperia Z3", Location = "Warehouse 1", State = "Working", Photo = "https://avatars.mds.yandex.net/get-mpic/96484/img_id3008615484850637072/orig", Description = "description", IdSubCategory = 2 },
            new SubjectDto { InventoryNumber = 5, Name = "Canon EOS 1300D Kit", Location = "Warehouse 1", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/195452/img_id7948107280802676417/orig", Description = "description", IdSubCategory = 3 },
            new SubjectDto { InventoryNumber = 6, Name = "Canon PowerShot SX620 HS", Location = "Warehouse 1", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/195452/img_id3009300450598592384/orig", Description = "description", IdSubCategory = 3 },
            new SubjectDto { InventoryNumber = 7, Name = "ATLANT М 7184-003", Location = "Warehouse 1", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/200316/img_id465623648100938606/orig", Description = "description", IdSubCategory = 4 },
            new SubjectDto { InventoryNumber =8, Name = "ATLANT М 7204-100", Location = "Warehouse 1", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/96484/img_id3763531369097749738/orig", Description = "description", IdSubCategory = 4 },
            new SubjectDto { InventoryNumber =9, Name = "GERMES Stash plus 60 AL", Location = "Warehouse 1", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/199079/img_id6440082672219637460/orig", Description = "description", IdSubCategory = 5 },
            new SubjectDto { InventoryNumber =10, Name = "GERMES Stash plus 60 IX", Location = "Warehouse 2", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/199079/img_id4458285398250739306/orig", Description = "description", IdSubCategory = 5 },
            new SubjectDto { InventoryNumber =11, Name = "GEFEST 6502-02 0045", Location = "Warehouse 2", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/96484/img_id2040365954788044981/orig", Description = "description", IdSubCategory = 6 },
            new SubjectDto { InventoryNumber =12, Name = "GEFEST 3200-08", Location = "Warehouse 2", State = "Will be acquired", Photo = "https://avatars.mds.yandex.net/get-mpic/397397/img_id5180371151626122523.jpeg/orig", Description = "description", IdSubCategory = 6 },
            new SubjectDto { InventoryNumber =13, Name = "Ikea Colsta", Location = "Warehouse 2", State = "Will be acquired", Photo = "photo", Description = "description", IdSubCategory = 7 },
            new SubjectDto { InventoryNumber =14, Name = "Intex Kriss", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 7 },
            new SubjectDto { InventoryNumber =15, Name = "Halmar 3000", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 8 },
            new SubjectDto { InventoryNumber =16, Name = "Halmar 5000", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 8 },
            new SubjectDto { InventoryNumber =17, Name = "Metta BK-8CH", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 9 },
            new SubjectDto { InventoryNumber =18, Name = "Metta AA-8CH", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 9 },
            new SubjectDto { InventoryNumber =19, Name = "Bosh GSP L123", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 10 },
            new SubjectDto { InventoryNumber =20, Name = "Bosh GSP L321", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 10 },
            new SubjectDto { InventoryNumber =21, Name = "Solaris MMA-208", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 11 },
            new SubjectDto { InventoryNumber =22, Name = "Spark MasterARC 200", Location = "Warehouse 2", State = "Decommissionedе", Photo = "photo", Description = "описание", IdSubCategory = 11 },
            new SubjectDto { InventoryNumber =23, Name = "Keramin Ultra", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 12 },
            new SubjectDto { InventoryNumber =24, Name = "Keramin Ultra2", Location = "Warehouse 2", State = "Decommissioned", Photo = "photo", Description = "description", IdSubCategory = 12 },
            new SubjectDto { InventoryNumber =25, Name = "Roca Berna", Location = "Warehouse 2", State = "Working", Photo = "photo", Description = "description", IdSubCategory = 13 },
            new SubjectDto { InventoryNumber =26, Name = "Roca Diverta", Location = "Warehouse 2", State = "Working", Photo = "photo", Description = "description", IdSubCategory = 13 },
            new SubjectDto { InventoryNumber =27, Name = "Triton 2000", Location = "Warehouse 2", State = "Working", Photo = "photo", Description = "description", IdSubCategory = 14 },
            new SubjectDto { InventoryNumber =28, Name = "Paisiedon 3000", Location = "Warehouse 2", State = "Working", Photo = "photo", Description = "description", IdSubCategory = 14 },
        };


        List<CategoryDto> categories = new List<CategoryDto>()
        {
            new CategoryDto {Id=1, Name="Electronics", SubCategories = new List<SubCategoryDto>() {
                     new SubCategoryDto {Id=1, Name= "Monitors", IdCategory=1},
                     new SubCategoryDto {Id=2, Name= "Phones", IdCategory=1},
                     new SubCategoryDto {Id=3, Name= "Cameras", IdCategory=1}}
            },
            new CategoryDto {Id=2, Name="Appliances", SubCategories = new List<SubCategoryDto>() {
                     new SubCategoryDto {Id=4, Name= "Refrigerators", IdCategory=2},
                     new SubCategoryDto {Id=5, Name= "Hoods", IdCategory=2},
                     new SubCategoryDto {Id=6, Name= "Kitchen stoves", IdCategory=2}}
            },
            new CategoryDto {Id=3, Name="Furniture", SubCategories= new List<SubCategoryDto> (){
                    new SubCategoryDto {Id=7, Name= "Sofas", IdCategory=3},
                    new SubCategoryDto {Id=8, Name= "Tables", IdCategory=3},
                    new SubCategoryDto {Id=9, Name= "Chairs", IdCategory=3}}
            },
            new CategoryDto {Id=4, Name="The electrotool", SubCategories = new List<SubCategoryDto>() {
                    new SubCategoryDto {Id=10, Name= "Drills", IdCategory=4,},
                    new SubCategoryDto {Id=11, Name= "Welders", IdCategory=4}}
            },
            new CategoryDto {Id=5, Name="Sanitary engineering", SubCategories=new List<SubCategoryDto>() {
                   new SubCategoryDto {Id=12, Name= "Toilets", IdCategory=5},
                   new SubCategoryDto {Id=13, Name= "Washbasins", IdCategory=5},
                   new SubCategoryDto {Id=14, Name= "Baths", IdCategory=5}}
            }
        };

        public List<CategoryDto> GetCategories()
        {
            return categories;
        }

        public List<SubCategoryDto> GetSubCategories()
        {
            List<SubCategoryDto> subCategories = new List<SubCategoryDto>();
            foreach (var category in categories)
            {
                foreach (var subCategory in category.SubCategories)
                {
                    subCategories.Add(subCategory);
                }
            }
            return subCategories;
        }

        public List<SubjectDto> GetSubjects()
        {
            return subjects;
        }

        public SubjectDto GetSubjectInformationById(int inventoryNumberSubject)
        {
            SubjectDto subject = GetSubjects().Where(x => x.InventoryNumber == inventoryNumberSubject).FirstOrDefault();
            return subject;
        }
    }
}
