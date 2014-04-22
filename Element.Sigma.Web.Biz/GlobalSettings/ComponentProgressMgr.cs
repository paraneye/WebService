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
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class ComponentProgressMgr
    {
        public SigmaResultType GetComponentProgress(string componentProgressId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentProgressId", componentProgressId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetComponentProgress", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListComponentProgress(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListComponentProgress", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListComponentProgressStep(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < s_option.Count; i++)
            {
                parameters.Add(new SqlParameter(s_option[i], s_key[i]));
            }
            
            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProgressStepByComponentId", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddComponentProgress(TypeComponentProgress objComponentProgress)
        {
            TransactionScope scope = null;
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            
            List<SqlParameter> paramList = new List<SqlParameter>();
            if (objComponentProgress.ProgressStepId > 0)
                paramList.Add(new SqlParameter("@ProgressStepId", objComponentProgress.ProgressStepId));
            else
                paramList.Add(new SqlParameter("@ProgressStepId", DBNull.Value));

            if (objComponentProgress.CostCodeId > 0)
                paramList.Add(new SqlParameter("@CostCodeId", objComponentProgress.CostCodeId));
            else
                paramList.Add(new SqlParameter("@CostCodeId", DBNull.Value));
            paramList.Add(new SqlParameter("@ComponentId", objComponentProgress.ComponentId));
            paramList.Add(new SqlParameter("@IwpId", DBNull.Value));
            paramList.Add(new SqlParameter("@IsCompleted", objComponentProgress.IsCompleted));
            paramList.Add(new SqlParameter("@AmountInstalled", objComponentProgress.AmountInstalled));
            paramList.Add(new SqlParameter("@EstimatedManhours", objComponentProgress.EstimatedManhours));
            paramList.Add(new SqlParameter("@OwnerCostCodeId", objComponentProgress.OwnerCostCodeId));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddComponentProgress", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType UpdateComponentProgress(TypeComponentProgress objComponentProgress)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentProgressId", objComponentProgress.ComponentProgressId),
					new SqlParameter("@ProgressStepId", objComponentProgress.ProgressStepId),
					new SqlParameter("@CostCodeId", objComponentProgress.CostCodeId),
					new SqlParameter("@ComponentId", objComponentProgress.ComponentId),
					new SqlParameter("@IwpId", objComponentProgress.IwpId),
					new SqlParameter("@IsCompleted", objComponentProgress.IsCompleted),
					new SqlParameter("@AmountInstalled", objComponentProgress.AmountInstalled),
					new SqlParameter("@EstimatedManhours", objComponentProgress.EstimatedManhours),
					new SqlParameter("@OwnerCostCodeId", objComponentProgress.OwnerCostCodeId),
					new SqlParameter("@UpdatedBy", userinfo.SigmaUserId),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateComponentProgress", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemoveComponentProgress(TypeComponentProgress objComponentProgress)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentProgressId", objComponentProgress.ComponentProgressId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveComponentProgress", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveComponentProgressByComponentId(TypeComponentProgress objComponentProgress)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", objComponentProgress.ComponentId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveComponentProgressbyComponentId", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiComponentProgress(List<TypeComponentProgress> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                if (listObj.Count > 0)
                    RemoveComponentProgressByComponentId(listObj[0]);

                foreach (TypeComponentProgress anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddComponentProgress(anObj);
                            break;
                        case "U":
                            UpdateComponentProgress(anObj);
                            break;
                        case "D":
                            RemoveComponentProgress(anObj);
                            break;
                    }
                }
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
    }
}
