using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;
using System.Linq;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.TrueTask;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using System.Collections.Specialized;
using System;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class ProgressTypeMgr
    {
        #region Progress Type

        public SigmaResultType GetProgressType(string progressTypeId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProgressTypeId", Utilities.ToInt32(progressTypeId.Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressType", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListProgressType(NameValueCollection queryParams)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            string max = queryParams["max"];
            string offset = queryParams["offset"];
            string o_option = queryParams["o_option"];
            string o_desc = queryParams["o_desc"];
            string DisciplineCode = queryParams["DisciplineCode"];

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 10 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            parameters.Add(new SqlParameter("@DisciplineCode", DisciplineCode));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProgressType", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddProgressType(TypeProgressType objProgressType)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", objProgressType.Name.Trim()));
            paramList.Add(new SqlParameter("@Description", objProgressType.Description.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProgressType", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateProgressType(TypeProgressType objProgressType)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProgressTypeId", Utilities.ToInt32(objProgressType.ProgressTypeId.ToString().Trim())),
                new SqlParameter("@Name", objProgressType.Name.Trim()),
                new SqlParameter("@Description", objProgressType.Description.Trim()),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProgressType", parameters);
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveProgressType(TypeProgressType objProgressType)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProgressTypeId", Utilities.ToInt32(objProgressType.ProgressTypeId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProgressType", parameters);
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiProgressType(List<TypeProgressType> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var affectCount = 0;

                foreach (TypeProgressType item in listObj)
                {
                    switch (item.SigmaOperation)
                    {
                        case SigmaOperation.DELETE:
                            affectCount += RemoveProgressType(item).AffectedRow;
                            break;
                    }
                }
                result.AffectedRow = affectCount;
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType AddProgressTypeInfo(TypeProgressType objProgressType)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType resultProgressType = new SigmaResultType();
            bool isProgressStep = true;

            if (objProgressType.ProgressStep.Count > 0)
            {
                var failCount = objProgressType.ProgressStep.Where(p => p.SigmaOperation == "C" && (p.Name.Trim() == "" || p.Weight <= 0)).Count();
                if (failCount > 0)
                    isProgressStep = false;

                var stepWeightSum = (from d in objProgressType.ProgressStep where d.SigmaOperation == SigmaOperation.INSERT || d.SigmaOperation == SigmaOperation.UPDATE select d.Weight).Sum();
                if (stepWeightSum != 100)
                    isProgressStep = false;
            }
            else if (objProgressType.ProgressStep.Count == 0)
            {
                isProgressStep = false;
            }

            if (!(string.IsNullOrEmpty(objProgressType.Name))
                && !(string.IsNullOrEmpty(objProgressType.Description))
                && isProgressStep
            )
            {
                using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objProgressType.SigmaOperation == SigmaOperation.INSERT)
                    {
                        resultProgressType = AddProgressType(objProgressType);
                        objProgressType.ProgressStep.ForEach(item => item.ProgressTypeId = resultProgressType.ScalarValue);
                    }
                    else if (objProgressType.SigmaOperation == SigmaOperation.UPDATE)
                    {
                        resultProgressType = UpdateProgressType(objProgressType);
                        objProgressType.ProgressStep.ForEach(item => item.ProgressTypeId = objProgressType.ProgressTypeId);
                    }

                    if (resultProgressType.IsSuccessful && objProgressType.ProgressStep.Count > 0)
                    {
                        foreach (var item in objProgressType.ProgressStep)
                        {
                            switch (item.SigmaOperation)
                            {
                                case SigmaOperation.INSERT:
                                    AddProgressStep(item);
                                    break;
                                case SigmaOperation.UPDATE:
                                    UpdateProgressStep(item);
                                    break;
                                case SigmaOperation.DELETE:
                                    RemoveProgressStep(item);
                                    break;
                            }
                        }
                    }

                    result.AffectedRow = resultProgressType.AffectedRow;
                    result.ScalarValue = resultProgressType.ScalarValue;
                    result.IsSuccessful = true;

                    scope.Complete();
                }
            }
            else
            {
                result.AffectedRow = -1;
                result.ErrorCode = "GlobalSetting0001";
                result.ErrorMessage = "Validation";
                result.IsSuccessful = false;
            }

            return result;
        }

        public SigmaResultType ListProgressTypeByTaskCateogry(string taskCategoryId, string taskTypeId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskCategoryId", Utilities.ToInt32(taskCategoryId.Trim())),
                new SqlParameter("@TaskTypeId", Utilities.ToInt32(taskTypeId.Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressTypeByTaskCateogry", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //public SigmaResultType AddProgressStep(TypeProgressStep objProgressStep)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();
        //    //SigmaResultType progressStep = new SigmaResultType();
        //    //SigmaResultType materialprogressStep = new SigmaResultType();
        //    TypeProgressStep typeProgressStep = new TypeProgressStep();

        //    typeProgressStep.MaterialId = objProgressStep.Parentid;
        //    typeProgressStep.Value = objProgressStep.Value;
        //    typeProgressStep.CreatedBy = objProgressStep.CreatedBy;
        //    typeProgressStep.UpdatedBy = objProgressStep.UpdatedBy;

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        ProgressStepMgr custom = new ProgressStepMgr();

        //        progressStep = custom.AddprogressStep(objProgressStep);
        //        typeProgressStep.progressStepId = progressStep.ScalarValue;
        //        materialprogressStep = AddMaterialprogressStep(typeProgressStep);

        //        scope.Complete();
        //    }

        //    return result;
        //}

        //public SigmaResultType UpdateProgressStep(TypeProgressStep objProgressStep)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();
        //    SigmaResultType progressStep = new SigmaResultType();
        //    SigmaResultType materialprogressStep = new SigmaResultType();
        //    TypeProgressStep TypeProgressStep = new TypeProgressStep();

        //    TypeProgressStep.MaterialId = objProgressStep.Parentid;
        //    TypeProgressStep.progressStepId = objProgressStep.progressStepId;
        //    TypeProgressStep.Value = objProgressStep.Value;
        //    TypeProgressStep.CreatedBy = objProgressStep.CreatedBy;
        //    TypeProgressStep.UpdatedBy = objProgressStep.UpdatedBy;

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        progressStepMgr custom = new progressStepMgr();
        //        progressStep = custom.UpdateprogressStep(objProgressStep);
        //        materialprogressStep = UpdateMaterialprogressStep(TypeProgressStep);

        //        scope.Complete();
        //    }

        //    return result;
        //}

        //public SigmaResultType RemoveProgressStep(TypeProgressStep objProgressStep)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();
        //    SigmaResultType progressStep = new SigmaResultType();
        //    SigmaResultType materialprogressStep = new SigmaResultType();
        //    TypeProgressStep TypeProgressStep = new TypeProgressStep();

        //    TypeProgressStep.MaterialId = objProgressStep.Parentid;
        //    TypeProgressStep.progressStepId = objProgressStep.progressStepId;
        //    TypeProgressStep.Value = objProgressStep.Value;
        //    TypeProgressStep.CreatedBy = objProgressStep.CreatedBy;
        //    TypeProgressStep.UpdatedBy = objProgressStep.UpdatedBy;

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        materialprogressStep = RemoveMaterialprogressStep(TypeProgressStep);
        //        //progressStep = RemoveprogressStep(objProgressStep);

        //        scope.Complete();
        //    }

        //    return result;
        //}

        #endregion Progress Type

        #region Progress Step

        public SigmaResultType GetProgressStepByProgessTypeId(string progressTypeId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProgressStepId", Utilities.ToInt32(progressTypeId.Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressStepByProgressTypeId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddProgressStep(TypeProgressStep objProgressStep)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProgressTypeId", Utilities.ToInt32(objProgressStep.ProgressTypeId.ToString().Trim())));
            paramList.Add(new SqlParameter("@Name", objProgressStep.Name.Trim()));
            paramList.Add(new SqlParameter("@IsMultipliable", objProgressStep.IsMultipliable.Trim()));
            paramList.Add(new SqlParameter("@Weight", Utilities.ToInt32(objProgressStep.Weight.ToString().Trim())));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProgressStep", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateProgressStep(TypeProgressStep objProgressStep)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProgressStepId", Utilities.ToInt32(objProgressStep.ProgressStepId.ToString().Trim())),
                new SqlParameter("@ProgressTypeId", Utilities.ToInt32(objProgressStep.ProgressTypeId.ToString().Trim())),
                new SqlParameter("@Name", objProgressStep.Name.Trim()),
                new SqlParameter("@IsMultipliable", objProgressStep.IsMultipliable.Trim()),
                new SqlParameter("@Weight", Utilities.ToInt32(objProgressStep.Weight.ToString().Trim())),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProgressStep", parameters);
                result.IsSuccessful = true;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveProgressStep(TypeProgressStep objProgressStep)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProgressStepId", Utilities.ToInt32(objProgressStep.ProgressStepId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProgressStep", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        #endregion Progress Step

        #region ProgressTypeMap

        //public SigmaResultType GetProgressTypeMap(string progressTypeMapId)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@ProgressTypeMapId", progressTypeMapId)
        //        };

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressTypeMap", parameters);

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = 1;
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType ListProgressTypeMap(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProgressTypeMap", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddProgressTypeMap(TypeProgressTypeMap objProgressTypeMap)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DisciplineCode", objProgressTypeMap.DisciplineCode.Trim()));
            paramList.Add(new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objProgressTypeMap.TaskCategoryId.ToString().Trim())));
            if (objProgressTypeMap.TaskTypeId > 0)
            {
                paramList.Add(new SqlParameter("@TaskTypeId", Utilities.ToInt32(objProgressTypeMap.TaskTypeId.ToString().Trim())));
            }
            else
            {
                paramList.Add(new SqlParameter("@TaskTypeId", DBNull.Value));
            }
            paramList.Add(new SqlParameter("@ProgressTypeId", Utilities.ToInt32(objProgressTypeMap.ProgressTypeId.ToString().Trim())));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProgressTypeMap", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateProgressTypeMap(TypeProgressTypeMap objProgressTypeMap)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProgressTypeMapId", Utilities.ToInt32(objProgressTypeMap.ProgressTypeMapId.ToString().Trim())),
                new SqlParameter("@DisciplineCode", objProgressTypeMap.DisciplineCode.Trim()),
				new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objProgressTypeMap.TaskCategoryId.ToString().Trim())),
				new SqlParameter("@TaskTypeId", Utilities.ToInt32(objProgressTypeMap.TaskTypeId.ToString().Trim())),
				new SqlParameter("@ProgressTypeId", Utilities.ToInt32(objProgressTypeMap.ProgressTypeId.ToString().Trim())),
				new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProgressTypeMap", parameters);
                result.IsSuccessful = true;
             
                scope.Complete();
            }

            return result;
        }

        //public SigmaResultType RemoveProgressTypeMap(TypeProgressTypeMap objProgressTypeMap)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    TransactionScope scope = null;

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@ProgressTypeMapId", objProgressTypeMap.ProgressTypeMapId)
        //        };


        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProgressTypeMap", parameters);
        //        result.IsSuccessful = true;
        //        scope.Complete();
        //    }

        //    return result;
        //}

        //public SigmaResultType MultiProgressTypeMap(List<TypeProgressTypeMap> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {

        //        foreach (TypeProgressTypeMap anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddProgressTypeMap(anObj);
        //                    break;
        //                case "U":
        //                    UpdateProgressTypeMap(anObj);
        //                    break;
        //                case "D":
        //                    RemoveProgressTypeMap(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    return result;
        //}

        public SigmaResultType AddProgressTypeMapInfo(TypeProgressTypeMap objProgressTypeMap)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataSet taskTypeDataSet = null;
            List<TypeProgressTypeMap> progressTypeMapList = new List<TypeProgressTypeMap>(); ;
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType resultProgressTypeMap = new SigmaResultType();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                if (objProgressTypeMap.SigmaOperation == SigmaOperation.INSERT)
                {
                    resultProgressTypeMap = AddProgressTypeMap(objProgressTypeMap);
                    taskTypeDataSet = ListTaskType(objProgressTypeMap);

                    foreach (DataRow item in taskTypeDataSet.Tables[0].Rows)
                    {
                        TypeProgressTypeMap progressTypeMap = new TypeProgressTypeMap();
                        progressTypeMap.DisciplineCode = objProgressTypeMap.DisciplineCode;
                        progressTypeMap.TaskCategoryId = objProgressTypeMap.TaskCategoryId;
                        progressTypeMap.TaskTypeId = int.Parse(item["TaskTypeId"].ToString());
                        progressTypeMap.ProgressTypeId = objProgressTypeMap.ProgressTypeId;
                        progressTypeMap.CreatedBy = userinfo.SigmaUserId;
                        progressTypeMap.UpdatedBy = userinfo.SigmaUserId;
                        progressTypeMapList.Add(progressTypeMap);
                    }
                }
                else if (objProgressTypeMap.SigmaOperation == SigmaOperation.UPDATE)
                {
                    resultProgressTypeMap = UpdateProgressTypeMap(objProgressTypeMap);
                    taskTypeDataSet = ListTaskType(objProgressTypeMap);

                    foreach (DataRow item in taskTypeDataSet.Tables[0].Rows)
                    {
                        TypeProgressTypeMap progressTypeMap = new TypeProgressTypeMap();
                        progressTypeMap.SigmaOperation = SigmaOperation.INSERT;
                        progressTypeMap.DisciplineCode = objProgressTypeMap.DisciplineCode;
                        progressTypeMap.TaskCategoryId = objProgressTypeMap.TaskCategoryId;
                        progressTypeMap.TaskTypeId = int.Parse(item["TaskTypeId"].ToString());
                        progressTypeMap.ProgressTypeId = objProgressTypeMap.ProgressTypeId;
                        progressTypeMap.CreatedBy = userinfo.SigmaUserId;
                        progressTypeMap.UpdatedBy = userinfo.SigmaUserId;
                        progressTypeMapList.Add(progressTypeMap);
                    }
                }

                if (resultProgressTypeMap.IsSuccessful && progressTypeMapList.Count > 0)
                {
                    foreach (var item in progressTypeMapList)
                    {
                        switch (item.SigmaOperation)
                        {
                            case SigmaOperation.INSERT:
                                AddProgressTypeMap(item);
                                break;
                            case SigmaOperation.UPDATE:
                                UpdateProgressTypeMap(item);
                                break;
                        }
                    }
                }

                result.AffectedRow = resultProgressTypeMap.AffectedRow;
                result.ScalarValue = resultProgressTypeMap.ScalarValue;
                result.IsSuccessful = true;

                scope.Complete();
            }
            return result;
        }

        public DataSet ListTaskType(TypeProgressTypeMap objProgressTypeMap)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objProgressTypeMap.TaskCategoryId.ToString().Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListTaskTypeNotAssignProgressTypeMap", parameters);

            // return
            return ds;
        }

        public SigmaResultType GetProgressTypeMapByDisciplineCode(string taskCategoryId, string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskCategoryId", Utilities.ToInt32(taskCategoryId.Trim())),
                new SqlParameter("@DisciplineCode", disciplineCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressTypeMapByDisciplineCode", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion ProgressType Map
    }
}
