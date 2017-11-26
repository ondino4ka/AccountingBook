using System.Collections.Generic;
using AccountingBookService.Contracts.Models.Dto;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System;
using System.Linq;

namespace AccountingBookService.Contracts.Contracts
{
    public class AccountingBookService : IAccountingBookService
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["AccounitngBookConnection"].ConnectionString;

        private void GetDataFromDb<T>(ref List<T> list, string procedureName, params SqlParameter[] sqlParametr)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;

                    if (sqlParametr.Count() != 0)
                    {
                        foreach (var parametr in sqlParametr)
                        {
                            command.Parameters.Add(parametr);
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);


                    if (procedureName == "SelectCategories")
                    {
                        List<CategoryDto> tempList = new List<CategoryDto>();
                        foreach (DataTable table in dataSet.Tables)
                        {
                            foreach (DataRow dataRow in table.Rows)
                            {
                                tempList.Add(new CategoryDto { Id = (int)dataRow[0], Name = (string)dataRow[1], SubCategories = new List<SubCategoryDto>() });
                            }
                        }
                        list = tempList.Cast<T>().ToList();
                    }
                    else if (procedureName == "SelectSubCategories")
                    {
                        List<SubCategoryDto> tempList = new List<SubCategoryDto>();
                        foreach (DataTable table in dataSet.Tables)
                        {
                            foreach (DataRow dataRow in table.Rows)
                            {
                                tempList.Add(new SubCategoryDto { Id = (int)dataRow[0], Name = (string)dataRow[1], IdCategory = (int)dataRow[2] });
                            }
                        }
                        list = tempList.Cast<T>().ToList();
                    }

                    else if (procedureName == "SelectSubjectsByCategoryId" || procedureName == "SelectSubjectsBySubCategoryId")
                    {
                        List<SubjectDetailsDto> tempList = new List<SubjectDetailsDto>();
                        foreach (DataTable table in dataSet.Tables)
                        {
                            foreach (DataRow dataRow in table.Rows)
                            {
                                tempList.Add(new SubjectDetailsDto { InventoryNumber = (int)dataRow[0], Name = (string)dataRow[1], Photo = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2], Description = (string)dataRow[3] });
                            }
                        }
                        list = tempList.Cast<T>().ToList();
                    }

                    else if (procedureName == "SelectSubjectInformationById")
                    {
                        List<SubjectDetailsDto> tempList = new List<SubjectDetailsDto>();
                        foreach (DataTable table in dataSet.Tables)
                        {
                            foreach (DataRow dataRow in table.Rows)
                            {
                                tempList.Add(new SubjectDetailsDto { InventoryNumber = (int)dataRow[0], Name = (string)dataRow[1], State = (string)dataRow[2], Category = (string)dataRow[3], SubCategory = (string)dataRow[4], Photo = dataRow.IsNull(5) ? string.Empty : (string)dataRow[5], Description = (string)dataRow[6], Location = (string)dataRow[7] });
                            }
                        }
                        list = tempList.Cast<T>().ToList();
                    }
                }
            }
        }

        public List<CategoryDto> GetCategories()
        {
            List<CategoryDto> categoryDto = new List<CategoryDto>();
            GetDataFromDb(ref categoryDto, "SelectCategories");
            return categoryDto;
        }

        public List<SubCategoryDto> GetSubCategories()
        {
            List<SubCategoryDto> subCategoryDto = new List<SubCategoryDto>();
            GetDataFromDb(ref subCategoryDto, "SelectSubCategories");
            return subCategoryDto;
        }

        public List<SubjectDetailsDto> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public List<SubjectDetailsDto> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory)
        {
            List<SubjectDetailsDto> subjectsDto = new List<SubjectDetailsDto>();

            if (isCategory)
            {
                SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@categoryId", Value = id };
                GetDataFromDb(ref subjectsDto, "SelectSubjectsByCategoryId", param);
            }
            else
            {
                SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@subCategoryId", Value = id };
                GetDataFromDb(ref subjectsDto, "SelectSubjectsBySubCategoryId", param);
            }
            return subjectsDto;
        }

        public SubjectDetailsDto GetSubjectInformationById(int inventoryNumber)
        {
            List<SubjectDetailsDto> subjectDto = new List<SubjectDetailsDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            GetDataFromDb(ref subjectDto, "SelectSubjectInformationById", param);
            return subjectDto.FirstOrDefault();
        }
    }
}
