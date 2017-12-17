using AccountingBookService.Contracts.Contracts.Interface;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService : IGetService
    {
        readonly string connectionString;
        const string errorMessage = "Now the server is unavailable.Try later";
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
                                    tempList.Add(new SubjectDetailsDto
                                    {
                                        InventoryNumber = (int)dataRow[0],
                                        Name = (string)dataRow[1],
                                        State = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2],
                                        Category = dataRow.IsNull(3) ? string.Empty : (string)dataRow[3],
                                        Photo = dataRow.IsNull(4) ? string.Empty : (string)dataRow[4],
                                        Description = (string)dataRow[5],
                                        Location = dataRow.IsNull(6) ? string.Empty : (string)dataRow[6],
                                    });
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
                        List<UserAuthorizationDto> tempList = new List<UserAuthorizationDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new UserAuthorizationDto { Name = (string)dataRow[1], Roles = GetRolesAuthorizationByUserId((int)(dataRow[0])) });
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
                    else if (procedureName == "SelectRolesAuthorizationByUserId")
                    {
                        List<RoleAuthorizationDto> tempList = new List<RoleAuthorizationDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new RoleAuthorizationDto { RoleName = (string)dataRow[0] });
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
                    else if (procedureName == "SelectRoles")
                    {
                        List<RoleDto> tempList = new List<RoleDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new RoleDto { Id = (int)dataRow[0], Name = (string)dataRow[1] });
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
                    else if (procedureName == "SelectUserById")
                    {
                        List<UserDto> tempList = new List<UserDto>();
                        try
                        {

                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new UserDto { Id = (int)dataRow[0], Name = (string)dataRow[1], Password = (string)dataRow[2], Email = (string)dataRow[3], Roles = GetRolesIdByUserId((int)dataRow[0]).Select(x => x.Id).ToArray() });
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

                    else if (procedureName == "SelectRolesIdByUserId")
                    {
                        List<RoleDto> tempList = new List<RoleDto>();
                        try
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new RoleDto { Id = (int)dataRow[0] });
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

                    else if (procedureName == "SelectUsersByName")
                    {
                        List<UserDto> tempList = new List<UserDto>();
                        try
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new UserDto { Id = (int)dataRow[0], Name = (string)dataRow[1], Password = (string)dataRow[2], Email = (string)dataRow[3] });
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
                    else if (procedureName == "SelectLocations")
                    {
                        List<LocationDto> tempList = new List<LocationDto>();
                        try
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new LocationDto { Id = (int)dataRow[0], Address = (string)dataRow[1] });
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
                    else if (procedureName == "SelectSubjectByInventoryNumber")
                    {
                        List<SubjectDto> tempList = new List<SubjectDto>();
                        try
                        {
                            foreach (DataTable table in dataSet.Tables)
                            {
                                foreach (DataRow dataRow in table.Rows)
                                {
                                    tempList.Add(new SubjectDto
                                    {
                                        InventoryNumber = (int)dataRow[0],
                                        Name = (string)dataRow[1],
                                        StateId = dataRow.IsNull(2) ? null : (int?)dataRow[2],
                                        CategoryId = dataRow.IsNull(3) ? null : (int?)dataRow[3],
                                        Description = (string)dataRow[4],
                                        Photo = dataRow.IsNull(5) ? string.Empty : (string)dataRow[5],
                                        LocationId = dataRow.IsNull(6) ? null : (int?)dataRow[6],
                                    });
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


        public List<SubjectDetailsDto> GetSubjectsByCategoryId(int? categoryId)
        {
            List<SubjectDetailsDto> subjectsDto = new List<SubjectDetailsDto>();
            SqlParameter param = new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@categoryId", Value = (object)categoryId ?? DBNull.Value };
            GetDataFromDb(ref subjectsDto, "SelectSubjectsByCategoryId", param);
            return subjectsDto;
        }

        public SubjectDetailsDto GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            List<SubjectDetailsDto> subjectDto = new List<SubjectDetailsDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            GetDataFromDb(ref subjectDto, "SelectSubjectInformationById", param);
            return subjectDto.FirstOrDefault();
        }

        public UserAuthorizationDto GetUserAuthorizationByName(string userName)
        {
            List<UserAuthorizationDto> userDto = new List<UserAuthorizationDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@userName", Value = userName };
            GetDataFromDb(ref userDto, "SelectUserByName", param);
            return userDto.FirstOrDefault();
        }

        public bool IsValidUser(string userName, string password)
        {
            SqlParameter[] param = {
                new SqlParameter
                {
                   DbType = DbType.String,
                   ParameterName = "@username",
                   Value = userName
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
                    catch (SqlException sqlException)
                    {
                        Log.Error(sqlException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }

                    if ((int)resultPrameter.Value == 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public bool IsExistsUser(int userId, string userName)
        {
            SqlParameter[] param = {
                new SqlParameter
                {
                   DbType = DbType.String,
                   ParameterName = "@userName",
                   Value = userName
                },
                    new SqlParameter
                {
                   DbType = DbType.Int32,
                   ParameterName = "@userId",
                   Value = userId
                },
            };

            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "IsExistsUser";
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
                    catch (SqlException sqlException)
                    {
                        Log.Error(sqlException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }

                    if ((int)resultPrameter.Value == 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }


        public List<RoleAuthorizationDto> GetRolesAuthorizationByUserId(int userId)
        {
            List<RoleAuthorizationDto> roleDto = new List<RoleAuthorizationDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            GetDataFromDb(ref roleDto, "SelectRolesAuthorizationByUserId", param);
            return roleDto;
        }

        public List<CategoryDto> GetCategoriesByName(string categoryName)
        {
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@categoryName", Value = categoryName };
            GetDataFromDb(ref categoriesDto, "SelectCategoriesByName", param);
            return categoriesDto;
        }
        public List<SubjectDetailsDto> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
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

        public List<RoleDto> GetRoles()
        {
            List<RoleDto> rolesDto = new List<RoleDto>();
            GetDataFromDb(ref rolesDto, "SelectRoles");
            return rolesDto;
        }
        public UserDto GetUserById(int userId)
        {
            List<UserDto> userDto = new List<UserDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            GetDataFromDb(ref userDto, "SelectUserById", param);
            return userDto.FirstOrDefault();
        }

        public List<RoleDto> GetRolesIdByUserId(int userId)
        {
            List<RoleDto> roleDto = new List<RoleDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            GetDataFromDb(ref roleDto, "SelectRolesIdByUserId", param);
            return roleDto;
        }

        public List<UserDto> GetUsersByName(string userName)
        {
            List<UserDto> userDtoList = new List<UserDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@userName", Value = userName };
            GetDataFromDb(ref userDtoList, "SelectUsersByName", param);
            return userDtoList;
        }

        public List<LocationDto> GetLocations()
        {
            List<LocationDto> addressDtoList = new List<LocationDto>();
            GetDataFromDb(ref addressDtoList, "SelectLocations");
            return addressDtoList;
        }

        public SubjectDto GetSubjectByInventoryNumber(int inventoryNumber)
        {
            List<SubjectDto> subjectDto = new List<SubjectDto>();
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            GetDataFromDb(ref subjectDto, "SelectSubjectByInventoryNumber", param);
            return subjectDto.FirstOrDefault();
        }

        public bool IsExistsSubject(int inventoryNumber)
        {
            SqlParameter param = new SqlParameter
            {
                DbType = DbType.Int32,
                ParameterName = "@inventoryNumber",
                Value = inventoryNumber
            };

            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "IsExistSubject";
                    command.Parameters.Add(param);

                    SqlParameter resultPrameter = new SqlParameter();
                    resultPrameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(resultPrameter);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();

                    try
                    {
                        adapter.Fill(dataSet);
                    }
                    catch (SqlException sqlException)
                    {
                        Log.Error(sqlException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }

                    if ((int)resultPrameter.Value == 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
