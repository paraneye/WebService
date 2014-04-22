using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Element.Shared.Common;
using Element.Sigma.Web.Biz;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.MTO;


namespace Element.Sigma.Web.Service.GlobalSettings
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISigmaGlobalSettings" in both code and config file together.
    [ServiceContract]
    public interface ISigmaGlobalSettings
    {

        #region SigmaUser


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUsers/{sigmaUserId}")]
        SigmaResultType GetSigmaUser(string sigmaUserId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUsers")]
        SigmaResultType ListSigmaUser();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUsers")]
        SigmaResultType AddSigmaUser(TypeSigmaUser paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUsers")]
        SigmaResultType MultiUsers(TypeSigmaUser paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUsers")]
        SigmaResultType RemoveSigmaUser(TypeSigmaUser paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUsers/Multi")]
        SigmaResultType MultiSigmaUser(List<TypeSigmaUser> listObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UserProfile")]
        SigmaResultType UpdateUserProfile(TypeSigmaUser paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Password")]
        SigmaResultType UpdatePassword(TypeSigmaUser paramObj);

        #endregion
        
        #region SigmaUserSigmaRole


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUserSigmaRoles/{sigmaUserId}")]
        SigmaResultType GetSigmaUserSigmaRole(string sigmaUserId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUserSigmaRoles")]
        SigmaResultType ListSigmaUserSigmaRole();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUserSigmaRoles")]
        SigmaResultType AddSigmaUserSigmaRole(TypeSigmaUserSigmaRole paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUserSigmaRoles")]
        SigmaResultType UpdateSigmaUserSigmaRole(TypeSigmaUserSigmaRole paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaUserSigmaRole")]
        SigmaResultType RemoveSigmaUserSigmaRole(TypeSigmaUserSigmaRole paramObj);



        #endregion

        #region SigmaRole

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaRoles/{sigmaRoleId}")]
        SigmaResultType GetSigmaRole(string sigmaRoleId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaRoles")]
        SigmaResultType ListSigmaRole();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaRoles")]
        SigmaResultType AddSigmaRole(TypeSigmaRole paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaRoles")]
        SigmaResultType UpdateSigmaRole(TypeSigmaRole paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaRoles")]
        SigmaResultType RemoveSigmaRole(TypeSigmaRole paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaRoles/Multi")]
        SigmaResultType MultiSigmaRole(List<TypeSigmaRole> listObj);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaRolesByProjectId/{projectId}")]
        SigmaResultType ListSigmaRolesByProjectId(string projectId);

        #endregion

        #region SigmaJob

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaJobs/{sigmaJobId}")]
        SigmaResultType GetSigmaJob(string sigmaJobId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaJobs")]
        SigmaResultType ListSigmaJob();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaJobs")]
        SigmaResultType AddSigmaJob(TypeSigmaJob paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaJobs")]
        SigmaResultType UpdateSigmaJob(TypeSigmaJob paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaJobs")]
        SigmaResultType RemoveSigmaJob(TypeSigmaJob paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaJobs/Multi")]
        SigmaResultType MultiSigmaJob(List<TypeSigmaJob> listObj);

        #endregion

        #region Roles & Permission

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Permissions/{sigmaRoleId}")]
        SigmaResultType ListSigmaRoleSigmaJob(string sigmaRoleId);

         [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Permissions")]
        SigmaResultType ListSigmaRoleSigmaJobForInit();

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "RolesNPermissions/Multi")]
        SigmaResultType MultiRolesNPermissions(TypeSigmaRole listObj);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "PermissionReport")]
        SigmaResultType ListPermissionReport();

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "PermissionReport/Multi")]
        SigmaResultType MultiPermissionReport(List<TypeSigmaRoleSigmaJob> listObj);

        #endregion

        #region FileStore

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "FileStores/{fileStoreId}")]
        SigmaResultType GetFileStore(string fileStoreId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "FileStores")]
        SigmaResultType ListFileStore();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "FileStores")]
        SigmaResultType AddFileStore(TypeFileStore paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "FileStores")]
        SigmaResultType UpdateFileStore(TypeFileStore paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "FileStores")]
        SigmaResultType RemoveFileStore(TypeFileStore paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "FileStores/Multi")]
        SigmaResultType MultiFileStore(List<TypeFileStore> listObj);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "FileType/{codeCategory}")]
        SigmaResultType GetFileType(string codeCategory);

        #endregion

        #region UploadedFileInfo

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UploadedFileInfos/{uploadedFileInfoId}")]
        SigmaResultType GetUploadedFileInfo(string uploadedFileInfoId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UploadedFileInfos")]
        SigmaResultType ListUploadedFileInfo();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UploadedFileInfos")]
        SigmaResultType AddUploadedFileInfo(TypeUploadedFileInfo paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UploadedFileInfos")]
        SigmaResultType UpdateUploadedFileInfo(TypeUploadedFileInfo paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UploadedFileInfos")]
        SigmaResultType RemoveUploadedFileInfo(TypeUploadedFileInfo paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UploadedFileInfos/Multi")]
        SigmaResultType MultiUploadedFileInfo(List<TypeUploadedFileInfo> listObj);

        #endregion

        #region SigmaCode

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodes/{code}/{codeCategory}")]
        SigmaResultType GetSigmaCode(string code, string codeCategory);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodes")]
        SigmaResultType ListSigmaCode();


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodes")]
        SigmaResultType AddSigmaCode(TypeSigmaCode paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodes")]
        SigmaResultType UpdateSigmaCode(TypeSigmaCode paramObj);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodes")]
        SigmaResultType RemoveSigmaCode(TypeSigmaCode paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodes/Multi")]
        SigmaResultType MultiSigmaCode(List<TypeSigmaCode> listObj);
        #endregion

        #region SigmaCodeCategory
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodeCategorys/{codeCategory}")]
        SigmaResultType GetSigmaCodeCategory(string codeCategory);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodeCategorys")]
        SigmaResultType ListSigmaCodeCategory();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodeCategorys")]
        SigmaResultType AddSigmaCodeCategory(TypeSigmaCodeCategory paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodeCategorys")]
        SigmaResultType UpdateSigmaCodeCategory(TypeSigmaCodeCategory paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodeCategorys")]
        SigmaResultType RemoveSigmaCodeCategory(TypeSigmaCodeCategory paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SigmaCodeCategorys/Multi")]
        SigmaResultType MultiSigmaCodeCategory(List<TypeSigmaCodeCategory> listObj);
        #endregion

        #region CostCode
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CostCodes/{costCodeId}")]
        SigmaResultType GetCostCode(string costCodeId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CostCodes")]
        SigmaResultType ListCostCode();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CostCodes")]
        SigmaResultType AddCostCode(TypeCostCode paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CostCodes")]
        SigmaResultType UpdateCostCode(TypeCostCode paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CostCodes")]
        SigmaResultType RemoveCostCode(TypeCostCode paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CostCodes/Multi")]
        SigmaResultType MultiCostCode(List<TypeCostCode> listObj);

        #endregion 

        #region Company
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Companys/{companyId}")]
        SigmaResultType GetCompany(string companyId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Companys")]
        SigmaResultType ListCompany();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Companys")]
        SigmaResultType AddCompany(TypeCompany paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Companys")]
        SigmaResultType UpdateCompany(TypeCompany paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Companys")]
        SigmaResultType RemoveCompany(TypeCompany paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Companys/Multi")]
        SigmaResultType MultiCompany(List<TypeCompany> listObj);

        #endregion 

        #region Component
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Components/{componentId}")]
        SigmaResultType GetComponent(string componentId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Components")]
        SigmaResultType ListComponent();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Components")]
        SigmaResultType AddComponent(TypeComponent paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Components")]
        SigmaResultType UpdateComponent(TypeComponent paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Components")]
        SigmaResultType RemoveComponent(TypeComponent paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Components/Multi")]
        SigmaResultType MultiComponent(List<TypeComponent> listObj);
        #endregion

        #region ComponentCustomField
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentCustomFields/{componentId}")]
        SigmaResultType GetComponentCustomField(string componentId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentCustomFields")]
        SigmaResultType ListComponentCustomField();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentCustomFields")]
        SigmaResultType AddComponentCustomField(TypeComponentCustomField paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentCustomFields")]
        SigmaResultType UpdateComponentCustomField(TypeComponentCustomField paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentCustomFields")]
        SigmaResultType RemoveComponentCustomField(TypeComponentCustomField paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentCustomFields/Multi")]
        SigmaResultType MultiComponentCustomField(List<TypeComponentCustomField> listObj);

        #endregion 

        #region ComponentProgresss
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentProgresss/{componentProgressId}")]
        SigmaResultType GetComponentProgress(string componentProgressId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentProgresss")]
        SigmaResultType ListComponentProgress();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentProgressStep")]
        SigmaResultType ListComponentProgressStep();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentProgresss")]
        SigmaResultType AddComponentProgress(TypeComponentProgress paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentProgresss")]
        SigmaResultType UpdateComponentProgress(TypeComponentProgress paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentProgresss")]
        SigmaResultType RemoveComponentProgress(TypeComponentProgress paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentProgresss/Multi")]
        SigmaResultType MultiComponentProgress(List<TypeComponentProgress> listObj);
        #endregion 

        #region Material

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "MaterialFile/{filePath}/{exportFilePath}")]
        SigmaResultType GetMaterialFile(string filePath, string exportFilePath);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Materials/{materialId}")]
        SigmaResultType GetMaterial(string materialId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Materials")]
        SigmaResultType ListMaterial();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Materials")]
        SigmaResultType AddMaterial(TypeMaterial paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Materials")]
        SigmaResultType UpdateMaterial(TypeMaterial paramObj);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Materials")]
        SigmaResultType RemoveMaterial(TypeMaterial paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Materials/Multi")]
        SigmaResultType MultiMaterial(List<TypeMaterial> listObj);

        #endregion

        #region MaterialCustomField

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "MaterialCustomFieldsWithCustomField/{materialId}")]
        SigmaResultType GetMaterialCustomFieldWithCustomField(string materialId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", 
        //    RequestFormat = WebMessageFormat.Json, 
        //    ResponseFormat = WebMessageFormat.Json, 
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest, 
        //    UriTemplate = "MaterialCustomFields/{}")]
        //SigmaResultType GetMaterialCustomField(string );

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "MaterialCustomFields")]
        //SigmaResultType ListMaterialCustomField();

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "MaterialCustomFields")]
        //SigmaResultType AddMaterialCustomField(TypeMaterialCustomField paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "MaterialCustomFields")]
        //SigmaResultType UpdateMaterialCustomField(TypeMaterialCustomField paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "MaterialCustomFields")]
        //SigmaResultType RemoveMaterialCustomField(TypeMaterialCustomField paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "MaterialCustomFields/Multi")]
        //SigmaResultType MultiMaterialCustomField(List<TypeMaterialCustomField> listObj);

        #endregion MaterialCustomFields

        #region Consumable

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Consumables/{consumableId}")]
        SigmaResultType GetConsumable(string consumableId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Consumables")]
        SigmaResultType ListConsumable();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Consumables")]
        SigmaResultType AddConsumable(TypeConsumable paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Consumables")]
        SigmaResultType UpdateConsumable(TypeConsumable paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Consumables")]
        SigmaResultType RemoveConsumable(TypeConsumable paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Consumables/Multi")]
        SigmaResultType MultiConsumable(List<TypeConsumable> listObj);

        #endregion Consumable

        #region Equipment

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Equipments/{equipmentId}")]
        SigmaResultType GetEquipment(string equipmentId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Equipments")]
        SigmaResultType ListEquipment();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Equipments")]
        SigmaResultType AddEquipment(TypeEquipment paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Equipments")]
        SigmaResultType UpdateEquipment(TypeEquipment paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "Equipments")]
        //SigmaResultType RemoveEquipment(TypeEquipment paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Equipments/Multi")]
        SigmaResultType MultiEquipment(List<TypeEquipment> listObj);

        #endregion Equipment

        #region EquipmentCustomField

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EquipmentCustomFieldsWithCustomField/{materialId}")]
        SigmaResultType GetEquipmentCustomFieldWithCustomField(string materialId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", 
        //    RequestFormat = WebMessageFormat.Json, 
        //    ResponseFormat = WebMessageFormat.Json, 
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest, 
        //    UriTemplate = "EquipmentCustomFields/{}")]
        //SigmaResultType GetEquipmentCustomField(string id);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "EquipmentCustomFields")]
        //SigmaResultType ListEquipmentCustomField();

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "EquipmentCustomFields")]
        //SigmaResultType AddEquipmentCustomField(TypeEquipmentCustomField paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "EquipmentCustomFields")]
        //SigmaResultType UpdateEquipmentCustomField(TypeEquipmentCustomField paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "EquipmentCustomFields")]
        //SigmaResultType RemoveEquipmentCustomField(TypeEquipmentCustomField paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "EquipmentCustomFields/Multi")]
        //SigmaResultType MultiEquipmentCustomField(List<TypeEquipmentCustomField> listObj);

        #endregion EquipmentCustomField

        #region Common Code

        #region Progress Type

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypes/{progressTypeId}")]
        SigmaResultType GetProgressType(string progressTypeId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypes")]
        SigmaResultType ListProgressType();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypes")]
        SigmaResultType AddProgressType(TypeProgressType paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypes")]
        SigmaResultType UpdateProgressType(TypeProgressType paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypes")]
        //SigmaResultType RemoveProgressType(TypeProgressType paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypes/Multi")]
        //SigmaResultType MultiProgressType(List<TypeProgressType> listObj);
        
        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypes")]
        //SigmaResultType UpdateProgressType(TypeProgressType paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypes")]
        //SigmaResultType RemoveProgressType(TypeProgressType paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypes/Multi")]
        SigmaResultType MultiProgressType(List<TypeProgressType> listObj);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypeByTaskCateogry/{taskCategoryId}/{taskTypeId}")]
        SigmaResultType ListProgressTypeByTaskCateogry(string taskCategoryId, string taskTypeId);

        #endregion Progress Type

        #region Progress Step

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressSteps/{progressStepId}")]
        //SigmaResultType GetProgressStep(string progressStepId);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressSteps")]
        //SigmaResultType ListProgressStep();

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressSteps")]
        //SigmaResultType AddProgressStep(TypeProgressStep paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressSteps")]
        //SigmaResultType UpdateProgressStep(TypeProgressStep paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressSteps")]
        //SigmaResultType RemoveProgressStep(TypeProgressStep paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressSteps/Multi")]
        //SigmaResultType MultiProgressStep(List<TypeProgressStep> listObj);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressStepByProgessTypeId/{progressTypeId}")]
        SigmaResultType GetProgressStepByProgessTypeId(string progressTypeId);

        #endregion Progress Step

        #region ProgressTypeMap

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypeMaps/{progressTypeMapId}")]
        //SigmaResultType GetProgressTypeMap(string progressTypeMapId);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypeMaps")]
        //SigmaResultType ListProgressTypeMap();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypeMaps")]
        SigmaResultType AddProgressTypeMap(TypeProgressTypeMap paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypeMaps")]
        SigmaResultType UpdateProgressTypeMap(TypeProgressTypeMap paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypeMaps")]
        //SigmaResultType RemoveProgressTypeMap(TypeProgressTypeMap paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "ProgressTypeMaps/Multi")]
        //SigmaResultType MultiProgressTypeMap(List<TypeProgressTypeMap> listObj);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ProgressTypeMapByDisciplineCode/{taskCategoryId}/{disciplineCode}")]
        SigmaResultType GetProgressTypeMapByDisciplineCode(string taskCategoryId, string disciplineCode);

        #endregion ProgressTypeMap

        #region Drawing Type Management

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "SigmaCodes/{codeCategory}")]
        //SigmaResultType GetSigmaCode(string codeCategory);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "SigmaCodes")]
        //SigmaResultType ListSigmaCode();

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "SigmaCodes")]
        //SigmaResultType AddSigmaCode(TypeSigmaCode paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "SigmaCodes")]
        //SigmaResultType UpdateSigmaCode(TypeSigmaCode paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "SigmaCodes")]
        //SigmaResultType RemoveSigmaCode(TypeSigmaCode paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "SigmaCodes/Multi")]
        //SigmaResultType MultiSigmaCode(List<TypeSigmaCode> listObj);

        #endregion Drawing Type Management

        #region Task Category and Type

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "TaskCategorys/{taskCategoryId}")]
        //SigmaResultType GetTaskCategory(string taskCategoryId);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "TaskCategorys")]
        //SigmaResultType ListTaskCategory();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TaskCategorys")]
        SigmaResultType AddTaskCategory(TypeTaskCategory paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TaskCategorys")]
        SigmaResultType UpdateTaskCategory(TypeTaskCategory paramObj);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TaskCategorys")]
        SigmaResultType RemoveTaskCategory(TypeTaskCategory paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "TaskCategorys/Multi")]
        //SigmaResultType MultiTaskCategory(List<TypeTaskCategory> listObj);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TaskCategoryWithTaskType")]
        SigmaResultType ListTaskCategoryWithTaskType();

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "TaskTypes/{taskTypeId}")]
        //SigmaResultType GetTaskType(string taskTypeId);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "TaskTypes")]
        //SigmaResultType ListTaskType();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TaskTypes")]
        SigmaResultType AddTaskType(TypeTaskType paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TaskTypes")]
        SigmaResultType UpdateTaskType(TypeTaskType paramObj);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TaskTypes")]
        SigmaResultType RemoveTaskType(TypeTaskType paramObj);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "TaskTypes/Multi")]
        //SigmaResultType MultiTaskType(List<TypeTaskType> listObj);

        
        #endregion Task Category and Type
              

        #endregion Common Code
    }
}
