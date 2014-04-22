using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Element.Shared.Common;
using System.Collections.Generic;
using Element.Sigma.Web.Biz.Types.Common;

namespace Element.Sigma.Web.Biz.Common
{
    public class LogMgr
    {
        public SigmaResultType GetSigmaLog(string id)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Id", id)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaLog", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaLog(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaLog", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddSigmaLog(TypeSigmaLog objSigmaLog)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Date", objSigmaLog.Date));
            paramList.Add(new SqlParameter("@Thread", objSigmaLog.Thread));
            paramList.Add(new SqlParameter("@Level", objSigmaLog.Level));
            paramList.Add(new SqlParameter("@Logger", objSigmaLog.Logger));
            paramList.Add(new SqlParameter("@Message", objSigmaLog.Message));
            paramList.Add(new SqlParameter("@Exception", objSigmaLog.Exception));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaLog", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }


        public SigmaResultType UpdateSigmaLog(TypeSigmaLog objSigmaLog)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@Date", objSigmaLog.Date),
					new SqlParameter("@Thread", objSigmaLog.Thread),
					new SqlParameter("@Level", objSigmaLog.Level),
					new SqlParameter("@Logger", objSigmaLog.Logger),
					new SqlParameter("@Message", objSigmaLog.Message),
					new SqlParameter("@Exception", objSigmaLog.Exception)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaLog", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveSigmaLog(TypeSigmaLog objSigmaLog)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Id", objSigmaLog.Id)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaLog", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType MultiSigmaLog(List<TypeSigmaLog> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeSigmaLog anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddSigmaLog(anObj);
                            break;
                        case "U":
                            UpdateSigmaLog(anObj);
                            break;
                        case "D":
                            RemoveSigmaLog(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }
    }
}
