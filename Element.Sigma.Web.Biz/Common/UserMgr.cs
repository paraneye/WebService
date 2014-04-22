using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Element.Shared.Common;

namespace Element.Sigma.Web.Biz.Common
{
    public class UserMgr
    {
        public SigmaResultType Login(string userId, string userName)
        {
            SigmaResultType result = new SigmaResultType();
            result.IsSuccessful = true;
            return result;
        }

        public SigmaResultType GetUser(string userId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetUser", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListUser()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListUser", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddUser(string userName)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userName", userName)
                };

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_AddUser", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveUser(string userId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveUser", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
    }
}
