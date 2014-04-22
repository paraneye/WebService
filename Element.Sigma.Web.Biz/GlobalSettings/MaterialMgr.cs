using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;
using System.Linq;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using System.Collections.Specialized;
using System;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class MaterialMgr
    {
        #region Materil

        public SigmaResultType GetMaterial(string materialId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@materialId", materialId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetMaterial", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListMaterial(NameValueCollection queryParams)
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
            string TaskCategoryId = queryParams["TaskCategoryId"];
            string TaskTypeId = queryParams["TaskTypeId"];
            string Description = queryParams["Description"];
            string IsConsumable = queryParams["IsConsumable"];

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 10 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            parameters.Add(new SqlParameter("@DisciplineCode", DisciplineCode));
            parameters.Add(new SqlParameter("@TaskCategoryId", Utilities.ToInt32(TaskCategoryId)));
            parameters.Add(new SqlParameter("@TaskTypeId", Utilities.ToInt32(TaskTypeId)));
            parameters.Add(new SqlParameter("@Description", Description));
            parameters.Add(new SqlParameter("@IsConsumable", IsConsumable));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMaterial", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddMaterial(TypeMaterial objMaterial)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@DisciplineCode", objMaterial.DisciplineCode.Trim()));
            paramList.Add(new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objMaterial.TaskCategoryId.ToString().Trim())));
            paramList.Add(new SqlParameter("@TaskTypeId", Utilities.ToInt32(objMaterial.TaskTypeId.ToString().Trim())));
            paramList.Add(new SqlParameter("@Manhours", objMaterial.Manhours));
            paramList.Add(new SqlParameter("@UomCode", objMaterial.UomCode.Trim()));
            paramList.Add(new SqlParameter("@Vendor", objMaterial.Vendor.Trim()));
            paramList.Add(new SqlParameter("@PartNumber", objMaterial.PartNumber.Trim()));
            paramList.Add(new SqlParameter("@Description", objMaterial.Description.Trim()));
            if (objMaterial.CostCodeId == 0)
            {
                paramList.Add(new SqlParameter("@CostCodeId", DBNull.Value));
            }
            else
            {
                paramList.Add(new SqlParameter("@CostCodeId", Utilities.ToInt32(objMaterial.CostCodeId.ToString().Trim())));
            }
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddMaterial", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateMaterial(TypeMaterial objMaterial)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaterialId", Utilities.ToInt32(objMaterial.MaterialId.ToString().Trim())));
            parameters.Add(    new SqlParameter("@DisciplineCode", objMaterial.DisciplineCode.Trim()));
			parameters.Add(    new SqlParameter("@TaskCategoryId", Utilities.ToInt32(objMaterial.TaskCategoryId.ToString().Trim())));
			parameters.Add(    new SqlParameter("@TaskTypeId", Utilities.ToInt32(objMaterial.TaskTypeId.ToString().Trim())));
			parameters.Add(    new SqlParameter("@Manhours", objMaterial.Manhours));
			parameters.Add(    new SqlParameter("@UomCode", objMaterial.UomCode.Trim()));
			parameters.Add(    new SqlParameter("@Vendor", objMaterial.Vendor.Trim()));
			parameters.Add(    new SqlParameter("@PartNumber", objMaterial.PartNumber.Trim()));
            parameters.Add(    new SqlParameter("@Description", objMaterial.Description.Trim()));
            if(objMaterial.CostCodeId == 0){
                parameters.Add(new SqlParameter("@CostCodeId", DBNull.Value));
            }else{
                parameters.Add(new SqlParameter("@CostCodeId", Utilities.ToInt32(objMaterial.CostCodeId.ToString().Trim())));
            }
			parameters.Add(    new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim()));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateMaterial", parameters.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveMaterial(TypeMaterial objMaterial)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@materialId", Utilities.ToInt32(objMaterial.MaterialId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveMaterial", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiMaterial(List<TypeMaterial> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var affectCount = 0;

                foreach (TypeMaterial item in listObj)
                {
                    switch (item.SigmaOperation)
                    {
                        case SigmaOperation.DELETE:
                            affectCount += RemoveMaterial(item).AffectedRow;
                            break;
                    }
                }

                result.AffectedRow = affectCount;
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public DataSet ListMaterialByDisciplineTaskCategory(string disciplineCode, string taskCategoryId, string taskTypeId, string description, string uomCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DisciplineCode", disciplineCode),
                new SqlParameter("@TaskCategoryId", taskCategoryId),
                new SqlParameter("@TaskTypeId", taskTypeId),
                new SqlParameter("@Description", description),
                new SqlParameter("@UomCode", uomCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMaterialByDisciplineTaskCategory", parameters);

            // return
            return ds;
        }

        public DataSet ListMaterialByVendorPartNumber(string vendor, string description, string partNumber, string uomCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Vendor", vendor),
                new SqlParameter("@Description", description),
                new SqlParameter("@PartNumber", partNumber),
                new SqlParameter("@UomCode", uomCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMaterialByVendorPartNumber", parameters);

            // return
            return ds;
        }

        public SigmaResultType AddMaterialInfo(TypeMaterial objMaterial)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType resultMaterial = new SigmaResultType();
            bool isValidation = false;
            bool isCostomField = true;

            if(objMaterial.CustomField.Count > 0)
            {
                var count = objMaterial.CustomField.Where(p => p.SigmaOperation == "C" && (p.FieldName.Trim() == "" || p.Value.Trim() == "")).Count(); 
                if (count > 0)
                    isCostomField = false;
            }

            if (!(string.IsNullOrEmpty(objMaterial.DisciplineCode))
                && !(string.IsNullOrEmpty(objMaterial.Description))
                && !(string.IsNullOrEmpty(objMaterial.UomCode))
                && Utilities.ToInt32((objMaterial.TaskCategoryId.ToString().Trim())) > 0
                && Utilities.ToInt32((objMaterial.TaskTypeId.ToString().Trim())) > 0
                && objMaterial.Manhours >= 0
                && isCostomField
            )
                isValidation = true;

            if (isValidation)
            {
                using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objMaterial.SigmaOperation == SigmaOperation.INSERT)
                    {
                        resultMaterial = AddMaterial(objMaterial);
                        objMaterial.CustomField.ForEach(item => item.Parentid = resultMaterial.ScalarValue);
                    }
                    else if (objMaterial.SigmaOperation == SigmaOperation.UPDATE)
                    {
                        resultMaterial = UpdateMaterial(objMaterial);
                        objMaterial.CustomField.ForEach(item => item.Parentid = objMaterial.MaterialId);
                    }

                    if (resultMaterial.IsSuccessful && objMaterial.CustomField.Count > 0)
                    {
                        foreach (var item in objMaterial.CustomField)
                        {
                            switch (item.SigmaOperation)
                            {
                                case SigmaOperation.INSERT:
                                    AddCustomFieldWithMaterialCustomField(item);
                                    break;
                                case SigmaOperation.UPDATE:
                                    UpdateCustomFieldWithMaterialCustomField(item);
                                    break;
                                case SigmaOperation.DELETE:
                                    RemoveCustomFieldWithMaterialCustomField(item);
                                    break;
                            }
                        }
                    }

                    result.AffectedRow = resultMaterial.AffectedRow;
                    result.ScalarValue = resultMaterial.ScalarValue;
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

        public SigmaResultType AddCustomFieldWithMaterialCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType customField = new SigmaResultType();
            SigmaResultType materialCustomField = new SigmaResultType();
            TypeMaterialCustomField typeMaterialCustomField = new TypeMaterialCustomField();

            typeMaterialCustomField.MaterialId = objCustomField.Parentid;
            typeMaterialCustomField.Value = objCustomField.Value;
            typeMaterialCustomField.CreatedBy = userinfo.SigmaUserId;
            typeMaterialCustomField.UpdatedBy = userinfo.SigmaUserId;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                CustomFieldMgr custom = new CustomFieldMgr();

                customField = custom.AddCustomField(objCustomField);
                typeMaterialCustomField.CustomFieldId = customField.ScalarValue;
                materialCustomField = AddMaterialCustomField(typeMaterialCustomField);

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateCustomFieldWithMaterialCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType customField = new SigmaResultType();
            SigmaResultType materialCustomField = new SigmaResultType();
            TypeMaterialCustomField typeMaterialCustomField = new TypeMaterialCustomField();

            typeMaterialCustomField.MaterialId = objCustomField.Parentid;
            typeMaterialCustomField.CustomFieldId = objCustomField.CustomFieldId;
            typeMaterialCustomField.Value = objCustomField.Value;
            typeMaterialCustomField.CreatedBy = userinfo.SigmaUserId;
            typeMaterialCustomField.UpdatedBy = userinfo.SigmaUserId;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                CustomFieldMgr custom = new CustomFieldMgr();
                customField = custom.UpdateCustomField(objCustomField);
                materialCustomField = UpdateMaterialCustomField(typeMaterialCustomField);
                
                scope.Complete();
            }
            
            return result;
        }

        public SigmaResultType RemoveCustomFieldWithMaterialCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType customField = new SigmaResultType();
            SigmaResultType materialCustomField = new SigmaResultType();
            TypeMaterialCustomField typeMaterialCustomField = new TypeMaterialCustomField();

            typeMaterialCustomField.MaterialId = objCustomField.Parentid;
            typeMaterialCustomField.CustomFieldId = objCustomField.CustomFieldId;
            typeMaterialCustomField.Value = objCustomField.Value;
            typeMaterialCustomField.CreatedBy = userinfo.SigmaUserId;
            typeMaterialCustomField.UpdatedBy = userinfo.SigmaUserId;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                materialCustomField = RemoveMaterialCustomField(typeMaterialCustomField);
                //customField = RemoveCustomField(objCustomField);
             
                scope.Complete();
            }

            return result;
        }

        #endregion 

        #region MaterialCustomField

        //public SigmaResultType GetMaterialCustomField(string id)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@", id)
        //        };

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetMaterialCustomField", parameters);

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = 1;
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType ListMaterialCustomField(string offset, string max, string o_option, string o_desc, string s_option1, string s_option2)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 50 : int.Parse(max))));
        //    parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
        //    parameters.Add(new SqlParameter("@SortColumn", o_option));
        //    parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            
        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCompany", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0];
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaterialId", Utilities.ToInt32(objMaterialCustomField.MaterialId.ToString().Trim())));
            paramList.Add(new SqlParameter("@CustomFieldId", Utilities.ToInt32(objMaterialCustomField.CustomFieldId.ToString().Trim())));
            paramList.Add(new SqlParameter("@Value", objMaterialCustomField.Value.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddMaterialCustomField", paramList.ToArray());
                result.IsSuccessful = true;
                //result.ScalarValue = (int)outParam.Value;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaterialId", Utilities.ToInt32(objMaterialCustomField.MaterialId.ToString().Trim())),
                new SqlParameter("@CustomFieldId", Utilities.ToInt32(objMaterialCustomField.CustomFieldId.ToString().Trim())),
                new SqlParameter("@Value", objMaterialCustomField.Value.Trim()),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateMaterialCustomField", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaterialId", Utilities.ToInt32(objMaterialCustomField.MaterialId.ToString().Trim())),
                new SqlParameter("@CustomFieldId", Utilities.ToInt32(objMaterialCustomField.CustomFieldId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveMaterialCustomField", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        //public SigmaResultType MultiMaterialCustomField(List<TypeMaterialCustomField> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {
        //        foreach (TypeMaterialCustomField anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddMaterialCustomField(anObj);
        //                    break;
        //                case "U":
        //                    UpdateMaterialCustomField(anObj);
        //                    break;
        //                case "D":
        //                    RemoveMaterialCustomField(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    return result;
        //}

        #endregion
              

    }
}
