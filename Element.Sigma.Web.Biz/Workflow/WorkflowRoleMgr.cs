using Element.Shared.Common;

using OptimaJet.Workflow.Core.Runtime;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Element.Sigma.Web.Biz.Workflow
{
    public class WorkflowRoleMgr : IWorkflowRoleProvider
    {
        #region IsInRole : ID와 Role 코드가 존재하는지 체크

        /**********************************************************************************************
         * Mehtod   명 : IsInRole
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : ID와 Role 코드가 존재하는지 체크
         * Input    값 : IsInRole(User의 Guid, Role의 id)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// IsInRole : ID와 Role 코드가 존재하는지 체크
        /// </summary>
        /// <param name="identityId">User의 Guid</param>
        /// <param name="roleId">Role의 id</param>
        /// <returns>bool</returns>
        public bool IsInRole(Guid identityId, string roleId)
        {
            bool isReturn = false;

            Guid giRoleId = new Guid(roleId);

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UserID", identityId));
            parameters.Add(new SqlParameter("@RoleID", giRoleId));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserByRoleNUserId", parameters.ToArray());

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

        #region GetAllInRole : 해당 Role을 가지고 있는 직원의 ID 목록 리턴

        /**********************************************************************************************
         * Mehtod   명 : GetAllInRole
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 해당 Role을 가지고 있는 직원의 ID 목록 리턴
         * Input    값 : GetAllInRole(User의 Guid, Role의 id)
         * Ouput    값 : bool
         **********************************************************************************************/
        /// <summary>
        /// GetAllInRole : 해당 Role을 가지고 있는 직원의 ID 목록 리턴
        /// </summary>
        /// <param name="roleId">Role 코드</param>
        /// <returns>대상자ID 목록</returns>
        public IEnumerable<Guid> GetAllInRole(string roleId)
        {
            List<Guid> lstGidREturn = new List<Guid>();

            Guid giRoleId = new Guid(roleId);

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@RoleID", giRoleId));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserByRoleId", parameters.ToArray());

            foreach (DataRow dr in ds.Tables[0].Select())
            {
                Guid idTemp = new Guid();
                idTemp = new Guid(dr["SigmaUserGuid"].ToString());

                lstGidREturn.Add(idTemp);
            }

            return lstGidREturn;
        }

        #endregion
    }
}
