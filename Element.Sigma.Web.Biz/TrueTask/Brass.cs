using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Element.Shared.Common;
using Element.Reveal.DataLibrary;
using System.Transactions;
using Microsoft.Reporting.WebForms;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class Brass
    {
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<DailybrassDTO> GetDailybrassByForemanWorkdate(int projectId, string disciplineCode, string foremanId, DateTime workDate)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode),
                    new SqlParameter("@foremanId", foremanId),
                    new SqlParameter("@workDate", workDate)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDailybrassByForemanWorkdate", parameters);  //sp_get_dailybrass_by_personnel_workdate
            List<DailybrassDTO> result = DTOHelper.DataTableToListDTO<DailybrassDTO>(ds);
            return result;            
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<DailybrasssignDTO> GetDailybrasssignByDailyBrass(int dailybrassId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@dailybrassId", dailybrassId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDailybrasssignByDailybrass", parameters);  //sp_get_dailybrasssign_by_dailybrass
            List<DailybrasssignDTO> result = DTOHelper.DataTableToListDTO<DailybrasssignDTO>(ds);
            return result;
        }

        #region Save
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public List<DailybrasssignDTO> SaveDailybrasssign(List<DailybrasssignDTO> dailybrasssign)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(dailybrasssign.GetType(), dailybrasssign);

            string insert_sp_name = "tsp_AddDailybrasssign";  //sp_insert_dailybrasssign
            string update_sp_name = "tsp_UpdateDailybrasssign";  //sp_update_dailybrasssign
            string delete_sp_name = "tsp_RemoveDailybrasssign";  //sp_delete_dailybrasssign

            string[] insert_columns = { "DailyBrassSignID", "DailyBrassId", "PersonnelId", "SignInDate", "SignOutDate", "ToolboxSignedDate", "NfcUid", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] update_columns = { "DailyBrassSignID", "DailyBrassId", "PersonnelId", "SignInDate", "SignOutDate", "ToolboxSignedDate", "NfcUid", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] delete_columns = { "DailyBrassSignID" };

            ds = DAHelper.UpdateDataTableBySqlConnection(connStr, ds, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatusNo.None);

            dailybrasssign = (List<DailybrasssignDTO>)DTOHelper.DeserializeDTOList(dailybrasssign.GetType(), ds);

            // Return the data transfer object.
            return dailybrasssign;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public List<DailytoolboxDTO> SaveDailybrasstoolbox(List<DailytoolboxDTO> dailytoolbox)
        {
            TransactionScope scope = null;

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                dailybrasstoolboxSave(dailytoolbox.Where(x => x.DTOStatus == (int)RowStatus.Delete).ToList());

                dailytoolbox = dailybrasstoolboxSave(dailytoolbox.Where(x => x.DTOStatus == (int)RowStatus.New).ToList());

                scope.Complete();
            }

            return dailytoolbox;
        }

        private List<DailytoolboxDTO> dailybrasstoolboxSave(List<DailytoolboxDTO> dailytoolbox)
        {
            if (dailytoolbox.Count() > 0)
            {
                // Get connection string
                string connStr = ConnStrHelper.getDbConnString();

                DataSet ds = new DataSet();

                ds = DTOHelper.SerializeDTOList(dailytoolbox.GetType(), dailytoolbox);

                string insert_sp_name = "tsp_AddDailybrasstoolbox";  //sp_insert_dailytoolbox
                string update_sp_name = "tsp_UpdateDailybrasstoolbox";
                string delete_sp_name = "tsp_RemoveDailybrasstoolbox";


                string[] insert_columns = { "DailyToolboxID", "DailyBrassID", "SPCollectionID", "DocumentName", "DocumentVersion" };
                string[] update_columns = { "DailyToolboxID", "DailyBrassID", "SPCollectionID", "DocumentName", "DocumentVersion" };
                string[] delete_columns = { "DailyToolboxID" };

                ds = DAHelper.UpdateDataTableBySqlConnection(connStr, ds, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatusNo.None);

                dailytoolbox = (List<DailytoolboxDTO>)DTOHelper.DeserializeDTOList(dailytoolbox.GetType(), ds);
            }
            // Return the data transfer object.
            return dailytoolbox;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public List<DailybrassDTO> SaveDailybrass(List<DailybrassDTO> dailybrass)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(dailybrass.GetType(), dailybrass);

            string insert_sp_name = "tsp_AddDailybrass";  //sp_insert_dailybrass
            string update_sp_name = "tsp_UpdateDailybrass";  //sp_update_dailybrass
            string delete_sp_name = "tsp_DeleteDailybrass";  //sp_delete_dailybrass

            string[] insert_columns = { "DailyBrassID", "ProjectId", "ForemanId", "DisciplineCode", "WorkDate", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] update_columns = { "DailyBrassID", "ProjectId", "ForemanId", "DisciplineCode", "WorkDate", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] delete_columns = { "DailyBrassID" };

            ds = DAHelper.UpdateDataTableBySqlConnection(connStr, ds, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatusNo.None);

            dailybrass = (List<DailybrassDTO>)DTOHelper.DeserializeDTOList(dailybrass.GetType(), ds);

            // Return the data transfer object.
            return dailybrass;
        }


        #endregion Save End

        public SigmaResultTypeDTO SaveCrewAttendance_Rpt(int dailybrassId, string sigmauserId)
        {
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            DataSet ds = GetCrewAttendance_Rpt(dailybrassId);
            int projectId = 0;
            List<rptDailyBrassInOutDTO> brassList = DTOHelper.DataTableToListDTO<rptDailyBrassInOutDTO>(ds, 0);
            List<rptCrewAttendanceHeader> headerList = DTOHelper.DataTableToListDTO<rptCrewAttendanceHeader>(ds, 1);

            if (brassList.Count > 0 && headerList.Count > 0)
            {
                projectId = headerList[0].ProjectId;
                List<ReportParameter> Params = new List<ReportParameter>();
                Params.Add(new ReportParameter("DailyBrassID", dailybrassId.ToString()));
                Params.Add(new ReportParameter("ProjectID", projectId.ToString()));
                //Params.Add(new ReportParameter("imgurl", @".\Resource\images\Logo.png"));

                LocalReport report = new LocalReport();
                report.ReportPath = @"..\Element.Sigma.Web.Biz\TrueTask\Resource\rdl\RPTCrewAttendance.rdl";
                report.EnableExternalImages = true;
                report.SetParameters(Params);
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dsDailyBrassSign", brassList));
                report.DataSources.Add(new ReportDataSource("dsHeader", headerList));

                byte[] bytes = report.Render("Image");
                string fileName = headerList[0].ForemanId + '_' + dailybrassId.ToString();

                #region Upload Report File & Save File Info

                string fileType = Element.Reveal.DataLibrary.Utilities.FileType.CREW_ATTENDANCE;
                int dailyBrassReportId = 0;
                int fileStoreId = 0;
                string fileExtension = "jpg";

                //Check existence
                List<ComboBoxDTO> exists = GetDailybrassreportByDailybrassFiletype_Combo(dailybrassId, fileType);
                if (exists != null && exists.Count > 0)
                {
                    dailyBrassReportId = exists[0].DataID;
                    int.TryParse(exists[0].ExtraValue3, out fileStoreId);
                    fileName = exists[0].DataName;
                    fileExtension = exists[0].ExtraValue4;
                }

                UpfileDTOS upFileCollection = new UpfileDTOS();
                List<FileStoreDTO> fileStoreList = new List<FileStoreDTO>();
                List<UploadedFileInfoDTO> uploadFileList = new List<UploadedFileInfoDTO>();

                FileStoreDTO fileStore = new FileStoreDTO();
                fileStore.FileTitle = fileName;
                fileStore.FileDescription = DateTime.Now.ToString();
                fileStore.FileCategory = Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT;
                fileStore.FileTypeCode = fileType;
                fileStore.CreatedBy = sigmauserId;
                fileStore.UpdatedBy = sigmauserId;
                fileStore.FileStoreId = fileStoreId;
                fileStore.ProjectId = projectId;
                fileStoreList.Add(fileStore);
                upFileCollection.fileStoreDTOList = fileStoreList;

                UploadedFileInfoDTO uploadFile = new UploadedFileInfoDTO();
                uploadFile.Name = fileName;
                uploadFile.Size = bytes.Length;
                uploadFile.FileExtension = fileExtension;
                uploadFile.UploadedBy = sigmauserId;
                uploadFile.UploadedDate = DateTime.Now;
                uploadFile.CreatedBy = sigmauserId;
                uploadFile.UpdatedBy = sigmauserId;
                uploadFile.byteFile = bytes;
                uploadFile.UploadedFileInfoId = 0;
                uploadFile.FileStoreId = fileStoreId;
                uploadFileList.Add(uploadFile);
                upFileCollection.uploadedFileDTOList = uploadFileList;

                upFileCollection = (new TrueTask.Common()).SaveSingleUploadFile(upFileCollection, sigmauserId);

                #endregion

                #region Save Report Document Info

                List<DailybrassreportDTO> reportDTOList = new List<DailybrassreportDTO>();

                DailybrassreportDTO reportDTO = new DailybrassreportDTO();
                reportDTO.DailyBrassReportId = dailyBrassReportId;
                reportDTO.DailyBrassId = dailybrassId;
                reportDTO.UploadedFileInfoId = upFileCollection.uploadedFileDTOList[0].UploadedFileInfoId;
                reportDTO.UpdatedBy = sigmauserId;
                reportDTO.DTOStatus = (int)RowStatusNo.New;
                reportDTOList.Add(reportDTO);

                reportDTOList = SaveDailyBrassReport(reportDTOList);

                #endregion

                result.IsSuccessful = true;
            }
            else
            {
                result.AffectedRow = -1;
                result.ErrorCode = "";
                result.ErrorMessage = "no data";
                result.IsSuccessful = false;
            }

            return result;

        }

        public DataSet GetCrewAttendance_Rpt(int dailybrassId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@dailybrassId", dailybrassId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_RptCrewAttendance", parameters);  //sp_rpt_get_dailybrasssign_by_dailybrass
            return ds;

        }

        public SigmaResultTypeDTO SaveTimeAndProgress_Rpt(int dailybrassId, string sigmauserId)
        {
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();

            return result;
        }

        public List<ComboBoxDTO> GetDailybrassreportByDailybrassFiletype_Combo(int dailybrassId, string fileTypeCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@dailybrassId", dailybrassId),
                    new SqlParameter("@FileTypeCode", fileTypeCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDailybrassreportByDailybrassFileType", parameters);
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        public List<DailybrassreportDTO> SaveDailyBrassReport(List<DailybrassreportDTO> DailyBrassReport)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(DailyBrassReport.GetType(), DailyBrassReport);

            string insert_sp_name = "tsp_AddDailybrassreport";
            string update_sp_name = "tsp_UpdateDailybrassreport";
            string delete_sp_name = "tsp_RemoveDailybrassreport";
  
            string[] insert_columns = { "DailyBrassReportId", "DailyBrassId", "DailyBrassReportCode", "UploadedFileInfoId", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] update_columns = { "DailyBrassReportId", "DailyBrassId", "DailyBrassReportCode", "UploadedFileInfoId", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] delete_columns = { "DailyBrassReportId" };

            ds = DAHelper.UpdateDataTableBySqlConnection(connStr, ds, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatusNo.None);

            DailyBrassReport = (List<DailybrassreportDTO>)DTOHelper.DeserializeDTOList(DailyBrassReport.GetType(), ds);

            // Return the data transfer object.
            return DailyBrassReport;                
        }

    }
}
