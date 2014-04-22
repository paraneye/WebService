using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using System.Xml.Linq;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class PermissionMgr
    {
        public SigmaResultType ListSigmaRoleSigmaJob(string sigmaRoleId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SigmaRoleId", sigmaRoleId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaRoleSigmaJob", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaRoleSigmaJobForInit()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaJobForPermission", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddSigmaRoleSigmaJob(TypeSigmaRoleSigmaJob objSigmaRoleSigmaJob)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaRoleSigmaJob.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaJobId", objSigmaRoleSigmaJob.SigmaJobId));
            paramList.Add(new SqlParameter("@SigmaRoleId", objSigmaRoleSigmaJob.SigmaRoleId));
            paramList.Add(new SqlParameter("@CreatedBy", objSigmaRoleSigmaJob.CreatedBy));


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaRoleSigmaJob", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType MultiSigmaRoleSigmaJob(TypeSigmaRole listObj)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            listObj.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            if(listObj.SigmaRoleId != null)
                RemoveSigmaRoleSigmaJob(listObj.SigmaRoleId);

            int sigmaRoleId = listObj.SigmaRoleId;

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();

                
                switch (listObj.SigmaOperation)
                {
                    case "C":
                        result = sigmaRoleMgr.AddSigmaRole(listObj);
                        sigmaRoleId = result.ScalarValue;
                        break;
                    case "U":
                        result = sigmaRoleMgr.UpdateSigmaRole(listObj);
                        break;
                }

                if (result.IsSuccessful)
                {

                    listObj.typeSigmaRoleSigmaJob.ForEach(x => x.CreatedBy = userinfo.SigmaUserId);
                    listObj.typeSigmaRoleSigmaJob.ForEach(x => x.SigmaRoleId = sigmaRoleId);

                    foreach (TypeSigmaRoleSigmaJob anObj in listObj.typeSigmaRoleSigmaJob)
                    {
                        AddSigmaRoleSigmaJob(anObj);
                    }
                    result.IsSuccessful = true;
                    scope.Complete();
                }
            }

            return result;
        }

        public SigmaResultType MultiPermissionReport(List<TypeSigmaRoleSigmaJob> listObj)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            listObj.ForEach(x => x.CreatedBy = userinfo.SigmaUserId);

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            RemoveSigmaRoleSigmaJob(0);
            
            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeSigmaRoleSigmaJob anObj in listObj)
                {
                    AddSigmaRoleSigmaJob(anObj);
                }
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveSigmaRoleSigmaJob(int sigmaRoleId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@SigmaRoleId", sigmaRoleId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaRoleSigmaJobBySigmaRole", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

    }
}
