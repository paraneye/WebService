using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class ScheduledWorkItemMgr
    {
        public SigmaResultType GetScheduledWorkItem(string scheduledWorkItemId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@scheduledWorkItemId", scheduledWorkItemId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetScheduledWorkItem", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListScheduledWorkItem(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCompany", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0];
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddScheduledWorkItem(TypeScheduledWorkItem objScheduledWorkItem)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@ExternalScheduleId", objScheduledWorkItem.ExternalScheduleId),
					new SqlParameter("@CwpId", objScheduledWorkItem.CwpId),
					new SqlParameter("@ScheduleName", objScheduledWorkItem.ScheduleName),
					new SqlParameter("@StartDate", objScheduledWorkItem.StartDate),
					new SqlParameter("@EndDate", objScheduledWorkItem.EndDate),
					new SqlParameter("@CrewMemebersAssigned", objScheduledWorkItem.CrewMemebersAssigned),
					new SqlParameter("@TotalWorkingHours", objScheduledWorkItem.TotalWorkingHours),
					new SqlParameter("@LeaderId", objScheduledWorkItem.LeaderId),
					new SqlParameter("@CreatedBy", objScheduledWorkItem.CreatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_AddScheduledWorkItem", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }


        public SigmaResultType UpdateScheduledWorkItem(TypeScheduledWorkItem objScheduledWorkItem)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@ExternalScheduleId", objScheduledWorkItem.ExternalScheduleId),
					new SqlParameter("@CwpId", objScheduledWorkItem.CwpId),
					new SqlParameter("@ScheduleName", objScheduledWorkItem.ScheduleName),
					new SqlParameter("@StartDate", objScheduledWorkItem.StartDate),
					new SqlParameter("@EndDate", objScheduledWorkItem.EndDate),
					new SqlParameter("@CrewMemebersAssigned", objScheduledWorkItem.CrewMemebersAssigned),
					new SqlParameter("@TotalWorkingHours", objScheduledWorkItem.TotalWorkingHours),
					new SqlParameter("@LeaderId", objScheduledWorkItem.LeaderId),
					new SqlParameter("@CreatedBy", objScheduledWorkItem.CreatedBy),
					new SqlParameter("@UpdatedBy", objScheduledWorkItem.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateScheduledWorkItem", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemoveScheduledWorkItem(string scheduledWorkItemId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@scheduledWorkItemId", scheduledWorkItemId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveScheduledWorkItem", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType BatchProcessScheduledWorkItem(List<TypeScheduledWorkItem> objList)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeScheduledWorkItem anObj in objList)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddScheduledWorkItem(anObj);
                            break;
                        case "U":
                            UpdateScheduledWorkItem(anObj);
                            break;
                        case "D":
                            RemoveScheduledWorkItem(anObj.ScheduledWorkItemId);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }
    }
}
