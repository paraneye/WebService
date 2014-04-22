using System.Data.SqlClient;
using System.Data;

using Element.Shared.Common;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class EquipmentCustomFieldMgr
    {
        #region EquipmentCustomField

        public SigmaResultType GetEquipmentCustomFieldWithCustomField(string materialId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaterialId", materialId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetEquipmentCustomFieldWithCustomField", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //public SigmaResultType GetEquipmentCustomField(string id)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //        new SqlParameter("@", id)
        //    };

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetEquipmentCustomField", parameters);

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = 1;
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType ListEquipmentCustomField(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListEquipmentCustomField", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType AddEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    paramList.Add(new SqlParameter("@EquipmentId", objEquipmentCustomField.EquipmentId));
        //    paramList.Add(new SqlParameter("@CustomFieldId", objEquipmentCustomField.CustomFieldId));
        //    paramList.Add(new SqlParameter("@Value", objEquipmentCustomField.Value));
        //    paramList.Add(new SqlParameter("@CreatedBy", objEquipmentCustomField.CreatedBy));
        //    SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
        //    outParam.Direction = ParameterDirection.Output;
        //    paramList.Add(outParam);

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddEquipmentCustomField", paramList.ToArray());
        //        result.IsSuccessful = true;
        //        result.ScalarValue = (int)outParam.Value;
            
        //        scope.Complete();
        //    }

        //    return result;
        //}

        //public SigmaResultType UpdateEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //        new SqlParameter("@EquipmentId", objEquipmentCustomField.EquipmentId),
        //        new SqlParameter("@CustomFieldId", objEquipmentCustomField.CustomFieldId),
        //        new SqlParameter("@Value", objEquipmentCustomField.Value),
        //        new SqlParameter("@CreatedBy", objEquipmentCustomField.CreatedBy),
        //        new SqlParameter("@UpdatedBy", objEquipmentCustomField.UpdatedBy),
        //    };

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateEquipmentCustomField", parameters);
        //        result.IsSuccessful = true;
                
        //        scope.Complete();
        //    }

        //    return result;
        //}
        //public SigmaResultType RemoveEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    TransactionScope scope = null;

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //        new SqlParameter("@", objEquipmentCustomField.CustomFieldId)
        //    };

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveEquipmentCustomField", parameters);
        //        result.IsSuccessful = true;
                
        //        scope.Complete();
        //    }

        //    return result;
        //}
		
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

        #endregion EquipmentCustomField
    }
}
