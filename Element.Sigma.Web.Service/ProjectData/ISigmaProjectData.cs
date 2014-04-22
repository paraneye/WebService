using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using Element.Shared.Common;
using Element.Sigma.Web.Biz;
using Element.Sigma.Web.Biz.Types.ProjectData;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.GlobalSettings;

namespace Element.Sigma.Web.Service.ProjectData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISigmaProjectData" in both code and config file together.
    [ServiceContract]
    public interface ISigmaProjectData
    {
        #region Manage Drawing

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Drawings/{DrawingId}")]
        SigmaResultType GetDrawing(string DrawingId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Drawings")]
        SigmaResultType ListDrawing();
                
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CountOrphanDrawings")]
        SigmaResultType CountOrphanDrawing();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "RefDrawings/{CWPName}")]
        SigmaResultType ListRefDrawing(string CWPName);
        

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "DrawingViewer")]
        SigmaResultType DrawingViewer(string CWPName, string DrawingName);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "DrawingBinding")]
        SigmaResultType DrawingBinding(TypeDrawing paramObj);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Drawings")]
        SigmaResultType AddDrawing(TypeDrawing paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Drawings")]
        SigmaResultType UpdateDrawing(TypeDrawing paramObj);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Drawings")]
        SigmaResultType RemoveDrawing(TypeDrawing paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Drawings/Multi")]
        SigmaResultType MultiDrawing(List<TypeDrawing> listObj);

        #endregion
        
        #region ImportDrawing : Get Drawing Info After ImportDrawing

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "DrawingLists/{ImportHistoryId}")]
        SigmaResultType ListDrawingByImportHistoryId(string ImportHistoryId); 
        
        #endregion 


        #region ComponentReferenceDrawing
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentReferenceDrawings/{componentReferenceDrawingId}")]
        SigmaResultType GetComponentReferenceDrawing(string componentReferenceDrawingId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentReferenceDrawings")]
        SigmaResultType ListComponentReferenceDrawing();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentReferenceDrawings")]
        SigmaResultType AddComponentReferenceDrawing(TypeComponentReferenceDrawing paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentReferenceDrawings")]
        SigmaResultType UpdateComponentReferenceDrawing(TypeComponentReferenceDrawing paramObj);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentReferenceDrawings")]
        SigmaResultType RemoveComponentReferenceDrawing(TypeComponentReferenceDrawing paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentReferenceDrawings/Multi")]
        SigmaResultType MultiComponentReferenceDrawing(List<TypeComponentReferenceDrawing> listObj);
        #endregion 

        #region ImportMTO :

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "TagNumberCombos/{DrawingId}/{Gubun}")]
        SigmaResultType GetTagNumberCombo(string DrawingId, string Gubun);//Get Assciated TagNumber ComboBox :: Gubun: 1이면 Composite


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Discipline/{CwpName}/{CwpId}")]
        SigmaResultType GetDiscipline(string CwpName, string CwpId); //usp_GetDiscipline[MTO]

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "DeleteMTOs/Multi")]
        SigmaResultType DeleteMTO(List<TypeComponent> listCom);


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EditMTO/{componentId}")]
        SigmaResultType GetComponentCustomField(string componentId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "MTOs/{componentId}")]
        SigmaResultType ListMTO(string componentId);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SaveMTOs")]
        SigmaResultType SaveMTO(TypeComponent paramObj, TypeMaterial paramObj2);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SaveMTOs")]
        SigmaResultType UpdateMTO(TypeComponent paramObj, TypeMaterial paramObj2);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentsByDrawingId/{DrawingId}")]
        SigmaResultType ListComponents(string DrawingId);//EXEC usp_ListComponentByDrawingId(After Save MTO)

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ComponentsByImportHistory/{ImportHistoryId}")]
        SigmaResultType ListComponentsByImportHistoryId(string ImportHistoryId);//EXCE usp_ListComponentImportHistoryId(After Excelfile import)

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CivilMTOs")]
        SigmaResultType ListCivilMTO();

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "CivilMTOs/Multi")]
        SigmaResultType MultiCivilMTO(List<TypeMTO> listObj);

        #endregion 

        #region MaterialCustomField

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
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "MaterialCustomFields/Multi")]
        //SigmaResultType MultiMaterialCustomField(List<TypeMaterialCustomField> listObj);

        #endregion 

        #region Assign Cost Code

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AssignmentComponentProgress")]
        SigmaResultType ListAssignmentComponentProgress();

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AssignmentComponentProgress")]
        SigmaResultType UpdateAssignmentComponentProgress(List<TypeAssignmentCostCode> listObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AssignmentComponentProgressAll")]
        SigmaResultType UpdateAssignmentComponentProgressAll(List<TypeAssignmentCostCode> listObj);

        #endregion

        #region  P6 Schedule 
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetGeneralForeManCombo")]
        SigmaResultType GetGeneralForeManCombo(); 

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetP6ProjectCombo/{userName}/{password}")]
        SigmaResultType GetP6ProjectCombo(string userName, string password); // Call P6 Project info

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ReadP6WBSManager/{projectId}/{url}/{userName}/{password}")]
        SigmaResultType ReadP6WBSManager(string projectId, string url, string userName, string password);// Read P6 & Set & Save


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ImportedSchedules/{scheduledworkitemid}")]
        SigmaResultType GetImportedSchedule(string scheduledworkitemid);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ImportedSchedules")]
        SigmaResultType ListImportedSchedule();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ImportedSchedules")]
        SigmaResultType AddImportedSchedule(TypeImportedSchedule paramObj);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ImportedSchedules")]
        SigmaResultType UpdateImportedSchedule(TypeImportedSchedule paramObj);



        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "MultiImportedSchedule")]
        SigmaResultType MultiImportedSchedule();


        #endregion

    }
}


