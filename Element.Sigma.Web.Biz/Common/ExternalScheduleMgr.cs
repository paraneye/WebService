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
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.Common
{
    public class ExternalScheduleMgr
    {
        public SigmaResultType GetExternalSchedule(string externalScheduleId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ExternalScheduleId", externalScheduleId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetExternalSchedule", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListExternalSchedule(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListExternalSchedule", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        /// <summary>
        /// P6 관련
        /// </summary>
        /// <param name="objExternalSchedule"></param>
        /// <returns></returns>
        public SigmaResultType AddExternalSchedule(TypeExternalSchedule objExternalSchedule)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Level", objExternalSchedule.Level));
            paramList.Add(new SqlParameter("@StartDate", objExternalSchedule.StartDate));
            paramList.Add(new SqlParameter("@EndDate", objExternalSchedule.EndDate));
            paramList.Add(new SqlParameter("@OriginalDuration", objExternalSchedule.OriginalDuration));
            paramList.Add(new SqlParameter("@ProjectObjectId", objExternalSchedule.ProjectObjectId));
            paramList.Add(new SqlParameter("@ActivityObjectId", objExternalSchedule.ActivityObjectId));
            paramList.Add(new SqlParameter("@ParentObjectId", objExternalSchedule.ParentObjectId));
            paramList.Add(new SqlParameter("@RemainingDuration", objExternalSchedule.RemainingDuration));
            paramList.Add(new SqlParameter("@ExternalProjectName", objExternalSchedule.ExternalProjectName));
            paramList.Add(new SqlParameter("@CalendarId", objExternalSchedule.CalendarId));
            paramList.Add(new SqlParameter("@CreatedBy", AuthMgr.GetUserInfo().SigmaUserId));
            paramList.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddExternalSchedule", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }


        public SigmaResultType UpdateExternalSchedule(TypeExternalSchedule objExternalSchedule)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@Level", objExternalSchedule.Level),
					new SqlParameter("@StartDate", objExternalSchedule.StartDate),
					new SqlParameter("@EndDate", objExternalSchedule.EndDate),
					new SqlParameter("@OriginalDuration", objExternalSchedule.OriginalDuration),
					new SqlParameter("@ProjectObjectId", objExternalSchedule.ProjectObjectId),
					new SqlParameter("@ActivityObjectId", objExternalSchedule.ActivityObjectId),
					new SqlParameter("@ParentObjectId", objExternalSchedule.ParentObjectId),
					new SqlParameter("@RemainingDuration", objExternalSchedule.RemainingDuration),
					new SqlParameter("@CalendarId", objExternalSchedule.CalendarId),
					new SqlParameter("@CreatedBy", AuthMgr.GetUserInfo().SigmaUserId.Trim()),
					new SqlParameter("@UpdatedBy", AuthMgr.GetUserInfo().SigmaUserId.Trim()),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateExternalSchedule", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemoveExternalSchedule(TypeExternalSchedule objExternalSchedule)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ExternalScheduleId", objExternalSchedule.ExternalScheduleId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveExternalSchedule", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType MultiExternalSchedule(List<TypeExternalSchedule> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeExternalSchedule anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddExternalSchedule(anObj);
                            break;
                        case "U":
                            UpdateExternalSchedule(anObj);
                            break;
                        case "D":
                            RemoveExternalSchedule(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }
    }
}
