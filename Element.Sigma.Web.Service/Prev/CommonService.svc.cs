using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.IO;
using Element.Sigma.Web.Biz;
using Element.Reveal.DataLibrary;

namespace Element.Sigma.Web.Service.Prev
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommonService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CommonService : ICommonService
    {
        //#region "Get, SELECT"

        //public List<EquipmentDTO> GetAllEqupment()
        //{

        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllEquipment();
        //}

        //public List<EquipmentDTO> JsonGetAllEqupment()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllEquipment();
        //}

        //public EquipmentDTO GetEqupmentById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEquipmentByID(Id);
        //}

        //public EquipmentDTO JsonGetEqupmentById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEquipmentByID(Int32.Parse(Id));
        //}

        //public List<EquipmentDTO> GetEquipmentByType(int type, string EquipName, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEquipmentByType(type, EquipName, projectId);
        //}

        //public List<EquipmentDTO> JsonGetEquipmentByType(string type, string EquipName, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEquipmentByType(Int32.Parse(type), EquipName, Int32.Parse(projectId));
        //}

        //public List<FieldequipmentDTO> GetAllFieldEqupment()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllFieldEquipment();
        //}

        //public List<FieldequipmentDTO> JsonGetAllFieldEqupment()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllFieldEquipment();
        //}
        
        //public FieldequipmentDTO GetFieldEqupmentById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFieldEquipmentByID(Id);
        //}

        //public FieldequipmentDTO JsonGetFieldEqupmentById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFieldEquipmentByID(Int32.Parse(Id));
        //}

        //public List<FieldequipmentDTO> GetFieldequipmentByType(string search)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFieldequipmentByType(search);
        //}

        public List<FieldequipmentDTO> JsonGetFieldequipmentByType(string search)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetFieldequipmentByType(Helper.RemoveJsonParameterWrapper(search));
        }

        //public CompanyDTO GetCompanyById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyById(Id);
        //}

        //public CompanyDTO JsonGetCompanyById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyById(Int32.Parse(Id));
        //}

        //public List<CompanyDTO> GetCompanyByTypeLUID(int CompanyTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByTypeLUID(CompanyTypeLUID);
        //}

        //public List<CompanyDTO> JsonGetCompanyByTypeLUID(string CompanyTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByTypeLUID(Int32.Parse(CompanyTypeLUID));
        //}

        //public List<CompanyDTO> GetCompanyByCompanyType(string CompanyType)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByCompanyType(CompanyType);
        //}

        //public List<CompanyDTO> JsonGetCompanyByCompanyType(string CompanyType)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByCompanyType(CompanyType);
        //} 

        //public List<CompanyDTO> GetCompanyByName(string name)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByCompanyName(name);
        //}

        //public List<CompanyDTO> JsonGetCompanyByName(string name)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByCompanyName(name);
        //}

        //public List<CompanyDTO> GetCompanyByCompanyId(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByCompanyId(Id);
        //}

        //public List<CompanyDTO> JsonGetCompanyByCompanyId(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyByCompanyId(Int32.Parse(Id));
        //}

        //public List<CompanyDTO> GetCompanyAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyAll();
        //}

        //public List<CompanyDTO> JsonGetCompanyAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompanyAll();
        //}

        //public List<ProjectcontractorDTO> GetProjectContractor(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectContractor(Id);
        //}

        //public List<ProjectcontractorDTO> JsonGetProjectContractor(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectContractor(Int32.Parse(Id));
        //}

        //public List<EmpclassDTO> GetEmpclassById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEmpclassById(Id);
        //}

        //public List<EmpclassDTO> JsonGetEmpclassById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEmpclassById(Int32.Parse(Id));
        //}

        //public List<EmpclassDTO> GetEmpclassAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEmpclassAll();
        //}

        //public List<EmpclassDTO> JsonGetEmpclassAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEmpclassAll();
        //}

        //public List<LookupDTO> GetUserGroup()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupByLookupType(LOOKUPTYPE.UserGroup);
        //}

        //public List<LookupDTO> JsonGetUserGroup()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupByLookupType(LOOKUPTYPE.UserGroup);
        //}

        //public List<LookupDTO> GetLookupByLookupType(string lookuptype)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupByLookupType(Helper.RemoveJsonParameterWrapper(lookuptype));
        //}

        public List<LookupDTO> JsonGetLookupByLookupType(string lookuptype)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetSigmaCodeByCodeCategory(Helper.RemoveJsonParameterWrapper(lookuptype));
        }

        //public List<LookupDTO> GetLookupByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupByID(Id);
        //}

        //public List<LookupDTO> JsonGetLookupByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupByID(Int32.Parse(Id));
        //}

        //public LookupDTO GetSingleLookupByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSingleLookupByID(Id);
        //}

        //public LookupDTO JsonGetSingleLookupByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSingleLookupByID(Int32.Parse(Id));
        //}

        //public List<LookupDTO> GetAllLookup()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupAll();
        //}

        //public List<LookupDTO> JsonGetAllLookup()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupAll();
        //}

        //public List<LookupDTO> GetLookupForLibInsulPipeFactor()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupForLibInsulPipeFactor();
        //}



        //public List<UserlookupDTO> GetUserlookupByLookupType(string lookuptype)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByLookupType(Helper.RemoveJsonParameterWrapper(lookuptype));
        //}

        //public List<UserlookupDTO> JsonGetUserlookupByLookupType(string lookuptype)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByLookupType(Helper.RemoveJsonParameterWrapper(lookuptype));
        //}

        //public List<UserlookupDTO> GetUserlookupByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByID(Id);
        //}

        //public List<UserlookupDTO> JsonGetUserlookupByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByID(Int32.Parse(Id));
        //}

        //public UserlookupDTO GetSingleUserlookupByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSingleUserlookupByID(Id);
        //}

        //public UserlookupDTO JsonGetSingleUserlookupByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSingleUserlookupByID(Int32.Parse(Id));
        //}

        //public UserlookupCityDTO GetSingleUserlookupByID_City(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSingleUserlookupByID_City(Id);
        //}

        //public UserlookupCityDTO JsonGetSingleUserlookupByID_City(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSingleUserlookupByID_City(Int32.Parse(Id));
        //}

        //public List<UserlookupDTO> GetAllUserlookup()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupAll();
        //}

        //public List<UserlookupDTO> JsonGetAllUserlookup()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupAll();
        //}

        //public List<UserlookupCityDTO> GetUserlookupByType_City(string lookuptype, int CountryID, int ProvinceID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByType_City(lookuptype, CountryID, ProvinceID);
        //}

        //public List<UserlookupCityDTO> JsonGetUserlookupByType_City(string lookuptype, string CountryID, string ProvinceID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByType_City(lookuptype, Int32.Parse(CountryID), Int32.Parse(ProvinceID));
        //}

        //public List<TaskcategoryDTO> GetTaskCategoryByModuleID(int id)
        //{
        //    List<TaskcategoryDTO> dto = new List<TaskcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetTaskCategoryByModuleID(id);
        //    return dto;
        //}

        //public List<TaskcategoryDTO> JsonGetTaskCategoryByModuleID(string id)
        //{
        //    List<TaskcategoryDTO> dto = new List<TaskcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetTaskCategoryByModuleID(Int32.Parse(id));
        //    return dto;
        //}

        //public List<TaskcategoryDTO> GetTaskCategoryByLibInsulPipeFactor()
        //{
        //    List<TaskcategoryDTO> dto = new List<TaskcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetTaskCategoryByLibInsulPipeFactor();
        //    return dto;
        //}

        //public List<TaskcategoryDTO> JsonGetTaskCategoryByLibInsulPipeFactor()
        //{
        //    List<TaskcategoryDTO> dto = new List<TaskcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetTaskCategoryByLibInsulPipeFactor();
        //    return dto;
        //}

        //public List<TaskcategoryDTO> GetTaskcategoryByMaterialCategory(int moduleId, int materialCategoryId)
        //{
        //    List<TaskcategoryDTO> dto = new List<TaskcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetTaskcategoryByMaterialCategory(moduleId, materialCategoryId);
        //    return dto;
        //}

        public List<TaskcategoryDTO> JsonGetTaskcategoryByMaterialCategory(string disciplineCode, string taskcategoryId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetTaskcategoryByMaterialCategory(Helper.RemoveJsonParameterWrapper(disciplineCode), Int32.Parse(taskcategoryId));
        }

        //public List<MaterialcategoryDTO> GetMaterialCategoryByModuleID(int moduleid)
        //{
        //    List<MaterialcategoryDTO> dto = new List<MaterialcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetMaterialCategoryByModuleID(moduleid);
        //    return dto;
        //}

        public List<MaterialcategoryDTO> JsonGetMaterialCategoryByDisciplineCode(string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetMaterialCategoryByDisciplineCode(Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<MaterialcategoryDTO> GetMaterialCategoryByLibInsulPipeFactor()
        //{
        //    List<MaterialcategoryDTO> dto = new List<MaterialcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetMaterialCategoryByLibInsulPipeFactor();
        //    return dto;
        //}

        //public List<MaterialcategoryDTO> JsonGetMaterialCategoryByLibInsulPipeFactor()
        //{
        //    List<MaterialcategoryDTO> dto = new List<MaterialcategoryDTO>();

        //    dto = (new Element.Reveal.Server.BALC.CommonReader()).GetMaterialCategoryByLibInsulPipeFactor();
        //    return dto;
        //}

        //public List<ModuleDTO> GetModuleAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetModuleAll(); ;
        //}

        public List<ModuleDTO> JsonGetModuleAll()
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetModuleAll(); ;
        }

        //public ModuleDTO GetModuleByID(int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetModuleByID(moduleId);
        //}

        public ModuleDTO JsonGetModuleByID(string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetModuleByID(Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<RuleofcreditweightDTO> GetRuelOfCreditWeightByProjectAndMaterialCategory(int projectId, int moduleId, int materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRuelOfCreditWeightByProjectAndMaterialCategory(projectId, moduleId, materialcategoryId);
        //}

        //public List<RuleofcreditweightDTO> JsonGetRuelOfCreditWeightByProjectAndMaterialCategory(string projectId, string disciplineCode, string materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRuelOfCreditWeightByProjectAndMaterialCategory(Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(materialcategoryId));
        //}

        //public List<RuleofcreditweightDTO> GetRuleOfCreditWeightByProject(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRuleOfCreditWeightByProject(projectId, moduleId);
        //}

        //public List<RuleofcreditweightDTO> JsonGetRuleOfCreditWeightByProject(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRuleOfCreditWeightByProject(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<LookupDTO> GetRuleOfCreditAvailable(int projectId, int moduleId, int materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRuleOfCreditAvailable(projectId, moduleId, materialcategoryId);
        //}

        //public List<LookupDTO> JsonGetRuleOfCreditAvailable(string projectId, string disciplineCode, string materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRuleOfCreditAvailable(Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(materialcategoryId));
        //}
        
        //public List<DepartmentDTO> GetDepartmentAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentAll();
        //}

        //public List<DepartmentDTO> JsonGetDepartmentAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentAll();
        //}

        //public DepartmentDTO GetDepartmentByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentByID(id);
        //}

        //public DepartmentDTO JsonGetDepartmentByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentByID(Int32.Parse(id));
        //}

        //public DepartmentDTO GetDepartmentByDepartmentText(string department)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentByDepartmentText(department);
        //}

        //public DepartmentDTO JsonGetDepartmentByDepartmentText(string department)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentByDepartmentText(department);
        //}

        //public List<DepartmentDTO> GetDepartmentByDepartType(int departTypeLUId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentByDepartType(departTypeLUId, 0);
        //}

        //public List<DepartmentDTO> JsonGetDepartmentByDepartType(string departTypeLUId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartmentByDepartType(Int32.Parse(departTypeLUId), 0);
        //}

        //public List<DepartmentDTO> GetDepartmentApprovalGroup(int departTypeLUId)
        //{
        //    return (new BALC.CommonReader()).GetDepartmentByDepartType(departTypeLUId, 1).ToList();
        //}

        //public List<DepartmentDTO> JsonGetDepartmentApprovalGroup(string departTypeLUId)
        //{
        //    return (new BALC.CommonReader()).GetDepartmentByDepartType(Int32.Parse(departTypeLUId), 1).ToList();
        //}

        //public DepartstructureDTO GetDepartstructureByPersonnelDepartStructure(int personnelId, int departstructId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByPersonnelDepartStructure(Helper.RemoveJsonParameterWrapper(personnelId), departstructId, projectId, moduleId);
        //}

        //public DepartstructureDTO JsonGetDepartstructureByPersonnelDepartStructure(string personnelId, string departstructId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByPersonnelDepartStructure(Int32.Parse(Helper.RemoveJsonParameterWrapper(personnelId)), Int32.Parse(departstructId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}
        
        //public List<DepartstructureDTO> GetDepartstructureByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureById(Id);
        //}

        //public List<DepartstructureDTO> JsonGetDepartstructureByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureById(Int32.Parse(Id));
        //}

        //public List<DepartstructureDTO> GetDepartStructureByPersonnelID(int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartStructureByPersonnelID(Helper.RemoveJsonParameterWrapper(personnelId));
        //}

        //public List<DepartstructureDTO> GetDepartstructureByProject(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByProject(projectId, moduleId);
        //}

        //public List<DepartstructureDTO> JsonGetDepartstructureByProject(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByProject(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<DepartstructureDTO> GetDepartstructureByProjectModuleForMenonsite(int projectId, int moduleId, int departTypeLUID, string name)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByProjectModuleForMenonsite(projectId, moduleId, departTypeLUID, name);
        //}

        //public List<DepartstructureDTO> JsonGetDepartstructureByProjectModuleForMenonsite(string projectId, string disciplineCode, string departTypeLUID, string name)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByProjectModuleForMenonsite(Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(departTypeLUID), name);
        //}

        //public List<DepartstructureDTO> GetChildDepartStructureByDepartStructure(int departStructureID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetChildDepartStructureByDepartStructure(departStructureID);
        //}

        //public List<DepartstructureDTO> JsonGetChildDepartStructureByDepartStructure(string departStructureID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetChildDepartStructureByDepartStructure(Int32.Parse(departStructureID));
        //}

        //public List<DepartstructureDTO> GetWorkFlowDepartStructureByDepartment(int departmentId, int departStructureId, int fiwpid, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetWorkFlowDepartStructureByDepartment(departmentId, departStructureId, fiwpid, projectId, moduleId);
        //}

        //public List<DepartstructureDTO> JsonGetWorkFlowDepartStructureByDepartment(string departmentId, string departStructureId, string fiwpid, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetWorkFlowDepartStructureByDepartment(Int32.Parse(departmentId), Int32.Parse(departStructureId), Int32.Parse(fiwpid), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<PersonnelDTO> GetAllPersonnelByProjectID(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllPersonnelByProjectID(projectId, moduleId);
        //}

        //public List<PersonnelDTO> JsonGetAllPersonnelByProjectID(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllPersonnelByProjectID(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<PersonnelDTO> GetAllPersonnelUnassignedByProjectID(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllPersonnelUnassignedByProjectID(projectId);
        //}

        //public List<PersonnelDTO> JsonGetAllPersonnelUnassignedByProjectID(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllPersonnelUnassignedByProjectID(Int32.Parse(projectId));
        //}

        //public List<PersonnelDTO> GetPersonnelByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetPersonnelByID(Id);
        //}

        //public List<PersonnelDTO> JsonGetPersonnelByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetPersonnelByID(Int32.Parse(Id));
        //}

        //public PersonnelDTO GetSinglePersonnelByDepartStructure(int departStructureID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSinglePersonnelByDepartStructure(departStructureID);
        //}

        //public PersonnelDTO JsonGetSinglePersonnelByDepartStructure(string departStructureID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSinglePersonnelByDepartStructure(Int32.Parse(departStructureID));
        //}

        //public PersonnelDTO GetSinglePersonnelByID(int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.UserReader()).GetSinglePersonnelByID(Helper.RemoveJsonParameterWrapper(personnelId));
        //}

        public PersonnelDTO JsonGetSinglePersonnelByID(string personnelId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetSinglePersonnelByID(Helper.RemoveJsonParameterWrapper(personnelId));
        }

        public ComboCodeBoxDTO JsonGetSigmaUserPhotoBySigmaUserId(string sigmaUserId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetSigmaUserPhotoBySigmaUserId(Helper.RemoveJsonParameterWrapper(sigmaUserId), Helper.GetWebrootUrl());
        }

        public UserInfoDTO JsonGetUserInfo(string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetUserInfo(Helper.RemoveJsonParameterWrapper(userId));
        }

        //public PageAndPageusergroup GetPageSettings(string pageGUID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetPageByGUID(pageGUID);
        //}

        //public PageAndPageusergroup JsonGetPageSettings(string pageGUID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetPageByGUID(pageGUID);
        //}

        //public SdDTO GetSdByID(int sdId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdByID(sdId);
        //}

        //public SdDTO JsonGetSdByID(string sdId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdByID(Int32.Parse(sdId));
        //}

        //public List<SdDTO> GetSdByModule(int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdByModule(moduleId);
        //}

        //public List<SdDTO> JsonGetSdByModule(string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdByModule(Int32.Parse(moduleId));
        //}

        //public List<SdDTO> GetSdByMaterialCategory(int materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdByMaterialCategory(materialcategoryId);
        //}

        //public List<SdDTO> JsonGetSdByMaterialCategory(string materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdByMaterialCategory(Int32.Parse(materialcategoryId));
        //}

        //public List<SdmateriallistDTO> GetSdmateriallistBySD(int sdId, int uomLUId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdmateriallistBySD(sdId, uomLUId);
        //}
        
        //public List<SdmateriallistDTO> JsonGetSdmateriallistBySD(string sdId, string uomLUId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdmateriallistBySD(Int32.Parse(sdId), Int32.Parse(uomLUId));
        //}

        //public SdmateriallistDTO GetSdmateriallistByMaterialListID(int MaterialListID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdmateriallistByMaterialListID(MaterialListID);
        //}

        //public SdmateriallistDTO JsonGetSdmateriallistByMaterialListID(string MaterialListID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdmateriallistByMaterialListID(Int32.Parse(MaterialListID));
        //}

        //public SdPageTotal GetSdForPaging(int selectedPage, int pageSize, int projectId, int moduleId, int sdTypeLUId, int materialCategoryId, int drawingId, string sdName, string company)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdForPaging(selectedPage, pageSize, projectId, moduleId, sdTypeLUId, materialCategoryId, drawingId, sdName, company);
        //}

        //public SdPageTotal JsonGetSdForPaging(string selectedPage, string pageSize, string projectId, string disciplineCode, string sdTypeLUId, string materialCategoryId, string drawingId, string sdName, string company)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(sdTypeLUId), Int32.Parse(materialCategoryId), Int32.Parse(drawingId), sdName, company);
        //}

        //public SdPageTotal GetSdForPagingMto(int selectedPage, int pageSize, int ModuleId, int SDType, int MaterialCategory, string SDName, string Company)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdForPagingMto(selectedPage, pageSize, ModuleId, SDType, MaterialCategory, SDName, Company);
        //}

        //public SdPageTotal JsonGetSdForPagingMto(string selectedPage, string pageSize, string disciplineCode, string SDType, string MaterialCategory, string SDName, string Company)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSdForPagingMto(Int32.Parse(selectedPage), Int32.Parse(pageSize), Int32.Parse(ModuleId), Int32.Parse(SDType), Int32.Parse(MaterialCategory), SDName, Company);
        //}

        //public List<UsergroupDTO> GetUsergroupAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUsergroupAll();
        //}

        //public List<UsergroupDTO> JsonGetUsergroupAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUsergroupAll();
        //}

        //public List<DepartstructureDTO> GetDepartstructureByDepartment(int departmentId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByDepartment(departmentId, projectId, moduleId);
        //}

        //public List<DepartstructureDTO> JsonGetDepartstructureByDepartment(string departmentId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByDepartment(Int32.Parse(departmentId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<DepartstructureDTO> GetDepartstructureByDepartmentText(string department, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByDepartmentText(department, projectId, moduleId);
        //}

        //public List<DepartstructureDTO> JsonGetDepartstructureByDepartmentText(string department, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByDepartmentText(department, Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<DepartstructureDTO> GetDepartstructureByLoginAccount(int loginAccountId, int departTypeLUId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByLoginAccount(loginAccountId, departTypeLUId);
        //}

        //public List<DepartstructureDTO> JsonGetDepartstructureByLoginAccount(string loginAccountId, string departTypeLUId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDepartstructureByLoginAccount(Int32.Parse(loginAccountId), Int32.Parse(departTypeLUId));
        //}

        //public List<ImportedfilenameDTO> GetImportedfilenameAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetImportedfilenameAll();
        //}

        //public List<ImportedfilenameDTO> JsonGetImportedfilenameAll()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetImportedfilenameAll();
        //}

        //public List<ImportedfilenameDTO> GetImportedfilenameByfilename(string filename, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetImportedfilenameByfilename(filename, projectId, moduleId);
        //}

        //public List<ImportedfilenameDTO> JsonGetImportedfilenameByfilename(string filename, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetImportedfilenameByfilename(filename, Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ImportedfilenameDTO> GetImportedfilenameByfiletype(string filetype, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetImportedfilenameByfiletype(filetype, projectId, moduleId);
        //}

        //public List<ImportedfilenameDTO> JsonGetImportedfilenameByfiletype(string filetype, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetImportedfilenameByfiletype(filetype, Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //#endregion "End Get, SELECT"

        //#region "Save"

        //public List<EquipmentDTO> SaveEquipment(List<EquipmentDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveEquipment(dto);
        //}

        //public List<EquipmentDTO> JsonSaveEquipment(List<EquipmentDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveEquipment(dto);
        //}

        //public List<FieldequipmentDTO> SaveFieldEquipment(List<FieldequipmentDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveFieldEquipment(dto);
        //}

        //public List<FieldequipmentDTO> JsonSaveFieldEquipment(List<FieldequipmentDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveFieldEquipment(dto);
        //}

        //public List<ProjectcontractorDTO> SaveProjectContractor(List<ProjectcontractorDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveProjectContractor(dto);
        //}

        //public List<ProjectcontractorDTO> JsonSaveProjectContractor(List<ProjectcontractorDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveProjectContractor(dto);
        //}

        //public List<CompanyDTO> SaveCompany(List<CompanyDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveCompany(dto);
        //}

        //public List<CompanyDTO> JsonSaveCompany(List<CompanyDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveCompany(dto);
        //}

        //public List<EmpclassDTO> SaveEmpclass(List<EmpclassDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveEmpclass(dto);
        //}

        //public List<EmpclassDTO> JsonSaveEmpclass(List<EmpclassDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveEmpclass(dto);
        //}

        //public List<LookupDTO> SaveLookup(List<LookupDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveLookup(dto);
        //}

        //public List<LookupDTO> JsonSaveLookup(List<LookupDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveLookup(dto);
        //}

        //public List<UserlookupDTO> SaveUserlookup(List<UserlookupDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveUserlookup(dto);
        //}

        //public List<UserlookupDTO> JsonSaveUserlookup(List<UserlookupDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveUserlookup(dto);
        //}

        //public List<UserlookupCityDTO> SaveUserlookupCity(List<UserlookupCityDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveUserlookupCity(dto);
        //}

        //public List<UserlookupCityDTO> JsonSaveUserlookupCity(List<UserlookupCityDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveUserlookupCity(dto);
        //}

        //public List<RuleofcreditweightDTO> SaveRuleOfCreditWeight(List<RuleofcreditweightDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveRuleOfCreditWeight(dto);
        //}

        //public List<RuleofcreditweightDTO> JsonSaveRuleOfCreditWeight(List<RuleofcreditweightDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveRuleOfCreditWeight(dto);
        //}

        //public List<PersonnelDTO> SavePersonnel(List<PersonnelDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SavePersonnel(dto);
        //}

        //public List<PersonnelDTO> JsonSavePersonnel(List<PersonnelDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SavePersonnel(dto);
        //}

        //public List<DepartmentDTO> SaveDepartment(List<DepartmentDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveDepartment(dto);
        //}

        //public List<DepartmentDTO> JsonSaveDepartment(List<DepartmentDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveDepartment(dto);
        //}

        //public List<DepartstructureDTO> SaveDepartStructure(List<DepartstructureDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveDepartStructure(dto);
        //}

        //public List<DepartstructureDTO> JsonSaveDepartStructure(List<DepartstructureDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveDepartStructure(dto);
        //}

        //public List<DepartstructureDTO> SaveDepartStructureForModule(List<DepartstructureDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveDepartStructureForModule(dto);
        //}

        //public List<DepartstructureDTO> JsonSaveDepartStructureForModule(List<DepartstructureDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveDepartStructureForModule(dto);
        //}

        //public List<PageDTO> SavePage(List<PageDTO> newPage)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SavePage(newPage, RowStatus.None);
        //}

        //public List<PageDTO> JsonSavePage(List<PageDTO> newPage)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SavePage(newPage, RowStatus.None);
        //}

        //public PageAndPageusergroup SavePageSettings(PageAndPageusergroup page)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SavePageSettings(page);
        //}

        //public PageAndPageusergroup JsonSavePageSettings(PageAndPageusergroup page)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SavePageSettings(page);
        //}

        //public List<SdDTO> SaveSd(List<SdDTO> sd)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSd(sd);
        //}

        //public List<SdDTO> JsonSaveSd(List<SdDTO> sd)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSd(sd);
        //}

        //public List<SdmateriallistDTO> SaveSdmateriallist(List<SdmateriallistDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSdmateriallist(dto);
        //}

        //public List<SdmateriallistDTO> JsonSaveSdmateriallist(List<SdmateriallistDTO> dto)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSdmateriallist(dto);
        //}

        //public List<SdDTO> SaveSDWithMaterialList(List<SdDTO> sd, List<SdmateriallistDTO> sm)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSDWithMaterialList(sd, sm);
        //}

        //public List<SdDTO> JsonSaveSDWithMaterialList(List<SdDTO> sd, List<SdmateriallistDTO> sm)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSDWithMaterialList(sd, sm);
        //}

        //public SdAndSdmateriallistDTO SaveSdAndSdmateriallistWithPageNumber(SdAndSdmateriallistDTO sdandsdmateriallist, int pageSize, int projectId, int moduleId, int sdTypeLUId, int materialCategoryId, int drawingId, string sdName, string company)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSdAndSdmateriallistWithPageNumber(sdandsdmateriallist, pageSize, projectId, moduleId, sdTypeLUId, materialCategoryId, drawingId, sdName, company);
        //}

        //public SdAndSdmateriallistDTO SaveSdAndSdmateriallist(SdAndSdmateriallistDTO sdandsdmateriallist)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSdAndSdmateriallist(sdandsdmateriallist);
        //}

        //public SdAndSdmateriallistDTO JsonSaveSdAndSdmateriallist(SdAndSdmateriallistDTO sdandsdmateriallist)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonWriter()).SaveSdAndSdmateriallist(sdandsdmateriallist);
        //}
        
        //public void RemoveCalendar(int p6CalendarID)
        //{
        //    (new Element.Reveal.Server.BALC.CommonWriter()).RemoveCalendar(p6CalendarID);
        //}

        //public void JsonRemoveCalendar(string p6CalendarID)
        //{
        //    (new Element.Reveal.Server.BALC.CommonWriter()).RemoveCalendar(Int32.Parse(p6CalendarID));
        //}

        //#endregion "End Save"

        //#region "PanelBar Data"

        //public List<ComboBoxDTO> GetCWPByProject_PanelBar(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCWPByProject_PanelBar(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetCWPByProject_PanelBar(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCWPByProject_PanelBar(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //#endregion "PanelBar Data"

        ////Arranged by Hoon in order of Relavance and Name
        //#region "ComboBox Data"

        //public List<ComboBoxDTO> GetComponentProgressTimesheetUncompleted_Combo(int cwpId, int materialcategoryId, int fiwpId, int projectId, int moduleId, DateTime workDate, int ruleofcreditweightId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetComponentProgressTimesheetUncompleted_Combo(cwpId, materialcategoryId, fiwpId, projectId, moduleId, workDate, ruleofcreditweightId);
        //}

        //public List<ComboBoxDTO> JsonGetComponentProgressTimesheetUncompleted_Combo(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetComponentProgressTimesheetUncompleted_Combo(Int32.Parse(cwpId), Int32.Parse(materialcategoryId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(moduleId), DateTime.Parse(workDate), Int32.Parse(ruleofcreditweightId));
        //}

        //public List<ComboBoxDTO> GetCostCodeByProject_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCostCodeByProject_Combo(projectId, moduleId);
        //}

        public List<ComboBoxDTO> JsonGetCostCodeByProject_Combo(string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetCostCodeByProject_Combo(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<ComboBoxDTO> GetWorkDateByProject_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetWorkDateByProject_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetWorkDateByProject_Combo(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetWorkDateByProject_Combo(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetTimeSheetByWorkDate_Combo(int projectId, int moduleId, DateTime workDate)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTimeSheetByWorkDate_Combo(projectId, moduleId, workDate);
        //}

        //public List<ComboBoxDTO> JsonGetTimeSheetByWorkDate_Combo(string projectId, string disciplineCode, string workDate)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTimeSheetByWorkDate_Combo(Int32.Parse(projectId), Int32.Parse(moduleId), DateTime.Parse(workDate));
        //}

        //public List<ComboBoxDTO> GetLibPipeMaterailGrp_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLibPipeMaterailGrp_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetLibPipeMaterailGrp_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLibPipeMaterailGrp_Combo();
        //}
        //public List<LoopDTO> GetLoop_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLoop_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> GetCWPByProject_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCWPByProject_Combo(projectId, moduleId);
        //}

        public List<ComboBoxDTO> JsonGetCWPByProject_Combo_Mobile(string projectId, string disciplineCode, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetCWPByProject_Combo_Mobile(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.RemoveJsonParameterWrapper(userId));
        }

        public List<ComboCodeBoxDTO> JsonGetCWPByProject_Combo(string projectId, string disciplineCode, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetCWPByProject_Combo(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.RemoveJsonParameterWrapper(userId));
        }

        //public List<ComboBoxDTO> GetPlant_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetPlant_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetPlant_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetPlant_Combo();
        //}

        //public List<ComboBoxDTO> GetCompany_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompany_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetCompany_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCompany_Combo();
        //}

        //public List<ComboBoxDTO> GetCWPAssignedFIWPByProject_Combo(int materialcategoryId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCWPAssignedFIWPByProject_Combo(materialcategoryId, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetCWPAssignedFIWPByProject_Combo(string materialcategoryId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCWPAssignedFIWPByProject_Combo(Int32.Parse(materialcategoryId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetDrawingAll_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingAll_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetDrawingAll_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingAll_Combo();
        //}

        //public List<ComboBoxDTO> GetComponentIsoLineNo_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetComponentIsoLineNo_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> GetDrawingByCWP_Combo(int cwpId, int materialCategoryId, string engTagNumber, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingByCWPProject_Combo(cwpId, materialCategoryId, Helper.RemoveJsonParameterWrapper(engTagNumber), projectId, moduleId, Helper.GetImageLocationURL());
        //}

        public List<ComboBoxDTO> JsonGetDrawingByCWP_Combo(string cwpId, string taskcategoryId, string engTagNumber, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetDrawingByCWPProject_Combo(Int32.Parse(cwpId), Int32.Parse(taskcategoryId), Helper.RemoveJsonParameterWrapper(engTagNumber), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        }

        //public List<ComboBoxDTO> GetDrawingByCWPProjectschedule_Combo(int cwpId, int projectscheduleId, string engTagNumber, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingByCWPProjectschedule_Combo(cwpId, projectscheduleId, Helper.RemoveJsonParameterWrapper(engTagNumber), projectId, moduleId, Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> JsonGetDrawingByCWPProjectschedule_Combo(string cwpId, string projectscheduleId, string engTagNumber, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingByCWPProjectschedule_Combo(Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Helper.RemoveJsonParameterWrapper(engTagNumber), Int32.Parse(projectId), Int32.Parse(moduleId), Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> GetDrawingByProjectSchedule_Combo(int projectScheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingByProjectSchedule_Combo(projectScheduleId);
        //}

        //public List<ComboBoxDTO> JsonGetDrawingByProjectSchedule_Combo(string projectScheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingByProjectSchedule_Combo(Int32.Parse(projectScheduleId));
        //}

        //public List<ComboBoxDTO> GetDrawingTagByProjectID_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingTagByProjectID_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetDrawingTagByProjectID_Combo(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingTagByProjectID_Combo(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetReferenceDrawingByTagNo_Combo(string engTag, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetReferenceDrawingByTagNo_Combo(engTag, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetReferenceDrawingByTagNo_Combo(string engTag, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetReferenceDrawingByTagNo_Combo(engTag, Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetReferenceDrawingByQaqcformTemplate_Combo(int fiwpId, string engTag, int qaqcformTemplateId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetReferenceDrawingByQaqcformTemplate_Combo(fiwpId, engTag, qaqcformTemplateId);
        //}

        //public List<ComboBoxDTO> JsonGetReferenceDrawingByQaqcformTemplate_Combo(string fiwpId, string engTag, string qaqcformTemplateId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetReferenceDrawingByQaqcformTemplate_Combo(Int32.Parse(fiwpId), engTag, Int32.Parse(qaqcformTemplateId));
        //}

        //public List<ComboBoxDTO> GetFIWPCrewByFIWP_Combo(int projectScheduleId, int fiwpId, DateTime startDate, DateTime endDate, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPCrewByFIWP_Combo(projectScheduleId, fiwpId, startDate, endDate, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetFIWPCrewByFIWP_Combo(string projectScheduleId, string fiwpId, string startDate, string endDate, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPCrewByFIWP_Combo(Int32.Parse(projectScheduleId), Int32.Parse(fiwpId), DateTime.Parse(startDate), DateTime.Parse(endDate), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetManhourRateByLevel(int level, int parentlevelId, int levelId, int projectId, int moduleId)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ReportReader()).GetManhourRateByLevel(level, parentlevelId, levelId, projectId, moduleId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<ComboBoxDTO> JsonGetManhourRateByLevel(string level, string parentlevelId, string levelId, string projectId, string disciplineCode)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ReportReader()).GetManhourRateByLevel(Int32.Parse(level), Int32.Parse(parentlevelId), Int32.Parse(levelId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<ComboBoxDTO> GetFIWPByProject_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByProject_Combo(projectId, moduleId);
        //}

        public List<ComboCodeBoxDTO> JsonGetFIWPByProject_Combo(string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetFIWPByProject_Combo(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public DataTable GetProgressTimesheetByProjectID_Combo(int cwpId, int materialcategoryId, int fiwpId, int projectId, int moduleId, DateTime workdate)
        //{
        //    System.Data.DataTable table = new System.Data.DataTable();
        //    table.TableName = "ProgressTimesheet";
        //    table.Columns.Add("Employee Name");

        //    List<ComboBoxDTO> results = (new Element.Reveal.Server.BALC.CommonReader()).GetProgressTimesheetByProjectID_Combo(cwpId, materialcategoryId, fiwpId, projectId, moduleId, workdate);
        //    List<TaskcategoryDTO> tasks = GetTaskcategoryByMaterialCategory(moduleId, materialcategoryId);

        //    try
        //    {
        //        var joins = results.GroupJoin(tasks, x => Convert.ToInt32(x.ExtraValue2), y => y.TaskCategoryID, (x, g) =>
        //        new { x, g }).SelectMany(y => y.g.DefaultIfEmpty(), (item, y) =>
        //        new { item.x.DataID, item.x.DataName, item.x.ExtraValue1, item.x.ExtraValue2, y.Description });

        //        foreach (string column in tasks.GroupBy(g => g.Description).Select(x => x.Key))
        //            table.Columns.Add(column);

        //        foreach (var item in joins)
        //        {
        //            System.Data.DataRow row = table.NewRow();
        //            row.BeginEdit();
        //            row[0] = item.DataName;
        //            row[item.Description] = Convert.ToDecimal(item.ExtraValue1);
        //            row.EndEdit();
        //            table.Rows.Add(row);
        //        }
        //    }
        //    catch { }

        //    return table;
        //}

        //public DataTable JsonGetProgressTimesheetByProjectID_Combo(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workdate)
        //{
        //    System.Data.DataTable table = new System.Data.DataTable();
        //    table.TableName = "ProgressTimesheet";
        //    table.Columns.Add("Employee Name");

        //    List<ComboBoxDTO> results = (new Element.Reveal.Server.BALC.CommonReader()).GetProgressTimesheetByProjectID_Combo(Int32.Parse(cwpId), Int32.Parse(materialcategoryId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(moduleId), DateTime.Parse(workdate));
        //    List<TaskcategoryDTO> tasks = GetTaskcategoryByMaterialCategory(Int32.Parse(moduleId), Int32.Parse(materialcategoryId));

        //    try
        //    {
        //        var joins = results.GroupJoin(tasks, x => Convert.ToInt32(x.ExtraValue2), y => y.TaskCategoryID, (x, g) =>
        //        new { x, g }).SelectMany(y => y.g.DefaultIfEmpty(), (item, y) =>
        //        new { item.x.DataID, item.x.DataName, item.x.ExtraValue1, item.x.ExtraValue2, y.Description });

        //        foreach (string column in tasks.GroupBy(g => g.Description).Select(x => x.Key))
        //            table.Columns.Add(column);

        //        foreach (var item in joins)
        //        {
        //            System.Data.DataRow row = table.NewRow();
        //            row.BeginEdit();
        //            row[0] = item.DataName;
        //            row[item.Description] = Convert.ToDecimal(item.ExtraValue1);
        //            row.EndEdit();
        //            table.Rows.Add(row);
        //        }
        //    }
        //    catch { }

        //    return table;
        //}

        //public List<ComboBoxDTO> GetProjectScheduleByProject_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectScheduleByProject_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetProjectScheduleByProject_Combo(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectScheduleByProject_Combo(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetProjectScheduleByCwp_Combo(int cwpId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectScheduleByCwp_Combo(cwpId, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetProjectScheduleByCwp_Combo(string cwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectScheduleByCwp_Combo(Int32.Parse(cwpId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetProjectScheduleByCwpWithFiwp_Combo(int cwpId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectScheduleByCwpWithFiwp_Combo(cwpId, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> GetQaqcDrawingsByComponent_Combo(int componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetQaqcDrawingsByComponent_Combo(componentId);
        //}

        //public List<ComboBoxDTO> JsonGetQaqcDrawingsByComponent_Combo(string componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetQaqcDrawingsByComponent_Combo(Int32.Parse(componentId));
        //}

        //public List<ComboBoxDTO> GetSubmittedQaqcformByFiwp(int fiwpId, string qaaqctemplate, int systemId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetQaqcformByFiwp(fiwpId, qaaqctemplate, systemId, projectId, moduleId, 1, Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> JsonGetSubmittedQaqcformByFiwp(string fiwpId, string qaaqctemplate, string systemId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetQaqcformByFiwp(Int32.Parse(fiwpId), qaaqctemplate, Int32.Parse(systemId), Int32.Parse(projectId), Int32.Parse(moduleId), 1, Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> GetReelNoByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetReelNoByFIWPQaqc_Combo(fiwpId, qAQCFormTemplateID);
        //}

        //public List<ComboBoxDTO> JsonGetReelNoByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetReelNoByFIWPQaqc_Combo(Int32.Parse(fiwpId), Int32.Parse(qAQCFormTemplateID));
        //}

        //public List<ComboBoxDTO> GetRuleofCreditByMaterialCategory_Combo(int projectId, int moduleId, int materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRuleofCreditByMaterialCategory_Combo(projectId, moduleId, materialcategoryId);
        //}

        public List<ComboBoxDTO> JsonGetRuleofCreditByMaterialCategory_Combo(string projectId, string disciplineCode, string taskcategoryId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetRuleofCreditByMaterialCategory_Combo(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Int32.Parse(taskcategoryId));
        }

        //public List<ComboBoxDTO> GetScaffoldByCwp_Combo(int cwpId, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetScaffoldByCwp_Combo(cwpId, projectId);
        //}

        //public List<ComboBoxDTO> JsonGetScaffoldByCwp_Combo(string cwpId, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetScaffoldByCwp_Combo(Int32.Parse(cwpId), Int32.Parse(projectId));
        //}

        //public List<ComboBoxDTO> GetScaffoldRequestByCwp_Combo(int cwpId, int fiwpId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetScaffoldRequestByCwp_Combo(cwpId, fiwpId, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetScaffoldRequestByCwp_Combo(string cwpId, string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetScaffoldRequestByCwp_Combo(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetSDByModule_Combo(int moduleId, int materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSDByModule_Combo(moduleId, materialcategoryId);
        //}

        //public List<ComboBoxDTO> JsonGetSDByModule_Combo(string disciplineCode, string materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSDByModule_Combo(Int32.Parse(moduleId), Int32.Parse(materialcategoryId));
        //}

        //public List<ComboBoxDTO> GetSystemByProject_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSystemByProject_Combo(projectId, moduleId);
        //}

        public List<ComboBoxDTO> JsonGetSystemByProject_Combo(string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetSystemByProject_Combo(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<ComboBoxDTO> GetTagNoByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTagNoByFIWPQaqc_Combo(fiwpId, qAQCFormTemplateID);
        //}

        //public List<ComboBoxDTO> JsonGetTagNoByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTagNoByFIWPQaqc_Combo(Int32.Parse(fiwpId), Int32.Parse(qAQCFormTemplateID));
        //}

        //public List<ComboBoxDTO> GetEngTagNumberByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEngTagNumberByFIWPQaqc_Combo(fiwpId, qAQCFormTemplateID);
        //}

        //public List<ComboBoxDTO> JsonGetEngTagNumberByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEngTagNumberByFIWPQaqc_Combo(Int32.Parse(fiwpId), Int32.Parse(qAQCFormTemplateID));
        //}

        //public List<ComboBoxDTO> GetKeyValueByFIWPQaqc_Combo(int fiwpId, int qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetKeyValueByFIWPQaqc_Combo(fiwpId, qAQCFormTemplateID);
        //}

        //public List<ComboBoxDTO> JsonGetKeyValueByFIWPQaqc_Combo(string fiwpId, string qAQCFormTemplateID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetKeyValueByFIWPQaqc_Combo(Int32.Parse(fiwpId), Int32.Parse(qAQCFormTemplateID));
        //}

        //public List<ComboBoxDTO> GetSystemByFIWP_Combo(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSystemByFIWP_Combo(fiwpId);
        //}

        //public List<ComboBoxDTO> JsonGetSystemByFIWP_Combo(string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSystemByFIWP_Combo(Int32.Parse(fiwpId));
        //}

        //public List<ComboBoxDTO> GetDrawingByFIWP_Combo(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingByFIWP_Combo(fiwpId);
        //}

        //public List<ComboBoxDTO> JsonGetDrawingByFIWP_Combo(string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDrawingByFIWP_Combo(Int32.Parse(fiwpId));
        //}

        //public List<ComboBoxDTO> GetQAQCFormByQCTemplateSystemCWPFIWP_Combo(int qctemplateID, int cwpId, int fiwpId, int systemId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetQAQCFormByQCTemplateSystemCWPFIWP_Combo(qctemplateID, cwpId, fiwpId, systemId, projectId, moduleId, 0, "");
        //}

        //public List<ComboBoxDTO> JsonGetQAQCFormByQCTemplateSystemCWPFIWP_Combo(string qctemplateID, string cwpId, string fiwpId, string systemId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetQAQCFormByQCTemplateSystemCWPFIWP_Combo(Int32.Parse(qctemplateID), Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(systemId), Int32.Parse(projectId), Int32.Parse(moduleId), 0, "");
        //}

        //public List<ComboBoxDTO> GetMTOSearchGroup_Combo(int projectscheduleId, int projectId, int moduleId, string searchColumn, string tableName)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetMTOSearchGroupByProjectID_Combo(projectscheduleId, projectId, moduleId, searchColumn, tableName);
        //}

        //public List<ComboBoxDTO> JsonGetMTOSearchGroup_Combo(string projectscheduleId, string projectId, string disciplineCode, string searchColumn, string tableName)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetMTOSearchGroupByProjectID_Combo(Int32.Parse(projectscheduleId), Int32.Parse(projectId), Int32.Parse(moduleId), searchColumn, tableName);
        //}

        //public List<ComboBoxDTO> GetMaterialCategoryByModule_Combo(int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetMaterialCategoryByModule_Combo(moduleId);
        //}

        public List<ComboBoxDTO> JsonGetMaterialCategoryByModule_Combo(string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetMaterialCategoryByModule_Combo(Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<ComboBoxDTO> GetLibinsulpipemanhourForPaging_Combo(string dbname, int selectedPage, int pageSize, int selectoption, decimal pipesize)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLibinsulpipemanhourForPaging_Combo(dbname, selectedPage, pageSize, selectoption, pipesize);
        //}

        //public List<ComboBoxDTO> GetMaterialProcessSystem_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetMaterialProcessSystem_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> GetMaterialSize_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetMaterialSize_Combo(projectId, moduleId);
        //}

        //#region Person

        //public List<ComboBoxDTO> GetChildDepartStructure_Combo(int moduleId, int projectId, string parentDepartment)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetChildDepartStructure_Combo(moduleId, projectId, parentDepartment);
        //}

        //public List<ComboBoxDTO> JsonGetChildDepartStructure_Combo(string disciplineCode, string projectId, string parentDepartment)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetChildDepartStructure_Combo(Int32.Parse(moduleId), Int32.Parse(projectId), parentDepartment);
        //}

        //public List<ComboBoxDTO> GetCrewAndForemanByFiwp_Combo(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCrewAndForemanByFiwp_Combo(fiwpId);
        //}

        //public List<ComboBoxDTO> JsonGetCrewAndForemanByFiwp_Combo(string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCrewAndForemanByFiwp_Combo(Int32.Parse(fiwpId));
        //}

        //public List<ComboBoxDTO> GetCrewAndForemanByFiwpWorkDate_Combo(int fiwpId, int cwpId, int projectId, int moduleId, DateTime workDate)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCrewAndForemanByFiwpWorkDate_Combo(fiwpId, cwpId, projectId, moduleId, workDate);
        //}

        public List<ComboBoxDTO> JsonGetCrewAndForemanByFiwpWorkDate_Combo(string iwpId, string cwpId, string projectId, string disciplineCode, string workDate)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetCrewAndForemanByFiwpWorkDate_Combo(Int32.Parse(iwpId), Int32.Parse(cwpId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), DateTime.Parse(workDate));
        }

        //public List<ComboBoxDTO> GetAllPersonnelByCWPProject_Combo(int fiwpId, int cwpId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllPersonnelByCWPProject_Combo(fiwpId, cwpId, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetAllPersonnelByCWPProject_Combo(string fiwpId, string cwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetAllPersonnelByCWPProject_Combo(Int32.Parse(fiwpId), Int32.Parse(cwpId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetDFLByByProjectID_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDFLByByProjectID_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetDFLByByProjectID_Combo(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDFLByByProjectID_Combo(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        public List<ComboCodeBoxDTO> JsonGetSigmaUserSigmaRoleBySigmaRoleReportToReportToRoleProject(string roleTypeCode, string reportTo, string reportToRoleTypeCode, string projectId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetSigmaUserSigmaRoleBySigmaRoleReportToReportToRoleProject(Helper.RemoveJsonParameterWrapper(roleTypeCode), Helper.RemoveJsonParameterWrapper(reportTo), Helper.RemoveJsonParameterWrapper(reportToRoleTypeCode), Int32.Parse(projectId), Helper.GetWebrootUrl());
        }

        //public List<ComboBoxDTO> GetForemanByGeneralForeman_Combo(int departStructureID, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetForemanByGeneralForeman_Combo(departStructureID, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetForemanByGeneralForeman_Combo(string sigmaUserId, string sigmaRoleId, string projectId)
        //{
        //    return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetForemanByGeneralForeman_Combo(sigmaUserId, Int32.Parse(sigmaRoleId), Int32.Parse(projectId));
        //}

        //public List<ComboBoxDTO> GetForemanGeneralForemanNameByPersonnelDepartment_Combo(int personnelId, int departmentId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetForemanGeneralForemanNameByPersonnelDepartment_Combo(Helper.RemoveJsonParameterWrapper(personnelId), departmentId, projectId, moduleId);
        //}

        public List<ComboCodeBoxDTO> JsonGetForemanGeneralForemanNameByPersonnelDepartment_Combo(string personnelId, string departmentId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetForemanGeneralForemanNameByPersonnelDepartment_Combo(Helper.RemoveJsonParameterWrapper(personnelId), Int32.Parse(departmentId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<ComboBoxDTO> GetForemanByFIWP_Combo(int fiwpId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetForemanByFIWP_Combo(fiwpId, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetForemanByFIWP_Combo(string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetForemanByFIWP_Combo(Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetForemanByProjectID_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetForemanByProjectID_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetForemanByProjectID_Combo(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetForemanByProjectID_Combo(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetGeneralForemanByProject_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetGeneralForemanByProject_Combo(projectId, moduleId);
        //}

        //public List<ComboCodeBoxDTO> JsonGetGeneralForemanByProject_Combo(string projectId)
        //{
        //    return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetGeneralForemanByProject_Combo(Int32.Parse(projectId));
        //}

        //public List<ComboBoxDTO> GetGeneralForemanBySuperintendant_Combo(int projectId, int moduleId, int superintendantId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetGeneralForemanBySuperintendant_Combo(projectId, moduleId, superintendantId);
        //}

        //public List<ComboBoxDTO> JsonGetGeneralForemanBySuperintendant_Combo(string projectId, string disciplineCode, string superintendantId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetGeneralForemanBySuperintendant_Combo(Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(superintendantId));
        //}

        //public List<ComboBoxDTO> GetSuperintendantInPrjSchedule_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSuperintendantInPrjSchedule_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetSuperintendantInPrjSchedule_Combo(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSuperintendantInPrjSchedule_Combo(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //#endregion

        //#region FIWP
        //public List<ComboBoxDTO> GetFIWPByProjectSchedule_Combo(int projectScheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByProjectSchedule_Combo(projectScheduleId);
        //}

        public List<ComboBoxDTO> JsonGetFIWPByProjectSchedule_Combo(string scheduledWorkItemId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetFIWPByProjectSchedule_Combo(Int32.Parse(scheduledWorkItemId));
        }

        //public List<ComboBoxDTO> GetFIWPByProjectSchedulePackageType_Combo(int projectScheduleId, int packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByProjectSchedulePackageType_Combo(projectScheduleId, packagetypeLuid);
        //}

        public List<ComboBoxDTO> JsonGetFIWPByProjectSchedulePackageType_Combo(string scheduledWorkItemId, string packageTypeCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetFIWPByProjectSchedulePackageType_Combo(Int32.Parse(scheduledWorkItemId), Helper.RemoveJsonParameterWrapper(packageTypeCode));
        }

        //public List<ComboBoxDTO> GetFIWPByPersonnelDepartment_Combo(int projectId, int moduleId, int personnelId, int departmentId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByPersonnelDepartment_Combo(projectId, moduleId, Helper.RemoveJsonParameterWrapper(personnelId), departmentId);
        //}

        //public List<ComboBoxDTO> JsonGetFIWPByPersonnelDepartment_Combo(string projectId, string disciplineCode, string personnelId, string departmentId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByPersonnelDepartment_Combo(Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(Helper.RemoveJsonParameterWrapper(personnelId)), Int32.Parse(departmentId));
        //}

        //public List<ComboBoxDTO> GetFIWPByPersonnelDepartmentFiwpqaqc_Combo(int projectId, int moduleId, int personnelId, int departmentId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByPersonnelDepartmentFiwpqaqc_Combo(projectId, moduleId, Helper.RemoveJsonParameterWrapper(personnelId), departmentId);
        //}

        public List<ComboBoxDTO> JsonGetFIWPByPersonnelDepartmentFiwpqaqc_Combo(string projectId, string disciplineCode, string personnelId, string departmentId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetFIWPByPersonnelDepartmentFiwpqaqc_Combo(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.RemoveJsonParameterWrapper(personnelId), Int32.Parse(departmentId));
        }

        //public ExtSchedulerDTO GetFIWPByFIWP_ExtSch(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByFIWP_ExtSch(fiwpId);
        //}

        //public ExtSchedulerDTO JsonGetFIWPByFIWP_ExtSch(string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByFIWP_ExtSch(Int32.Parse(fiwpId));
        //}

        //public List<ExtSchedulerDTO> GetFIWPByProjectSchedule_ExtSch(int projectScheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByProjectSchedule_ExtSch(projectScheduleId);
        //}

        public List<ExtSchedulerDTO> JsonGetFIWPByProjectSchedule_ExtSch(string scheduledWorkItemId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetFIWPByProjectSchedule_ExtSch_Combo(Int32.Parse(scheduledWorkItemId));
        }

        //public List<ExtSchedulerDTO> GetFIWPByProjectSchedule_ExtSch_Mobile(int projectId, int moduleId, int cwpid)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByProjectSchedule_ExtSch_Mobile(projectId, moduleId, cwpid);
        //}

        //public List<ExtSchedulerDTO> GetFIWPByProjectSchedule_ExtSch_MobileHicharts(int projectId, int moduleId, int cwpid)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByProjectSchedule_ExtSch_MobileHicharts(projectId, moduleId, cwpid);
        //}

        //public List<ExtSchedulerDTO> GetProjectSchedule_Cwp_ExtSch(int cwpid, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectSchedule_Cwp_ExtSch(cwpid, projectId, moduleId);
        //}

        //public List<ExtSchedulerDTO> JsonGetProjectSchedule_Cwp_ExtSch(string cwpid, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectSchedule_Cwp_ExtSch(Int32.Parse(cwpid), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ExtSchedulerDTO> GetProjectSchedule_fiwp_Cwp_ExtSch(int cwpid, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectSchedule_fiwp_Cwp_ExtSch(cwpid, projectId, moduleId);
        //}

        //public List<ExtSchedulerDTO> JsonGetProjectSchedule_fiwp_Cwp_ExtSch(string cwpid, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetProjectSchedule_fiwp_Cwp_ExtSch(Int32.Parse(cwpid), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ExtSchedulerDTO> GetFiwpManPowerByProjectSchedule_ExtSch(int scheduleId, int fiwpId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFiwpManPowerByProjectSchedule_ExtSch(scheduleId, fiwpId, projectId, moduleId);
        //}

        //public List<ExtSchedulerDTO> JsonGetFiwpManPowerByProjectSchedule_ExtSch(string scheduleId, string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFiwpManPowerByProjectSchedule_ExtSch(Int32.Parse(scheduleId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetFIWPByCwp_Combo(int cwpId, int materialcategoryId, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByCwp_Combo(cwpId, materialcategoryId, projectId, moduleId);
        //}

        public List<ComboBoxDTO> JsonGetFIWPByCwp_Combo(string cwpId, string taskcategoryId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetFIWPByCwp_Combo(Int32.Parse(cwpId), Int32.Parse(taskcategoryId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<ComboBoxDTO> GetFIWPByPackageType_Combo(int projectId, int moduleId, int packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByPackageType_Combo(projectId, moduleId, packagetypeLuid);
        //}

        //public List<ComboBoxDTO> JsonGetFIWPByPackageType_Combo(string projectId, string disciplineCode, string packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByPackageType_Combo(Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(packagetypeLuid));
        //}

        //public List<ComboBoxDTO> GetTagNumberByComponent_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTagNumberByComponent_Combo(projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetTagNumberByComponent_Combo(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTagNumberByComponent_Combo(Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //public List<ComboBoxDTO> GetDocumentByFIWP_Combo(int projectId, int moduleId, int cwpId, int fiwpId, int DocumentTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDocumentByFIWP_Combo(projectId, moduleId, cwpId, fiwpId, DocumentTypeLUID);
        //}

        //public List<ComboBoxDTO> JsonGetDocumentByFIWP_Combo(string projectId, string disciplineCode, string cwpId, string fiwpId, string DocumentTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetDocumentByFIWP_Combo(Int32.Parse(projectId), Int32.Parse(moduleId), Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(DocumentTypeLUID));
        //}

        //public List<ComboBoxDTO> GetFIWPByMaterialCategoryType_Combo(string type, int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByMaterialCategoryType_Combo(type, projectId, moduleId);
        //}

        //public List<ComboBoxDTO> JsonGetFIWPByMaterialCategoryType_Combo(string type, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFIWPByMaterialCategoryType_Combo(type, Int32.Parse(projectId), Int32.Parse(moduleId));
        //}

        //#endregion

        //#region LookupType

        //public List<ComboBoxDTO> GetLookupByLookupType_Combo(string lookuptype, string lookupsubtype)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLookupByLookupType_Combo(lookuptype, lookupsubtype);
        //}

        public List<ComboCodeBoxDTO> JsonGetLookupByLookupType_Combo(string lookuptype, string lookupsubtype)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetSigmaCodeByCodeCategory_Combo(Helper.RemoveJsonParameterWrapper(lookuptype), Helper.RemoveJsonParameterWrapper(lookupsubtype));
        }

        //JsonGetLookupByLookupType_Combo 과 동일함, 차후 JsonGetLookupByLookupType_Combo 삭제예정
        public List<ComboCodeBoxDTO> JsonGetSigmaCodeByCodeCategory_Combo(string codeCategory, string subCodeCategory)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetSigmaCodeByCodeCategory_Combo(Helper.RemoveJsonParameterWrapper(codeCategory), Helper.RemoveJsonParameterWrapper(subCodeCategory));
        }

        //public List<ComboBoxDTO> GetUserlookupByLookupType_Combo(string lookuptype, string lookupsubtype)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByLookupType_Combo(lookuptype, lookupsubtype);
        //}

        //public List<ComboBoxDTO> JsonGetUserlookupByLookupType_Combo(string lookuptype, string lookupsubtype)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUserlookupByLookupType_Combo(lookuptype, lookupsubtype);
        //}

        //public List<ComboBoxDTO> GetCableType1_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCableType1_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetCableType1_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCableType1_Combo();
        //}

        //public List<ComboBoxDTO> GetCableType2_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCableType2_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetCableType2_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetCableType2_Combo();
        //}

        //public List<ComboBoxDTO> GetEquipType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEquipType_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetEquipType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetEquipType_Combo();
        //}

        //public List<ComboBoxDTO> GetFixtureType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFixtureType_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetFixtureType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetFixtureType_Combo();
        //}

        //public List<ComboBoxDTO> GetInstrCategory_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetInstrCategory_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetInstrCategory_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetInstrCategory_Combo();
        //}

        //public List<ComboBoxDTO> GetInstrType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetInstrType_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetInstrType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetInstrType_Combo();
        //}

        //public List<ComboBoxDTO> GetItemCode_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetItemCode_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetItemCode_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetItemCode_Combo();
        //}

        //public List<ComboBoxDTO> GetLightingType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLightingType_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetLightingType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetLightingType_Combo();
        //}

        //public List<ComboBoxDTO> GetRacewayClass_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayClass_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetRacewayClass_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayClass_Combo();
        //}

        //public List<ComboBoxDTO> GetRacewayLength_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayLength_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetRacewayLength_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayLength_Combo();
        //}

        //public List<ComboBoxDTO> GetRacewayType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayType_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetRacewayType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayType_Combo();
        //}

        //public List<ComboBoxDTO> GetRacewayWidth_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayWidth_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetRacewayWidth_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetRacewayWidth_Combo();
        //}

        //public List<ComboBoxDTO> GetSiderailDepth_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSiderailDepth_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetSiderailDepth_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSiderailDepth_Combo();
        //}

        //public List<ComboBoxDTO> GetSDType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSDType_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetSDType_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetSDType_Combo();
        //}

        //public List<ComboBoxDTO> GetUOM_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetUOM_Combo();
        //}

        public List<ComboCodeBoxDTO> JsonGetUOM_Combo()
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetUOM_Combo();
        }

        //public List<ComboBoxDTO> GetVendor_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetVendor_Combo();
        //}

        //public List<ComboBoxDTO> JsonGetVendor_Combo()
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetVendor_Combo();
        //}

        //public List<ComboBoxDTO> GetTaskTypeByMaterialCategoryForElectricalEstManhrsLibrary_Combo(int materialCategoryId, int divValue)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTaskTypeByMaterialCategoryForElectricalEstManhrsLibrary_Combo(materialCategoryId, divValue);
        //}

        //public List<ComboBoxDTO> JsonGetTaskTypeByMaterialCategoryForElectricalEstManhrsLibrary_Combo(string materialCategoryId, string divValue)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTaskTypeByMaterialCategoryForElectricalEstManhrsLibrary_Combo(Int32.Parse(materialCategoryId), Int32.Parse(divValue));
        //}

        //public List<ComboBoxDTO> GetVendorByMaterialCategoryForElectricalEstManhrsLibrary_Combo(int materialCategoryId, int divValue)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetVendorByMaterialCategoryForElectricalEstManhrsLibrary_Combo(materialCategoryId, divValue);
        //}

        //public List<ComboBoxDTO> JsonGetVendorByMaterialCategoryForElectricalEstManhrsLibrary_Combo(string materialCategoryId, string divValue)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetVendorByMaterialCategoryForElectricalEstManhrsLibrary_Combo(Int32.Parse(materialCategoryId), Int32.Parse(divValue));
        //}

        //#endregion


        //public List<ComboBoxDTO> GetTurnoverPackageByBinderPage_Combo(int projectId, int moduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.CommonReader()).GetTurnoverPackageByBinderPage_Combo(projectId, moduleId);
        //}

        public List<ComboBoxDTO> JsonGetTurnoverPackageByBinderPage_Combo(string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetTurnoverPackageByBinderPage_Combo(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //#endregion

        public UpfileDTOS JsonSaveUploadFile(UpfileDTOS upFileDS, string userId)
        {
            //string rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
            //return (new Element.Sigma.Web.Biz.TrueTask.Common()).JsonSaveUploadFile(upFileInfo, rootPath);
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).SaveSingleUploadFile(upFileDS, userId);
        }

        #region DataSync
        public List<DataSyncFileVersionInfoDTO> JsonSyncDownload(string apkVersion, string udID, string loginID, string dataVersion)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.DataSync()).SyncDownload(apkVersion, udID, loginID, Int32.Parse(dataVersion));
        }

        public SigmaResultTypeDTO JsonMultiUploadFileHistoryInfo(List<UploadFileHistoryInfoDTO> objList)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.DataSync()).MultiUploadFileHistoryInfo(objList);
        }

        public SigmaResultTypeDTO JsonAddUploadFileHistoryInfo(UploadFileHistoryInfoDTO anObj)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.DataSync()).AddUploadFileHistoryInfo(anObj);
        }

        public SigmaResultTypeDTO JsonAddDataSyncHistoryInfo(String FromFileVerSionId, String ToFileVerSionId, String MobileLoginId, String MobileUdId, String CreatedDate)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.DataSync()).AddDataSyncHistoryInfo(FromFileVerSionId, ToFileVerSionId, MobileLoginId, MobileUdId, CreatedDate);
        }

        public DataSyncZumeroInfoDTO JsonSyncZumero(string loginID)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.DataSync()).SyncZumero(loginID);
        }
        #endregion DataSync End

        #region uploadTest
        public void UploadTestByte(ByteTypeDTO drawing)
        {
            string fileName = drawing.DrawingName;
            byte[] fileBytes = drawing.DrawingFileByte;

            string uploadFolder = @"c:\testtmp\";

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string filePath = Path.Combine(uploadFolder, fileName);

            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            // Writes a block of bytes to this stream using data from
            // a byte array.
            fs.Write(fileBytes, 0, fileBytes.Length);

            // close file stream
            fs.Close();
        }

        public UpfileDTOS JsonSaveSingleUploadFileTest()
        {
            //string rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
            //return (new Element.Sigma.Web.Biz.TrueTask.Common()).JsonSaveUploadFile(upFileInfo, rootPath);
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).SaveSingleUploadFileTest();
        }
        #endregion uploadTest End

        public SigmaResultTypeDTO JsonUploadFileByPath(List<UploadFileDTO> objList)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).UploadFileByPath(objList);
        }

    }
}
