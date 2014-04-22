using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Element.Reveal.DataLibrary;
using Element.Shared.Common;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class Common
    {
        #region Common

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public bool LoginActiveDir(string strServer, string loginName, string bPassword)
        {
            string[] serverinfo = strServer.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            System.DirectoryServices.AccountManagement.PrincipalContext insPrincipalContext = new System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, serverinfo[0].Trim(), string.Format("DC={0}, DC={1}", serverinfo[0].Split('.')[0], serverinfo[0].Split('.')[1]), serverinfo[1].Trim(), serverinfo[2].Trim());
            return insPrincipalContext.ValidateCredentials(loginName, bPassword);
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public LoginaccountDTO GetLoginAuthenticate(string loginName, string password)
        {
            string connStr = ConnStrHelper.getDbConnString();
            
            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@loginName", loginName),
                    new SqlParameter("@password", password)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetLoginauthenticate", parameters);
            LoginaccountDTO loginAccount = new LoginaccountDTO();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                loginAccount = DTOHelper.DataTableToSingleDTO<LoginaccountDTO>(ds);

                loginAccount.personnel = GetSinglePersonnelByID(loginAccount.PersonnelId);
            }

            return loginAccount;
        }

        public PersonnelDTO GetSinglePersonnelByID(string personnelId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@personnelId", personnelId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetSinglePersonnel", parameters);  //sp_findByID_personnel
            PersonnelDTO result = DTOHelper.DataTableToSingleDTO<PersonnelDTO>(ds);
            return result;

        }

        public ComboCodeBoxDTO GetSigmaUserPhotoBySigmaUserId(string sigmaUserId, string webPath)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", sigmaUserId),
                    new SqlParameter("@WebPath", webPath + "/SigmaStorage/")
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetSigmaUserBySigmaUserId", parameters); 
            ComboCodeBoxDTO result = DTOHelper.DataTableToSingleDTO<ComboCodeBoxDTO>(ds);
            return result;

        }


        public string GetProjectPath(int id, string type)
        {
            return GetProjectPath(id, type, "SharePointURL");
        }

        public string GetProjectPath(int projectId, string type, string prefix)
        {
            string result = string.Empty;
            string projPath = string.Empty;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectID", projectId),
                    new SqlParameter("@type", type)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetProjectPath", parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                projPath = (ds.Tables[0].Rows[0][0] == null) ? string.Empty : ds.Tables[0].Rows[0][0].ToString();
            }

            switch (type)
            {
                case "SharePointURL":
                    result = projPath;
                    break;
                case "IFCImagePath":
                    result = prefix + projPath;
                    break;
                case "URL":
                    result = prefix + projPath;
                    break;
            }

            return result;

        }

        public UserInfoDTO GetUserInfo(string userId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@userId", userId)
            };
                        
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetUserInfoAll", parameters);             
            UserInfoDTO result = DTOHelper.DataTableToSingleDTO<UserInfoDTO>(ds);
            return result;

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public LoginaccountDTO GetLoginaccountByLoginName(string loginName)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LoginName", loginName)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetLoginaccountByLoginname", parameters);
            LoginaccountDTO result = DTOHelper.DataTableToSingleDTO<LoginaccountDTO>(ds);
            return result;

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public LoginaccountDTO GetLoginaccountByPesonnelID(string sigmaUserId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserlId", sigmaUserId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetLoginaccount", parameters);
            LoginaccountDTO result = DTOHelper.DataTableToSingleDTO<LoginaccountDTO>(ds);
            return result;

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ProjectDTO> GetProjectAll()
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ListProject");
            List<ProjectDTO> result = DTOHelper.DataTableToListDTO<ProjectDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ProjectmoduleDTO> GetProjectAllModules()
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ListProjectAllModule");
            List<ProjectmoduleDTO> result = DTOHelper.DataTableToListDTO<ProjectmoduleDTO>(ds);
            return result;

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ProjectDTO> GetProjectBySigmauser(string sigmaUserId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserlId", sigmaUserId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetProjectBySigmauser", parameters);
            List<ProjectDTO> result = DTOHelper.DataTableToListDTO<ProjectDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ModuleDTO> GetModuleAll()
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            //SqlParameter[] parameters = new SqlParameter[] {
            //        new SqlParameter("@projectId", projectId),
            //        new SqlParameter("@disciplineCode", disciplineCode)
            //};

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ListDisciplineCode");  //sp_findall_module
            List<ModuleDTO> result = DTOHelper.DataTableToListDTO<ModuleDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<TaskcategoryDTO> GetTaskcategoryByMaterialCategory(string disciplineCode, int taskcategoryId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@taskcategoryId", taskcategoryId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetProgresstypeByTaskCategory", parameters);  //sp_get_taskcategory_by_materialcategory
            List<TaskcategoryDTO> result = DTOHelper.DataTableToListDTO<TaskcategoryDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<MaterialcategoryDTO> GetMaterialCategoryByDisciplineCode(string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetMaterialcategoryByDisciplineCode", parameters);  //sp_get_materialcategory_by_moduleid
            List<MaterialcategoryDTO> result = DTOHelper.DataTableToListDTO<MaterialcategoryDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public ModuleDTO GetModuleByID(string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDiscipline", parameters);  //sp_findByID_module
            ModuleDTO result = DTOHelper.DataTableToSingleDTO<ModuleDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<LookupDTO> GetSigmaCodeByCodeCategory(string codeCategory)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@codeCategory", codeCategory)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetSigmaCodeByCodeCategory", parameters);  //sp_get_lookup_by_lookuptype
            List<LookupDTO> result = DTOHelper.DataTableToListDTO<LookupDTO>(ds);
            return result;
        }

        public UpfileDTOS SaveSingleUploadFile(UpfileDTOS upfileDS, string userId)
        {
            UpfileDTOS retUpfileDS = new UpfileDTOS();
            retUpfileDS.fileStoreDTOList = new List<FileStoreDTO>();
            retUpfileDS.uploadedFileDTOList = new List<UploadedFileInfoDTO>();

            //Types.Auth.TypeUserInfo userInfo = Auth.AuthMgr.GetUserInfo();
            UserInfoDTO userInfo = new UserInfoDTO();
            userInfo = GetUserInfo(userId);            

            string sourceFilePath = string.Empty;
            string detailFilePath = string.Empty;
            string filetype = string.Empty;

            string uploadFolder = string.Empty;

            if (upfileDS == null || upfileDS.fileStoreDTOList == null || upfileDS.uploadedFileDTOList == null)
            {
                return upfileDS;
            }

            FileStoreDTO fileStore = upfileDS.fileStoreDTOList[0];
            UploadedFileInfoDTO uploadFile = upfileDS.uploadedFileDTOList[0];

            if (uploadFile != null && uploadFile.byteFile.Length > 0)
            {
                System.Configuration.AppSettingsReader appSetting = new System.Configuration.AppSettingsReader();
                string rootPath = "/SigmaStorage/";

                if (string.IsNullOrEmpty(fileStore.FileTypeCode))
                {
                    fileStore.ExceptionMessage = "File Type is Empty";
                    retUpfileDS.fileStoreDTOList.Add(fileStore);
                    retUpfileDS.uploadedFileDTOList.Add(uploadFile);
                    return retUpfileDS;
                }

                List<ComboCodeBoxDTO> documentTypes = GetSigmaCodeByCodeCategory_Code_Combo("", (string.IsNullOrEmpty(fileStore.FileCategory) ? Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT : fileStore.FileCategory));
                string childPath = "SigmaDoc/" + userInfo.CompanyName + "/" + userInfo.CurrentProjectId + "/" + documentTypes[0].DataName + "/" + uploadFile.Name + "/";

                int newRevision = 0;
                if (uploadFile.FileStoreId == 0)
                {
                    newRevision = 1;
                    //todo : filestore 저장 후 upfileinfo 저장
                }
                else
                {
                    newRevision = GetUploadedFileNewRevision(uploadFile.FileStoreId);
                    //todo : revision 조회해서 upfileinfo 저장
                }
                uploadFile.Revision = newRevision;

                uploadFolder = HttpContext.Current.Server.MapPath(rootPath + childPath + newRevision.ToString() + "/");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                string filePath = Path.Combine(uploadFolder, uploadFile.Name + "." + uploadFile.FileExtension);

                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                byte[] fileBytes = uploadFile.byteFile;
                fs.Write(fileBytes, 0, fileBytes.Length);

                fs.Close();

                //generate thumbnail 
                bool isSuccessful = false;
                if (!string.IsNullOrEmpty(uploadFile.FileExtension) && uploadFile.FileExtension.ToLower() == "jpg")
                    isSuccessful = (new Element.Sigma.Web.Biz.Common.ThumbnailMgr()).GenerateThumbnail(uploadFolder, uploadFile.Name, uploadFile.FileExtension);
                
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    SigmaResultType resFileStore = new SigmaResultType();
                    SigmaResultType resUploadFileInfo = new SigmaResultType();
                    if (fileStore.FileStoreId <= 0)
                    {
                        resFileStore = SaveFileStoreInsert(fileStore);

                        if (resFileStore.IsSuccessful && resFileStore.ScalarValue > 0)
                        {
                            if (fileStore.FileStoreId <= 0)
                                fileStore.FileStoreId = resFileStore.ScalarValue;

                            if (uploadFile.FileStoreId == 0)
                            {
                                uploadFile.FileStoreId = fileStore.FileStoreId;
                            }

                            uploadFile.Path = Path.Combine(childPath + newRevision.ToString() + "/", uploadFile.Name + "." + uploadFile.FileExtension);

                            resUploadFileInfo = SaveUploadedFileInfoInsert(uploadFile);
                            uploadFile.UploadedFileInfoId = resUploadFileInfo.ScalarValue;
                        }
                    }
                    else
                    {
                        resFileStore = SaveFileStoreUpdate(fileStore);

                        if (resFileStore.IsSuccessful)
                        {
                            uploadFile.Path = Path.Combine(childPath + newRevision.ToString() + "/", uploadFile.Name + "." + uploadFile.FileExtension);

                            resUploadFileInfo = SaveUploadedFileInfoInsert(uploadFile);
                            uploadFile.UploadedFileInfoId = resUploadFileInfo.ScalarValue;
                        }
                    }

                    scope.Complete();            
                }

                //for thumbnail
                if (isSuccessful == false)
                    uploadFile.ExceptionMessage = "A thumbnail was not generated.";
            }
            else
            {
                uploadFile.ExceptionMessage = "FileSize : 0 Byte";
                retUpfileDS.fileStoreDTOList.Add(fileStore);
                retUpfileDS.uploadedFileDTOList.Add(uploadFile);
                return retUpfileDS;
            }

            ////예외 처리 할 것. 02-19 leebw
            List<FileStoreDTO> fileStoreList = new List<FileStoreDTO>();
            fileStoreList.Add(fileStore);
            retUpfileDS.fileStoreDTOList = fileStoreList;

            List<UploadedFileInfoDTO> uploadedFileInfoList = new List<UploadedFileInfoDTO>();
            uploadFile.byteFile = null;
            uploadedFileInfoList.Add(uploadFile);
            retUpfileDS.uploadedFileDTOList = uploadedFileInfoList;

            return retUpfileDS;
        }

        public UpfileDTOS SaveMultiUploadFile(UpfileDTOS upfileDS, string userId, string fileName)
        {
            UpfileDTOS retUpfileDS = new UpfileDTOS();
            retUpfileDS.fileStoreDTOList = new List<FileStoreDTO>();
            retUpfileDS.uploadedFileDTOList = new List<UploadedFileInfoDTO>();

            //Types.Auth.TypeUserInfo userInfo = Auth.AuthMgr.GetUserInfo();
            UserInfoDTO userInfo = new UserInfoDTO();            
            userInfo = GetUserInfo(userId);

            string sourceFilePath = string.Empty;
            string detailFilePath = string.Empty;
            string filetype = string.Empty;

            string uploadFolder = string.Empty;

            if (upfileDS == null || upfileDS.fileStoreDTOList == null || upfileDS.uploadedFileDTOList == null)
            {
                return upfileDS;
            }            
            
            FileStoreDTO fileStore = upfileDS.fileStoreDTOList[0];
            List<UploadedFileInfoDTO> uploadFiles = upfileDS.uploadedFileDTOList;

            if (uploadFiles != null && uploadFiles.Count > 0)
            {
                System.Configuration.AppSettingsReader appSetting = new System.Configuration.AppSettingsReader();
                string rootPath = "/SigmaStorage/";

                if (string.IsNullOrEmpty(fileStore.FileTypeCode))
                {
                    fileStore.ExceptionMessage = "File Type is Empty";
                    retUpfileDS.fileStoreDTOList.Add(fileStore);
                    retUpfileDS.uploadedFileDTOList.AddRange(uploadFiles);
                    return retUpfileDS;
                }

                List<ComboCodeBoxDTO> documentTypes = GetSigmaCodeByCodeCategory_Code_Combo("", (string.IsNullOrEmpty(fileStore.FileCategory) ? Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT : fileStore.FileCategory));
                string childPath = "SigmaDoc/" + userInfo.CompanyName + "/" + userInfo.CurrentProjectId + "/" + documentTypes[0].DataName + "/" + (string.IsNullOrEmpty(fileName) ? uploadFiles[0].Name : fileName) + "/";

                int newRevision = 0;
                if (uploadFiles[0].FileStoreId == 0)
                {
                    newRevision = 1;
                    //todo : filestore 저장 후 upfileinfo 저장
                }
                else
                {
                    newRevision = GetUploadedFileNewRevision(uploadFiles[0].FileStoreId);
                    //todo : revision 조회해서 upfileinfo 저장
                }

                #region Save FileStore

                List<FileStoreDTO> fileStoreList = new List<FileStoreDTO>();

                SigmaResultType resFileStore = new SigmaResultType();
                if (fileStore.FileStoreId <= 0)
                {
                    resFileStore = SaveFileStoreInsert(fileStore);

                    if (resFileStore.IsSuccessful && resFileStore.ScalarValue > 0)
                        fileStore.FileStoreId = resFileStore.ScalarValue;
                }
                else
                {
                    resFileStore = SaveFileStoreUpdate(fileStore);
                }

                fileStoreList.Add(fileStore);
                retUpfileDS.fileStoreDTOList = fileStoreList;

                #endregion

                #region Save UploadedFileInfo

                List<UploadedFileInfoDTO> uploadedFileInfoList = new List<UploadedFileInfoDTO>();

                foreach (UploadedFileInfoDTO uploadFile in uploadFiles)
                {
                    if (uploadFile.FileStoreId == 0)
                    {
                        uploadFile.FileStoreId = fileStore.FileStoreId;
                    }
                                        
                    if (uploadFile.byteFile.Length > 0)
                    {
                        uploadFile.Revision = newRevision;

                        if (!string.IsNullOrEmpty(fileName))
                            uploadFile.Name = fileName;

                        uploadFolder = HttpContext.Current.Server.MapPath(rootPath + childPath + newRevision.ToString() + "/");
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }
                        string filePath = Path.Combine(uploadFolder, uploadFile.Name + "." + uploadFile.FileExtension);

                        //string physicalPath = HttpContext.Current.Server.MapPath(filePath);
                        System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        // Writes a block of bytes to this stream using data from
                        // a byte array.
                        byte[] fileBytes = uploadFile.byteFile;
                        fs.Write(fileBytes, 0, fileBytes.Length);

                        fs.Close();

                        //generate thumbnail 
                        bool isSuccessful = false;
                        if (!string.IsNullOrEmpty(uploadFile.FileExtension) && uploadFile.FileExtension.ToLower() == "jpg")
                            isSuccessful = (new Element.Sigma.Web.Biz.Common.ThumbnailMgr()).GenerateThumbnail(uploadFolder, uploadFile.Name, uploadFile.FileExtension);

                        //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                        //{                            

                        SigmaResultType resUploadFileInfo = new SigmaResultType();

                        uploadFile.Path = Path.Combine(childPath + newRevision.ToString() + "/", uploadFile.Name + "." + uploadFile.FileExtension);

                        uploadFile.UploadedBy = string.IsNullOrEmpty(uploadFile.UploadedBy) ? userId : uploadFile.UploadedBy;
                        uploadFile.CreatedBy = string.IsNullOrEmpty(uploadFile.CreatedBy) ? userId : uploadFile.CreatedBy;
                        uploadFile.UpdatedBy = string.IsNullOrEmpty(uploadFile.UpdatedBy) ? userId : uploadFile.UpdatedBy;

                        resUploadFileInfo = SaveUploadedFileInfoInsert(uploadFile);
                        uploadFile.UploadedFileInfoId = resUploadFileInfo.ScalarValue;

                        //    scope.Complete();
                        //}

                        //for thumbnail
                        if (isSuccessful == false)
                            uploadFile.ExceptionMessage = "A thumbnail was not generated.";
                    }
                    else
                    {
                        uploadFile.ExceptionMessage = "FileSize : 0 Byte";
                        retUpfileDS.fileStoreDTOList.Add(fileStore);
                        retUpfileDS.uploadedFileDTOList.Add(uploadFile);
                        return retUpfileDS;
                    }

                    uploadFile.byteFile = null;
                    uploadedFileInfoList.Add(uploadFile);
                }

                retUpfileDS.uploadedFileDTOList = uploadedFileInfoList;

                #endregion
            }
            else
            {
                uploadFiles[0].ExceptionMessage = "There are no Files.";
                retUpfileDS.fileStoreDTOList.Add(fileStore);
                retUpfileDS.uploadedFileDTOList.Add(uploadFiles[0]);
                return retUpfileDS;
            }

            return retUpfileDS;
        }

        public int GetUploadedFileNewRevision(int FileStoreId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            int rtnValue = 0;
            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@FileStoreId", FileStoreId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetUploadedFileNewRevison", parameters);

            try
            {
                rtnValue = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                rtnValue = 0;
            }

            return rtnValue;
        }

        public ProjectDTO GetProjectByID(int projectId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetProject", parameters);  //sp_findByID_project
            ProjectDTO result = DTOHelper.DataTableToSingleDTO<ProjectDTO>(ds);
            return result;

        }


        #endregion Common


        #region ComboBox

        /// <summary>
        /// GetComboDrawingByIDs
        /// </summary>
        /// <param name="dbname"></param>
        /// <param name="path"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetComboDrawingByIDs(string webPath, string ids)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@path", webPath + "/SigmaStorage/"),
                    new SqlParameter("@ids", ids)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboDrawingByIDs", parameters);
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetFIWPByProjectSchedule_Combo
        /// </summary>
        /// <param name="scheduledWorkItemId"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetFIWPByProjectSchedule_Combo(int scheduledWorkItemId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ScheduledWorkItemId", scheduledWorkItemId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboIwpByScheduledWorkItem", parameters);  //sp_get_combo_fiwp_by_projectschedule
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetFIWPByCwp_Combo
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="taskCategoryId"></param>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetFIWPByCwp_Combo(int cwpId, int taskcategoryId, int projectId, string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CwpID", cwpId),
                    new SqlParameter("@TaskCategoryId", taskcategoryId),
                    new SqlParameter("@ProjectID", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboIwpByCwp", parameters);  //sp_get_combo_fiwp_by_cwp
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;

        }

        /// <summary>
        /// GetMaterialCategoryByModule_Combo
        /// </summary>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetMaterialCategoryByModule_Combo(string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DisciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboTaskCategory", parameters);  //sp_get_combo_materialcategory_by_module
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;

        }

        /// <summary>
        /// GetCrewAndForemanByFiwpWorkDate_Combo
        /// </summary>
        /// <param name="iwpId"></param>
        /// <param name="cwpId"></param>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <param name="workDate"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetCrewAndForemanByFiwpWorkDate_Combo(int iwpId, int cwpId, int projectId, string disciplineCode, DateTime workDate)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@iwpId", iwpId),
                    new SqlParameter("@cwpId", cwpId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@workDate", workDate)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboChildDepartstructureByIwpWorkdate", parameters);  //sp_get_combo_childdepartstructure_by_fiwp_workdate
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;

        }

        /// <summary>
        /// GetRuleofCreditByMaterialCategory_Combo
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <param name="taskcategoryId"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetRuleofCreditByMaterialCategory_Combo(int projectId, string disciplineCode, int taskcategoryId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@TaskCategoryID", taskcategoryId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboCreditweightByTaskcategory", parameters);  //sp_get_combo_creditweight_by_materialcategory
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetSystemByProject_Combo
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetSystemByProject_Combo(int projectId, string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboSystemByProject", parameters);  //sp_get_combo_system_by_project
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetCostCodeByProject_Combo
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetCostCodeByProject_Combo(int projectId, string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboCostcodeByProject", parameters);  //sp_get_combo_costcode_by_project
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetFIWPByProject_Combo
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboCodeBoxDTO> GetFIWPByProject_Combo(int projectId, string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboIwpByProject", parameters);  //sp_get_combo_fiwp_by_project
            List<ComboCodeBoxDTO> result = DTOHelper.DataTableToListDTO<ComboCodeBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetDrawingByCWPProject_Combo
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="tastcateogyrId"></param>
        /// <param name="engTagNumber"></param>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetDrawingByCWPProject_Combo(int cwpId, int tastcateogyrId, string engTagNumber, int projectId, string disciplineCode, string path)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@cwpId", cwpId),
                    new SqlParameter("@tastcateogyrId", tastcateogyrId),
                    new SqlParameter("@engTagNumber", engTagNumber),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@path", path)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboDrawingByCwpProject", parameters);  //sp_get_combo_drawing_by_cwp_project
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetTurnoverPackageByBinderPage_Combo
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetTurnoverPackageByBinderPage_Combo(int projectId, string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboTurnoverpackageByBinderPage", parameters);  //sp_get_combo_turnoverpackage_by_binder_page
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboBoxDTO> GetFIWPByPersonnelDepartmentFiwpqaqc_Combo(int projectId, string disciplineCode, string personnelId, int departmentId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@personnelId", personnelId),
                    new SqlParameter("@departmentId", departmentId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboIwpByPersonnelDepartmentFiwpqaqc", parameters);  //sp_get_combo_fiwp_by_personnel_department_fiwpqaqc
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ExtSchedulerDTO> GetFIWPByProjectSchedule_ExtSch_Combo(int scheduledWorkItemId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ScheduledWorkItemId", scheduledWorkItemId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboIwpByScheduledWorkItemExt", parameters);  //sp_get_combo_fiwp_by_projectschedule_ext
            List<ExtSchedulerDTO> result = DTOHelper.DataTableToListDTO<ExtSchedulerDTO>(ds);
            return result;
        }

        public List<ComboCodeBoxDTO> GetUOM_Combo()
        {
            string codeCategory = "UOM";
            return GetSigmaCodeByCodeCategory_Code_Combo(codeCategory, "");
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboCodeBoxDTO> GetSigmaCodeByCodeCategory_Code_Combo(string codeCategory, string code)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CodeCategory", codeCategory),
                    new SqlParameter("@Code", code)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboSigmacodeByCategoryCode", parameters);  //sp_get_combo_lookup_by_lookuptype
            List<ComboCodeBoxDTO> result = DTOHelper.DataTableToListDTO<ComboCodeBoxDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboCodeBoxDTO> GetSigmaCodeByCodeCategory_Combo(string codeCategory, string subCodeCategory)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@codeCategory", codeCategory),
                    new SqlParameter("@SubcodeCategory", subCodeCategory)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboSigmacodeByCodeCategory", parameters);  //sp_get_combo_lookup_by_lookuptype_lookupsubtype
            List<ComboCodeBoxDTO> result = DTOHelper.DataTableToListDTO<ComboCodeBoxDTO>(ds);
            return result;
        }



        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ComboCodeBoxDTO> GetForemanGeneralForemanNameByPersonnelDepartment_Combo(string personnelId, int departmentId, int projectId, string disciplineCode)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@personnelId", personnelId),
                    new SqlParameter("@departmentId", departmentId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboForemanGeneralforemannameByPersonnelDepartment", parameters);  //sp_get_combo_foreman_generalforemanname_by_personnel_department
            List<ComboCodeBoxDTO> result = DTOHelper.DataTableToListDTO<ComboCodeBoxDTO>(ds);
            return result;
        }

        #endregion ComboBox End


        #region 파일업로드 테스트
        // GlobalSetting 의 FileStoreMgr.cs 의 AddfileStore 사용가능하면 대체가능
        public SigmaResultType SaveFileStoreInsert(FileStoreDTO objFileStore)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectId", objFileStore.ProjectId));
            paramList.Add(new SqlParameter("@FileTitle", objFileStore.FileTitle));
            paramList.Add(new SqlParameter("@FileDescription", objFileStore.FileDescription));
            paramList.Add(new SqlParameter("@FileCategory", objFileStore.FileCategory));
            paramList.Add(new SqlParameter("@FileTypeCode", objFileStore.FileTypeCode));
            paramList.Add(new SqlParameter("@CreatedBy", objFileStore.CreatedBy == null ? "null" : objFileStore.CreatedBy));

            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "tsp_AddFileStore", paramList.ToArray());
            result.IsSuccessful = true;
            result.ScalarValue = (int)outParam.Value;

            return result;
        }

        // GlobalSetting 의 FileStoreMgr.cs 의 UpdatefileStore 사용가능하면 대체가능
        public SigmaResultType SaveFileStoreUpdate(FileStoreDTO objFileStore)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@FileStroeId", objFileStore.FileStoreId),
					new SqlParameter("@FileTitle", objFileStore.FileTitle),
					new SqlParameter("@FileDescription", objFileStore.FileDescription),
					new SqlParameter("@FileCategory", objFileStore.FileCategory),
					new SqlParameter("@FileTypeCode", objFileStore.FileTypeCode),
					new SqlParameter("@UpdatedBy", objFileStore.UpdatedBy == null ? "null" : objFileStore.UpdatedBy),
                };

            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "tsp_UpdateFileStore", parameters);
            result.IsSuccessful = true;

            return result;
        }

        public SigmaResultType SaveUploadedFileInfoInsert(UploadedFileInfoDTO objUploadedFileInfo)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();


            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@FileStoreId", objUploadedFileInfo.FileStoreId));
            paramList.Add(new SqlParameter("@Name", objUploadedFileInfo.Name));
            paramList.Add(new SqlParameter("@Size", objUploadedFileInfo.Size));
            paramList.Add(new SqlParameter("@Path", objUploadedFileInfo.Path));
            paramList.Add(new SqlParameter("@UploadedBy", objUploadedFileInfo.UploadedBy == null ? "null" : objUploadedFileInfo.UploadedBy));
            paramList.Add(new SqlParameter("@UploadedDate", objUploadedFileInfo.UploadedDate));
            paramList.Add(new SqlParameter("@FileExtension", objUploadedFileInfo.FileExtension));
            paramList.Add(new SqlParameter("@Revision", objUploadedFileInfo.Revision));
            paramList.Add(new SqlParameter("@CreatedBy", objUploadedFileInfo.CreatedBy == null ? "null" : objUploadedFileInfo.CreatedBy));

            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "tsp_AddUploadedFileInfo", paramList.ToArray());
            result.IsSuccessful = true;
            result.ScalarValue = (int)outParam.Value;

            return result;
        }

        public UpfileDTOS SaveSingleUploadFileTest()
        {
            UpfileDTOS ds = new UpfileDTOS();
            FileStoreDTO filestoreDT = new FileStoreDTO();
            List<FileStoreDTO> filestoreList = new List<FileStoreDTO>();
            UploadedFileInfoDTO uploadFileInfoDT = new UploadedFileInfoDTO();
            List<UploadedFileInfoDTO> uploadFileInfoList = new List<UploadedFileInfoDTO>();

            int iFileStoreId = 72;

            filestoreDT.FileTitle = "IWP Asseble Test";
            filestoreDT.FileDescription = DateTime.Now.ToString();
            filestoreDT.FileCategory = "FILE_CATEGORY_DOCUMENT";
            filestoreDT.FileTypeCode = "FILE_TYPE_COVER";
            filestoreDT.CreatedBy = "testuser";
            filestoreDT.UpdatedBy = "testUser";
            filestoreDT.FileStoreId = iFileStoreId;
            filestoreDT.ProjectId = 0;
            filestoreList.Add(filestoreDT);

            ds.fileStoreDTOList = filestoreList;

            MemoryStream ms = new MemoryStream();
            byte[] bFile = FileToByteArray(@"C:\TMP\test.jpg");

            uploadFileInfoDT.Name = "IWP Asseble Image";
            uploadFileInfoDT.Size = 1000;
            uploadFileInfoDT.UploadedBy = "uploadtuser";
            uploadFileInfoDT.FileExtension = "jpg";
            uploadFileInfoDT.CreatedBy = "testuser";
            uploadFileInfoDT.UpdatedBy = "testuser";
            uploadFileInfoDT.byteFile = bFile;
            uploadFileInfoDT.UploadedFileInfoId = 0;
            uploadFileInfoDT.FileStoreId = iFileStoreId;
            uploadFileInfoDT.UploadedDate = DateTime.Now;
            uploadFileInfoList.Add(uploadFileInfoDT);
            ds.uploadedFileDTOList = uploadFileInfoList;

            return SaveSingleUploadFile(ds, "admin");
        }

        public byte[] FileToByteArray(string path)
        {
            byte[] fileBytes = null;
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    fileBytes = new byte[fileStream.Length];
                    fileStream.Read(fileBytes, 0, fileBytes.Length);
                }
            }
            catch (Exception e)
            {
                // Exception ...
            }
            return fileBytes;
        }
        #endregion 파일업로드 테스트

        public SigmaResultTypeDTO UploadFileByPath(List<UploadFileDTO> objList)
        {
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            string fileName = string.Empty;
            string filePath = string.Empty;
            byte[] fileBytes = null;
            string rootPath = "/SigmaStorage/";

            foreach (UploadFileDTO obj in objList)
            {
                fileName = obj.FileName;
                filePath = obj.FilePath;
                fileBytes = obj.FileByte;

                string uploadFolder = HttpContext.Current.Server.MapPath(rootPath + filePath);

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string strPath = Path.Combine(uploadFolder, fileName);

                System.IO.FileStream fs = new System.IO.FileStream(strPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                fs.Write(fileBytes, 0, fileBytes.Length);

                // close file stream
                fs.Close();
            }

            result.IsSuccessful = true;

            return result;
        }

    }

}
