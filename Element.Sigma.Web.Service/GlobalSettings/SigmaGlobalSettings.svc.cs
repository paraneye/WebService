using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.ServiceModel.Web;
using System.Collections.Generic;

using Element.Shared.Common;
using Element.Sigma.Web.Biz;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.Types.MTO;
using System.Collections.Specialized;
using System.ServiceModel.Activation;

namespace Element.Sigma.Web.Service.GlobalSettings
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SigmaGlobalSettings" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SigmaGlobalSettings.svc or SigmaGlobalSettings.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SigmaGlobalSettings : ISigmaGlobalSettings
    {

        #region SigmaUser
        public SigmaResultType GetSigmaUser(string sigmaUserId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.GetSigmaUser(sigmaUserId);
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

        public SigmaResultType ListSigmaUser()
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
                s_option.Add("@SigmaUserId");
                s_key.Add(queryStr["FirstName"]);
                s_key.Add(queryStr["LastName"]);
                s_key.Add(queryStr["SigmaUserId"]);

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.ListSigmaUser(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddSigmaUser(TypeSigmaUser objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.AddSigmaUser(objSigmaUser);
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

        public SigmaResultType UpdateSigmaUser(TypeSigmaUser objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.AddSigmaUser(objSigmaUser);
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

      

        public SigmaResultType RemoveSigmaUser(TypeSigmaUser objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.RemoveSigmaUser(objSigmaUser);
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
        public SigmaResultType MultiSigmaUser(List<TypeSigmaUser> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.MultiSigmaUser(listObj);
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

        public SigmaResultType MultiUsers(TypeSigmaUser objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.MultiUsers(objSigmaUser);
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

        public SigmaResultType UpdateUserProfile(TypeSigmaUser objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.UpdateUserProfile(objSigmaUser);
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


        public SigmaResultType UpdatePassword(TypeSigmaUser objSigmaUser)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.UpdatePassword(objSigmaUser);
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
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.GetSigmaUserSigmaRole(sigmaUserId);
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

        public SigmaResultType ListSigmaUserSigmaRole()
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

                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.ListSigmaUserSigmaRole(offset, max, s_option, s_key, o_option, o_desc);
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
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.AddSigmaUserSigmaRole(objSigmaUserSigmaRole);
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

        public SigmaResultType RemoveSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaUserMgr sigmaUserMgr = new SigmaUserMgr();
                result = sigmaUserMgr.RemoveSigmaUserSigmaRole(objSigmaUserSigmaRole);
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

        #region SigmaRole
        public SigmaResultType GetSigmaRole(string sigmaRoleId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();
                result = sigmaRoleMgr.GetSigmaRole(sigmaRoleId);
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

        public SigmaResultType ListSigmaRole()
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

                SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();
                result = sigmaRoleMgr.ListSigmaRole(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddSigmaRole(TypeSigmaRole objSigmaRole)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();
                result = sigmaRoleMgr.AddSigmaRole(objSigmaRole);
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

        public SigmaResultType UpdateSigmaRole(TypeSigmaRole objSigmaRole)
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

        public SigmaResultType RemoveSigmaRole(TypeSigmaRole objSigmaRole)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();
                result = sigmaRoleMgr.RemoveSigmaRole(objSigmaRole);
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

        public SigmaResultType MultiSigmaRole(List<TypeSigmaRole> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();
                result = sigmaRoleMgr.MultiSigmaRole(listObj);
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

        public SigmaResultType ListSigmaRolesByProjectId(string projectId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaRoleMgr sigmaRoleMgr = new SigmaRoleMgr();
                result = sigmaRoleMgr.ListSigmaRolesByProjectId(projectId);
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

        #region SigmaJob

        public SigmaResultType GetSigmaJob(string sigmaJobId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaJobMgr sigmaJobMgr = new SigmaJobMgr();
                result = sigmaJobMgr.GetSigmaJob(sigmaJobId);
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

        public SigmaResultType ListSigmaJob()
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

                SigmaJobMgr sigmaJobMgr = new SigmaJobMgr();
                result = sigmaJobMgr.ListSigmaJob(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddSigmaJob(TypeSigmaJob objSigmaJob)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaJobMgr sigmaJobMgr = new SigmaJobMgr();
                result = sigmaJobMgr.AddSigmaJob(objSigmaJob);
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

        public SigmaResultType UpdateSigmaJob(TypeSigmaJob objSigmaJob)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                result.IsSuccessful = true;
                SigmaJobMgr sigmaJobMgr = new SigmaJobMgr();
                result = sigmaJobMgr.UpdateSigmaJob(objSigmaJob);
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

        public SigmaResultType RemoveSigmaJob(TypeSigmaJob objSigmaJob)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaJobMgr sigmaJobMgr = new SigmaJobMgr();
                result = sigmaJobMgr.RemoveSigmaJob(objSigmaJob);
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

        public SigmaResultType MultiSigmaJob(List<TypeSigmaJob> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaJobMgr sigmaJobMgr = new SigmaJobMgr();
                result = sigmaJobMgr.MultiSigmaJob(listObj);
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

        #region Roles & Permissions

        public SigmaResultType ListSigmaRoleSigmaJob(string sigmaRoleId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                PermissionMgr permissionMgr = new PermissionMgr();
                result = permissionMgr.ListSigmaRoleSigmaJob(sigmaRoleId);
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

        public SigmaResultType ListSigmaRoleSigmaJobForInit()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                PermissionMgr permissionMgr = new PermissionMgr();
                result = permissionMgr.ListSigmaRoleSigmaJobForInit();
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

        public SigmaResultType MultiRolesNPermissions(TypeSigmaRole listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                PermissionMgr permissionMgr = new PermissionMgr();
                result = permissionMgr.MultiSigmaRoleSigmaJob(listObj);
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

        public SigmaResultType ListPermissionReport()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                PermissionMgr permissionMgr = new PermissionMgr();
                result = permissionMgr.ListSigmaRoleSigmaJob("0");
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

        public SigmaResultType MultiPermissionReport(List<TypeSigmaRoleSigmaJob> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                PermissionMgr permissionMgr = new PermissionMgr();
                result = permissionMgr.MultiPermissionReport(listObj);
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

        #region FileStore

        public SigmaResultType GetFileStore(string fileStoreId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                FileStoreMgr fileStoreMgr = new FileStoreMgr();
                result = fileStoreMgr.GetFileStore(fileStoreId);
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

        public SigmaResultType ListFileStore()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                //var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                //string max = queryStr["max"];
                //string offset = queryStr["offset"];
                ////2014.2.14 modified querystring rule
                //List<string> s_option = new List<string>();
                //List<string> s_key = new List<string>();
                //s_option.Add("@CostCode");
                //s_option.Add("@Description");
                //s_key.Add(queryStr["CostCode"]);
                //s_key.Add(queryStr["Description"]);

                //string o_option = queryStr["o_option"];
                //string o_desc = queryStr["o_desc"];

                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];
                string s_option = queryStr["s_option"];
                string s_key = queryStr["s_key"];
                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                List<string[]> s_optionkeyList = new List<string[]>();

                if (!string.IsNullOrEmpty(queryStr["FileCategory"]))
                {
                    string[] s_optionkeys = new string[2];
                    s_optionkeys[0] = "FileCategory";
                    s_optionkeys[1] = queryStr["FileCategory"];
                    s_optionkeyList.Add(s_optionkeys);
                }
                else
                {
                    string[] s_optionkeys = new string[2];
                    s_optionkeys[0] = "FileCategory";
                    s_optionkeys[1] = null;
                    s_optionkeyList.Add(s_optionkeys);
                }
                if (!string.IsNullOrEmpty(queryStr["FileTypeCode"]))
                {
                    string[] s_optionkeys = new string[2];
                    s_optionkeys[0] = "FileTypeCode";
                    s_optionkeys[1] = queryStr["FileTypeCode"];
                    s_optionkeyList.Add(s_optionkeys);
                }
                else
                {
                    string[] s_optionkeys = new string[2];
                    s_optionkeys[0] = "FileTypeCode";
                    s_optionkeys[1] = null;
                    s_optionkeyList.Add(s_optionkeys);
                }
                //if (!string.IsNullOrEmpty(queryStr["UploadedBy"]))
                //{
                //    string[] s_optionkeys = new string[2];
                //    s_optionkeys[0] = "UploadedBy";
                //    s_optionkeys[1] = queryStr["UploadedBy"];
                //    s_optionkeyList.Add(s_optionkeys);
                //}
                //else
                //{
                //    string[] s_optionkeys = new string[2];
                //    s_optionkeys[0] = "UploadedBy";
                //    s_optionkeys[1] = null;
                //    s_optionkeyList.Add(s_optionkeys);
                //}
                //if (!string.IsNullOrEmpty(queryStr["Title"]))
                //{
                //    string[] s_optionkeys = new string[2];
                //    s_optionkeys[0] = "Title";
                //    s_optionkeys[1] = queryStr["Title"];
                //    s_optionkeyList.Add(s_optionkeys);
                //}
                //else
                //{
                //    string[] s_optionkeys = new string[2];
                //    s_optionkeys[0] = "Title";
                //    s_optionkeys[1] = null;
                //    s_optionkeyList.Add(s_optionkeys);
                //}
                //if (!string.IsNullOrEmpty(queryStr["Description"]))
                //{
                //    string[] s_optionkeys = new string[2];
                //    s_optionkeys[0] = "Description";
                //    s_optionkeys[1] = queryStr["Description"];
                //    s_optionkeyList.Add(s_optionkeys);
                //}
                //else
                //{
                //    string[] s_optionkeys = new string[2];
                //    s_optionkeys[0] = "Description";
                //    s_optionkeys[1] = null;
                //    s_optionkeyList.Add(s_optionkeys);
                //}
                //
                if (!string.IsNullOrEmpty(s_option))
                {
                    if (s_option == "Title")
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "Title";
                        s_optionkeys[1] = s_key;
                        s_optionkeyList.Add(s_optionkeys);

                        string[] s_optionkeys2 = new string[2];
                        s_optionkeys2[0] = "Description";
                        s_optionkeys2[1] = null;
                        s_optionkeyList.Add(s_optionkeys2);

                        string[] s_optionkeys3 = new string[2];
                        s_optionkeys3[0] = "UploadedBy";
                        s_optionkeys3[1] = null;
                        s_optionkeyList.Add(s_optionkeys3);
                    }
                    if (s_option == "Description")
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "Description";
                        s_optionkeys[1] = s_key;
                        s_optionkeyList.Add(s_optionkeys);

                        string[] s_optionkeys2 = new string[2];
                        s_optionkeys2[0] = "Title";
                        s_optionkeys2[1] = null;
                        s_optionkeyList.Add(s_optionkeys);

                        string[] s_optionkeys3 = new string[2];
                        s_optionkeys3[0] = "UploadedBy";
                        s_optionkeys3[1] = null;
                        s_optionkeyList.Add(s_optionkeys3);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(queryStr["Title"]))
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "Title";
                        s_optionkeys[1] = queryStr["Title"];
                        s_optionkeyList.Add(s_optionkeys);
                    }
                    else
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "Title";
                        s_optionkeys[1] = null;
                        s_optionkeyList.Add(s_optionkeys);
                    }
                    if (!string.IsNullOrEmpty(queryStr["Description"]))
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "Description";
                        s_optionkeys[1] = queryStr["Description"];
                        s_optionkeyList.Add(s_optionkeys);
                    }
                    else
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "Description";
                        s_optionkeys[1] = null;
                        s_optionkeyList.Add(s_optionkeys);
                    }
                    if (!string.IsNullOrEmpty(queryStr["UploadedBy"]))
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "UploadedBy";
                        s_optionkeys[1] = queryStr["UploadedBy"];
                        s_optionkeyList.Add(s_optionkeys);
                    }
                    else
                    {
                        string[] s_optionkeys = new string[2];
                        s_optionkeys[0] = "UploadedBy";
                        s_optionkeys[1] = null;
                        s_optionkeyList.Add(s_optionkeys);
                    }
                }
                
                

                FileStoreMgr fileStoreMgr = new FileStoreMgr();
                result = fileStoreMgr.ListFileStore(offset, max, s_optionkeyList, o_option, o_desc);
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

        public SigmaResultType AddFileStore(TypeFileStore objFileStore)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ////string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                //string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"];

                FileStoreMgr fileStoreMgr = new FileStoreMgr();
                result = fileStoreMgr.AddFileStore(objFileStore, ConfigMgr.GetTargetPath());
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

        public SigmaResultType UpdateFileStore(TypeFileStore objFileStore)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ////string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                //string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"];

                FileStoreMgr fileStoreMgr = new FileStoreMgr();
                result = fileStoreMgr.UpdateFileStore(objFileStore, ConfigMgr.GetTargetPath());
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

        public SigmaResultType RemoveFileStore(TypeFileStore objFileStore)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                FileStoreMgr fileStoreMgr = new FileStoreMgr();
                result = fileStoreMgr.RemoveFileStore(objFileStore);
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

        public SigmaResultType MultiFileStore(List<TypeFileStore> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                //string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                FileStoreMgr fileStoreMgr = new FileStoreMgr();
                result = fileStoreMgr.MultiFileStore(listObj, ConfigMgr.GetTargetPath());
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

        public SigmaResultType GetFileType(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                FileStoreMgr fileStoreMgr = new FileStoreMgr();
                result = fileStoreMgr.GetFileType(codeCategory);
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

        #region UploadedFileInfo

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

        #region SigmaCode

        public SigmaResultType GetSigmaCode(string code, string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.GetSigmaCode(code ,codeCategory);
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

        public SigmaResultType ListSigmaCode()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.ListSigmaCode(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters);
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

        public SigmaResultType AddSigmaCode(TypeSigmaCode objSigmaCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.AddSigmaCode(objSigmaCode);
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

        public SigmaResultType UpdateSigmaCode(TypeSigmaCode objSigmaCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.UpdateSigmaCode(objSigmaCode);
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

        public SigmaResultType RemoveSigmaCode(TypeSigmaCode objSigmaCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.RemoveSigmaCode(objSigmaCode);
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

        public SigmaResultType MultiSigmaCode(List<TypeSigmaCode> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.MultiSigmaCode(listObj);
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

        #region SigmaCodeCategory
        public SigmaResultType GetSigmaCodeCategory(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.GetSigmaCodeCategory(codeCategory);
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

        public SigmaResultType ListSigmaCodeCategory()
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

                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.ListSigmaCodeCategory(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddSigmaCodeCategory(TypeSigmaCodeCategory objSigmaCodeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.AddSigmaCodeCategory(objSigmaCodeCategory);
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

        public SigmaResultType UpdateSigmaCodeCategory(TypeSigmaCodeCategory objSigmaCodeCategory)
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

        public SigmaResultType RemoveSigmaCodeCategory(TypeSigmaCodeCategory objSigmaCodeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.RemoveSigmaCodeCategory(objSigmaCodeCategory);
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

        public SigmaResultType MultiSigmaCodeCategory(List<TypeSigmaCodeCategory> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
                result = sigmaCodeMgr.MultiSigmaCodeCategory(listObj);
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

        #region Costcode 

        public SigmaResultType GetCostCode(string costCodeId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.GetCostCode(costCodeId);
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

        public SigmaResultType ListCostCode()
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
                
                //generate template
                costCodeMgr.SetProjectCostCodeTemplate(ConfigMgr.GetDynamicTemplateFilePath("costcode"));

                result = costCodeMgr.ListCostCode(offset, max, s_option, s_key, o_option, o_desc);

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


        public SigmaResultType AddCostCode(TypeCostCode objCostCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.AddCostCode(objCostCode);
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

        public SigmaResultType UpdateCostCode(TypeCostCode objCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.UpdateCostCode(objCostCode);
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

        public SigmaResultType RemoveCostCode(TypeCostCode objCostCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.RemoveCostCode(objCostCode);
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

        public SigmaResultType MultiCostCode(List<TypeCostCode> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CostCodeMgr costCodeMgr = new CostCodeMgr();
                result = costCodeMgr.MultiCostCode(listObj);
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

        #region component

        public SigmaResultType GetComponent(string componentId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentMgr componentMgr = new ComponentMgr();
                result = componentMgr.GetComponent(componentId);
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

        public SigmaResultType ListComponent()
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

                ComponentMgr componentMgr = new ComponentMgr();
                result = componentMgr.ListComponent(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddComponent(TypeComponent objComponent)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentMgr componentMgr = new ComponentMgr();
                result = componentMgr.AddComponent(objComponent);
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

        public SigmaResultType UpdateComponent(TypeComponent objComponent)
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

        public SigmaResultType RemoveComponent(TypeComponent objComponent)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentMgr componentMgr = new ComponentMgr();
                result = componentMgr.RemoveComponent(objComponent);
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

        public SigmaResultType MultiComponent(List<TypeComponent> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentMgr componentMgr = new ComponentMgr();
                result = componentMgr.MultiComponent(listObj);
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

        #region ComponentCustomField
        public SigmaResultType GetComponentCustomField(string componentId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentCustomFieldMgr componentCustomFieldMgr = new ComponentCustomFieldMgr();
                result = componentCustomFieldMgr.GetComponentCustomField(componentId);
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

        public SigmaResultType ListComponentCustomField()
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

                ComponentCustomFieldMgr componentCustomFieldMgr = new ComponentCustomFieldMgr();
                result = componentCustomFieldMgr.ListComponentCustomField(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddComponentCustomField(TypeComponentCustomField objComponentCustomField)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentCustomFieldMgr componentCustomFieldMgr = new ComponentCustomFieldMgr();
                result = componentCustomFieldMgr.AddComponentCustomField(objComponentCustomField);
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

        public SigmaResultType UpdateComponentCustomField(TypeComponentCustomField objComponentCustomField)
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

        public SigmaResultType RemoveComponentCustomField(TypeComponentCustomField objComponentCustomField)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentCustomFieldMgr componentCustomFieldMgr = new ComponentCustomFieldMgr();
                result = componentCustomFieldMgr.RemoveComponentCustomField(objComponentCustomField);
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

        public SigmaResultType MultiComponentCustomField(List<TypeComponentCustomField> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentCustomFieldMgr componentCustomFieldMgr = new ComponentCustomFieldMgr();
                result = componentCustomFieldMgr.MultiComponentCustomField(listObj);
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

        #region Material

        public SigmaResultType GetMaterialFile(string filePath, string exportFilePath)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ImportMgr materialMgr = new ImportMgr();
                result = materialMgr.ImportMeterialLib(filePath, exportFilePath);
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

        public SigmaResultType GetMaterial(string materialId)
        {
            SigmaResultType result = new SigmaResultType();
            
            try
            {
                MaterialMgr materialMgr = new MaterialMgr();
                result = materialMgr.GetMaterial(materialId);
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

        public SigmaResultType ListMaterial()
        {
            SigmaResultType result = new SigmaResultType();
            
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;

                //Dictionary<string, string> dictionary = new Dictionary<string, string>();
                //dictionary.Add("DisciplineCode", queryStr["DisciplineCode"]);
                //dictionary.Add("TaskCategoryId", queryStr["TaskCategoryId"]);
                //dictionary.Add("TaskTypeId", queryStr["TaskTypeId"]);
                //dictionary.Add("Description", queryStr["Description"]);

                //string max = queryStr["max"];
                //string offset = queryStr["offset"];
                //string o_option = queryStr["o_option"];
                //string o_desc = queryStr["o_desc"];

                MaterialMgr materialMgr = new MaterialMgr();
                result = materialMgr.ListMaterial(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters);
                
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

        public SigmaResultType AddMaterial(TypeMaterial objMaterial)
        {
            SigmaResultType result = new SigmaResultType();
            
            try
            {
                MaterialMgr materialMgr = new MaterialMgr();
                result = materialMgr.AddMaterialInfo(objMaterial);
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

        public SigmaResultType UpdateMaterial(TypeMaterial objMaterial)
        {
            SigmaResultType result = new SigmaResultType();
            
            try
            {
                MaterialMgr materialMgr = new MaterialMgr();
                result = materialMgr.AddMaterialInfo(objMaterial);
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

        public SigmaResultType RemoveMaterial(TypeMaterial objMaterial)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MaterialMgr materialMgr = new MaterialMgr();
                result = materialMgr.RemoveMaterial(objMaterial);
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

        public SigmaResultType MultiMaterial(List<TypeMaterial> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                MaterialMgr materialMgr = new MaterialMgr();
                result = materialMgr.MultiMaterial(listObj);
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

        #region MaterialCustomField

        public SigmaResultType GetMaterialCustomFieldWithCustomField(string materialId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();
                result = materialCustomFieldMgr.GetMaterialCustomFieldWithCustomField(materialId);
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

        //public SigmaResultType GetMaterialCustomField(string )
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();
        //        result = materialCustomFieldMgr.GetMaterialCustomField();
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

        //public SigmaResultType ListMaterialCustomField()
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

        //        MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();
        //        result = materialCustomFieldMgr.ListMaterialCustomField(offset, max, s_option, s_key, o_option, o_desc);
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

        //public SigmaResultType AddMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();
        //        result = materialCustomFieldMgr.AddMaterialCustomField(objMaterialCustomField);
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

        //public SigmaResultType UpdateMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
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

        //public SigmaResultType RemoveMaterialCustomField(TypeMaterialCustomField objMaterialCustomField)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();
        //        result = materialCustomFieldMgr.RemoveMaterialCustomField(objMaterialCustomField);
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

        //public SigmaResultType MultiMaterialCustomField(List<TypeMaterialCustomField> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();
        //        result = materialCustomFieldMgr.MultiMaterialCustomField(listObj);
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

        #endregion MaterialCustomField

        #region consumable

        public SigmaResultType GetConsumable(string consumableId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ConsumableMgr consumableMgr = new ConsumableMgr();
                result = consumableMgr.GetConsumable(consumableId);
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

        public SigmaResultType ListConsumable()
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

                ConsumableMgr consumableMgr = new ConsumableMgr();
                result = consumableMgr.ListConsumable(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddConsumable(TypeConsumable objConsumable)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ConsumableMgr consumableMgr = new ConsumableMgr();
                result = consumableMgr.AddConsumable(objConsumable);
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

        public SigmaResultType UpdateConsumable(TypeConsumable objConsumable)
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

        public SigmaResultType RemoveConsumable(TypeConsumable objConsumable)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ConsumableMgr consumableMgr = new ConsumableMgr();
                result = consumableMgr.RemoveConsumable(objConsumable);
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

        public SigmaResultType MultiConsumable(List<TypeConsumable> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ConsumableMgr consumableMgr = new ConsumableMgr();
                result = consumableMgr.MultiConsumable(listObj);
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

        #endregion Consumable

        #region Company


        public SigmaResultType GetCompany(string companyId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CompanyMgr companyMgr = new CompanyMgr();
                result = companyMgr.GetCompany(companyId);
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

        public SigmaResultType ListCompany()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CompanyMgr companyMgr = new CompanyMgr();
                result = companyMgr.ListCompany(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters);
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

        public SigmaResultType AddCompany(TypeCompany objCompany)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                CompanyMgr companyMgr = new CompanyMgr();
                result = companyMgr.AddCompany(objCompany);
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

        public SigmaResultType UpdateCompany(TypeCompany objCompany)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                result.IsSuccessful = true;
                CompanyMgr companyMgr = new CompanyMgr();
                result = companyMgr.UpdateCompany(objCompany);

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

        public SigmaResultType RemoveCompany(TypeCompany objCompany)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CompanyMgr companyMgr = new CompanyMgr();
                result = companyMgr.RemoveCompany(objCompany);
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

        public SigmaResultType MultiCompany(List<TypeCompany> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                CompanyMgr companyMgr = new CompanyMgr();
                result = companyMgr.MultiCompany(listObj);
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

        #region Equipment

        public SigmaResultType GetEquipment(string equipmentId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                EquipmentMgr equipmentMgr = new EquipmentMgr();
                result = equipmentMgr.GetEquipment(equipmentId);
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

        public SigmaResultType ListEquipment()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                
                //Dictionary<string, string> dictionary = new Dictionary<string, string>();
                //dictionary.Add("EquipmentCodeMain", queryStr["EquipmentCodeMain"]);
                //dictionary.Add("EquipmentCodeSub", queryStr["EquipmentCodeSub"]);
                //dictionary.Add("ThirdLevel", queryStr["ThirdLevel"]);

                //string max = queryStr["max"];
                //string offset = queryStr["offset"];
                //string o_option = queryStr["o_option"];
                //string o_desc = queryStr["o_desc"];

                EquipmentMgr equipmentMgr = new EquipmentMgr();
                result = equipmentMgr.ListEquipment(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters);
                
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

        public SigmaResultType AddEquipment(TypeEquipment objEquipment)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                EquipmentMgr equipmentMgr = new EquipmentMgr();
                result = equipmentMgr.AddEquipmentInfo(objEquipment);
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

        public SigmaResultType UpdateEquipment(TypeEquipment objEquipment)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                EquipmentMgr materialMgr = new EquipmentMgr();
                result = materialMgr.AddEquipmentInfo(objEquipment);
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

        //public SigmaResultType RemoveEquipment(TypeEquipment objEquipment)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        EquipmentMgr equipmentMgr = new EquipmentMgr();
        //        result = equipmentMgr.RemoveEquipment(objEquipment);
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

        public SigmaResultType MultiEquipment(List<TypeEquipment> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                EquipmentMgr equipmentMgr = new EquipmentMgr();
                result = equipmentMgr.MultiEquipment(listObj);
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

        #endregion Equipment

        #region EquipmentCustomField

        public SigmaResultType GetEquipmentCustomFieldWithCustomField(string materialId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                EquipmentCustomFieldMgr equipmentCustomFieldMgr = new EquipmentCustomFieldMgr();
                result = equipmentCustomFieldMgr.GetEquipmentCustomFieldWithCustomField(materialId);
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

        //public SigmaResultType GetEquipmentCustomField(string id)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        EquipmentCustomFieldMgr equipmentCustomFieldMgr = new EquipmentCustomFieldMgr();
        //        result = equipmentCustomFieldMgr.GetEquipmentCustomField(id);
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

        //public SigmaResultType ListEquipmentCustomField()
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

        //        EquipmentCustomFieldMgr equipmentCustomFieldMgr = new EquipmentCustomFieldMgr();
        //        result = equipmentCustomFieldMgr.ListEquipmentCustomField(offset, max, s_option, s_key, o_option, o_desc);
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

        //public SigmaResultType AddEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        EquipmentCustomFieldMgr equipmentCustomFieldMgr = new EquipmentCustomFieldMgr();
        //        result = equipmentCustomFieldMgr.AddEquipmentCustomField(objEquipmentCustomField);
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

        //public SigmaResultType UpdateEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
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

        //public SigmaResultType RemoveEquipmentCustomField(TypeEquipmentCustomField objEquipmentCustomField)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        EquipmentCustomFieldMgr equipmentCustomFieldMgr = new EquipmentCustomFieldMgr();
        //        result = equipmentCustomFieldMgr.RemoveEquipmentCustomField(objEquipmentCustomField);
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

        //public SigmaResultType MultiEquipmentCustomField(List<TypeEquipmentCustomField> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        EquipmentCustomFieldMgr equipmentCustomFieldMgr = new EquipmentCustomFieldMgr();
        //        result = equipmentCustomFieldMgr.MultiEquipmentCustomField(listObj);
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

        #endregion EquipmentCustomField

        #region Common Code

        #region Progress Type 

        public SigmaResultType GetProgressType(string progressTypeId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.GetProgressType(progressTypeId);
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

        public SigmaResultType ListProgressType()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                //Dictionary<string, string> dictionary = new Dictionary<string, string>();
                //dictionary.Add("DisciplineCode", queryStr["DisciplineCode"]);

                //string max = queryStr["max"];
                //string offset = queryStr["offset"];
                //string o_option = queryStr["o_option"];
                //string o_desc = queryStr["o_desc"];

                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.ListProgressType(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters);
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

        public SigmaResultType AddProgressType(TypeProgressType objProgressType)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.AddProgressTypeInfo(objProgressType);
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

        public SigmaResultType UpdateProgressType(TypeProgressType objProgressType)
        {
            SigmaResultType result = new SigmaResultType();
            
            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.AddProgressTypeInfo(objProgressType);
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

        //public SigmaResultType RemoveProgressType(TypeProgressType objProgressType)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
        //        result = progressTypeMgr.RemoveProgressType(objProgressType);
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

        public SigmaResultType MultiProgressType(List<TypeProgressType> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.MultiProgressType(listObj);
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

        public SigmaResultType ListProgressTypeByTaskCateogry(string taskCategoryId, string taskTypeId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.ListProgressTypeByTaskCateogry(taskCategoryId, taskTypeId);
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

        #endregion Progress Type 

        #region Progress Step

        //public SigmaResultType GetProgressStep(string progressStepId)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        ProgressStepMgr progressStepMgr = new ProgressStepMgr();
        //        result = progressStepMgr.GetProgressStep(progressStepId);
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

        //public SigmaResultType ListProgressStep()
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

        //        ProgressStepMgr progressStepMgr = new ProgressStepMgr();
        //        result = progressStepMgr.ListProgressStep(offset, max, s_option, s_key, o_option, o_desc);
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

        //public SigmaResultType AddProgressStep(TypeProgressStep objProgressStep)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        ProgressStepMgr progressStepMgr = new ProgressStepMgr();
        //        result = progressStepMgr.AddProgressStep(objProgressStep);
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

        //public SigmaResultType UpdateProgressStep(TypeProgressStep objProgressStep)
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

        //public SigmaResultType RemoveProgressStep(TypeProgressStep objProgressStep)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProgressStepMgr progressStepMgr = new ProgressStepMgr();
        //        result = progressStepMgr.RemoveProgressStep(objProgressStep);
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

        //public SigmaResultType MultiProgressStep(List<TypeProgressStep> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProgressStepMgr progressStepMgr = new ProgressStepMgr();
        //        result = progressStepMgr.MultiProgressStep(listObj);
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

        public SigmaResultType GetProgressStepByProgessTypeId(string progressTypeId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProgressTypeMgr progressStepMgr = new ProgressTypeMgr();
                result = progressStepMgr.GetProgressStepByProgessTypeId(progressTypeId);
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

        #endregion Progress Step

        #region ProgressTypeMap

        //public SigmaResultType GetProgressTypeMap(string progressTypeMapId)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
        //        result = progressTypeMgr.GetProgressTypeMap(progressTypeMapId);
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

        //public SigmaResultType ListProgressTypeMap()
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

        //        ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
        //        result = progressTypeMgr.ListProgressTypeMap(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddProgressTypeMap(TypeProgressTypeMap objProgressTypeMap)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.AddProgressTypeMapInfo(objProgressTypeMap);
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

        public SigmaResultType UpdateProgressTypeMap(TypeProgressTypeMap objProgressTypeMap)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.AddProgressTypeMapInfo(objProgressTypeMap);
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

        //public SigmaResultType RemoveProgressTypeMap(TypeProgressTypeMap objProgressTypeMap)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
        //        result = progressTypeMgr.RemoveProgressTypeMap(objProgressTypeMap);
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

        //public SigmaResultType MultiProgressTypeMap(List<TypeProgressTypeMap> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
        //        result = progressTypeMgr.MultiProgressTypeMap(listObj);
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

        public SigmaResultType GetProgressTypeMapByDisciplineCode(string taskCategoryId, string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ProgressTypeMgr progressTypeMgr = new ProgressTypeMgr();
                result = progressTypeMgr.GetProgressTypeMapByDisciplineCode(taskCategoryId, disciplineCode);
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

        #endregion ProgressTypeMap

        #region Drawing Type Management

        //public SigmaResultType GetSigmaCode(string codeCategory)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
        //        result = sigmaCodeMgr.GetSigmaCode(codeCategory);
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

        //public SigmaResultType ListSigmaCode()
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

        //        SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
        //        result = sigmaCodeMgr.ListSigmaCode(offset, max, s_option, s_key, o_option, o_desc);
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

        //public SigmaResultType AddSigmaCode(TypeSigmaCode objSigmaCode)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
        //        result = sigmaCodeMgr.AddSigmaCode(objSigmaCode);
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

        //public SigmaResultType UpdateSigmaCode(TypeSigmaCode objSigmaCode)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
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

        //public SigmaResultType RemoveSigmaCode(TypeSigmaCode objSigmaCode)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
        //        result = sigmaCodeMgr.RemoveSigmaCode(objSigmaCode);
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

        //public SigmaResultType MultiSigmaCode(List<TypeSigmaCode> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
        //        result = sigmaCodeMgr.MultiSigmaCode(listObj);
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

        #endregion Drawing Type Management

        #region Task Category and Type

        //public SigmaResultType GetTaskCategory(string taskCategoryId)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
        //        result = taskCategoryMgr.GetTaskCategory(taskCategoryId);
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

        //public SigmaResultType ListTaskCategory()
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

        //        TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
        //        result = taskCategoryMgr.ListTaskCategory(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddTaskCategory(TypeTaskCategory objTaskCategory)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
                result = taskCategoryMgr.AddTaskCategory(objTaskCategory);
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

        public SigmaResultType UpdateTaskCategory(TypeTaskCategory objTaskCategory)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
                result = taskCategoryMgr.UpdateTaskCategory(objTaskCategory);
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

        public SigmaResultType RemoveTaskCategory(TypeTaskCategory objTaskCategory)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
                result = taskCategoryMgr.RemoveTaskCategory(objTaskCategory);
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

        //public SigmaResultType MultiTaskCategory(List<TypeTaskCategory> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
        //        result = taskCategoryMgr.MultiTaskCategory(listObj);
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

        public SigmaResultType ListTaskCategoryWithTaskType()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
                result = taskCategoryMgr.ListTaskCategoryWithTaskType();
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

        //public SigmaResultType GetTaskType(string taskTypeId)
        //{
        //    SigmaResultType result = new SigmaResultType();
        //    try
        //    {
        //        TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
        //        result = taskTypeMgr.GetTaskType(taskTypeId);
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

        //public SigmaResultType ListTaskType()
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

        //        TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
        //        result = taskTypeMgr.ListTaskType(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddTaskType(TypeTaskType objTaskType)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
                result = taskCategoryMgr.AddTaskType(objTaskType);
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

        public SigmaResultType UpdateTaskType(TypeTaskType objTaskType)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
                result = taskCategoryMgr.UpdateTaskType(objTaskType);
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

        public SigmaResultType RemoveTaskType(TypeTaskType objTaskType)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
                result = taskCategoryMgr.RemoveTaskType(objTaskType);
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

        //public SigmaResultType MultiTaskType(List<TypeTaskType> listObj)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    try
        //    {
        //        TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
        //        result = taskTypeMgr.MultiTaskType(listObj);
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
        
        #endregion Task Category and Type

        #endregion Common Code

        #region ComponentProgressMgr

        public SigmaResultType GetComponentProgress(string componentProgressId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentProgressMgr componentProgressMgr = new ComponentProgressMgr();
                result = componentProgressMgr.GetComponentProgress(componentProgressId);
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

        public SigmaResultType ListComponentProgress()
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

                ComponentProgressMgr componentProgressMgr = new ComponentProgressMgr();
                result = componentProgressMgr.ListComponentProgress(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType ListComponentProgressStep()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                var queryStr = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
                string max = queryStr["max"];
                string offset = queryStr["offset"];

                List<string> s_option = new List<string>();
                List<string> s_key = new List<string>();
                s_option.Add("@ComponentId");
                s_key.Add(queryStr["ComponentId"]);
                 

                string o_option = queryStr["o_option"];
                string o_desc = queryStr["o_desc"];

                ComponentProgressMgr componentProgressMgr = new ComponentProgressMgr();
                result = componentProgressMgr.ListComponentProgressStep(offset, max, s_option, s_key, o_option, o_desc);
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

        public SigmaResultType AddComponentProgress(TypeComponentProgress objComponentProgress)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                ComponentProgressMgr componentProgressMgr = new ComponentProgressMgr();
                result = componentProgressMgr.AddComponentProgress(objComponentProgress);
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

        public SigmaResultType UpdateComponentProgress(TypeComponentProgress objComponentProgress)
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

        public SigmaResultType RemoveComponentProgress(TypeComponentProgress objComponentProgress)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentProgressMgr componentProgressMgr = new ComponentProgressMgr();
                result = componentProgressMgr.RemoveComponentProgress(objComponentProgress);
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

        public SigmaResultType MultiComponentProgress(List<TypeComponentProgress> listObj)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                ComponentProgressMgr componentProgressMgr = new ComponentProgressMgr();
                result = componentProgressMgr.MultiComponentProgress(listObj);
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
