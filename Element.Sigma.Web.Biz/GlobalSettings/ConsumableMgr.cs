using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class ConsumableMgr
    {
        public SigmaResultType GetConsumable(string consumableId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ConsumableId", consumableId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetConsumable", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListConsumable(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListConsumable", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddConsumable(TypeConsumable objConsumable)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Description", objConsumable.Description));
            paramList.Add(new SqlParameter("@PartNumber", objConsumable.PartNumber));
            paramList.Add(new SqlParameter("@Vendor", objConsumable.Vendor));
            paramList.Add(new SqlParameter("@UomCode", objConsumable.UomCode));
            paramList.Add(new SqlParameter("@CreatedBy", objConsumable.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddConsumable", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType UpdateConsumable(TypeConsumable objConsumable)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@Description", objConsumable.Description),
					new SqlParameter("@PartNumber", objConsumable.PartNumber),
					new SqlParameter("@Vendor", objConsumable.Vendor),
					new SqlParameter("@UomCode", objConsumable.UomCode),
					new SqlParameter("@CreatedBy", objConsumable.CreatedBy),
					new SqlParameter("@UpdatedBy", objConsumable.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateConsumable", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveConsumable(TypeConsumable objConsumable)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ConsumableId", objConsumable.ConsumableId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveConsumable", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiConsumable(List<TypeConsumable> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeConsumable anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddConsumable(anObj);
                            break;
                        case "U":
                            UpdateConsumable(anObj);
                            break;
                        case "D":
                            RemoveConsumable(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }
    }
}
