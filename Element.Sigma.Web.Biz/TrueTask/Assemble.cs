using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Element.Shared.Common;
using Element.Reveal.DataLibrary;
using System.Transactions;
using Microsoft.Reporting.WebForms;
using System.Web;
using System.IO;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class Assemble
    {
        /// <summary>
        /// GetCwpByProjectPackageType
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <param name="packageTypeCode"></param>
        /// <returns></returns>
        public List<CwpDTO> GetCwpByProjectPackageType(int projectId, string disciplineCode, string packageTypeCode, string userId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode),
                    new SqlParameter("@PackageTypeCode", packageTypeCode),
                    new SqlParameter("@SigmaUserId", userId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetCwpByProjectDisciplinePackageType", parameters);
            List<CwpDTO> result = DTOHelper.DataTableToListDTO<CwpDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetProjectScheduleByCwpProjectPackageTypeWithWBS
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="projectId"></param>
        /// <param name="packageTypeCode"></param>
        /// <returns></returns>
        public List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectPackageTypeWithWBS(int cwpId, int projectId, string packageTypeCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CwpId", cwpId),
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@PackageTypeCode", packageTypeCode),
                    new SqlParameter("@IncludedWBS", 1) 
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetScheduledWorkItemByCwpProjectPackageType", parameters);
            List<ProjectscheduleDTO> result = DTOHelper.DataTableToListDTO<ProjectscheduleDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetFiwpByCwpSchedulePackageType
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="scheduledWorkItemId"></param>
        /// <param name="packageTypeCode"></param>
        /// <returns></returns>
        public List<FiwpDTO> GetFiwpByCwpSchedulePackageType(int cwpId, int scheduledWorkItemId, string packageTypeCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CwpId", cwpId),
                    new SqlParameter("@ScheduledWorkItemId", scheduledWorkItemId),
                    new SqlParameter("@PackageTypeCode", packageTypeCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwpByCwpScheduledWorkItemPackageType", parameters);
            List<FiwpDTO> result = DTOHelper.DataTableToListDTO<FiwpDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetFiwpEquipByFIWP
        /// </summary>
        /// <param name="iwpId"></param>
        /// <returns></returns>
        public List<FiwpequipDTO> GetFiwpEquipByFIWP(int iwpId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IwpId", iwpId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwpEquipmentByIwp", parameters);
            List<FiwpequipDTO> result = DTOHelper.DataTableToListDTO<FiwpequipDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetFieldequipmentByType
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<FieldequipmentDTO> GetFieldequipmentByType(string search)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Search", search)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetEquipmentByCode", parameters);
            List<FieldequipmentDTO> result = DTOHelper.DataTableToListDTO<FieldequipmentDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetLibconsumableAll
        /// </summary>
        /// <returns></returns>
        public List<LibconsumableDTO> GetLibconsumableAll()
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {                    
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetMaterialForConsumable", parameters);
            List<LibconsumableDTO> result = DTOHelper.DataTableToListDTO<LibconsumableDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetUploadedFileInfoByProjectFileType
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="fileTypeCode"></param>
        /// <returns></returns>
        public List<DocumentDTO> GetUploadedFileInfoByProjectFileType(int projectId, string fileTypeCode, string fileCategory, string webPath)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {     
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@FileTypeCode", fileTypeCode),
                    new SqlParameter("@FileCategory", fileCategory),
                    new SqlParameter("@WebPath", webPath + "/SigmaStorage/")
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetUploadedFileInfoByProjectFileType", parameters);
            List<DocumentDTO> result = DTOHelper.DataTableToListDTO<DocumentDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetIwpDocumentByIwpProjectFileType
        /// </summary>
        /// <param name="iwpId"></param>
        /// <param name="projectId"></param>
        /// <param name="fileTypeCode"></param>
        /// <returns></returns>
        public List<DocumentDTO> GetIwpDocumentByIwpProjectFileType(int iwpId, int projectId, string fileTypeCode, string isDisplayable, string fileCategory, string webPath, int iwpDocumentId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {     
                    new SqlParameter("@IwpId", iwpId),
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@FileTypeCode", fileTypeCode),                    
                    new SqlParameter("@FileCategory", fileCategory),
                    new SqlParameter("@IsDisplayable", isDisplayable),
                    new SqlParameter("@WebPath", webPath + "/SigmaStorage/"),
                    new SqlParameter("@IwpDocumentId", iwpDocumentId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwpDocumentByIwpProjectFileType", parameters);
            List<DocumentDTO> result = DTOHelper.DataTableToListDTO<DocumentDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetIwpDocumentByIwpProjectFileType_Combo
        /// </summary>
        /// <param name="iwpId"></param>
        /// <param name="projectId"></param>
        /// <param name="fileTypeCode"></param>
        /// <returns></returns>
        public List<ComboBoxDTO> GetIwpDocumentByIwpProjectFileType_Combo(int iwpId, int projectId, string fileTypeCode, string isDisplayable)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IwpId", iwpId),
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@FileTypeCode", fileTypeCode),
                    new SqlParameter("@IsDisplayable", isDisplayable)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboIwpDocumentByIwpProjectFileType", parameters);
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<DocumentDTO> GetDocumentByFIWPDocType(string filetypeCode, int iwpId, int projectId, string disciplineCode, string path)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {     
                    new SqlParameter("@FileTypeCode", filetypeCode),
                    new SqlParameter("@FIWPID", iwpId),
                    new SqlParameter("@ProjectID", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode),
                    new SqlParameter("@Path", path + "/SigmaStorage/")
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwpDocumentByIwpDoctype", parameters);  //sp_get_document_by_fiwp_doctype
            List<DocumentDTO> result = DTOHelper.DataTableToListDTO<DocumentDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetProjectCwaIwpByIwp
        /// </summary>
        /// <param name="iwpId"></param>
        /// <returns></returns>
        public rptProjectCwaIwpDTO GetProjectCwaIwpByIwp(int iwpId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {     
                    new SqlParameter("@IwpId", iwpId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetProjectCwaIwpByIwp", parameters);
            rptProjectCwaIwpDTO result = DTOHelper.DataTableToSingleDTO<rptProjectCwaIwpDTO>(ds);
            return result;
        }

        /// <summary>
        /// SaveFiwpequip
        /// </summary>
        /// <param name="fiwpequip"></param>
        /// <returns></returns>
        public List<FiwpequipDTO> SaveFiwpequip(List<FiwpequipDTO> fiwpequip)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(fiwpequip.GetType(), fiwpequip);

            string insert_sp_name = "tsp_AddIwpEquipment";
            string update_sp_name = "tsp_UpdateIwpEquipment";
            string delete_sp_name = "tsp_RemoveIwpEquipment";
            
            string[] insert_columns = { "FiwpEquipID", "FIWPID", "EquipmentID", "Qty", "StartUseDate", "FinishUseDate", "UpdatedBy" };
            string[] update_columns = { "FiwpEquipID", "FIWPID", "EquipmentID", "Qty", "StartUseDate", "FinishUseDate", "UpdatedBy" };
            string[] delete_columns = { "FiwpEquipID" };

            ds.Tables[0].TableName = TableName.FIWPEquip;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.FIWPEquip, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.FiwpEquip;
            fiwpequip = (List<FiwpequipDTO>)DTOHelper.DeserializeDTOList(fiwpequip.GetType(), ds);

            // Return the data transfer object.
            return fiwpequip;    
        }

        public List<DocumentDTO> SaveDocument(List<DocumentDTO> document)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(document.GetType(), document);

            string insert_sp_name = "tsp_AddIwpDocument";
            string update_sp_name = "tsp_UpdateIwpDocument";
            string delete_sp_name = "tsp_RemoveIwpDocument";

            string[] insert_columns = { "DocumentID", "FIWPID", "FileStoreId", "IsDisplayable", "UpdatedBy" };
            string[] update_columns = { "DocumentID", "FIWPID", "FileStoreId", "IsDisplayable", "UpdatedBy" };
            string[] delete_columns = { "DocumentID" };

            ds.Tables[0].TableName = TableName.Document;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.Document, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.Document;
            document = (List<DocumentDTO>)DTOHelper.DeserializeDTOList(document.GetType(), ds);

            // Return the data transfer object.
            return document;
        }

        public List<FiwpmaterialDTO> SaveFiwpMaterial(List<FiwpmaterialDTO> fiwpmaterial)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(fiwpmaterial.GetType(), fiwpmaterial);

            string insert_sp_name = "tsp_AddIwpMaterial";
            string update_sp_name = "tsp_UpdateIwpMaterial";
            string delete_sp_name = "tsp_RemoveIwpMaterial";

            string[] insert_columns = { "FIWPMaterialID", "FIWPID", "EstMHLibID", "UOMLUID", "Qty", "UpdatedBy" };
            string[] update_columns = { "FIWPMaterialID", "FIWPID", "EstMHLibID", "UOMLUID", "Qty", "UpdatedBy" };
            string[] delete_columns = { "FIWPMaterialID" };

            ds.Tables[0].TableName = TableName.FiwpMaterial;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.FiwpMaterial, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.FiwpMaterial;
            fiwpmaterial = (List<FiwpmaterialDTO>)DTOHelper.DeserializeDTOList(fiwpmaterial.GetType(), ds);

            // Return the data transfer object.
            return fiwpmaterial;
        }

        /// <summary>
        /// SaveFiwpequipForAssembleIWP
        /// </summary>
        /// <param name="fiwpequips"></param>
        /// <param name="fiwps"></param>
        /// <param name="documents"></param>
        /// <returns></returns>
        public List<FiwpequipDTO> SaveFiwpequipForAssembleIWP(List<FiwpequipDTO> fiwpequips, List<FiwpDTO> fiwps, string userId)
        {
            //TransactionScope scope = null;
            byte[] bytes = null;
            string fileType = Element.Reveal.DataLibrary.Utilities.FileType.EQUIPMENT;

            int iwpDocumentId = 0;
            int fileStoreId = 0;            
            string fileExtension = "jpg";            
            string fileName = fiwps[0].FiwpName + "_" + fileType; 

            //Get Default Info
            rptProjectCwaIwpDTO rptInfo = GetProjectCwaIwpByIwp(fiwps[0].FiwpID);

            //Check existence
            List<ComboBoxDTO> exists = GetIwpDocumentByIwpProjectFileType_Combo(fiwps[0].FiwpID, fiwps[0].ProjectID, fileType, "Y");
            if (exists != null && exists.Count > 0)
            {
                iwpDocumentId = exists[0].DataID;
                int.TryParse(exists[0].ExtraValue3, out fileStoreId);
                fileName = exists[0].DataName;
                fileExtension = exists[0].ExtraValue4;                
            }

            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{

            //Save user manipulated data
            if (fiwpequips != null && fiwpequips.Count > 0)
                fiwpequips = SaveFiwpequip(fiwpequips);
            //Get Latest data
            fiwpequips = GetFiwpEquipByFIWP(fiwps[0].FiwpID);
            //Generate Report
            bytes = GenerateReportForEquipment(fiwpequips, rptInfo);

            #region Upload Report File & Save File Info

            UpfileDTOS upFileCollection = new UpfileDTOS();
            List<FileStoreDTO> fileStoreList = new List<FileStoreDTO>();
            List<UploadedFileInfoDTO> uploadFileList = new List<UploadedFileInfoDTO>();

            FileStoreDTO fileStore = new FileStoreDTO();
            fileStore.FileTitle = fileName;
            fileStore.FileDescription = DateTime.Now.ToString();
            fileStore.FileCategory = Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT; 
            fileStore.FileTypeCode = fileType;
            fileStore.CreatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            fileStore.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            fileStore.FileStoreId = fileStoreId;
            fileStore.ProjectId = fiwps[0].ProjectID;

            fileStoreList.Add(fileStore);
            upFileCollection.fileStoreDTOList = fileStoreList;

            UploadedFileInfoDTO uploadFile = new UploadedFileInfoDTO();            
            uploadFile.Name = fileName;
            uploadFile.Size = bytes.Length;
            uploadFile.FileExtension = fileExtension;
            uploadFile.UploadedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.UploadedDate = DateTime.Now;
            uploadFile.CreatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.byteFile = bytes;
            uploadFile.UploadedFileInfoId = 0;
            uploadFile.FileStoreId = fileStoreId;            

            uploadFileList.Add(uploadFile);
            upFileCollection.uploadedFileDTOList = uploadFileList;

            upFileCollection = (new TrueTask.Common()).SaveSingleUploadFile(upFileCollection, userId);

            #endregion

            #region Save Report Document Info

            List<DocumentDTO> documents = new List<DocumentDTO>();

            DocumentDTO iwpDocument = new DocumentDTO();
            iwpDocument.DocumentID = iwpDocumentId;
            iwpDocument.FIWPID = fiwps[0].FiwpID;
            //iwpDocument.SPCollectionID = upFileCollection.uploadedFileDTOList[0].UploadedFileInfoId;
            iwpDocument.FileStoreId = upFileCollection.uploadedFileDTOList[0].FileStoreId;
            iwpDocument.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            iwpDocument.IsDisplayable = "Y";
            if (iwpDocument.DocumentID > 0)
                iwpDocument.DTOStatus = (int)RowStatusNo.Update;
            else
                iwpDocument.DTOStatus = (int)RowStatusNo.New;

            documents.Add(iwpDocument);            

            documents = SaveDocument(documents);

            #endregion

            //Update Assemble Step
            if (fiwps[0].DocEstablishedLUID != Element.Reveal.DataLibrary.Utilities.AssembleStep.APPROVER)
                fiwps = (new TrueTask.Build()).SaveIwp(fiwps);

            //    scope.Complete();
            //}

            return fiwpequips;
        }

        /// <summary>
        /// SaveFiwpMaterialForAssembleIWP
        /// </summary>
        /// <param name="fiwpmaterials"></param>
        /// <param name="fiwps"></param>
        /// <param name="documents"></param>
        /// <returns></returns>
        public List<FiwpmaterialDTO> SaveFiwpMaterialForAssembleIWP(List<FiwpmaterialDTO> fiwpmaterials, List<FiwpDTO> fiwps, string userId)
        {
            //TransactionScope scope = null;
            byte[] bytes = null;
            string fileType = Element.Reveal.DataLibrary.Utilities.FileType.CONSUMABLE;

            int iwpDocumentId = 0;
            int fileStoreId = 0;
            string fileExtension = "jpg";            
            string fileName = fiwps[0].FiwpName + "_" + fileType;

            //Get Default Info
            rptProjectCwaIwpDTO rptInfo = GetProjectCwaIwpByIwp(fiwps[0].FiwpID);

            //Check existence
            List<ComboBoxDTO> exists = GetIwpDocumentByIwpProjectFileType_Combo(fiwps[0].FiwpID, fiwps[0].ProjectID, fileType, "Y");
            if (exists != null && exists.Count > 0)
            {
                iwpDocumentId = exists[0].DataID;
                int.TryParse(exists[0].ExtraValue3, out fileStoreId);
                fileName = exists[0].DataName;
                fileExtension = exists[0].ExtraValue4;
            }

            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{

            //Save user manipulated data
            if (fiwpmaterials != null && fiwpmaterials.Count > 0)
                fiwpmaterials = SaveFiwpMaterial(fiwpmaterials);
            //Get Latest Data
            fiwpmaterials = (new TrueTask.Build()).GetFiwpMaterialByFIWP(fiwps[0].FiwpID, fiwps[0].ProjectID, "");
            //Generate Report
            bytes = GenerateReportForMaterial(fiwpmaterials, rptInfo);

            #region Upload Report File & Save File Info

            UpfileDTOS upFileCollection = new UpfileDTOS();
            List<FileStoreDTO> fileStoreList = new List<FileStoreDTO>();
            List<UploadedFileInfoDTO> uploadFileList = new List<UploadedFileInfoDTO>();

            FileStoreDTO fileStore = new FileStoreDTO();
            fileStore.FileTitle = fileName;
            fileStore.FileDescription = DateTime.Now.ToString();
            fileStore.FileCategory = Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT;
            fileStore.FileTypeCode = fileType;
            fileStore.CreatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            fileStore.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            fileStore.FileStoreId = fileStoreId;
            fileStore.ProjectId = fiwps[0].ProjectID;

            fileStoreList.Add(fileStore);
            upFileCollection.fileStoreDTOList = fileStoreList;

            UploadedFileInfoDTO uploadFile = new UploadedFileInfoDTO();            
            uploadFile.Name = fileName;
            uploadFile.Size = bytes.Length;
            uploadFile.FileExtension = fileExtension;
            uploadFile.UploadedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.UploadedDate = DateTime.Now;
            uploadFile.CreatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.byteFile = bytes;
            uploadFile.UploadedFileInfoId = 0;
            uploadFile.FileStoreId = fileStoreId;

            uploadFileList.Add(uploadFile);
            upFileCollection.uploadedFileDTOList = uploadFileList;

            upFileCollection = (new TrueTask.Common()).SaveSingleUploadFile(upFileCollection, userId);

            #endregion

            #region Save Report Document Info

            List<DocumentDTO> documents = new List<DocumentDTO>();

            DocumentDTO iwpDocument = new DocumentDTO();
            iwpDocument.DocumentID = iwpDocumentId;
            iwpDocument.FIWPID = fiwps[0].FiwpID;
            //iwpDocument.SPCollectionID = upFileCollection.uploadedFileDTOList[0].UploadedFileInfoId;
            iwpDocument.FileStoreId = upFileCollection.uploadedFileDTOList[0].FileStoreId;
            iwpDocument.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            iwpDocument.IsDisplayable = "Y";
            if (iwpDocument.DocumentID > 0)
                iwpDocument.DTOStatus = (int)RowStatusNo.Update;
            else
                iwpDocument.DTOStatus = (int)RowStatusNo.New;
            
            documents.Add(iwpDocument);

            documents = SaveDocument(documents);

            #endregion

            //Update Assemble Step
            if (fiwps[0].DocEstablishedLUID != Element.Reveal.DataLibrary.Utilities.AssembleStep.APPROVER)
                fiwps = (new TrueTask.Build()).SaveIwp(fiwps);

            //    scope.Complete();
            //}

            return fiwpmaterials;
        }

        /// <summary>
        /// SaveDocumentForAssembleIWP
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="fiwps"></param>
        /// <returns></returns>
        public List<DocumentDTO> SaveDocumentForAssembleIWP(List<FiwpDTO> fiwps, List<DocumentDTO> documents, string curStepCode, string userId, string webPath)
        {
            //TransactionScope scope = null;
            byte[] bytes = null;
            string fileType = string.Empty;

            //Check FileType
            switch (curStepCode)
            {
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.COVER:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.COVER;
                    break;
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.SAFETY_FORM:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.SAFETY_FORM;
                    break;
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.ITR:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.ITR;
                    break;
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.SPEC:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.SPEC;
                    break;
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.MOC:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.MOC;
                    break;
            }
            
            int iwpDocumentId = 0;
            int fileStoreId = 0;
            string fileExtension = "jpg";
            string fileName = fiwps[0].FiwpName + "_" + fileType;
            string coverImageUrl = string.Empty;

            //Get Default Info
            rptProjectCwaIwpDTO rptInfo = GetProjectCwaIwpByIwp(fiwps[0].FiwpID);

            //Check existence
            List<ComboBoxDTO> exists = GetIwpDocumentByIwpProjectFileType_Combo(fiwps[0].FiwpID, fiwps[0].ProjectID, fileType, "Y");
            if (exists != null && exists.Count > 0)
            {
                iwpDocumentId = exists[0].DataID;
                int.TryParse(exists[0].ExtraValue3, out fileStoreId);
                fileName = exists[0].DataName;
                fileExtension = exists[0].ExtraValue4;
            }

            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{

            //Save user manipulated data
            if (documents != null && documents.Count > 0)
            {
                coverImageUrl = string.IsNullOrEmpty(documents[0].LocationURL) ? "" : HttpContext.Current.Server.MapPath(documents[0].LocationURL.Replace(webPath, ""));
                documents[0].IsDisplayable = "N";
                documents = SaveDocument(documents);
            }

            //Generate Report
            if (curStepCode == Element.Reveal.DataLibrary.Utilities.AssembleStep.COVER)
                bytes = GenerateReportForCover(coverImageUrl, rptInfo);
            else
            {
                string listTitle = "List";
                List<ComboBoxDTO> combos = GetIwpDocumentByIwpProjectFileType_Combo(fiwps[0].FiwpID, fiwps[0].ProjectID, fileType, "N");
                List<ComboCodeBoxDTO> type = (new TrueTask.Common()).GetSigmaCodeByCodeCategory_Code_Combo(null, fileType);
                if (type != null && type.Count > 0)
                    listTitle = type[0].DataName;

                bytes = GenerateReportForCombo(combos, rptInfo, listTitle);
            }

            #region Upload Report File & Save File Info

            UpfileDTOS upFileCollection = new UpfileDTOS();
            List<FileStoreDTO> fileStoreList = new List<FileStoreDTO>();
            List<UploadedFileInfoDTO> uploadFileList = new List<UploadedFileInfoDTO>();

            FileStoreDTO fileStore = new FileStoreDTO();
            fileStore.FileTitle = fileName;
            fileStore.FileDescription = DateTime.Now.ToString();
            fileStore.FileCategory = Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT;
            fileStore.FileTypeCode = fileType;
            fileStore.CreatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            fileStore.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            fileStore.FileStoreId = fileStoreId;
            fileStore.ProjectId = fiwps[0].ProjectID;

            fileStoreList.Add(fileStore);
            upFileCollection.fileStoreDTOList = fileStoreList;

            UploadedFileInfoDTO uploadFile = new UploadedFileInfoDTO();            
            uploadFile.Name = fileName;
            uploadFile.Size = bytes.Length;
            uploadFile.FileExtension = fileExtension;
            uploadFile.UploadedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.UploadedDate = DateTime.Now;
            uploadFile.CreatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            uploadFile.byteFile = bytes;
            uploadFile.UploadedFileInfoId = 0;
            uploadFile.FileStoreId = fileStoreId;

            uploadFileList.Add(uploadFile);
            upFileCollection.uploadedFileDTOList = uploadFileList;

            upFileCollection = (new TrueTask.Common()).SaveSingleUploadFile(upFileCollection, userId);

            #endregion

            #region Save Report Document Info

            DocumentDTO iwpDocument = new DocumentDTO();
            iwpDocument.DocumentID = iwpDocumentId;
            iwpDocument.FIWPID = fiwps[0].FiwpID;
            //iwpDocument.SPCollectionID = upFileCollection.uploadedFileDTOList[0].UploadedFileInfoId;
            iwpDocument.FileStoreId = upFileCollection.uploadedFileDTOList[0].FileStoreId;
            iwpDocument.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            iwpDocument.IsDisplayable = "Y";            
            if (iwpDocument.DocumentID > 0)
                iwpDocument.DTOStatus = (int)RowStatusNo.Update;
            else
                iwpDocument.DTOStatus = (int)RowStatusNo.New;

            documents.Clear();
            documents.Add(iwpDocument);

            documents = SaveDocument(documents);

            #endregion

            //Update Assemble Step
            if (fiwps[0].DocEstablishedLUID != Element.Reveal.DataLibrary.Utilities.AssembleStep.APPROVER)
                fiwps = (new TrueTask.Build()).SaveIwp(fiwps);
                        
            //    scope.Complete();
            //}

            return documents;
        }

        public List<DocumentDTO> SaveDocumentWithOZformForAssembleIWP(List<FiwpDTO> fiwps, UpfileDTOS upFileCollection, string curStepCode, string userId)
        {
            //TransactionScope scope = null;
            //byte[] bytes = null;
            string fileType = string.Empty;

            //Check FileType
            switch (curStepCode)
            {
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.SUMMARY:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.SUMMARY;
                    break;
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.SAFETY_CHECK:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.SAFETY_CHECK;
                    break;
                case Element.Reveal.DataLibrary.Utilities.AssembleStep.SCAFFOLD_CHECK:
                    fileType = Element.Reveal.DataLibrary.Utilities.FileType.SCAFFOLD_CHECK;
                    break;                
            }

            int iwpDocumentId = 0;
            int fileStoreId = 0;
            //string fileExtension = "jpg";
            string fileName = fiwps[0].FiwpName + "_" + fileType;            

            //Get Default Info
            rptProjectCwaIwpDTO rptInfo = GetProjectCwaIwpByIwp(fiwps[0].FiwpID);

            //Check existence
            List<ComboBoxDTO> exists = GetIwpDocumentByIwpProjectFileType_Combo(fiwps[0].FiwpID, fiwps[0].ProjectID, fileType, "Y");
            if (exists != null && exists.Count > 0)
            {
                iwpDocumentId = exists[0].DataID;
                int.TryParse(exists[0].ExtraValue3, out fileStoreId);
                fileName = exists[0].DataName;
                //fileExtension = exists[0].ExtraValue4;
            }

            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{
                        
            #region Upload Report File & Save File Info

            if (upFileCollection.fileStoreDTOList == null || upFileCollection.fileStoreDTOList.Count <= 0)
            {
                List<FileStoreDTO> fileStoreList = new List<FileStoreDTO>();
                //List<UploadedFileInfoDTO> uploadFileList = new List<UploadedFileInfoDTO>();

                FileStoreDTO fileStore = new FileStoreDTO();
                fileStore.FileTitle = fileName;
                fileStore.FileDescription = DateTime.Now.ToString();
                fileStore.FileCategory = Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT; 
                fileStore.FileTypeCode = fileType;
                fileStore.CreatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
                fileStore.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
                fileStore.FileStoreId = fileStoreId;
                fileStore.ProjectId = fiwps[0].ProjectID;

                fileStoreList.Add(fileStore);
                upFileCollection.fileStoreDTOList = fileStoreList;
            }
            //UploadedFileInfoDTO uploadFile = new UploadedFileInfoDTO();            
            //uploadFile.Name = fileName;
            //uploadFile.Size = bytes.Length;
            //uploadFile.FileExtension = fileExtension;
            //uploadFile.UploadedBy = fiwps[0].UpdatedBy;
            //uploadFile.UploadedDate = DateTime.Now;
            //uploadFile.CreatedBy = fiwps[0].UpdatedBy;
            //uploadFile.UpdatedBy = fiwps[0].UpdatedBy;
            ////uploadFile.byteFile = bytes;
            //uploadFile.UploadedFileInfoId = 0;
            //uploadFile.FileStoreId = fileStoreId;

            //uploadFileList.Add(uploadFile);
            //upFileCollection.uploadedFileDTOList = uploadFileList;

            upFileCollection = (new TrueTask.Common()).SaveMultiUploadFile(upFileCollection, userId, fileName);

            #endregion

            #region Save Report Document Info

            List<DocumentDTO> documents = new List<DocumentDTO>();
            #region "old code _ uploadedFileInfo"
            //foreach (UploadedFileInfoDTO uploadFile in upFileCollection.uploadedFileDTOList)
            //{
            //    DocumentDTO iwpDocument = new DocumentDTO();
            //    //iwpDocument.DocumentID = iwpDocumentId;
            //    iwpDocument.FIWPID = fiwps[0].FiwpID;
            //    iwpDocument.SPCollectionID = uploadFile.UploadedFileInfoId;            
            //    iwpDocument.UpdatedBy = fiwps[0].UpdatedBy;

            //    if (uploadFile.FileExtension.ToLower() == "jpg")
            //        iwpDocument.IsDisplayable = "Y";
            //    else
            //        iwpDocument.IsDisplayable = "N";  

            //    //if (iwpDocument.DocumentID > 0)
            //    //  iwpDocument.DTOStatus = (int)RowStatusNo.Update;
            //    //else
            //    iwpDocument.DTOStatus = (int)RowStatusNo.New;
            
            //    documents.Add(iwpDocument);
            //}
            #endregion
            
            DocumentDTO iwpDocument = new DocumentDTO();
            iwpDocument.DocumentID = iwpDocumentId;
            iwpDocument.FIWPID = fiwps[0].FiwpID;
            iwpDocument.FileStoreId = upFileCollection.uploadedFileDTOList[0].FileStoreId;
            iwpDocument.UpdatedBy = string.IsNullOrEmpty(fiwps[0].UpdatedBy) ? userId : fiwps[0].UpdatedBy;
            iwpDocument.IsDisplayable = "Y";
            if (iwpDocument.DocumentID > 0)
                iwpDocument.DTOStatus = (int)RowStatusNo.Update;
            else
            iwpDocument.DTOStatus = (int)RowStatusNo.New;

            documents.Add(iwpDocument);

            documents = SaveDocument(documents);

            #endregion

            //Update Assemble Step
            if (fiwps[0].DocEstablishedLUID != Element.Reveal.DataLibrary.Utilities.AssembleStep.APPROVER)
                fiwps = (new TrueTask.Build()).SaveIwp(fiwps);

            //    scope.Complete();
            //}

            return documents;
        }

        #region "Generate Report"

        private byte[] GenerateReportForCover(string imageUrl, rptProjectCwaIwpDTO rptInfo)
        {   
            byte[] bytes = null;

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string DeviceInfo = "<DeviceInfo>" +
                 "  <OutputFormat>JPEG</OutputFormat>" +
                 "  <EndPage>1</EndPage>" +
                 "  <PageWidth>17in</PageWidth>" +
                 "  <PageHeight>11in</PageHeight>" +
                 "  <MarginTop>0in</MarginTop>" +
                 "  <MarginLeft>0in</MarginLeft>" +
                 "  <MarginRight>0in</MarginRight>" +
                 "  <MarginBottom>0in</MarginBottom>" +
                 "</DeviceInfo>";

            List<ReportParameter> paramList = new List<ReportParameter>();
            
            //Default Parameter
            paramList = GetReportParams(rptInfo);

            //Cover Image Parameter
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var imageBytes = (new TrueTask.Common()).FileToByteArray(imageUrl); //System.IO.File.ReadAllBytes(imageUrl);

                if (imageBytes != null)
                    imageUrl = Convert.ToBase64String(imageBytes);
            }
            paramList.Add(new ReportParameter("par_imageurl", imageUrl));

            LocalReport report = new LocalReport();

            report.ReportPath = @".\Prev\Resource\rdl\RPTCreateFIWPP1.rdl";
            report.EnableExternalImages = true;
            report.SetParameters(paramList); 
            report.DataSources.Clear();

            report.DataSources.Add(new ReportDataSource("CostCode", new List<CostcodeDTO>()));

            bytes = report.Render("Image", DeviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            
            return bytes;
        }

        private byte[] GenerateReportForMaterial(List<FiwpmaterialDTO> fiwpmaterials, rptProjectCwaIwpDTO rptInfo)
        {
            byte[] bytes = null;

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string DeviceInfo = "<DeviceInfo>" +
                 "  <OutputFormat>JPEG</OutputFormat>" +
                 "  <EndPage>1</EndPage>" +
                 "  <PageWidth>17in</PageWidth>" +
                 "  <PageHeight>11in</PageHeight>" +
                 "  <MarginTop>0in</MarginTop>" +
                 "  <MarginLeft>0in</MarginLeft>" +
                 "  <MarginRight>0in</MarginRight>" +
                 "  <MarginBottom>0in</MarginBottom>" +
                 "</DeviceInfo>";

            List<ReportParameter> paramList = new List<ReportParameter>();

            //Default Parameter
            paramList = GetReportParams(rptInfo);

            if (fiwpmaterials == null || fiwpmaterials.Count <= 0)
                fiwpmaterials = new List<FiwpmaterialDTO>();

            LocalReport report = new LocalReport();

            report.ReportPath = @".\Prev\Resource\rdl\RPTCreateFIWPP3.rdl";
            report.EnableExternalImages = true;
            report.SetParameters(paramList);
            report.DataSources.Clear();
            //Material DataSource
            report.DataSources.Add(new ReportDataSource("rptMaterial", fiwpmaterials));

            bytes = report.Render("Image", DeviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            return bytes;
        }

        private byte[] GenerateReportForEquipment(List<FiwpequipDTO> fiwpequips, rptProjectCwaIwpDTO rptInfo)
        {
            byte[] bytes = null;

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string DeviceInfo = "<DeviceInfo>" +
                 "  <OutputFormat>JPEG</OutputFormat>" +
                 "  <EndPage>1</EndPage>" +
                 "  <PageWidth>8in</PageWidth>" +
                 "  <PageHeight>11in</PageHeight>" +
                 "  <MarginTop>0in</MarginTop>" +
                 "  <MarginLeft>0in</MarginLeft>" +
                 "  <MarginRight>0in</MarginRight>" +
                 "  <MarginBottom>0in</MarginBottom>" +
                 "</DeviceInfo>";

            List<ReportParameter> paramList = new List<ReportParameter>();

            //Parameter
            paramList = GetReportParams(rptInfo);
            
            if (fiwpequips == null || fiwpequips.Count <= 0)
                fiwpequips = new List<FiwpequipDTO>();

            LocalReport report = new LocalReport();

            report.ReportPath = @".\Prev\Resource\rdl\RPTEquipmentList.rdl";
            report.EnableExternalImages = true;
            report.SetParameters(paramList);
            report.DataSources.Clear();
            //Material DataSource
            report.DataSources.Add(new ReportDataSource("rptEquipment", fiwpequips));

            bytes = report.Render("Image", DeviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            return bytes;
        }

        private byte[] GenerateReportForCombo(List<ComboBoxDTO> combos, rptProjectCwaIwpDTO rptInfo, string listTitle)
        {
            byte[] bytes = null;

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string DeviceInfo = "<DeviceInfo>" +
                 "  <OutputFormat>JPEG</OutputFormat>" +
                 "  <EndPage>1</EndPage>" +
                 "  <PageWidth>8in</PageWidth>" +
                 "  <PageHeight>11in</PageHeight>" +
                 "  <MarginTop>0in</MarginTop>" +
                 "  <MarginLeft>0in</MarginLeft>" +
                 "  <MarginRight>0in</MarginRight>" +
                 "  <MarginBottom>0in</MarginBottom>" +
                 "</DeviceInfo>";

            List<ReportParameter> paramList = new List<ReportParameter>();

            //Default Parameter
            paramList = GetReportParams(rptInfo);
            //Defined Parameter For Combo 
            paramList.Add(new ReportParameter("par_title", string.IsNullOrEmpty(listTitle) ? "" : listTitle)); //List Title

            if (combos == null || combos.Count <= 0)
                combos = new List<ComboBoxDTO>();

            LocalReport report = new LocalReport();

            report.ReportPath = @".\Prev\Resource\rdl\RPTAssembleList.rdl";
            report.EnableExternalImages = true;
            report.SetParameters(paramList);
            report.DataSources.Clear();
            //Material DataSource
            report.DataSources.Add(new ReportDataSource("rptCombobox", combos));

            bytes = report.Render("Image", DeviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            return bytes;
        }

        private List<ReportParameter> GetReportParams(rptProjectCwaIwpDTO rptInfo)
        {
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("par_fiwp", string.IsNullOrEmpty(rptInfo.FiwpName) ? "" : rptInfo.FiwpName)); //FIWP 
            paramList.Add(new ReportParameter("par_schid", string.IsNullOrEmpty(rptInfo.ProjectScheduleName) ? "" : rptInfo.ProjectScheduleName)); //SchID
            paramList.Add(new ReportParameter("txtTitle", string.IsNullOrEmpty(rptInfo.Description) ? "" : rptInfo.Description)); //TITLE
            paramList.Add(new ReportParameter("par_client", string.IsNullOrEmpty(rptInfo.ClientCompanyName) ? "" : rptInfo.ClientCompanyName)); //Client
            paramList.Add(new ReportParameter("par_project", string.IsNullOrEmpty(rptInfo.ClientProjectName) ? "" : rptInfo.ClientProjectName)); //Client Project
            paramList.Add(new ReportParameter("par_job", string.IsNullOrEmpty(rptInfo.ProjectName) ? "" : rptInfo.ProjectName)); //Ledcor Project
            paramList.Add(new ReportParameter("par_ewp", string.IsNullOrEmpty(rptInfo.CwaName) ? "" : rptInfo.CwaName)); //CWA Ref            

            //Logo
            string logoUrl = string.Empty;            
            var logoBytes = (new TrueTask.Common()).FileToByteArray(HttpContext.Current.Server.MapPath(@"..\Prev\Resource\images\element_2x07_02.png"));
            //var logoBytes = (new TrueTask.Common()).FileToByteArray(HttpContext.Current.Server.MapPath(@".\Resource\images\element_2x07_02.png")); 
            if (logoBytes != null)
                logoUrl = Convert.ToBase64String(logoBytes);

            paramList.Add(new ReportParameter("par_logoUrl", logoUrl)); //Logo
                        
            return paramList;
        }

        #endregion

        public int generateRptTest(int div, string userId)
        {
            byte[] bytes = null;
            rptProjectCwaIwpDTO rptInfo = GetProjectCwaIwpByIwp(1);

            UserInfoDTO userInfo = new UserInfoDTO();
            userInfo = (new TrueTask.Common()).GetUserInfo(userId);
            
            switch (div)
            {
                case 1:
                    bytes = GenerateReportForCover("", rptInfo);
                    break;
                case 2:
                    List<FiwpequipDTO> equips = new List<FiwpequipDTO>();
                    for (int i = 1; i < 10; i++)
                    {
                        FiwpequipDTO equip = new FiwpequipDTO();
                        equip.FiwpEquipID = i;
                        equip.EquipmentName = i.ToString();
                        equip.EquipDesc = i.ToString();
                        equip.StartUseDate = DateTime.Now;
                        equip.FinishUseDate = DateTime.Now;
                        equips.Add(equip);
                    }
                    bytes = GenerateReportForEquipment(equips, rptInfo);
                    break;
                case 3:
                    List<FiwpmaterialDTO> materials = new List<FiwpmaterialDTO>();
                    for (int i = 1; i < 10; i++)
                    {
                        FiwpmaterialDTO material = new FiwpmaterialDTO();
                        material.FIWPMaterialID = i;
                        material.PartNo = i.ToString();
                        material.Vendor = i.ToString();
                        material.Qty = Convert.ToDecimal(i);                        
                        materials.Add(material);
                    }
                    bytes = GenerateReportForMaterial(materials, rptInfo);
                    break;
                case 4:
                    List<ComboBoxDTO> combos = new List<ComboBoxDTO>();
                    for (int i = 1; i < 10; i++)
                    {
                        ComboBoxDTO combo = new ComboBoxDTO();
                        combo.DataID = i;
                        combo.DataName = i.ToString();
                        combo.ExtraValue1 = i.ToString();
                        combo.ExtraValue2 = i.ToString();
                        combo.ExtraValue3 = i.ToString();
                        combos.Add(combo);
                    }
                    bytes = GenerateReportForCombo(combos, rptInfo, "List");
                    break;                
            }

            string rootPath = "/SigmaStorage/";                        
            string childPath = "SigmaDoc/" + userInfo.CompanyName + "/" + userInfo.CurrentProjectId + "/";

            int newRevision = 0;
            
            string uploadFolder = HttpContext.Current.Server.MapPath(rootPath + childPath + newRevision.ToString() + "/");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            string filePath = Path.Combine(uploadFolder, "TEST.jpg");

            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            // Writes a block of bytes to this stream using data from
            // a byte array.
            fs.Write(bytes, 0, bytes.Length);

            fs.Close();

            return 1;
        }
    }
}
