using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;
using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class SigmaJobMgr
    {

        public SigmaResultType GetSigmaJob(string sigmaJobId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@SigmaJobId", sigmaJobId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaJob", paramList.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaJob(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@SigmaJobName", (s_option == "SigmaJobName" ? s_key : null)));

            paramList.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            paramList.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            paramList.Add(new SqlParameter("@SortColumn", o_option));
            paramList.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaJob", paramList.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddSigmaJob(TypeSigmaJob objSigmaJob)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaJobName", objSigmaJob.SigmaJobName));
            paramList.Add(new SqlParameter("@JobCategoryCode", objSigmaJob.JobCategoryCode));
            paramList.Add(new SqlParameter("@CreatedBy", objSigmaJob.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaJob", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }


        public SigmaResultType UpdateSigmaJob(TypeSigmaJob objSigmaJob)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaJobId", objSigmaJob.SigmaJobId));
            paramList.Add(new SqlParameter("@SigmaJobName", objSigmaJob.SigmaJobName));
            paramList.Add(new SqlParameter("@JobCategoryCode", objSigmaJob.JobCategoryCode));
            paramList.Add(new SqlParameter("@UpdatedBy", objSigmaJob.UpdatedBy));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaJob", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemoveSigmaJob(TypeSigmaJob objSigmaJob)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@SigmaJobId", objSigmaJob.SigmaJobId));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaJob", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType MultiSigmaJob(List<TypeSigmaJob> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeSigmaJob anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddSigmaJob(anObj);
                            break;
                        case "U":
                            UpdateSigmaJob(anObj);
                            break;
                        case "D":
                            RemoveSigmaJob(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            result.IsSuccessful = true;

            return result;
        }
    }
}
