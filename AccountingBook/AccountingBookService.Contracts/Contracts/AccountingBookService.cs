using System.Collections.Generic;
using AccountingBookService.Contracts.Models.Dto;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System;

namespace AccountingBookService.Contracts.Contracts
{
    public class AccountingBookService : IAccountingBookService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AccounitngBookConnection"].ConnectionString;
        public List<CategoryDto> GetCategories()
        {
            List<CategoryDto> categoryDto = new List<CategoryDto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SelectCategories";

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow dataRow in table.Rows)
                        {
                            categoryDto.Add(new CategoryDto { Id = (int)dataRow[0], Name = (string)dataRow[1], SubCategories = new List<SubCategoryDto>() });
                        }
                    }
                }
            }
            return categoryDto;
        }

        public List<SubCategoryDto> GetSubCategories()
        {
            List<SubCategoryDto> subCategoryDto = new List<SubCategoryDto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SelectSubCategories";

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow dataRow in table.Rows)
                        {
                            subCategoryDto.Add(new SubCategoryDto { Id = (int)dataRow[0], Name = (string)dataRow[1], IdCategory = (int)dataRow[2] });
                        }
                    }
                }
            }
            return subCategoryDto;
        }

        public List<SubjectDto> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public List<SubjectDto> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory)
        {
            List<SubjectDto> subjectsDto = new List<SubjectDto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;

                    if (isCategory)
                    {
                        command.CommandText = "SelectSubjectsByCategoryId";
                        SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@categoryId", Value = id };
                        command.Parameters.Add(param);
                    }
                    else
                    {
                        command.CommandText = "SelectSubjectsBySubCategoryId";
                        SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@subCategoryId", Value = id };
                        command.Parameters.Add(param);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow dataRow in table.Rows)
                        {
                            subjectsDto.Add(new SubjectDto { InventoryNumber = (int)dataRow[0], Name = (string)dataRow[1], Photo = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2], Description = (string)dataRow[3] });
                        }
                    }
                }
            }
            return subjectsDto;
        }


        public SubjectDto GetSubjectInformationById(int inventoryNumber)
        {
            SubjectDto subjectDto = new SubjectDto();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SelectSubjectInformationById";

                    SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
                    command.Parameters.Add(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow dataRow in table.Rows)
                        {
                            subjectDto = new SubjectDto { InventoryNumber = (int)dataRow[0], Name = (string)dataRow[1], State = (string)dataRow[2], Category = (string)dataRow[3], SubCategory = (string)dataRow[4], Photo = dataRow.IsNull(5) ? string.Empty : (string)dataRow[5], Description = (string)dataRow[6], Location = (string)dataRow[7] };
                        }
                    }
                }
            }
            return subjectDto;
        }
    }
}
