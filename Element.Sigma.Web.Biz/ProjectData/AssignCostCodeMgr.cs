using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.ProjectSettings;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectData;
using Element.Sigma.Web.Biz.Auth;
using System.Xml.Linq;

namespace Element.Sigma.Web.Biz.ProjectData
{
    public class AssignCostCodeMgr
    {
        public SigmaResultType ListAssignmentComponentProgress(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < s_option.Count; i++)
            {
                parameters.Add(new SqlParameter(s_option[i], s_key[i]));
            }

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));

            
            parameters.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListComponentProgress", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType UpdateAssignmentComponentProgress(TypeAssignmentCostCode objAssignmentcostcode)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@CostCodeId", objAssignmentcostcode.CostCodeId),
					new SqlParameter("@ComponentProgressId", objAssignmentcostcode.ComponentProgressId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateComponentProgressForAssignCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType MultiAssignmentComponentProgress(List<TypeAssignmentCostCode> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeAssignmentCostCode anObj in listObj)
                {
                    UpdateAssignmentComponentProgress(anObj);
                }
                scope.Complete();
                result.IsSuccessful = true;
            }

            return result;
        }


        public List<TypeAssignmentCostCode> TargetListAssignmentComponentProgress(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            List<TypeAssignmentCostCode> result = new List<TypeAssignmentCostCode>();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < s_option.Count; i++)
            {
                parameters.Add(new SqlParameter(s_option[i], s_key[i]));
            }

            parameters.Add(new SqlParameter("@MaxNumRows", 10000));
            parameters.Add(new SqlParameter("@RetrieveOffset",  int.Parse("0")));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListComponentProgress", parameters.ToArray());


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TypeAssignmentCostCode obj = new TypeAssignmentCostCode();
                obj.ComponentProgressId = Convert.ToInt32(ds.Tables[0].Rows[i]["ComponentProgressId"]);
                result.Add(obj);
            }
            // return
            return result;
        }
    }
}
