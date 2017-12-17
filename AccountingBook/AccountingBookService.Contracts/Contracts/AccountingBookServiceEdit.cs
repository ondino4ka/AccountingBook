using AccountingBookService.Contracts.Contracts.Interface;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;
using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService : IEditService
    {
        public void EditUser(UserDto userDto)
        {
            DataTable data = new DataTable();
            data.Columns.Add("id", typeof(int));
            foreach (var role in userDto.Roles)
            {
                data.Rows.Add(role);
            }

            SqlParameter[] param = {
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
                   new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = userDto.Id
                },
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateUser";
                    command.Parameters.AddRange(param);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
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

        public void EditSubjectInformation(SubjectDto subjectDto)
        {
            SqlParameter[] param = {
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
                    DbType = DbType.String,
                    ParameterName = "@description",
                     Value = subjectDto.Description
                },
                     new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@locationId",
                    Value = (object)subjectDto.LocationId ?? DBNull.Value
                },

            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateSubjectInformation";
                    command.Parameters.AddRange(param);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
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

        public void EditSubjectPhoto(int inventoryNumber, string photo)
        {
            SqlParameter[] param = {
                new SqlParameter
                {
                   DbType = DbType.Int32,
                   ParameterName = "@inventoryNumber",
                   Value = inventoryNumber
                },         
                     new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@photo",
                    Value = (object)photo ?? DBNull.Value
                },
            };


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateSubjectPhoto";
                    command.Parameters.AddRange(param);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
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

        public void EditLocation(int locationId, string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Address can not be null or empty"), new FaultReason("External error"));
            }
            SqlParameter[] param = {
                new SqlParameter
                {
                   DbType = DbType.Int32,
                   ParameterName = "@locationId",
                   Value = locationId
                },
                     new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "@address",
                    Value = address
                },
            };


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateLocation";
                    command.Parameters.AddRange(param);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
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
    }
}
