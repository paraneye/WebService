using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Auth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;


namespace Element.Sigma.Web.Biz.Auth
{
    public class AuthMgr
    {

        public SigmaResultType Login(string userId, string passwd)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId), 
                    new SqlParameter("@passwd", passwd)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetLogin", parameters);

            if (ds.Tables[0].Rows.Count == 0)
            {            
                SqlParameter[] checkUserParam = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", userId)
                };

                DataSet userDs = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUser", checkUserParam);
                if (userDs.Tables[0].Rows.Count == 0)
                {
                    // No user exist
                    result.JsonDataSet = "[]";
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                    result.ErrorCode = "AUTH0001";
                    result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0001");
                    return result;
                }
                else
                {
                    // Password is incorrect
                    result.JsonDataSet = "[]";
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                    result.ErrorCode = "AUTH0002";
                    result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0002");
                    return result;
                }
            }

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public static TypeUserInfo GetUserInfo()
        {
            TypeUserInfo userInfo = new TypeUserInfo(); 

            string cookie =  HttpContext.Current.Request.Cookies["logininfo"].Value;
            string userId = string.Empty;
            string companyname = string.Empty;
            int projectId = 0;
            int companyId = 0;

            if (!string.IsNullOrEmpty(cookie))
            {
                TypeUserInfo obj = JsonHelper.JsonDeserialize<TypeUserInfo>(cookie);
                userId = obj.SigmaUserId;
                projectId = obj.CurrentProjectId;
                companyname = obj.CompanyName;
                companyId = obj.CompanyId;
            }
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId) 
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetUserInfoAll", parameters);

            userInfo.SigmaUserId = userId;
            userInfo.CompanyId = companyId;
            userInfo.CompanyName = companyname;
            userInfo.ClientCompanyId = !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ClientCompanyId"].ToString()) ? (int)ds.Tables[0].Rows[0]["ClientCompanyId"] : 0;
            userInfo.CurrentProjectId = projectId; 
            userInfo.CurrentProjectName = !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ProjectName"].ToString()) ? (string)ds.Tables[0].Rows[0]["ProjectName"] : "";
            userInfo.CurrentSigmaRoleId = !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["SigmaRoleId"].ToString()) ? (int)ds.Tables[0].Rows[0]["SigmaRoleId"] : 0;
            userInfo.CurrentSigmaRoleName = !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RoleName"].ToString()) ? (string)ds.Tables[0].Rows[0]["RoleName"] : "";

            return userInfo;
        }

        public SigmaResultType GetUserPermissionForScreenId(string userId, string screenId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId),
                    new SqlParameter("@screenId", screenId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetUserPermissionForScreenId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetUserPermissionByUrl(string userId, string url)
        {
            //throw new NotImplementedException();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId),
                    new SqlParameter("@url", url)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetUserPermissionForUrl", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetScreensByUser(string userId)
        {
            //throw new NotImplementedException();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetScreensByUser", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetProjectListByUser(string userId)
        {
            throw new NotImplementedException();
        }

        public SigmaResultType GetLicense()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@CompanyId", userinfo.CompanyId)
            };
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetLicense", parameters);
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            return result;
        }

        public SigmaResultType ListScreensBySigmaUserId(string sigmaUserId)
        {
            TypeUserInfo userInfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", sigmaUserId),
                    new SqlParameter("@ProjectId", userInfo.CurrentProjectId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListScreenbySigmaUserId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }
    }
}
