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
using Element.Sigma.Web.Biz.Types.Common;

namespace Element.Sigma.Web.Biz.Common
{
    public class ScheduledWorkItemMgr
    {
        public SigmaResultType GetScheduledWorkItem(string scheduledWorkItemId)
        {
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ScheduledWorkItemId", scheduledWorkItemId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetScheduledWorkItem", parameters);
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            return result;
        }
        public SigmaResultType AddScheduledWorkItem(TypeScheduledWorkItem objScheduledWorkItem)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ExternalScheduleId", objScheduledWorkItem.ExternalScheduleId));
            paramList.Add(new SqlParameter("@CwpId", objScheduledWorkItem.CwpId));
            paramList.Add(new SqlParameter("@ScheduleName", objScheduledWorkItem.ScheduleName));
            paramList.Add(new SqlParameter("@StartDate", objScheduledWorkItem.StartDate));
            paramList.Add(new SqlParameter("@EndDate", objScheduledWorkItem.EndDate));
            paramList.Add(new SqlParameter("@CrewMemebersAssigned", objScheduledWorkItem.CrewMemebersAssigned));
            paramList.Add(new SqlParameter("@TotalWorkingHours", objScheduledWorkItem.TotalWorkingHours));
            paramList.Add(new SqlParameter("@LeaderId", objScheduledWorkItem.LeaderId));
            paramList.Add(new SqlParameter("@CreatedBy", objScheduledWorkItem.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddScheduledWorkItem", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
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
        public SigmaResultType RemoveScheduledWorkItem(TypeScheduledWorkItem objScheduledWorkItem)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ScheduledWorkItemId", objScheduledWorkItem.ScheduledWorkItemId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveScheduledWorkItem", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
        public SigmaResultType MultiScheduledWorkItem(List<TypeScheduledWorkItem> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeScheduledWorkItem anObj in listObj)
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
                            RemoveScheduledWorkItem(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }
    }
}
