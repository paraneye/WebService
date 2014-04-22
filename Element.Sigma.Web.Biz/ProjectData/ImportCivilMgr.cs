using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;
using System.Web.Script.Serialization;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.GlobalSettings;

namespace Element.Sigma.Web.Biz.ProjectData
{
    public class ImportCivilMgr
    {

        /// <summary>
        /// Edit Material Informantion (popup)
        /// </summary>
        /// <param name="ComponentId">ComponentId</param>
        /// <returns></returns>
        public SigmaResultType ListMTOByComponent(string ComponentId)
        {
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ComponentId", int.Parse(ComponentId)));
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMTOByComponentId", parameters.ToArray());
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            return result;
        }

        /// <summary>
        /// Edit Material Informantion (popup)
        /// </summary>
        /// <param name="ComponentId">ComponentId</param>
        /// <returns></returns>
        public SigmaResultType GetComponentCustomField(string ComponentId)
        {
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ComponentId", int.Parse(ComponentId)));
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetComponentCustomField", parameters.ToArray());
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            return result;
        }

        /// <summary>
        /// 2014-02-24
        /// List Import MTO After Iniitial Screen
        /// </summary>
        /// <param name="DrawingId">DrawingId</param>
        /// <param name="offset"></param>
        /// <param name="max"></param>
        /// <param name="s_option"></param>
        /// <param name="s_key"></param>
        /// <param name="o_option"></param>
        /// <param name="o_desc"></param>
        /// <returns></returns>
        public SigmaResultType ListComponentsByDrawingId(string DrawingId, string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DrawingId", int.Parse(DrawingId)));
            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListComponentByDrawingId", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListMTO(string ComponentId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ComponentId", int.Parse(ComponentId)));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMTO", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = convertMTOdataToJson(ds.Tables[0], ds.Tables[1], ds.Tables[2]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        private string convertMTOdataToJson(DataTable component, DataTable comcustumfield, DataTable material)
        {
            List<Dictionary<string, object>> rtn = new List<Dictionary<string, object>>();
            Dictionary<string, object> param = new Dictionary<string, object>();
            Dictionary<string, object> param2 = new Dictionary<string, object>();
            List<Dictionary<string, object>> sub_list = new List<Dictionary<string, object>>();

            foreach (DataRow row in comcustumfield.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();

                foreach (DataColumn col in comcustumfield.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                sub_list.Add(dict);
            }

            foreach (DataRow row in component.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();

                foreach (DataColumn col in component.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                dict["ComCustomField"] = sub_list;
                param = dict;
            }

            foreach (DataRow row in material.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();

                foreach (DataColumn col in material.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                param2 = dict;
            }


            Dictionary<string, object> dictmp = new Dictionary<string, object>();
            dictmp["paramObj"] = param;
            dictmp["paramObj2"] = param2;
            rtn.Add(dictmp);


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(rtn);
        }

        /// <summary>
        /// List MTOInfo After Import Civil MTO(Excel)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="offset"></param>
        /// <param name="max"></param>
        /// <param name="s_option"></param>
        /// <param name="s_key"></param>
        /// <param name="o_option"></param>
        /// <param name="o_desc"></param>
        /// <returns></returns>
        public SigmaResultType ListComponentsByImportHistoryId(string ImportHistoryId, string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            int CwpId = 0;
            int DrawingId = 0;
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ImportHistoryId", Convert.ToInt32(ImportHistoryId)));
            parameters.Add(new SqlParameter("@CwpId", CwpId));
            parameters.Add(new SqlParameter("@DrawingId", DrawingId));
            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListComponentByImportHistoryId", parameters.ToArray());
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            return result;
        }


        /// <summary>
        /// ImportMTO Delete
        /// </summary>
        /// <param name="objMTO"></param>
        /// <returns></returns>
        public SigmaResultType RemoveMTOComponent(TypeMTO objMTO)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", objMTO.ComponentId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveComponent", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        /// <summary>
        ///  Delete
        /// </summary>
        /// <param name="listObj"></param>
        /// <returns></returns>
        public SigmaResultType MultiCivilMTO(List<TypeMTO> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeMTO anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "D":
                            RemoveMTOComponent(anObj);
                            break;
                    }
                }
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
    }
}
