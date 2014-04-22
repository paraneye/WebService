using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.IO;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class UploadedFileInfoMgr
    {
        public SigmaResultType GetUploadedFileInfo(string uploadedFileInfoId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UploadedFileInfoId", uploadedFileInfoId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetUploadedFileInfo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListUploadedFileInfo(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            
            parameters.Add(new SqlParameter(string.Format("@{0}", s_option), s_key));

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            
            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListUploadedFileInfo", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.IsSuccessful = true;
            // return
            return result;
        }

        public int GetUploadedFileRevisionInfo(int FileStoreId)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FileStoreId", FileStoreId));
            SqlParameter outParam = new SqlParameter("@Revision", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);
            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_GetUploadedFileRevison", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return (int)outParam.Value;
        }

        public SigmaResultType AddUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            //objFileStore.CompanyId = userinfo.CompanyId.ToString();
            objUploadedFileInfo.CreatedBy = userinfo.SigmaUserId;
            objUploadedFileInfo.UpdatedBy = userinfo.SigmaUserId;
            objUploadedFileInfo.UploadedBy = userinfo.SigmaUserId;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            
            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {

                List<SqlParameter> paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@FileStoreId", objUploadedFileInfo.FileStoreId));
                paramList.Add(new SqlParameter("@Name", objUploadedFileInfo.Name));
                paramList.Add(new SqlParameter("@Size", objUploadedFileInfo.Size));
                paramList.Add(new SqlParameter("@Path", objUploadedFileInfo.Path));
                paramList.Add(new SqlParameter("@UploadedBy", objUploadedFileInfo.UploadedBy));
                //paramList.Add(new SqlParameter("@UploadedDate", objUploadedFileInfo.UploadedDate));
                paramList.Add(new SqlParameter("@FileExtension", objUploadedFileInfo.FileExtension));
                paramList.Add(new SqlParameter("@Revision", GetUploadedFileRevisionInfo(objUploadedFileInfo.FileStoreId)));
                paramList.Add(new SqlParameter("@CreatedBy", objUploadedFileInfo.CreatedBy));
                paramList.Add(new SqlParameter("@UpdatedBy", objUploadedFileInfo.UpdatedBy));
                SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                paramList.Add(outParam);

                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddUploadedFileInfo", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType UpdateUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            //objFileStore.CompanyId = userinfo.CompanyId.ToString();
            objUploadedFileInfo.CreatedBy = userinfo.SigmaUserId;
            objUploadedFileInfo.UpdatedBy = userinfo.SigmaUserId;
            objUploadedFileInfo.UploadedBy = userinfo.SigmaUserId;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@UploadedFileInfoId", objUploadedFileInfo.UploadedFileInfoId),
					new SqlParameter("@FileStoreId", objUploadedFileInfo.FileStoreId),
					new SqlParameter("@Name", objUploadedFileInfo.Name),
					new SqlParameter("@Size", objUploadedFileInfo.Size),
					new SqlParameter("@Path", objUploadedFileInfo.Path),
					new SqlParameter("@UploadedBy", objUploadedFileInfo.UploadedBy),
					new SqlParameter("@UploadedDate", objUploadedFileInfo.UploadedDate),
					new SqlParameter("@FileExtension", objUploadedFileInfo.FileExtension),
					new SqlParameter("@Revision", objUploadedFileInfo.Revision),
					new SqlParameter("@CreatedBy", objUploadedFileInfo.CreatedBy),
					new SqlParameter("@UpdatedBy", objUploadedFileInfo.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateUploadedFileInfo", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public bool RemoveUploadedFileInfoALL(int FileStoreId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@FileStoreId", FileStoreId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveUploadedFileInfoALL", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result.IsSuccessful;
        }

        public SigmaResultType RemoveUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@UploadedFileInfoId", objUploadedFileInfo.UploadedFileInfoId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveUploadedFileInfo", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiUploadedFileInfo(List<TypeUploadedFileInfo> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeUploadedFileInfo anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddUploadedFileInfo(anObj);
                            break;
                        case "U":
                            UpdateUploadedFileInfo(anObj);
                            break;
                        case "D":
                            RemoveUploadedFileInfo(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }

        public int GetUploadedFileInfoCountByName(string filename)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Name", filename),
                    new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetUploadedFileInfoByName", parameters);

            // return
            return ds.Tables[0].Rows.Count;
        }
    }
}
