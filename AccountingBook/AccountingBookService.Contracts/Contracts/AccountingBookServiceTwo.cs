using System;
using System.Linq;
using System.Configuration;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;
using AccountingBookService.Contracts.Models.Dto;
using AccountingBookService.Contracts.Models.DtoException;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService: IAddService, IEditService, IDeleteService
    {
        public void AddUser(UserDto userDto)
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
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertUser";
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

        public void DeleteUserById(int userId)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteUserById";
                    command.Parameters.Add(parameter);

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

    }
}
