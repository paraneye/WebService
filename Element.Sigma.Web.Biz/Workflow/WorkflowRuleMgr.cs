using Element.Shared.Common;

using OptimaJet.Workflow.Core.Runtime;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Element.Sigma.Web.Biz.Workflow
{
    public class WorkflowRuleMgr : IWorkflowRuleProvider
    {
        private Dictionary<string, Func<Guid, Guid, bool>> _funcs = new Dictionary<string, Func<Guid, Guid, bool>>();
        private Dictionary<string, Func<Guid, IEnumerable<Guid>>> _getIdentitiesFuncs = new Dictionary<string, Func<Guid, IEnumerable<Guid>>>();

        public WorkflowRuleMgr()
        {
            _funcs.Add("IsDocumentAuthor", IsDocumentAuthor);
            _funcs.Add("IsAuthorsBoss", IsAuthorsBoss);
            _funcs.Add("IsDocumentController", IsDocumentController);
            _getIdentitiesFuncs.Add("IsDocumentAuthor", GetDocumentAuthor);
            _getIdentitiesFuncs.Add("IsDocumentController", GetDocumentController);
            _getIdentitiesFuncs.Add("IsAuthorsBoss", GetAuthorsBoss);
        }

        #region IsDocumentAuthor : Process의 작성자가 맞는지 조회

        /**********************************************************************************************
         * Mehtod   명 : IsDocumentAuthor
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : Process의 작성자가 맞는지 조회
         * Input    값 : IsDocumentAuthor(작성한 Process GuID, 작성자 GuID)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// IsDocumentAuthor : Process의 작성자가 맞는지 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="identityId">작성자 GuID</param>
        /// <returns>bool</returns>
        private bool IsDocumentAuthor(Guid processId, Guid identityId)
        {
            bool isOk = false;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));
            parameters.Add(new SqlParameter("@AuthorID", identityId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentByAuthor", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    isOk = true;
                }
            }

            return isOk;
        }

        #endregion

        #region IsAuthorsBoss : 해당ID가 Process를 작성한 User의 상사인지 확인

        /**********************************************************************************************
         * Mehtod   명 : IsAuthorsBoss
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 해당ID가 Process를 작성한 User의 상사인지 확인
         * Input    값 : IsAuthorsBoss(작성한 Process GuID, 조회대상 GuID)
         * Ouput    값 : Bool
         **********************************************************************************************/
        /// <summary>
        /// IsAuthorsBoss : 해당ID가 Process를 작성한 User의 상사인지 확인
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="identityId">조회대상 GuID</param>
        /// <returns>bool</returns>
        private bool IsAuthorsBoss(Guid processId, Guid identityId)
        {
            bool isReturn = false;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));
            parameters.Add(new SqlParameter("@BossID", identityId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentAuthorBoss", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    isReturn = true;
                }
            }

            return isReturn;
        }

        #endregion

        #region IsDocumentController : Process의 관리자가 맞는지 조회

        /**********************************************************************************************
         * Mehtod   명 : IsDocumentController
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : Process의 관리자가 맞는지 조회
         * Input    값 : IsDocumentController(작성한 Process GuID, 관리자 GuID)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// IsDocumentController : Process의 관리자가 맞는지 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="identityId">관리자 GuID</param>
        /// <returns>bool</returns>
        private bool IsDocumentController(Guid processId, Guid identityId)
        {
            bool isOk = false;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));
            parameters.Add(new SqlParameter("@HeaderID", identityId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentByEmloyeeControlerId", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    isOk = true;
                }
            }

            return isOk;
        }

        #endregion

        #region GetDocumentAuthor :  Process의 작성자 조회

        /**********************************************************************************************
         * Mehtod   명 : GetDocumentAuthor
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-13
         * 용       도 : Process의 작성자 조회
         * Input    값 : GetDocumentAuthor(작성한 Process GuID)
         * Ouput    값 : 작성자 목록
         **********************************************************************************************/
        /// <summary>
        /// Process의 작성자ID 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <returns>작성자 목록</returns>
        private IEnumerable<Guid> GetDocumentAuthor(Guid processId)
        {
            List<Guid> lstGidREturn = new List<Guid>();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentAuthor", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Select())
                    {
                        Guid uiAuthorId = new Guid(dr["AuthorId"].ToString());

                        lstGidREturn.Add(uiAuthorId);
                    }
                }
                else
                {
                    return new List<Guid> { };
                }
            }
            else
            {
                return new List<Guid> { };
            }

            return lstGidREturn;
        }

        #endregion

        #region GetDocumentController : Process의 1차보고자 조회

        /**********************************************************************************************
         * Mehtod   명 : GetDocumentController
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : Process의 1차보고자 조회
         * Input    값 : GetDocumentController(작성한 Process GuID)
         * Ouput    값 : 1차보고자 목록
         **********************************************************************************************/
        /// <summary>
        /// GetDocumentController : Process의 1차보고자 조회
        /// </summary>
        /// <param name="processId">작성한 Process</param>
        /// <returns>관리자ID</returns>
        private IEnumerable<Guid> GetDocumentController(Guid processId)
        {
            List<Guid> lstGidREturn = new List<Guid>();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetUpperController", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Select())
                    {
                        Guid uiHeader = new Guid(dr["SigmaUserGuid"].ToString());

                        lstGidREturn.Add(uiHeader);
                    }
                }
                else
                {
                    return new List<Guid> { };
                }
            }
            else
            {
                return new List<Guid> { };
            }

            return lstGidREturn;
        }

        #endregion

        #region GetAuthorsBoss : Process를 작성한 User의 상사ID 조회

        /**********************************************************************************************
         * Mehtod   명 : GetAuthorsBoss
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : Process를 작성한 User의 상사ID 조회
         * Input    값 : GetAuthorsBoss(작성한 Process GuID)
         * Ouput    값 : 상사ID 목록
         **********************************************************************************************/
        /// <summary>
        /// GetAuthorsBoss : Process를 작성한 User의 상사ID 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <returns>상사ID 목록</returns>
        private IEnumerable<Guid> GetAuthorsBoss(Guid processId)
        {
            List<Guid> lstGidREturn = new List<Guid>();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProcessID", processId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaHeadUserList", parameters.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Select())
                    {
                        Guid uiHeader = new Guid(dr["SigmaHeadUserGuId"].ToString());

                        lstGidREturn.Add(uiHeader);
                    }
                }
            }

            return lstGidREturn;
        }

        #endregion

        #region CheckRule : 해당 ID가 Process의 Rule에 부합한지 조회

        /**********************************************************************************************
         * Mehtod   명 : CheckRule
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 해당 ID가 Process의 Rule에 부합한지 조회
         * Input    값 : CheckRule(작성한 Process GuID, 조회대상ID, rule이름)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// 해당 ID가 Process의 Rule에 부합한지 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="identityId">조회대상ID</param>
        /// <param name="ruleName">rule이름</param>
        /// <returns>bool</returns>
        public bool CheckRule(Guid processId, Guid identityId, string ruleName)
        {
            return _funcs.ContainsKey(ruleName) && _funcs[ruleName].Invoke(processId, identityId);
        }

        #endregion

        #region CheckRule : 해당 ID가 Process의 Rule에 부합한지 조회

        /**********************************************************************************************
         * Mehtod   명 : CheckRule
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 해당 ID가 Process의 Rule에 부합한지 조회
         * Input    값 : CheckRule(작성한 Process GuID, 조회대상ID, rule이름, 처리할매개변수)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// 해당 ID가 Process의 Rule에 부합한지 조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="identityId">조회대상ID</param>
        /// <param name="ruleName">rule이름</param>
        /// <param name="parameters">매개변수</param>
        /// <returns>bool</returns>
        public bool CheckRule(Guid processId, Guid identityId, string ruleName, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GetIdentitiesForRule : 해당 Process의 Rule에 맞는 ID조회

        /**********************************************************************************************
         * Mehtod   명 : GetIdentitiesForRule
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 해당 Process의 Rule에 맞는 ID조회
         * Input    값 : GetIdentitiesForRule(작성한 Process GuID, rule이름)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// GetIdentitiesForRule : 해당 Process의 Rule에 맞는 ID조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="ruleName">rule이름</param>
        /// <returns>bool</returns>
        public IEnumerable<Guid> GetIdentitiesForRule(Guid processId, string ruleName)
        {
            return !_getIdentitiesFuncs.ContainsKey(ruleName) ? new List<Guid> { } : _getIdentitiesFuncs[ruleName].Invoke(processId);
        }

        #endregion

        #region GetIdentitiesForRule : 해당 Process의 Rule에 맞는 ID조회

        /**********************************************************************************************
         * Mehtod   명 : GetIdentitiesForRule
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 해당 Process의 Rule에 맞는 ID조회
         * Input    값 : GetIdentitiesForRule(작성한 Process GuID, rule이름, 처리할매개변수)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// GetIdentitiesForRule : 해당 Process의 Rule에 맞는 ID조회
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <param name="ruleName">rule이름</param>
        /// <param name="parameters">처리할매개변수</param>
        /// <returns>bool</returns>
        public IEnumerable<Guid> GetIdentitiesForRule(Guid processId, string ruleName, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
