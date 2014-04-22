using Element.Shared.Common;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Types.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Element.Sigma.Web.Biz.Common
{
    public class MessageBoxMgr
    {
        public SigmaResultType GetMessageBox(string msgTypeCode, string msgSeq)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@MsgTypeCode", msgTypeCode));
            paramList.Add(new SqlParameter("@MsgSeq", msgSeq));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetMessageBox", paramList.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //public SigmaResultType ListMessageBox(NameValueCollection queryParams)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    List<SqlParameter> paramList = new List<SqlParameter>();

        //    string max = queryParams["max"];
        //    string offset = queryParams["offset"];
        //    string o_option = queryParams["o_option"];
        //    string o_desc = queryParams["o_desc"];

        //    paramList.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
        //    paramList.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

        //    paramList.Add(new SqlParameter("@SortColumn", o_option));
        //    paramList.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMessageBox", paramList.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        //public SigmaResultType AddMessageBox(TypeMessageBox objMessageBox)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    paramList.Add(new SqlParameter("@MsgTitle", objMessageBox.MsgTitle));
        //    paramList.Add(new SqlParameter("@MsgTo", objMessageBox.MsgTo));
        //    paramList.Add(new SqlParameter("@IsRead", objMessageBox.IsRead));
        //    paramList.Add(new SqlParameter("@IsDelete", objMessageBox.IsDelete));
        //    paramList.Add(new SqlParameter("@CreatedBy", objMessageBox.CreatedBy));
        //    paramList.Add(new SqlParameter("@ContextSeq", objMessageBox.ContextSeq));
        //    SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
        //    outParam.Direction = ParameterDirection.Output;
        //    paramList.Add(outParam);

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddMessageBox", paramList.ToArray());
        //        result.IsSuccessful = true;
        //        result.ScalarValue = (int)outParam.Value;
             
        //        scope.Complete();
        //    }

        //    return result;
        //}

        //public SigmaResultType UpdateMessageBox(TypeMessageBox objMessageBox)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    paramList.Add(new SqlParameter("@MsgTypeCode", objMessageBox.MsgTypeCode));
        //    paramList.Add(new SqlParameter("@MsgSeq", objMessageBox.MsgSeq));
        //    paramList.Add(new SqlParameter("@MsgTitle", objMessageBox.MsgTitle));
        //    paramList.Add(new SqlParameter("@MsgTo", objMessageBox.MsgTo));
        //    paramList.Add(new SqlParameter("@IsRead", objMessageBox.IsRead));
        //    paramList.Add(new SqlParameter("@IsDelete", objMessageBox.IsDelete));
        //    paramList.Add(new SqlParameter("@ContextSeq", objMessageBox.ContextSeq));

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateMessageBox", paramList.ToArray());
        //        result.IsSuccessful = true;
        
        //        scope.Complete();
        //    }

        //    return result;
        //}

        //public SigmaResultType UpdateMessageBox(TypeMessageBox objMessageBox)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    List<SqlParameter> paramList = new List<SqlParameter>();
        //    paramList.Add(new SqlParameter("@MsgTypeCode", objMessageBox.MsgTypeCode));
        //    paramList.Add(new SqlParameter("@MsgSeq", objMessageBox.MsgSeq));
        //    paramList.Add(new SqlParameter("@MsgTitle", objMessageBox.MsgTitle));
        //    paramList.Add(new SqlParameter("@MsgTo", objMessageBox.MsgTo));
        //    paramList.Add(new SqlParameter("@IsRead", objMessageBox.IsRead));
        //    paramList.Add(new SqlParameter("@IsDelete", objMessageBox.IsDelete));
        //    paramList.Add(new SqlParameter("@ContextSeq", objMessageBox.ContextSeq));

        //    using (scope = new TransactionScope(TransactionScopeOption.Required))
        //    {
        //        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateMessageBox", paramList.ToArray());
        //        result.IsSuccessful = true;

        //        scope.Complete();
        //    }

        //    return result;
        //}

        public SigmaResultType RemoveMessageBox(TypeMessageBox objMessageBox)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@MsgTypeCode", objMessageBox.MsgTypeCode.Trim()));
            paramList.Add(new SqlParameter("@MsgSeq", Utilities.ToInt32(objMessageBox.MsgSeq.ToString().Trim())));
            paramList.Add(new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim()));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveMessageBox", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        //public SigmaResultType MultiMessageBox(List<TypeMessageBox> listObj)
        //{
        //    TransactionScope scope = null;
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {

        //        foreach (TypeMessageBox anObj in listObj)
        //        {
        //            switch (anObj.SigmaOperation)
        //            {
        //                case "C":
        //                    AddMessageBox(anObj);
        //                    break;
        //                case "U":
        //                    UpdateMessageBox(anObj);
        //                    break;
        //                case "D":
        //                    RemoveMessageBox(anObj);
        //                    break;
        //            }
        //        }

        //        scope.Complete();
        //    }

        //    result.IsSuccessful = true;

        //    return result;
        //}

        public SigmaResultType ListMessageBoxBySigmaUserId()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));
            paramList.Add(new SqlParameter("@SigmaUserId", userinfo.SigmaUserId.Trim()));
           
            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListMessageBoxBySigmaUserId", paramList.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }
    }
}
