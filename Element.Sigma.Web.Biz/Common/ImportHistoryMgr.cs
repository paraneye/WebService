using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.IO;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.Common
{
    public class ImportHistoryMgr
    {
       
        public SigmaResultType ListImportHistory(string ImportCategory, string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ImportCategory", ImportCategory));//MTO or CostCode or User etc...
            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            parameters.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListImportHistory", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }
        public SigmaResultType AddImportHistory(TypeImportHistory objImportHistory)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            DataSet ds = new DataSet();
            ds.Tables.Add("ImportHistory");
            ds.Tables["ImportHistory"].Columns.Add("Id");
            ds.Tables["ImportHistory"].Columns.Add("Total");
            ds.Tables["ImportHistory"].Columns.Add("Success");
            ds.Tables["ImportHistory"].Columns.Add("Fail");

            string[] str = new string[4];
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ImportCategory", objImportHistory.ImportCategory));
            paramList.Add(new SqlParameter("@ImportedFileName", objImportHistory.ImportedFileName));
            paramList.Add(new SqlParameter("@ImportedDate", objImportHistory.ImportedDate));
            paramList.Add(new SqlParameter("@TotalCount", objImportHistory.TotalCount));
            paramList.Add(new SqlParameter("@SuccessCount", objImportHistory.SuccessCount));
            paramList.Add(new SqlParameter("@FailCount", objImportHistory.FailCount));
            paramList.Add(new SqlParameter("@CreatedBy", objImportHistory.CreatedBy));
            paramList.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddImportHistory", paramList.ToArray());
                result.IsSuccessful = true;
                str[0] = outParam.Value.ToString();
                str[1] = objImportHistory.TotalCount.ToString();
                str[2] = objImportHistory.SuccessCount.ToString();
                str[3] = objImportHistory.FailCount.ToString();

                ds.Tables[0].Rows.Add(str);

                result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
                result.ScalarValue = (int)outParam.Value;
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType UpdateImportHistory(TypeImportHistory objImportHistory)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            DataSet ds = new DataSet();
            ds.Tables.Add("ImportHistory");
            ds.Tables["ImportHistory"].Columns.Add("Id");
            ds.Tables["ImportHistory"].Columns.Add("Total");
            ds.Tables["ImportHistory"].Columns.Add("Success");
            ds.Tables["ImportHistory"].Columns.Add("Fail");

            string[] str = new string[4];

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ImportHistoryId", objImportHistory.ImportHistoryId),
                    new SqlParameter("@ImportCategory", objImportHistory.ImportCategory),
					new SqlParameter("@ImportedFileName", objImportHistory.ImportedFileName),
					new SqlParameter("@ImportedDate", objImportHistory.ImportedDate),
					new SqlParameter("@TotalCount", objImportHistory.TotalCount),
					new SqlParameter("@SuccessCount", objImportHistory.SuccessCount),
					new SqlParameter("@FailCount", objImportHistory.FailCount),
					new SqlParameter("@UpdatedBy", AuthMgr.GetUserInfo().SigmaUserId.Trim()),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateImportHistory", parameters);
                result.IsSuccessful = true;

                str[0] = objImportHistory.ImportHistoryId.ToString();
                str[1] = objImportHistory.TotalCount.ToString();
                str[2] = objImportHistory.SuccessCount.ToString();
                str[3] = objImportHistory.FailCount.ToString();

                ds.Tables[0].Rows.Add(str);

                result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
                result.ScalarValue = objImportHistory.ImportHistoryId;
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemoveImportHistory(TypeImportHistory objImportHistory)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ImportHistoryId", objImportHistory.ImportHistoryId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveImportHistory", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
        public SigmaResultType MultiImportHistory(List<TypeImportHistory> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                foreach (TypeImportHistory anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "D":
                            result = RemoveImportHistory(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }
    }
}
