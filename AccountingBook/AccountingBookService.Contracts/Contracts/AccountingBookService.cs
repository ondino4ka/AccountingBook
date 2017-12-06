using System;
using System.Linq;
using System.Configuration;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using log4net;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;


namespace AccountingBookService.Contracts.Contracts
{
    public class AccountingBookService : IAccountingBookService
    {
        readonly string connectionString;
        static string errorMessage = "Now the server is unavailable.Try later";
        private static readonly ILog Log = LogManager.GetLogger("AccountingBookService");
        public AccountingBookService()
        {
            try
            {
                Log.Info("connection open");
                connectionString = ConfigurationManager.ConnectionStrings["AccountingBookConnection"].ConnectionString;
            }
            catch (NullReferenceException ex)
            {
                Log.Error(ex.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
            catch (InvalidOperationException ex)
            {
                Log.Error(ex.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
            }
        }

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
                    try
                    {
                        adapter.Fill(dataSet);
                    }
                    catch (FormatException formatException)
                    {
                        Log.Error(formatException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }
                    catch (SqlException sqlException)
                    {
                        Log.Error(sqlException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }


                    if (procedureName == "SelectCategories")
                    {
                        List<CategoryDto> tempList = new List<CategoryDto>();
                        try
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new CategoryDto { Id = (int)dataRow[0], Pid = dataRow.IsNull(1) ? null : (int?)dataRow[1], Name = (string)dataRow[2] });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                        }
                        list = tempList.Cast<T>().ToList();
                    }

                    else if (procedureName == "SelectSubjectsByCategoryId")
                    {
                        List<SubjectDetailsDto> tempList = new List<SubjectDetailsDto>();
                        try
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new SubjectDetailsDto { InventoryNumber = (int)dataRow[0], Name = (string)dataRow[1], Photo = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2], Description = (string)dataRow[3] });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                        }
                        list = tempList.Cast<T>().ToList();
                    }

                    else if (procedureName == "SelectSubjectInformationById")
                    {
                        List<SubjectDetailsDto> tempList = new List<SubjectDetailsDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new SubjectDetailsDto { InventoryNumber = (int)dataRow[0], Name = (string)dataRow[1], State = (string)dataRow[2], Category = (string)dataRow[3], Photo = dataRow.IsNull(4) ? string.Empty : (string)dataRow[4], Description = (string)dataRow[5], Location = (string)dataRow[6] });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                        }
                        list = tempList.Cast<T>().ToList();
                    }
                    else if (procedureName == "SelectUserByName")
                    {
                        List<UserDto> tempList = new List<UserDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new UserDto { UserName = (string)dataRow[1], Roles = GetRolesByUserId((int)(dataRow[0])) });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                        }
                        list = tempList.Cast<T>().ToList();
                    }
                    else if (procedureName == "SelectRolesByUserId")
                    {
                        List<RoleDto> tempList = new List<RoleDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new RoleDto { RoleName = (string)dataRow[0] });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                        }
                        list = tempList.Cast<T>().ToList();
                    }
                    else if (procedureName == "SelectCategoriesByName")
                    {
                        List<CategoryDto> tempList = new List<CategoryDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new CategoryDto { Id = (int)dataRow[0], Name = (string)dataRow[1] });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                        }
                        list = tempList.Cast<T>().ToList();
                    }
                    else if (procedureName == "SelectSubjectByNameCategoryIdAndStateId")
                    {
                        List<SubjectDetailsDto> tempList = new List<SubjectDetailsDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new SubjectDetailsDto { InventoryNumber = (int)dataRow[0], Name = (string)dataRow[1], Photo = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2], Description = (string)dataRow[3] });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                        }
                        list = tempList.Cast<T>().ToList();
                    }
                    else if (procedureName == "SelectStates")
                    {
                        List<StateDto> tempList = new List<StateDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new StateDto { Id = (int)dataRow[0], StateName = (string)dataRow[1] });
                                }
                            }
                        }
                        catch (InvalidCastException invalidCastException)
                        {
                            Log.Error(invalidCastException.Message);
                            throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
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

        public List<SubjectDetailsDto> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public List<SubjectDetailsDto> GetSubjectsByCategoryId(int categoryId)
        {
            List<SubjectDetailsDto> subjectsDto = new List<SubjectDetailsDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@categoryId", Value = categoryId };
            GetDataFromDb(ref subjectsDto, "SelectSubjectsByCategoryId", param);
            return subjectsDto;
        }

        public SubjectDetailsDto GetSubjectInformationById(int inventoryNumber)
        {
            List<SubjectDetailsDto> subjectDto = new List<SubjectDetailsDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            GetDataFromDb(ref subjectDto, "SelectSubjectInformationById", param);
            return subjectDto.FirstOrDefault();
        }

        public UserDto GetUserByName(string userName)
        {
            List<UserDto> userDto = new List<UserDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@userName", Value = userName };
            GetDataFromDb(ref userDto, "SelectUserByName", param);
            return userDto.FirstOrDefault();
        }

        public bool IsValidUser(string username, string password)
        {
            SqlParameter[] param = {
                new SqlParameter
                {
                   DbType = DbType.String,
                   ParameterName = "@username",
                   Value = username
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@password",
                    Value = password
                }
            };

            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "IsValidUser";
                    command.Parameters.AddRange(param);

                    SqlParameter resultPrameter = new SqlParameter();
                    resultPrameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(resultPrameter);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();

                    try
                    {
                        adapter.Fill(dataSet);
                    }
                    catch (SqlException ex)
                    {
                        throw new FaultException<ServiceFault>(new ServiceFault(ex.Message), new FaultReason(ex.Message));
                    }

                    if ((int)resultPrameter.Value == 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public List<RoleDto> GetRolesByUserId(int userId)
        {
            List<RoleDto> roleDto = new List<RoleDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            GetDataFromDb(ref roleDto, "SelectRolesByUserId", param);
            return roleDto;
        }

        public List<CategoryDto> GetCategoriesByName(string categoryName)
        {
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@categoryName", Value = categoryName };
            GetDataFromDb(ref categoriesDto, "SelectCategoriesByName", param);
            return categoriesDto;
        }
        public List<SubjectDetailsDto> GetSubjectByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            List<SubjectDetailsDto> categoriesDto = new List<SubjectDetailsDto>();

            SqlParameter[] param = {
                new SqlParameter
                {
                   DbType = DbType.String,
                   ParameterName = "@subjectName",
                   Value = subjectName
                },
                new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@idState",
                    Value = stateId
                },
                new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@categoryId",
                    Value = categoryId
                }
            };
     
            GetDataFromDb(ref categoriesDto, "SelectSubjectByNameCategoryIdAndStateId", param);
            return categoriesDto;
        }

        public List<StateDto> GetStates()
        {
            List<StateDto> statesDto = new List<StateDto>();
            GetDataFromDb(ref statesDto, "SelectStates");
            return statesDto;
        }
    }
}
