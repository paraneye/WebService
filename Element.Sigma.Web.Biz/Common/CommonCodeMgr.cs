using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.Common
{
    public class CommonCodeMgr
    {

        /// <summary>
        /// Common Code Table 
        /// </summary>
        /// <param name="tablename">Table Name </param>
        /// <param name="where">Where</param>
        /// <returns></returns>
        public DataTable GetCommonCode(string selectvalue, string tablename, string where)
        {
            string connStr = ConnStrHelper.getDbConnString();
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCommonCode", selectvalue, tablename, where);
            return ds.Tables[0];
        }

        public DataTable GetCWP()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            string connStr = ConnStrHelper.getDbConnString();
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCWPByProjectId", userinfo.CurrentProjectId);
            return ds.Tables[0];
        }

        /// <summary>
        /// Check Drawing info
        /// </summary>
        /// <param name="drawname">drawname</param>
        /// <param name="revision">revision</param>
        /// <returns></returns>
        public DataTable GetCwpDrawing(string drawname, string revision)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            string connStr = ConnStrHelper.getDbConnString();
            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCwpDrawingByNameProjectId", drawname, userinfo.CurrentProjectId);

            return ds.Tables[0];
        }

        /// <summary>
        /// Chect Customfield Data 
        /// </summary>
        /// <param name="FieldName">Excel FieldNamd</param>
        /// <param name="Value">Excel Field Data</param>
        /// <returns></returns>
        public DataTable GetCustomField(string FieldName, string Value)
        {
            string connStr = ConnStrHelper.getDbConnString();
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCustomFieldByNameValue", FieldName, Value);
            return ds.Tables[0];
        }


        /// <summary>
        /// Check Exist MaterialName from Material Table
        /// </summary>
        /// <param name="DisciplineCode">DisciplineCode</param>
        /// <returns></returns>
        public DataTable GetMaterialNameInfoByDisciplineCode(string DisciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetMaterialInfoByDisciplineCode", DisciplineCode);
            return ds.Tables[0];
        }

        /// <summary>
        /// Check ProgressStep Info(When ImportMTO)
        /// </summary>
        /// <param name="TaskCategoryId"></param>
        /// <param name="TaskTypeId"></param>
        /// <returns></returns>
        public DataTable GetProgressStepByTaskCategoryTaskType(int TaskCategoryId, int TaskTypeId)
        {
            string connStr = ConnStrHelper.getDbConnString();
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressStepByTaskCategoryTaskType", TaskCategoryId, TaskTypeId);
            return ds.Tables[0];
        }

    }
}
