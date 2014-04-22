using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.Auth;
using System.Web;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class FileStoreMgr
    {
        #region FileStore
        public SigmaResultType GetFileStore(string fileStoreId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@fileStoreId", fileStoreId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetFileStore", parameters);
            
            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListFileStore(string offset, string max, List<string[]> s_optionkeyList, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var s_optionkey in s_optionkeyList)
            {
                parameters.Add(new SqlParameter(string.Format("@{0}", s_optionkey[0]), s_optionkey[1]));
            }

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));

            parameters.Add(new SqlParameter("@projectId", userinfo.CurrentProjectId));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListFileStore", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);

            //result.AffectedRow = (int)ds.Tables[1].Rows[0][0];
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return

            return result;
        }

        public SigmaResultType AddFileStore(TypeFileStore objFileStore, string targetPath)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            //objFileStore.CompanyId = userinfo.CompanyId.ToString();
            objFileStore.CreatedBy = userinfo.SigmaUserId;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));
            paramList.Add(new SqlParameter("@FileTitle", objFileStore.FileTitle));
            paramList.Add(new SqlParameter("@FileDescription", objFileStore.FileDescription));
            paramList.Add(new SqlParameter("@FileCategory", objFileStore.FileCategory));
            paramList.Add(new SqlParameter("@FileTypeCode", objFileStore.FileTypeCode));
            paramList.Add(new SqlParameter("@CreatedBy", objFileStore.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddFileStore", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                //scope.Complete();
                if (objFileStore.UploadedFileInfo.UploadedFileInfoId == 0)
                {
                    //FileInfo fileinfo = new FileInfo(targetPath + objFileStore.UploadedFileInfo.Path);

                    //objFileStore.UploadedFileInfo.Name = Path.GetFileNameWithoutExtension(targetPath + objFileStore.UploadedFileInfo.Path);
                    //objFileStore.UploadedFileInfo.Size = (int)fileinfo.Length;
                    //objFileStore.UploadedFileInfo.FileExtension = fileinfo.Extension;//Path.GetExtension(objFileStore.UploadedFileInfo.Path);
                    //objFileStore.UploadedFileInfo.FileStoreId = (int)outParam.Value;


                    //-----------------------------------------------------------------------------------------------------
                    //--------------- IE - The given path's format is not supported.  error 해결 -------------------------
                    string filename = Path.GetFileNameWithoutExtension(targetPath + objFileStore.UploadedFileInfo.Path);
                    //string filename = System.IO.Path.GetFileName(targetPath + objFileStore.UploadedFileInfo.Path);
                    FileInfo fileinfo = new FileInfo(targetPath + objFileStore.UploadedFileInfo.Path);
                    string fileExtention = Path.GetExtension(targetPath + objFileStore.UploadedFileInfo.Path);
                    //-----------------------------------------------------------------------------------------------------
                    //-----------------------------------------------------------------------------------------------------

                    objFileStore.UploadedFileInfo.Name = filename;
                    objFileStore.UploadedFileInfo.Size = (int)fileinfo.Length;
                    objFileStore.UploadedFileInfo.FileExtension = fileExtention;
                    objFileStore.UploadedFileInfo.FileStoreId = (int)outParam.Value;


                    UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                    uploadedFileInfoMgr.AddUploadedFileInfo(objFileStore.UploadedFileInfo);
                }
                scope.Complete();
            }


            return result;
        }


        public SigmaResultType UpdateFileStore(TypeFileStore objFileStore, string targetPath)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objFileStore.UpdatedBy = userinfo.SigmaUserId;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@FileStroeId", objFileStore.FileStoreId),
					new SqlParameter("@FileTitle", objFileStore.FileTitle),
					new SqlParameter("@FileDescription", objFileStore.FileDescription),
					new SqlParameter("@FileCategory", objFileStore.FileCategory),
					new SqlParameter("@FileTypeCode", objFileStore.FileTypeCode),
					new SqlParameter("@UpdatedBy", objFileStore.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateFileStore", parameters);
                result.IsSuccessful = true;
                //scope.Complete();
                if (objFileStore.UploadedFileInfo.Path != null)
                {
                    FileInfo fileinfo = new FileInfo(targetPath + objFileStore.UploadedFileInfo.Path);

                    objFileStore.UploadedFileInfo.Name = Path.GetFileNameWithoutExtension(targetPath + objFileStore.UploadedFileInfo.Path);
                    objFileStore.UploadedFileInfo.Size = (int)fileinfo.Length;
                    objFileStore.UploadedFileInfo.FileExtension = Path.GetExtension(objFileStore.UploadedFileInfo.Path);
                    objFileStore.UploadedFileInfo.FileStoreId = objFileStore.FileStoreId;

                    UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                    uploadedFileInfoMgr.AddUploadedFileInfo(objFileStore.UploadedFileInfo);
                }
                scope.Complete();
            }

            return result;
        }
        public SigmaResultType RemoveFileStore(TypeFileStore objFileStore)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@fileStoreId", objFileStore.FileStoreId)
                };

            // IWP Document를 확인 해야 됨.
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListUploadedFileInfoByFileStoreId", parameters);

            var UploadedFiles = (from dr in ds.Tables[0].AsEnumerable() select dr.Field<string>("Path"));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveFileStore", parameters);
                result.IsSuccessful = true;
                scope.Complete();
                foreach (string Path in UploadedFiles)
                {
                    string basePath = HttpContext.Current.Server.MapPath("/SigmaStorage");
                    try
                    {
                        string filepath = basePath + "\\" + Path.Replace("/", "\\");
                        if (File.Exists(filepath))
                        {
                            File.Delete(filepath);
                            File.Delete(System.IO.Path.ChangeExtension(filepath, "pdf"));
                            File.Delete(filepath.Replace(".jpg", ".thumbnail.jpg"));
                        }
                    }
                    catch { }
                    //SigmaDoc/Ledcor/1/Document/EQUIPMENT-Battery_Care_And_Tips.pdf
                }
                //SigmaResultType uploadedresult = new SigmaResultType();
                //UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                //uploadedFileInfoMgr.RemoveUploadedFileInfoALL(objFileStore.FileStoreId);
            }


            return result;
        }


        public SigmaResultType MultiFileStore(List<TypeFileStore> listObj, string targetPath)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            foreach (TypeFileStore anObj in listObj)
            {
                switch (anObj.SigmaOperation)
                {
                    case "C":
                        result = AddFileStore(anObj, targetPath);
                        break;
                    case "U":
                        result = UpdateFileStore(anObj, targetPath);
                        break;
                    case "D":
                        result = RemoveFileStore(anObj);
                        break;
                }
            }

            return result;
        }
        #endregion

        #region FileType
        public SigmaResultType GetFileType(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@codeCategory", codeCategory) ,
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetFileTypeByCodeCategory", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }
        #endregion


        /*
        #region UploadedFileInfo
        public SigmaResultType GetUploadedFileInfo(string uploadedFileInfoId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@uploadedFileInfoId", uploadedFileInfoId)
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


            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCompany", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0];
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FileStoreId", objUploadedFileInfo.FileStoreId));
            paramList.Add(new SqlParameter("@Name", objUploadedFileInfo.Name));
            paramList.Add(new SqlParameter("@Size", objUploadedFileInfo.Size));
            paramList.Add(new SqlParameter("@Path", objUploadedFileInfo.Path));
            paramList.Add(new SqlParameter("@UploadedBy", objUploadedFileInfo.UploadedBy));
            paramList.Add(new SqlParameter("@UploadedDate", objUploadedFileInfo.UploadedDate));
            paramList.Add(new SqlParameter("@FileExtension", objUploadedFileInfo.FileExtension));
            paramList.Add(new SqlParameter("@Revision", objUploadedFileInfo.Revision));
            paramList.Add(new SqlParameter("@FileType", objUploadedFileInfo.FileType));
            paramList.Add(new SqlParameter("@CreatedBy", objUploadedFileInfo.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
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

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@FileStoreId", objUploadedFileInfo.FileStoreId),
					new SqlParameter("@Name", objUploadedFileInfo.Name),
					new SqlParameter("@Size", objUploadedFileInfo.Size),
					new SqlParameter("@Path", objUploadedFileInfo.Path),
					new SqlParameter("@UploadedBy", objUploadedFileInfo.UploadedBy),
					new SqlParameter("@UploadedDate", objUploadedFileInfo.UploadedDate),
					new SqlParameter("@FileExtension", objUploadedFileInfo.FileExtension),
					new SqlParameter("@Revision", objUploadedFileInfo.Revision),
					new SqlParameter("@FileType", objUploadedFileInfo.FileType),
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
        public SigmaResultType RemoveUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@uploadedFileInfoId", objUploadedFileInfo.UploadedFileInfoId)
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
        #endregion
         * */
    }
}
