using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectSettings;

namespace Element.Sigma.Web.Biz.ProjectSettings

{
    public class ProjectMgr
    {
        #region Project

        public SigmaResultType GetProject(string projectId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", projectId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProject", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //public SigmaResultType ListProject(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    List<SqlParameter> parameters = new List<SqlParameter>();


        //    parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
        //    parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

        //    parameters.Add(new SqlParameter("@SortColumn", o_option));
        //    parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProject", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddProject(TypeProject objProject)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectName", objProject.ProjectName));
            paramList.Add(new SqlParameter("@ProjectNumber", objProject.ProjectNumber));
            paramList.Add(new SqlParameter("@ProjectDescription", objProject.ProjectDescription));
            paramList.Add(new SqlParameter("@CompanyId", userinfo.CompanyId));
            paramList.Add(new SqlParameter("@CountryName", objProject.CountryName));
            paramList.Add(new SqlParameter("@CountyName", objProject.CountyName));
            paramList.Add(new SqlParameter("@CityName", objProject.CityName));
            paramList.Add(new SqlParameter("@LogoFilePath", objProject.LogoFilePath));
            paramList.Add(new SqlParameter("@ClientCompanyId", objProject.ClientCompanyId));
            paramList.Add(new SqlParameter("@ClientProjectId", objProject.ClientProjectId));
            paramList.Add(new SqlParameter("@ClientProjectName", objProject.ClientProjectName));
            paramList.Add(new SqlParameter("@IsActive", objProject.IsActive));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProject", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateProject(TypeProject objProject)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            
            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
				new SqlParameter("@ProjectId", objProject.ProjectId),
                new SqlParameter("@ProjectName", objProject.ProjectName),
				new SqlParameter("@ProjectNumber", objProject.ProjectNumber),
				new SqlParameter("@ProjectDescription", objProject.ProjectDescription),
				new SqlParameter("@CompanyId", objProject.CompanyId),
				new SqlParameter("@CountryName", objProject.CountryName),
				new SqlParameter("@CountyName", objProject.CountyName),
				new SqlParameter("@CityName", objProject.CityName),
				new SqlParameter("@LogoFilePath", objProject.LogoFilePath),
				new SqlParameter("@ClientCompanyId", objProject.ClientCompanyId),
				new SqlParameter("@ClientProjectId", objProject.ClientProjectId),
				new SqlParameter("@ClientProjectName", objProject.ClientProjectName),
                new SqlParameter("@IsActive", objProject.IsActive),
				new SqlParameter("@UpdatedBy", userinfo.SigmaUserId)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProject", parameters);
                result.IsSuccessful = true;
             
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveProject(TypeProject objProject)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", objProject.ProjectId)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProject", parameters);
                result.IsSuccessful = true;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType CloseOpenProject(TypeProject objProject)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;
            bool isAuthentication = true;

            // Project Closed
            if (objProject.IsActive.ToUpper().Equals("N"))
            {
                if (userinfo.SigmaUserId.ToUpper().Equals("ADMIN"))
                {
                    isAuthentication = true;
                }
                else
                {
                    isAuthentication = false;
                }
            }

            if (isAuthentication)
            {
                // Get connection string
                string connStr = ConnStrHelper.getDbConnString();

                // Compose parameters
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", objProject.ProjectId),
                    new SqlParameter("@IsActive", objProject.IsActive),
                    new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
                };

                using (scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_CloseOpenProject", parameters);
                    result.IsSuccessful = true;

                    scope.Complete();
                }
            }
            else
            {
                result.AffectedRow = -1;
                result.ErrorCode = "GlobalSetting0001";
                result.ErrorMessage = "Authentication";
                result.IsSuccessful = false;
            }

