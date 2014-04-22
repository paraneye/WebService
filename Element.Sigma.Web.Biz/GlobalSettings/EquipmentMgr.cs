using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;
using System.Linq;
using System.Collections.Specialized;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class EquipmentMgr
    {
        #region Equipment

        public SigmaResultType GetEquipment(string equipmentId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@EquipmentId", Utilities.ToInt32(equipmentId.ToString().Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetEquipment", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListEquipment(NameValueCollection queryParams)
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
            string EquipmentCodeMain = queryParams["EquipmentCodeMain"];
            string EquipmentCodeSub = queryParams["EquipmentCodeSub"];
            string ThirdLevel = queryParams["ThirdLevel"];

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 10 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            parameters.Add(new SqlParameter("@EquipmentCodeMain", EquipmentCodeMain));
            parameters.Add(new SqlParameter("@EquipmentCodeSub", EquipmentCodeSub));
            parameters.Add(new SqlParameter("@ThirdLevel", ThirdLevel));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListEquipment", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddEquipment(TypeEquipment objEquipment)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@EquipmentCodeMain", objEquipment.EquipmentCodeMain.Trim()));
            paramList.Add(new SqlParameter("@EquipmentCodeSub", objEquipment.EquipmentCodeSub.Trim()));
            paramList.Add(new SqlParameter("@Description", objEquipment.Description.Trim()));
            paramList.Add(new SqlParameter("@ThirdLevel", objEquipment.ThirdLevel.Trim()));
            paramList.Add(new SqlParameter("@Spec", objEquipment.Spec.Trim()));
            paramList.Add(new SqlParameter("@EquipmentType", objEquipment.EquipmentType.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            paramList.Add(new SqlParameter("@ModelNumber", objEquipment.ModelNumber.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddEquipment", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateEquipment(TypeEquipment objEquipment)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
				new SqlParameter("@EquipmentId", objEquipment.EquipmentId),
                new SqlParameter("@EquipmentCodeMain", objEquipment.EquipmentCodeMain.Trim()),
				new SqlParameter("@EquipmentCodeSub", objEquipment.EquipmentCodeSub.Trim()),
				new SqlParameter("@ThirdLevel", objEquipment.ThirdLevel.Trim()),
                new SqlParameter("@Description", objEquipment.Description.Trim()),
				new SqlParameter("@Spec", objEquipment.Spec.Trim()),
				new SqlParameter("@EquipmentType", objEquipment.EquipmentType.Trim()),
				new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim()),
                new SqlParameter("@ModelNumber", objEquipment.ModelNumber.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateEquipment", parameters);
                result.IsSuccessful = true;
                
                scope.Complete();
            }

            return result;
        }
        
        public SigmaResultType RemoveEquipment(TypeEquipment objEquipment)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@EquipmentId", Utilities.ToInt32(objEquipment.EquipmentId.ToString().Trim())),
                new SqlParameter("@NewId", SqlDbType.Int)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveEquipment", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiEquipment(List<TypeEquipment> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var affectCount = 0;

                foreach (TypeEquipment item in listObj)
                {
                    switch (item.SigmaOperation)
                    {
                        case SigmaOperation.DELETE:
                            affectCount +=  RemoveEquipment(item).AffectedRow;
                            break;
                    }
                }

                result.AffectedRow = affectCount;
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public DataSet ListMaterialByEquipmentCodeMain(string equipmentCodeMain, string equipmentCodeSub, string thirdLevel, string spec, string equipmentType)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@EquipmentCodeMain", equipmentCodeMain),
                new SqlParameter("@EquipmentCodeSub", equipmentCodeSub),
                new SqlParameter("@ThirdLevel", thirdLevel),
                new SqlParameter("@Spec", spec),
                new SqlParameter("@EquipmentType", equipmentType)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMaterialByEquipmentCodeMain", parameters);

            // return
            return ds;
        }

        public SigmaResultType AddEquipmentInfo(TypeEquipment objEquipment)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType resultEquipment = new SigmaResultType();
            bool isCostomField = true;

            if (objEquipment.CustomField.Count > 0)
            {
                var count = objEquipment.CustomField.Where(p => p.SigmaOperation == "C" && (p.FieldName.Trim() == "" || p.Value.Trim() == "")).Count();
                if (count > 0)
                    isCostomField = false;
            }

            if (!(string.IsNullOrEmpty(objEquipment.EquipmentCodeMain))
                && !(string.IsNullOrEmpty(objEquipment.EquipmentCodeSub))
                && !(string.IsNullOrEmpty(objEquipment.Spec))
            )
            {
                using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objEquipment.SigmaOperation == SigmaOperation.INSERT)
                    {
                        resultEquipment = AddEquipment(objEquipment);
                        objEquipment.CustomField.ForEach(item => item.Parentid = resultEquipment.ScalarValue);
                    }
                    else if (objEquipment.SigmaOperation == SigmaOperation.UPDATE)
                    {
                        resultEquipment = UpdateEquipment(objEquipment);
                        objEquipment.CustomField.ForEach(item => item.Parentid = objEquipment.EquipmentId);
                    }

                    if (resultEquipment.IsSuccessful && objEquipment.CustomField.Count > 0)
                    {
                        foreach (var item in objEquipment.CustomField)
                        {
                            switch (item.SigmaOperation)
                            {
                                case SigmaOperation.INSERT:
                                    AddCustomFieldWithEquipmentCustomField(item);
                                    break;
                                case SigmaOperation.UPDATE:
                                    UpdateCustomFieldWithEquipmentCustomField(item);
                                    break;
                                case SigmaOperation.DELETE:
                                    RemoveCustomFieldWithEquipmentCustomField(item);
                                    break;
                            }
                        }
                    }

                    result.AffectedRow = resultEquipment.AffectedRow;
                    result.ScalarValue = resultEquipment.ScalarValue;
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

        public SigmaResultType AddCustomFieldWithEquipmentCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType customField = new SigmaResultType();
            SigmaResultType EquipmentCustomField = new SigmaResultType();
            TypeEquipmentCustomField typeEquipmentCustomField = new TypeEquipmentCustomField();

            typeEquipmentCustomField.EquipmentId = objCustomField.Parentid;
            typeEquipmentCustomField.Value = objCustomField.Value;
            typeEquipmentCustomField.CreatedBy = userinfo.SigmaUserId;
            typeEquipmentCustomField.UpdatedBy = userinfo.SigmaUserId;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                CustomFieldMgr custom = new CustomFieldMgr();

                customField = custom.AddCustomField(objCustomField);
                typeEquipmentCustomField.CustomFieldId = customField.ScalarValue;
                EquipmentCustomField = AddEquipmentCustomField(typeEquipmentCustomField);

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateCustomFieldWithEquipmentCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType customField = new SigmaResultType();
            SigmaResultType EquipmentCustomField = new SigmaResultType();
            TypeEquipmentCustomField typeEquipmentCustomField = new TypeEquipmentCustomField();

            typeEquipmentCustomField.EquipmentId = objCustomField.Parentid;
            typeEquipmentCustomField.CustomFieldId = objCustomField.CustomFieldId;
            typeEquipmentCustomField.Value = objCustomField.Value;
            typeEquipmentCustomField.CreatedBy = userinfo.SigmaUserId;
            typeEquipmentCustomField.UpdatedBy = userinfo.SigmaUserId;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                CustomFieldMgr custom = new CustomFieldMgr();
                customField = custom.UpdateCustomField(objCustomField);
                EquipmentCustomField = UpdateEquipmentCustomField(typeEquipmentCustomField);

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveCustomFieldWithEquipmentCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType customField = new SigmaResultType();
            SigmaResultType EquipmentCustomField = new SigmaResultType();
            TypeEquipmentCustomField typeEquipmentCustomField = new TypeEquipmentCustomField();

            typeEquipmentCustomField.EquipmentId = objCustomField.Parentid;
            typeEquipmentCustomField.CustomFieldId = objCustomField.CustomFieldId;
            typeEquipmentCustomField.Value = objCustomField.Value;
            typeEquipmentCustomField.CreatedBy = userinfo.SigmaUserId;
            typeEquipmentCustomField.UpdatedBy = userinfo.SigmaUserId;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                EquipmentCustomField = RemoveEquipmentCustomField(typeEquipmentCustomField);
                //customField = RemoveCustomField(objCustomField);

                scope.Complete();
            }

            return result;
        }

        #endregion Equipment

        #region EquipmentCustomField

        //public SigmaResultType GetEquipmentCustomField(string id)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@", id)
        //        };

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetEquipmentCustomField", parameters);

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = 1;
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType ListEquipmentCustomField(string offset, string max, string o_option, string o_desc, string s_option1, string s_option2)
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

        public SigmaResultType AddEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@EquipmentId", Utilities.ToInt32(objEquipmentCustomField.EquipmentId.ToString().Trim())));
            paramList.Add(new SqlParameter("@CustomFieldId", Utilities.ToInt32(objEquipmentCustomField.CustomFieldId.ToString().Trim())));
            paramList.Add(new SqlParameter("@Value", objEquipmentCustomField.Value.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddEquipmentCustomField", paramList.ToArray());
                result.IsSuccessful = true;
                //result.ScalarValue = (int)outParam.Value;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@EquipmentId", Utilities.ToInt32(objEquipmentCustomField.EquipmentId.ToString().Trim())),
                new SqlParameter("@CustomFieldId", Utilities.ToInt32(objEquipmentCustomField.CustomFieldId.ToString().Trim())),
                new SqlParameter("@Value", objEquipmentCustomField.Value.Trim()),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateEquipmentCustomField", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@EquipmentId", Utilities.ToInt32(objEquipmentCustomField.EquipmentId.ToString().Trim())),
                new SqlParameter("@CustomFieldId", Utilities.ToInt32(objEquipmentCustomField.CustomFieldId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveEquipmentCustomField", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        //public SigmaResultType MultiEquipmentCustomField(List<TypeEquipmentCustomField> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {
        //        foreach (TypeEquipmentCustomField anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddEquipmentCustomField(anObj);
        //                    break;
        //                case "U":
        //                    UpdateEquipmentCustomField(anObj);
        //                    break;
        //                case "D":
        //                    RemoveEquipmentCustomField(anObj);
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
