using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Element.Reveal.DataLibrary;
using System.Data.SqlClient;
using Element.Shared.Common;
using System.Data;
using System.Transactions;
using Element.Sigma.Web.Biz.Workflow;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class DataSync
    {
        public List<DataSyncFileVersionInfoDTO> SyncDownload(string apkVersion, string udID, string loginID, int dataVersion)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@VesionId", dataVersion),
                    new SqlParameter("@LoginID", loginID)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDataSyncFileVersionInfo", parameters);
            List<DataSyncFileVersionInfoDTO> result = DTOHelper.DataTableToListDTO<DataSyncFileVersionInfoDTO>(ds);
            return result;
        }

        public DataSyncZumeroInfoDTO SyncZumero(string loginID)
        {
            DataSyncZumeroInfoDTO result = new DataSyncZumeroInfoDTO();
            result.ZumeroURL = System.Web.Configuration.WebConfigurationManager.AppSettings["ZumeroURL"]; ;
            result.ZumeroFile = System.Web.Configuration.WebConfigurationManager.AppSettings["ZumeroFile"]; ;
            result.ZumeroUser = System.Web.Configuration.WebConfigurationManager.AppSettings["ZumeroUser"]; ;
            result.ZumeroPassword = System.Web.Configuration.WebConfigurationManager.AppSettings["ZumeroPassword"]; ;
            return result;
        }
        #region Save

        #region Multi Save UploadFileHistoryInfo
        public SigmaResultTypeDTO MultiUploadFileHistoryInfo(List<UploadFileHistoryInfoDTO> objList)
        {
            TransactionScope scope = null;
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                foreach (UploadFileHistoryInfoDTO anObj in objList)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddUploadFileHistoryInfo(anObj);
                            break;
                        case "U":
                            //UpdateSigmaRole(anObj);
                            break;
                        case "D":
                            //RemoveSigmaRole(anObj);
                            break;
                    }
                }
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultTypeDTO AddUploadFileHistoryInfo(UploadFileHistoryInfoDTO anObj)
        {
            TransactionScope scope = null;
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FileName", anObj.FileName));
            paramList.Add(new SqlParameter("@FilePath", anObj.FilePath));
            paramList.Add(new SqlParameter("@RelationTable", anObj.RelationTable));
            paramList.Add(new SqlParameter("@MobileLoginId", anObj.MobileLoginId));
            paramList.Add(new SqlParameter("@MobileUdId", anObj.MobileUdId));
            paramList.Add(new SqlParameter("@CreatedDate", anObj.CreatedDate));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "tsp_AddUploadFileHistoryInfo", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
        #endregion Multi Save UploadFileHistoryInfo End

        #region Multi Save DataSyncHistoryInfo
        public SigmaResultTypeDTO MultiDataSyncHistoryInfo(List<DataSyncHistoryInfoDTO> objList)
        {
            TransactionScope scope = null;
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                foreach (DataSyncHistoryInfoDTO anObj in objList)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddDataSyncHistoryInfo(anObj);
                            break;
                        case "U":
                            //UpdateSigmaRole(anObj);
                            break;
                        case "D":
                            //RemoveSigmaRole(anObj);
                            break;
                    }
                }
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultTypeDTO AddDataSyncHistoryInfo(String FromFileVerSionId, String ToFileVerSionId, String MobileLoginId, String MobileUdId, String CreatedDate)
        {
            TransactionScope scope = null;
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FromFileVerSionId", FromFileVerSionId));
            paramList.Add(new SqlParameter("@ToFileVerSionId", ToFileVerSionId));
            paramList.Add(new SqlParameter("@MobileLoginId", MobileLoginId));
            paramList.Add(new SqlParameter("@MobileUdId", MobileUdId));
            paramList.Add(new SqlParameter("@CreatedDate", CreatedDate));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "tsp_AddDataSyncHistoryInfo", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            RFIWorkFlowSubmit(MobileLoginId);
            return result;
        }

        private void RFIWorkFlowSubmit(String loginId)
        {

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LoginId", loginId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListRfi", parameters);
            WorkflowMgr workflowMgr = new WorkflowMgr();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    List<Element.Sigma.Web.Biz.Types.Common.TypeTransition> transitionList = new List<Element.Sigma.Web.Biz.Types.Common.TypeTransition>();
                    Element.Sigma.Web.Biz.Types.Common.TypeTransition typeTransition = new Element.Sigma.Web.Biz.Types.Common.TypeTransition();

                    transitionList.Add(typeTransition);
                    Common common = new Common();
                    UserInfoDTO userInfo = common.GetUserInfo(ds.Tables[0].Rows[i]["ToUserId"].ToString());

                    typeTransition.UserId = ds.Tables[0].Rows[i]["ToUserId"].ToString();
                    typeTransition.Role = userInfo.CurrentSigmaRoleId;
                    typeTransition.Row = 0;
                    transitionList.Add(typeTransition);

                    workflowMgr.GetWorkflowRoleTitle("WORKFLOW_TYPE_RFI");
                    workflowMgr.SaveWorkflowCrew("WORKFLOW_TYPE_RFI", 0, loginId, transitionList, ds.Tables[0].Rows[i]["Subject"].ToString(), ds.Tables[0].Rows[i]["ReasonRequested"].ToString(), ds.Tables[0].Rows[i]["ProposedSolution"].ToString(), (int)ds.Tables[0].Rows[i]["RfiId"], (int)ds.Tables[0].Rows[i]["IwpId"]);
                    workflowMgr.SaveWorkflowForEasyEx("WORKFLOW_TYPE_RFI", (int)ds.Tables[0].Rows[i]["RfiId"], 0, "Y", loginId, ds.Tables[0].Rows[i]["ReasonRequested"].ToString(), ds.Tables[0].Rows[i]["ProposedSolution"].ToString());

                    TransactionScope scope = null;
                    SigmaResultTypeDTO result = new SigmaResultTypeDTO();
                    
                    List<SqlParameter> paramList = new List<SqlParameter>();
                    paramList.Add(new SqlParameter("@RfiId", (int)ds.Tables[0].Rows[i]["RfiId"]));
                    paramList.Add(new SqlParameter("@ClientRfiNo", loginId));

                    using (scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_UpdateRfi", paramList.ToArray());
                        result.IsSuccessful = true;
                        scope.Complete();
                    }
                }
            }

        }
        
        public SigmaResultTypeDTO AddDataSyncHistoryInfo(DataSyncHistoryInfoDTO anObj)
        {
            TransactionScope scope = null;
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FromFileVerSionId", anObj.FromFileVerSionId));
            paramList.Add(new SqlParameter("@ToFileVerSionId", anObj.ToFileVerSionId));
            paramList.Add(new SqlParameter("@MobileLoginId", anObj.MobileLoginId));
            paramList.Add(new SqlParameter("@MobileUdId", anObj.MobileUdId));
            paramList.Add(new SqlParameter("@CreatedDate", anObj.CreatedDate));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "tsp_AddDataSyncHistoryInfo", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        #endregion Multi Save DataSyncHistoryInfo

        #endregion Save End

    }
}
