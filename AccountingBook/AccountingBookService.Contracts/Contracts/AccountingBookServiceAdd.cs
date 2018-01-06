using AccountingBookService.Contracts.Contracts.Interface;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;
using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService : IAddService
    {
        private void ChangeDataDB(string procedureName, params SqlParameter[] sqlParameter)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;

                    if (sqlParameter != null)
                    {
                        foreach (SqlParameter parameter in sqlParameter)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (InvalidOperationException invalidOperationException)
                    {
                        Log.Error(invalidOperationException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }
                    catch (SqlException sqlException)
                    {
                        Log.Error(sqlException.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.Message);
                        throw new FaultException<ServiceFault>(new ServiceFault(errorMessage), new FaultReason("Internal error"));
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public void AddUser(UserDto userDto)
        {
            DataTable data = new DataTable();
            data.Columns.Add("id", typeof(int));
            foreach (var role in userDto.Roles)
            {
                data.Rows.Add(role);
            }

            SqlParameter[] parameters = {
                new SqlParameter
                {
                   DbType = DbType.String,
                   ParameterName = "@name",
                   Value = userDto.Name
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@passwrod",
                    Value = userDto.Password
                },
                   new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@email",
                    Value = userDto.Email
                },

                   new SqlParameter
                {
                    SqlDbType = SqlDbType.Structured,
                    ParameterName = "@ids",
                    Value = data
                },
            };
            ChangeDataDB("InsertUser", parameters);
        }

        public void AddSubject(SubjectDto subjectDto)
        {
            SqlParameter[] parameters = {
                new SqlParameter
                {
                   DbType = DbType.Int32,
                   ParameterName = "@inventoryNumber",
                   Value = subjectDto.InventoryNumber
                },
                new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@name",
                    Value = subjectDto.Name
                },
                   new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@stateId",
                    Value = (object)subjectDto.StateId ?? DBNull.Value
                },

                   new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@categoryId",
                    Value = (object)subjectDto.CategoryId ?? DBNull.Value
                },
                   new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@photo",
                    Value = (object)subjectDto.Photo ?? DBNull.Value
                },
                 new SqlParameter
                 {
                    DbType = DbType.String,
                    ParameterName = "@description",
                    Value = subjectDto.Description
                 },
                    new SqlParameter
                 {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@locationId",
                    Value = (object)subjectDto.LocationId ?? DBNull.Value
                 }
            };
            ChangeDataDB("InsertSubject", parameters);
        }

        public void AddLocation(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Address can not be null or empty"), new FaultReason("External error"));
            }
            SqlParameter parameter = new SqlParameter
            {
                DbType = DbType.String,
                ParameterName = "@address",
                Value = address
            };
            ChangeDataDB("InsertLocation", parameter);
        }

        public void AddState(string stateName)
        {
            if (string.IsNullOrEmpty(stateName))
            {
                throw new FaultException<ServiceFault>(new ServiceFault("State can not be null or empty"), new FaultReason("External error"));
            }
            SqlParameter parameter = new SqlParameter
            {
                DbType = DbType.String,
                ParameterName = "@stateName",
                Value = stateName
            };
            ChangeDataDB("InsertState", parameter);
        }

        public void AddCategory(int? pid, string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Name can not be null or empty"), new FaultReason("External error"));
            }
            SqlParameter[] parameters = {
                new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@categoryName",
                    Value = categoryName
                },
                new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@pid",
                    Value = (object)pid ?? DBNull.Value
                }
            };
            ChangeDataDB("InsertCategory", parameters);
        }
    }
}