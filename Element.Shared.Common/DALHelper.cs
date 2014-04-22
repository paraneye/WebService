using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;

namespace Element.Shared.Common
{
    public sealed class DALHelper
    {
        //Constructor
        private DALHelper() { }

        #region "-> Get"

        public static Database GetDatabase()
        {

            return DatabaseFactory.CreateDatabase();
        }

        public static Database GetDatabase(string instanceName)
        {
            return DatabaseFactory.CreateDatabase(instanceName);
        }

        public static DataSet GetData(string spname, params object[] parms)
        {
            try
            {
                return GetData(DatabaseFactory.CreateDatabase(), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("GetData exception", ex);
            }

        }

        public static DataSet GetData(string dbname, string spname, params object[] parms)
        {
            try
            {
                return GetData(GetDatabase(dbname), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("GetData exception", ex);
            }
        }

        public static DataSet GetData(Database db, string spname, params object[] parms)
        {
            try
            {
                return db.ExecuteDataSet(spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("GetData exception", ex);
            }
        }


        public static int ExecuteScalar(string spname, params object[] parms)
        {
            try
            {
                return ExecuteScalar(DatabaseFactory.CreateDatabase(), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteScalar exception", ex);
            }
        }


        public static int ExecuteScalar(string dbname, string spname, params object[] parms)
        {
            try
            {
                return ExecuteScalar(DatabaseFactory.CreateDatabase(dbname), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteScalar exception", ex);
            }
        }

        public static int ExecuteScalar(Database db, string spname, params object[] parms)
        {
            try
            {
                return (int)DatabaseFactory.CreateDatabase().ExecuteScalar(spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteScalar exception", ex);
            }
        }


        public static IDataReader GetDataReader(string spname, params object[] parms)
        {
            try
            {
                return GetDataReader(DatabaseFactory.CreateDatabase(), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("GetDataReader exception", ex);
            }

        }

        public static IDataReader GetDataReader(string dbname, string spname, params object[] parms)
        {
            try
            {
                return GetDataReader(DatabaseFactory.CreateDatabase(dbname), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("GetDataReader exception", ex);
            }
        }

        public static IDataReader GetDataReader(Database db, string spname, params object[] parms)
        {
            try
            {
                return db.ExecuteReader(spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("GetDataReader exception", ex);
            }
        }

        #endregion;

        #region "-> Update"

        public static DataSet UpdateDataTable(
                DataSet ds,
                string tablename,
                string insert_sp_name, string[] insert_columns,
                string update_sp_name, string[] update_columns,
                string delete_sp_name, string[] delete_columns,
                RowStatus rowstate)
        {
            return UpdateDataTable(
                    DatabaseFactory.CreateDatabase(),
                    ds,
                    tablename,
                    insert_sp_name, insert_columns,
                    update_sp_name, update_columns,
                    delete_sp_name, delete_columns,
                    rowstate);
        }

        public static DataSet UpdateDataTable(
                string dbname, DataSet ds, string tablename,
                string insert_sp_name, string[] insert_columns,
                string update_sp_name, string[] update_columns,
                string delete_sp_name, string[] delete_columns,
                RowStatus rowstate)
        {
            return UpdateDataTable(
                    DatabaseFactory.CreateDatabase(dbname),
                    ds,
                    tablename,
                    insert_sp_name, insert_columns,
                    update_sp_name, update_columns,
                    delete_sp_name, delete_columns,
                    rowstate);
        }

        public static DataSet UpdateDataTable(
                Database db,
                DataSet ds,
                string tablename,
                string insert_sp_name, string[] insert_columns,
                string update_sp_name, string[] update_columns,
                string delete_sp_name, string[] delete_columns,
                RowStatus rowstate)
        {
            

            SqlDataAdapter da = new SqlDataAdapter();

            da.InsertCommand = SqlHelper.CreateCommand((SqlConnection)db.CreateConnection(), insert_sp_name, insert_columns);
            da.UpdateCommand = SqlHelper.CreateCommand((SqlConnection)db.CreateConnection(), update_sp_name, update_columns);
            da.DeleteCommand = SqlHelper.CreateCommand((SqlConnection)db.CreateConnection(), delete_sp_name, delete_columns);

            if (rowstate == RowStatus.None) 
                da.Update(ds.Tables[tablename]);
            else
                if (ds.Tables[tablename].Select("", "",  (DataViewRowState)Convert.ToInt32(rowstate)).Length > 0)
                {
                    da.Update(ds.Tables[tablename].Select("", "",  (DataViewRowState)Convert.ToInt32(rowstate)));
                }
            return ds;

        }

        public static DataSet UpdateDataTableBySqlConnection(
                string connStr,
                DataSet ds,
                string tablename,
                string insert_sp_name, string[] insert_columns,
                string update_sp_name, string[] update_columns,
                string delete_sp_name, string[] delete_columns,
                RowStatus rowstate)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(connStr);

            da.InsertCommand = SqlHelper.CreateCommand(conn, insert_sp_name, insert_columns);
            da.UpdateCommand = SqlHelper.CreateCommand(conn, update_sp_name, update_columns);
            da.DeleteCommand = SqlHelper.CreateCommand(conn, delete_sp_name, delete_columns);

            if (rowstate == RowStatus.None)
                da.Update(ds.Tables[tablename]);
            else
                if (ds.Tables[tablename].Select("", "", (DataViewRowState)Convert.ToInt32(rowstate)).Length > 0)
                {
                    da.Update(ds.Tables[tablename].Select("", "", (DataViewRowState)Convert.ToInt32(rowstate)));
                }
            return ds;

        }

        #endregion;

        #region "-> ExecuteNonQuery "

        public static int ExecuteNonQuery(string spname, params object[] parms)
        {
            try
            {
                return ExecuteNonQuery(DatabaseFactory.CreateDatabase(), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery exception", ex);
            }

        }

        public static int ExecuteNonQuery(string dbname, string spname, params object[] parms)
        {
            try
            {
                return ExecuteNonQuery(DatabaseFactory.CreateDatabase(dbname), spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery exception", ex);
            }
        }

        public static int ExecuteNonQuery(Database db, string spname, params object[] parms)
        {
            try
            {
                return db.ExecuteNonQuery(spname, parms);
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery exception", ex);
            }
        }
        #endregion;

    }
}
