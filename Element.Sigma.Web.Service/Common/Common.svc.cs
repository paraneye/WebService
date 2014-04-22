using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Collections.Generic;
using System.ServiceModel.Web;
using Element.Shared.Common;
using Element.Sigma.Web.Biz;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.ProjectSettings;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using System.ServiceModel.Activation;

namespace Element.Sigma.Web.Service.Common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Common" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Common.svc or Common.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Common : ICommon
    {
  
        #region UploadFile
        public SigmaResultType GetUploadedFileInfo(string uploadedFileInfoId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                result = uploadedFileInfoMgr.GetUploadedFileInfo(uploadedFileInfoId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ListUploadedFileInfo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                string s_option = queryStr["s_option"];
                string s_key = queryStr["s_key"];
                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                result = uploadedFileInfoMgr.ListUploadedFileInfo(offset, max, s_option, s_key, o_option, o_desc);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType AddUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                result = uploadedFileInfoMgr.AddUploadedFileInfo(objUploadedFileInfo);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType UpdateUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType RemoveUploadedFileInfo(TypeUploadedFileInfo objUploadedFileInfo)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                result = uploadedFileInfoMgr.RemoveUploadedFileInfo(objUploadedFileInfo);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType MultiUploadedFileInfo(List<TypeUploadedFileInfo> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                UploadedFileInfoMgr uploadedFileInfoMgr = new UploadedFileInfoMgr();
                result = uploadedFileInfoMgr.MultiUploadedFileInfo(listObj);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }


        #endregion

        #region ImportFile

        public SigmaResultType ImportFile()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string fileType = queryStr["filetype"];
                string filePath = queryStr["filepath"];

                //string rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                //string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"];

                string rootPath = ConfigMgr.GetImportFilePath();

                filePath = rootPath + filePath;
                
                //fileType = "DrawingImage";

                // ImportFile
                switch (fileType)
                {
                    case "Drawing":
                        //importDrawing importDrawing = new ImportDrawing();
                        ImportDrawingMgr importDrawing = new ImportDrawingMgr();
                        result = importDrawing.AddDrawing(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "DrawingImage":
                        //ImportDrawing importDrawingImage = new ImportDrawing();
                        ImportDrawingMgr importDrawingImage = new ImportDrawingMgr();
                        //result = importDrawingImage.AddDrawingImage(filePath, targetPath);
                        result = importDrawingImage.AddDrawingImage(filePath, ConfigMgr.GetTargetPath());
                        break;
                    case "MTO":
                        ImportMgr importMgr = new ImportMgr();
                        result = importMgr.ImportMTOFromExcel(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "CostCode":
                        CostCodeMgr costcodeMgr = new CostCodeMgr();
                        result = costcodeMgr.ImportCostCodeFromExcel(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "ProjectCostCode":
                        CostCodeMgr projectcostcodeMgr = new CostCodeMgr();
                        result = projectcostcodeMgr.ImportProjectCostCodeFromExcel(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "ClientCostCode":
                        CostCodeMgr clientcostcodeMgr = new CostCodeMgr();
                        result = clientcostcodeMgr.ImportClientCostCodeFromExcel(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "HR":
                        PersonnelMgr personnelMgr = new PersonnelMgr();
                        result = personnelMgr.ImportPersonnelFromExcel(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "User":
                        SigmaUserMgr sigmauserMgr = new SigmaUserMgr();
                        result = sigmauserMgr.ImportSigmaUserFromExcel(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "MeterialLibrary":
                        ImportMgr importMeterial = new ImportMgr();
                        result = importMeterial.ImportMeterialLib(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "EquipmentLibrary":
                        ImportMgr importEquipment = new ImportMgr();
                        result = importEquipment.ImportEquipmentLib(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "ConsumableLibrary":
                        ImportMgr importConsumable = new ImportMgr();
                        result = importConsumable.ImportConsumableLib(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    case "DrawingType":
                        ImportMgr importDrawingType = new ImportMgr();
                        result = importDrawingType.ImportDrawingTypeLib(filePath, ConfigMgr.GetExportFilePath());
                        break;
                    default:
                        break;
                }
                return result;
                
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }
        
        #endregion

        #region ImportHistory
        
        public SigmaResultType ListImportHistory(string ImportCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                string s_option = queryStr["s_option"];
                string s_key = queryStr["s_key"];
                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                ImportHistoryMgr importHistoryMgr = new ImportHistoryMgr();
                result = importHistoryMgr.ListImportHistory(ImportCategory, offset, max, s_option, s_key, o_option, o_desc);
                return result;
            }
            catch (Exception ex)
            {
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType AddImportHistory(TypeImportHistory objImportHistory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ImportHistoryMgr importHistoryMgr = new ImportHistoryMgr();
                result = importHistoryMgr.AddImportHistory(objImportHistory);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType UpdateImportHistory(TypeImportHistory objImportHistory)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType RemoveImportHistory(TypeImportHistory objImportHistory)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ImportHistoryMgr importHistoryMgr = new ImportHistoryMgr();
                result = importHistoryMgr.RemoveImportHistory(objImportHistory);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType MultiImportHistory(List<TypeImportHistory> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ImportHistoryMgr importHistoryMgr = new ImportHistoryMgr();
                result = importHistoryMgr.MultiImportHistory(listObj);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }
        #endregion

        #region ComboBox

        public SigmaResultType CostCodeCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCostCodeCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }


        public SigmaResultType CustomFieldCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCustomFieldCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType DisciplinesCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetDisciplineCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType DisciplinesComboByProjectId(string projectId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetDisciplineComboByProjectId(projectId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType CwpCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCwpCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType IwpCombo(string cwpId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetIwpCombo(cwpId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType DrawingNumberCombo(string cwpId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetDrawingNumberCombo(Int32.Parse(cwpId));
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }


        public SigmaResultType TaskCategoryCombo(string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetTaskCategoryCombo(disciplineCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType TaskCategoryByCwpId(string cwpid)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetTaskCategoryByCwpIdCombo(cwpid);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType TaskTypeCombo(string taskCategoryId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetTaskTypeCombo(taskCategoryId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ProgressStepCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
              
                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@CwpId");
                s_option.Add("@TaskCategoryId");
                s_option.Add("@TaskTypeId");
                s_key.Add(queryStr["CwpId"]);
                s_key.Add(queryStr["TaskCategoryId"]);
                s_key.Add(queryStr["TaskTypeId"]);

                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetProgressStepCombo(s_option, s_key);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ProgressTypeCombo(string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetProgressTypeCombo(disciplineCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ProgressTypeComboByCwpId(string cwpId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetProgressTypeComboByCwpId(cwpId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType UomCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetSigmaCodeCombo("UOM");
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType DivisionCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetSigmaCodeCombo("ROLE_DIVISION_TYPE");
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType PersonnelTypeCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetSigmaCodeCombo("PERSONNEL_TYPE");
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType CompanyCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCompanyCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType CompanyAllCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCompanyAllCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType CompanyByCompanyTypeCodeCombo(string companyTypeCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCompanyByCompanyTypeCodeCombo(companyTypeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType CompanyTypeCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCompanyTypeCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType SigmaRoleCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetSigmaRoleCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType SigmaUserCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetSigmaUserCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType SigmaUserForProjectCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetSigmaUserForProjectCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType EquipmentCodeMainCombo(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetEquipmentCodeCombo(codeCategory);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType EquipmentCodeSubCombo(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetEquipmentCodeCombo(codeCategory);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType EquipmentThirdLevelCombo(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetEquipmentThirdLevelCombo(codeCategory);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType DrawingType()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetDrawingType();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType CountryCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCountryCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType CountyCombo(string country)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetCountyCombo(country);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ProjectCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetProjectCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType DefaultProjectCombo()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComboBoxMgr comboBoxMgr = new ComboBoxMgr();
                result = comboBoxMgr.GetDefaultProjectCombo();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        #endregion ComboBox

        #region Admin Tools

        public SigmaResultType GetSigmaLog(string id)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                LogMgr LogMgr = new LogMgr();
                result = LogMgr.GetSigmaLog(id);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ListSigmaLog()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                string s_option = queryStr["s_option"];
                string s_key = queryStr["s_key"];
                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                LogMgr LogMgr = new LogMgr();
                result = LogMgr.ListSigmaLog(offset, max, s_option, s_key, o_option, o_desc);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType AddSigmaLog(TypeSigmaLog objSigmaLog)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                LogMgr LogMgr = new LogMgr();
                result = LogMgr.AddSigmaLog(objSigmaLog);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType UpdateSigmaLog(TypeSigmaLog objSigmaLog)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType RemoveSigmaLog(TypeSigmaLog objSigmaLog)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                LogMgr LogMgr = new LogMgr();
                result = LogMgr.RemoveSigmaLog(objSigmaLog);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType MultiSigmaLog(List<TypeSigmaLog> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                LogMgr LogMgr = new LogMgr();
                result = LogMgr.MultiSigmaLog(listObj);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        #endregion

        #region MessageBox

        public SigmaResultType GetMessageBox(string msgTypeCode, string msgSeq)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                MessageBoxMgr messageBoxMgr = new MessageBoxMgr();
                result = messageBoxMgr.GetMessageBox(msgTypeCode, msgSeq);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        //public SigmaResultType ListMessageBox()
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
        //        result = messageBoxMgr.ListCompany(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log Exception
        //        ExceptionHelper.logException(ex);
        //        result.IsSuccessful = false;
        //        result.ErrorMessage = ex.Message;
        //        return result;
        //    }
        //}

        public SigmaResultType ListMessageBoxBySigmaUserId()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                MessageBoxMgr messageBoxMgr = new MessageBoxMgr();
                result = messageBoxMgr.ListMessageBoxBySigmaUserId();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        //public SigmaResultType AddMessageBox(TypeMessageBox objMessageBox)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        MessageBoxMgr messageBoxMgr = new MessageBoxMgr();
        //        result = messageBoxMgr.AddMessageBox(objMessageBox);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log Exception
        //        ExceptionHelper.logException(ex);
        //        result.IsSuccessful = false;
        //        result.ErrorMessage = ex.Message;
        //        return result;
        //    }
        //}

        //public SigmaResultType UpdateMessageBox(TypeMessageBox objMessageBox)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        result.IsSuccessful = true;
        //        MessageBoxMgr messageBoxMgr = new MessageBoxMgr();
        //        result = messageBoxMgr.UpdateMessageBox(objMessageBox);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log Exception
        //        ExceptionHelper.logException(ex);
        //        result.IsSuccessful = false;
        //        result.ErrorMessage = ex.Message;
        //        return result;
        //    }
        //}

        public SigmaResultType RemoveMessageBox(TypeMessageBox objMessageBox)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MessageBoxMgr messageBoxMgr = new MessageBoxMgr();
                result = messageBoxMgr.RemoveMessageBox(objMessageBox);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        //public SigmaResultType MultiMessageBox(List<TypeMessageBox> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        MessageBoxMgr messageBoxMgr = new MessageBoxMgr();
        //        result = messageBoxMgr.MultiMessageBox(listObj);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log Exception
        //        ExceptionHelper.logException(ex);
        //        result.IsSuccessful = false;
        //        result.ErrorMessage = ex.Message;
        //        return result;
        //    }
        //}

        #endregion MessageBox
    }
}
