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
using Element.Sigma.Web.Biz.Types.ProjectSettings;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using System.Xml.Linq;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;

namespace Element.Sigma.Web.Biz.ProjectData
{
    public class MemberMgr
    {
        #region SigmaUserSigmaRole

        public SigmaResultType GetSigmaUserSigmaRole(string sigmaUserId)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", sigmaUserId),
                    new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUserSigmaRoleByPtojectId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetSigmaRoleBySigmaUser(List<string> s_option, List<string> s_key)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < s_option.Count; i++)
            {
                parameters.Add(new SqlParameter(s_option[i], s_key[i]));
            }

            // Compose parameters
            parameters.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetHierarchy", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaUserSigmaRole()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaUserSigmaRoleByProjectId", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUserSigmaRole.ProjectId = userinfo.CurrentProjectId;
            objSigmaUserSigmaRole.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaRoleId", objSigmaUserSigmaRole.SigmaRoleId));
            paramList.Add(new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId));
            paramList.Add(new SqlParameter("@ReportTo", objSigmaUserSigmaRole.ReportTo));
            paramList.Add(new SqlParameter("@ReportToRole", objSigmaUserSigmaRole.ReportToRole));
            paramList.Add(new SqlParameter("@IsDefault", objSigmaUserSigmaRole.IsDefault));
            paramList.Add(new SqlParameter("@ProjectId", objSigmaUserSigmaRole.ProjectId));
            paramList.Add(new SqlParameter("@CreatedBy", objSigmaUserSigmaRole.CreatedBy));


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaUserSigmaRole", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }


        public SigmaResultType UpdateSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUserSigmaRole.ProjectId = userinfo.CurrentProjectId;
            objSigmaUserSigmaRole.CreatedBy = userinfo.SigmaUserId;
            objSigmaUserSigmaRole.UpdatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaRoleId", objSigmaUserSigmaRole.SigmaRoleId),
                    new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId),
					new SqlParameter("@ReportTo", objSigmaUserSigmaRole.ReportTo),
					new SqlParameter("@ReportToRole", objSigmaUserSigmaRole.ReportToRole),
					new SqlParameter("@IsDefault", objSigmaUserSigmaRole.IsDefault),
					new SqlParameter("@ProjectId", objSigmaUserSigmaRole.ProjectId),
					new SqlParameter("@CreatedBy", objSigmaUserSigmaRole.CreatedBy)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaUserSigmaRole", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaUserSigmaRole", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiSigmaUserSigmaRole(List<TypeSigmaUserSigmaRole> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeSigmaUserSigmaRole anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddSigmaUserSigmaRole(anObj);
                            break;
                        case "U":
                            UpdateSigmaUserSigmaRole(anObj);
                            break;
                        case "D":
                            RemoveSigmaUserSigmaRole(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }

        #endregion

        #region ProjectUserDiscipline

        public SigmaResultType GetProjectUserDiscipline(string sigmaUserId)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", userinfo.CurrentProjectId),
                    new SqlParameter("@SigmaUserId", sigmaUserId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProjectUserDiscipline", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListProjectUserDiscipline(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProjectUserDiscipline", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddProjectUserDiscipline(TypeProjectUserDiscipline objProjectUserDiscipline)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objProjectUserDiscipline.ProjectId = userinfo.CurrentProjectId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectId", objProjectUserDiscipline.ProjectId));
            paramList.Add(new SqlParameter("@SigmaUserId", objProjectUserDiscipline.SigmaUserId));
            paramList.Add(new SqlParameter("@DisciplineCode", objProjectUserDiscipline.DisciplineCode));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProjectUserDiscipline", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveProjectUserDiscipline(TypeProjectUserDiscipline objProjectUserDiscipline)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DisciplineCode", objProjectUserDiscipline.DisciplineCode)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProjectUserDiscipline", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType MultiProjectUserDiscipline(List<TypeProjectUserDiscipline> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeProjectUserDiscipline anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddProjectUserDiscipline(anObj);
                            break;
                        case "D":
                            RemoveProjectUserDiscipline(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }
        #region Member

        public SigmaResultType MultiMember(TypeMember clsObj)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                string sigmaUserId = string.Empty;
                if (clsObj.typeProjectUserDiscipline.Count > 0)
                    sigmaUserId = clsObj.typeProjectUserDiscipline[0].SigmaUserId;
                else if (clsObj.typeSigmaUserSigmaRole.Count > 0)
                    sigmaUserId = clsObj.typeSigmaUserSigmaRole[0].SigmaUserId;

                if (!string.IsNullOrEmpty(sigmaUserId))
                    RemoveMember(sigmaUserId);

                foreach (TypeProjectUserDiscipline anObj in clsObj.typeProjectUserDiscipline)
                {
                    if(anObj.SigmaOperation != "D")
                        AddProjectUserDiscipline(anObj);
                }
                foreach (TypeSigmaUserSigmaRole anObj in clsObj.typeSigmaUserSigmaRole)
                {
                    if (anObj.SigmaOperation != "D")
                        AddSigmaUserSigmaRole(anObj);
                }

                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveMember(string sigmaUserId)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@SigmaUserId", sigmaUserId),
                 new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveMemberBySigmaUser", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiHierarchy(List<TypeSigmaUserSigmaRole> listObj)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                RemoveHierarchy();

                foreach (TypeSigmaUserSigmaRole anObj in listObj)
                {
                    AddSigmaUserSigmaRole(anObj);
                }

                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveHierarchy()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                 new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveHierarchy", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType ListMember(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

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
            parameters.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMember", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }


        public SigmaResultType ListRoleHierarchy()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListRoleHierarchy", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }
        

        #endregion

        #endregion
    }
}
