using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectSettings;

namespace Element.Sigma.Web.Biz.ProjectSettings

{
    public class IwpViewerMgr
    {
        #region IwpViewer

        public SigmaResultType ListIwpViewer(List<string> s_option, List<string> s_key)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < s_option.Count; i++)
            {
                parameters.Add(new SqlParameter(s_option[i], s_key[i]));
            }
            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListIwpViewer", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion
    }
}
