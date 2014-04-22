using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Text.RegularExpressions;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class TaskCategoryMgr
    {
        #region TaskCategory

        //public SigmaResultType GetTaskCategory(string taskCategoryId)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@TaskCategoryId", taskCategoryId)
        //        };

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetTaskCategory", parameters);

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = 1;
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType ListTaskCategory(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListTaskCategory", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddTaskCategory(TypeTaskCategory objTaskCategory)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get TaskCode
            objTaskCategory.TaskCategoryCode = GetTaskCode(objTaskCategory.DisciplineCode, objTaskCategory.TaskCategoryName);

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DisciplineCode", objTaskCategory.DisciplineCode.Trim()));
            paramList.Add(new SqlParameter("@TaskCategoryCode", objTaskCategory.TaskCategoryCode.Trim()));
            paramList.Add(new SqlParameter("@TaskCategoryName", objTaskCategory.TaskCategoryName.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddTaskCategory", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
             
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateTaskCategory(TypeTaskCategory objTaskCategory)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objTaskCategory.TaskCategoryId.ToString().Trim())),
                new SqlParameter("@TaskCategoryName", objTaskCategory.TaskCategoryName.Trim()),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateTaskCategory", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveTaskCategory(TypeTaskCategory objTaskCategory)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objTaskCategory.TaskCategoryId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveTaskCategory", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        //public SigmaResultType MultiTaskCategory(List<TypeTaskCategory> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {

        //        foreach (TypeTaskCategory anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddTaskCategory(anObj);
        //                    break;
        //                case "U":
        //                    UpdateTaskCategory(anObj);
        //                    break;
        //                case "D":
        //                    RemoveTaskCategory(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    return result;
        //}

        public SigmaResultType ListTaskCategoryWithTaskType()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListTaskCategoryWithTaskType", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        public DataSet ListTaskCategoryByDisciplineCode(string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DisciplineCode", disciplineCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListTaskCategoryByDisciplineCode", parameters);

            // return
            return ds;
        }

        public string GetTaskCode(string disciplineCode, string taskName)
        {
            string taskCode = "";
            string codeName;
            codeName = taskName.Replace(" ", "_").ToUpper();
            codeName = Regex.Replace(codeName, @"[^a-zA-Z0-9_]", "", RegexOptions.Singleline);

            // Set TaskCode
            switch (disciplineCode)
            {
                case "DISCIPLINE_CIVIL":
                    taskCode = PrefixDiscipline.DISCIPLINE_CIVIL + "_" + codeName;
                    break;
                case "DISCIPLINE_ELECTRICAL":
                    taskCode = PrefixDiscipline.DISCIPLINE_ELECTRICAL + "_" + codeName;
                    break;
                case "DISCIPLINE_INSTRUMENTATION":
                    taskCode = PrefixDiscipline.DISCIPLINE_INSTRUMENTATION + "_" + codeName;
                    break;
                case "DISCIPLINE_INSULATION":
                    taskCode = PrefixDiscipline.DISCIPLINE_INSULATION + "_" + codeName;
                    break;
                case "DISCIPLINE_MECHANICAL":
                    taskCode = PrefixDiscipline.DISCIPLINE_MECHANICAL + "_" + codeName;
                    break;
                case "DISCIPLINE_PIPING":
                    taskCode = PrefixDiscipline.DISCIPLINE_PIPING + "_" + codeName;
                    break;
                case "DISCIPLINE_RFID":
                    taskCode = PrefixDiscipline.DISCIPLINE_RFID + "_" + codeName;
                    break;
                case "DISCIPLINE_SCAFFOLD":
                    taskCode = PrefixDiscipline.DISCIPLINE_SCAFFOLD + "_" + codeName;
                    break;
                case "DISCIPLINE_STEEL":
                    taskCode = PrefixDiscipline.DISCIPLINE_STEEL + "_" + codeName;
                    break;
            }

            return taskCode;
        }

        #endregion TaskCategory

        #region TaskType

        //public SigmaResultType GetTaskType(string taskTypeId)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@TaskTypeId", taskTypeId)
        //        };

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetTaskType", parameters);

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = 1;
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType ListTaskType(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListTaskType", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddTaskType(TypeTaskType objTaskType)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get TaskCode
            objTaskType.TaskTypeCode = GetTaskCode(objTaskType.DisciplineCode, objTaskType.TaskTypeName);
            objTaskType.TaskTypeShortName = objTaskType.TaskTypeName;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objTaskType.TaskCategoryId.ToString().Trim())));
            paramList.Add(new SqlParameter("@TaskTypeCode", objTaskType.TaskTypeCode.Trim()));
            paramList.Add(new SqlParameter("@TaskTypeShortName", objTaskType.TaskTypeShortName.Trim()));
            paramList.Add(new SqlParameter("@TaskTypeName", objTaskType.TaskTypeName.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddTaskType", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType UpdateTaskType(TypeTaskType objTaskType)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            objTaskType.TaskTypeShortName = objTaskType.TaskTypeName;

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskTypeId", Utilities.ToInt32(objTaskType.TaskTypeId.ToString().Trim())),
                new SqlParameter("@TaskTypeShortName", objTaskType.TaskTypeShortName.Trim()),
                new SqlParameter("@TaskTypeName", objTaskType.TaskTypeName.Trim()),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateTaskType", parameters);
                result.IsSuccessful = true;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveTaskType(TypeTaskType objTaskType)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskTypeId", Utilities.ToInt32(objTaskType.TaskTypeId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveTaskType", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        //public SigmaResultType MultiTaskType(List<TypeTaskType> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {

        //        foreach (TypeTaskType anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddTaskType(anObj);
        //                    break;
        //                case "U":
        //                    UpdateTaskType(anObj);
        //                    break;
        //                case "D":
        //                    RemoveTaskType(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    return result;
        //}

        public DataSet ListTaskTypeByDisciplineCode(string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DisciplineCode", disciplineCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListTaskTypeByDisciplineCode", parameters);

            // return
            return ds;
        }

        #endregion TaskType
    }
}
