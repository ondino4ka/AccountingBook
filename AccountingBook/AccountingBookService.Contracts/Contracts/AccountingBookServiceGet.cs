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
using System.Web.Caching;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService : IGetService
    {
        private readonly string connectionString;
        private readonly string connectionStringCacheDependency;
        private readonly Cache cache;
        private const string ERROR_MESSAGE = "Now the server is unavailable.Try later";
        private const string ERROR_MESSAGE_REASON  = "Internal error";
        private readonly ILog Log;
        public AccountingBookService()
        {
            Log = LogManager.GetLogger("AccountingBookService");
            try
            {
                Log.Info("connection open");
                connectionString = ConfigurationManager.ConnectionStrings["AccountingBookConnection"].ConnectionString;
                connectionStringCacheDependency = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AccountingBookConnection"].ConnectionString;
                cache = new Cache();
                SqlDependency.Start(connectionStringCacheDependency);
            }
            catch (NullReferenceException ex)
            {
                Log.Error(ex.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
            catch (InvalidOperationException ex)
            {
                Log.Error(ex.Message);
                throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
            }
        }

        private List<T> GetDataFromDb<T>(Func<DataRow, T> createDtoFunc, string procedureName, string key, string tableName, params SqlParameter[] sqlParametr)
        {
            List<T> resultList = GetDataFromDb(createDtoFunc, procedureName, sqlParametr);
            UpdateCache(key, tableName, resultList);
            return resultList;
        }

        private List<T> GetDataFromDb<T>(Func<DataRow, T> createDtoFunc, string procedureName, params SqlParameter[] sqlParametr)
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
                        foreach (SqlParameter parametr in sqlParametr)
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
                        throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                    }
                    catch (SqlException sqlException)
                    {
                        Log.Error(sqlException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                    }
                    List<T> resultList = new List<T>();
                    try
                    {
                        foreach (DataTable table in dataSet.Tables)
                        {
                            foreach (DataRow dataRow in table.Rows)
                            {
                                resultList.Add(createDtoFunc(dataRow));
                            }
                        }
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        Log.Error(invalidCastException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                    }
                    return resultList;
                }
            }
        }

        private void UpdateCache(string key, string tableName, object value)
        {
            SqlCacheDependency dependency = null;
            try
            {
                dependency = new SqlCacheDependency("AccountingBook", tableName);
            }
            catch (DatabaseNotEnabledForNotificationException exDbDis)
            {
                Log.Error(exDbDis.Message);
                try
                {
                    SqlCacheDependencyAdmin.EnableNotifications(connectionStringCacheDependency);
                }
                catch (UnauthorizedAccessException exPerm)
                {
                    Log.Error(exPerm.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                }
            }
            catch (TableNotEnabledForNotificationException exTabDis)
            {
                Log.Error(exTabDis.Message);
                try
                {
                    SqlCacheDependencyAdmin.EnableTableForNotifications(connectionStringCacheDependency, tableName);
                }
                catch (SqlException exc)
                {
                    Log.Error(exc.Message);
                    throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                }
            }
            finally
            {
                if (dependency != null)
                {
                    cache.Insert(key, value, dependency);
                }
            }
        }

        public List<CategoryDto> GetCategories()
        {
            if (cache["Categories"] == null)
            {
                Func<DataRow, CategoryDto> retFunc = CreateCategoryDto;
                return GetDataFromDb(retFunc, "SelectCategories", "Categories", "Categories");
            }
            return (List<CategoryDto>)cache["Categories"];
        }
        public List<CategoryDto> GetCategoriesBesidesCurrent(int categoryId)
        {
            SqlParameter param = new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@categoryId", Value = (object)categoryId ?? DBNull.Value };
            Func<DataRow, CategoryDto> retFunc = CreateCategoryDto;
            return GetDataFromDb(retFunc, "SelectCategoriesBesidesCurrent", param);
        }
        public CategoryDto CreateCategoryDto(DataRow dataRow)
        {
            return new CategoryDto
            {
                Id = (int)dataRow[0],
                Pid = dataRow.IsNull(1) ? null : (int?)dataRow[1],
                Name = (string)dataRow[2]
            };
        }

        public List<SubjectDetailsDto> GetSubjectsByCategoryId(int? categoryId)
        {
            Func<DataRow, SubjectDetailsDto> retFunc = CreateSubjectDetailsDto;
            SqlParameter param = new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@categoryId", Value = (object)categoryId ?? DBNull.Value };
            return GetDataFromDb(retFunc, "SelectSubjectsByCategoryId", param);
        }
        public SubjectDetailsDto CreateSubjectDetailsDto(DataRow dataRow)
        {
            return new SubjectDetailsDto
            {
                InventoryNumber = (int)dataRow[0],
                Name = (string)dataRow[1],
                Photo = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2],
                Description = (string)dataRow[3]
            };
        }

        public SubjectDetailsDto GetSubjectInformationByInventoryNumber(int inventoryNumber)
        {
            Func<DataRow, SubjectDetailsDto> retFunc = CreateSubjectInformationByInventoryNumberDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            return GetDataFromDb(retFunc, "SelectSubjectInformationById", param).FirstOrDefault();
        }
        public SubjectDetailsDto CreateSubjectInformationByInventoryNumberDto(DataRow dataRow)
        {
            return new SubjectDetailsDto
            {
                InventoryNumber = (int)dataRow[0],
                Name = (string)dataRow[1],
                State = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2],
                Category = dataRow.IsNull(3) ? string.Empty : (string)dataRow[3],
                Photo = dataRow.IsNull(4) ? string.Empty : (string)dataRow[4],
                Description = (string)dataRow[5],
                Location = dataRow.IsNull(6) ? string.Empty : (string)dataRow[6],
            };
        }

        public UserAuthorizationDto GetUserAuthorizationByName(string userName)
        {
            Func<DataRow, UserAuthorizationDto> retFunc = CreateUserAuthorizationByNameDto;
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@userName", Value = userName };
            return GetDataFromDb(retFunc, "SelectUserByName", param).FirstOrDefault();
        }
        public UserAuthorizationDto CreateUserAuthorizationByNameDto(DataRow dataRow)
        {
            return new UserAuthorizationDto
            {
                Name = (string)dataRow[1],
                Roles = GetRolesAuthorizationByUserId((int)(dataRow[0]))
            };
        }

        public List<RoleAuthorizationDto> GetRolesAuthorizationByUserId(int userId)
        {
            Func<DataRow, RoleAuthorizationDto> retFunc = CreateRolesAuthorizationByUserIdDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            return GetDataFromDb(retFunc, "SelectRolesAuthorizationByUserId", param);
        }
        public RoleAuthorizationDto CreateRolesAuthorizationByUserIdDto(DataRow dataRow)
        {
            return new RoleAuthorizationDto
            {
                RoleName = (string)dataRow[0]
            };
        }

        public List<CategoryDto> GetCategoriesByName(string categoryName)
        {
            Func<DataRow, CategoryDto> retFunc = CreateCategoriesByNameDto;
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@categoryName", Value = categoryName };
            return GetDataFromDb(retFunc, "SelectCategoriesByName", param);
        }
        public CategoryDto CreateCategoriesByNameDto(DataRow dataRow)
        {
            return new CategoryDto
            {
                Id = (int)dataRow[0],
                Name = (string)dataRow[1]
            };
        }

        public List<SubjectDetailsDto> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            Func<DataRow, SubjectDetailsDto> retFunc = CreateSubjectsByNameCategoryIdAndStateIdDto;
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

            return GetDataFromDb(retFunc, "SelectSubjectByNameCategoryIdAndStateId", param);
        }

        public SubjectDetailsDto CreateSubjectsByNameCategoryIdAndStateIdDto(DataRow dataRow)
        {
            return new SubjectDetailsDto
            {
                InventoryNumber = (int)dataRow[0],
                Name = (string)dataRow[1],
                Photo = dataRow.IsNull(2) ? string.Empty : (string)dataRow[2],
                Description = (string)dataRow[3]
            };
        }

        public List<StateDto> GetStates()
        {
            if (cache["States"] == null)
            {
                Func<DataRow, StateDto> retFunc = CreateStatesDto;
                return GetDataFromDb(retFunc, "SelectStates", "States", "States");
            }
            return (List<StateDto>)cache["States"];
        }

        public StateDto GetStateById(int stateId)
        {
            Func<DataRow, StateDto> retFunc = CreateStatesDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@stateId", Value = stateId };
            return GetDataFromDb(retFunc, "SelectStateById", param).FirstOrDefault();
        }

        public StateDto CreateStatesDto(DataRow dataRow)
        {
            return new StateDto
            {
                Id = (int)dataRow[0],
                StateName = (string)dataRow[1]
            };
        }

        public List<RoleDto> GetRoles()
        {
            Func<DataRow, RoleDto> retFunc = CreateRolesDto;
            return GetDataFromDb(retFunc, "SelectRoles");
        }
        public RoleDto CreateRolesDto(DataRow dataRow)
        {
            return new RoleDto
            {
                Id = (int)dataRow[0],
                Name = (string)dataRow[1]
            };
        }

        public UserDto GetUserById(int userId)
        {
            Func<DataRow, UserDto> retFunc = CreateUserByIdDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            return GetDataFromDb(retFunc, "SelectUserById", param).FirstOrDefault();
        }
        public UserDto CreateUserByIdDto(DataRow dataRow)
        {
            return new UserDto
            {
                Id = (int)dataRow[0],
                Name = (string)dataRow[1],
                Email = (string)dataRow[3],
                Roles = GetRolesIdByUserId((int)dataRow[0]).Select(x => x.Id).ToArray()
            };
        }

        public List<RoleDto> GetRolesIdByUserId(int userId)
        {
            Func<DataRow, RoleDto> retFunc = CreateRolesIdByUserIdDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            return GetDataFromDb(retFunc, "SelectRolesIdByUserId", param);
        }

        public RoleDto CreateRolesIdByUserIdDto(DataRow dataRow)
        {
            return new RoleDto
            {
                Id = (int)dataRow[0]
            };
        }

        public List<UserDto> GetUsersByName(string userName)
        {
            Func<DataRow, UserDto> retFunc = CreateUsersByNameDto;
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@userName", Value = userName };
            return GetDataFromDb(retFunc, "SelectUsersByName", param);
        }
        public UserDto CreateUsersByNameDto(DataRow dataRow)
        {
            return new UserDto
            {
                Id = (int)dataRow[0],
                Name = (string)dataRow[1],
                Email = (string)dataRow[3]
            };
        }

        public List<LocationDto> GetLocations()
        {
            if (cache["Locations"] == null)
            {
                Func<DataRow, LocationDto> retFunc = CreateLocationsDto;
                return GetDataFromDb(retFunc, "SelectLocations", "Locations", "Locations");
            }
            return (List<LocationDto>)cache["Locations"];
        }
        public LocationDto CreateLocationsDto(DataRow dataRow)
        {
            return new LocationDto
            {
                Id = (int)dataRow[0],
                Address = (string)dataRow[1]
            };
        }

        public SubjectDto GetSubjectByInventoryNumber(int inventoryNumber)
        {
            Func<DataRow, SubjectDto> retFunc = CreateSubjectByInventoryNumberDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            return GetDataFromDb(retFunc, "SelectSubjectByInventoryNumber", param).FirstOrDefault();
        }
        public SubjectDto CreateSubjectByInventoryNumberDto(DataRow dataRow)
        {
            return new SubjectDto
            {
                InventoryNumber = (int)dataRow[0],
                Name = (string)dataRow[1],
                StateId = dataRow.IsNull(2) ? null : (int?)dataRow[2],
                CategoryId = dataRow.IsNull(3) ? null : (int?)dataRow[3],
                Description = (string)dataRow[4],
                Photo = dataRow.IsNull(5) ? string.Empty : (string)dataRow[5],
                LocationId = dataRow.IsNull(6) ? null : (int?)dataRow[6],
            };
        }

        public List<LocationDto> GetLocationsByAddress(string address)
        {
            Func<DataRow, LocationDto> retFunc = CreateLocationsByAddressDto;
            SqlParameter param = new SqlParameter { DbType = DbType.String, ParameterName = "@address", Value = address };
            return GetDataFromDb(retFunc, "SelectLocationsByAddress", param);
        }

        public LocationDto GetLocationsById(int locationId)
        {
            Func<DataRow, LocationDto> retFunc = CreateLocationsByAddressDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@idLocation", Value = locationId };
            return GetDataFromDb(retFunc, "SelectLocationById", param).FirstOrDefault();
        }
        public LocationDto CreateLocationsByAddressDto(DataRow dataRow)
        {
            return new LocationDto
            {
                Id = (int)dataRow[0],
                Address = (string)dataRow[1]
            };
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            Func<DataRow, CategoryDto> retFunc = CreateCategoryByIdDto;
            SqlParameter param = new SqlParameter { DbType = DbType.Int32, ParameterName = "@categoryId", Value = categoryId };
            return GetDataFromDb(retFunc, "SelectCategoryById", param).FirstOrDefault();
        }
        public CategoryDto CreateCategoryByIdDto(DataRow dataRow)
        {
            return new CategoryDto
            {
                Id = (int)dataRow[0],
                Pid = dataRow.IsNull(1) ? null : (int?)dataRow[1],
                Name = (string)dataRow[2]
            };
        }

        private bool GetBoolFromDb(string procedureName, params SqlParameter[] sqlParametr)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    if (sqlParametr.Count() != 0)
                    {
                        foreach (SqlParameter parametr in sqlParametr)
                        {
                            command.Parameters.Add(parametr);
                        }
                    }
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
                        throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                    }
                    catch (InvalidOperationException invalidOperationException)
                    {
                        Log.Error(invalidOperationException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(ERROR_MESSAGE), new FaultReason(ERROR_MESSAGE_REASON));
                    }
                    if ((int)resultPrameter.Value == 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
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
            return GetBoolFromDb("IsValidUser", param);
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
            return GetBoolFromDb("IsExistsUser", param);
        }

        public bool IsExistsSubject(int inventoryNumber)
        {
            SqlParameter param = new SqlParameter
            {
                DbType = DbType.Int32,
                ParameterName = "@inventoryNumber",
                Value = inventoryNumber
            };
            return GetBoolFromDb("IsExistSubject", param);
        }
    }
}