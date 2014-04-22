using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Element.Reveal.DataLibrary;

namespace Element.Sigma.Web.Service.Prev
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LoginaccountDTO GetLoginAccountById(int loginAccountId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginAccountById/{loginAccountId}")]
        //LoginaccountDTO JsonGetLoginAccountById(string loginAccountId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LoginaccountAndModuleUserGroup GetLoginaccountBySharePointUser(string sharePointUser);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginaccountBySharePointUser/{sharePointUser}")]
        //LoginaccountAndModuleUserGroup JsonGetLoginaccountBySharePointUser(string sharePointUser);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]        
        //LoginaccountDTO GetLoginaccountByLoginName(string loginName);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginaccountByLoginName/{loginName}")]
        LoginaccountDTO JsonGetLoginaccountByLoginName(string loginName);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LoginaccountDTO GetLoginaccountByPesonnelID(int personnelId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginaccountByPesonnelID/{sigmaUserlId}")]
        LoginaccountDTO JsonGetLoginaccountByPesonnelID(string sigmaUserlId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]        
        //LoginaccountAndModuleUserGroup GetUserLogin(string loginName, byte[] bPassword, bool isdomainUser);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MobileLoginDTO MobileGetUserLogin(string loginName, byte[] bPassword, bool isdomainUser, DateTime workDate, bool brasscheck);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonMobileGetUserLogin/{loginName}/{bPassword}/{isdomainUser}/{workDate}/{brasscheck}")]
        MobileLoginDTO JsonMobileGetUserLogin(string loginName, string bPassword, string isdomainUser, string workDate, string brasscheck);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonMobileUserLogin")]
        MobileLoginDTO JsonMobileUserLogin(string loginName, string bPassword, string isdomainUser, string workDate, string brasscheck);

        //[AuthorizationBehavior]
        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserLogin/{loginName}")]
        //MobileLoginDTO JsonGetUserLogin(string loginName);

        ////[OperationContract]
        ////[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonPutUserLogin")]
        ////MobileLoginDTO JsonUserLogin(string loginName, string base64PassWord);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUserLogin/{loginName}/{base64PassWord}")]
        //MobileLoginDTO JsonUserLogin(string loginName, string base64PassWord);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoginaccountDTO> GetUserAccounts();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserAccounts")]
        //List<LoginaccountDTO> JsonGetUserAccounts();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoginaccountDTO> GetLoginaccountByIsDomainUser(int isDomainUser);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginaccountByIsDomainUser/{isDomainUser}")]
        //List<LoginaccountDTO> JsonGetLoginaccountByIsDomainUser(string isDomainUser);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoginaccountDTO> GetLoginaccountByProject(int projectID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginaccountByProject/{projectID}")]
        //List<LoginaccountDTO> JsonGetLoginaccountByProject(string projectID);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoginaccountmoduleusergroupDTO> GetLoginModuleUsergroupByLoginID(int loginAccountId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginModuleUsergroupByLoginID/{loginAccountId}")]
        //List<LoginaccountmoduleusergroupDTO> JsonGetLoginModuleUsergroupByLoginID(string loginAccountId);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string[] GetSPLogin();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSPLogin")]
        //string[] JsonGetSPLogin();
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void ResetPassword(int loginAccountId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonResetPassword/{loginAccountId}")]
        //void JsonResetPassword(string loginAccountId);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoginaccountDTO> SaveLoginaccount(List<LoginaccountDTO> loginaccount);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveLoginaccount/{loginaccount}")]
        ////List<LoginaccountDTO> JsonSaveLoginaccount(List<LoginaccountDTO> loginaccount);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoginaccountDTO> SaveLoginaccountOnly(List<LoginaccountDTO> loginaccount);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LoginaccountDTO SaveSingleLoginaccount(LoginaccountDTO loginaccount);

        ////[OperationContract]
        ////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSingleLoginaccount/{loginaccount}")]
        ////LoginaccountDTO JsonSaveSingleLoginaccount(LoginaccountDTO loginaccount);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoginaccountmoduleusergroupDTO> SaveLoginaccountmoduleusergroup(List<LoginaccountmoduleusergroupDTO> list);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveLoginaccountmoduleusergroup/{list}")]
        ////List<LoginaccountmoduleusergroupDTO> JsonSaveLoginaccountmoduleusergroup(List<LoginaccountmoduleusergroupDTO> list);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetActiveDirUsers(string strUser);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetActiveDirUsers/{strUser}")]
        //List<ComboBoxDTO> JsonGetActiveDirUsers(string strUser);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LoginaccountDTO GetLoginaccountByTempOwnerPesonnelID(int personnelId);
    }
}
