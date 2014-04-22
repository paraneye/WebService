using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class ComponentCustomFieldMgr
    {

        public SigmaResultType GetComponentCustomField(string componentId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", componentId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetComponentCustomField", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }
        public SigmaResultType ListComponentCustomField(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListComponentCustomField", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }
        public SigmaResultType AddComponentCustomField(TypeComponentCustomField objComponentCustomField)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ComponentId", objComponentCustomField.ComponentId));
            paramList.Add(new SqlParameter("@CustomFieldId", objComponentCustomField.CustomFieldId));
            paramList.Add(new SqlParameter("@Value", objComponentCustomField.Value));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddComponentCustomField", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = 1; //ComponentCustomField table에는 PK가 없기에 @NewId 필요 없음
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType UpdateComponentCustomField(TypeComponentCustomField objComponentCustomField)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", objComponentCustomField.ComponentId),
					new SqlParameter("@CustomFieldId", objComponentCustomField.CustomFieldId),
					new SqlParameter("@Value", objComponentCustomField.Value),
					new SqlParameter("@UpdatedBy", userinfo.SigmaUserId),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateComponentCustomField", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemoveComponentCustomField(TypeComponentCustomField objComponentCustomField)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", objComponentCustomField.ComponentId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveComponentCustomField", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiComponentCustomField(List<TypeComponentCustomField> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeComponentCustomField anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddComponentCustomField(anObj);
                            break;
                        case "U":
                            UpdateComponentCustomField(anObj);
                            break;
                        case "D":
                            RemoveComponentCustomField(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }



    }
}
