using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Element.Reveal.DataLibrary;
using System.IO;

namespace Element.Sigma.Web.Service.Prev
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommonService" in both code and config file together.
    [ServiceContract]
    public interface ICommonService
    {
        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllEqupment")]
        //List<EquipmentDTO> GetAllEqupment();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAllEqupment")]
        //List<EquipmentDTO> JsonGetAllEqupment();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //EquipmentDTO GetEqupmentById(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetEqupmentById/{Id}")]
        //EquipmentDTO JsonGetEqupmentById(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<EquipmentDTO> GetEquipmentByType(int type, string EquipName, int projectId);

        //[OperationContract, WebInvoke(Method = "Get",  RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "JsonGetEquipmentByType/{type}/{EquipName}/{projectId}")]
        //List<EquipmentDTO> JsonGetEquipmentByType(string type, string EquipName, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FieldequipmentDTO> GetAllFieldEqupment();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLoginaccountByLoginName")]
        //List<FieldequipmentDTO> JsonGetAllFieldEqupment();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FieldequipmentDTO GetFieldEqupmentById(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFieldEqupmentById/{Id}")]
        //FieldequipmentDTO JsonGetFieldEqupmentById(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FieldequipmentDTO> GetFieldequipmentByType(string search);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFieldequipmentByType/{search}")]
        List<FieldequipmentDTO> JsonGetFieldequipmentByType(string search);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //CompanyDTO GetCompanyById(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCompanyById/{Id}")]
        //CompanyDTO JsonGetCompanyById(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CompanyDTO> GetCompanyByTypeLUID(int CompanyTypeLUID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCompanyByTypeLUID/{CompanyTypeLUID}")]
        //List<CompanyDTO> JsonGetCompanyByTypeLUID(string CompanyTypeLUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CompanyDTO> GetCompanyByCompanyType(string CompanyType);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCompanyByCompanyType/{CompanyType}")]
        //List<CompanyDTO> JsonGetCompanyByCompanyType(string CompanyType);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CompanyDTO> GetCompanyByName(string name);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCompanyByName/{name}")]
        //List<CompanyDTO> JsonGetCompanyByName(string name);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CompanyDTO> GetCompanyByCompanyId(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCompanyByCompanyId/{Id}")]
        //List<CompanyDTO> JsonGetCompanyByCompanyId(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CompanyDTO> GetCompanyAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCompanyAll")]
        //List<CompanyDTO> JsonGetCompanyAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectcontractorDTO> GetProjectContractor(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectContractor/{Id}")]
        //List<ProjectcontractorDTO> JsonGetProjectContractor(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<EmpclassDTO> GetEmpclassById(int Id);

        ////[OperationContract]
        ////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetEmpclassById/{Id}")]
        ////List<EmpclassDTO> JsonGetEmpclassById(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<EmpclassDTO> GetEmpclassAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetEmpclassAll")]
        //List<EmpclassDTO> JsonGetEmpclassAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LookupDTO> GetUserGroup();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserGroup")]
        //List<LookupDTO> JsonGetUserGroup();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LookupDTO> GetLookupByLookupType(string lookuptype);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLookupByLookupType/{lookuptype}")]
        List<LookupDTO> JsonGetLookupByLookupType(string lookuptype);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LookupDTO> GetLookupByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLookupByID/{Id}")]
        //List<LookupDTO> JsonGetLookupByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LookupDTO GetSingleLookupByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSingleLookupByID/{Id}")]
        //LookupDTO JsonGetSingleLookupByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LookupDTO> GetAllLookup();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAllLookup")]
        //List<LookupDTO> JsonGetAllLookup();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<UserlookupDTO> GetUserlookupByLookupType(string lookuptype);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserlookupByLookupType/{lookuptype}")]
        //List<UserlookupDTO> JsonGetUserlookupByLookupType(string lookuptype);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<UserlookupDTO> GetUserlookupByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserlookupByID/{Id}")]
        //List<UserlookupDTO> JsonGetUserlookupByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //UserlookupDTO GetSingleUserlookupByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSingleUserlookupByID/{Id}")]
        //UserlookupDTO JsonGetSingleUserlookupByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //UserlookupCityDTO GetSingleUserlookupByID_City(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSingleUserlookupByID_City/{Id}")]
        //UserlookupCityDTO JsonGetSingleUserlookupByID_City(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<UserlookupDTO> GetAllUserlookup();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAllUserlookup")]
        //List<UserlookupDTO> JsonGetAllUserlookup();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<UserlookupCityDTO> GetUserlookupByType_City(string lookuptype, int CountryID, int ProvinceID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserlookupByType_City/{lookuptype}/{CountryID}/{ProvinceID}")]
        //List<UserlookupCityDTO> JsonGetUserlookupByType_City(string lookuptype, string CountryID, string ProvinceID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetUserlookupByLookupType_Combo(string lookuptype, string lookupsubtype);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserlookupByLookupType_Combo/{lookuptype}/{lookupsubtype}")]
        //List<ComboBoxDTO> JsonGetUserlookupByLookupType_Combo(string lookuptype, string lookupsubtype);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LookupDTO> GetLookupForLibInsulPipeFactor();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TaskcategoryDTO> GetTaskCategoryByModuleID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTaskCategoryByModuleID/{id}")]
        //List<TaskcategoryDTO> JsonGetTaskCategoryByModuleID(string id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TaskcategoryDTO> GetTaskCategoryByLibInsulPipeFactor();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTaskCategoryByLibInsulPipeFactor")]
        //List<TaskcategoryDTO> JsonGetTaskCategoryByLibInsulPipeFactor();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TaskcategoryDTO> GetTaskcategoryByMaterialCategory(int moduleId, int materialCategoryId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTaskcategoryByMaterialCategory/{disciplineCode}/{taskcategoryId}")]
        List<TaskcategoryDTO> JsonGetTaskcategoryByMaterialCategory(string disciplineCode, string taskcategoryId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialcategoryDTO> GetMaterialCategoryByModuleID(int moduleid);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialCategoryByModuleID/{disciplineCode}")]
        List<MaterialcategoryDTO> JsonGetMaterialCategoryByDisciplineCode(string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialcategoryDTO> GetMaterialCategoryByLibInsulPipeFactor();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialCategoryByLibInsulPipeFactor")]
        //List<MaterialcategoryDTO> JsonGetMaterialCategoryByLibInsulPipeFactor();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ModuleDTO> GetModuleAll();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetModuleAll")]
        List<ModuleDTO> JsonGetModuleAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ModuleDTO GetModuleByID(int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetModuleByID/{disciplineCode}")]
        ModuleDTO JsonGetModuleByID(string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RuleofcreditweightDTO> GetRuelOfCreditWeightByProjectAndMaterialCategory(int projectId, int moduleId, int materialcategoryId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRuelOfCreditWeightByProjectAndMaterialCategory/{projectId}/{moduleId}/{materialcategoryId}")]
        //List<RuleofcreditweightDTO> JsonGetRuelOfCreditWeightByProjectAndMaterialCategory(string projectId, string disciplineCode, string materialcategoryId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RuleofcreditweightDTO> GetRuleOfCreditWeightByProject(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRuleOfCreditWeightByProject/{projectId}/{moduleId}")]
        //List<RuleofcreditweightDTO> JsonGetRuleOfCreditWeightByProject(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LookupDTO> GetRuleOfCreditAvailable(int projectId, int moduleId, int materialcategoryId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRuleOfCreditAvailable/{projectId}/{moduleId}/{materialcategoryId}")]
        //List<LookupDTO> JsonGetRuleOfCreditAvailable(string projectId, string disciplineCode, string materialcategoryId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartmentDTO> GetDepartmentAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartmentAll")]
        //List<DepartmentDTO> JsonGetDepartmentAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DepartmentDTO GetDepartmentByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartmentByID/{id}")]
        //DepartmentDTO JsonGetDepartmentByID(string id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DepartmentDTO GetDepartmentByDepartmentText(string department);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartmentByDepartmentText/{department}")]
        //DepartmentDTO JsonGetDepartmentByDepartmentText(string department);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartmentDTO> GetDepartmentByDepartType(int departTypeLUId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartmentByDepartType/{departTypeLUId}")]
        //List<DepartmentDTO> JsonGetDepartmentByDepartType(string departTypeLUId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartmentDTO> GetDepartmentApprovalGroup(int departTypeLUId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartmentApprovalGroup/{departTypeLUId}")]
        //List<DepartmentDTO> JsonGetDepartmentApprovalGroup(string departTypeLUId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DepartstructureDTO GetDepartstructureByPersonnelDepartStructure(int personnelId, int departstructId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartstructureByPersonnelDepartStructure/{personnelId}/{departstructId}/{projectId}/{moduleId}")]
        //DepartstructureDTO JsonGetDepartstructureByPersonnelDepartStructure(string personnelId, string departstructId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetDepartstructureByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartstructureByID/{Id}")]
        //List<DepartstructureDTO> JsonGetDepartstructureByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetDepartStructureByPersonnelID(int personnelId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetDepartstructureByProject(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartstructureByProject/{projectId}/{moduleId}")]
        //List<DepartstructureDTO> JsonGetDepartstructureByProject(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetDepartstructureByProjectModuleForMenonsite(int projectId, int moduleId, int departTypeLUID, string name);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartstructureByProjectModuleForMenonsite/{projectId}/{moduleId}/{departTypeLUID}/{name}")]
        //List<DepartstructureDTO> JsonGetDepartstructureByProjectModuleForMenonsite(string projectId, string disciplineCode, string departTypeLUID, string name);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetChildDepartStructureByDepartStructure(int departStructureID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetChildDepartStructureByDepartStructure/{departStructureID}")]
        //List<DepartstructureDTO> JsonGetChildDepartStructureByDepartStructure(string departStructureID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetWorkFlowDepartStructureByDepartment(int departmentId, int departStructureId, int fiwpid, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetWorkFlowDepartStructureByDepartment/{departmentId}/{departStructureId}/{fiwpid}/{projectId}/{moduleId}")]
        //List<DepartstructureDTO> JsonGetWorkFlowDepartStructureByDepartment(string departmentId, string departStructureId, string fiwpid, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<PersonnelDTO> GetAllPersonnelByProjectID(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAllPersonnelByProjectID/{projectId}/{moduleId}")]
        //List<PersonnelDTO> JsonGetAllPersonnelByProjectID(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<PersonnelDTO> GetAllPersonnelUnassignedByProjectID(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAllPersonnelUnassignedByProjectID/{projectId}")]
        //List<PersonnelDTO> JsonGetAllPersonnelUnassignedByProjectID(string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<PersonnelDTO> GetPersonnelByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetPersonnelByID/{Id}")]
        //List<PersonnelDTO> JsonGetPersonnelByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //PersonnelDTO GetSinglePersonnelByDepartStructure(int departStructureID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSinglePersonnelByDepartStructure/{departStructureID}")]
        //PersonnelDTO JsonGetSinglePersonnelByDepartStructure(string departStructureID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //PersonnelDTO GetSinglePersonnelByID(int personnelId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSinglePersonnelByID/{personnelId}")]
        PersonnelDTO JsonGetSinglePersonnelByID(string personnelId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSigmaUserPhotoBySigmaUserId/{sigmaUserId}")]
        ComboCodeBoxDTO JsonGetSigmaUserPhotoBySigmaUserId(string sigmaUserId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUserInfo/{userId}")]
        UserInfoDTO JsonGetUserInfo(string userId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //PageAndPageusergroup GetPageSettings(string pageGUID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetEmpclassById/{pageGUID}")]
        //PageAndPageusergroup JsonGetPageSettings(string pageGUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SdDTO GetSdByID(int sdId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSdByID/{sdId}")]
        //SdDTO JsonGetSdByID(string sdId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SdDTO> GetSdByModule(int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSdByModule/{moduleId}")]
        //List<SdDTO> JsonGetSdByModule(string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SdDTO> GetSdByMaterialCategory(int materialcategoryId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSdByMaterialCategory/{materialcategoryId}")]
        //List<SdDTO> JsonGetSdByMaterialCategory(string materialcategoryId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SdPageTotal GetSdForPaging(int selectedPage, int pageSize, int projectId, int moduleId, int sdTypeLUId, int materialCategoryId, int drawingId, string sdName, string company);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSdForPaging/{selectedPage}/{pageSize}/{projectId}/{moduleId}/{sdTypeLUId}/{materialCategoryId}/{drawingId}/{sdName}/{company}")]
        //SdPageTotal JsonGetSdForPaging(string selectedPage, string pageSize, string projectId, string disciplineCode, string sdTypeLUId, string materialCategoryId, string drawingId, string sdName, string company);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SdPageTotal GetSdForPagingMto(int selectedPage, int pageSize, int ModuleId, int SDType, int MaterialCategory, string SDName, string Company);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSdForPagingMto/{selectedPage}/{pageSize}/{ModuleId}/{SDType}/{MaterialCategory}/{SDName}/{Company}")]
        //SdPageTotal JsonGetSdForPagingMto(string selectedPage, string pageSize, string disciplineCode, string SDType, string MaterialCategory, string SDName, string Company);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SdmateriallistDTO> GetSdmateriallistBySD(int sdId, int uomLUId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSdmateriallistBySD/{sdId}/{uomLUId}")]
        //List<SdmateriallistDTO> JsonGetSdmateriallistBySD(string sdId, string uomLUId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SdmateriallistDTO GetSdmateriallistByMaterialListID(int MaterialListID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSdmateriallistByMaterialListID/{MaterialListID}")]
        //SdmateriallistDTO JsonGetSdmateriallistByMaterialListID(string MaterialListID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<UsergroupDTO> GetUsergroupAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUsergroupAll")]
        //List<UsergroupDTO> JsonGetUsergroupAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetDepartstructureByDepartment(int departmentId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartstructureByDepartment/{departmentId}/{projectId}/{moduleId}")]
        //List<DepartstructureDTO> JsonGetDepartstructureByDepartment(string departmentId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetDepartstructureByDepartmentText(string department, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartstructureByDepartmentText/{department}/{projectId}/{moduleId}")]
        //List<DepartstructureDTO> JsonGetDepartstructureByDepartmentText(string department, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> GetDepartstructureByLoginAccount(int loginAccountId, int departTypeLUId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDepartstructureByLoginAccount/{loginAccountId}/{departTypeLUId}")]
        //List<DepartstructureDTO> JsonGetDepartstructureByLoginAccount(string loginAccountId, string departTypeLUId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]   
        //List<ImportedfilenameDTO> GetImportedfilenameAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetImportedfilenameAll")]
        //List<ImportedfilenameDTO> JsonGetImportedfilenameAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ImportedfilenameDTO> GetImportedfilenameByfilename(string filename, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetImportedfilenameByfilename/{filename}/{projectId}/{moduleId}")]
        //List<ImportedfilenameDTO> JsonGetImportedfilenameByfilename(string filename, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ImportedfilenameDTO> GetImportedfilenameByfiletype(string filetype, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetImportedfilenameByfiletype/{filetype}/{projectId}/{moduleId}")]
        //List<ImportedfilenameDTO> JsonGetImportedfilenameByfiletype(string filetype, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<EquipmentDTO> SaveEquipment(List<EquipmentDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveEquipment/{dto}")]
        ////List<EquipmentDTO> JsonSaveEquipment(List<EquipmentDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FieldequipmentDTO> SaveFieldEquipment(List<FieldequipmentDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFieldEquipment/{dto}")]
        ////List<FieldequipmentDTO> JsonSaveFieldEquipment(List<FieldequipmentDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectcontractorDTO> SaveProjectContractor(List<ProjectcontractorDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveProjectContractor/{dto}")]
        ////List<ProjectcontractorDTO> JsonSaveProjectContractor(List<ProjectcontractorDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CompanyDTO> SaveCompany(List<CompanyDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveCompany/{dto}")]
        ////List<CompanyDTO> JsonSaveCompany(List<CompanyDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<EmpclassDTO> SaveEmpclass(List<EmpclassDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveEmpclass/{dto}")]
        ////List<EmpclassDTO> JsonSaveEmpclass(List<EmpclassDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LookupDTO> SaveLookup(List<LookupDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveLookup/{dto}")]
        ////List<LookupDTO> JsonSaveLookup(List<LookupDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<UserlookupDTO> SaveUserlookup(List<UserlookupDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<UserlookupCityDTO> SaveUserlookupCity(List<UserlookupCityDTO> dto);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RuleofcreditweightDTO> SaveRuleOfCreditWeight(List<RuleofcreditweightDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveRuleOfCreditWeight/{dto}")]
        ////List<RuleofcreditweightDTO> JsonSaveRuleOfCreditWeight(List<RuleofcreditweightDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<PersonnelDTO> SavePersonnel(List<PersonnelDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSavePersonnel/{dto}")]
        ////List<PersonnelDTO> JsonSavePersonnel(List<PersonnelDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartmentDTO> SaveDepartment(List<DepartmentDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDepartment/{dto}")]
        ////List<DepartmentDTO> JsonSaveDepartment(List<DepartmentDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> SaveDepartStructure(List<DepartstructureDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDepartStructure/{dto}")]
        ////List<DepartstructureDTO> JsonSaveDepartStructure(List<DepartstructureDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DepartstructureDTO> SaveDepartStructureForModule(List<DepartstructureDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDepartStructureForModule/{dto}")]
        ////List<DepartstructureDTO> JsonSaveDepartStructureForModule(List<DepartstructureDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<PageDTO> SavePage(List<PageDTO> newPage);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSavePage/{newPage}")]
        ////List<PageDTO> JsonSavePage(List<PageDTO> newPage);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //PageAndPageusergroup SavePageSettings(PageAndPageusergroup page);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSavePageSettings/{page}")]
        ////PageAndPageusergroup JsonSavePageSettings(PageAndPageusergroup page);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SdDTO> SaveSd(List<SdDTO> sd);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSd/{sd}")]
        ////List<SdDTO> JsonSaveSd(List<SdDTO> sd);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SdmateriallistDTO> SaveSdmateriallist(List<SdmateriallistDTO> dto);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSdmateriallist/{dto}")]
        ////List<SdmateriallistDTO> JsonSaveSdmateriallist(List<SdmateriallistDTO> dto);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SdDTO> SaveSDWithMaterialList(List<SdDTO> sd, List<SdmateriallistDTO> sm);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSDWithMaterialList/{sd}/{sm}")]
        ////List<SdDTO> JsonSaveSDWithMaterialList(List<SdDTO> sd, List<SdmateriallistDTO> sm);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SdAndSdmateriallistDTO SaveSdAndSdmateriallistWithPageNumber(SdAndSdmateriallistDTO sdandsdmateriallist, int pageSize, int projectId, int moduleId, int sdTypeLUId, int materialCategoryId, int drawingId, string sdName, string company);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SdAndSdmateriallistDTO SaveSdAndSdmateriallist(SdAndSdmateriallistDTO sdandsdmateriallist);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSdAndSdmateriallist/{sdandsdmateriallist}")]
        ////SdAndSdmateriallistDTO JsonSaveSdAndSdmateriallist(SdAndSdmateriallistDTO sdandsdmateriallist);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void RemoveCalendar(int p6CalendarID);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonRemoveCalendar/{p6CalendarID}")]
        ////void JsonRemoveCalendar(string p6CalendarID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCWPByProject_PanelBar(int projectId, int moduleId);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWPByProject_PanelBar/{projectId}/{moduleId}")]
        ////List<ComboBoxDTO> JsonGetCWPByProject_PanelBar(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetComponentProgressTimesheetUncompleted_Combo(int cwpId, int materialcategoryId, int fiwpId, int projectId, int moduleId, DateTime workDate, int ruleofcreditweightId);

        ////[OperationContract]
        //////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressTimesheetUncompleted_Combo/{cwpId}/{materialcategoryId}/{fiwpId}/{projectId}/{moduleId}/{workDate}/{ruleofcreditweightId}")]
        ////List<ComboBoxDTO> JsonGetComponentProgressTimesheetUncompleted_Combo(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCostCodeByProject_Combo(int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostCodeByProject_Combo/{projectId}/{disciplineCode}")]
        List<ComboBoxDTO> JsonGetCostCodeByProject_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetWorkDateByProject_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveEquipment/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetWorkDateByProject_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetTimeSheetByWorkDate_Combo(int projectId, int moduleId, DateTime workDate);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimeSheetByWorkDate_Combo/{projectId}/{moduleId}/{workDate}")]
        //List<ComboBoxDTO> JsonGetTimeSheetByWorkDate_Combo(string projectId, string disciplineCode, string workDate);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LoopDTO> GetLoop_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCWPByProject_Combo(int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWPByProject_Combo_Mobile/{projectId}/{disciplineCode}/{userId}")]
        List<ComboBoxDTO> JsonGetCWPByProject_Combo_Mobile(string projectId, string disciplineCode, string userId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWPByProject_Combo/{projectId}/{disciplineCode}/{userId}")]
        List<ComboCodeBoxDTO> JsonGetCWPByProject_Combo(string projectId, string disciplineCode, string userId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetPlant_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetPlant_Combo")]
        //List<ComboBoxDTO> JsonGetPlant_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCompany_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCompany_Combo")]
        //List<ComboBoxDTO> JsonGetCompany_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCWPAssignedFIWPByProject_Combo(int materialcategoryId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWPAssignedFIWPByProject_Combo/{materialcategoryId}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetCWPAssignedFIWPByProject_Combo(string materialcategoryId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDrawingAll_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingAll_Combo")]
        //List<ComboBoxDTO> JsonGetDrawingAll_Combo();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetComponentIsoLineNo_Combo(int projectId, int moduleId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDrawingByCWP_Combo(int cwpId, int materialCategoryId, string engTagNumber, int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByCWP_Combo/{cwpId}/{taskcategoryId}/{engTagNumber}/{projectId}/{disciplineCode}")]
        List<ComboBoxDTO> JsonGetDrawingByCWP_Combo(string cwpId, string taskcategoryId, string engTagNumber, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDrawingByCWPProjectschedule_Combo(int cwpId, int projectscheduleId, string engTagNumber, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByCWPProjectschedule_Combo/{cwpId}/{projectscheduleId}/{engTagNumber}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetDrawingByCWPProjectschedule_Combo(string cwpId, string projectscheduleId, string engTagNumber, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDrawingByProjectSchedule_Combo(int projectScheduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByProjectSchedule_Combo/{projectScheduleId}")]
        //List<ComboBoxDTO> JsonGetDrawingByProjectSchedule_Combo(string projectScheduleId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDrawingTagByProjectID_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingTagByProjectID_Combo/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetDrawingTagByProjectID_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetReferenceDrawingByTagNo_Combo(string engTag, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetReferenceDrawingByTagNo_Combo/{engTag}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetReferenceDrawingByTagNo_Combo(string engTag, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetReferenceDrawingByQaqcformTemplate_Combo(int fiwpId, string engTag, int qaqcformTemplateId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetReferenceDrawingByQaqcformTemplate_Combo/{fiwpId}/{engTag}/{qaqcformTemplateId}")]
        //List<ComboBoxDTO> JsonGetReferenceDrawingByQaqcformTemplate_Combo(string fiwpId, string engTag, string qaqcformTemplateId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPCrewByFIWP_Combo(int projectScheduleId, int fiwpId, DateTime startDate, DateTime endDate, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPCrewByFIWP_Combo/{projectScheduleId}/{fiwpId}/{startDate}/{endDate}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetFIWPCrewByFIWP_Combo(string projectScheduleId, string fiwpId, string startDate, string endDate, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetManhourRateByLevel(int level, int parentlevelId, int levelId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetManhourRateByLevel/{level}/{parentlevelId}/{levelId}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetManhourRateByLevel(string level, string parentlevelId, string levelId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DataTable GetProgressTimesheetByProjectID_Combo(int cwpId, int materialcategoryId, int fiwpId, int projectId, int moduleId, DateTime workdate);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProgressTimesheetByProjectID_Combo/{cwpId}/{materialcategoryId}/{fiwpId}/{projectId}/{moduleId}/{workdate}")]
        //DataTable JsonGetProgressTimesheetByProjectID_Combo(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workdate);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetProjectScheduleByProject_Combo(int projectId, int moduleId);

        ////[OperationContract]
        ////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByProject_Combo/{projectId}/{moduleId}")]
        ////List<ComboBoxDTO> JsonGetProjectScheduleByProject_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetProjectScheduleByCwp_Combo(int cwpId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByCwp_Combo/{cwpId}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetProjectScheduleByCwp_Combo(string cwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetProjectScheduleByCwpWithFiwp_Combo(int cwpId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetQaqcDrawingsByComponent_Combo(int componentId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcDrawingsByComponent_Combo/{componentId}")]
        //List<ComboBoxDTO> JsonGetQaqcDrawingsByComponent_Combo(string componentId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetSubmittedQaqcformByFiwp(int fiwpId, string qaaqctemplate, int systemId, int projectId, int moduleId);

        ////[OperationContract]
        ////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSubmittedQaqcformByFiwp/{fiwpId}/{qaaqctemplate}{systemId}/{projectId}/{moduleId}")]
        ////List<ComboBoxDTO> JsonGetSubmittedQaqcformByFiwp(string fiwpId, string qaaqctemplate, string systemId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetReelNoByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetReelNoByFIWPQaqc_Combo/{fiwpId}/{qAQCFormTemplateID}")]
        //List<ComboBoxDTO> JsonGetReelNoByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetRuleofCreditByMaterialCategory_Combo(int projectId, int moduleId, int materialcategoryId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRuleofCreditByMaterialCategory_Combo/{projectId}/{disciplineCode}/{taskcategoryId}")]
        List<ComboBoxDTO> JsonGetRuleofCreditByMaterialCategory_Combo(string projectId, string disciplineCode, string taskcategoryId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetScaffoldByCwp_Combo(int cwpId, int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldByCwp_Combo/{cwpId}/{projectId}")]
        //List<ComboBoxDTO> JsonGetScaffoldByCwp_Combo(string cwpId, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetScaffoldRequestByCwp_Combo(int cwpId, int fiwpId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldRequestByCwp_Combo/{cwpId}/{fiwpId}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetScaffoldRequestByCwp_Combo(string cwpId, string fiwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetSDByModule_Combo(int moduleId, int materialcategoryId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSDByModule_Combo/{moduleId}/{materialcategoryId}")]
        //List<ComboBoxDTO> JsonGetSDByModule_Combo(string disciplineCode, string materialcategoryId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetSystemByProject_Combo(int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSystemByProject_Combo/{projectId}/{disciplineCode}")]
        List<ComboBoxDTO> JsonGetSystemByProject_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetTagNoByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTagNoByFIWPQaqc_Combo/{fiwpId}/{qAQCFormTemplateID}")]
        //List<ComboBoxDTO> JsonGetTagNoByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetEngTagNumberByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetEngTagNumberByFIWPQaqc_Combo/{fiwpId}/{qAQCFormTemplateID}")]
        //List<ComboBoxDTO> JsonGetEngTagNumberByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetKeyValueByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByProject_Combo/{fiwpId}/{qAQCFormTemplateID}")]
        //List<ComboBoxDTO> JsonGetKeyValueByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetSystemByFIWP_Combo(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSystemByFIWP_Combo/{fiwpId}")]
        //List<ComboBoxDTO> JsonGetSystemByFIWP_Combo(string fiwpId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDrawingByFIWP_Combo(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByFIWP_Combo/{fiwpId}")]
        //List<ComboBoxDTO> JsonGetDrawingByFIWP_Combo(string fiwpId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetQAQCFormByQCTemplateSystemCWPFIWP_Combo(int qctemplateID, int cwpId, int fiwpId, int systemId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQAQCFormByQCTemplateSystemCWPFIWP_Combo/{qctemplateID}/{cwpId}/{fiwpId}/{systemId}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetQAQCFormByQCTemplateSystemCWPFIWP_Combo(string qctemplateID, string cwpId, string fiwpId, string systemId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetMTOSearchGroup_Combo(int projectscheduleId, int projectId, int moduleId, string searchColumn, string tableName);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMTOSearchGroup_Combo/{projectscheduleId}/{projectId}/{moduleId}/{searchColumn}/{tableName}")]
        //List<ComboBoxDTO> JsonGetMTOSearchGroup_Combo(string projectscheduleId, string projectId, string disciplineCode, string searchColumn, string tableName);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetMaterialCategoryByModule_Combo(int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialCategoryByModule_Combo/{disciplineCode}")]
        List<ComboBoxDTO> JsonGetMaterialCategoryByModule_Combo(string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetLibinsulpipemanhourForPaging_Combo(string dbname, int selectedPage, int pageSize, int selectoption, decimal pipesize);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetMaterialProcessSystem_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetMaterialSize_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetChildDepartStructure_Combo(int moduleId, int projectId, string parentDepartment);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetChildDepartStructure_Combo/{moduleId}/{projectId}/{parentDepartment}")]
        //List<ComboBoxDTO> JsonGetChildDepartStructure_Combo(string disciplineCode, string projectId, string parentDepartment);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCrewAndForemanByFiwp_Combo(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCrewAndForemanByFiwp_Combo/{fiwpId}")]
        //List<ComboBoxDTO> JsonGetCrewAndForemanByFiwp_Combo(string fiwpId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCrewAndForemanByFiwpWorkDate_Combo(int fiwpId, int cwpId, int projectId, int moduleId, DateTime workDate);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCrewAndForemanByFiwpWorkDate_Combo/{iwpId}/{cwpId}/{projectId}/{disciplineCode}/{workDate}")]
        List<ComboBoxDTO> JsonGetCrewAndForemanByFiwpWorkDate_Combo(string iwpId, string cwpId, string projectId, string disciplineCode, string workDate);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetAllPersonnelByCWPProject_Combo(int fiwpId, int cwpId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAllPersonnelByCWPProject_Combo/{fiwpId}/{cwpId}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetAllPersonnelByCWPProject_Combo(string fiwpId, string cwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDFLByByProjectID_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDFLByByProjectID_Combo/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetDFLByByProjectID_Combo(string projectId, string disciplineCode);

        

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSigmaUserSigmaRoleBySigmaRoleReportToReportToRoleProject/{roleTypeCode}/{reportTo}/{reportToRoleTypeCode}/{projectId}")]
        List<ComboCodeBoxDTO> JsonGetSigmaUserSigmaRoleBySigmaRoleReportToReportToRoleProject(string roleTypeCode, string reportTo, string reportToRoleTypeCode, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetForemanByGeneralForeman_Combo(int departStructureID, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetForemanByGeneralForeman_Combo/{sigmaUserId}/{sigmaRoleId}/{projectId}")]
        //List<ComboBoxDTO> JsonGetForemanByGeneralForeman_Combo(string sigmaUserId, string sigmaRoleId, string projectId);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetForemanGeneralForemanNameByPersonnelDepartment_Combo(int personnelId, int departmentId, int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetForemanGeneralForemanNameByPersonnelDepartment_Combo/{personnelId}/{departmentId}/{projectId}/{disciplineCode}")]
        List<ComboCodeBoxDTO> JsonGetForemanGeneralForemanNameByPersonnelDepartment_Combo(string personnelId, string departmentId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetForemanByFIWP_Combo(int fiwpId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetForemanByFIWP_Combo/{fiwpId}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetForemanByFIWP_Combo(string fiwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetForemanByProjectID_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetForemanByProjectID_Combo/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetForemanByProjectID_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetGeneralForemanByProject_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetGeneralForemanByProject_Combo/{projectId}")]
        //List<ComboCodeBoxDTO> JsonGetGeneralForemanByProject_Combo(string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetGeneralForemanBySuperintendant_Combo(int projectId, int moduleId, int superintendantId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetGeneralForemanBySuperintendant_Combo/{projectId}/{moduleId}/{superintendantId}")]
        //List<ComboBoxDTO> JsonGetGeneralForemanBySuperintendant_Combo(string projectId, string disciplineCode, string superintendantId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetSuperintendantInPrjSchedule_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSuperintendantInPrjSchedule_Combo/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetSuperintendantInPrjSchedule_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByProject_Combo(int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByProject_Combo/{projectId}/{disciplineCode}")]
        List<ComboCodeBoxDTO> JsonGetFIWPByProject_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByProjectSchedule_Combo(int projectScheduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByProjectSchedule_Combo/{scheduledWorkItemId}")]
        List<ComboBoxDTO> JsonGetFIWPByProjectSchedule_Combo(string scheduledWorkItemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByProjectSchedulePackageType_Combo(int projectScheduleId, int packagetypeLuid);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByProjectSchedulePackageType_Combo/{scheduledWorkItemId}/{packageTypeCode}")]
        List<ComboBoxDTO> JsonGetFIWPByProjectSchedulePackageType_Combo(string scheduledWorkItemId, string packageTypeCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByPersonnelDepartment_Combo(int projectId, int moduleId, int personnelId, int departmentId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByPersonnelDepartment_Combo/{projectId}/{moduleId}/{personnelId}/{departmentId}")]
        //List<ComboBoxDTO> JsonGetFIWPByPersonnelDepartment_Combo(string projectId, string disciplineCode, string personnelId, string departmentId);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByPersonnelDepartmentFiwpqaqc_Combo(int projectId, int moduleId, int personnelId, int departmentId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByPersonnelDepartmentFiwpqaqc_Combo/{projectId}/{disciplineCode}/{personnelId}/{departmentId}")]
        List<ComboBoxDTO> JsonGetFIWPByPersonnelDepartmentFiwpqaqc_Combo(string projectId, string disciplineCode, string personnelId, string departmentId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ExtSchedulerDTO GetFIWPByFIWP_ExtSch(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByFIWP_ExtSch/{fiwpId}")]
        //ExtSchedulerDTO JsonGetFIWPByFIWP_ExtSch(string fiwpId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ExtSchedulerDTO> GetFIWPByProjectSchedule_ExtSch(int projectScheduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByProjectSchedule_ExtSch/{scheduledWorkItemId}")]
        List<ExtSchedulerDTO> JsonGetFIWPByProjectSchedule_ExtSch(string scheduledWorkItemId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ExtSchedulerDTO> GetFIWPByProjectSchedule_ExtSch_Mobile(int projectId, int moduleId, int cwpid);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ExtSchedulerDTO> GetFIWPByProjectSchedule_ExtSch_MobileHicharts(int projectId, int moduleId, int cwpid);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ExtSchedulerDTO> GetProjectSchedule_Cwp_ExtSch(int cwpid, int projectId, int moduleId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ExtSchedulerDTO> GetProjectSchedule_fiwp_Cwp_ExtSch(int cwpid, int projectId, int moduleId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ExtSchedulerDTO> GetFiwpManPowerByProjectSchedule_ExtSch(int scheduleId, int fiwpId, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpManPowerByProjectSchedule_ExtSch/{scheduleId}/{fiwpId}/{projectId}/{moduleId}")]
        //List<ExtSchedulerDTO> JsonGetFiwpManPowerByProjectSchedule_ExtSch(string scheduleId, string fiwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByCwp_Combo(int cwpId, int materialcategoryId, int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByCwp_Combo/{cwpId}/{taskCategoryId}/{projectId}/{disciplineCode}")]
        List<ComboBoxDTO> JsonGetFIWPByCwp_Combo(string cwpId, string taskCategoryId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByPackageType_Combo(int projectId, int moduleId, int packagetypeLuid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByPackageType_Combo/{projectId}/{moduleId}/{packagetypeLuid}")]
        //List<ComboBoxDTO> JsonGetFIWPByPackageType_Combo(string projectId, string disciplineCode, string packagetypeLuid);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetTagNumberByComponent_Combo(int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTagNumberByComponent_Combo/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetTagNumberByComponent_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDocumentByFIWP_Combo(int projectId, int moduleId, int cwpId, int fiwpId, int DocumentTypeLUID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentByFIWP_Combo/{projectId}/{moduleId}/{cwpId}/{fiwpId}/{DocumentTypeLUID}")]
        //List<ComboBoxDTO> JsonGetDocumentByFIWP_Combo(string projectId, string disciplineCode, string cwpId, string fiwpId, string DocumentTypeLUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFIWPByMaterialCategoryType_Combo(string type, int projectId, int moduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPByMaterialCategoryType_Combo/{type}/{projectId}/{moduleId}")]
        //List<ComboBoxDTO> JsonGetFIWPByMaterialCategoryType_Combo(string type, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetLookupByLookupType_Combo(string lookuptype, string lookupsubtype);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLookupByLookupType_Combo/{lookuptype}/{lookupsubtype}")]
        List<ComboCodeBoxDTO> JsonGetLookupByLookupType_Combo(string lookuptype, string lookupsubtype);

        //JsonGetLookupByLookupType_Combo 과 동일함, 차후 JsonGetLookupByLookupType_Combo 삭제예정
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSigmaCodeByCodeCategory_Combo/{codeCategory}/{subCodeCategory}")]
        List<ComboCodeBoxDTO> JsonGetSigmaCodeByCodeCategory_Combo(string codeCategory, string subCodeCategory);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCableType1_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCableType1_Combo")]
        //List<ComboBoxDTO> JsonGetCableType1_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetCableType2_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCableType2_Combo")]
        //List<ComboBoxDTO> JsonGetCableType2_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetEquipType_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetEquipType_Combo")]
        //List<ComboBoxDTO> JsonGetEquipType_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetFixtureType_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFixtureType_Combo")]
        //List<ComboBoxDTO> JsonGetFixtureType_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetInstrCategory_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetInstrCategory_Combo")]
        //List<ComboBoxDTO> JsonGetInstrCategory_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetInstrType_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetInstrType_Combo")]
        //List<ComboBoxDTO> JsonGetInstrType_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetItemCode_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetItemCode_Combo")]
        //List<ComboBoxDTO> JsonGetItemCode_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetLightingType_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLightingType_Combo")]
        //List<ComboBoxDTO> JsonGetLightingType_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetRacewayClass_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRacewayClass_Combo")]
        //List<ComboBoxDTO> JsonGetRacewayClass_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetRacewayLength_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRacewayLength_Combo")]
        //List<ComboBoxDTO> JsonGetRacewayLength_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetRacewayType_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRacewayType_Combo")]
        //List<ComboBoxDTO> JsonGetRacewayType_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetRacewayWidth_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRacewayWidth_Combo")]
        //List<ComboBoxDTO> JsonGetRacewayWidth_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetSiderailDepth_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSiderailDepth_Combo")]
        //List<ComboBoxDTO> JsonGetSiderailDepth_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetSDType_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSDType_Combo")]
        //List<ComboBoxDTO> JsonGetSDType_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetUOM_Combo();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUOM_Combo")]
        List<ComboCodeBoxDTO> JsonGetUOM_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetVendor_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetVendor_Combo")]
        //List<ComboBoxDTO> JsonGetVendor_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetLibPipeMaterailGrp_Combo();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeMaterailGrp_Combo")]
        //List<ComboBoxDTO> JsonGetLibPipeMaterailGrp_Combo();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetTaskTypeByMaterialCategoryForElectricalEstManhrsLibrary_Combo(int materialCategoryId, int divValue);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTaskTypeByMaterialCategoryForElectricalEstManhrsLibrary_Combo/{materialCategoryId}/{divValue}")]
        //List<ComboBoxDTO> JsonGetTaskTypeByMaterialCategoryForElectricalEstManhrsLibrary_Combo(string materialCategoryId, string divValue);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetVendorByMaterialCategoryForElectricalEstManhrsLibrary_Combo(int materialCategoryId, int divValue);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetVendorByMaterialCategoryForElectricalEstManhrsLibrary_Combo/{materialCategoryId}/{divValue}")]
        //List<ComboBoxDTO> JsonGetVendorByMaterialCategoryForElectricalEstManhrsLibrary_Combo(string materialCategoryId, string divValue);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetTurnoverPackageByBinderPage_Combo(int projectId, int moduleId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTurnoverPackageByBinderPage_Combo/{projectId}/{disciplineCode}")]
        List<ComboBoxDTO> JsonGetTurnoverPackageByBinderPage_Combo(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", UriTemplate = "JsonTruetaskFileUpload/{fileName}")]
        //bool JsonTruetaskFileUpload(string fileName, Stream fileStream);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveUploadFile")]
        UpfileDTOS JsonSaveUploadFile(UpfileDTOS upFileDS, string userId);

        #region 업로드테스트
        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UploadTestByte")]
        void UploadTestByte(ByteTypeDTO drawing);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSingleUploadFileTest")]
        UpfileDTOS JsonSaveSingleUploadFileTest();
        #endregion 업로드테스트

        #region DataSync
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSyncDownload/{apkVersion}/{udID}/{loginID}/{dataVersion}")]
        List<DataSyncFileVersionInfoDTO> JsonSyncDownload(string apkVersion, string udID, string loginID, string dataVersion);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonMultiUploadFileHistoryInfo")]
        SigmaResultTypeDTO JsonMultiUploadFileHistoryInfo(List<UploadFileHistoryInfoDTO> objList);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonAddUploadFileHistoryInfo")]
        SigmaResultTypeDTO JsonAddUploadFileHistoryInfo(UploadFileHistoryInfoDTO anObj);
        #endregion DataSync

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUploadFileByPath")]
        SigmaResultTypeDTO JsonUploadFileByPath(List<UploadFileDTO> objList);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonAddDataSyncHistoryInfo/{FromFileVerSionId}/{ToFileVerSionId}/{MobileLoginId}/{MobileUdId}/{CreatedDate}")]
        SigmaResultTypeDTO JsonAddDataSyncHistoryInfo(String FromFileVerSionId, String ToFileVerSionId, String MobileLoginId, String MobileUdId, String CreatedDate);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSyncZumero/{loginID}")]
        DataSyncZumeroInfoDTO JsonSyncZumero(string loginID);
    }

    //[ServiceContract]
    //public interface ITransferService
    //{
    //    [OperationContract]
    //    void UploadFile(string parentDir, string fileName, long length, byte[] fileBytes);
    //}

}
