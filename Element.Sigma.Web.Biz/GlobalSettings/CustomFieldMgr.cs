using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class CustomFieldMgr
    {
        #region CustomField

        public SigmaResultType GetCustomField(string customFieldId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@customFieldId", customFieldId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCustomField", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListCustomField(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCompany", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0];
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FieldType", (Utilities.ToInt32(objCustomField.Value) == 0 ? "STRING" : "INTEGER" )));
            paramList.Add(new SqlParameter("@FieldName", objCustomField.FieldName));
            paramList.Add(new SqlParameter("@IsDisplayable", objCustomField.IsDisplayable));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            paramList.Add(new SqlParameter("@DisciplineCode", objCustomField.DisciplineCode));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddCustomField", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CustomFieldId", objCustomField.CustomFieldId),
				new SqlParameter("@FieldType", objCustomField.FieldType),
				new SqlParameter("@FieldName", objCustomField.FieldName),
				new SqlParameter("@IsDisplayable", objCustomField.IsDisplayable),
				new SqlParameter("@UpdatedBy", userinfo.SigmaUserId),
				new SqlParameter("@DisciplineCode", objCustomField.DisciplineCode)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateCustomField", parameters);
                result.IsSuccessful = true;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveCustomField(TypeCustomField objCustomField)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CustomFieldId", objCustomField.CustomFieldId)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveCustomField", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiCustomField(List<TypeCustomField> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                foreach (TypeCustomField anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddCustomField(anObj);
                            break;
                        case "U":
                            UpdateCustomField(anObj);
                            break;
                        case "D":
                            RemoveCustomField(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }

        public TypeCustomField GetCustomField(TypeCustomField objCustomField)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FieldType", "STRING"));
            paramList.Add(new SqlParameter("@FieldName", objCustomField.FieldName));
            paramList.Add(new SqlParameter("@IsDisplayable", objCustomField.IsDisplayable));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            paramList.Add(new SqlParameter("@DisciplineCode", DBNull.Value));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCustomFieldByAdd", paramList.ToArray());

            if(ds.Tables[0].Rows.Count > 0)
            {
                objCustomField.CustomFieldId = Convert.ToInt32(ds.Tables[0].Rows[0]["CustomFieldId"]);
                objCustomField.FieldType = ds.Tables[0].Rows[0]["FieldType"].ToString();
                objCustomField.FieldName = ds.Tables[0].Rows[0]["FieldName"].ToString();
                objCustomField.IsDisplayable = ds.Tables[0].Rows[0]["IsDisplayable"].ToString();
                objCustomField.CreatedBy = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                objCustomField.UpdatedBy = ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
                objCustomField.DisciplineCode = ds.Tables[0].Rows[0]["DisciplineCode"].ToString();
            }

            return objCustomField;
        }

        #endregion
    }
}
