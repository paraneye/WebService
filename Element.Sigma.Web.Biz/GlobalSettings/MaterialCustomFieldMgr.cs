using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.IO;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class MaterialCustomFieldMgr
    {
        public SigmaResultType GetMaterialCustomFieldWithCustomField(string materialId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaterialId", materialId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetMaterialCustomFieldWithCustomField", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
			result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        ///// <summary>
        ///// Data > ImportMTO > 
        ///// </summary>
        ///// <param name="objMaterialCustomField"></param>
        ///// <returns></returns>
        //public SigmaResultType AddMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();
        //    string connStr = ConnStrHelper.getDbConnString();

        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    paramList.Add(new SqlParameter("@MaterialId", objMaterialCustomField.MaterialId));
        //    paramList.Add(new SqlParameter("@CustomFieldId", objMaterialCustomField.CustomFieldId));
        //    paramList.Add(new SqlParameter("@Value", objMaterialCustomField.Value));
        //    paramList.Add(new SqlParameter("@CreatedBy", objMaterialCustomField.CreatedBy));

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddMaterialCustomField", paramList.ToArray());
        //        result.IsSuccessful = true;
        //        result.ScalarValue = 1; //MaterialCustomField table에는 PK가 없기에 @NewId 필요 없음
        //        scope.Complete();

        //    }

        //    return result;
        //}

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

        //public SigmaResultType ListMaterialCustomField(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMaterialCustomField", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}
       
        //public SigmaResultType UpdateMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@MaterialId", objMaterialCustomField.MaterialId),
        //            new SqlParameter("@CustomFieldId", objMaterialCustomField.CustomFieldId),
        //            new SqlParameter("@Value", objMaterialCustomField.Value),
        //            new SqlParameter("@CreatedBy", objMaterialCustomField.CreatedBy),
        //            new SqlParameter("@UpdatedBy", objMaterialCustomField.UpdatedBy),
        //        };

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateMaterialCustomField", parameters);
        //        result.IsSuccessful = true;
        //        scope.Complete();

        //    }

        //    return result;
        //}

        //public SigmaResultType RemoveMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    TransactionScope scope = null;

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@", objMaterialCustomField.)
        //        };

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveMaterialCustomField", parameters);
        //        result.IsSuccessful = true;
        //        scope.Complete();
        //    }

        //    return result;
        //}
		
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

        public DataSet ListMaterialCustomFieldByFieldName(string fieldName)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@FieldName", fieldName)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMaterialCustomFieldByFieldName", parameters);

            // return
            return ds;
        }

    }
}
