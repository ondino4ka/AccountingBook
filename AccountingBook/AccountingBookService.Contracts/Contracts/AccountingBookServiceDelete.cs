using AccountingBookService.Contracts.Contracts.Interface;
using System.Data;
using System.Data.SqlClient;

namespace AccountingBookService.Contracts.Contracts
{
    public partial class AccountingBookService: IDeleteService
    {
        public void DeleteSubjectByInventoryNumber(int inventoryNumber)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@inventoryNumber", Value = inventoryNumber };
            ChangeDataDB("DeleteSubjectByInventoryNumber", parameter);
        }    

        public void DeleteUserById(int userId)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@userId", Value = userId };
            ChangeDataDB("DeleteUserById", parameter);
        }

        public void DeleteLocationById(int locationId)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@locationId", Value = locationId };
            ChangeDataDB("DeleteLocationById", parameter);           
        }

        public void DeleteStateById(int stateId)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@stateId", Value = stateId };
            ChangeDataDB("DeleteStateById", parameter);     
        }

        public void DeleteCategoryById(int categoryId)
        {
            SqlParameter parameter = new SqlParameter { DbType = DbType.Int32, ParameterName = "@categoryId", Value = categoryId };
            ChangeDataDB("DeleteCategoryById", parameter);          
        }
    }
}
