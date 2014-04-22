using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web;
using Element.Sigma.Web.Biz;
using Element.Reveal.DataLibrary;

namespace Element.Sigma.Web.Service.Prev
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class UserService : IUserService
    {
        //#region "Get, Select"
        
        ///// <summary>
        ///// Retrieve Loginaccount object which account contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="loginAccountId">Loginaccount unique identifier to search for</param>
        ///// <returns>LoginaccountDTO</returns>
        //public LoginaccountDTO GetLoginAccountById(int loginAccountId)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginAccountById(loginAccountId);
        //}

        ///// <summary>
        ///// Retrieve Loginaccount object which account contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="loginAccountId">Loginaccount unique identifier to search for</param>
        ///// <returns>LoginaccountDTO</returns>
        //public LoginaccountDTO JsonGetLoginAccountById(string loginAccountId)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginAccountById(Int32.Parse(loginAccountId));
        //}

        ///// <summary>
        ///// Retrieve LoginaccountAndModuleUserGroup object which account contains the specified SharePointUser to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="sharePointUser">SharePointUser to search for</param>
        ///// <returns>LoginaccountAndModuleUserGroup</returns>
        //public LoginaccountAndModuleUserGroup GetLoginaccountBySharePointUser(string sharePointUser)
        //{
        //    //return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountBySharePointUser(sharePointUser);

        //    LoginaccountAndModuleUserGroup _login = new LoginaccountAndModuleUserGroup();

        //    LoginaccountDTO _dto = (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountBySharePointUser(sharePointUser);
        //    if (_dto != null)
        //    {
        //        _login.login = _dto;
        //        _login.moduleusergroup = (new Element.Reveal.Server.BALC.UserReader()).GetLoginModuleUsergroupByLogin(_dto.LoginAccountID);
        //    }

        //    return _login;
        //}

        ///// <summary>
        ///// Retrieve LoginaccountAndModuleUserGroup object which account contains the specified SharePointUser to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="sharePointUser">SharePointUser to search for</param>
        ///// <returns>LoginaccountAndModuleUserGroup</returns>
        //public LoginaccountAndModuleUserGroup JsonGetLoginaccountBySharePointUser(string sharePointUser)
        //{
        //    //return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountBySharePointUser(sharePointUser);

        //    LoginaccountAndModuleUserGroup _login = new LoginaccountAndModuleUserGroup();

        //    LoginaccountDTO _dto = (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountBySharePointUser(sharePointUser);
        //    if (_dto != null)
        //    {
        //        _login.login = _dto;
        //        _login.moduleusergroup = (new Element.Reveal.Server.BALC.UserReader()).GetLoginModuleUsergroupByLogin(_dto.LoginAccountID);
        //    }

        //    return _login;
        //}
        
        ///// <summary>
        ///// Retrieve Loginaccount object which account contains the specified LoginName to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="loginName">LoginName to search for</param>
        ///// <returns>LoginaccountDTO</returns>
        //public LoginaccountDTO GetLoginaccountByLoginName(string loginName)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountByLoginName(loginName);
        //}

        /// <summary>
        /// Retrieve Loginaccount object which account contains the specified LoginName to match.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="loginName">LoginName to search for</param>
        /// <returns>LoginaccountDTO</returns>
        public LoginaccountDTO JsonGetLoginaccountByLoginName(string loginName)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetLoginaccountByLoginName(Helper.RemoveJsonParameterWrapper(loginName));
        }

        ///// <summary>
        ///// Retrieve Loginaccount object which account contains the specified PersonnelID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="personnelId">PersonnelID to search for</param>
        ///// <returns>LoginaccountDTO</returns>
        //public LoginaccountDTO GetLoginaccountByPesonnelID(int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountByPesonnelID(personnelId);
        //}

        /// <summary>
        /// Retrieve Loginaccount object which account contains the specified PersonnelID to match.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="personnelId">PersonnelID to search for</param>
        /// <returns>LoginaccountDTO</returns>
        public LoginaccountDTO JsonGetLoginaccountByPesonnelID(string sigmaUserlId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetLoginaccountByPesonnelID(Helper.RemoveJsonParameterWrapper(sigmaUserlId));
        }

        //public LoginaccountAndModuleUserGroup GetUserLogin(string loginName, byte[] bPassword, bool isdomainUser)
        //{
        //    LoginaccountAndModuleUserGroup _login = new LoginaccountAndModuleUserGroup();
        //    Element.Reveal.Server.BALC.UserReader ureader = new Element.Reveal.Server.BALC.UserReader();

        //    //first get loginAccountDTO to check if the account came from domain server.
        //    if (isdomainUser)
        //    {
        //        bool isSucc = ureader.LoginActiveDir(Helper.ActiveDirectoryServer, loginName, System.Text.UTF8Encoding.UTF8.GetString(bPassword));
        //        if (isSucc)
        //        {
        //            LoginaccountDTO _dto = ureader.GetLoginAuthenticate(loginName, null);
        //            if (_dto != null)
        //            {
        //                _login.login = _dto;
        //                _login.moduleusergroup = ureader.GetLoginModuleUsergroupByLogin(_dto.LoginAccountID);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        LoginaccountDTO _dto = ureader.GetLoginAuthenticate(loginName, System.Text.UTF8Encoding.UTF8.GetString(bPassword));
        //        if (_dto != null)
        //        {
        //            _login.login = _dto;
        //            _login.moduleusergroup = ureader.GetLoginModuleUsergroupByLogin(_dto.LoginAccountID);
        //        }
        //    }

        //    return _login;
        //}

        //public MobileLoginDTO MobileGetUserLogin(string loginName, byte[] bPassword, bool isdomainUser, DateTime workDate, bool brasscheck)
        //{
        //    MobileLoginDTO _login = new MobileLoginDTO();
        //    LoginaccountDTO _dto = null;

        //    Element.Sigma.Web.Biz.TrueTask.Common ureader = new Biz.TrueTask.Common();

        //    //first get loginAccountDTO to check if the account came from domain server.
        //    if (isdomainUser)
        //    {
        //        bool isSucc = ureader.LoginActiveDir(Helper.ActiveDirectoryServer, loginName, System.Text.UTF8Encoding.UTF8.GetString(bPassword));
        //        if (isSucc)
        //            _dto = ureader.GetLoginAuthenticate(loginName, null);
        //    }
        //    else
        //        _dto = ureader.GetLoginAuthenticate(loginName, System.Text.UTF8Encoding.UTF8.GetString(bPassword));

        //    if (_dto != null)
        //    {
        //        string[] strLogin = Helper.SPLogin.Split(';');
        //        if (strLogin.Length >= 2)
        //        {
        //            _login.SPUser = strLogin[0];
        //            _login.SPPassword = strLogin[1];
        //        }

        //        strLogin = Helper.WebDAVLogin.Split(';');
        //        if (strLogin.Length >= 2)
        //        {
        //            _login.WDUser = strLogin[0];
        //            _login.WDPassword = strLogin[1];
        //        }

        //        _login.UserName = string.Format("{0}, {1}", _dto.LastName, _dto.FirstName);
        //        _login.EMail = _dto.EMail;
        //        _login.DepartmentName = _dto.DepartmentName;
        //        _login.CurProjectID = _dto.CurProjectID;
        //        _login.CurModuleID = _dto.CurModuleID;
        //        _login.UserGroupID = loginName == OwnerLoginName.Admin ? 1 : _dto.UserGroupID;
        //        _login.PersonnelID = _dto.personnel.PersonnelID;
        //        _login.FIWPID = _dto.personnel.CurFIWPID;
        //        _login.FirstName = _dto.personnel.FName;
        //        _login.LastName = _dto.personnel.LName;
        //        _login.LoginName = _dto.LoginName;

        //        Guid guid = Guid.NewGuid();
        //        String key = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(loginName)).ToString();
        //        String Token = key + ";" + guid.ToString();
        //        _login.SessionKey = Token;

        //        HttpRuntime.Cache.Insert(loginName, guid.ToString());

        //        if (_dto.CurProjectID > 0)
        //            _login.SPURL = ureader.GetProjectPath(_dto.CurProjectID, "SharePointURL", string.Empty);

        //        if (brasscheck)
        //        {
        //            try
        //            {
        //                // 테스트 위해 임시 주석 처리
        //                //if (_dto.DepartmentID == 14)
        //                //{
        //                List<DailybrassDTO> brassList = null;
        //                brassList = (new Element.Sigma.Web.Biz.TrueTask.Build()).GetDailybrassByForemanPersonnelWorkDate(_dto.CurProjectID, _dto.CurModuleID, _dto.PersonnelID, workDate);
        //                if (brassList.Count == 0)
        //                {
        //                    //DailybrassDTO brass = new DailybrassDTO();
        //                    //brass.DTOStatus = (int)RowStatus.New;
        //                    //brass.ProjectID = _dto.CurProjectID;
        //                    //brass.ModuleID = _dto.CurModuleID;
        //                    //brass.ForemanPersonnelID = _dto.PersonnelID;
        //                    //brass.WorkDate = workDate;
        //                    //brassList.Add(brass);

        //                    //brassList = (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDailybrass(brassList);
        //                }
        //                else
        //                {
        //                    _login.IsDailyBrass = 1;
        //                }
        //                //}
        //            }
        //            catch (Exception e)
        //            {
        //            }
        //        }
        //    }

        //    return _login;
        //}

        public MobileLoginDTO JsonMobileGetUserLogin(string loginName, string bPassword, string isdomainUser, string workDate, string brasscheck)
        {
            MobileLoginDTO _login = new MobileLoginDTO();
            LoginaccountDTO _dto = null;

            byte[] bytePassword = System.Convert.FromBase64String(bPassword);  //아직 Password가 암호화 안되어 있어 string으로 처리
            StringBuilder strPwd = new StringBuilder();
            for (int i = 0; i < bytePassword.Length; i++)
            {
                strPwd.Append(bytePassword[i].ToString("X2"));
            }

            bool boolDomainUser = bool.Parse(isdomainUser);
            bool boolBrasscheck = bool.Parse(brasscheck);
            DateTime DtWorkDate = DateTime.Parse(Helper.ConvertStringToDateTimeString(Helper.RemoveJsonParameterWrapper(workDate)));

            #region  data가 없어 test로 생성
            //_login.SPUser = "SPUser";
            //_login.SPPassword = "SPPassword";
            //_login.WDUser = "WDUser";
            //_login.WDPassword = "WDPassword";
            //_login.UserName = string.Format("{0}, {1}", "_dto.LastName", "_dto.FirstName");
            //_login.EMail = "_dto.EMail";
            //_login.DepartmentName = "_dto.DepartmentName";
            //_login.CurProjectID = 11;
            //_login.CurModuleID = 21;
            //_login.UserGroupID = loginName == OwnerLoginName.Admin ? 1 : 31;
            //_login.PersonnelID = 1;
            //_login.FIWPID = 101;
            //_login.FirstName = "_dto.personnel.FName";
            //_login.LastName = "_dto.personnel.LName";
            //_login.LoginName = "_dto.LoginName";

            //Guid guidTest = Guid.NewGuid();
            //String keyTest = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(loginName)).ToString();
            //String TokenTest = keyTest + ";" + guidTest.ToString();
            //_login.SessionKey = TokenTest;

            //_login.SPURL = "SharePointURL";

            //return _login;
            #endregion  data가 없어 test로 생성

            Element.Sigma.Web.Biz.TrueTask.Common ureader = new Biz.TrueTask.Common();

            //first get loginAccountDTO to check if the account came from domain server.
            if (boolDomainUser)
            {
                bool isSucc = ureader.LoginActiveDir(Helper.ActiveDirectoryServer, loginName, strPwd.ToString().ToLower());  //byte로 바로 확인
                //bool isSucc = ureader.LoginActiveDir(Helper.ActiveDirectoryServer, loginName, System.Text.UTF8Encoding.UTF8.GetString(bytePassword));
                //bool isSucc = ureader.LoginActiveDir(Helper.ActiveDirectoryServer, loginName, bPassword);  //아직 Password가 암호화 안되어 있어 string으로 처리
                if (isSucc)
                    _dto = ureader.GetLoginAuthenticate(loginName, null);
            }
            else
            {
                _dto = ureader.GetLoginAuthenticate(loginName, strPwd.ToString().ToLower());  //byte로 바로 확인
                //_dto = ureader.GetLoginAuthenticate(loginName, System.Text.UTF8Encoding.UTF8.GetString(bytePassword));
                //_dto = ureader.GetLoginAuthenticate(loginName, bPassword);
            }

            if (_dto != null)
            {
                //사용할건지? 확인
                //// sharepoint user?
                //string[] strLogin = Helper.SPLogin.Split(';');
                //if (strLogin.Length >= 2)
                //{
                //    _login.SPUser = strLogin[0];
                //    _login.SPPassword = strLogin[1];
                //}

                //// user?
                //strLogin = Helper.WebDAVLogin.Split(';');
                //if (strLogin.Length >= 2)
                //{
                //    _login.WDUser = strLogin[0];
                //    _login.WDPassword = strLogin[1];
                //}

                _login.UserName = string.Format("{0}, {1}", _dto.LastName, _dto.FirstName);
                _login.EMail = _dto.EMail;
                _login.DepartmentName = _dto.DepartmentName;
                _login.CurProjectID = _dto.CurProjectID;
                //_login.CurModuleID = _dto.CurModuleID;
                _login.CurDisciplineCode = _dto.CurDisciplineCode;
                _login.UserGroupID = loginName == OwnerLoginName.Admin ? 1 : _dto.UserGroupID;
                _login.PersonnelId = _dto.personnel.PersonnelId;
                _login.FIWPID = _dto.personnel.CurFIWPID;
                _login.FirstName = _dto.personnel.FName;
                _login.LastName = _dto.personnel.LName;
                _login.LoginName = _dto.LoginName;
                _login.PhotoUrl = _dto.PhotoUrl;

                Guid guid = Guid.NewGuid();
                String key = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(loginName)).ToString();
                String Token = key + ";" + guid.ToString();
                _login.SessionKey = Token;

                HttpRuntime.Cache.Insert(loginName, guid.ToString());

                //if (_dto.CurProjectID > 0)
                //    _login.SPURL = ureader.GetProjectPath(_dto.CurProjectID, "SharePointURL", string.Empty);

                //boolBrasscheck 는 로그인시 사용안하기로 함(모바일 서팀장)
                //if (boolBrasscheck)
                //{
                //    try
                //    {
                //        // 테스트 위해 임시 주석 처리
                //        //if (_dto.DepartmentID == 14)
                //        //{
                //        List<DailybrassDTO> brassList = null;
                //        brassList = (new Element.Sigma.Web.Biz.TrueTask.Build()).GetDailybrassByForemanPersonnelWorkDate(_dto.CurProjectID, _dto.CurDisciplineCode, _dto.PersonnelId, DtWorkDate);
                //        if (brassList.Count == 0)
                //        {
                //            DailybrassDTO brass = new DailybrassDTO();
                //            brass.DTOStatus = (int)RowStatusNo.New;
                //            brass.ProjectID = _dto.CurProjectID;
                //            brass.DisciplineCode = _dto.CurDisciplineCode;
                //            brass.ForemanID = _dto.LoginAccountID;
                //            brass.WorkDate = DtWorkDate;
                //            brassList.Add(brass);

                //            brassList = (new Element.Sigma.Web.Biz.TrueTask.Brass()).SaveDailybrass(brassList);
                //        }
                //        else
                //        {
                //            _login.IsDailyBrass = 1;
                //        }
                //        //}
                //    }
                //    catch (Exception e)
                //    {
                //        Console.Write(e.Message);
                //    }
                //}
            }

            return _login;
        }

        public MobileLoginDTO JsonMobileUserLogin(string loginName, string bPassWord, string isdomainUser, string workDate, string brasscheck)
        {
            return JsonMobileGetUserLogin(loginName, bPassWord, isdomainUser, workDate, brasscheck);
        }

        //public MobileLoginDTO JsonGetUserLogin(string loginName)
        //{
        //    LoginaccountAndModuleUserGroup login = new LoginaccountAndModuleUserGroup();
        //    MobileLoginDTO mlogin = new MobileLoginDTO();
        //    Element.Reveal.Server.BALC.UserReader ureader = new Element.Reveal.Server.BALC.UserReader();
        //    LoginaccountDTO dto = ureader.GetLoginaccountByLoginName(loginName);

        //    //LoginaccountDTO dto = ureader.GetLoginAuthenticate(loginName, System.Text.UTF8Encoding.UTF8.GetString(bPassword));
        //    if (dto != null)
        //    {
        //        string[] strLogin = Helper.SPLogin.Split(';');
        //        if (strLogin.Length >= 2)
        //        {
        //            mlogin.SPUser = strLogin[0];
        //            mlogin.SPPassword = strLogin[1];
        //        }

        //        strLogin = Helper.WebDAVLogin.Split(';');
        //        if (strLogin.Length >= 2)
        //        {
        //            mlogin.WDUser = strLogin[0];
        //            mlogin.WDPassword = strLogin[1];
        //        }

        //        mlogin.UserName = string.Format("{0}, {1}", dto.LastName, dto.FirstName);
        //        mlogin.EMail = dto.EMail;
        //        mlogin.DepartmentName = dto.DepartmentName;
        //        mlogin.CurProjectID = dto.CurProjectID;
        //        mlogin.CurModuleID = dto.CurModuleID;
        //        mlogin.UserGroupID = loginName == OwnerLoginName.Admin ? 1 : dto.UserGroupID;
        //        mlogin.PersonnelID = dto.personnel.PersonnelID;
        //        mlogin.SessionKey = "TrueVue";

        //        if (dto.CurProjectID > 0)
        //            mlogin.SPURL = (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectPath(dto.CurProjectID, "SharePointURL", string.Empty);
        //    }
        //    return mlogin;
        //}

        //public MobileLoginDTO JsonUserLogin(string loginName, string base64PassWord)
        //{
        //    LoginaccountAndModuleUserGroup login = new LoginaccountAndModuleUserGroup();
        //    MobileLoginDTO mlogin = new MobileLoginDTO();

        //    byte[] bPassword = System.Convert.FromBase64String(base64PassWord);
        //    LoginaccountDTO dto = (new Element.Reveal.Server.BALC.UserReader()).GetLoginAuthenticate(loginName, System.Text.UTF8Encoding.UTF8.GetString(bPassword));

            
        //    if (dto != null)
        //    {
        //        string[] strLogin = Helper.SPLogin.Split(';');
        //        if (strLogin.Length >= 2)
        //        {
        //            mlogin.SPUser = strLogin[0];
        //            mlogin.SPPassword = strLogin[1];
        //        }

        //        strLogin = Helper.WebDAVLogin.Split(';');
        //        if (strLogin.Length >= 2)
        //        {
        //            mlogin.WDUser = strLogin[0];
        //            mlogin.WDPassword = strLogin[1];
        //        }

        //        mlogin.UserName = string.Format("{0}, {1}", dto.LastName, dto.FirstName);
        //        mlogin.EMail = dto.EMail;
        //        mlogin.DepartmentName = dto.DepartmentName;
        //        mlogin.CurProjectID = dto.CurProjectID;
        //        mlogin.CurModuleID = dto.CurModuleID;
        //        mlogin.UserGroupID = loginName == OwnerLoginName.Admin ? 1 : dto.UserGroupID;
        //        mlogin.PersonnelID = dto.personnel.PersonnelID;

        //        Guid guid = Guid.NewGuid();
        //        String key = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(loginName)).ToString();
        //        String Token = key + ";" + guid.ToString();

        //        HttpRuntime.Cache.Insert(loginName, guid.ToString());
        //        mlogin.SessionKey = Token; 
            
        //        if (dto.CurProjectID > 0)
        //            mlogin.SPURL = (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectPath(dto.CurProjectID, "SharePointURL", string.Empty);
        //    }

           
        //    return mlogin;
        //}

        //public List<LoginaccountDTO> GetUserAccounts()
        //{
        //    List<LoginaccountDTO> dtos = null;
        //    dtos = (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountAll();

        //    return dtos;
        //}

        //public List<LoginaccountDTO> JsonGetUserAccounts()
        //{
        //    List<LoginaccountDTO> dtos = null;
        //    dtos = (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountAll();

        //    return dtos;
        //}
        
        //public List<LoginaccountDTO> GetLoginaccountByIsDomainUser(int isDomainUser)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountByIsDomainUser(isDomainUser);
        //}

        //public List<LoginaccountDTO> JsonGetLoginaccountByIsDomainUser(string isDomainUser)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountByIsDomainUser(Int32.Parse(isDomainUser));
        //}
        
        //public List<LoginaccountDTO> GetLoginaccountByProject(int projectID)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountByProject(projectID);
        //}

        //public List<LoginaccountDTO> JsonGetLoginaccountByProject(string projectID)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountByProject(Int32.Parse(projectID));
        //}
        
        //public List<LoginaccountmoduleusergroupDTO> GetLoginModuleUsergroupByLoginID(int loginAccountId)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginModuleUsergroupByLogin(loginAccountId);
        //}

        //public List<LoginaccountmoduleusergroupDTO> JsonGetLoginModuleUsergroupByLoginID(string loginAccountId)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginModuleUsergroupByLogin(Int32.Parse(loginAccountId));
        //}
        
        //public string[] GetSPLogin()
        //{
        //    //UserName=admin;Password=admin;
        //    string[] retValue = null;
        //    string[] strSPLogin = Helper.SPLogin.Split(';');
        //    if (strSPLogin.Length >= 3)
        //    {
        //        string[] id = strSPLogin[0].Split('=');
        //        string[] pw = strSPLogin[1].Split('=');
        //        string[] domain = strSPLogin[2].Split('=');

        //        if (id.Length == 2 && pw.Length == 2 && domain.Length == 2)
        //        {
        //            retValue = new string[3];
        //            retValue[0] = id[1];
        //            retValue[1] = pw[1];
        //            retValue[2] = domain[1];
        //        }
        //    }

        //    return retValue;
        //}

        //public string[] JsonGetSPLogin()
        //{
        //    //UserName=admin;Password=admin;
        //    string[] retValue = null;
        //    string[] strSPLogin = Helper.SPLogin.Split(';');
        //    if (strSPLogin.Length >= 3)
        //    {
        //        string[] id = strSPLogin[0].Split('=');
        //        string[] pw = strSPLogin[1].Split('=');
        //        string[] domain = strSPLogin[2].Split('=');

        //        if (id.Length == 2 && pw.Length == 2 && domain.Length == 2)
        //        {
        //            retValue = new string[3];
        //            retValue[0] = id[1];
        //            retValue[1] = pw[1];
        //            retValue[2] = domain[1];
        //        }
        //    }

        //    return retValue;
        //}

        //#endregion "Get, Select"
        
        //public void ResetPassword(int loginAccountId)
        //{
        //    (new Element.Reveal.Server.BALC.UserReader()).ResetPassword(loginAccountId);
        //}

        //public void JsonResetPassword(string loginAccountId)
        //{
        //    (new Element.Reveal.Server.BALC.UserReader()).ResetPassword(Int32.Parse(loginAccountId));
        //}
        
        //public List<LoginaccountDTO> SaveLoginaccount(List<LoginaccountDTO> loginaccount)
        //{
        //    return (new UserReader()).SaveLoginaccount(loginaccount);
        //}

        //public List<LoginaccountDTO> JsonSaveLoginaccount(List<LoginaccountDTO> loginaccount)
        //{
        //    return (new UserReader()).SaveLoginaccount(loginaccount);
        //}

        //public List<LoginaccountDTO> SaveLoginaccountOnly(List<LoginaccountDTO> loginaccount)
        //{
        //    return (new UserReader()).SaveLoginaccountOnly(loginaccount);
        //}

        //public List<LoginaccountDTO> JsonSaveLoginaccountOnly(List<LoginaccountDTO> loginaccount)
        //{
        //    return (new UserReader()).SaveLoginaccountOnly(loginaccount);
        //}

        //public LoginaccountDTO SaveSingleLoginaccount(LoginaccountDTO loginaccount)
        //{
        //    List<LoginaccountDTO> list = new List<LoginaccountDTO>();
        //    list.Add(loginaccount);

        //    list = (new UserReader()).SaveLoginaccount(list);

        //    return list.FirstOrDefault();
        //}

        //public LoginaccountDTO JsonSaveSingleLoginaccount(LoginaccountDTO loginaccount)
        //{
        //    List<LoginaccountDTO> list = new List<LoginaccountDTO>();
        //    list.Add(loginaccount);

        //    list = (new UserReader()).SaveLoginaccount(list);

        //    return list.FirstOrDefault();
        //}
        
        //public List<LoginaccountmoduleusergroupDTO> SaveLoginaccountmoduleusergroup(List<LoginaccountmoduleusergroupDTO> list)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLoginaccountmoduleusergroup(list);
        //}

        //public List<LoginaccountmoduleusergroupDTO> JsonSaveLoginaccountmoduleusergroup(List<LoginaccountmoduleusergroupDTO> list)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLoginaccountmoduleusergroup(list);
        //}
        
        //public List<ComboBoxDTO> GetActiveDirUsers(string strUser)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetActiveDirUsers(Helper.ActiveDirectoryServer, strUser);
        //}

        //public List<ComboBoxDTO> JsonGetActiveDirUsers(string strUser)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetActiveDirUsers(Helper.ActiveDirectoryServer, strUser);
        //}

        //public LoginaccountDTO GetLoginaccountByTempOwnerPesonnelID(int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetLoginaccountByTempOwnerPesonnelID(personnelId);
        //}
    }
}
