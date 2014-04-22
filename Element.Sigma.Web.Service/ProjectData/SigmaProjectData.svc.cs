using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Collections.Generic;
using System.ServiceModel.Web;


using Element.Shared.Common;
using Element.Sigma.Web.Biz;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectData;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.MTO;
using System.ServiceModel.Activation;

namespace Element.Sigma.Web.Service.ProjectData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SigmaProjectData" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SigmaProjectData.svc or SigmaProjectData.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SigmaProjectData : ISigmaProjectData
    {

        #region ComponentReferenceDrawing

        public SigmaResultType GetComponentReferenceDrawing(string componentReferenceDrawingId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentReferenceDrawingMgr componentReferenceDrawingMgr = new ComponentReferenceDrawingMgr();
                result = componentReferenceDrawingMgr.GetComponentReferenceDrawing(componentReferenceDrawingId);
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

        public SigmaResultType ListComponentReferenceDrawing()
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

                ComponentReferenceDrawingMgr componentReferenceDrawingMgr = new ComponentReferenceDrawingMgr();
                result = componentReferenceDrawingMgr.ListComponentReferenceDrawing(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddComponentReferenceDrawing(TypeComponentReferenceDrawing objComponentReferenceDrawing)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentReferenceDrawingMgr componentReferenceDrawingMgr = new ComponentReferenceDrawingMgr();
                result = componentReferenceDrawingMgr.AddComponentReferenceDrawing(objComponentReferenceDrawing);
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

        public SigmaResultType UpdateComponentReferenceDrawing(TypeComponentReferenceDrawing objComponentReferenceDrawing)
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

        public SigmaResultType RemoveComponentReferenceDrawing(TypeComponentReferenceDrawing objComponentReferenceDrawing)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentReferenceDrawingMgr componentReferenceDrawingMgr = new ComponentReferenceDrawingMgr();
                result = componentReferenceDrawingMgr.RemoveComponentReferenceDrawing(objComponentReferenceDrawing);
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

        public SigmaResultType MultiComponentReferenceDrawing(List<TypeComponentReferenceDrawing> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentReferenceDrawingMgr componentReferenceDrawingMgr = new ComponentReferenceDrawingMgr();
                result = componentReferenceDrawingMgr.MultiComponentReferenceDrawing(listObj);
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
        #region From P6 Sch
        /// <summary>
        /// 2014-03-09
        /// Get GeneralForeman
        /// </summary>
        /// <returns></returns>
        public SigmaResultType GetGeneralForeManCombo()
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ScheduleMgr schMgr = new ScheduleMgr();
                result = schMgr.GetGeneralForeManCombo();
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


        /// <summary>
        /// Get P6 Project List
        /// Project Control > Data > Schedule > Get Project Info
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public SigmaResultType GetP6ProjectCombo(string userName, string password)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ScheduleMgr schMgr = new ScheduleMgr();
                result = schMgr.P6ProjectCombo(userName, password);
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

        /// <summary>
        /// Read & Set WBS
        /// Project Control > Data > Schedule > ImportSchedule
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public SigmaResultType ReadP6WBSManager(string projectId, string url, string UserName, string PassWord)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ScheduleMgr schMgr = new ScheduleMgr();
                result = schMgr.ReadP6WBSManager(int.Parse(projectId));
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

        #endregion 
        #region DrawingLists

        public SigmaResultType GetDrawing(string DrawingId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.GetDrawing(DrawingId);
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

        public SigmaResultType ListDrawing()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                //2014.2.14 modified querystring rule
                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@DrawingName");
                s_option.Add("@FileName");
                s_option.Add("@DrawingType");
                s_option.Add("@ViewOption");
                s_key.Add(queryStr["DrawingName"]);
                s_key.Add(queryStr["FileName"]);
                s_key.Add(queryStr["DrawingType"]);
                s_key.Add(queryStr["ViewOption"]);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.ListDrawing(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType CountOrphanDrawing()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.CountOrphanDrawing();
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

        public SigmaResultType ListRefDrawing(string CWPName)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.ListRefDrawing(CWPName);
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

        public SigmaResultType DrawingViewer(string CWPName, string DrawingName)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                //2014.2.14 modified querystring rule
                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@CWPName");
                s_option.Add("@DrawingName");
                s_key.Add(CWPName);
                s_key.Add(DrawingName);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.DrawingViewer(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType DrawingBinding(TypeDrawing objDrawingid)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.DrawingBinding(objDrawingid);
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

        public SigmaResultType AddDrawing(TypeDrawing objDrawingid)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.AddDrawing(objDrawingid);
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

        public SigmaResultType UpdateDrawing(TypeDrawing objDrawingid)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.UpdateDrawing(objDrawingid);
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

        public SigmaResultType RemoveDrawing(TypeDrawing objDrawingid)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.RemoveDrawing(objDrawingid);
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

        public SigmaResultType MultiDrawing(List<TypeDrawing> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                DrawingMgr drawingMgr = new DrawingMgr();
                result = drawingMgr.MultiDrawing(listObj);
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

        public SigmaResultType ListDrawingByImportHistoryId(string ImportHistoryId)
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

                ImportDrawing importDrawing = new ImportDrawing();
                result = importDrawing.ListDrawingByImportHistoryId(int.Parse(ImportHistoryId), offset, max, s_option, s_key, o_option, o_desc);
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

        #region MTO(Civil)

        /// <summary>
        /// 2014-03-10
        /// Data > MTO > Get Associated Tag Number Combo
        /// </summary>
        /// <param name="DrawingId"></param>
        /// <returns></returns>
        public SigmaResultType GetTagNumberCombo(string DrawingId, string Gubun)
        {
            SigmaResultType Result = new SigmaResultType();

            try
            {
                ImportMgr MTOMgr = new ImportMgr();
                Result = MTOMgr.GetTagNumberCombo(int.Parse(DrawingId), int.Parse(Gubun));
                return Result;
            }
            catch (Exception ex)
            {
                ExceptionHelper.logException(ex);
                Result.IsSuccessful = false;
                Result.ErrorMessage = ex.Message;
                return Result;
            }
        }

        /// <summary>
        /// Get Discipline
        /// </summary>
        /// <param name="CwpName"></param>
        /// <param name="CwpId"></param>
        /// <returns></returns>
        public SigmaResultType GetDiscipline(string CwpName, string CwpId)
        {
            SigmaResultType Result = new SigmaResultType();

            try
            {
                ImportMgr MTOMgr = new ImportMgr();
                Result = MTOMgr.GetDiscipline(CwpName, CwpId);
                return Result;
            }
            catch (Exception ex)
            {
                ExceptionHelper.logException(ex);
                Result.IsSuccessful = false;
                Result.ErrorMessage = ex.Message;
                return Result;
            }
        }

        /// <summary>
        /// MTO : Edit Material information(PopUP info)
        /// </summary>
        /// <param name="componentId">componentId</param>
        /// <returns></returns>
        public SigmaResultType ListMTOComponent(string componentId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                ImportCivilMgr ImportCivilMgr = new ImportCivilMgr();
                result = ImportCivilMgr.ListMTOByComponent(componentId);
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

        public SigmaResultType ListMTO(string componentId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                ImportCivilMgr ImportCivilMgr = new ImportCivilMgr();
                result = ImportCivilMgr.ListMTO(componentId);
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

        /// <summary>
        ///  MTO : Edit Material information(PopUP info)
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns></returns>
        public SigmaResultType GetComponentCustomField(string componentId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                ImportCivilMgr ImportCivilMgr = new ImportCivilMgr();
                result = ImportCivilMgr.GetComponentCustomField(componentId);
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

        public SigmaResultType DeleteMTO(List<TypeComponent> listCom)
        {
            SigmaResultType sResult = new SigmaResultType();
            ImportMgr DeleteMTO = new ImportMgr();
            return sResult = DeleteMTO.DeleteMTO(listCom);
        }

        /// <summary>
        /// Edit MTO : Edit Material Information
        /// </summary>
        /// <param name="objComonent"></param>
        /// <param name="objMaterial"></param>
        /// <returns></returns>
        public SigmaResultType UpdateMTO(TypeComponent objComonent, TypeMaterial objMaterial)
        {
            SigmaResultType sResult = new SigmaResultType();
            ImportMgr UpdateMTO = new ImportMgr();
            return sResult = UpdateMTO.UpdateMTO(objComonent, objMaterial);
        }

        /// <summary>
        /// 2014-02-21 
        /// Import MTO Maunal
        /// </summary>
        /// <param name="objComponent"></param>
        /// <param name="objComponetCustomField"></param>
        /// <param name="objImportHistory"></param>
        /// <param name="objMaterial"></param>
        /// <returns></returns>
        public SigmaResultType SaveMTO(TypeComponent objComponent, TypeMaterial objMaterial)
        {
            SigmaResultType sResult = new SigmaResultType();
            ImportMgr SaveImport = new ImportMgr();
            return sResult = SaveImport.SaveMTO(objComponent, objMaterial); 
        }

        /// <summary>
        /// 2014-02-24 : MTO:Initial Screen
        /// </summary>
        /// <param name="DrawingId">DrawingID</param>
        /// <returns></returns>
        public SigmaResultType ListComponents(string DrawingId)
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

                ImportCivilMgr ImportCivilMgr = new ImportCivilMgr();
                result = ImportCivilMgr.ListComponentsByDrawingId(DrawingId, offset, max, s_option, s_key, o_option, o_desc);
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

        /// <summary>
        /// Data > ImportMTO > List After Import Excel MTO
        /// </summary>
        /// <param name="ImportHistoryId"></param>
        /// <returns></returns>
        public SigmaResultType ListComponentsByImportHistoryId(string ImportHistoryId)
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

                ImportCivilMgr ImportCivilMgr = new ImportCivilMgr();
                result = ImportCivilMgr.ListComponentsByImportHistoryId(ImportHistoryId, offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType ListCivilMTO()
        {
            return ListComponentsByImportHistoryId("0");
        }

        public SigmaResultType MultiCivilMTO(List<TypeMTO> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ImportCivilMgr ImportCivilMgr = new ImportCivilMgr();
                result = ImportCivilMgr.MultiCivilMTO(listObj);
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

        #region Assign Cost Code

        public SigmaResultType ListAssignmentComponentProgress()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@CwpId");
                s_option.Add("@TaskCategoryId");
                s_option.Add("@TaskTypeId");
                s_option.Add("@ProgressStepId");
                s_key.Add(queryStr["cwp"]);
                s_key.Add(queryStr["taskcategory"]);
                s_key.Add(queryStr["tasktype"]);
                s_key.Add(queryStr["progress"]);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                AssignCostCodeMgr assigncostCodeMgr = new AssignCostCodeMgr();

                result = assigncostCodeMgr.ListAssignmentComponentProgress(offset, max, s_option, s_key, o_option, o_desc);

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

        public SigmaResultType UpdateAssignmentComponentProgress(List<TypeAssignmentCostCode> objAssignmentCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                AssignCostCodeMgr assigncostCodeMgr = new AssignCostCodeMgr();
                result = assigncostCodeMgr.MultiAssignmentComponentProgress(objAssignmentCostCode);
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

        public SigmaResultType UpdateAssignmentComponentProgressAll(List<TypeAssignmentCostCode> objAssignmentCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            List<TypeAssignmentCostCode> trgAssignmentCostCode = TargetLlistAssignmentCostCode(objAssignmentCostCode);

            try
            {
                AssignCostCodeMgr assigncostCodeMgr = new AssignCostCodeMgr();
                result = assigncostCodeMgr.MultiAssignmentComponentProgress(trgAssignmentCostCode);
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

        private static List<TypeAssignmentCostCode> TargetLlistAssignmentCostCode(List<TypeAssignmentCostCode> objAssignmentCostCode)
        {
            var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
            string max = queryStr["max"];
            string offset = queryStr["offset"];
            List<string> s_option = new List<string>();
            List<string> s_key = new List<string>();
            s_option.Add("@CwpId");
            s_option.Add("@TaskCategoryId");
            s_option.Add("@TaskTypeId");
            s_option.Add("@ProgressStepId");
            s_key.Add(queryStr["cwp"]);
            s_key.Add(queryStr["taskcategory"]);
            s_key.Add(queryStr["tasktype"]);
            s_key.Add(queryStr["progress"]);

            string o_option = queryStr["o_option"];
            string o_desc = queryStr["o_desc"];

            List<TypeAssignmentCostCode> result = new List<TypeAssignmentCostCode>();
            AssignCostCodeMgr assigncostCodeMgr = new AssignCostCodeMgr();
            result = assigncostCodeMgr.TargetListAssignmentComponentProgress(offset, max, s_option, s_key, o_option, o_desc);

            result.ForEach(x => x.CostCodeId = objAssignmentCostCode[0].CostCodeId);

            return result;
        }

        

        #endregion

        #region Schedule

        public SigmaResultType GetImportedSchedule(string scheduledworkitemid)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ScheduleMgr scheduleMgr = new ScheduleMgr();
                result = scheduleMgr.GetImportedSchedule(scheduledworkitemid);
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

        public SigmaResultType ListImportedSchedule()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ScheduleMgr scheduleMgr = new ScheduleMgr();
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                result = scheduleMgr.ListImportedSchedule(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters);
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

        public SigmaResultType AddImportedSchedule(TypeImportedSchedule paramObj)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ScheduleMgr scheduleMgr = new ScheduleMgr();
                result = scheduleMgr.AddImportedSchedule(paramObj);
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

        public SigmaResultType UpdateImportedSchedule(TypeImportedSchedule paramObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                result.IsSuccessful = true;
                ScheduleMgr scheduleMgr = new ScheduleMgr();
                result = scheduleMgr.UpdateImportedSchedule(paramObj);
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

        /// <summary>
        /// Data > Schedule > Remove Schedule
        /// </summary>
        /// <returns></returns>
        public SigmaResultType MultiImportedSchedule()
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ScheduleMgr scheduleMgr = new ScheduleMgr();
                result = scheduleMgr.MultiImportedSchedule();
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
    }
}
