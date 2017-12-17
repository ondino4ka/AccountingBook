using AccountingBookService.Contracts.Contracts.Interface;
using AccountingBookService.Contracts.Models.DtoException;
using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService: IDeleteService
    {
        public void DeleteSubjectByInventoryNumber(int inventoryNumber)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteSubjectByInventoryNumber";
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

        public void DeleteLocationById(int locationId)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@locationId", Value = locationId };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteLocationById";
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

        public void DeleteStateById(int stateId)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@stateId", Value = stateId };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteStateById";
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
    }
}
