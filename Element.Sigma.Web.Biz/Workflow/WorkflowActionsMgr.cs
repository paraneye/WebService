using Element.Shared.Common;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace Element.Sigma.Web.Biz.Workflow
{
    public class WorkflowActionsMgr
    {
        #region CheckDocumentHasController : Process가 관리자정보를 가지고 있는지 조회

        /**********************************************************************************************
         * Mehtod   명 : CheckDocumentHasController
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : Process가 관리자정보를 가지고 있는지 조회
         * Input    값 : CheckDocumentHasController(작성한 Process GuID)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// Process가 관리자정보를 가지고 있는지 조회
        /// </summary>
        /// <param name="processId">작성한 Process</param>
        /// <param name="conditionResult">bool</param>
        public void CheckDocumentHasController(Guid processId, out bool conditionResult)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));

            conditionResult = false;

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentByDocumentId", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    conditionResult = true;
                }
            }
        }

        #endregion

        #region CheckDocumentsAuthorIsBoss : Process의 최종승인자가 보스인지 조회

        /**********************************************************************************************
         * Mehtod   명 : CheckDocumentsAuthorIsBoss
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : Process의 최종승인자가 보스인지 조회
         * Input    값 : CheckDocumentsAuthorIsBoss(작성한 Process GuID)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// CheckDocumentsAuthorIsBoss : Process의 최종승인자가 보스인지 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <returns>DataTable</returns>
        /// <param name="conditionResult">bool</param>
        public void CheckDocumentsAuthorIsBoss(Guid processId, out bool conditionResult)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));

            conditionResult = false;

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetAuthorBossList", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    conditionResult = true;
                }
            }
        }

        #endregion

        #region CheckBigBossMustSight : Process의 합이 100보다 큰지 조회

        /**********************************************************************************************
         * Mehtod   명 : CheckBigBossMustSight
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : Process의 합이 100보다 큰지 조회
         * Input    값 : CheckBigBossMustSight
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// CheckBigBossMustSight : Process의 합이 100보다 큰지 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="conditionResult">bool</param>
        public void CheckBigBossMustSight(Guid processId, out bool conditionResult)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));

            conditionResult = false;

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentBiggerThanSum", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    conditionResult = true;
                }
            }
        }

        #endregion

        #region DeleteEmptyTransitionHistoryItems : TransitionTime가 값이 없는 Process 삭제

        /**********************************************************************************************
         * Mehtod   명 : DeleteEmptyTransitionHistoryItems
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : DocumentTransitionHistories의 Process(Document)의 TransitionTime가 값이 없으면 모두 지울것
         * Input    값 : DeleteEmptyTransitionHistoryItems
         * Ouput    값 : void
         **********************************************************************************************/
        /// <summary>
        /// DeleteEmptyTransitionHistoryItems : TransitionTime가 값이 없는 Process 삭제
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        public void DeleteEmptyTransitionHistoryItems(Guid processId)
        {
            TransactionScope scope = null;
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ProcessID", processId));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                int result = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_AddImportHistory", paramList.ToArray());

                scope.Complete();
            }
        }

        #endregion

        #region WriteTransitionHistory : 등록된 정보를 바탕으로한 히스토리 생성

        /**********************************************************************************************
         * Mehtod   명 : WriteTransitionHistory
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 등록된 정보를 바탕으로한 히스토리 생성
         * Input    값 : WriteTransitionHistory(작성한 Process GuID, 현재상태값, 다음상태값, 명령어, 담당자리스트)
         * Ouput    값 : DataTable
         **********************************************************************************************/
        /// <summary>
        /// WriteTransitionHistory : 등록된 정보를 바탕으로한 히스토리 생성
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="currentStateName">현재상태값</param>
        /// <param name="executedStateName">다음상태값</param>
        /// <param name="commandName">명령어</param>
        /// <param name="identities">담당자리스트</param>
        public void WriteTransitionHistory(Guid processId, string currentStateName, string executedStateName, string commandName, IEnumerable<Guid> identities)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            foreach (Guid uiUser in identities)
            {
                // Compose parameters
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@SigmaUserGuid", uiUser));

                // Get Data 
                DataSet dsPos = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentStatus", parameters.ToArray());

                if (dsPos != null)
                {
                    if (dsPos.Tables[0].Rows.Count > 0)
                    {
                        currentStateName = dsPos.Tables[0].Rows[0]["SchemePosId"].ToString();
                        executedStateName = dsPos.Tables[0].Rows[0]["ReportToPosId"].ToString();
                        break;
                    }
                }
            }

            // Draft
            var currentstate = WorkflowInitMgr.Runtime.GetLocalizedStateName(processId, currentStateName);

            // Controller sighting
            var nextState = WorkflowInitMgr.Runtime.GetLocalizedStateName(processId, executedStateName);

            // Start processing
            var command = WorkflowInitMgr.Runtime.GetLocalizedCommandName(processId, commandName);

            using (var scope = new TransactionScope())
            {
                foreach (Guid uiGuid in identities)
                {
                    // Compose parameters
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    parameters.Add(new SqlParameter("@Id", Guid.NewGuid()));
                    parameters.Add(new SqlParameter("@UserName", GetEmployeesStringList(uiGuid)));
                    parameters.Add(new SqlParameter("@DestinationState", nextState));
                    parameters.Add(new SqlParameter("@ProcessId", processId));
                    parameters.Add(new SqlParameter("@InitialState", currentstate));
                    parameters.Add(new SqlParameter("@Command", command));
                    parameters.Add(new SqlParameter("@UserId", identities));

                    // Get Data 
                    DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_AddDocumentTransitionHistoryByOne", parameters.ToArray());
                }

                scope.Complete();
            }
        }

        #endregion

        #region GetEmployeesStringList : 사용자ID들을 입력받아서 그 사람들의 이름 정보를 가져옴.

        /**********************************************************************************************
         * Mehtod   명 : GetEmployeesStringList
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 사용자ID들을 입력받아서 그 사람들의 이름 정보를 가져옴.
         * Input    값 : GetEmployeesStringList(담당자 Guid)
         * Ouput    값 : 담당자이름
         **********************************************************************************************/
        /// <summary>
        /// GetEmployeesStringList : 사용자ID들을 입력받아서 그 사람들의 이름 정보를 가져옴.
        /// </summary>
        /// <param name="identities">담당자 Guid</param>
        /// <returns>나열된담당자목록</returns>
        private string GetEmployeesStringList(Guid identities)
        {
            var sb = new StringBuilder();

            bool isFirst = true;

            DataTable dtReturn = new DataTable();

            // wfp_GetSigmaUserByUserId
            dtReturn = GetEmployeesString(identities);

            if (dtReturn != null)
            {
                if (dtReturn.Rows.Count > 0)
                {
                    if (!isFirst)
                    {
                        sb.Append(",");
                    }
                    isFirst = false;

                    sb.Append(dtReturn.Rows[0]["FirstName"].ToString() + " " + dtReturn.Rows[0]["LastName"].ToString());
                }
            }

            return sb.ToString();
        }

        #endregion

        #region GetEmployeesString : 사용자ID들을 입력받아서 그 사람들의 이름 정보를 가져옴.

        /**********************************************************************************************
         * Mehtod   명 : GetEmployeesString
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-28
         * 용       도 : 사용자ID들을 입력받아서 그 사람들의 이름 정보를 가져옴.
         * Input    값 : GetEmployeesString(담당자 Guid)
         * Ouput    값 : DataTable
         **********************************************************************************************/
        /// <summary>
        /// GetEmployeesString : 사용자ID들을 입력받아서 그 사람들의 이름 정보를 가져옴.
        /// </summary>
        /// <param name="giUser">담당자 Guid</param>
        /// <returns>담당자정보</returns>
        private DataTable GetEmployeesString(Guid giUser)
        {
            DataTable dtReturn = new DataTable();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UserID", giUser));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserByUserId", parameters.ToArray());

            if (ds != null)
            {
                dtReturn = ds.Tables[0];
            }

            return dtReturn;
        }

        #endregion

        #region UpdateTransitionHistory : 등록된 정보를 바탕으로한 히스토리 수정

        /**********************************************************************************************
         * Mehtod   명 : UpdateTransitionHistory
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 등록된 정보를 바탕으로한 히스토리 수정
         * Input    값 : UpdateTransitionHistory
         * Ouput    값 : void
         **********************************************************************************************/
        /// <summary>
        /// UpdateTransitionHistory : 등록된 정보를 바탕으로한 히스토리 수정
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="currentStateName">현재상태값</param>
        /// <param name="executedStateName">다음상태값</param>
        /// <param name="commandName">명령어</param>
        /// <param name="identityId">담당자리스트</param>
        /// <param name="impersonatedIdentityId">담당자리스트</param>
        /// <param name="comment">비고</param>
        public void UpdateTransitionHistory(Guid processId, string currentStateName, string executedStateName, string commandName, Guid identityId, Guid impersonatedIdentityId, string comment)
        {
            var currentstate = WorkflowInitMgr.Runtime.GetLocalizedStateName(processId, currentStateName);

            var nextState = WorkflowInitMgr.Runtime.GetLocalizedStateName(processId, executedStateName);

            var command = WorkflowInitMgr.Runtime.GetLocalizedCommandName(processId, commandName);

            int Order = 0;

            using (var scope = new TransactionScope())
            {
                // Get connection string
                string connStr = ConnStrHelper.getDbConnString();
                // Compose parameters
                List<SqlParameter> parametersDoc = new List<SqlParameter>();

                parametersDoc.Add(new SqlParameter("@ProcessID", processId));

                // Get Data 
                DataSet dsDoc = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentByDocumentId", parametersDoc.ToArray());

                if (dsDoc.Tables[0] != null)
                {
                    if (dsDoc.Tables[0].Rows.Count > 0)
                    {
                        // DocumentTranscationHistory 테이블에서 현재 설정값 조회
                        // Compose parameters
                        List<SqlParameter> parametersHis = new List<SqlParameter>();

                        parametersHis.Add(new SqlParameter("@ProcessID", processId));
                        parametersHis.Add(new SqlParameter("@InitialState", currentstate));
                        parametersHis.Add(new SqlParameter("@DestinationState", nextState));

                        // Get Data 
                        DataSet dsHis = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentTransitionHistory", parametersHis.ToArray());

                        if (dsHis.Tables[0] != null)
                        {
                            if (dsHis.Tables[0].Rows.Count > 0)
                            {
                                Order = Int32.Parse(dsHis.Tables[0].Rows[0]["Seq"].ToString());
                            }
                            else
                            {
                                // Compose parameters
                                List<SqlParameter> parametersOrd = new List<SqlParameter>();

                                parametersOrd.Add(new SqlParameter("@Id", Guid.NewGuid()));
                                parametersOrd.Add(new SqlParameter("@UserName", ""));
                                parametersOrd.Add(new SqlParameter("@DestinationState", nextState));
                                parametersOrd.Add(new SqlParameter("@ProcessId", processId));
                                parametersOrd.Add(new SqlParameter("@InitialState", currentstate));
                                parametersOrd.Add(new SqlParameter("@Command", command));

                                // Get Data 
                                DataSet dsOrd = SqlHelper.ExecuteDataset(connStr, "wfp_AddDocumentTransitionHistory", parametersOrd.ToArray());

                                if (dsOrd.Tables[0] != null)
                                {
                                    Order = Int32.Parse(dsOrd.Tables[0].Rows[0]["Seq"].ToString());
                                }
                            }
                        }

                        // Compose parameters
                        List<SqlParameter> parametersDTH = new List<SqlParameter>();

                        parametersDTH.Add(new SqlParameter("@ProcessId", processId));
                        parametersDTH.Add(new SqlParameter("@Order", Order));
                        parametersDTH.Add(new SqlParameter("@EmployeeId", identityId));
                        parametersDTH.Add(new SqlParameter("@Command", command));

                        int resultDTH = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyDocumentTransitionHistory", parametersDTH.ToArray());

                        // 같은 Order의 모든 Item이 처리된 경우에만 바뀌어야 함.
                        // Compose parameters
                        List<SqlParameter> parametersDSN = new List<SqlParameter>();

                        parametersDSN.Add(new SqlParameter("@ProcessId", processId));
                        parametersDSN.Add(new SqlParameter("@StateName", nextState));
                        parametersDSN.Add(new SqlParameter("@Order", Order));

                        int resultDSN = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyDocumentStateName", parametersDSN.ToArray());
                    }
                }
                else
                {
                    return;
                }

                scope.Complete();
            }
        }

        #endregion

        #region DeleteEmptyPreHistory : DocumentTransitionHistory 테이블에서 TransitionTime가 없는 Process 삭제

        /**********************************************************************************************
         * Mehtod   명 : DeleteEmptyPreHistory
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : DocumentTransitionHistory 테이블에서 TransitionTime가 없는 Process 삭제
         * Input    값 : DeleteEmptyPreHistory(Guid processId)
         * Ouput    값 : object[]
         **********************************************************************************************/
        /// <summary>
        /// DocumentTransitionHistory 테이블에서 TransitionTime가 없는 Process 삭제
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <returns>object[]</returns>
        internal static void DeleteEmptyPreHistory(Guid processId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessId", processId));

            int resultDSN = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_RemoveDocumentTransitionHistory", parameters.ToArray());
        }

        #endregion
    }
}
