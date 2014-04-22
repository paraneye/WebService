using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using Element.Shared.Common;
using Element.Sigma.Web.Biz;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Auth;

using System.Web;
using System.ServiceModel.Activation;

namespace Element.Sigma.Web.Service.Auth
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SigmaAuth" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SigmaAuth.svc or SigmaAuth.svc.cs at the Solution Explorer and start debugging.
    public class SigmaAuth : ISigmaAuth
    {
        public SigmaResultType GetUser(string userId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                UserMgr userMgr = new UserMgr();
                result = userMgr.GetUser(userId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ListUser()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                UserMgr userMgr = new UserMgr();
                result = userMgr.ListUser();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType AddUser(string userName)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                UserMgr userMgr = new UserMgr();
                result = userMgr.AddUser(userName);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }


        public SigmaResultType RemoveUser(string userId)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                UserMgr userMgr = new UserMgr();
                result = userMgr.RemoveUser(userId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType Login(string userId, string passwd)
        {
            SigmaResultType result = new SigmaResultType();
            AuthMgr authMgr = new AuthMgr();
            try
            {
                result = authMgr.Login(userId, passwd);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ForgotPassword(string userId, string email)
        {
            SigmaResultType result = new SigmaResultType();
            MailMgr mailMgr = new MailMgr();
            try
            {
                result = mailMgr.ForgotPassword(userId, email);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType GetLicense()
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                AuthMgr authMgr = new AuthMgr();
                result = authMgr.GetLicense();
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        public SigmaResultType ListScreenBySigmaUserId(string sigmaUserId)
        {
            SigmaResultType result = new SigmaResultType();
            try
            {
                AuthMgr authMgr = new AuthMgr();
                result = authMgr.ListScreensBySigmaUserId(sigmaUserId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

    }
}
