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
using Element.Sigma.Web.Biz.ProjectSettings;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectData;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectSettings;
using System.ServiceModel.Activation;

namespace Element.Sigma.Web.Service.ProjectSettings
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SigmaProjectSettings" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SigmaProjectSettings.svc or SigmaProjectSettings.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SigmaProjectSettings : ISigmaProjectSettings
    {
        #region Personnel

        public SigmaResultType GetPersonnel(string personnelId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                PersonnelMgr personnelMgr = new PersonnelMgr();
                result = personnelMgr.GetPersonnel(personnelId);
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

        public SigmaResultType ListPersonnel()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];

                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@FirstName");
                s_option.Add("@LastName");
                s_option.Add("@Company");
                s_key.Add(queryStr["FirstName"]);
                s_key.Add(queryStr["LastName"]);
                s_key.Add(queryStr["Company"]);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                PersonnelMgr personnelMgr = new PersonnelMgr();
                result = personnelMgr.ListPersonnel(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddPersonnel(TypePersonnel objPersonnel)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                PersonnelMgr personnelMgr = new PersonnelMgr();
                result = personnelMgr.AddPersonnel(objPersonnel);
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

        public SigmaResultType UpdatePersonnel(TypePersonnel objPersonnel)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                PersonnelMgr personnelMgr = new PersonnelMgr();
                result = personnelMgr.UpdatePersonnel(objPersonnel);
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

        public SigmaResultType RemovePersonnel(TypePersonnel objPersonnel)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                PersonnelMgr personnelMgr = new PersonnelMgr();
                result = personnelMgr.RemovePersonnel(objPersonnel);
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

        public SigmaResultType MultiPersonnel(List<TypePersonnel> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                PersonnelMgr personnelMgr = new PersonnelMgr();
                result = personnelMgr.MultiPersonnel(listObj);
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

        #region ProjectCostCode

        public SigmaResultType GetProjectCostCode(string CostCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.GetProjectCostCode(CostCode);
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

        public SigmaResultType ListProjectCostCode()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];

                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@CostCode");
                s_option.Add("@Description");
                s_key.Add(queryStr["CostCode"]);
                s_key.Add(queryStr["Description"]);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.ListProjectCostCode(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType ListProjectCostCodeForMap()
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

                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.ListProjectCostCodeForMap(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddProjectCostCode(TypeProjectCostCode objProjectCostCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.AddProjectCostCode(objProjectCostCode);
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

        public SigmaResultType UpdateProjectCostCode(TypeProjectCostCode objProjectCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.UpdateProjectCostCode(objProjectCostCode);
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

        public SigmaResultType RemoveProjectCostCode(TypeProjectCostCode objProjectCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.RemoveProjectCostCode(objProjectCostCode);
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

        public SigmaResultType MultiProjectCostCode(List<TypeProjectCostCode> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.MultiProjectCostCode(listObj);
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

        #region ClientCostCode

        public SigmaResultType GetClientCostCode(string clientCostCodeId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.GetClientCostCode(clientCostCodeId);
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

        public SigmaResultType ListClientCostCode()
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

                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.ListClientCostCode(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddClientCostCode(TypeClientCostCode objClientCostCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.AddClientCostCode(objClientCostCode);
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

        public SigmaResultType UpdateClientCostCode(TypeClientCostCode objClientCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.UpdateClientCostCode(objClientCostCode);
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

        public SigmaResultType RemoveClientCostCode(TypeClientCostCode objClientCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.RemoveClientCostCode(objClientCostCode);
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

        public SigmaResultType MultiClientCostCode(List<TypeClientCostCode> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.MultiClientCostCode(listObj);
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

        #region CostCodeMap

        public SigmaResultType GetCostCodeMap(string costCodeMapId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.GetCostCodeMap(costCodeMapId);
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

        public SigmaResultType ListCostCodeMap()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];

                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@ClientCostCode");
                s_option.Add("@ClientCostCodeName");
                s_option.Add("@ProjectCostCode");
                s_option.Add("@ProjectCostCodeName");
                s_key.Add(queryStr["ClientCostCode"]);
                s_key.Add(queryStr["ClientCostCodeName"]);
                s_key.Add(queryStr["ProjectCostCode"]);
                s_key.Add(queryStr["ProjectCostCodeName"]);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.ListCostCodeMap(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddCostCodeMap(TypeCostCodeMap objCostCodeMap)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.AddCostCodeMap(objCostCodeMap);
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

        public SigmaResultType UpdateCostCodeMap(TypeCostCodeMap objCostCodeMap)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.UpdateCostCodeMap(objCostCodeMap);
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

        public SigmaResultType RemoveCostCodeMap(TypeCostCodeMap objCostCodeMap)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.RemoveCostCodeMap(objCostCodeMap);
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

        public SigmaResultType MultiCostCodeMap(List<TypeCostCodeMap> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.MultiCostCodeMap(listObj);
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

        #region SigmaUserSigmaRole

        public SigmaResultType GetSigmaUserSigmaRole(string sigmaUserId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.GetSigmaUserSigmaRole(sigmaUserId);
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

        public SigmaResultType GetSigmaRoleBySigmaUser()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
             
                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@SigmaUserId");
                s_option.Add("@SigmaRoleId");
                s_key.Add(queryStr["SigmaUserId"]);
                s_key.Add(queryStr["SigmaRoleId"]);

                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.GetSigmaRoleBySigmaUser(s_option, s_key);
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

        public SigmaResultType AddSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.AddSigmaUserSigmaRole(objSigmaUserSigmaRole);
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

        public SigmaResultType UpdateSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.UpdateSigmaUserSigmaRole(objSigmaUserSigmaRole);
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

        public SigmaResultType RemoveSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.RemoveSigmaUserSigmaRole(objSigmaUserSigmaRole);
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

        public SigmaResultType MultiSigmaUserSigmaRole(List<TypeSigmaUserSigmaRole> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.MultiSigmaUserSigmaRole(listObj);
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


        public SigmaResultType UpdateSigmaUserSigmaRoleForHierarchy(TypeSigmaUserSigmaRole objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.UpdateSigmaUserSigmaRoleForHierarchy(objSigmaUser);
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

        public SigmaResultType RemoveSigmaUserSigmaRoleForHierarchy(TypeSigmaUserSigmaRole objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.RemoveSigmaUserSigmaRoleForHierarchy(objSigmaUser);
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

        #region ProjectUserDiscipline

        public SigmaResultType GetProjectUserDiscipline(string sigmaUserId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.GetProjectUserDiscipline(sigmaUserId);
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

        public SigmaResultType ListProjectUserDiscipline()
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

                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.ListProjectUserDiscipline(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddProjectUserDiscipline(TypeProjectUserDiscipline objProjectUserDiscipline)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.AddProjectUserDiscipline(objProjectUserDiscipline);
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

        public SigmaResultType RemoveProjectUserDiscipline(TypeProjectUserDiscipline objProjectUserDiscipline)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.RemoveProjectUserDiscipline(objProjectUserDiscipline);
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

        public SigmaResultType MultiProjectUserDiscipline(List<TypeProjectUserDiscipline> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.MultiProjectUserDiscipline(listObj);
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

        public SigmaResultType MultiMember(TypeMember clsObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.MultiMember(clsObj);
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

        public SigmaResultType MultiHierarchy(List<TypeSigmaUserSigmaRole> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.MultiHierarchy(listObj);
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

        public SigmaResultType RemoveMember(TypeProjectUserDiscipline objProjectUserDiscipline)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.RemoveMember(objProjectUserDiscipline.SigmaUserId);
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

        public SigmaResultType ListMember()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                //string s_option = queryStr["s_option"];
                //string s_key = queryStr["s_key"];
                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@Name");
                s_option.Add("@RoleName");
                s_option.Add("@DisciplineName");
                s_key.Add(queryStr["Name"]);
                s_key.Add(queryStr["RoleName"]);
                s_key.Add(queryStr["DisciplineName"]);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.ListMember(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType ListRoleHierarchy()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                MemberMgr memberMgr = new MemberMgr();
                result = memberMgr.ListRoleHierarchy();
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

        public SigmaResultType ListIwpViewer()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@IwpId");
                s_key.Add(queryStr["IwpId"]);

                IwpViewerMgr iwpViewerMgr = new IwpViewerMgr();
                result = iwpViewerMgr.ListIwpViewer(s_option, s_key);
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

        #region CWA

        public SigmaResultType GetCWA(string cwaId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CWAMgr cWAMgr = new CWAMgr();
                result = cWAMgr.GetCWA(cwaId);
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

        public SigmaResultType ListCWA()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CWAMgr cWAMgr = new CWAMgr();
                result = cWAMgr.ListCWA();
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

        public SigmaResultType AddCWA(TypeCWA objCWA)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CWAMgr cWAMgr = new CWAMgr();
                result = cWAMgr.AddCWAInfo(objCWA);
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

        public SigmaResultType UpdateCWA(TypeCWA objCWA)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CWAMgr cWAMgr = new CWAMgr();
                result = cWAMgr.AddCWAInfo(objCWA);
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

        //public SigmaResultType RemoveCWA(TypeCWA objCWA)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        CWAMgr cWAMgr = new CWAMgr();
        //        result = cWAMgr.RemoveCWA(objCWA);
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

        public SigmaResultType MultiCWA(List<TypeCWA> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CWAMgr cWAMgr = new CWAMgr();
                result = cWAMgr.MultiCWA(listObj);
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

        #endregion CWA

        #region CWP

        public SigmaResultType GetCWP(string cwpId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CWAMgr CWAMgr = new CWAMgr();
                result = CWAMgr.GetCWP(cwpId);
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

        //public SigmaResultType ListCWP()
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
        //        string max = queryStr["max"];
        //        string offset = queryStr["offset"];
        //        string s_option = queryStr["s_option"];
        //        string s_key = queryStr["s_key"];
        //        string o_option = queryStr["o_option"];
        //        string o_desc = queryStr["o_desc"];

        //        CWAMgr CWAMgr = new CWAMgr();
        //        result = CWAMgr.ListCWP(offset, max, s_option, s_key, o_option, o_desc);
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

        //public SigmaResultType AddCWP(TypeCWP objCWP)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        CWAMgr CWAMgr = new CWAMgr();
        //        result = CWAMgr.AddCWP(objCWP);
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

        public SigmaResultType UpdateCWP(TypeCWP objCWP)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CWAMgr CWAMgr = new CWAMgr();
                result = CWAMgr.UpdateCWP(objCWP);
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

        //public SigmaResultType RemoveCWP(TypeCWP objCWP)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        CWAMgr CWAMgr = new CWAMgr();
        //        result = CWAMgr.RemoveCWP(objCWP);
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

        public SigmaResultType MultiCWP(List<TypeCWP> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CWAMgr CWAMgr = new CWAMgr();
                result = CWAMgr.MultiCWP(listObj);
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

        public SigmaResultType GetCWPByCWAId(string cwaId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CWAMgr CWAMgr = new CWAMgr();
                result = CWAMgr.GetCWPByCWAId(cwaId);
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

        #endregion CWP

        #region Project

        public SigmaResultType GetProject(string projectId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProjectMgr projectMgr = new ProjectMgr();
                result = projectMgr.GetProject(projectId);
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

        //public SigmaResultType ListProject()
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
        //        string max = queryStr["max"];
        //        string offset = queryStr["offset"];
        //        string s_option = queryStr["s_option"];
        //        string s_key = queryStr["s_key"];
        //        string o_option = queryStr["o_option"];
        //        string o_desc = queryStr["o_desc"];

        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.ListProject(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddProject(TypeProject objProject)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProjectMgr projectMgr = new ProjectMgr();
                result = projectMgr.AddProjectInfo(objProject);
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

        public SigmaResultType UpdateProject(TypeProject objProject)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ProjectMgr projectMgr = new ProjectMgr();
                result = projectMgr.AddProjectInfo(objProject);
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

        public SigmaResultType RemoveProject(TypeProject objProject)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ProjectMgr projectMgr = new ProjectMgr();
                result = projectMgr.RemoveProject(objProject);
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

        //public SigmaResultType MultiProject(List<TypeProject> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.MultiProject(listObj);
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

        public SigmaResultType CloseOpenProject(TypeProject objProject)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ProjectMgr projectMgr = new ProjectMgr();
                result = projectMgr.CloseOpenProject(objProject);
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

        #region ProjectDiscipline

        public SigmaResultType GetProjectDiscipline(string projectId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProjectMgr projectMgr = new ProjectMgr();
                result = projectMgr.GetProjectDiscipline(projectId);
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

        //public SigmaResultType ListProjectDiscipline()
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
        //        string max = queryStr["max"];
        //        string offset = queryStr["offset"];
        //        string s_option = queryStr["s_option"];
        //        string s_key = queryStr["s_key"];
        //        string o_option = queryStr["o_option"];
        //        string o_desc = queryStr["o_desc"];

        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.ListProjectDiscipline(offset, max, s_option, s_key, o_option, o_desc);
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

        //public SigmaResultType AddProjectDiscipline(TypeProjectDiscipline objProjectDiscipline)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.AddProjectDiscipline(objProjectDiscipline);
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

        //public SigmaResultType UpdateProjectDiscipline(TypeProjectDiscipline objProjectDiscipline)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        result.IsSuccessful = true;
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

        //public SigmaResultType RemoveProjectDiscipline(TypeProjectDiscipline objProjectDiscipline)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.RemoveProjectDiscipline(objProjectDiscipline);
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

        //public SigmaResultType MultiProjectDiscipline(List<TypeProjectDiscipline> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.MultiProjectDiscipline(listObj);
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

        #endregion ProjectDiscipline

        #region ProjectSubcontractor

        public SigmaResultType GetProjectSubcontractor(string projectId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProjectMgr projectMgr = new ProjectMgr();
                result = projectMgr.GetProjectSubcontractor(projectId);
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

        //public SigmaResultType ListProjectSubcontractor()
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
        //        string max = queryStr["max"];
        //        string offset = queryStr["offset"];
        //        string s_option = queryStr["s_option"];
        //        string s_key = queryStr["s_key"];
        //        string o_option = queryStr["o_option"];
        //        string o_desc = queryStr["o_desc"];

        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.ListProjectSubcontractor(offset, max, s_option, s_key, o_option, o_desc);
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

        //public SigmaResultType AddProjectSubcontractor(TypeProjectSubcontractor objProjectSubcontractor)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.AddProjectSubcontractor(objProjectSubcontractor);
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

        //public SigmaResultType UpdateProjectSubcontractor(TypeProjectSubcontractor objProjectSubcontractor)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        result.IsSuccessful = true;
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

        //public SigmaResultType RemoveProjectSubcontractor(TypeProjectSubcontractor objProjectSubcontractor)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.RemoveProjectSubcontractor(objProjectSubcontractor);
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

        //public SigmaResultType MultiProjectSubcontractor(List<TypeProjectSubcontractor> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProjectMgr projectMgr = new ProjectMgr();
        //        result = projectMgr.MultiProjectSubcontractor(listObj);
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

        #endregion ProjectSubcontractor
    }
}