            return result;
        }

        //public SigmaResultType MultiProject(List<TypeProject> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {

        //        foreach (TypeProject anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddProject(anObj);
        //                    break;
        //                case "U":
        //                    UpdateProject(anObj);
        //                    break;
        //                case "D":
        //                    RemoveProject(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    return result;
        //}

        public SigmaResultType AddProjectInfo(TypeProject objProject)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType resultProject = new SigmaResultType();
            
            bool isDiscipline = true;
            bool isAuthentication = true;

            // Project Closed
            if (objProject.IsActive.ToUpper().Equals("N"))
            {
                if (userinfo.SigmaUserId.ToUpper().Equals("ADMIN"))
                {
                    isAuthentication = true;
                }
                else
                {
                    isAuthentication = false;
                }
            }

            if (objProject.ProjectDiscipline.Count == 0)
            {
                isDiscipline = false;
            }

            if (!(string.IsNullOrEmpty(objProject.ProjectName))
                && !(string.IsNullOrEmpty(objProject.ProjectNumber))
                && !(string.IsNullOrEmpty(objProject.ProjectManagerId))
                //&& !(string.IsNullOrEmpty(objProject.ClientCompanyId))
                && !(string.IsNullOrEmpty(objProject.ClientProjectId))
                && !(string.IsNullOrEmpty(objProject.ClientProjectName))
                && isDiscipline
                && isAuthentication
            )
            {
                using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objProject.SigmaOperation == SigmaOperation.INSERT)
                    {
                        resultProject = AddProject(objProject);
                        objProject.ProjectId = resultProject.ScalarValue;
                        objProject.ProjectDiscipline.ForEach(item => item.ProjectId = objProject.ProjectId);
                        objProject.ProjectSubcontractor.ForEach(item => item.ProjectId = objProject.ProjectId);
                    }
                    else if (objProject.SigmaOperation == SigmaOperation.UPDATE)
                    {
                        resultProject = UpdateProject(objProject);
                        objProject.ProjectDiscipline.ForEach(item => item.ProjectId = objProject.ProjectId);
                        objProject.ProjectSubcontractor.ForEach(item => item.ProjectId = objProject.ProjectId);

                        // Delete ProjectDiscipline && ProjectSubcontractor
                        if (resultProject.IsSuccessful)
                        {
                            RemoveProjectDiscipline(objProject);
                            RemoveProjectSubcontractor(objProject);
                        }
                    }

                    if (resultProject.IsSuccessful)
                    {
                        // ProjectDiscipline
                        if (objProject.ProjectDiscipline.Count > 0)
                        {
                            foreach (var item in objProject.ProjectDiscipline)
                            {
                                switch (item.SigmaOperation)
                                {
                                    case SigmaOperation.INSERT:
                                        AddProjectDiscipline(item);
                                        break;
                                }
                            }
                        }

                        // ProjectSubcontractor
                        if (objProject.ProjectSubcontractor.Count > 0)
                        {
                            foreach (var item in objProject.ProjectSubcontractor)
                            {
                                switch (item.SigmaOperation)
                                {
                                    case SigmaOperation.INSERT:
                                        AddProjectSubcontractor(item);
                                        break;
                                }
                            }
                        }

                        // Project Manager
                        #region Project Manager
                        if (!(string.IsNullOrEmpty(objProject.ProjectManagerId.ToString())))
                        {
                            SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                            SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();
                            ProjectUserDisciplineMgr projectUserDisciplineMgr = new ProjectUserDisciplineMgr();
                            TypeSigmaUserSigmaRole userRole = new TypeSigmaUserSigmaRole();
                            TypeProjectUserDiscipline userDiscipline = new TypeProjectUserDiscipline();

                            DataSet sigmaRoleDataSet = null;
                            DataSet sigmaUserSigmaRoleDataSet = null;

                            // Get SigmaRoleId
                            sigmaRoleDataSet = sigmaRoleMgr.GetSigmaRoleByName("Project Manager");
                            var sigmaRole = sigmaRoleDataSet.Tables[0].Rows[0]["SigmaRoleId"];

                            // Get SigmaUserSigmaRole
                            //sigmaUserSigmaRole = projectUserDisciplineMgr.

                            // Set SigmaUserSigmaRole
                            userRole.SigmaRoleId = int.Parse(sigmaRole.ToString());
                            userRole.SigmaUserId = objProject.ProjectManagerId;
                            userRole.ProjectId = objProject.ProjectId;
                            userRole.CreatedBy = userinfo.SigmaUserId;

                            if (objProject.SigmaOperation == SigmaOperation.INSERT)
                            {
                                sigmaUserMgr.AddSigmaUserSigmaRoleForProject(userRole);

                                // ProjectUserDiscipline
                                if (objProject.ProjectDiscipline.Count > 0)
                                {
                                    foreach (var item in objProject.ProjectDiscipline)
                                    {
                                        TypeProjectUserDiscipline projectUserDiscipline = new TypeProjectUserDiscipline();

                                        projectUserDiscipline.ProjectId = objProject.ProjectId;
                                        projectUserDiscipline.SigmaUserId = objProject.ProjectManagerId;
                                        projectUserDiscipline.DisciplineCode = item.DisciplineCode;

                                        switch (item.SigmaOperation)
                                        {
                                            case SigmaOperation.INSERT:
                                                projectUserDisciplineMgr.AddProjectUserDiscipline(projectUserDiscipline);
                                                break;
                                        }
                                    }
                                }
                            }

                            if (objProject.SigmaOperation == SigmaOperation.UPDATE)
                            {
                                //sigmaUserSigmaRoleDataSet = sigmaUserMgr.GetSigmaUserSigmaRoleBySigmaRoleId(objProject.ProjectId, int.Parse(sigmaRole.ToString()));
                                //var sigmaUserSigmaRole = sigmaUserSigmaRoleDataSet.Tables[0].Rows[0]["SigmaUserId"];

                                // 1. SigmaUserSigmaRole Delete
                                sigmaUserMgr.RemoveSigmaUserSigmaRoleByProjectId(userRole);
                                // 2. SigmaUserSigmaRole Insert
                                sigmaUserMgr.AddSigmaUserSigmaRole(userRole);

                                // 3. ProjectUserDiscipline Delete
                                userDiscipline.ProjectId = objProject.ProjectId;
                                userDiscipline.SigmaUserId = userRole.SigmaUserId;
                                userDiscipline.DisciplineCode = "ALL";
                                projectUserDisciplineMgr.RemoveProjectUserDiscipline(userDiscipline);

                                // 4. ProjectUserDiscipline Insert
                                foreach (var item in objProject.ProjectDiscipline)
                                {
                                    TypeProjectUserDiscipline projectUserDiscipline = new TypeProjectUserDiscipline();

                                    projectUserDiscipline.ProjectId = objProject.ProjectId;
                                    projectUserDiscipline.SigmaUserId = objProject.ProjectManagerId;
                                    projectUserDiscipline.DisciplineCode = item.DisciplineCode;

                                    switch (item.SigmaOperation)
                                    {
                                        case SigmaOperation.INSERT:
                                            projectUserDisciplineMgr.AddProjectUserDiscipline(projectUserDiscipline);
                                            break;
                                    }
                                }

                                // 5. ProjectUserDiscipline Delete(except ProjectManager)
                                projectUserDisciplineMgr.RemoveProjectUserDisciplineByProjectInfo(objProject.ProjectId);
                            }
                        }

                        #endregion Project Manager
                    }

                    result.AffectedRow = resultProject.AffectedRow;
                    result.ScalarValue = resultProject.ScalarValue;
                    result.IsSuccessful = true;

                    scope.Complete();
                }
            }
            else
            {
                result.AffectedRow = -1;
                result.ErrorCode = "ProjectSetting0001";
                result.ErrorMessage = "Validation";
                result.IsSuccessful = false;
            }

            return result;
        }

        #endregion Project

        #region ProjectDiscipline

        public SigmaResultType GetProjectDiscipline(string projectId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", projectId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProjectDiscipline", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //public SigmaResultType ListProjectDiscipline(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    List<SqlParameter> parameters = new List<SqlParameter>();
			            
        //    parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
        //    parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
        //    parameters.Add(new SqlParameter("@SortColumn", o_option));
        //    parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProjectDiscipline", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddProjectDiscipline(TypeProjectDiscipline objProjectDiscipline)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectId", objProjectDiscipline.ProjectId));
            paramList.Add(new SqlParameter("@DisciplineCode", objProjectDiscipline.DisciplineCode));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProjectDiscipline", paramList.ToArray());
                result.IsSuccessful = true;
                //result.ScalarValue = (int)outParam.Value;

                scope.Complete();
            }

            return result;
        }

        //public SigmaResultType UpdateProjectDiscipline(TypeProjectDiscipline objProjectDiscipline)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@ProjectId", objProjectDiscipline.ProjectId),
        //            new SqlParameter("@DisciplineCode", objProjectDiscipline.DisciplineCode),
        //            new SqlParameter("@CreatedBy", objProjectDiscipline.CreatedBy),
        //            new SqlParameter("@UpdatedBy", objProjectDiscipline.UpdatedBy),
        //        };

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProjectDiscipline", parameters);
        //        result.IsSuccessful = true;
        //        scope.Complete();

        //    }

        //    return result;
        //}

        public SigmaResultType RemoveProjectDiscipline(TypeProject objProject)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", objProject.ProjectId)
            };
            
            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProjectDiscipline", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
		
        //public SigmaResultType MultiProjectDiscipline(List<TypeProjectDiscipline> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {

        //        foreach (TypeProjectDiscipline anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddProjectDiscipline(anObj);
        //                    break;
        //                case "U":
        //                    UpdateProjectDiscipline(anObj);
        //                    break;
        //                case "D":
        //                    RemoveProjectDiscipline(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    return result;
        //}

        #endregion ProjectDiscipline

        #region ProjectSubcontractor

        public SigmaResultType GetProjectSubcontractor(string projectId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", projectId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProjectSubcontractor", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //public SigmaResultType ListProjectSubcontractor(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    List<SqlParameter> parameters = new List<SqlParameter>();

			            
        //    parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
        //    parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

        //    parameters.Add(new SqlParameter("@SortColumn", o_option));
        //    parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProjectSubcontractor", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddProjectSubcontractor(TypeProjectSubcontractor objProjectSubcontractor)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectId", objProjectSubcontractor.ProjectId));
            paramList.Add(new SqlParameter("@CompanyId", objProjectSubcontractor.CompanyId));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProjectSubcontractor", paramList.ToArray());
                result.IsSuccessful = true;
                //result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }

        //public SigmaResultType UpdateProjectSubcontractor(TypeProjectSubcontractor objProjectSubcontractor)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@ProjectId", objProjectSubcontractor.ProjectId),
        //            new SqlParameter("@CompanyId", objProjectSubcontractor.CompanyId),
        //            new SqlParameter("@CreatedBy", objProjectSubcontractor.CreatedBy),
        //            new SqlParameter("@UpdatedBy", objProjectSubcontractor.UpdatedBy),
        //        };

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProjectSubcontractor", parameters);
        //        result.IsSuccessful = true;
        //        scope.Complete();

        //    }

        //    return result;
        //}

        public SigmaResultType RemoveProjectSubcontractor(TypeProject objProject)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", objProject.ProjectId)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProjectSubcontractor", parameters);
                result.IsSuccessful = true;
                
                scope.Complete();
            }

            return result;
        }
		
        //public SigmaResultType MultiProjectSubcontractor(List<TypeProjectSubcontractor> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {

        //        foreach (TypeProjectSubcontractor anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddProjectSubcontractor(anObj);
        //                    break;
        //                case "U":
        //                    UpdateProjectSubcontractor(anObj);
        //                    break;
        //                case "D":
        //                    RemoveProjectSubcontractor(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    return result;
        //}

        #endregion ProjectSubcontractor

    }
}
