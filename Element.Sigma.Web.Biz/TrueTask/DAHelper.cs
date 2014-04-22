using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Element.Shared.Common;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class DAHelper
    {
        public static DataSet UpdateDataTableBySqlConnection(
                string connStr,
                DataSet ds,
                string insert_sp_name, string[] insert_columns,
                string update_sp_name, string[] update_columns,
                string delete_sp_name, string[] delete_columns,
                RowStatusNo rowstate)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(connStr);

            da.InsertCommand = SqlHelper.CreateCommand(conn, insert_sp_name, insert_columns);
            da.UpdateCommand = SqlHelper.CreateCommand(conn, update_sp_name, update_columns);
            da.DeleteCommand = SqlHelper.CreateCommand(conn, delete_sp_name, delete_columns);

            if (rowstate == RowStatusNo.None)
                da.Update(ds.Tables[0]);
            else
                if (ds.Tables[0].Select("", "", (DataViewRowState)Convert.ToInt32(rowstate)).Length > 0)
                {
                    da.Update(ds.Tables[0].Select("", "", (DataViewRowState)Convert.ToInt32(rowstate)));
                }
            return ds;
        }
    }
}
