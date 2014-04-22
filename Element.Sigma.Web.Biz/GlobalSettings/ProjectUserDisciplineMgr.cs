using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.ProjectSettings;
using System.Transactions;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class ProjectUserDisciplineMgr
    {
        public SigmaResultType GetProjectUserDiscipline(string projectId, string sigmaUserId, string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ProjectId", projectId));
            paramList.Add(new SqlParameter("@SigmaUserId", sigmaUserId));
            paramList.Add(new SqlParameter("@DisciplineCode", disciplineCode));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProjectUserDiscipline", paramList.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListProjectUserDiscipline(NameValueCollection queryParams)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();


            string max = queryParams["max"];
            string offset = queryParams["offset"];
            string o_option = queryParams["o_option"];
            string o_desc = queryParams["o_desc"];

            paramList.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            paramList.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            paramList.Add(new SqlParameter("@SortColumn", o_option));
            paramList.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProjectUserDiscipline", paramList.ToArray());

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
                //result.ScalarValue = (int)outParam.Value;
                
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType UpdateProjectUserDiscipline(TypeProjectUserDiscipline objProjectUserDiscipline)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));
            paramList.Add(new SqlParameter("@SigmaUserId", objProjectUserDiscipline.SigmaUserId));
            paramList.Add(new SqlParameter("@DisciplineCode", objProjectUserDiscipline.DisciplineCode));
            paramList.Add(new SqlParameter("@IsDefault", objProjectUserDiscipline.IsDefault));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProjectUserDiscipline", paramList.ToArray());
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
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));
            paramList.Add(new SqlParameter("@SigmaUserId", objProjectUserDiscipline.SigmaUserId));
            paramList.Add(new SqlParameter("@DisciplineCode", objProjectUserDiscipline.DisciplineCode));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProjectUserDiscipline", paramList.ToArray());
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
                        case "U":
                            UpdateProjectUserDiscipline(anObj);
                            break;
                        case "D":
                            RemoveProjectUserDiscipline(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            result.IsSuccessful = true;

            return result;
        }

        public SigmaResultType RemoveProjectUserDisciplineByProjectInfo(int projcetId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ProjectId", projcetId));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProjectUserDisciplineByProjectInfo", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

    }
}
