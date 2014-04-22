using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Element.Reveal.DataLibrary;

namespace Element.Sigma.Web.Service.Prev
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProjectService" in both code and config file together.
    [ServiceContract]
    public interface IProjectService
    {
        ////Arranged by Hoon in order of relavance and name to convenient indexing
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //AreaDTO GetAreaByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAreaByID/{id}")]
        //AreaDTO JsonGetAreaByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<AreaDTO> GetAreaAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAreaAll")]
        //List<AreaDTO> JsonGetAreaAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ComponentDTO GetComponentByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentByID/{id}")]
        //ComponentDTO JsonGetComponentByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentDTO> GetComponentByFiwp(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentByFiwp/{fiwpId}")]
        //List<ComponentDTO> JsonGetComponentByFiwp(string fiwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentDTO> GetComponentAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentAll")]
        //List<ComponentDTO> JsonGetComponentAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ComponentDTO GetComponentByComponentID(int componentid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentByComponentID/{componentid}")]
        //ComponentDTO JsonGetComponentByComponentID(string componentid);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentlogDTO> GetComponentlogByRFIID(int rfiid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentlogByRFIID/{rfiid}")]
        //List<ComponentlogDTO> JsonGetComponentlogByRFIID(string rfiid);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentDTO> GetComponentByCwpDrawing(int cwpId, int drawingId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentByCwpDrawing/{cwpId}/{drawingId}/{projectId}/{disciplineCode}")]
        //List<ComponentDTO> JsonGetComponentByCwpDrawing(string cwpId, string drawingId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentDTO> GetComponentForSystem(int cwpId, int materiacategoryId, int taskLUID, string engTagNum, string fromtoTag, bool isSystemEmpty);

        //[OperationContract][WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentForSystem/{cwpId}/{materiacategoryId}/{taskLUID}/{engTagNum}/{fromtoTag}/{isSystemEmpty}")]
        //List<ComponentDTO> JsonGetComponentForSystem(string cwpId, string materiacategoryId, string taskLUID, string engTagNum, string fromtoTag, string isSystemEmpty);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ComponentPageTotal GetComponentForSystemByLineForPaging(int projectid, string disciplineCode, string processsystem, string line, string size, int emptysystem, int selectpage, int pagesize);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ComponentPageTotal GetComponentForSystemByTaskForPaging(int projectid, string disciplineCode, int taskid, int drawingid, int systemid, int tasktypeid, int emptysystem, int selectpage, int pagesize);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectDTO> GetContractorProject(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetContractorProject/{projectId}")]
        //List<ProjectDTO> JsonGetContractorProject(string projectId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetUploadedFileInfoByProjectFileType/{projectId}/{fileTypeCode}/{fileCategory}")]
        List<DocumentDTO> JsonGetUploadedFileInfoByProjectFileType(string projectId, string fileTypeCode, string fileCategory);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetIwpDocumentByIwpProjectFileType/{iwpId}/{projectId}/{fileTypeCode}/{isDisplayable}/{fileCategory}/{iwpDocumentId}")]
        List<DocumentDTO> JsonGetIwpDocumentByIwpProjectFileType(string iwpId, string projectId, string fileTypeCode, string isDisplayable, string fileCategory, string iwpDocumentId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> GetDocumentForFIWPByDocType(int doctypeId, int fiwpId, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentForFIWPByDocType/{doctypeId}/{fiwpId}/{projectId}/{disciplineCode}")]
        List<DocumentDTO> JsonGetDocumentForFIWPByDocType(string doctypeId, string fiwpId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> GetDocumentByRFIID(int rfiId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentByRFIID/{rfiId}/{projectId}/{disciplineCode}")]
        //List<DocumentDTO> JsonGetDocumentByRFIID(string rfiId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> GetDocumentByTurnoverPackage(string lookupValue, int fiwpId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> GetDocumentByTurnoverPackageDocType(int doctypeId, int fiwpId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentByTurnoverPackageDocType/{doctypeId}/{fiwpId}/{projectId}/{disciplineCode}")]
        //List<DocumentDTO> JsonGetDocumentByTurnoverPackageDocType(string doctypeId, string fiwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> GetDocumentAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentAll")]
        //List<DocumentDTO> JsonGetDocumentAll();
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpDocument GetFIWPDocDrawingsByFIWP(int fiwpId, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPDocDrawingsByFIWP/{fiwpId}/{projectId}/{disciplineCode}")]
        DocumentAndDrawing JsonGetFIWPDocDrawingsByFIWP(string fiwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpDocument GetFIWPDocDrawingsBySIWP(int siwpId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPDocDrawingsBySIWP/{siwpId}/{projectId}/{disciplineCode}")]
        //FiwpDocument JsonGetFIWPDocDrawingsBySIWP(string siwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpDocument GetFIWPDocDrawingsByHydro(int hydroId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFIWPDocDrawingsByHydro/{hydroId}/{projectId}/{disciplineCode}")]
        //FiwpDocument JsonGetFIWPDocDrawingsByHydro(string hydroId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpDocument GetFIWPDocDrawingsByCSU(int fiwpId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCSUDocDrawingsByFIWP/{fiwpId}/{projectId}/{disciplineCode}")]
        //FiwpDocument JsonGetFIWPDocDrawingsByCSU(string fiwpId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DocumentnoteDTO GetSingleDocumentNoteByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSingleDocumentNoteByID/{Id}")]
        //DocumentnoteDTO JsonGetSingleDocumentNoteByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentnoteDTO> GetDocumentNoteByFiwpDocumentDrawing(int fiwpId, int documentId, int drawingId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentNoteByFiwpDocumentDrawing/{fiwpId}/{documentId}/{drawingId}/{projectId}/{disciplineCode}")]
        //List<DocumentnoteDTO> JsonGetDocumentNoteByFiwpDocumentDrawing(string fiwpId, string documentId, string drawingId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentnoteDTO> GetDocumentNoteBySPColletctionID(int SPCollectionID, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentNoteBySPColletctionID/{SPCollectionID}/{projectId}/{disciplineCode}")]
        //List<DocumentnoteDTO> JsonGetDocumentNoteBySPColletctionID(string SPCollectionID, string projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingStickyNoteByDrawing/{drawingId}/{projectId}/{disciplineCode}")]
        List<DrawingStickyNoteDTO> JsonGetDrawingStickyNoteByDrawing(string drawingId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpdocordinalDTO> GetFiwpDocordinalByFiwp(int projectscheduleId, int fiwpId, int projectId, string disciplineCode);
              
        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpDocordinalByFiwp/{projectscheduleId}/{fiwpId}/{projectId}/{disciplineCode}")]
        //List<FiwpdocordinalDTO> JsonGetFiwpDocordinalByFiwp(string projectscheduleId, string fiwpId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpwfpDTO> GetFiwpWFPByFIWP(int id, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpWFPByFIWP/{id}/{projectId}/{disciplineCode}")]
        //List<FiwpwfpDTO> JsonGetFiwpWFPByFIWP(string id, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpequipDTO> GetFiwpEquipByFIWP(int id, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpEquipByFIWP/{IwpId}")]
        List<FiwpequipDTO> JsonGetFiwpEquipByFIWP(string IwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmanonsiteDTO> GetFiwpManonsiteByForeman(int foremanStructureId, DateTime workdate);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpManonsiteByForeman/{foremanStructureId}/{workdate}")]
        //List<FiwpmanonsiteDTO> JsonGetFiwpManonsiteByForeman(string foremanStructureId, string workdate);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialDTO> GetMaterialAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialAll")]
        //List<MaterialDTO> JsonGetMaterialAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialDTO> GetMaterialByMaterialCategory(int materialcategoryId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialCableDTO> GetMaterialCableByMaterialCategory(int materialCategoryId, int cwpId, int drawingId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialCableByMaterialCategory/{materialCategoryId}/{cwpId}/{drawingId}/{projectId}/{disciplineCode}")]
        //List<MaterialCableDTO> JsonGetMaterialCableByMaterialCategory(string materialCategoryId, string cwpId, string drawingId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialCableDTO> GetMaterialCableByAny(int cwpId, int fiwpId, int projectId, string disciplineCode, string filterName, string filterValue);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialCableByAny/{cwpId}/{fiwpId}/{projectId}/{disciplineCode}/{filterName}/{filterValue}")]
        //List<MaterialCableDTO> JsonGetMaterialCableByAny(string cwpId, string fiwpId, string projectId, string disciplineCode, string filterName, string filterValue);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialRacewayDTO> GetMaterialRacewayByMaterialCategory(int materialCategoryId, int cwpId, int drawingId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialRacewayByMaterialCategory/{materialCategoryId}/{cwpId}/{drawingId}/{projectId}/{disciplineCode}")]
        //List<MaterialRacewayDTO> JsonGetMaterialRacewayByMaterialCategory(string materialCategoryId, string cwpId, string drawingId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialDTO> GetMaterialCommonByMaterialCategory(int materialCategoryId, int cwpId, int drawingId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialCommonByMaterialCategory/{materialCategoryId}/{cwpId}/{drawingId}/{projectId}/{disciplineCode}")]
        //List<MaterialDTO> JsonGetMaterialCommonByMaterialCategory(string materialCategoryId, string cwpId, string drawingId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MaterialCableDTO GetMaterialCableByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialCableByID/{id}")]
        //MaterialCableDTO JsonGetMaterialCableByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MaterialDTO GetMaterialByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialByID/{id}")]
        //MaterialDTO JsonGetMaterialByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MaterialDTO GetMaterialByComponentID(int componentId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialByComponentID/{componentId}")]
        //MaterialDTO JsonGetMaterialByComponentID(string componentId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<PlantDTO> GetPlantAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetPlantAll")]
        //List<PlantDTO> JsonGetPlantAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectDTO GetProjectById(int id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectById/{id}")]
        ProjectDTO JsonGetProjectById(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectAndModule GetProjectAndModulesById(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectAndModulesById/{id}")]
        //ProjectAndModule JsonGetProjectAndModulesById(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectmoduleDTO> GetProjectAllModule();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectmoduleDTO> GetAllProjectAndModules();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectAllModule")]
        List<ProjectmoduleDTO> JsonGetProjectAllModule();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectmoduleDTO> GetProjectModuleByProjectID(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectModuleByProjectID/{projectId}")]
        //List<ProjectmoduleDTO> JsonGetProjectModuleByProjectID(string projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectModuleByProjectIDLoginID/{projectId}/{logindId}")]
        //List<ProjectmoduleDTO> JsonGetProjectModuleByProjectIDLoginID(string projectId, string logindId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectDTO> GetProjectAll();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectAll")]
        List<ProjectDTO> JsonGetProjectAll();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectBySigmauser/{sigmaUserId}")]
        List<ProjectDTO> JsonGetProjectBySigmauser(string sigmaUserId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<WeatherDTO> GetWeatherByProject(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetWeatherByProject/{projectId}")]
        //List<WeatherDTO> JsonGetWeatherByProject(string projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectDTO GetProjectSPURLByProject(int projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string GetProjectIFCImagePathByProject(int projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string GetProjectImageURLByProject(int projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectWizard GetProjectWizardByProject(int projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodeDTO> GetCostcodeByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodeByID/{Id}")]
        //List<CostcodeDTO> JsonGetCostcodeByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodeDTO> GetCostCodeByCostCode(string CostCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodeDTO> GetCostcodeByProjectID(int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodeByProjectID/{projectId}/{disciplineCode}")]
        //List<CostcodeDTO> JsonGetCostcodeByProjectID(string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> GetCostcodeByProjectschedule(int projectId, int projectscheduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodeByProjectschedule/{projectId}/{projectscheduleId}")]
        //List<CostcodestructureDTO> JsonGetCostcodeByProjectschedule(string projectId, string projectscheduleId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodeDTO> GetCostcodeAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodeAll")]
        //List<CostcodeDTO> JsonGetCostcodeAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodelockedDTO> GetCostcodelockedByCwpCostcode(int cwpId, int costcodeId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodelockedByCwpCostcode/{cwpId}/{costcodeId}")]
        //List<CostcodelockedDTO> JsonGetCostcodelockedByCwpCostcode(string cwpId, string costcodeId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodelockedDTO> GetCostcodelockedByCwpProgress(int cwpId, int progressId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodelockedByCwpProgress/{cwpId}/{progressId}")]
        //List<CostcodelockedDTO> JsonGetCostcodelockedByCwpProgress(string cwpId, string progressId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //CostcodestructureDTO GetCostcodestructureByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodestructureByID/{Id}")]
        //CostcodestructureDTO JsonGetCostcodestructureByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> GetCostcodestructureAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodestructureAll")]
        //List<CostcodestructureDTO> JsonGetCostcodestructureAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> GetProjectScheduleCostCodeByProjectID(int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleCostCodeByProjectID/{projectId}/{disciplineCode}")]
        //List<CostcodestructureDTO> JsonGetProjectScheduleCostCodeByProjectID(string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> GetCostcodestructureByCwpCostcode(int cwpId, int costcodeId, int projectId, int excludeLocked);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> GetProjectScheduleFiwpByCWPProjectID(int projectId, string disciplineCode, int cwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleFiwpByCWPProjectID/{projectId}/{disciplineCode}/{cwpId}")]
        //List<CostcodestructureDTO> JsonGetProjectScheduleFiwpByCWPProjectID(string projectId, string disciplineCode, string cwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //CostcodetaleDTO GetCostcodetaleByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodetaleByID/{Id}")]
        //CostcodetaleDTO JsonGetCostcodetaleByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodetaleDTO> GetCostcodetaleAll();
        
        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodetaleAll")]
        //List<CostcodetaleDTO> JsonGetCostcodetaleAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodetaleDTO> GetCostcodetaleByCostCodeID(int costcodeId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCostcodetaleByCostCodeID/{costcodeId}")]
        //List<CostcodetaleDTO> JsonGetCostcodetaleByCostCodeID(string costcodeId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwaDTO> GetCWAByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWAByID/{id}")]
        //List<CwaDTO> JsonGetCWAByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwaDTO> GetCWAByProjectID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWAByProjectID/{id}")]
        //List<CwaDTO> JsonGetCWAByProjectID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //CwpDTO GetCWPByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWPByID/{id}")]
        //CwpDTO JsonGetCWPByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwpDTO> GetCWPsByProjectID(int id, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCWPsByProjectID/{projectId}/{disciplineCode}/{userId}")]
        List<CwpDTO> JsonGetCWPsByProjectID(string projectId, string disciplineCode, string userId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwpDTO> GetCwpByProject(int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCwpByProject/{projectId}/{disciplineCode}")]
        //List<CwpDTO> JsonGetCwpByProject(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwpDTO> GetCwpByProjectPackageType(int projectId, string disciplineCode, int packagetypeLuid);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCwpByProjectPackageType/{projectId}/{disciplineCode}/{packagetypeCode}/{userId}")]
        List<CwpDTO> JsonGetCwpByProjectPackageType(string projectId, string disciplineCode, string packagetypeCode, string userId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwpDTO> GetCWPsByCWAID(int cwaId);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectcostcodeDTO> GetProjectCostCodeManHoursByProjectId(int id, string disciplineCode, int cwpid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectCostCodeManHoursByProjectId/{id}/{disciplineCode}/{cwpid}")]
        //List<ProjectcostcodeDTO> JsonGetProjectCostCodeManHoursByProjectId(string id, string disciplineCode, string cwpid);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string GetPivotViewerDrawingsURL(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetPivotViewerDrawingsURL/{id}")]
        //string JsonGetPivotViewerDrawingsURL(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingAll")]
        //List<DrawingDTO> JsonGetDrawingAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingDTO GetDrawingByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByID/{Id}")]
        //DrawingDTO JsonGetDrawingByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingsByProjectID(int Id, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingsByProjectID/{Id}/{disciplineCode}")]
        //List<DrawingDTO> JsonGetDrawingsByProjectID(string Id, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingDTO GetDrawingByDrawingName(string drawingName, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByDrawingName/{drawingName}/{projectId}/{disciplineCode}")]
        //DrawingDTO JsonGetDrawingByDrawingName(string drawingName, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingByDrawingType(int drawingTypeLuid, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByDrawingType/{drawingTypeLuid}/{projectId}/{disciplineCode}")]
        //List<DrawingDTO> JsonGetDrawingByDrawingType(string drawingTypeLuid, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> GetDrawingByDrawingType_Combo(int drawingTypeLuid, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByDrawingType_Combo/{drawingTypeLuid}/{projectId}/{disciplineCode}")]
        //List<ComboBoxDTO> JsonGetDrawingByDrawingType_Combo(string drawingTypeLuid, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingrevisionDTO> GetDrawingRevisionByProjectID(int Id, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingRevisionByProjectID/{Id}/{disciplineCode}")]
        //List<DrawingrevisionDTO> JsonGetDrawingRevisionByProjectID(string Id, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingrevisionDTO> GetDrawingrevisionByDrawing(int drawingId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingrevisionByDrawing/{drawingId}")]
        //List<DrawingrevisionDTO> JsonGetDrawingrevisionByDrawing(string drawingId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingrevisionDTO> GetDrawingrevisionByDrawingFileUrl(string drawingId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingrevisionByDrawingFileUrl/{drawingId}")]
        //List<DrawingrevisionDTO> JsonGetDrawingrevisionByDrawingFileUrl(string drawingId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingByCWP(int cwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByCWP/{cwpId}")]
        //List<DrawingDTO> JsonGetDrawingByCWP(string cwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingByRFIId(int projectid, string disciplineCode, int rfiid);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingByCWP_DrawingName(int cwpId, string strSearch);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByCWP/{cwpId}/{strSearch}")]
        //List<DrawingDTO> JsonGetDrawingByCWP_DrawingName(string cwpId, string strSearch);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingPageTotal GetDrawingByCWP_DrawingNameForPaging(int cwpId, string strSearch, int selectedPage, int pageSize);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByCWP_DrawingNameForPaging/{cwpId}/{strSearch}/{selectedPage}/{pageSize}")]
        //DrawingPageTotal JsonGetDrawingByCWP_DrawingNameForPaging(string cwpId, string strSearch, string selectedPage, string pageSize);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingsByFIWP(int fiwpId, int drawingtype);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingsByFIWP/{fiwpId}/{drawingtype}")]
        //List<DrawingDTO> JsonGetDrawingsByFIWP(string fiwpId, string drawingtype);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByIWP/{iwpId}/{projectId}/{displineCode}")]
        List<DrawingDTO> JsonGetDrawingByIwp(string iwpId, string projectId, string displineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetAllDrawingsByFIWP(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllDrawingsByFIWP/{fiwpId}")]
        //List<DrawingDTO> JsonGetAllDrawingsByFIWP(string fiwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingreferenceDTO> GetDrawingReferenceByDrawingID(int drawingId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingReferenceByDrawingID/{drawingId}")]
        //List<DrawingreferenceDTO> JsonGetDrawingReferenceByDrawingID(string drawingId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingsdrefDTO> GetDrawingsdrefByDrawingID(int drawingId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingsdrefByDrawingID/{drawingId}")]
        //List<DrawingsdrefDTO> JsonGetDrawingsdrefByDrawingID(string drawingId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingcwpDTO> GetDrawingCWPByDrawingID(int drawingId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingCWPByDrawingID/{drawingId}")]
        //List<DrawingcwpDTO> JsonGetDrawingCWPByDrawingID(string drawingId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingcwpDTO> GetDrawingCWPByProject(int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingCWPByProject/{projectId}/{disciplineCode}")]
        //List<DrawingcwpDTO> JsonGetDrawingCWPByProject(string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TagnumberdrawingDTO> GetTagnumberdrawingByComponent(int componentId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTagnumberdrawingByComponent/{componentId}")]
        //List<TagnumberdrawingDTO> JsonGetTagnumberdrawingByComponent(string componentId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingPageTotal GetDrawingForDrawingViewer(string dbname, int projectId, List<int> cwpId, List<int> fiwpId, List<int> drawingtype, string engtag, string title, string sortOption, int currpage);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "JsonGetDrawingForDrawingViewer/{projectId}/{cwpIds}/{fiwpIds}/{drawingtypes}/{engtag}/{title}/{sortOption}/{currpage}/{pagesize}")]
        DrawingPageTotal JsonGetDrawingForDrawingViewer(string projectId, string cwpIds, string fiwpIds, string drawingtypes, string engtag, string title, string sortOption, string currpage, string pagesize);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingDTO GetDrawingBySPCollectionID(string dbname, int spcollectionId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "JsonGetDrawingBySPCollectionID/{spcollectionId}")]
        //DrawingDTO JsonGetDrawingBySPCollectionID(string spcollectionId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingBySPCollectionIDs(string dbname, int projectId, string disciplineCode, List<int> spcollectionId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "JsonGetDrawingBySPCollectionIDs/{projectId}/{disciplineCode}/{spcollectionId}")]
        //List<DrawingDTO> JsonGetDrawingBySPCollectionIDs(string projectId, string disciplineCode, string spcollectionId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SystemDTO> GetSystemByProjectID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSystemByProjectID/{id}")]
        //List<SystemDTO> JsonGetSystemByProjectID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SystemDTO> GetSystemByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSystemByID/{id}")]
        //List<SystemDTO> JsonGetSystemByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SystemDTO GetSingleSystemByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSingleSystemByID/{id}")]
        //SystemDTO JsonGetSingleSystemByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ScaffoldDTO GetScaffoldByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldByID/{id}")]
        //ScaffoldDTO JsonGetScaffoldByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ScaffoldrequestDTO> GetScaffoldRequestByProject(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldRequestByProject/{projectId}")]
        //List<ScaffoldrequestDTO> JsonGetScaffoldRequestByProject(string projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ScaffoldAndRequest GetScaffoldRequestByID(int scaffoldrequestId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldRequestByID/{scaffoldrequestId}")]
        //ScaffoldAndRequest JsonGetScaffoldRequestByID(string scaffoldrequestId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ScaffoldAndRequestDTO GetScaffoldAndrequestByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldAndrequestByID/{Id}")]
        //ScaffoldAndRequestDTO JsonGetScaffoldAndrequestByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ScaffoldrequestDTO GetScaffoldRequestByScaffold(int scaffoldId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldRequestByScaffold/{scaffoldId}")]
        //ScaffoldrequestDTO JsonGetScaffoldRequestByScaffold(string scaffoldId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ScaffoldtradeDTO> GetScaffoldtradeByScaffoldRequestID(int scaffoldrequestId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetScaffoldtradeByScaffoldRequestID/{scaffoldrequestId}")]
        //List<ScaffoldtradeDTO> JsonGetScaffoldtradeByScaffoldRequestID(string scaffoldrequestId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SigmacueDTO> GetSigmacueByPersonnel(int personnelId);
        
        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSigmacueByPersonnel/{personnelId}")]
        //List<SigmacueDTO> JsonGetSigmacueByPersonnel(string personnelId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> GetComponentProgressByCWPAndDrawing(int cwpId, int drawingId, int materialCategoryId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressByCWPAndDrawing/{cwpId}/{drawingId}/{materialCategoryId}/{projectId}/{disciplineCode}")]
        //List<ProgressDTO> JsonGetComponentProgressByCWPAndDrawing(string cwpId, string drawingId, string materialCategoryId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetComponentProgressByCWPAndMaterialCategoryID(int cwpId, int materialcategoryId, int progressId, int componentId, string engtag, int rfiId, int projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> GetProgressAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProgressAll")]
        //List<ProgressDTO> JsonGetProgressAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetProgressForCWPUpdating(int cwpId, int materialCategoryId, int taskCategoryId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProgressForCWPUpdating/{cwpId}/{materialCategoryId}/{taskCategoryId}/{projectId}/{disciplineCode}")]
        //List<MTODTO> JsonGetProgressForCWPUpdating(string cwpId, string materialCategoryId, string taskCategoryId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressForScheduling(int cwpId, int drawingId, int materialCategoryId, int taskCategoryId, int systemId, int typeLUId, string engTag, string searchcolumn, string searchvalue, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressForScheduling/{cwpId}/{drawingId}/{materialCategoryId}/{taskCategoryId}/{systemId}/{typeLUId}/{engTag}/{searchcolumn}/{searchvalue}/{projectId}/{disciplineCode}")]
        //MTOAndDrawing JsonGetComponentProgressForScheduling(string cwpId, string drawingId, string materialCategoryId, string taskCategoryId, string systemId, string typeLUId, string engTag, string searchcolumn, string searchvalue, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CollectionDTO> GetAvailableCollectionForScheduling(int cwpId, int projectscheduleId, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAvailableCollectionForScheduling/{cwpId}/{scheduledWorkItemId}/{projectId}/{disciplineCode}/{iwpId}")]
        List<CollectionDTO> JsonGetAvailableCollectionForScheduling(string cwpId, string scheduledWorkItemId, string projectId, string disciplineCode, string iwpId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CollectionDTO> GetAvailableCollectionForHydroScheduling(int cwpId, int projectscheduleId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAvailableCollectionForHydroScheduling/{cwpId}/{projectscheduleId}/{projectId}/{disciplineCode}")]
        //List<CollectionDTO> JsonGetAvailableCollectionForHydroScheduling(string cwpId, string projectscheduleId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CollectionDTO> GetAvailableCollectionForSchedulingApp(int cwpId, int projectscheduleId, int projectId, string disciplineCode);

        ////[OperationContract]
        ////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAvailableCollectionForSchedulingApp/{cwpId}/{projectscheduleId}/{projectId}/{disciplineCode}")]
        ////List<CollectionDTO> JsonGetAvailableCollectionForSchedulingApp(string cwpId, string projectscheduleId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressForFIWP(int cwpId, int projectscheduleId, int drawingId, int materialCategoryId, int taskCategoryId, int systemId, int typeLUId, string engTag, string searchcolumn, string searchvalue, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressForFIWP/{cwpId}/{projectscheduleId}/{drawingId}/{materialCategoryId}/{taskCategoryId}/{systemId}/{typeLUId}/{engTag}/{searchcolumn}/{searchvalue}/{projectId}/{disciplineCode}")]
        //MTOAndDrawing JsonGetComponentProgressForFIWP(string cwpId, string projectscheduleId, string drawingId, string materialCategoryId, string taskCategoryId, string systemId, string typeLUId, string engTag, string searchcolumn, string searchvalue, string projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressByIwpDrawing/{iwpId}/{drawingId}/{projectId}/{disciplineCode}")]
        List<TimeProgressInputDTO> JsonGetComponentProgressByIwpDrawing(string iwpId, string drawingId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressForSchedulingWithList(int cwpId, int drawingId,
        //                                                            List<int> materialCategoryIdList, List<int> taskCategoryIdList,
        //                                                            List<int> systemIdList, List<int> typeLUIdList,
        //                                                            List<int> drawingtypeLUIdList, List<int> costcodeIdList,
        //                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> compsearchstringList, 
        //                                                            List<ComboBoxDTO> locationList, List<string> rfinumberList,
        //                                                            string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "JsonGetComponentProgressForSchedulingWithList")]
        MTOAndDrawing JsonGetComponentProgressForSchedulingWithList( string cwpId
                                                                    ,string drawingId
                                                                    ,List<string> taskCategoryCodeList
                                                                    ,List<int> taskTypeIdList
                                                                    ,List<int> materialIdList
                                                                    ,List<int> progressIdList
                                                                    ,string searchValue
                                                                    ,string projectId
                                                                    ,string disciplineCode
                                                                    ,string grouppage);
        //MTOAndDrawing JsonGetComponentProgressForSchedulingWithList(string cwpId, string drawingId,
        //                                                            List<string> taskCategoryCodeList, List<int> taskCategoryIdList,
        //                                                            List<int> systemIdList, List<int> typeLUIdList,
        //                                                            List<int> drawingtypeLUIdList, List<int> costcodeIdList,
        //                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> compsearchstringList,
        //                                                            List<ComboBoxDTO> locationList, List<string> rfinumberList,
        //                                                            string searchcolumn, List<string> searchvalueList,
        //                                                            string projectId, string disciplineCode, string grouppage);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateSIWPProgressAssignmentByScope(ProgressAssignment progress, int startdrawingId, int enddrawingId, int startidfseq, int endidfseq,
        //                                                              List<int> withindrawingList, string userName, string password);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateHydroProgressAssignmentByStartPoint(ProgressAssignment progress, int drawingId, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressForHydroSchedulingWithList(int drawingId,
        //                                                            List<int> systemIdList, List<int> projectscheduleIdList, List<int> costcodeIdList,
        //                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> locationList,  string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressForHydroSchedulingWithListApps(int cwpId, int drawingId,
        //                                                            List<ComboBoxDTO> matrsearchstringList, List<ComboBoxDTO> matrsearchstringList2, List<ComboBoxDTO> compsearchstringList, List<ComboBoxDTO> pnidsearchstringList,
        //                                                            List<int> systemIdList, List<int> projectscheduleIdList, List<int> costcodeIdList,
        //                                                            List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressForHydroSchedulingAppWithList(int drawingId,
        //                                                            List<int> systemIdList, List<int> projectscheduleIdList, List<int> costcodeIdList, List<string> isolineIdList,
        //                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage);

        ////[OperationContract]
        ////[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "JsonGetComponentProgressForSchedulingAppWithList")]
        ////MTOAndDrawing JsonGetComponentProgressForSchedulingAppWithList(string drawingId,
        ////                                                            List<string> systemIdList, List<string> projectscheduleIdList, List<string> costcodeIdList, List<string> isolineIdList,
        ////                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        ////                                                            string projectId, string disciplineCode, string grouppage);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressForFIWPWithList(int cwpId,
        //                                                  int projectscheduleId, int drawingId,
        //                                                  List<int> materialCategoryIdList, List<int> taskCategoryIdList,
        //                                                  List<int> systemIdList, List<int> typeLUIdList,
        //                                                  List<int> drawingtypeLUIdList, List<int> costcodeIdList,
        //                                                  List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> compsearchstringList, 
        //                                                  List<ComboBoxDTO> locationList, List<string> rfinumberList,
        //                                                  string searchcolumn, List<string> searchvalueList,
        //                                                  int projectId, string disciplineCode, int grouppage);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "JsonGetComponentProgressForFIWPWithList")]
        MTOAndDrawing JsonGetComponentProgressForFIWPWithList(string cwpId,
                                                            string projectscheduleId, 
                                                            string drawingId,
                                                            List<string> taskCategoryCodeList,
                                                            List<int> taskTypeIdList,
                                                            List<int> materialIdList,
                                                            List<int> progressIdList,
                                                            string searchValue,
                                                            string projectId,
                                                            string disciplineCode,
                                                            string grouppage);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetComponentProgressByFIWP(int fiwpId, int projectScheduleID, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressByFIWP/{iwpId}/{scheduledWorkItemId}/{projectId}/{disciplineCode}")]
        List<MTODTO> JsonGetComponentProgressByFIWP(string iwpId, string scheduledWorkItemId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetComponentProgressBySIWP(int fiwpId, int projectScheduleID, int projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOAndDrawing GetComponentProgressByFIWPUncompleted(int cwpId, int materialcategoryId, int fiwpId, int projectId, string disciplineCode, DateTime workDate, int ruleofcreditweightId, List<int> drawingIds);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressByFIWPUncompleted/{cwpId}/{materialcategoryId}/{fiwpId}/{projectId}/{disciplineCode}/{workDate}/{ruleofcreditweightId}/{drawingIds}")]
        //MTOAndDrawing JsonGetComponentProgressByFIWPUncompleted(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId, string drawingIds);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetComponentProgressByFIWPPartialComplete(int cwpId, int materialcategoryId, int fiwpId, int projectId, string disciplineCode, DateTime workDate, int ruleofcreditweightId, int timeallocationId, int flag);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CollectionDTO> GetAvailableCollectionForForemanUncompleted(int personnelId, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetAvailableCollectionForForemanUncompleted_Combo/{personnelId}/{projectId}/{disciplineCode}")]
        List<ComboBoxDTO> JsonGetAvailableCollectionForForemanUncompleted_Combo(string personnelId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressByFIWPPartialComplete/{cwpId}/{materialcategoryId}/{fiwpId}/{projectId}/{disciplineCode}/{workDate}/{ruleofcreditweightId}/{timeallocationId}/{flag}")]
        //List<MTODTO> JsonGetComponentProgressByFIWPPartialComplete(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId, string timeallocationId, string flag);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetComponentProgressByFIWPDone(int cwpId, int materialcategoryId, int fiwpId, int projectId, string disciplineCode, DateTime workDate, int ruleofcreditweightId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentProgressByFIWPDone/{cwpId}/{materialcategoryId}/{fiwpId}/{projectId}/{disciplineCode}/{workDate}/{ruleofcreditweightId}")]
        //List<MTODTO> JsonGetComponentProgressByFIWPDone(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOPageTotal GetFileuploadForMTO(int cwpId, int fileId, int projectId, string disciplineCode, int selectedPage, int pageSize);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFileuploadForMTO/{cwpId}/{fileId}/{projectId}/{disciplineCode}/{selectedPage}/{pageSize}")]
        //MTOPageTotal JsonGetFileuploadForMTO(string cwpId, string fileId, string projectId, string disciplineCode, string selectedPage, string pageSize);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOPageTotal GetComponentForMTO(int cwpId, int drawigId, int materialCategoryId, int divValue, int taskCategoryId, int projectId, string disciplineCode, int selectedPage, int pageSize);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentForMTO/{cwpId}/{drawigId}/{materialCategoryId}/{divValue}/{taskCategoryId}/{projectId}/{disciplineCode}/{selectedPage}/{pageSize}")]
        //MTOPageTotal JsonGetComponentForMTO(string cwpId, string drawigId, string materialCategoryId, string divValue, string taskCategoryId, string projectId, string disciplineCode, string selectedPage, string pageSize);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //MTOPageTotal GetMaterialTakeOff(int cwpId, int drawigId, int materialCategoryId, int divValue, int taskCategoryId, int projectId, string disciplineCode, int selectedPage, int pageSize);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetMaterialTakeOff/{cwpId}/{drawigId}/{materialCategoryId}/{divValue}/{taskCategoryId}/{projectId}/{disciplineCode}/{selectedPage}/{pageSize}")]
        //MTOPageTotal JsonGetMaterialTakeOff(string cwpId, string drawigId, string materialCategoryId, string divValue, string taskCategoryId, string projectId, string disciplineCode, string selectedPage, string pageSize);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressDTO GetProgressById(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProgressById/{Id}")]
        //ProgressDTO JsonGetProgressById(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetProgressByComponentID(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> GetProgressByComponent(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> GetComponentByComponentForImport(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> GetProgressByProjectID(int projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> GetProgressByCostCode(int projectId, string disciplineCode, int costcodeId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> GetProgressByCostCodeForGrouping(int projectId, string disciplineCode, int cwpId, int costcodeId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> GetProgressByIds(string Ids);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProgressByIds/{Ids}")]
        //List<ProgressDTO> JsonGetProgressByIds(string Ids);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ComponentAndMaterial GetQAQCByFIWPReelNumber(int fiwpId, string reelNo, int qaqcFormTemplateId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProgressByIds/{fiwpId}/{reelNo}/{qaqcFormTemplateId}")]
        //ComponentAndMaterial JsonGetQAQCByFIWPReelNumber(string fiwpId, string reelNo, string qaqcFormTemplateId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ComponentAndMaterial GetQAQCByEngTag(int fiwpId, string engTag, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQAQCByEngTag/{fiwpId}/{engTag}/{projectId}/{disciplineCode}")]
        //ComponentAndMaterial JsonGetQAQCByEngTag(string fiwpId, string engTag, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ComponentAndMaterial GetQAQCByComponent(int componentId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQAQCByComponent/{componentId}")]
        //ComponentAndMaterial JsonGetQAQCByComponent(string componentId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibequipmanhourDTO> GetLibEquipManhour();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibEquipManhour")]
        //List<LibequipmanhourDTO> JsonGetLibEquipManhour();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibgroundingmanhourDTO> GetLibGroundingManhour();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibGroundingManhour")]
        //List<LibgroundingmanhourDTO> JsonGetLibGroundingManhour();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinstrmanhourDTO> GetLibInstrManhour();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibInstrManhour")]
        //List<LibinstrmanhourDTO> JsonGetLibInstrManhour();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LiblightingmanhourDTO> GetLibLightingManhour();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibLightingManhour")]
        //List<LiblightingmanhourDTO> JsonGetLibLightingManhour();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibracewaymanhourDTO> GetLibRacewayManhour();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibRacewayManhour")]
        //List<LibracewaymanhourDTO> JsonGetLibRacewayManhour();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibehtmanhourDTO> GetLibEhtManhour();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibEhtManhour")]
        //List<LibehtmanhourDTO> JsonGetLibEhtManhour();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibcablemanhourDTO> GetLibCableManhour();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibCableManhour")]
        //List<LibcablemanhourDTO> JsonGetLibCableManhour();

        ////LibInsul-------------------------------------------------------------
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulfactorDTO> GetLibinsulfactorAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulfactorDTO GetLibinsulfactorByID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulfactorDTO GetLibinsulfactorByFireProofID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulfactorPageTotal GetLibinsulfactorForPaging(int selectedPage, int pageSize, int ShapeLUID, int UOMLUID, int LibTypeLUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulfireproofDTO> GetLibinsulfireproofAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulfireproofDTO GetLibinsulfireproofByID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulpaintmanhourDTO> GetLibinsulpaintmanhourAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulpaintmanhourDTO GetLibinsulpaintmanhourByID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulpaintmanhourPageTotal GetLibinsulpaintmanhourForPaging(int selectedPage, int pageSize, int PaintLibTypeLUID, int TaskTypeLUID, int MaterialCategoryID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulpaintmanhourDTO> GetLibinsulpaintmanhourByNullmaterialcategory(int PaintLibTypeLUID, int TaskTypeLUID, int MaterialCategoryID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulpipefactorDTO> GetLibinsulpipefactorAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulpipefactorDTO GetLibinsulpipefactorByID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulpipefactorPageTotal GetLibinsulpipefactorForPaging(int selectedPage, int pageSize, int taskCategoryID, int materialCategoryID, int UOMLUID, int componentTypeLUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulpipemanhourDTO> GetLibinsulpipemanhourAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulpipemanhourDTO GetLibinsulpipemanhourByID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulpipemanhourDTO GetLibinsulpipemanhourBySize(decimal pipesize, int layer);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulpipemanhourPageTotal GetLibinsulpipemanhourForPaging(int selectedPage, int pageSize, int selectoption, decimal pipesize);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinsulfireproofPageTotal GetLibInsulFireProofForPaging(int selectedPage, int pageSize, int FireproofTypeLUID, string ComponentType);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulfactorDTO> GetLibinsulfactorForFireProof();

        ////--------------------------------------------------------------------------

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibequipmanhourDTO GetLibEquipManhourById(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibgroundingmanhourDTO GetLibGroundingManhourById(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinstrmanhourDTO GetLibInstrManhourById(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LiblightingmanhourDTO GetLibLightingManhourById(int Id);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibracewaymanhourDTO GetLibRacewayManhourById(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibehtmanhourDTO GetLibEhtManhourById(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibcablemanhourDTO GetLibCableManhourById(int Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibracewaymanhourPageTotal GetLibRacewayManhourForPaging(int selectedPage, int pageSize, string RacewayType, string PartNumber, string Vendor);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibRacewayManhourForPaging/{selectedPage}/{pageSize}/{RacewayType}/{PartNumber}/{Vendor}")]
        //LibracewaymanhourPageTotal JsonGetLibRacewayManhourForPaging(string selectedPage, string pageSize, string RacewayType, string PartNumber, string Vendor);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibcablemanhourPageTotal GetLibCableManhourForPaging(int selectedPage, int pageSize, string CableType, string PartNumber, string Vendor);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibCableManhourForPaging/{selectedPage}/{pageSize}/{CableType}/{PartNumber}/{Vendor}")]
        //LibcablemanhourPageTotal JsonGetLibCableManhourForPaging(string selectedPage, string pageSize, string CableType, string PartNumber, string Vendor);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LiblightingmanhourPageTotal GetLibLightingManhourForPaging(int selectedPage, int pageSize, string LightingType, string PartNumber, string Vendor);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibLightingManhourForPaging/{selectedPage}/{pageSize}/{LightingType}/{PartNumber}/{Vendor}")]
        //LiblightingmanhourPageTotal JsonGetLibLightingManhourForPaging(string selectedPage, string pageSize, string LightingType, string PartNumber, string Vendor);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibequipmanhourPageTotal GetLibEquipManhourForPaging(int selectedPage, int pageSize, string EquipType, string PartNumber, string Vendor);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibEquipManhourForPaging/{selectedPage}/{pageSize}/{EquipType}/{PartNumber}/{Vendor}")]
        //LibequipmanhourPageTotal JsonGetLibEquipManhourForPaging(string selectedPage, string pageSize, string EquipType, string PartNumber, string Vendor);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibgroundingmanhourPageTotal GetLibGroundingManhourForPaging(int selectedPage, int pageSize, string TaskType, string PartNumber, string Vendor);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibGroundingManhourForPaging/{selectedPage}/{pageSize}/{TaskType}/{PartNumber}/{Vendor}")]
        //LibgroundingmanhourPageTotal JsonGetLibGroundingManhourForPaging(string selectedPage, string pageSize, string TaskType, string PartNumber, string Vendor);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibinstrmanhourPageTotal GetLibInstrManhourForPaging(int selectedPage, int pageSize, string InstrType, string PartNumber, string Vendor);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibInstrManhourForPaging/{selectedPage}/{pageSize}/{InstrType}/{PartNumber}/{Vendor}")]
        //LibinstrmanhourPageTotal JsonGetLibInstrManhourForPaging(string selectedPage, string pageSize, string InstrType, string PartNumber, string Vendor);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibehtmanhourPageTotal GetLibEhtManhourForPaging(int selectedPage, int pageSize, string EHTType, string PartNumber, string Vendor);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibEhtManhourForPaging/{selectedPage}/{pageSize}/{EHTType}/{PartNumber}/{Vendor}")]
        //LibehtmanhourPageTotal JsonGetLibEhtManhourForPaging(string selectedPage, string pageSize, string EHTType, string PartNumber, string Vendor);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO GetQaqcformByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformByID/{id}")]
        //QaqcformDTO JsonGetQaqcformByID(string id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformDTO> GetQaqcformByComponentSystem(int ComponentId, int SystemId, int QAQCDataTypeLUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformtemplateDTO GetSignleQAQCFormTemplateByName(string templateName);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSignleQAQCFormTemplateByName/{templateName}")]
        //QaqcformtemplateDTO JsonGetSignleQAQCFormTemplateByName(string templateName);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformtemplateDTO> GetQaqcformtemplateByFiwpUnassigned(int formtype, int fiwpId, int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformtemplateByFiwpUnassigned/{formtype}/{fiwpId}/{projectId}")]
        //List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByFiwpUnassigned(string formtype, string fiwpId, string projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformtemplateDTO> GetQaqcformtemplateByFiwpIsQAQC(int cwpId, int fiwpId, int projectId, string disciplineCode, int doctypeId, int isQAQC);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformtemplateByFiwpIsQAQC/{cwpId}/{fiwpId}/{projectId}/{disciplineCode}/{doctypeId}/{isQAQC}")]
        //List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByFiwpIsQAQC(string cwpId, string fiwpId, string projectId, string disciplineCode, string doctypeId, string isQAQC);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformtemplateDTO> GetQaqcformtemplateByNameProject(string templateName, int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformtemplateByNameProject/{templateName}/{projectId}")]
        //List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByNameProject(string templateName, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformtemplateDTO> GetQaqcformtemplateByFormtypeNameProject(int formtype, string templateName, int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformtemplateByFormtypeNameProject/{formtype}/{templateName}/{projectId}")]
        //List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByFormtypeNameProject(string formtype, string templateName, string projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO GetQaqcformByQaqcComponent(int componentId, int qaqcFormTemplateId, int QAQCDataTypeLUID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformByQaqcComponent/{componentId}/{qaqcFormTemplateId}/{QAQCDataTypeLUID}")]
        //QaqcformDTO JsonGetQaqcformByQaqcComponent(string componentId, string qaqcFormTemplateId, string QAQCDataTypeLUID);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO GetQaqcformByReelNoFiwp(string reelNo, int fiwpId, int qaqcFormTemplateId, int QAQCDataTypeLUID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformByReelNoFiwp/{reelNo}/{fiwpId}/{qaqcFormTemplateId}/{QAQCDataTypeLUID}")]
        //QaqcformDTO JsonGetQaqcformByReelNoFiwp(string reelNo, string fiwpId, string qaqcFormTemplateId, string QAQCDataTypeLUID);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO GetQaqcformByEngTagNoFiwp(string engTag, int fiwpId, int qaqcFormTemplateId, int QAQCDataTypeLUID);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformByEngTagNoFiwp/{engTag}/{fiwpId}/{qaqcFormTemplateId}/{QAQCDataTypeLUID}")]
        //QaqcformDTO JsonGetQaqcformByEngTagNoFiwp(string engTag, string fiwpId, string qaqcFormTemplateId, string QAQCDataTypeLUID);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CalendarDTO> GetProjectCalendar(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectCalendar/{Id}")]
        //List<CalendarDTO> JsonGetProjectCalendar(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CalendarDTO> GetCalendarByProject(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCalendarByProject/{projectId}")]
        //List<CalendarDTO> JsonGetCalendarByProject(string projectId);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleAllByProjectID(int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleAllByProjectID/{projectId}/{disciplineCode}")]
        //List<ProjectscheduleDTO> JsonGetProjectScheduleAllByProjectID(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleAllByProjectIDModuleID(int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleAllByProjectIDModuleID/{projectId}/{disciplineCode}")]
        List<ProjectscheduleDTO> JsonGetProjectScheduleAllByProjectIDModuleID(string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleByProjectWithWBS(int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByProjectWithWBS/{projectId}/{disciplineCode}")]
        List<ProjectscheduleDTO> JsonGetProjectScheduleByProjectWithWBS(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectIDWithWBS(int cwpId, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByCwpProjectIDWithWBS/{cwpId}/{projectId}")]
        List<ProjectscheduleDTO> JsonGetProjectScheduleByCwpProjectIDWithWBS(string cwpId, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectWithWBS(int cwpId, int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByCwpProjectWithWBS/{cwpId}/{projectId}")]
        //List<ProjectscheduleDTO> JsonGetProjectScheduleByCwpProjectWithWBS(string cwpId, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectPackageTypeWithWBS(int cwpId, int projectId, int packagetypeLuid);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByCwpProjectPackageTypeWithWBS/{cwpId}/{projectId}/{packageTypeCode}")]
        List<ProjectscheduleDTO> JsonGetProjectScheduleByCwpProjectPackageTypeWithWBS(string cwpId, string projectId, string packageTypeCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleByProjectID(int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByProjectID/{projectId}/{disciplineCode}")]
        List<ProjectscheduleDTO> JsonGetProjectScheduleByProjectID(string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleByCWPProjectID(int cwpId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByCWPProjectID/{cwpId}/{projectId}/{disciplineCode}")]
        //List<ProjectscheduleDTO> JsonGetProjectScheduleByCWPProjectID(string cwpId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectscheduleDTO GetProjectScheduleByFIWPID(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByFIWPID/{fiwpId}")]
        //ProjectscheduleDTO JsonGetProjectScheduleByFIWPID(string fiwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectscheduleDTO GetSignleProjscheduleByID(int Id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSignleProjscheduleByID/{scheduledWorkItemId}")]
        ProjectscheduleDTO JsonGetSignleProjscheduleByID(string scheduledWorkItemId);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetProjectScheduleByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectScheduleByID/{Id}")]
        //List<ProjectscheduleDTO> JsonGetProjectScheduleByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> GetP6Project();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetP6Project")]
        //List<ProjectscheduleDTO> JsonGetP6Project();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //int CompareDateEnd(FiwpDTO fiwp);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> GetFiwpByProjectID(int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpByProjectID/{projectId}/{disciplineCode}")]
        //List<FiwpDTO> JsonGetFiwpByProjectID(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //bool CheckAssignedFIWP(int fiwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> GetFiwpByScheduleID(int scheduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpByScheduleID/{scheduleId}")]
        //List<FiwpDTO> JsonGetFiwpByScheduleID(string scheduleId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> GetFiwpByCwpSchedule(int cwpId, int projectScheduleId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpByCwpSchedule/{cwpId}/{projectScheduleId}")]
        //List<FiwpDTO> JsonGetFiwpByCwpSchedule(string cwpId, string projectScheduleId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> GetFiwpByCwpSchedulePackageType(int cwpId, int projectScheduleId, int packagetypeLuid);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpByCwpSchedulePackageType/{cwpId}/{scheduledWorkItemId}/{packageTypeCode}")]
        List<FiwpDTO> JsonGetFiwpByCwpSchedulePackageType(string cwpId, string scheduledWorkItemId, string packageTypeCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> GetFiwpByID(int Id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpByID/{iwpId}")]
        List<FiwpDTO> JsonGetFiwpByID(string iwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpDTO GetSingleFiwpByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSingleFiwpByID/{Id}")]
        //FiwpDTO JsonGetSingleFiwpByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> GetFiwpBySystemID(int SystemId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpBySystemID/{SystemId}")]
        //List<FiwpDTO> JsonGetFiwpBySystemID(string SystemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> GetFiwpBySystemPackageType(int projectId, int systemId, int packagetypeLuid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpBySystemPackageType/{projectId}/{systemId}/{packagetypeLuid}")]
        //List<FiwpDTO> JsonGetFiwpBySystemPackageType(string projectId, string systemId, string packagetypeLuid);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpDTO GetFiwpWithFiwpwfpByID(int fiwpId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpWithFiwpwfpByID/{fiwpId}/{projectId}/{disciplineCode}")]
        //FiwpDTO JsonGetFiwpWithFiwpwfpByID(string fiwpId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpworkflowDTO> GetFiwpworkflowByFiwp(int fiwpId, int isLatest);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpworkflowByFiwp/{fiwpId}/{isLatest}")]
        //List<FiwpworkflowDTO> JsonGetFiwpworkflowByFiwp(string fiwpId, string isLatest);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpworkflowDTO> GetFiwpworkflowByFiwpPersonnel(int fiwpId, int personnelId, int approvalStatus, int forApproval, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpworkflowByFiwpPersonnel/{fiwpId}/{personnelId}/{approvalStatus}/{forApproval}/{projectId}/{disciplineCode}")]
        //List<FiwpworkflowDTO> JsonGetFiwpworkflowByFiwpPersonnel(string fiwpId, string personnelId, string approvalStatus, string forApproval, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpworkflowDTO GetFiwpworkflowByID(int fiwpWPId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpworkflowByID/{fiwpWPId}")]
        //FiwpworkflowDTO JsonGetFiwpworkflowByID(string fiwpWPId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmanpowerDTO> GetFiwpManPowerByProjectScheduleID(int scheduleId, int fiwpId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpManPowerByProjectScheduleID/{scheduleId}/{fiwpId}/{projectId}/{disciplineCode}")]
        //List<FiwpmanpowerDTO> JsonGetFiwpManPowerByProjectScheduleID(string scheduleId, string fiwpId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpcommentDTO> GetFiwpcommentByFiwp(int fiwpId, DateTime workdate);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpcommentByFiwp/{fiwpId}/{workdate}")]
        //List<FiwpcommentDTO> JsonGetFiwpcommentByFiwp(string fiwpId, string workdate);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmaterialDTO> GetFiwpmaterialByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpmaterialByID/{id}")]
        //List<FiwpmaterialDTO> JsonGetFiwpmaterialByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmaterialDTO> GetFiwpMaterialByFIWP(int fiwpId, int projectId, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpMaterialByFIWP/{fiwpId}/{projectId}/{disciplineCode}")]
        List<FiwpmaterialDTO> JsonGetFiwpMaterialByFIWP(string fiwpId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmaterialDTO> GetFiwpmaterialAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpmaterialAll")]
        //List<FiwpmaterialDTO> JsonGetFiwpmaterialAll();
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //TimesheetDTO GetTimesheetByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByID/{id}")]
        //TimesheetDTO JsonGetTimesheetByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //TimeallocationDTO GetTimeallocationByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimeallocationByID/{id}")]
        //TimeallocationDTO JsonGetTimeallocationByID(string id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimesheetAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetAll")]
        //List<TimesheetDTO> JsonGetTimesheetAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimesheetByWorkdateCostcodeDepartstructure(DateTime workDate, int costcodeId, int departstructureId, int projectId, string disciplineCode, int ishistory);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByWorkdateCostcodeDepartstructure/{workDate}/{costcodeId}/{departstructureId}/{projectId}/{disciplineCode}/{ishistory}")]
        //List<TimesheetDTO> JsonGetTimesheetByWorkdateCostcodeDepartstructure(string workDate, string costcodeId, string departstructureId, string projectId, string disciplineCode, string ishistory);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimesheetByWorkdateDailyTimeSheet(DateTime workDate, int costcodeId, int departstructureId, int dailytimesheetId, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByWorkdateDailyTimeSheet/{workDate}/{costcodeId}/{departstructureId}/{dailytimesheetId}/{projectId}/{disciplineCode}")]
        //List<TimesheetDTO> JsonGetTimesheetByWorkdateDailyTimeSheet(string workDate, string costcodeId, string departstructureId, string dailytimesheetId, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimeallocationDTO> GetTimeallocationForGroup(int cwpId, int fiwpId, int materialCategoryId, DateTime installeddate, int ruleofcreditId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimeallocationForGroup/{cwpId}/{fiwpId}/{materialCategoryId}/{installeddate}/{ruleofcreditId}")]
        //List<TimeallocationDTO> JsonGetTimeallocationForGroup(string cwpId, string fiwpId, string materialCategoryId, string installeddate, string ruleofcreditId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetAndProgress> GetTimesheetAndProgressByWorkdateDepartStructure(DateTime workdate, int departstructureId, int dailytimesheetId, int projectId, string disciplineCode, int ishistory);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JasonGetTimesheetAndProgressByWorkdateDepartStructure/{workdate}/{departstructureId}/{dailytimesheetId}/{projectId}/{disciplineCode}/{ishistory}")]
        //List<TimesheetAndProgress> JasonGetTimesheetAndProgressByWorkdateDepartStructure(string workdate, string departstructureId, string dailytimesheetId, string projectId, string disciplineCode, string ishistory);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimesheetByFiwp(int fiwpId, int flg);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByFiwp/{fiwpId}/{flg}")]
        //List<TimesheetDTO> JsonGetTimesheetByFiwp(string fiwpId, string flg);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimesheetByTimeAllocationID(int timeallocationId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByTimeAllocationID/{timeallocationId}")]
        //List<TimesheetDTO> JsonGetTimesheetByTimeAllocationID(string timeallocationId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimeSheetTableByCWP(int cwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimeSheetTableByCWP/{cwpId}")]
        //List<TimesheetDTO> JsonGetTimeSheetTableByCWP(string cwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimesheetByFiwpWorkdate(int fiwpId, DateTime workDate, int projectId, string disciplineCode, int flg);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByFiwpWorkdate/{fiwpId}/{workDate}/{projectId}/{disciplineCode}/{flg}")]
        //List<TimesheetDTO> JsonGetTimesheetByFiwpWorkdate(string fiwpId, string workDate, string projectId, string disciplineCode, string flg);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> GetTimesheetByWorkdatePersonnelID(int personnelId, DateTime workDate, int projectId, string disciplineCode, int flg);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByWorkdatePersonnelID/{personnelId}/{workDate}/{projectId}/{disciplineCode}/{flg}")]
        //List<TimesheetDTO> JsonGetTimesheetByWorkdatePersonnelID(string personnelId, string workDate, string projectId, string disciplineCode, string flg);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //TimesheetTaskAndValue GetTimesheetTaskByCrew(int cwpId, int fiwpId, int materialcategoryId, DateTime workDate, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetTaskByCrew/{cwpId}/{fiwpId}/{materialcategoryId}/{workDate}/{projectId}/{disciplineCode}")]
        //TimesheetTaskAndValue JsonGetTimesheetTaskByCrew(string cwpId, string fiwpId, string materialcategoryId, string workDate, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //TimesheetTaskAndValue GetTimesheetByCrewForMultiPool(int cwpId, int fiwpId, int materialcategoryId, DateTime workDate, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetByCrewForMultiPool/{cwpId}/{fiwpId}/{materialcategoryId}/{workDate}/{projectId}/{disciplineCode}")]
        //TimesheetTaskAndValue JsonGetTimesheetByCrewForMultiPool(string cwpId, string fiwpId, string materialcategoryId, string workDate, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //TimesheetTaskAndValue GetTimesheetForOtherByCrew(int cwpId, int fiwpId, int materialcategoryId, DateTime workDate, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetTimesheetForOtherByCrew/{cwpId}/{fiwpId}/{materialcategoryId}/{workDate}/{projectId}/{disciplineCode}")]
        //TimesheetTaskAndValue JsonGetTimesheetForOtherByCrew(string cwpId, string fiwpId, string materialcategoryId, string workDate, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailytimesheetDTO> GetDailytimesheetByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDailytimesheetByID/{Id}")]
        //List<DailytimesheetDTO> JsonGetDailytimesheetByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //RfiDTO GetRfiByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRfiByID/{Id}")]
        //RfiDTO JsonGetRfiByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RfiDTO> GetRfiByProject(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRfiByProject/{projectId}")]
        //List<RfiDTO> JsonGetRfiByProject(string projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RfiDTO> GetRfiByProjectModule(int Id, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRfiByProjectModule/{Id}/{disciplineCode}")]
        //List<RfiDTO> JsonGetRfiByProjectModule(string Id, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RfiDTO> GetRFIByCWPDrawing(int CWPID, int DrawingID, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRFIByCWPDrawing/{CWPID}/{DrawingID}/{projectId}/{disciplineCode}")]
        //List<RfiDTO> JsonGetRFIByCWPDrawing(string CWPID, string DrawingID, string projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibconsumableDTO> GetLibconsumableAll();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibconsumableAll")]
        List<LibconsumableDTO> JsonGetLibconsumableAll();
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpqaqcDTO GetFiwpqaqcByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpqaqcByID/{id}")]
        //FiwpqaqcDTO JsonGetFiwpqaqcByID(string id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpqaqcDTO> GetFiwpqaqcAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpqaqcAll")]
        //List<FiwpqaqcDTO> JsonGetFiwpqaqcAll();
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpqaqcDTO> GetFiwpqaqcByFIWP(int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpqaqcByFIWP/{fiwpId}")]
        //List<FiwpqaqcDTO> JsonGetFiwpqaqcByFIWP(string fiwpId);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcconfigDTO GetQaqcconfigByID(int id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcconfigByID/{id}")]
        //QaqcconfigDTO JsonGetQaqcconfigByID(string id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcconfigDTO> GetQaqcconfigAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcconfigAll")]
        //List<QaqcconfigDTO> JsonGetQaqcconfigAll();
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> DeleteMTO(List<MTODTO> progress, string updatedBy, string userName, string password, int rfiid);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentDTO> DeleteMTOByImportedfilename(int importedfilenameId);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonDeleteMTOByImportedfilename")]
        //List<ComponentDTO> JsonDeleteMTOByImportedfilename(string importedfilenameId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> InsertUpdateMTO(List<ProgressDTO> progress);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> InsertUpdatePipeMTO(List<ProgressDTO> progress);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MTODTO> InsertUpdateInsulMTO(List<ProgressDTO> progress);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateProgressCostCodeByProgressID(int p_ProgressId, int p_CostCodeId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentDTO> SaveComponent(List<ComponentDTO> component);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RfidrawingDTO> SaveRFIDrawing(List<RfidrawingDTO> rfidrawing);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodeDTO> SaveCostcode(List<CostcodeDTO> costcode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //CostcodeDTO SaveSingleCostcode(CostcodeDTO costcode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> SaveCostcodeStructureByProjectSchedule(int intProjectID, int intCwpID, int intProjectScheduleID, int intParentCostcodeStructureID, int intClassLevel);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> SaveCostcodestructure(List<CostcodestructureDTO> costcodestructure);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodestructureDTO> SaveCostcodestructureProjectWizard(List<CostcodestructureDTO> costcodestructure);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodetaleDTO> SaveCostcodetale(List<CostcodetaleDTO> costcodestail);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CostcodelockedDTO> SaveCostcodelocked(List<CostcodelockedDTO> list);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwaDTO> SaveCwa(List<CwaDTO> cwas);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwaDTO> SaveCwaProjectWizard(List<CwaDTO> cwas);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwpDTO> SaveCwp(List<CwpDTO> cwps);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<CwpDTO> SaveCwpProjectWizard(List<CwpDTO> cwps);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //CwpDTO SaveSingleCwp(CwpDTO cwps);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingrevisionDTO> SaveDrawingRevision(List<DrawingrevisionDTO> drawingrev);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingcwpDTO> SaveDrawingCWP(List<DrawingcwpDTO> drawingcwp);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingreferenceDTO> SaveDrawingReference(List<DrawingreferenceDTO> DrawingReference);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingsdrefDTO> SaveDrawingsdre(List<DrawingsdrefDTO> Drawingsdref);

        ////[OperationContract]
        ////[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDrawingsdre/{Drawingsdref}")]
        ////List<DrawingsdrefDTO> JsonSaveDrawingsdre(List<DrawingsdrefDTO> Drawingsdref);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> SaveDrawing(List<DrawingDTO> drawing);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> SaveDrawingWithDrawingRevision(List<DrawingDTO> drawings);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> SaveDrawingWithDrawingReference(List<DrawingDTO> drawings);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TagnumberdrawingDTO> SaveTagnumberdrawing(List<TagnumberdrawingDTO> tagNumberDrawing);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> SaveSIWP(List<FiwpDTO> fiwp);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> SaveFIWP(List<FiwpDTO> fiwp, string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFIWP")]
        List<FiwpDTO> JsonSaveFIWP(List<FiwpDTO> fiwp);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpDTO> SaveHydro(List<FiwpDTO> fiwp, string userName, string password);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveHydro")]
        //List<FiwpDTO> JsonSaveHydro(List<FiwpDTO> fiwp, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpworkflowDTO> SaveFiwpworkflowWithSMTP(List<FiwpworkflowDTO> fiwpworkflow, string link);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpworkflowDTO> SaveFiwpworkflow(FiwpworkflowDTO[] fiwpworkflow);
        
        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //FiwpworkflowDTO SaveSingleFiwpworkflow(FiwpworkflowDTO fiwpworkflow);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmanpowerDTO> SaveFiwpManPower(List<FiwpmanpowerDTO> fiwpmanpower);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpcommentDTO> SaveFiwpcomment(List<FiwpcommentDTO> fiwpcomment);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmanonsiteDTO> SaveFiwpManonsite(List<FiwpmanonsiteDTO> fiwpManonsite);
        
        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpManonsite")]
        //List<FiwpmanonsiteDTO> JsonSaveFiwpManonsite(List<FiwpmanonsiteDTO> fiwpManonsite);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpdocordinalDTO> SaveFiwpdocordinal(List<FiwpdocordinalDTO> fiwpDocordinal);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpwfpDTO> SaveFiwpwfp(List<FiwpwfpDTO> fiwpwfp);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpwfp")]
        //List<FiwpwfpDTO> JsonSaveFiwpwfp(List<FiwpwfpDTO> fiwpwfp);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpequipDTO> SaveFiwpequip(List<FiwpequipDTO> fiwpequip);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpequip")]
        List<FiwpequipDTO> JsonSaveFiwpequip(List<FiwpequipDTO> fiwpequip);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmaterialDTO> SaveFiwpMaterial(List<FiwpmaterialDTO> fiwpmaterial);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpMaterial")]
        List<FiwpmaterialDTO> JsonSaveFiwpMaterial(List<FiwpmaterialDTO> fiwpmaterial);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> SaveDocument(List<DocumentDTO> document);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDocument")]
        List<DocumentDTO> JsonSaveDocument(List<DocumentDTO> document);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentnoteDTO> SaveDocumentNote(List<DocumentnoteDTO> documentnote);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibcablemanhourDTO> SaveLibcablemanhour(List<LibcablemanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibracewaymanhourDTO> SaveLibracewaymanhour(List<LibracewaymanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibehtmanhourDTO> SaveLibehtmanhour(List<LibehtmanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibequipmanhourDTO> SaveLibequipmanhour(List<LibequipmanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibconsumableDTO> SaveLibconsumable(List<LibconsumableDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibgroundingmanhourDTO> SaveLibgroundingmanhour(List<LibgroundingmanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LiblightingmanhourDTO> SaveLiblightingmanhour(List<LiblightingmanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinstrmanhourDTO> SaveLibinstrmanhour(List<LibinstrmanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialDTO> SaveMaterial(List<MaterialDTO> material);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<MaterialCableDTO> SaveMaterialCable(List<MaterialCableDTO> materialCables);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> SaveProgress(List<ProgressDTO> progress);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectAndModule SaveProjectAndProjectModule(ProjectAndModule projects);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectDTO> SaveProject(List<ProjectDTO> project);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectWizard SaveProjectWizard(ProjectWizard projectwizard);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectDTO DeleteProjectWizard(int projectId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProjectDTO SaveSingleProject(ProjectDTO project);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectDTO> SaveProjectAndSharePointProject(List<ProjectDTO> project);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformDTO> GetQaqcformByQcManager(int projectid, string disciplineCode, int loginId, int QAQCDataTypeLUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformDTO> SaveQaqcformForDownload(int projectId, string disciplineCode, int cwpId, int fiwpId, List<QaqcformtemplateDTO> qaqcformtemplate, string updatedBy, int QAQCDataTypeLUID);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveQaqcformForDownload")]
        //List<QaqcformDTO> JsonSaveQaqcformForDownload(string projectId, string disciplineCode, string cwpId, string fiwpId, List<QaqcformtemplateDTO> qaqcformtemplate, string updatedBy, string QAQCDataTypeLUID);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformDTO> SaveQaqcformForSubmit(List<QaqcformDTO> qaqcforms);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveQaqcformForSubmit")]
        //List<QaqcformDTO> JsonSaveQaqcformForSubmit(List<QaqcformDTO> qaqcforms);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO SaveQaqcform(QaqcformDTO qaqcForm);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectmoduleDTO> SaveProjectModule(List<ProjectmoduleDTO> projectmodule);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> SaveProjectSchedule(List<ProjectscheduleDTO> schedule, string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveProjectSchedule")]
        List<ProjectscheduleDTO> JsonSaveProjectSchedule(List<ProjectscheduleDTO> schedule);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectscheduleDTO> CleanProjectSchedule(int projectscheduleid, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<RfiDTO> SaveRFI(List<RfiDTO> rfi);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveRFI")]
        List<RfiDTO> JsonSaveRFI(List<RfiDTO> rfi);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ScaffoldAndRequest SaveScaffoldrequest(ScaffoldAndRequest dto);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SystemDTO> SaveSystem(List<SystemDTO> system);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SystemDTO> SaveSystemProjectWizard(List<SystemDTO> system);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //SystemDTO SaveSingleSystem(SystemDTO system);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<AreaDTO> SaveArea(List<AreaDTO> area);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> SaveTimesheet(List<TimesheetDTO> timesheet, List<MTODTO> progresses, decimal workhour, int timeallocationId);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveTimesheet")]
        //List<TimesheetDTO> JsonSaveTimesheet(List<TimesheetDTO> timesheet, List<MTODTO> progresses, string workhour, string timeallocationId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<TimesheetDTO> SaveTimeAllocationRestore(int timeallocationId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateFIWPProgressAssignment(ProgressAssignment progress, string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUpdateFIWPProgressAssignment")]
        ProgressAssignment JsonUpdateFIWPProgressAssignment(ProgressAssignment progress);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateSIWPProgressAssignment(ProgressAssignment progress, string userName, string password);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateSIWPProgressAssignmentByRange(ProgressAssignment progress,  int startprogressid, int endprogressid, string userName, string password);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateSIWPProgressAssignmentForTurnOver(ProgressAssignment progress, string userName, string password);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateSIWPProgressAssignmentForTurnOverByRange(ProgressAssignment progress,  int startprogressid, int endprogressid, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmaterialDTO> RegenerateFIWPMaterial(int fiwpId, int projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ExtSchedulerDTO UpdateFiwpScheduler(ExtSchedulerDTO extscheduler, string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUpdateFiwpScheduler")]
        ExtSchedulerDTO JsonUpdateFiwpScheduler(ExtSchedulerDTO extscheduler);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ExtSchedulerDTO UpdateFiwpManpower(ExtSchedulerDTO fiwpMPower, int projectscheduleId, int projectId, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateManhoursEstimateByCostCode(int cwpId, int costcodeId, int projectId, string disciplineCode, decimal manhourRate, decimal baseQty, string updatedBy, string UpdateQty);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateComponentWithAssociatedTag(int projectid, string disciplineCode, int tab, string isolineno, int componentid, int systemid);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateComponentWithSystem(int projectId, string disciplineCode, int tab, string firstid, string second, string third, int taskid, int isSystemEmpty, int systemId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateMaterialWithReelNo(int cwpId, int fiwpId, int projectId, string disciplineCode, string filterName, string filterValue, string newReelNo);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateProgressWithCWP(int cwpId, int materialCategoryId, int taskCategoryId, int projectId, string disciplineCode, int newCWPID);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateProgressCostCode(int cwpId, int materialcategoryid, int taskcategoryid, int componenttasktype, string engtag, int costcode, int projectid, string disciplineCode);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressDTO> UpdateProgressComponents(List<ProgressDTO> progress);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //ProgressAssignment UpdateProjectScheduleAssignment(ProgressAssignment progress, string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUpdateProjectScheduleAssignment")]
        ProgressAssignment JsonUpdateProjectScheduleAssignment(ProgressAssignment progress);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUpdateProjectSchedulePeriod")]
        ProjectscheduleDTO JsonUpdateProjectSchedulePeriod(ProjectscheduleDTO schedule, string totalManhours);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUpdateIwpPeriod")]
        FiwpDTO JsonUpdateIwpPeriod(FiwpDTO iwp, string totalManhours);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateQaqcformForSign(int qaqcformId, string savedUrl, int SPCollectionID, bool isSubmitted);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateSingleMaterialWithReelNo(int materialId, string newReelNo);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUpdateSingleMaterialWithReelNo/{materialId}/{newReelNo}")]
        //void JsonUpdateSingleMaterialWithReelNo(string materialId, string newReelNo);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateSingleProgressWithCWP(int progressId, int newCwpId);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void UpdateTimesheetToP6(int fiwpId, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void SyncProjectScheduleToP6(int projectscheduleId, int projectId, string disciplineCode, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void SyncFIWPResourceToP6(int fiwpId, int projectId, string disciplineCode, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void SyncScheduleResourceToP6(int fiwpId, int projectId, string disciplineCode, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void SyncScheduleResourceToP6ByProjectSchedule(int projectscheduleId, int projectId, string disciplineCode, string userName, string password);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void SyncScheduleFIWPResourceToP6(int fiwpId, int projectId, string disciplineCode, string userName, string password);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //int UploadSharePointForSPCollectionID(int projectId, string collection, string docName);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonUploadSharePointForSPCollectionID/{projectId}/{collection}/{docName}")]
        //int JsonUploadSharePointForSPCollectionID(string projectId, string collection, string docName);

        ///// <summary>
        ///// 2013-11-25 Add
        ///// </summary>
        ///// <returns></returns>
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingDTO SaveMultiDrawingAndUpload(byte[] DrawingData, DrawingDTO drwaing, string fileName, string siteInstance, string webPath, string physicalpath);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> SaveMultiDrawingAndUpload2(List<DrawingDTO> drwaings);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingDTO SaveDrawingAndUpload(DrawingDTO drwaing, string fileName, string siteInstance, string webPath, string physicalpath);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingDTO SaveDrawingAndGenerate(DrawingDTO drwaing, string siteInstance, string webPath);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //void RegenerateCXML(int projectId, string siteInstance, string webPath);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string GetImagePhysicalPath();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //string GetImageLocationURL();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipemanhourDTO> GetLibPipeManHourAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipeclassmanhourDTO> GetLibPipeClassManHourAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipeclassmanhourDTO> SaveLibPipeClassManHour(List<LibpipeclassmanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipeclassmanhourDTO GetLibPipeClassManHourByID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipeclassmanhourPageTotal GetLibPipeClassManHourForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeClassManHourForPaging/{selectedPage}/{pageSize}/{PipeType}/{SearchOption}/{PipeSize}/{selectoption}/{luid1}/{luid2}/{luid3}/{luid4}")]
        //LibpipeclassmanhourPageTotal JsonGetLibPipeClassManHourForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipemanhourratioDTO> GetLibPipeManhourRatioAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipemanhourratioDTO> SaveLibPipeManhourRatio(List<LibpipemanhourratioDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipemanhourratioDTO GetLibPipeManhourRatioByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeManhourRatioByID/{Id}")]
        //LibpipemanhourratioDTO JsonGetLibPipeManhourRatioByID(string Id);

        //[OperationContract] [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipemanhourDTO GetLibPipeManhourByID(int Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipemanhourratioPageTotal GetLibPipeManhourRatioForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeManhourRatioForPaging/{selectedPage}/{pageSize}/{PipeType}/{SearchOption}/{PipeSize}/{selectoption}/{luid1}/{luid2}/{luid3}/{luid4}")]
        //LibpipemanhourratioPageTotal JsonGetLibPipeManhourRatioForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipematerialgrpDTO GetLibPipeMaterailGrpByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeMaterailGrpByID/{Id}")]
        //LibpipematerialgrpDTO JsonGetLibPipeMaterailGrpByID(string Id);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipesupmanhourDTO> GetLibPipeSupManhourAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeSupManhourAll")]
        //List<LibpipesupmanhourDTO> JsonGetLibPipeSupManhourAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipesupmanhourDTO GetLibPipeSupManhourByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeSupManhourByID/{Id}")]
        //LibpipesupmanhourDTO JsonGetLibPipeSupManhourByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipesupmanhourPageTotal GetLibPipeSupManhourForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeSupManhourForPaging/{selectedPage}/{pageSize}/{PipeType}/{SearchOption}/{PipeSize}/{selectoption}/{luid1}/{luid2}/{luid3}/{luid4}")]
        //LibpipesupmanhourPageTotal JsonGetLibPipeSupManhourForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipesupmanhourDTO> SaveLibPipeSupManhour(List<LibpipesupmanhourDTO> lib);
        
        //[OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "JsonSaveLibPipeSupManhour")]
        //List<LibpipesupmanhourDTO> JsonSaveLibPipeSupManhour(List<LibpipesupmanhourDTO> lib);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipematerialgrpDTO> GetLibpipematerialgrpAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipeschmanhourDTO> GetLibPipeSchManhourAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeSchManhourAll")]
        //List<LibpipeschmanhourDTO> JsonGetLibPipeSchManhourAll();

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipeschmanhourDTO GetLibPipeSchManhourByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeSchManhourByID/{Id}")]
        //LibpipeschmanhourDTO JsonGetLibPipeSchManhourByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipeschmanhourPageTotal GetLibPipeSchManhourForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4, string PipeThickSch);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetLibPipeSchManhourForPaging/{selectedPage}/{pageSize}/{PipeType}/{SearchOption}/{PipeSize}/{selectoption}/{luid1}/{luid2}/{luid3}/{luid4}/{PipeThickSch}")]
        //LibpipeschmanhourPageTotal JsonGetLibPipeSchManhourForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4, string PipeThickSch);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipeschmanhourDTO> SaveLibPipeSchManhour(List<LibpipeschmanhourDTO> lib);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //LibpipemanhourPageTotal GetLibPipeManHourForPaging(int selectedPage, int pageSize, int PipeType, int MaterialType, decimal PipeSize, string PipeClass, string PipeSCH);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibpipemanhourDTO> SaveLibPipeManhour(List<LibpipemanhourDTO> lib);

        ////LibInsul-------------------------------------------------------------
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulfactorDTO> SaveLibinsulfactor(List<LibinsulfactorDTO> lib);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulfireproofDTO> SaveLibinsulfireproof(List<LibinsulfireproofDTO> lib);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulpaintmanhourDTO> SaveLibinsulpaintmanhour(List<LibinsulpaintmanhourDTO> lib);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulpipefactorDTO> SaveLibinsulpipefactor(List<LibinsulpipefactorDTO> lib);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<LibinsulpipemanhourDTO> SaveLibinsulpipemanhour(List<LibinsulpipemanhourDTO> lib);

        ////------------------------------------------------------------------------

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComponentDTO> GetComponentByRFIID(int rfiid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentByRFIID/{rfiid}")]
        //List<ComponentDTO> JsonGetComponentByRFIID(string rfiid);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //RfidrawingDTO GetRfiDrawingByRfidrawing(int rfiid, int drawingid, int cwpid, string revisionno);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRfiDrawingByRfidrawing/{rfiId}/{drawingid}/{cwpid}/{revisionno}")]
        //RfidrawingDTO JsonGetRfiDrawingByRfidrawing(string rfiid, string drawingid, string cwpid, string revisionno);

        //[OperationContract][WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //RfidrawingDTO GetRfiDrawingByID(int rfidrawingid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetRfiDrawingByID/{rfidrawingid}")]
        //RfidrawingDTO JsonGetRfiDrawingByID(string rfidrawingid);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentByFiwpForIOS/{fiwpid}/{projectid}/{disciplineCode}")]
        //List<string> JsonGetDocumentByFiwpForIOS(string fiwpid, string projectid, string disciplineCode);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetIwpDocumentByIwp/{iwpId}/{projectId}/{disciplineCode}")]
        List<string> JsonGetIwpDocumentFilterByIwp(string iwpId, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDocumentNoteByIOS")]
        //List<DocumentnoteDTO> JsonSaveDocumentNoteByIOS(DocumentnoteDTO list, string spcollectionid, string fiwpid);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDrawingStickyNote")]
        List<DrawingStickyNoteDTO> JsonSaveDrawingStickyNote(DrawingStickyNoteDTO list, string iwpId);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DocumentmarkupDTO GetDocumentmarkupByID(int Id);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentmarkupByID/{Id}")]
        //DocumentmarkupDTO JsonGetDocumentmarkupByID(string Id);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentmarkupDTO> GetDocumentmarkupByDrawingPersonnel(int drawingId, int personnelId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentmarkupByDrawingPersonnel/{drawingId}/{personnelId}")]
        List<DocumentmarkupDTO> JsonGetDocumentmarkupByDrawingPersonnel(string drawingId, string personnelId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentmarkupDTO> GetDocumentmarkupAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDocumentmarkupAll")]
        //List<DocumentmarkupDTO> JsonGetDocumentmarkupAll();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DrawingAndMarkup GetDrawingDocumentmarkupByDrawingPersonnel(int drawingId, int personnelId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingDocumentmarkupByDrawingPersonnel/{drawingId}/{personnelId}")]
        //DrawingAndMarkup JsonGetDrawingDocumentmarkupByDrawingPersonnel(string drawingId, string personnelId);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentmarkupDTO> SaveDocumentmarkup(List<DocumentmarkupDTO> documentmarkup);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDocumentmarkup")]
        //List<DocumentmarkupDTO> JsonSaveDocumentmarkup(List<DocumentmarkupDTO> documentmarkup);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DocumentmarkupDTO SaveDocumentmarkupWithSharePoint(int projectId, DocumentmarkupDTO documentmarkup);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDocumentmarkupWithSharePoint")]
        //DocumentmarkupDTO JsonSaveDocumentmarkupWithSharePoint(string projectId, DocumentmarkupDTO documentmarkup);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDocumentmarkupWithMarkupImage")]
        DocumentmarkupDTO JsonSaveDocumentmarkupWithMarkupImage(DocumentmarkupDTO documentmarkup, UpfileDTOS upFileCollection);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //DocumentDTO SaveProjectDocumentWithSharePointForModelView(List<FiwpDTO> fiwps, DocumentDTO document, string docName, string cwpName, string fiwpName);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveProjectDocumentWithSharePointForModelView")]
        //DocumentDTO JsonSaveProjectDocumentWithSharePointForModelView(List<FiwpDTO> fiwps, DocumentDTO document, string docName, string cwpName, string fiwpName);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> SaveProjectDocumentWithSharePointForWFP(DocumentDTO document, string cwpName, string fiwpName, int packagetypeLuid, int currentStep);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveProjectDocumentWithSharePointForWFP")]
        //List<DocumentDTO> JsonSaveProjectDocumentWithSharePointForWFP(DocumentDTO document, string cwpName, string fiwpName, string packagetypeLuid, string currentStep);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpwfpDTO> SaveFiwpwfpForAssembleIWP(List<FiwpwfpDTO> fiwpwfps, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpwfpForAssembleIWP")]
        //List<FiwpwfpDTO> JsonSaveFiwpwfpForAssembleIWP(List<FiwpwfpDTO> fiwpwfps, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpequipDTO> SaveFiwpequipForAssembleIWP(List<FiwpequipDTO> fiwpequips, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpequipForAssembleIWP")]
        List<FiwpequipDTO> JsonSaveFiwpequipForAssembleIWP(List<FiwpequipDTO> fiwpequips, List<FiwpDTO> fiwps, string userId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpmaterialDTO> SaveFiwpMaterialForAssembleIWP(List<FiwpmaterialDTO> fiwpmaterials, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpMaterialForAssembleIWP")]
        List<FiwpmaterialDTO> JsonSaveFiwpMaterialForAssembleIWP(List<FiwpmaterialDTO> fiwpmaterials, List<FiwpDTO> fiwps, string userId);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDocumentForAssembleIWP")]
        List<DocumentDTO> JsonSaveDocumentForAssembleIWP(List<FiwpDTO> fiwps, List<DocumentDTO> documents, string curStepCode, string userId);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDocumentWithOZformForAssembleIWP")]
        List<DocumentDTO> JsonSaveDocumentWithOZformForAssembleIWP(List<FiwpDTO> fiwps, UpfileDTOS upFileCollection, string curStepCode, string userId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformDTO> CreateQaqcForm(string dbname, string updatedBy);
               
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpqaqcDTO> SaveFiwpqaqcForAssembleIWP(List<FiwpqaqcDTO> fiwpqaqcs, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpqaqcForAssembleIWP")]
        //List<FiwpqaqcDTO> JsonSaveFiwpqaqcForAssembleIWP(List<FiwpqaqcDTO> fiwpqaqcs, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> SaveSafetyDocumentForAssembleIWP(List<DocumentDTO> safetys, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSafetyDocumentForAssembleIWP")]
        //List<DocumentDTO> JsonSaveSafetyDocumentForAssembleIWP(List<DocumentDTO> safetys, List<FiwpDTO> fiwps, List<DocumentDTO> documents);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ComboBoxDTO> SavePnIDDrawingForBuildCSU(List<ComboBoxDTO> drawings, List<FiwpDTO> fiwps);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSavePnIDDrawingForBuildCSU")]
        //List<ComboBoxDTO> JsonSavePnIDDrawingForBuildCSU(List<ComboBoxDTO> drawings, List<FiwpDTO> fiwps);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> SaveAssociatedDocumentForBuildCSU(List<DocumentDTO> associatedDocs, List<FiwpDTO> fiwps, int currentStep);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveAssociatedDocumentForBuildCSU")]
        //List<DocumentDTO> JsonSaveAssociatedDocumentForBuildCSU(List<DocumentDTO> associatedDocs, List<FiwpDTO> fiwps, string currentStep);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SigmacueDTO> SaveSigmacue(List<SigmacueDTO> sigmacue, int dataId, string type);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveSigmacue")]
        //List<SigmacueDTO> JsonSaveSigmacue(List<SigmacueDTO> sigmacue, int dataId, string type);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailybrassDTO> SaveDailybrass(List<DailybrassDTO> dailybrass);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDailybrass")]
        List<DailybrassDTO> JsonSaveDailybrass(List<DailybrassDTO> dailybrass);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailybrassDTO> GetDailybrassByForemanPersonnelWorkDate(int projectId, string disciplineCode, int personnelId, DateTime workDate);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDailybrassByForemanWorkdate/{projectId}/{disciplineCode}/{foremanId}/{workDate}")]
        List<DailybrassDTO> JsonGetDailybrassByForemanWorkdate(string projectId, string disciplineCode, string foremanId, string workDate);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailybrasssignDTO> SaveDailybrasssign(List<DailybrasssignDTO> dailybrasssign);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDailybrasssign")]
        List<DailybrasssignDTO> JsonSaveDailybrasssign(List<DailybrasssignDTO> dailybrasssign);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailybrasssignDTO> SaveDailybrasssignOffline(List<DailybrasssignDTO> dailybrasssign);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDailybrasssignOffline")]
        //List<DailybrasssignDTO> JsonSaveDailybrasssignOffline(List<DailybrasssignDTO> dailybrasssign);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailybrasssignDTO> GetDailybrasssignByDailyBrass(int dailybrassId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDailybrasssignByDailyBrass/{dailybrassId}")]
        List<DailybrasssignDTO> JsonGetDailybrasssignByDailyBrass(string dailybrassId);
        
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailytoolboxDTO> SaveDailytoolbox(List<DailytoolboxDTO> dailytoolbox);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDailybrasstoolbox")]
        List<DailytoolboxDTO> JsonSaveDailybrasstoolbox(List<DailytoolboxDTO> dailytoolbox);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ToolboxsignDTO> SaveToolboxsign(List<ToolboxsignDTO> toolboxsign);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveToolboxsign")]
        //List<ToolboxsignDTO> JsonSaveToolboxsign(List<ToolboxsignDTO> toolboxsign);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ToolboxsignDTO> SaveToolboxsignOffline(List<ToolboxsignDTO> toolboxsign);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveToolboxsignOffline")]
        //List<ToolboxsignDTO> JsonSaveToolboxsignOffline(List<ToolboxsignDTO> toolboxsign);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DailytoolboxDTO> GetDailytoolboxByDailyBrass(int dailybrassId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDailytoolboxByDailyBrass/{dailybrassId}")]
        //List<DailytoolboxDTO> JsonGetDailytoolboxByDailyBrass(string dailybrassId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //bool SaveDailyTimehseet(DateTime workDate, int dataId, int isDirect, int dailyTimesheetId, int status, string updatedBy, int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveDailyTimehseet/{workDate}/{intDataId}/{intFlag}/{dailyTimesheetId}/{status}/{updatedBy}/{projectId}/{disciplineCode}")]
        //bool JsonSaveDailyTimehseet(string workDate, string intDataId, string intFlag, string dailyTimesheetId, string status, string updatedBy, string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> GetSafetyDocumentsList(int projectId, string collection, string docName);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSafetyDocumentsList/{projectId}/{collection}/{docName}")]
        //List<DocumentDTO> JsonGetSafetyDocumentsList(string projectId, string collection, string docName);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //int SaveCrewAttendance(int dailybrassId, int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveCrewAttendance")]
        //int JsonSaveCrewAttendance(string dailybrassId, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //int SaveToolboxTalks(int dailybrassId, int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveToolboxTalks")]
        //int JsonSaveToolboxTalks(string dailybrassId, string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> GetCrewDocumentsList(int projectId, string collection, string[] docName);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCrewDocumentsList")]
        //List<DocumentDTO> JsonGetCrewDocumentsList(string projectId, string collection, string[] docName);

        ////[OperationContract]
        ////[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetCrewDocumentsList/{projectId}/{collection}/{docName}")]
        ////List<DocumentDTO> JsonGetCrewDocumentsList(string projectId, string collection, string[] docName);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<FiwpqaqcDTO> SaveFiwpqaqc(List<FiwpqaqcDTO> fiwpqaqc);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveFiwpqaqc")]
        //List<FiwpqaqcDTO> JsonSaveFiwpqaqc(List<FiwpqaqcDTO> fiwpqaqc);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcconfigDTO> SaveQaqcconfig(List<QaqcconfigDTO> qaqcconfig);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveQaqcconfig")]
        //List<QaqcconfigDTO> JsonSaveQaqcconfig(List<QaqcconfigDTO> qaqcconfig);

        //#region Qautity_Survey
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProgressruleofcreditCompletedDTO> GetFiwpByProgressCompleted(int projectId, string disciplineCode, int personnelId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetFiwpByProgressCompleted/{projectId}/{disciplineCode}/{personnelId}")]
        //List<ProgressruleofcreditCompletedDTO> JsonGetFiwpByProgressCompleted(string projectId, string disciplineCode, string personnelId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DrawingDTO> GetDrawingByFiwpProgressCompleted(int projectId, string disciplineCode, int cwpId, int projectscheduleId, int fiwpId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetDrawingByFiwpProgressCompleted/{projectId}/{disciplineCode}/{cwpId}/{projectscheduleId}/{fiwpId}")]
        //List<DrawingDTO> JsonGetDrawingByFiwpProgressCompleted(string projectId, string disciplineCode, string cwpId, string projectscheduleId, string fiwpId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QuantityserveyDTO> GetComponentByDrawingProgressCompleted(int projectId, string disciplineCode, int cwpId, int projectscheduleId, int fiwpId, int drawingId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetComponentByDrawingProgressCompleted/{projectId}/{disciplineCode}/{cwpId}/{projectscheduleId}/{fiwpId}/{drawingId}")]
        //List<QuantityserveyDTO> JsonGetComponentByDrawingProgressCompleted(string projectId, string disciplineCode, string cwpId, string projectscheduleId, string fiwpId, string drawingId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QuantityserveyDTO> SaveQuantitySurvey(List<QuantityserveyDTO> quantityservey);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveQuantitySurvey")]
        //List<QuantityserveyDTO> JsonSaveQuantitySurvey(List<QuantityserveyDTO> quantityservey);

        //#endregion Qautity_Survey


        //#region Turnover
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ProjectDTO> GetContractorProejctByOwnerProject(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetContractorProejctByOwnerProject/{projectId}")]
        //List<ProjectDTO> JsonGetContractorProejctByOwnerProject(string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<SystemDTO> GetSystemByTurnoverProject(int projectId, int constractorId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetSystemByTurnoverProject/{projectId}/{constractorId}")]
        //List<SystemDTO> JsonGetSystemByTurnoverProject(string projectId, string constractorId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<ModuleDTO> GetModuleByTurnoverSystem(int projectId, int constractorId, int systemId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetModuleByTurnoverSystem/{projectId}/{constractorId}/{systemId}")]
        //List<ModuleDTO> JsonGetModuleByTurnoverSystem(string projectId, string constractorId, string systemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //WalkdownDTOSet GetWalkDownBySystem(int projectId, int constractorId, int systemId, List<int> disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetWalkDownBySystem/{projectId}/{constractorId}/{systemId}/{moduleIds}")]
        //WalkdownDTOSet JsonGetWalkDownBySystem(string projectId, string constractorId, string systemId, string disciplineCodes);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformDTO> GetQaqcformBySystem(int systemId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformBySystem/{systemId}")]
        //List<QaqcformDTO> JsonGetQaqcformBySystem(string systemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformDTO> GetQaqcformBySystemFormtype(int projectId, string disciplineCode, int systemId, int formtype);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformBySystemFormtype/{projectId}/{disciplineCode}/{systemId}/{formtype}")]
        //List<QaqcformDTO> JsonGetQaqcformBySystemFormtype(string projectId, string disciplineCode, string systemId, string formtype);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<QaqcformdetailDTO> GetQaqcformByPersonnelDepartment(int projectId, string disciplineCode, int personnelId, int departmentId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetQaqcformByPersonnelDepartment/{projectId}/{disciplineCode}/{personnelId}/{departmentId}")]
        //List<QaqcformdetailDTO> JsonGetQaqcformByPersonnelDepartment(string projectId, string disciplineCode, string personnelId, string departmentId);

        //#endregion Turnover

        //#region Turnover_SAVE
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //WalkdownDTOSet SaveQaqcformWithSharepoint(WalkdownDTOSet walkdownDs);

        //[OperationContract]
        //[WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveQaqcformWithSharepoint")]
        //WalkdownDTOSet JsonSaveQaqcformWithSharepoint(WalkdownDTOSet walkdownDs);

        //#endregion Turnover_SAVE

        //#region Turnover_PunchTicket
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //WalkdownDTOSet GetPunchTicketByQaqcform(int qaqcformId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetPunchTicketByQaqcform/{qaqcformId}")]
        //WalkdownDTOSet JsonGetPunchTicketByQaqcform(string qaqcformId);


        //#endregion Turnover_PunchTicket

        //#region Turnover Package
        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> SaveTurnoverPackageWithSharePoint(DocumentDTO documentDTO, FiwpDTO fiwpDTO);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //PunchDTOSet GetPunchListByQaqcform(int qaqcformId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO SaveTurnoverCertificateForMC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> SaveTurnoverCertificatePDFForMC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO SaveTurnoverCertificateForTCCC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<DocumentDTO> SaveTurnoverCertificatePDFForTCCC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO GetTurnoverCertificateForMC(int projectId, int systemId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //QaqcformDTO GetTurnoverCertificateForTCCC(int projectId, int systemId);
        //#endregion Turnover Package

        //#region Punch
        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetPunchChartbyDiscipline/{projectId}")]
        //List<rptPunchDTO> JsonGetPunchChartbyDiscipline(string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<rptPunchDTO> GetPunchChartbyDiscipline(int projectId);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetPunchChartbyCAT/{projectId}")]
        //List<rptPunchDTO> JsonGetPunchChartbyCAT(string projectId);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<rptPunchDTO> GetPunchChartbyCAT(int projectId);

        //#endregion 

        
        //#region ITR
        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetITRChartbySystem/{projectId}/{disciplineCode}")]
        //List<rptQAQCformDTO> JsonGetITRChartbySystem(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<rptQAQCformDTO> GetITRChartbySystem(int projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetITRChartbyCWP/{projectId}/{disciplineCode}")]
        //List<rptQAQCformDTO> JsonGetITRChartbyCWP(string projectId, string disciplineCode);

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        //List<rptQAQCformDTO> GetITRChartbyCWP(int projectId, string disciplineCode);

        //#endregion

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonGetProjectCwaIwpByIwp/{iwpId}")]
        rptProjectCwaIwpDTO JsonGetProjectCwaIwpByIwp(string iwpId);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveCrewAttendance_Rpt")]
        SigmaResultTypeDTO JsonSaveCrewAttendance_Rpt(string dailybrassId, string sigmauserId);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonSaveTimeAndProgress_Rpt")]
        SigmaResultTypeDTO JsonSaveTimeAndProgress_Rpt(string dailybrassId, string SigmaUserId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsonReadP6WBSManager/{projectId}/{url}/{userName}/{password}/{userId}")]
        SigmaResultTypeDTO JsonReadP6WBSManager(string projectId, string url, string userName, string password, string userId);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "JsongenerateRptTest")]
        int JsongenerateRptTest(string div, string userId);
    }
}