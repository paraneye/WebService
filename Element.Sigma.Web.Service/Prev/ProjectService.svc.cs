using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Element.Sigma.Web.Biz;
using Element.Reveal.DataLibrary;
//using Microsoft.Practices.EnterpriseLibrary.Logging;
//using Microsoft.Practices.EnterpriseLibrary.Common;

namespace Element.Sigma.Web.Service.Prev
{
    
    

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProjectService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ProjectService : IProjectService
    {
        ////Arranged by Hoon in order of relavance and name to convenient indexing
        //#region "Get, SELECT"
        ///// <summary>
        ///// Retrieve area object which area contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Progress unique identifier to search for </param>
        ///// <returns>AreaDTO</returns>
        //public AreaDTO GetAreaByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAreaByID(id);
        //}

        ///// <summary>
        ///// Retrieve area object which area contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Progress unique identifier to search for </param>
        ///// <returns>AreaDTO</returns>
        //public AreaDTO JsonGetAreaByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAreaByID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve all area objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>AreaDTO</returns>
        //public List<AreaDTO> GetAreaAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAreaAll();
        //}

        ///// <summary>
        ///// Retrieve all area objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>AreaDTO</returns>
        //public List<AreaDTO> JsonGetAreaAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAreaAll();
        //}

        ///// <summary>
        ///// Retrieve component object which component contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Progress unique identifier to search for </param>
        ///// <returns>ComponentDTO</returns>
        //public ComponentDTO GetComponentByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByID(id);
        //}

        ///// <summary>
        ///// Retrieve component object which component contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Progress unique identifier to search for </param>
        ///// <returns>ComponentDTO</returns>
        //public ComponentDTO JsonGetComponentByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve assigned component.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> GetComponentByFiwp(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByFiwp(fiwpId);
        //}

        ///// <summary>
        ///// Retrieve assigned component.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> JsonGetComponentByFiwp(string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByFiwp(Int32.Parse(fiwpId));
        //}

        ///// <summary>
        ///// Retrieve all component objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> GetComponentAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentAll();
        //}

        ///// <summary>
        ///// Retrieve all component objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> JsonGetComponentAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentAll();
        //}
        
        ///// <summary>
        ///// Retrieve component object consisted of DrawingName.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="componentid">ComponentID to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public ComponentDTO GetComponentByComponentID(int componentid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByComponentID(componentid);
        //}

        ///// <summary>
        ///// Retrieve component object consisted of DrawingName.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="componentid">ComponentID to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public ComponentDTO JsonGetComponentByComponentID(string componentid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByComponentID(Int32.Parse(componentid));
        //}

        ///// <summary>
        ///// Retrieve assigned component objects which component contains the specified RFIID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="rfiid">RFIID to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> GetComponentByRFIID(int rfiid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByRFIID(rfiid);
        //}

        ///// <summary>
        ///// Retrieve assigned component objects which component contains the specified RFIID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="rfiid">RFIID to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> JsonGetComponentByRFIID(string rfiid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByRFIID(Int32.Parse(rfiid));
        //}

        ///// <summary>
        ///// Retrieve assigned component log.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="rfiid">RFIID to search for</param>
        ///// <returns>ComponentlogDTO</returns>
        //public List<ComponentlogDTO> GetComponentlogByRFIID(int rfiid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentlogByRFIID(rfiid);
        //}

        ///// <summary>
        ///// Retrieve assigned component log.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="rfiid">RFIID to search for</param>
        ///// <returns>ComponentlogDTO</returns>
        //public List<ComponentlogDTO> JsonGetComponentlogByRFIID(string rfiid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentlogByRFIID(Int32.Parse(rfiid));
        //}

        ///// <summary>
        ///// Retrieve assigned component.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> GetComponentByCwpDrawing(int cwpId, int drawingId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByCwpDrawing(cwpId, drawingId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve assigned component.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> JsonGetComponentByCwpDrawing(string cwpId, string drawingId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByCwpDrawing(Int32.Parse(cwpId), Int32.Parse(drawingId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve component objects for assigning system.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materiacategoryId">MaterialCategoryID to search for</param>
        ///// <param name="taskLUID">TaskTypeLUID to search for (0 returns all)</param>
        ///// <param name="engTagNum">EngTagNumber to search for (null returns all)</param>
        ///// <param name="fromtoTag">FromTag/ToTag to search for (null returns all)</param>
        ///// <param name="isSystemEmpty">>Whether it was not assigned to system or all (true: not assigned, false: all)</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> GetComponentForSystem(int cwpId, int materiacategoryId, int taskLUID, string engTagNum, string fromtoTag, bool isSystemEmpty)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentForSystem(cwpId, materiacategoryId, taskLUID, engTagNum, fromtoTag, isSystemEmpty);
        //}

        //public ComponentPageTotal GetComponentForSystemByLineForPaging(int projectid, string disciplineCode, string processsystem, string line, string size, int emptysystem, int selectpage, int pagesize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentForSystemByLineForPaging(projectid, Helper.RemoveJsonParameterWrapper(disciplineCode), processsystem, line, size, emptysystem, selectpage, pagesize);
        //}

        //public ComponentPageTotal GetComponentForSystemByTaskForPaging(int projectid, string disciplineCode, int taskid, int drawingid, int systemid, int tasktypeid, int emptysystem, int selectpage, int pagesize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentForSystemByTaskForPaging(projectid, Helper.RemoveJsonParameterWrapper(disciplineCode), taskid, drawingid, systemid, tasktypeid, emptysystem, selectpage, pagesize);
        //}

        ///// <summary>
        ///// Retrieve component objects for assigning system.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materiacategoryId">MaterialCategoryID to search for</param>
        ///// <param name="taskLUID">TaskTypeLUID to search for (0 returns all)</param>
        ///// <param name="engTagNum">EngTagNumber to search for (null returns all)</param>
        ///// <param name="fromtoTag">FromTag/ToTag to search for (null returns all)</param>
        ///// <param name="isSystemEmpty">>Whether it was not assigned to system or all (true: not assigned, false: all)</param>
        ///// <returns>ComponentDTO</returns>
        //public List<ComponentDTO> JsonGetComponentForSystem(string cwpId, string materiacategoryId, string taskLUID, string engTagNum, string fromtoTag, string isSystemEmpty)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentForSystem(Int32.Parse(cwpId), Int32.Parse(materiacategoryId), Int32.Parse(taskLUID), engTagNum, fromtoTag, bool.Parse(isSystemEmpty));
        //}

        ///// <summary>
        ///// Retrieve contractor's project.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID(=OwnerID) to search for</param>
        ///// <returns>ProjectDTO</returns>
        //public List<ProjectDTO> GetContractorProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetContractorProject(projectId);
        //}

        ///// <summary>
        ///// Retrieve contractor's project.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID(=OwnerID) to search for</param>
        ///// <returns>ProjectDTO</returns>
        //public List<ProjectDTO> JsonGetContractorProject(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetContractorProject(Int32.Parse(projectId));
        //}

        public List<DocumentDTO> JsonGetUploadedFileInfoByProjectFileType(string projectId, string fileTypeCode, string fileCategory)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetUploadedFileInfoByProjectFileType(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(fileTypeCode), Helper.RemoveJsonParameterWrapper(fileCategory), Helper.GetWebrootUrl());
        }

        public List<DocumentDTO> JsonGetIwpDocumentByIwpProjectFileType(string iwpId, string projectId, string fileTypeCode, string isDisplayable, string fileCategory, string iwpDocumentId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetIwpDocumentByIwpProjectFileType(Int32.Parse(iwpId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(fileTypeCode), Helper.RemoveJsonParameterWrapper(isDisplayable), Helper.RemoveJsonParameterWrapper(fileCategory), Helper.GetWebrootUrl(), Int32.Parse(iwpDocumentId));
        }

        ///// <summary>
        ///// Retrieve document objects which document contains the specified DocumentTypeLUID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="doctypeId">DocumentTypeLUID to search for (below 0 return all)</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>DocumentDTO</returns>
        //public List<DocumentDTO> GetDocumentForFIWPByDocType(int doctypeId, int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentByFIWPDocType(doctypeId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        /// <summary>
        /// Retrieve document objects which document contains the specified DocumentTypeLUID to match.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="doctypeId">DocumentTypeLUID to search for (below 0 return all)</param>
        /// <param name="fiwpId">FIWPID to search for</param>
        /// <param name="projectId">ProjectID to search for</param>
        /// <param name="disciplineCode">DisciplineCode to search for</param>
        /// <returns>DocumentDTO</returns>
        public List<DocumentDTO> JsonGetDocumentForFIWPByDocType(string doctypeId, string fiwpId, string projectId, string disciplineCode)
        {
            return null;
            //return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentByFIWPDocType(Int32.Parse(doctypeId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        }

        ///// <summary>
        ///// Retrieve document objects which document contains the specified RFIID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="rfiId">RFIID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>DocumentDTO</returns>
        //public List<DocumentDTO> GetDocumentByRFIID(int rfiId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentByRFIID(rfiId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve document objects which document contains the specified RFIID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="rfiId">RFIID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>DocumentDTO</returns>
        //public List<DocumentDTO> JsonGetDocumentByRFIID(string rfiId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentByRFIID(Int32.Parse(rfiId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public List<DocumentDTO> GetDocumentByTurnoverPackage(string lookupValue, int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentByTurnoverPackage(lookupValue, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// GetDocumentByTurnoverPackageDocType
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="doctypeId"></param>
        ///// <param name="fiwpId"></param>
        ///// <param name="projectId"></param>
        ///// <param name="disciplineCode"></param>
        ///// <returns></returns>
        //public List<DocumentDTO> GetDocumentByTurnoverPackageDocType(int doctypeId, int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentByTurnoverPackageDocType(doctypeId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// JsonGetDocumentByTurnoverPackageDocType
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="doctypeId"></param>
        ///// <param name="fiwpId"></param>
        ///// <param name="projectId"></param>
        ///// <param name="disciplineCode"></param>
        ///// <returns></returns>
        //public List<DocumentDTO> JsonGetDocumentByTurnoverPackageDocType(string doctypeId, string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentByTurnoverPackageDocType(Int32.Parse(doctypeId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}


        ///// <summary>
        ///// Retrieve all document objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>DocumentDTO</returns>
        //public List<DocumentDTO> GetDocumentAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentAll();
        //}

        ///// <summary>
        ///// Retrieve all document objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>DocumentDTO</returns>
        //public List<DocumentDTO> JsonGetDocumentAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetDocumentAll();
        //}

        ///// <summary>
        ///// Retrieve document note object which document note contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Document note unique identifier to search for </param>
        ///// <returns>DocumentnoteDTO</returns>
        //public DocumentnoteDTO GetSingleDocumentNoteByID(int Id)
        //{
        //    return (new BALC.ScheduleReader()).GetSingleDocumentNoteByID(Id);
        //}

        ///// <summary>
        ///// Retrieve document note object which document note contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Document note unique identifier to search for </param>
        ///// <returns>DocumentnoteDTO</returns>
        //public DocumentnoteDTO JsonGetSingleDocumentNoteByID(string Id)
        //{
        //    return (new BALC.ScheduleReader()).GetSingleDocumentNoteByID(Int32.Parse(Id));
        //}

        //public FiwpDocument GetFIWPDocDrawingsByFIWP(int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFIWPDocDrawingsByFIWP(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        public DocumentAndDrawing JsonGetFIWPDocDrawingsByFIWP(string fiwpId, string projectId, string disciplineCode)
        {
            //return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).GetIWPDocDrawingsByIWP(Int32.Parse(fiwpId), Int32.Parse(projectId), disciplineCode, Helper.GetImageLocationURL());
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).GetIWPDocDrawingsByIWP(Int32.Parse(fiwpId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetWebrootUrl());
        }

        //public FiwpDocument GetFIWPDocDrawingsBySIWP(int siwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFIWPDocDrawingsBySIWP(siwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public FiwpDocument JsonGetFIWPDocDrawingsBySIWP(string siwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFIWPDocDrawingsBySIWP(Int32.Parse(siwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public FiwpDocument GetFIWPDocDrawingsByHydro(int hydroId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFIWPDocDrawingsByHydro(hydroId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public FiwpDocument JsonGetFIWPDocDrawingsByHydro(string hydroId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFIWPDocDrawingsByHydro(Int32.Parse(hydroId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        //#region CSU
        //public FiwpDocument GetFIWPDocDrawingsByCSU(int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFIWPDocDrawingsByCSU(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public FiwpDocument JsonGetFIWPDocDrawingsByCSU(string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFIWPDocDrawingsByCSU(Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}
        //#endregion

        ////LibInsul-------------------------------------------------------------

        ///// <summary>
        ///// Retrieve all Insulation Factor library objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>LibinsulfactorDTO</returns>
        //public List<LibinsulfactorDTO> GetLibinsulfactorAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulfactorAll();
        //}

        ///// <summary>
        ///// Retrieve all Insulation Fireproof library objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>LibinsulfireproofDTO</returns>
        //public List<LibinsulfireproofDTO> GetLibinsulfireproofAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulfireproofAll();
        //}

        ///// <summary>
        ///// Retrieve all Insulation PaintManhours library objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>LibinsulpaintmanhourDTO</returns>
        //public List<LibinsulpaintmanhourDTO> GetLibinsulpaintmanhourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpaintmanhourAll();
        //}

        ///// <summary>
        ///// Retrieve all Insulation PipeFactor library objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns></returns>
        //public List<LibinsulpipefactorDTO> GetLibinsulpipefactorAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpipefactorAll();
        //}

        ///// <summary>
        ///// Retrieve all Insulation PipeManhours library objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>LibinsulpipemanhourDTO</returns>
        //public List<LibinsulpipemanhourDTO> GetLibinsulpipemanhourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpipemanhourAll();
        //}

        ///// <summary>
        ///// Retrieve Insulation Factor library object which library contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Libinsulfactor unique identifier to search for </param>
        ///// <returns>LibinsulfactorDTO</returns>
        //public LibinsulfactorDTO GetLibinsulfactorByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulfactorByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Insulation Factor library object which library contains the specified FireProofID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">FireProofID to search for</param>
        ///// <returns>LibinsulfactorDTO</returns>
        //public LibinsulfactorDTO GetLibinsulfactorByFireProofID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulfactorByFireProofID(Id);
        //}

        ///// <summary>
        ///// Retrieve Insulation Fireproof library object which library contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Libinsulfireproof unique identifier to search for </param>
        ///// <returns>LibinsulfireproofDTO</returns>
        //public LibinsulfireproofDTO GetLibinsulfireproofByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulfireproofByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Insulation PaintManhours library object which library contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Libinsulpaintmanhour unique identifier to search for </param>
        ///// <returns>LibinsulpaintmanhourDTO</returns>
        //public LibinsulpaintmanhourDTO GetLibinsulpaintmanhourByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpaintmanhourByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Insulation PaintManhours library objects. (not used_20130516)
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="PaintLibTypeLUID">PaintLibTypeLUID to search for</param>
        ///// <param name="TaskTypeLUID">MethodTypeLUID to search for</param>
        ///// <param name="MaterialCategoryID">MaterialCategoryID to search for</param>
        ///// <returns>LibinsulpaintmanhourDTO</returns>
        //public List<LibinsulpaintmanhourDTO> GetLibinsulpaintmanhourByNullmaterialcategory(int PaintLibTypeLUID, int TaskTypeLUID, int MaterialCategoryID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpaintmanhourByNullmaterialcategory(PaintLibTypeLUID, TaskTypeLUID, MaterialCategoryID);
        //}

        ///// <summary>
        ///// Retrieve Insulation PipeFactor library object which library contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Libinsulpipefactor unique identifier to search for </param>
        ///// <returns>LibinsulpipefactorDTOc</returns>
        //public LibinsulpipefactorDTO GetLibinsulpipefactorByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpipefactorByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Insulation PipeManhours library object which library contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Libinsulpipemanhour unique identifier to search for </param>
        ///// <returns>LibinsulpipemanhourDTO</returns>
        //public LibinsulpipemanhourDTO GetLibinsulpipemanhourByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpipemanhourByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Insulation PipeManhours library object which library contains the specified pipesize to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="pipesize">PipeSize to search for </param>
        ///// <param name="layer">Layer to search for</param>
        ///// <returns>LibinsulpipemanhourDTO</returns>
        //public LibinsulpipemanhourDTO GetLibinsulpipemanhourBySize(decimal pipesize, int layer)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpipemanhourBySize(pipesize, layer);
        //}
        
        ///// <summary>
        ///// Retrieve Insulation Factor library objects.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of Insulation Factor object to return</param>
        ///// <param name="ShapeLUID">ShapeLUID to search for (0 returns all)</param>
        ///// <param name="UOMLUID">UOMLUID to search for (0 returns all)</param>
        ///// <param name="LibTypeLUID">LibTypeLUID to search for (0 returns all)</param>
        ///// <returns>LibinsulfactorPageTotal</returns>
        //public LibinsulfactorPageTotal GetLibinsulfactorForPaging(int selectedPage, int pageSize, int ShapeLUID, int UOMLUID, int LibTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulfactorForPaging(selectedPage, pageSize, ShapeLUID, UOMLUID, LibTypeLUID);
        //}

        ///// <summary>
        ///// Retrieve Insulation PipeFactor library objects.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of Insulation PipeFactor object to return</param>
        ///// <param name="taskCategoryID">TaskCategoryID to search for (0 returns all)</param>
        ///// <param name="materialCategoryID">MaterialCategoryID to search for (0 returns all)</param>
        ///// <param name="UOMLUID">UOMLUID to search for (0 returns all)</param>
        ///// <param name="componentTypeLUID">ComponentTypeLUID to search for (0 returns all)</param>
        ///// <returns>LibinsulpipefactorPageTotal</returns>
        //public LibinsulpipefactorPageTotal GetLibinsulpipefactorForPaging(int selectedPage, int pageSize, int taskCategoryID, int materialCategoryID, int UOMLUID, int componentTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpipefactorForPaging(selectedPage, pageSize, taskCategoryID, materialCategoryID, UOMLUID, componentTypeLUID);
        //}

        ///// <summary>
        ///// Retrieve Insulation PaintManhours library objects.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of Insulation PaintManhours object to return</param>
        ///// <param name="PaintLibTypeLUID">PaintLibTypeLUID to search for (0 returns all)</param>
        ///// <param name="TaskTypeLUID">MethodTypeLUID to search for (0 returns all)</param>
        ///// <param name="MaterialCategoryID">MaterialCategoryID to search for (0 returns all)</param>
        ///// <returns>LibinsulpaintmanhourPageTotal</returns>
        //public LibinsulpaintmanhourPageTotal GetLibinsulpaintmanhourForPaging(int selectedPage, int pageSize, int PaintLibTypeLUID, int TaskTypeLUID, int MaterialCategoryID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpaintmanhourForPaging(selectedPage, pageSize, PaintLibTypeLUID, TaskTypeLUID, MaterialCategoryID);
        //}

        ///// <summary>
        ///// Retrieve Insulation PipeManhours library objects.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of Insulation PipeManhours object to return</param>
        ///// <param name="selectoption">selectoption to search for 
        ///// (0 returns objects which PipeSize is equal to PipeSize parameter, 
        ///// 1 returns objects which PipeSize is less than PipeSize parameter, 
        ///// 2 returns objects which PipeSize is more than PipeSize parameter)</param>
        ///// <param name="pipesize">PipeSize to search for (0 returns all)</param>
        ///// <returns>LibinsulpipemanhourPageTotal</returns>
        //public LibinsulpipemanhourPageTotal GetLibinsulpipemanhourForPaging(int selectedPage, int pageSize, int selectoption, decimal pipesize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulpipemanhourForPaging(selectedPage, pageSize, selectoption, pipesize);
        //}

        ///// <summary>
        ///// Retrieve Insulation Fireproof library objects.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of Insulation Fireproof object to return</param>
        ///// <param name="FireproofTypeLUID">FireproofTypeLUID to search for (0 returns all)</param>
        ///// <param name="ComponentType">ComponentType to search for (null returns all)</param>
        ///// <returns>LibinsulfireproofPageTotal</returns>
        //public LibinsulfireproofPageTotal GetLibInsulFireProofForPaging(int selectedPage, int pageSize, int FireproofTypeLUID, string ComponentType)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibInsulFireProofForPaging(selectedPage, pageSize, FireproofTypeLUID, ComponentType);
        //}

        ///// <summary>
        ///// Retrieve Insulation Factor library objects which library contains the specified LibTypeLUID(especially Fireproof) to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>LibinsulfactorDTO</returns>
        //public List<LibinsulfactorDTO> GetLibinsulfactorForFireProof()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibinsulfactorForFireProof();
        //}

        ////----------------------------------------------------------------------

        ///// <summary>
        ///// Retrieve Documentnote objects which documentnote contains the specified DocumentID or DrawingID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="documentId">DocumentID to search for (0 returns all)</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for (0 returns all)></param>
        ///// <returns>DocumentnoteDTO</returns>
        //public List<DocumentnoteDTO> GetDocumentNoteByFiwpDocumentDrawing(int fiwpId, int documentId, int drawingId, int projectId, string disciplineCode)
        //{
        //    return (new BALC.ScheduleReader()).GetDocumentNoteByFiwpDocumentDrawing(fiwpId, documentId, drawingId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Documentnote objects which documentnote contains the specified DocumentID or DrawingID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="documentId">DocumentID to search for (0 returns all)</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for (0 returns all)></param>
        ///// <returns>DocumentnoteDTO</returns>
        //public List<DocumentnoteDTO> JsonGetDocumentNoteByFiwpDocumentDrawing(string fiwpId, string documentId, string drawingId, string projectId, string disciplineCode)
        //{
        //    return (new BALC.ScheduleReader()).GetDocumentNoteByFiwpDocumentDrawing(Int32.Parse(fiwpId), Int32.Parse(documentId), Int32.Parse(drawingId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Documentnote objects which documentnote contains the specified SPCollectionID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="SPCollectionID">SPCollectionID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>DocumentnoteDTO</returns>
        //public List<DocumentnoteDTO> GetDocumentNoteBySPColletctionID(int SPCollectionID, int projectId, string disciplineCode)
        //{
        //    return (new BALC.ScheduleReader()).GetDocumentNoteBySPColletctionID(SPCollectionID, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Documentnote objects which documentnote contains the specified SPCollectionID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="SPCollectionID">SPCollectionID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>DocumentnoteDTO</returns>
        //public List<DocumentnoteDTO> JsonGetDocumentNoteBySPColletctionID(string SPCollectionID, string projectId, string disciplineCode)
        //{
        //    return (new BALC.ScheduleReader()).GetDocumentNoteBySPColletctionID(Int32.Parse(SPCollectionID), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        /// <summary>
        /// JsonGetDrawingStickyNoteByDrawing (prev : JsonGetDocumentNoteByDrawing)
        /// </summary>
        /// <param name="drawingId"></param>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        public List<DrawingStickyNoteDTO> JsonGetDrawingStickyNoteByDrawing(string drawingId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).GetDrawingStickyNoteByDrawing(Int32.Parse(drawingId), Int32.Parse(projectId), disciplineCode);
        }
        
        ///// <summary>
        ///// Retrieve Fiwpdocordinal objects which fiwpdocordinal contains the specified FIWPID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for (0 returns all)</param>
        ///// <param name="fiwpId">FIWPID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>FiwpdocordinalDTO</returns>
        //public List<FiwpdocordinalDTO> GetFiwpDocordinalByFiwp(int projectscheduleId, int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFiwpdocordinalByFIWP(projectscheduleId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Fiwpdocordinal objects which fiwpdocordinal contains the specified FIWPID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for (0 returns all)</param>
        ///// <param name="fiwpId">FIWPID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>FiwpdocordinalDTO</returns>
        //public List<FiwpdocordinalDTO> JsonGetFiwpDocordinalByFiwp(string projectscheduleId, string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFiwpdocordinalByFIWP(Int32.Parse(projectscheduleId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Fiwpwfp objects which fiwpwfp contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Fiwpwfp unique identifier to search for </param>
        ///// <param name="projectId">ProjectID to search for (not used: null)</param>
        ///// <param name="disciplineCode">DisciplineCode to search for (not used: null)</param>
        ///// <returns>FiwpwfpDTO</returns>
        //public List<FiwpwfpDTO> GetFiwpWFPByFIWP(int id, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpWFPByFIWP(id, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Fiwpwfp objects which fiwpwfp contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Fiwpwfp unique identifier to search for</param>
        ///// <param name="projectId">ProjectID to search for (not used: null)</param>
        ///// <param name="disciplineCode">DisciplineCode to search for (not used: null)</param>
        ///// <returns>FiwpwfpDTO</returns>
        //public List<FiwpwfpDTO> JsonGetFiwpWFPByFIWP(string id, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpWFPByFIWP(Int32.Parse(id), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Fiwpequip objects which fiwpequip contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Fiwpequip unique identifier to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>FiwpequipDTO</returns>
        //public List<FiwpequipDTO> GetFiwpEquipByFIWP(int id, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpEquipByFIWP(id, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        /// <summary>
        /// Retrieve Fiwpequip objects which fiwpequip contains the specified unique identifier to match.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="iwpId">Fiwpequip unique identifier to search for</param>        
        /// <returns>FiwpequipDTO</returns>
        public List<FiwpequipDTO> JsonGetFiwpEquipByFIWP(string iwpId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetFiwpEquipByFIWP(Int32.Parse(iwpId));
        }

        ///// <summary>
        ///// Retrieve Fiwpmanonsite objects which fiwpmanonsite contains the specified ForemanDepartStructureID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="foremanStructureId">ForemanDepartStructureID to search for</param>
        ///// <param name="workdate">WorkDate to search for</param>
        ///// <returns>FiwpmanonsiteDTO</returns>
        //public List<FiwpmanonsiteDTO> GetFiwpManonsiteByForeman(int foremanStructureId, DateTime workdate)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFiwpManonsiteByForeman(foremanStructureId, workdate);
        //}

        ///// <summary>
        ///// Retrieve Fiwpmanonsite objects which fiwpmanonsite contains the specified ForemanDepartStructureID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="foremanStructureId">ForemanDepartStructureID to search for</param>
        ///// <param name="workdate">WorkDate to search for</param>
        ///// <returns>FiwpmanonsiteDTO</returns>
        //public List<FiwpmanonsiteDTO> JsonGetFiwpManonsiteByForeman(string foremanStructureId, string workdate)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFiwpManonsiteByForeman(Int32.Parse(foremanStructureId), DateTime.Parse(workdate));
        //}

        ///// <summary>
        ///// Retrieve all Material objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>MaterialDTO</returns>
        //public List<MaterialDTO> GetMaterialAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialAll();
        //}

        //public List<MaterialDTO> GetMaterialByMaterialCategory(int materialcategoryId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialByMaterialCategory(materialcategoryId);
        //}

        ///// <summary>
        ///// Retrieve all Material objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>MaterialDTO</returns>
        //public List<MaterialDTO> JsonGetMaterialAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialAll();
        //}

        ///// <summary>
        ///// Retrieve MaterialCable objects which materialcable contains the specified MaterialCategoryID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MaterialCableDTO</returns>
        //public List<MaterialCableDTO> GetMaterialCableByMaterialCategory(int materialCategoryId, int cwpId, int drawingId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCableByMaterialCategory(materialCategoryId, cwpId, drawingId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve MaterialCable objects which materialcable contains the specified MaterialCategoryID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MaterialCableDTO</returns>
        //public List<MaterialCableDTO> JsonGetMaterialCableByMaterialCategory(string materialCategoryId, string cwpId, string drawingId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCableByMaterialCategory(Int32.Parse(materialCategoryId), Int32.Parse(cwpId), Int32.Parse(drawingId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve MaterialCable objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="filterName">FilterName to search for</param>
        ///// <param name="filterValue">FilterValue to search for</param>
        ///// <returns>MaterialCableDTO</returns>
        //public List<MaterialCableDTO> GetMaterialCableByAny(int cwpId, int fiwpId, int projectId, string disciplineCode, string filterName, string filterValue)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCableByAny(cwpId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), filterName, filterValue);
        //}

        ///// <summary>
        ///// Retrieve MaterialCable objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="filterName">FilterName to search for</param>
        ///// <param name="filterValue">FilterValue to search for</param>
        ///// <returns>MaterialCableDTO</returns>
        //public List<MaterialCableDTO> JsonGetMaterialCableByAny(string cwpId, string fiwpId, string projectId, string disciplineCode, string filterName, string filterValue)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCableByAny(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), filterName, filterValue);
        //}

        ///// <summary>
        ///// Retrieve MaterialRaceway objects which materialraceway contains the specified MaterialCategoryID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MaterialRacewayDTO</returns>
        //public List<MaterialRacewayDTO> GetMaterialRacewayByMaterialCategory(int materialCategoryId, int cwpId, int drawingId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialRacewayByMaterialCategory(materialCategoryId, cwpId, drawingId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve MaterialRaceway objects which materialraceway contains the specified MaterialCategoryID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MaterialRacewayDTO</returns>
        //public List<MaterialRacewayDTO> JsonGetMaterialRacewayByMaterialCategory(string materialCategoryId, string cwpId, string drawingId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialRacewayByMaterialCategory(Int32.Parse(materialCategoryId), Int32.Parse(cwpId), Int32.Parse(drawingId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Material objects which material contains the specified MaterialCategoryID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MaterialDTO</returns>
        //public List<MaterialDTO> GetMaterialCommonByMaterialCategory(int materialCategoryId, int cwpId, int drawingId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCommonByMaterialCategory(materialCategoryId, cwpId, drawingId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Material objects which material contains the specified MaterialCategoryID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MaterialDTO</returns>
        //public List<MaterialDTO> JsonGetMaterialCommonByMaterialCategory(string materialCategoryId, string cwpId, string drawingId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCommonByMaterialCategory(Int32.Parse(materialCategoryId), Int32.Parse(cwpId), Int32.Parse(drawingId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve MaterialCable object which materialcable contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">MaterialID to search for</param>
        ///// <returns>MaterialCableDTO</returns>
        //public MaterialCableDTO GetMaterialCableByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCableByID(id);
        //}

        ///// <summary>
        ///// Retrieve MaterialCable object which materialcable contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">MaterialID to search for</param>
        ///// <returns>MaterialCableDTO</returns>
        //public MaterialCableDTO JsonGetMaterialCableByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialCableByID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve Material object which material contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">MaterialID to search for</param>
        ///// <returns>MaterialDTO</returns>
        //public MaterialDTO GetMaterialByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialByID(id);
        //}

        ///// <summary>
        ///// Retrieve Material object which material contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">MaterialID to search for</param>
        ///// <returns>MaterialDTO</returns>
        //public MaterialDTO JsonGetMaterialByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialByID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve Material object which material contains the specified ComponentID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="componentId">ComponentID to search for</param>
        ///// <returns>MaterialDTO</returns>
        //public MaterialDTO GetMaterialByComponentID(int componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialByComponentID(componentId);
        //}

        ///// <summary>
        ///// Retrieve Material object which material contains the specified ComponentID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="componentId">ComponentID to search for</param>
        ///// <returns>MaterialDTO</returns>
        //public MaterialDTO JsonGetMaterialByComponentID(string componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialByComponentID(Int32.Parse(componentId));
        //}
        
        ///// <summary>
        ///// Retrieve all Plant objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>PlantDTO</returns>
        //public List<PlantDTO> GetPlantAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPlantAll();
        //}

        ///// <summary>
        ///// Retrieve all Plant objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>PlantDTO</returns>
        //public List<PlantDTO> JsonGetPlantAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPlantAll();
        //}

        ///// <summary>
        ///// Retrieve Project object which project contains the specified unique identifier to match. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Project unique identifier to search for</param>
        ///// <returns>ProjectDTO</returns>
        //public ProjectDTO GetProjectById(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectByID(id);
        //}

        /// <summary>
        /// Retrieve Project object which project contains the specified unique identifier to match. 
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="id">Project unique identifier to search for</param>
        /// <returns>ProjectDTO</returns>
        public ProjectDTO JsonGetProjectById(string id)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetProjectByID(Int32.Parse(id));
        }

        ///// <summary>
        ///// Retrieve ProjectAndModule object which projectAndModule contains the specified ProjectID to match. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">ProjectID to search for</param>
        ///// <returns>ProjectAndModule</returns>
        //public ProjectAndModule GetProjectAndModulesById(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectAndModulesByID(id);
        //}

        ///// <summary>
        ///// Retrieve ProjectAndModule object which projectAndModule contains the specified ProjectID to match. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">ProjectID to search for</param>
        ///// <returns>ProjectAndModule</returns>
        //public ProjectAndModule JsonGetProjectAndModulesById(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectAndModulesByID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve all ProjectModule objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>ProjectmoduleDTO</returns>
        //public List<ProjectmoduleDTO> GetProjectAllModule()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAllProjectModules();
        //}

        //public List<ProjectmoduleDTO> GetAllProjectAndModules()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAllProjectAndModules();
        //}

        /// <summary>
        /// Retrieve all ProjectModule objects.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <returns>ProjectmoduleDTO</returns>
        public List<ProjectmoduleDTO> JsonGetProjectAllModule()
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetProjectAllModules();
        }

        ///// <summary>
        ///// Retrieve ProjectModule objects which projectModule contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>ProjectmoduleDTO</returns>
        //public List<ProjectmoduleDTO> GetProjectModuleByProjectID(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectModulesByProjectID(projectId);
        //}

        ///// <summary>
        ///// Retrieve ProjectModule objects which projectModule contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>ProjectmoduleDTO</returns>
        //public List<ProjectmoduleDTO> JsonGetProjectModuleByProjectID(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectModulesByProjectID(Int32.Parse(projectId));
        //}

        ///// <summary>
        ///// Retrieve ProjectModule objects which projectModule contains the specified ProjectID and LoginName to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="logindId">LoginName to search for</param>
        ///// <returns>ProjectmoduleDTO</returns>
        //public List<ProjectmoduleDTO> JsonGetProjectModuleByProjectIDLoginID(string projectId, string logindId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectModulesByProjectIDLoginID(Int32.Parse(projectId), logindId);
        //}

        ///// <summary>
        ///// Retrieve all Project objects. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>ProjectDTO</returns>
        //public List<ProjectDTO> GetProjectAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectAll();
        //}

        /// <summary>
        /// Retrieve all Project objects.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <returns>ProjectDTO</returns>
        public List<ProjectDTO> JsonGetProjectAll()
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetProjectAll();
        }

        public List<ProjectDTO> JsonGetProjectBySigmauser(string sigmaUserId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Common()).GetProjectBySigmauser(sigmaUserId);
        }

        ///// <summary>
        ///// Retrieve Weather objects which weather contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>WeatherDTO</returns>
        //public List<WeatherDTO> GetWeatherByProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetWeatherByProject(projectId);
        //}

        ///// <summary>
        ///// Retrieve Weather objects which weather contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>WeatherDTO</returns>
        //public List<WeatherDTO> JsonGetWeatherByProject(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetWeatherByProject(Int32.Parse(projectId));
        //}

        ///// <summary>
        ///// Retrieve Project object which project contains the specified ProjectID to match and related SharePoint URL.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>ProjectDTO</returns>
        //public ProjectDTO GetProjectSPURLByProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectSPURL(projectId);
        //}

        ///// <summary>
        ///// Retrieve PhysicalPath of files which location contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>string</returns>
        //public string GetProjectIFCImagePathByProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectPath(projectId, "IFCImagePath", Helper.GetImagePhysicalPath());
        //}

        ///// <summary>
        ///// Retrieve URL of files which location contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>string</returns>
        //public string GetProjectImageURLByProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectPath(projectId, "URL", Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// Retrieve ProjectWizard object which projectWizard contains the specified ProjectID to match. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">ProjectID to search for</param>
        ///// <returns>ProjectWizard</returns>
        //public ProjectWizard GetProjectWizardByProject(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectWizardByID(id);
        //}

        //#region "Costcode"

        ///// <summary>
        ///// Retrieve Costcode objects which costcode contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Costcode unique identifier to search for</param>
        ///// <returns>CostcodeDTO</returns>
        //public List<CostcodeDTO> GetCostcodeByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Costcode objects which costcode contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Costcode unique identifier to search for</param>
        ///// <returns>CostcodeDTO</returns>
        //public List<CostcodeDTO> JsonGetCostcodeByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeByID(Int32.Parse(Id));
        //}

        ///// <summary>
        ///// Retrieve Costcode objects which costcode contains the specified CostCode to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="CostCode">CostCode to search for</param>
        ///// <returns>CostcodeDTO</returns>
        //public List<CostcodeDTO> GetCostCodeByCostCode(string CostCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeByCostCode(CostCode);
        //}

        ///// <summary>
        ///// Retrieve Costcode objects which costcode contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for (not used: null)</param>
        ///// <param name="disciplineCode">DisciplineCode to search for (not used: null)</param>
        ///// <returns>CostcodeDTO</returns>
        //public List<CostcodeDTO> GetCostcodeByProjectID(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeByProjectID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Costcode objects which costcode contains the specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for (not used: null)</param>
        ///// <param name="disciplineCode">DisciplineCode to search for (not used: null)</param>
        ///// <returns>CostcodeDTO</returns>
        //public List<CostcodeDTO> JsonGetCostcodeByProjectID(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeByProjectID(Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure objects which costcodestructure contains the specified ProjectScheduleID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> GetCostcodeByProjectschedule(int projectId, int projectscheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostcodeByProjectschedule(projectId, projectscheduleId);
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure objects which costcodestructure contains the specified ProjectScheduleID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> JsonGetCostcodeByProjectschedule(string projectId, string projectscheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostcodeByProjectschedule(Int32.Parse(projectId), Int32.Parse(projectscheduleId));
        //}

        ///// <summary>
        ///// Retrieve all Costcode objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>CostcodeDTO</returns>
        //public List<CostcodeDTO> GetCostcodeAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeAll();
        //}

        ///// <summary>
        ///// Retrieve all Costcode objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>CostcodeDTO</returns>
        //public List<CostcodeDTO> JsonGetCostcodeAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeAll();
        //}

        //#endregion "End Costcode"

        //#region "CostCodeLocked"

        ///// <summary>
        ///// Retrieve Costcodelocked objects which costcodelocked contains specified CWPID and CostCodeID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="costcodeId">CostCodeID to search for</param>
        ///// <returns>CostcodelockedDTO</returns>
        //public List<CostcodelockedDTO> GetCostcodelockedByCwpCostcode(int cwpId, int costcodeId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostcodelockedByCwpCostcode(cwpId, costcodeId);
        //}

        ///// <summary>
        ///// Retrieve Costcodelocked objects which costcodelocked contains specified CWPID and CostCodeID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="costcodeId">CostCodeID to search for</param>
        ///// <returns>CostcodelockedDTO</returns>
        //public List<CostcodelockedDTO> JsonGetCostcodelockedByCwpCostcode(string cwpId, string costcodeId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostcodelockedByCwpCostcode(Int32.Parse(cwpId), Int32.Parse(costcodeId));
        //}

        ///// <summary>
        ///// Retrieve Costcodelocked objects which costcodelocked contains specified CWPID and ProgressID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="progressId">ProgressID to search for</param>
        ///// <returns>CostcodelockedDTO</returns>
        //public List<CostcodelockedDTO> GetCostcodelockedByCwpProgress(int cwpId, int progressId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostcodelockedByCwpProgress(cwpId, progressId);
        //}

        ///// <summary>
        ///// Retrieve Costcodelocked objects which costcodelocked contains specified CWPID and ProgressID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="progressId">ProgressID to search for</param>
        ///// <returns>CostcodelockedDTO</returns>
        //public List<CostcodelockedDTO> JsonGetCostcodelockedByCwpProgress(string cwpId, string progressId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostcodelockedByCwpProgress(Int32.Parse(cwpId), Int32.Parse(progressId));
        //}

        //#endregion "CostCodeLocked"

        //#region "Costcodestructure"

        ///// <summary>
        ///// Retrieve Costcodestructure object which costcodestructure contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Costcodestructure unique identifier to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public CostcodestructureDTO GetCostcodestructureByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeStructureByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure object which costcodestructure contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Costcodestructure unique identifier to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public CostcodestructureDTO JsonGetCostcodestructureByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeStructureByID(Int32.Parse(Id));
        //}

        ///// <summary>
        ///// Retrieve all Costcodestructure objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> GetCostcodestructureAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeStructureAll();
        //}

        ///// <summary>
        ///// Retrieve all Costcodestructure objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> JsonGetCostcodestructureAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeStructureAll();
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure objects which costcodestructure contains specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> GetProjectScheduleCostCodeByProjectID(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectScheduleCostCodeByProjectID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure objects which costcodestructure contains specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> JsonGetProjectScheduleCostCodeByProjectID(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectScheduleCostCodeByProjectID(Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure objects which costcodestructure contains specified CWPID, CostCodeID, ProjectID and CostcodeLocked state to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="costcodeId">CostCodeID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="excludeLocked">ExcludeLocked to search for (0:not exclude locked costcode, others: exclude locked costcode)(</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> GetCostcodestructureByCwpCostcode(int cwpId, int costcodeId, int projectId, int excludeLocked)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostcodestructureByCwpCostcode(cwpId, costcodeId, projectId, excludeLocked);
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure objects which costcodestructure contains specified ProjectID and CWPID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> GetProjectScheduleFiwpByCWPProjectID(int projectId, string disciplineCode, int cwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectScheduleFiwpByCWPProjectID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), cwpId);
        //}

        ///// <summary>
        ///// Retrieve Costcodestructure objects which costcodestructure contains specified ProjectID and CWPID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <returns>CostcodestructureDTO</returns>
        //public List<CostcodestructureDTO> JsonGetProjectScheduleFiwpByCWPProjectID(string projectId, string disciplineCode, string cwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectScheduleFiwpByCWPProjectID(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(cwpId));
        //}

        //#endregion "End Costcodestructure"

        //#region "Costcodestructail"

        ///// <summary>
        ///// Retrieve Costcodetale object which costcodetale contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Costcodetale unique identifier to search for</param>
        ///// <returns>CostcodetaleDTO</returns>
        //public CostcodetaleDTO GetCostcodetaleByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeTaleByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Costcodetale object which costcodetale contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Costcodetale unique identifier to search for</param>
        ///// <returns>CostcodetaleDTO</returns>
        //public CostcodetaleDTO JsonGetCostcodetaleByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeTaleByID(Int32.Parse(Id));
        //}

        ///// <summary>
        ///// Retrieve all Costcodetale objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>CostcodetaleDTO</returns>
        //public List<CostcodetaleDTO> GetCostcodetaleAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeTaleAll();
        //}

        ///// <summary>
        ///// Retrieve all Costcodetale objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>CostcodetaleDTO</returns>
        //public List<CostcodetaleDTO> JsonGetCostcodetaleAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeTaleAll();
        //}

        ///// <summary>
        ///// Retrieve Costcodetale objects which costcodetale contains specified CostCodeID th match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="costcodeId">CostCodeID to search for</param>
        ///// <returns>CostcodetaleDTO</returns>
        //public List<CostcodetaleDTO> GetCostcodetaleByCostCodeID(int costcodeId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeTaleByCostCodeID(costcodeId);
        //}

        ///// <summary>
        ///// Retrieve Costcodetale objects which costcodetale contains specified CostCodeID th match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="costcodeId">CostCodeID to search for</param>
        ///// <returns>CostcodetaleDTO</returns>
        //public List<CostcodetaleDTO> JsonGetCostcodetaleByCostCodeID(string costcodeId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCostCodeTaleByCostCodeID(Int32.Parse(costcodeId));
        //}

        //#endregion "End Costcodestructail"

        //#region "CWA"

        ///// <summary>
        ///// Retrieve CWA objects which cwa contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">CWA unique identifier to search for</param>
        ///// <returns>CwaDTO</returns>
        //public List<CwaDTO> GetCWAByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwaByCwaID(id);
        //}

        ///// <summary>
        ///// Retrieve CWA objects which cwa contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">CWA unique identifier to search for</param>
        ///// <returns>CwaDTO</returns>
        //public List<CwaDTO> JsonGetCWAByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwaByCwaID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve CWA objects which cwa contains specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">ProjectID to search for</param>
        ///// <returns>CwaDTO</returns>
        //public List<CwaDTO> GetCWAByProjectID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwaByProjectID(id);
        //}

        ///// <summary>
        ///// Retrieve CWA objects which cwa contains specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">ProjectID to search for</param>
        ///// <returns>CwaDTO</returns>
        //public List<CwaDTO> JsonGetCWAByProjectID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwaByProjectID(Int32.Parse(id));
        //}

        //#endregion "End CWA"

        //#region "CWP"

        ///// <summary>
        ///// Retrieve CWP object which cwp contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">CWP unique identifier to search for</param>
        ///// <returns>CwpDTO</returns>
        //public CwpDTO GetCWPByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwpsByID(id);
        //}

        ///// <summary>
        ///// Retrieve CWP object which cwp contains specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">CWP unique identifier to search for</param>
        ///// <returns>CwpDTO</returns>
        //public CwpDTO JsonGetCWPByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwpsByID(Int32.Parse(id));
        //}

        /// <summary>
        /// Retrieve CWP objects which cwp contains specified ProjectID to match.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="id">ProjectID to search for</param>
        /// <param name="disciplineCode">DisciplineCode to search for</param>
        /// <returns>CwpDTO</returns>
        public List<CwpDTO> JsonGetCWPsByProjectID(string projectId, string disciplineCode, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetCwpsByProjectID(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.RemoveJsonParameterWrapper(userId));
        }
        
        //public List<CwpDTO> GetCwpByProject(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwpByProject(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<CwpDTO> JsonGetCwpByProject(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwpByProject(Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public List<CwpDTO> GetCwpByProjectPackageType(int projectId, string disciplineCode, int packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwpByProjectPackageType(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), packagetypeLuid);
        //}

        public List<CwpDTO> JsonGetCwpByProjectPackageType(string projectId, string disciplineCode, string packageTypeCode, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetCwpByProjectPackageType(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.RemoveJsonParameterWrapper(packageTypeCode), Helper.RemoveJsonParameterWrapper(userId));
        }

        ///// <summary>
        ///// Retrieve CWP objects which cwp contains specified CWAID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwaId">CWAID to search for</param>
        ///// <returns>CwpDTO</returns>
        //public List<CwpDTO> GetCWPsByCWAID(int cwaId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCwpsByCWAID(cwaId);
        //}

        //#endregion "End CWP"

        //#region "CostCode"

        ///// <summary>
        ///// Retrieve Projectcostcode objects which projectcostcode contains specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpid">CWPID to search for (0 returns all)</param>
        ///// <returns>ProjectcostcodeDTO</returns>
        //public List<ProjectcostcodeDTO> GetProjectCostCodeManHoursByProjectId(int id, string disciplineCode, int cwpid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectCostCodeManHoursByProjectId(id, Helper.RemoveJsonParameterWrapper(disciplineCode), cwpid);
        //}

        ///// <summary>
        ///// Retrieve Projectcostcode objects which projectcostcode contains specified ProjectID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpid">CWPID to search for (0 returns all)</param>
        ///// <returns>ProjectcostcodeDTO</returns>
        //public List<ProjectcostcodeDTO> JsonGetProjectCostCodeManHoursByProjectId(string id, string disciplineCode, string cwpid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProjectCostCodeManHoursByProjectId(Int32.Parse(id), Int32.Parse(disciplineCode), Int32.Parse(cwpid));
        //}

        //#endregion "End CostCode"

        //#region "Drawing"

        //public string GetPivotViewerDrawingsURL(int id)
        //{
        //    if (id == 10)
        //        return @"http://192.168.101.107/Element.Reveal.Server.WS/VRUPivotViewer.cxml";
        //    else
        //        return @"http://192.168.101.107/Element.Reveal.Server.WS/IFC_Images/Mosiac/MosiacPivotCollection.cxml";

        //}

        //public string JsonGetPivotViewerDrawingsURL(string id)
        //{
        //    if (Int32.Parse(id) == 10)
        //        return @"http://192.168.101.107/Element.Reveal.Server.WS/VRUPivotViewer.cxml";
        //    else
        //        return @"http://192.168.101.107/Element.Reveal.Server.WS/IFC_Images/Mosiac/MosiacPivotCollection.cxml";

        //}

        //public List<DrawingDTO> GetDrawingAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingAll();
        //}

        //public List<DrawingDTO> JsonGetDrawingAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingAll();
        //}

        //public DrawingDTO GetDrawingByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByID(Id);
        //}

        //public DrawingDTO JsonGetDrawingByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByID(Int32.Parse(Id));
        //}

        //public List<DrawingDTO> GetDrawingsByProjectID(int Id, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingsByProjectID(Id, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> JsonGetDrawingsByProjectID(string Id, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingsByProjectID(Int32.Parse(Id), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public DrawingDTO GetDrawingByDrawingName(string drawingName, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByDrawingName(drawingName, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public DrawingDTO JsonGetDrawingByDrawingName(string drawingName, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByDrawingName(drawingName, Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> GetDrawingByDrawingType(int drawingTypeLuid, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByDrawingType(drawingTypeLuid, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> JsonGetDrawingByDrawingType(string drawingTypeLuid, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByDrawingType(Int32.Parse(drawingTypeLuid), Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> GetDrawingByDrawingType_Combo(int drawingTypeLuid, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByDrawingType_Combo(drawingTypeLuid, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> JsonGetDrawingByDrawingType_Combo(string drawingTypeLuid, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByDrawingType_Combo(Int32.Parse(drawingTypeLuid), Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        //public List<DrawingrevisionDTO> GetDrawingRevisionByProjectID(int Id, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingRevisionByProjectID(Id);
        //}

        //public List<DrawingrevisionDTO> JsonGetDrawingRevisionByProjectID(string Id, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingRevisionByProjectID(Int32.Parse(Id));
        //}

        //public List<DrawingrevisionDTO> GetDrawingrevisionByDrawing(int drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingrevisionByDrawing(drawingId);
        //}

        //public List<DrawingrevisionDTO> JsonGetDrawingrevisionByDrawing(string drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingrevisionByDrawing(Int32.Parse(drawingId));
        //}

        //public List<DrawingrevisionDTO> GetDrawingrevisionByDrawingFileUrl(string drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingrevisionByDrawingFileUrl(drawingId);
        //}

        //public List<DrawingrevisionDTO> JsonGetDrawingrevisionByDrawingFileUrl(string drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingrevisionByDrawingFileUrl(drawingId);
        //}

        //public List<DrawingDTO> GetDrawingByCWP(int cwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByCWP(cwpId, Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> JsonGetDrawingByCWP(string cwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByCWP(Int32.Parse(cwpId), Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> GetDrawingByRFIId(int projectid, string disciplineCode, int rfiid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByRFIId(projectid, Helper.RemoveJsonParameterWrapper(disciplineCode), rfiid);
        //}

        //public List<DrawingDTO> GetDrawingByCWP_DrawingName(int cwpId, string strSearch)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByCWP_DrawingName(cwpId, strSearch, Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> JsonGetDrawingByCWP_DrawingName(string cwpId, string strSearch)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByCWP_DrawingName(Int32.Parse(cwpId), strSearch, Helper.GetImageLocationURL());
        //}

        //public DrawingPageTotal GetDrawingByCWP_DrawingNameForPaging(int cwpId, string strSearch, int selectedPage, int pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByCWP_DrawingNameForPaginig(cwpId, strSearch, Helper.GetImageLocationURL(), selectedPage, pageSize);

        //}

        //public DrawingPageTotal JsonGetDrawingByCWP_DrawingNameForPaging(string cwpId, string strSearch, string selectedPage, string pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByCWP_DrawingNameForPaginig(Int32.Parse(cwpId), strSearch, Helper.GetImageLocationURL(), Int32.Parse(selectedPage), Int32.Parse(pageSize));

        //}

        //public List<DrawingDTO> GetDrawingsByFIWP(int fiwpId, int drawingtype)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByFIWP(fiwpId, drawingtype, Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> JsonGetDrawingsByFIWP(string fiwpId, string drawingtype)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByFIWP(Int32.Parse(fiwpId), Int32.Parse(drawingtype), Helper.GetImageLocationURL());
        //}

        public List<DrawingDTO> JsonGetDrawingByIwp(string iwpId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.TimeProgress()).GetDrawingByIwp(Int32.Parse(iwpId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<DrawingDTO> GetAllDrawingsByFIWP(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAllDrawingByFIWP(fiwpId, Helper.GetImageLocationURL());
        //}

        //public List<DrawingDTO> JsonGetAllDrawingsByFIWP(string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAllDrawingByFIWP(Int32.Parse(fiwpId), Helper.GetImageLocationURL());
        //}

        //public List<DrawingreferenceDTO> GetDrawingReferenceByDrawingID(int drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingReferenceByDrawingID(drawingId);
        //}

        //public List<DrawingreferenceDTO> JsonGetDrawingReferenceByDrawingID(string drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingReferenceByDrawingID(Int32.Parse(drawingId));
        //}

        //public List<DrawingsdrefDTO> GetDrawingsdrefByDrawingID(int drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingsdrefByDrawingID(drawingId);
        //}

        //public List<DrawingsdrefDTO> JsonGetDrawingsdrefByDrawingID(string drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingsdrefByDrawingID(Int32.Parse(drawingId));
        //}

        //public List<DrawingcwpDTO> GetDrawingCWPByDrawingID(int drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingCWPByDrawingId(drawingId);
        //}

        //public List<DrawingcwpDTO> JsonGetDrawingCWPByDrawingID(string drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingCWPByDrawingId(Int32.Parse(drawingId));
        //}

        //public List<DrawingcwpDTO> GetDrawingCWPByProject(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingCWPByProject(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<DrawingcwpDTO> JsonGetDrawingCWPByProject(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingCWPByProject(Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public DrawingPageTotal GetDrawingForDrawingViewer(int projectId, List<int> cwpId, List<int> fiwpId, List<int> drawingtype, string engtag, string title, string sortOption, int currpage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingForDrawingViewer(projectId, cwpId, fiwpId, drawingtype, engtag, title, sortOption, currpage, Int32.Parse(Helper.DrawingPageSize), Helper.GetImageLocationURL());
        //}

        public DrawingPageTotal JsonGetDrawingForDrawingViewer(string projectId, string cwpIds, string fiwpIds, string drawingtypes, string engtag, string title, string sortOption, string currpage, string pagesize)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).GetDrawingForDrawingViewer(Int32.Parse(projectId), Helper.GetIntParameter(cwpIds), Helper.GetIntParameter(fiwpIds), Helper.GetIntParameter(drawingtypes), Helper.RemoveJsonParameterWrapper(engtag), Helper.RemoveJsonParameterWrapper(title), Helper.RemoveJsonParameterWrapper(sortOption), Int32.Parse(currpage), Int32.Parse(pagesize), Helper.GetWebrootUrl());
        }

        //public DrawingDTO GetDrawingBySPCollectionID(int spcollectionId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingBySPCollectionID(spcollectionId);
        //}

        //public DrawingDTO JsonGetDrawingBySPCollectionID(string spcollectionId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingBySPCollectionID(Int32.Parse(spcollectionId));
        //}

        //public List<DrawingDTO> GetDrawingBySPCollectionIDs(int projectId, string disciplineCode, List<int> spcollectionId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingBySPCollectionIDs(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), spcollectionId);
        //}

        //public List<DrawingDTO> JsonGetDrawingBySPCollectionIDs(string projectId, string disciplineCode, string spcollectionId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingBySPCollectionIDs(Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetIntParameter(spcollectionId));
        //}

        //#endregion "End Drawing"

        //#region "RFIDrawing"
        //public RfidrawingDTO GetRfiDrawingByRfidrawing(int rfiid, int drawingid, int cwpid, string revisionno)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiDrawingByRfidrawing(rfiid, drawingid, cwpid, revisionno);
        //}

        //public RfidrawingDTO JsonGetRfiDrawingByRfidrawing(string rfiid, string drawingid, string cwpid, string revisionno)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiDrawingByRfidrawing(Int32.Parse(rfiid), Int32.Parse(drawingid), Int32.Parse(cwpid), revisionno);
        //}

        //public RfidrawingDTO GetRfiDrawingByID(int rfidrawingid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiDrawingByID(rfidrawingid);
        //}

        //public RfidrawingDTO JsonGetRfiDrawingByID(string rfidrawingid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiDrawingByID(Int32.Parse(rfidrawingid));
        //}

        //#endregion "RFIDrawing"

        //#region "TagNumber Drawing"

        //public List<TagnumberdrawingDTO> GetTagnumberdrawingByComponent(int componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetTagnumberdrawingByComponent(componentId);
        //}

        //public List<TagnumberdrawingDTO> JsonGetTagnumberdrawingByComponent(string componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetTagnumberdrawingByComponent(Int32.Parse(componentId));
        //}

        //#endregion "End TagNumber Drawing"

        //#region "System"

        //public List<SystemDTO> GetSystemByProjectID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSystemByProjectID(id);
        //}

        //public List<SystemDTO> JsonGetSystemByProjectID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSystemByProjectID(Int32.Parse(id));
        //}

        //public List<SystemDTO> GetSystemByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSystemByID(id);
        //}

        //public List<SystemDTO> JsonGetSystemByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSystemByID(Int32.Parse(id));
        //}

        //public SystemDTO GetSingleSystemByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSingleSystemByID(id);
        //}

        //public SystemDTO JsonGetSingleSystemByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSingleSystemByID(Int32.Parse(id));
        //}

        //#endregion "End System"

        //#region "Scaffold"

        //public ScaffoldDTO GetScaffoldByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldByID(id);
        //}

        //public ScaffoldDTO JsonGetScaffoldByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldByID(Int32.Parse(id));
        //}

        //public List<ScaffoldrequestDTO> GetScaffoldRequestByProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldRequestByProject(projectId);
        //}

        //public List<ScaffoldrequestDTO> JsonGetScaffoldRequestByProject(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldRequestByProject(Int32.Parse(projectId));
        //}

        //public ScaffoldAndRequest GetScaffoldRequestByID(int scaffoldrequestId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldRequestByID(scaffoldrequestId);
        //}

        //public ScaffoldAndRequest JsonGetScaffoldRequestByID(string scaffoldrequestId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldRequestByID(Int32.Parse(scaffoldrequestId));
        //}

        //public ScaffoldAndRequestDTO GetScaffoldAndrequestByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldAndrequestByID(Id);
        //}

        //public ScaffoldAndRequestDTO JsonGetScaffoldAndrequestByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldAndrequestByID(Int32.Parse(Id));
        //}

        //public ScaffoldrequestDTO GetScaffoldRequestByScaffold(int scaffoldId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldRequestByScaffold(scaffoldId);
        //}

        //public ScaffoldrequestDTO JsonGetScaffoldRequestByScaffold(string scaffoldId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldRequestByScaffold(Int32.Parse(scaffoldId));
        //}

        //public List<ScaffoldtradeDTO> GetScaffoldtradeByScaffoldRequestID(int scaffoldrequestId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldtradeByScaffoldRequestID(scaffoldrequestId);
        //}

        //public List<ScaffoldtradeDTO> JsonGetScaffoldtradeByScaffoldRequestID(string scaffoldrequestId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetScaffoldtradeByScaffoldRequestID(Int32.Parse(scaffoldrequestId));
        //}

        //#endregion "Scaffold"

        //#region "Progress"

        ///// <summary>
        ///// Retrieve Progress objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (-1 returns all)</param>
        ///// <param name="drawingId">DrawingID to search for (-1 returns all)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (-1, 0 return all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> GetComponentProgressByCWPAndDrawing(int cwpId, int drawingId, int materialCategoryId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByCWP_Drawing_MaterialCategory(cwpId, drawingId, materialCategoryId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Progress objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (-1 returns all)</param>
        ///// <param name="drawingId">DrawingID to search for (-1 returns all)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (-1, 0 return all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> JsonGetComponentProgressByCWPAndDrawing(string cwpId, string drawingId, string materialCategoryId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByCWP_Drawing_MaterialCategory(Int32.Parse(cwpId), Int32.Parse(drawingId), Int32.Parse(materialCategoryId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (-1, 0 return all)</param>
        ///// <param name="materialcategoryId">MaterialCategoryID to search for (-1, 0 return all)</param>
        ///// <param name="progressId">TaskCategoryID to search for (-1, 0 return all)</param>
        ///// <param name="componentId">TaskTypeLUID to search for (-1, 0 return all)</param>
        ///// <param name="engtag">TagNumber to search for</param>
        ///// <param name="rfiId">RFIID to search for (below 0 return all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> GetComponentProgressByCWPAndMaterialCategoryID(int cwpId, int materialcategoryId, int progressId, int componentId, string engtag, int rfiId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByCWPAndMaterialCategoryID(cwpId, materialcategoryId, progressId, componentId, engtag, rfiId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (-1, 0 return all)</param>
        ///// <param name="materialcategoryId">MaterialCategoryID to search for (-1, 0 return all)</param>
        ///// <param name="progressId">TaskCategoryID to search for (-1, 0 return all)</param>
        ///// <param name="componentId">TaskTypeLUID to search for (-1, 0 return all)</param>
        ///// <param name="engtag">TagNumber to search for</param>
        ///// <param name="rfiId">RFIID to search for (below 0 return all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> JsonGetComponentProgressByCWPAndMaterialCategoryID(string cwpId, string materialcategoryId, string progressId, string componentId, string engtag, string rfiId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByCWPAndMaterialCategoryID(Int32.Parse(cwpId), Int32.Parse(materialcategoryId), Int32.Parse(progressId), Int32.Parse(componentId), engtag, Int32.Parse(rfiId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve all Progress objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> GetProgressAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressAll();
        //}

        ///// <summary>
        ///// Retrieve all Progress objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> JsonGetProgressAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressAll();
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects for update CWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> GetProgressForCWPUpdating(int cwpId, int materialCategoryId, int taskCategoryId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressForCWPUpdating(cwpId, materialCategoryId, taskCategoryId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects for update CWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> JsonGetProgressForCWPUpdating(string cwpId, string materialCategoryId, string taskCategoryId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressForCWPUpdating(Int32.Parse(cwpId), Int32.Parse(materialCategoryId), Int32.Parse(taskCategoryId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Available Collection list
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="projectId">ProjectScheduleID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        ///// 
        //public List<CollectionDTO> GetAvailableCollectionForScheduling(,
        //                                                         int cwpId,
        //                                                         int projectscheduleId,
        //                                                         int projectId,
        //                                                         string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.DALC.ProgressDAL()).GetAvailableCollectionForScheduling(cwpId, projectscheduleId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        /// <summary>
        /// Retrieve Available Collection list
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="cwpId">CWPID to search for</param>
        /// <param name="projectId">ProjectID to search for</param>
        /// <param name="projectId">ProjectScheduleID to search for</param>
        /// <param name="disciplineCode">DisciplineCode to search for</param>
        /// <returns>CollectionDTO</returns>
        public List<CollectionDTO> JsonGetAvailableCollectionForScheduling(string cwpId, string projectscheduleId, string projectId, string disciplineCode, string iwpId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetAvailableCollectionForScheduling(Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Int32.Parse(iwpId));
        }

        ///// <summary>
        ///// Retrieve Available Collection list
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="projectId">ProjectScheduleID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        ///// 
        //public List<CollectionDTO> GetAvailableCollectionForHydroScheduling(,
        //                                                         int cwpId,
        //                                                         int projectscheduleId,
        //                                                         int projectId,
        //                                                         string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.DALC.ProgressDAL()).GetAvailableCollectionForHydroScheduling(cwpId, projectscheduleId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Available Collection list
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="projectId">ProjectScheduleID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>CollectionDTO</returns>
        //public List<CollectionDTO> JsonGetAvailableCollectionForHydroScheduling(,
        //                                                         string cwpId,
        //                                                         string projectscheduleId,
        //                                                         string projectId,
        //                                                         string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.DALC.ProgressDAL()).GetAvailableCollectionForHydroScheduling(Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Available Collection list
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="projectId">ProjectScheduleID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        ///// 
        //public List<CollectionDTO> GetAvailableCollectionForSchedulingApp(int cwpId, int projectscheduleId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAvailableCollectionForSchedulingApp(cwpId, projectscheduleId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve Available Collection list
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="projectId">ProjectScheduleID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>CollectionDTO</returns>
        ////public List<CollectionDTO> JsonGetAvailableCollectionForSchedulingApp(string cwpId, string projectscheduleId, string projectId, string disciplineCode)
        ////{
        ////    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAvailableCollectionForSchedulingApp(Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        ////}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for Schedule. (not used_20130513)
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (below 0 return all)</param>
        ///// <param name="drawingId">DrawingID to search for (not used: null)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (below 0 return all)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (below 0 return all)</param>
        ///// <param name="systemId">SystemID to search for (below 0 return all)</param> 
        ///// <param name="typeLUId">TaskTypeLUID to search for (below 0 return all)</param>
        ///// <param name="engTag">EngTagNumber to search for (null returns all)</param>
        ///// <param name="searchcolumn">SearchColumn to search for (related to SearchValue)</param>
        ///// <param name="searchvalue">SearchValue to search for (related to SearchColumn)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing GetComponentProgressForScheduling(int cwpId, int drawingId, int materialCategoryId, int taskCategoryId, int systemId, int typeLUId, string engTag, string searchcolumn, string searchvalue, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForScheduling(cwpId, 0, drawingId, materialCategoryId, taskCategoryId, systemId, typeLUId, engTag, searchcolumn, searchvalue, 0, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for Schedule. (not used_20130513)
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (below 0 return all)</param>
        ///// <param name="drawingId">DrawingID to search for (not used: null)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (below 0 return all)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (below 0 return all)</param>
        ///// <param name="systemId">SystemID to search for (below 0 return all)</param> 
        ///// <param name="typeLUId">TaskTypeLUID to search for (below 0 return all)</param>
        ///// <param name="engTag">EngTagNumber to search for (null returns all)</param>
        ///// <param name="searchcolumn">SearchColumn to search for (related to SearchValue)</param>
        ///// <param name="searchvalue">SearchValue to search for (related to SearchColumn)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing JsonGetComponentProgressForScheduling(string cwpId, string drawingId, string materialCategoryId, string taskCategoryId, string systemId, string typeLUId, string engTag, string searchcolumn, string searchvalue, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForScheduling(Int32.Parse(cwpId), 0, Int32.Parse(drawingId), Int32.Parse(materialCategoryId), Int32.Parse(materialCategoryId), Int32.Parse(systemId), Int32.Parse(typeLUId), engTag, searchcolumn, searchvalue, 0, Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for FIWP. (not used_20130513)
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (below 0 return all)</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for (below 0 return all)</param>
        ///// <param name="drawingId">DrawingID to search for (not used: null)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (below 0 return all)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (below 0 return all)</param>
        ///// <param name="systemId">SystemID to search for (below 0 return all)</param> 
        ///// <param name="typeLUId">TaskTypeLUID to search for (below 0 return all)</param>
        ///// <param name="engTag">EngTagNumber to search for (null returns all)</param>
        ///// <param name="searchcolumn">SearchColumn to search for (related to SearchValue)</param>
        ///// <param name="searchvalue">SearchValue to search for (related to SearchColumn)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing GetComponentProgressForFIWP(int cwpId, int projectscheduleId, int drawingId, int materialCategoryId, int taskCategoryId, int systemId, int typeLUId, string engTag, string searchcolumn, string searchvalue, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForScheduling(cwpId, projectscheduleId, drawingId, materialCategoryId, taskCategoryId, systemId, typeLUId, engTag, searchcolumn, searchvalue, 1, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for FIWP. (not used_20130513)
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (below 0 return all)</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for (below 0 return all)</param>
        ///// <param name="drawingId">DrawingID to search for (not used: null)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (below 0 return all)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (below 0 return all)</param>
        ///// <param name="systemId">SystemID to search for (below 0 return all)</param> 
        ///// <param name="typeLUId">TaskTypeLUID to search for (below 0 return all)</param>
        ///// <param name="engTag">EngTagNumber to search for (null returns all)</param>
        ///// <param name="searchcolumn">SearchColumn to search for (related to SearchValue)</param>
        ///// <param name="searchvalue">SearchValue to search for (related to SearchColumn)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing JsonGetComponentProgressForFIWP(string cwpId, string projectscheduleId, string drawingId, string materialCategoryId, string taskCategoryId, string systemId, string typeLUId, string engTag, string searchcolumn, string searchvalue, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForScheduling(Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Int32.Parse(drawingId), Int32.Parse(materialCategoryId), Int32.Parse(taskCategoryId), Int32.Parse(systemId), Int32.Parse(typeLUId), engTag, searchcolumn, searchvalue, 1, Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL());
        //}

        public List<TimeProgressInputDTO> JsonGetComponentProgressByIwpDrawing(string iwpId, string drawingId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.TimeProgress()).JsonGetComponentProgressByIwpDrawing(Int32.Parse(iwpId), Int32.Parse(drawingId), Int32.Parse(projectId), disciplineCode);
        }

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for Schedule.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="materialCategoryIdList">MaterialCategoryID to search for</param>
        ///// <param name="taskCategoryIdList">TaskCategoryID to search for</param>
        ///// <param name="systemIdList">SystemID to search for</param> 
        ///// <param name="typeLUIdList">Specified TypeLUID(ComponentTaskType or Shapes) to search for</param>
        ///// <param name="drawingtypeLUIdList">DrawingTypeLUID to search for</param>
        ///// <param name="costcodeIdList">CostCodeID to search for</param>
        ///// <param name="searchstringList">Specified Material Field(TagNumber, Location, FromTag, ToTag) to search for</param>
        ///// <param name="compsearchstringList">Specified Component Field(Line Number, EWO Number) to search for</param>
        ///// <param name="locationList">Position to search for</param>
        ///// <param name="rfinumberList">RFI Number to search for</param>
        ///// <param name="searchcolumn">SearchColumn to search for (not used: null)</param>
        ///// <param name="searchvalueList">SearchValueList to search for (not used: new string list)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="grouppage">Page for Drawing Canvas to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing GetComponentProgressForSchedulingWithList(int cwpId, int drawingId,
        //                                                            List<int> materialCategoryIdList, List<int> taskCategoryIdList,
        //                                                            List<int> systemIdList, List<int> typeLUIdList,
        //                                                            List<int> drawingtypeLUIdList, List<int> costcodeIdList,
        //                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> compsearchstringList,
        //                                                            List<ComboBoxDTO> locationList, List<string> rfinumberList,
        //                                                            string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForScheduling(cwpId, 0, drawingId, materialCategoryIdList, taskCategoryIdList, systemIdList, typeLUIdList, drawingtypeLUIdList, costcodeIdList, searchstringList, compsearchstringList, locationList, rfinumberList, searchcolumn, searchvalueList, 0, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL(), grouppage);
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for Schedule.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="materialCategoryIdList">MaterialCategoryID to search for</param>
        ///// <param name="taskCategoryIdList">TaskCategoryID to search for</param>
        ///// <param name="systemIdList">SystemID to search for</param> 
        ///// <param name="typeLUIdList">Specified TypeLUID(ComponentTaskType or Shapes) to search for</param>
        ///// <param name="drawingtypeLUIdList">DrawingTypeLUID to search for</param>
        ///// <param name="costcodeIdList">CostCodeID to search for</param>
        ///// <param name="searchstringList">Specified Material Field(TagNumber, Location, FromTag, ToTag) to search for</param>
        ///// <param name="compsearchstringList">Specified Component Field(Line Number, EWO Number) to search for</param>
        ///// <param name="locationList">Position to search for</param>
        ///// <param name="rfinumberList">RFI Number to search for</param>
        ///// <param name="searchcolumn">SearchColumn to search for (not used: null)</param>
        ///// <param name="searchvalueList">SearchValueList to search for (not used: new string list)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="grouppage">Page for Drawing Canvas to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing JsonGetComponentProgressForSchedulingWithList(string cwpId, string drawingId,
        //                                                                   List<string> taskCategoryCodeList, List<int> taskCategoryIdList,
        //                                                                   List<int> systemIdList, List<int> typeLUIdList,
        //                                                                   List<int> drawingtypeLUIdList, List<int> costcodeIdList,
        //                                                                   List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> compsearchstringList,
        //                                                                   List<ComboBoxDTO> locationList, List<string> rfinumberList,
        //                                                                   string searchcolumn, List<string> searchvalueList,
        //                                                                   string projectId, string disciplineCode, string grouppage)
        //{
        //    //int cwpid = Int32.Parse(cwpId);
        //    //int drawingid = Int32.Parse(drawingId);
        //    //List<string> l1 = taskCategoryCodeList;
        //    //List<int> l2 = taskCategoryIdList;
        //    //List<int> l3 = systemIdList;
        //    //List<int> l4 = typeLUIdList;
        //    //List<int> l6 = drawingtypeLUIdList;
        //    //List<int> l7 = costcodeIdList;
        //    //List<ComboBoxDTO> l8 = searchstringList;
        //    //List<ComboBoxDTO> l9 = compsearchstringList;
        //    //List<ComboBoxDTO> la = locationList;
        //    //List<string> lb = rfinumberList;
        //    //string lc = searchcolumn;
        //    //List<string> ld = searchvalueList;
        //    //int a = Int32.Parse(projectId);
        //    //string b = disciplineCode;
        //    //string c = Helper.GetImageLocationURL();
        //    //int d = Int32.Parse(grouppage);

        //    //MTOAndDrawing aa = new MTOAndDrawing();
        //    //aa.TotalGroupPageCount = 10;
        //    //return aa;
        //    return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetComponentProgressForScheduling(Int32.Parse(cwpId)
        //                                                                                        , 0
        //                                                                                        , Int32.Parse(drawingId)
        //                                                                                        , taskCategoryCodeList
        //                                                                                        , taskCategoryIdList
        //                                                                                        , systemIdList
        //                                                                                        , typeLUIdList
        //                                                                                        , drawingtypeLUIdList
        //                                                                                        , costcodeIdList
        //                                                                                        , searchstringList
        //                                                                                        , compsearchstringList
        //                                                                                        , locationList
        //                                                                                        , rfinumberList
        //                                                                                        , searchcolumn
        //                                                                                        , searchvalueList
        //                                                                                        , 0
        //                                                                                        , Int32.Parse(projectId)
        //                                                                                        , disciplineCode
        //                                                                                        , Helper.GetImageLocationURL()
        //                                                                                        , Int32.Parse(grouppage));
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="drawingId"></param>
        /// <param name="taskCategoryCodeList"></param>
        /// <param name="taskTypeLUIdList"></param>
        /// <param name="materialIdList"></param>
        /// <param name="progressIdList"></param>
        /// <param name="searchcValue"></param>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <param name="grouppage"></param>
        /// <returns></returns>
        public MTOAndDrawing JsonGetComponentProgressForSchedulingWithList( string cwpId
                                                                            ,string drawingId
                                                                            ,List<string> taskCategoryCodeList
                                                                            ,List<int> taskTypeIdList
                                                                            ,List<int> materialIdList
                                                                            ,List<int> progressIdList
                                                                            ,string searchValue
                                                                            ,string projectId
                                                                            ,string disciplineCode
                                                                            ,string grouppage)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetComponentProgressForScheduling(Int32.Parse(cwpId)
                                                                                                ,0
                                                                                                ,Int32.Parse(drawingId)
                                                                                                ,taskCategoryCodeList
                                                                                                ,taskTypeIdList
                                                                                                ,materialIdList
                                                                                                ,progressIdList
                                                                                                ,searchValue
                                                                                                ,Int32.Parse(projectId)
                                                                                                ,Helper.RemoveJsonParameterWrapper(disciplineCode)
                                                                                                ,Helper.GetWebrootUrl() //Helper.GetImageLocationURL()
                                                                                                ,Int32.Parse(grouppage));
        }

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for SIWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="systemIdList">SystemID to search for</param> 
        ///// <param name="projectscheduleIdList">ProjectScheduleID to search for</param>
        ///// <param name="costcodeIdList">CostCodeID to search for</param>
        ///// <param name="searchstringList">Specified Field(TagNumber, RFI Number, Associated TagNumber, Material Item No., Location, Line No.) to search for</param>
        ///// <param name="locationList">Position to search for</param>
        ///// <param name="searchcolumn">SearchColumn to search for (not used: null)</param>
        ///// <param name="searchvalueList">SearchValueList to search for (not used: new string list)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="grouppage">Page for Drawing Canvas to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing GetComponentProgressForHydroSchedulingWithList(int drawingId,
        //                                                            List<int> systemIdList, List<int> projectscheduleIdList, List<int> costcodeIdList,
        //                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForHydroScheduling(drawingId, systemIdList, projectscheduleIdList, costcodeIdList, searchstringList, locationList, searchcolumn, searchvalueList, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL(), grouppage);
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for SIWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="systemIdList">SystemID to search for</param> 
        ///// <param name="projectscheduleIdList">ProjectScheduleID to search for</param>
        ///// <param name="costcodeIdList">CostCodeID to search for</param>
        ///// <param name="searchstringList">Specified Field(TagNumber, RFI Number, Associated TagNumber, Material Item No., Location, Line No.) to search for</param>
        ///// <param name="locationList">Position to search for</param>
        ///// <param name="searchcolumn">SearchColumn to search for (not used: null)</param>
        ///// <param name="searchvalueList">SearchValueList to search for (not used: new string list)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="grouppage">Page for Drawing Canvas to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing JsonGetComponentProgressForHydroSchedulingWithList(string projectscheduleId, string drawingId,
        //                                                                   List<string> systemIdList, List<string> projectscheduleIdList, List<string> costcodeIdList,
        //                                                                   List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                                   string projectId, string disciplineCode, string grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForHydroScheduling(Int32.Parse(drawingId),
        //                                                                                              systemIdList.ConvertAll(Int32.Parse), projectscheduleIdList.ConvertAll(Int32.Parse), costcodeIdList.ConvertAll(Int32.Parse),
        //                                                                                              searchstringList, locationList, searchcolumn, searchvalueList, Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL(), Int32.Parse(grouppage));
        //}

        //public MTOAndDrawing GetComponentProgressForHydroSchedulingWithListApps(int cwpId, int drawingId,
        //                                                            List<ComboBoxDTO> matrsearchstringList, List<ComboBoxDTO> matrsearchstringList2, List<ComboBoxDTO> compsearchstringList, List<ComboBoxDTO> pnidsearchstringList,
        //                                                            List<int> systemIdList, List<int> projectscheduleIdList, List<int> costcodeIdList,
        //                                                            List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForHydroSchedulingApps(cwpId, drawingId, matrsearchstringList, matrsearchstringList2, compsearchstringList, pnidsearchstringList, systemIdList, projectscheduleIdList, costcodeIdList, locationList, searchcolumn, searchvalueList, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL(), grouppage);
        //}

        //public MTOAndDrawing JsonGetComponentProgressForHydroSchedulingWithListApps(string cwpId, string drawingId,
        //                                                                   List<ComboBoxDTO> matrsearchstringList, List<ComboBoxDTO> matrsearchstringList2, List<ComboBoxDTO> compsearchstringList, List<ComboBoxDTO> pnidsearchstringList,
        //                                                                   List<string> systemIdList, List<string> projectscheduleIdList, List<string> costcodeIdList,
        //                                                                   List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                                   string projectId, string disciplineCode, string grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForHydroSchedulingApps(Int32.Parse(cwpId), Int32.Parse(drawingId), matrsearchstringList, matrsearchstringList2, compsearchstringList, pnidsearchstringList,
        //                                                                                              systemIdList.ConvertAll(Int32.Parse), projectscheduleIdList.ConvertAll(Int32.Parse), costcodeIdList.ConvertAll(Int32.Parse),
        //                                                                                              locationList, searchcolumn, searchvalueList, Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL(), Int32.Parse(grouppage));
        //}

        //public MTOAndDrawing GetComponentProgressForHydroSchedulingAppWithList(int drawingId,
        //                                                            List<int> systemIdList, List<int> projectscheduleIdList, List<int> costcodeIdList, List<string> isolineIdList,
        //                                                            List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                            int projectId, string disciplineCode, int grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForHydroSchedulingApp(drawingId, systemIdList, projectscheduleIdList, costcodeIdList, isolineIdList, searchstringList, locationList, searchcolumn, searchvalueList, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL(), grouppage);
        //}

        //public MTOAndDrawing JsonGetComponentProgressForHydroSchedulingAppWithList(string drawingId,
        //                                                                   List<string> systemIdList, List<string> projectscheduleIdList, List<string> costcodeIdList, List<string> isolineIdList,
        //                                                                   List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> locationList, string searchcolumn, List<string> searchvalueList,
        //                                                                   string projectId, string disciplineCode, string grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForHydroSchedulingApp(Int32.Parse(drawingId),
        //                                                                                              systemIdList.ConvertAll(Int32.Parse), projectscheduleIdList.ConvertAll(Int32.Parse), costcodeIdList.ConvertAll(Int32.Parse), isolineIdList,
        //                                                                                              searchstringList, locationList, searchcolumn, searchvalueList, Int32.Parse(projectId), Int32.Parse(disciplineCode), Helper.GetImageLocationURL(), Int32.Parse(grouppage));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects and Drawing list for FIWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="projectscheduleId">ProjectScheduleID to search for</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="materialCategoryIdList">MaterialCategoryID to search for</param>
        ///// <param name="taskCategoryIdList">TaskCategoryID to search for</param>
        ///// <param name="systemIdList">SystemID to search for</param> 
        ///// <param name="typeLUIdList">Specified TypeLUID(ComponentTaskType or Shapes) to search for</param>
        ///// <param name="drawingtypeLUIdList">DrawingTypeLUID to search for</param>
        ///// <param name="costcodeIdList">CostCodeID to search for</param>
        ///// <param name="searchstringList">Specified Material Field(TagNumber, Location, FromTag, ToTag) to search for</param>
        ///// <param name="compsearchstringList">Specified Component Field(Line Number, EWO Number) to search for</param>
        ///// <param name="locationList">Position to search for</param>
        ///// <param name="rfinumberList">RFI Number to search for</param>
        ///// <param name="searchcolumn">SearchColumn to search for (not used: null)</param>
        ///// <param name="searchvalueList">SearchValueList to search for (not used: new string list)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="grouppage">Page for Drawing Canvas to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing GetComponentProgressForFIWPWithList(int cwpId,
        //                                                         int projectscheduleId, int drawingId,
        //                                                         List<int> materialCategoryIdList, List<int> taskCategoryIdList,
        //                                                         List<int> systemIdList, List<int> typeLUIdList,
        //                                                         List<int> drawingtypeLUIdList, List<int> costcodeIdList,
        //                                                         List<ComboBoxDTO> searchstringList, List<ComboBoxDTO> compsearchstringList,
        //                                                         List<ComboBoxDTO> locationList, List<string> rfinumberList,
        //                                                         string searchcolumn, List<string> searchvalueList,
        //                                                         int projectId, string disciplineCode, int grouppage)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressForScheduling(cwpId, projectscheduleId, drawingId, materialCategoryIdList, taskCategoryIdList, systemIdList, typeLUIdList, drawingtypeLUIdList, costcodeIdList, searchstringList, compsearchstringList, locationList, rfinumberList, searchcolumn, searchvalueList, 1, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetImageLocationURL(), grouppage);
        //}

        public MTOAndDrawing JsonGetComponentProgressForFIWPWithList(string cwpId,
                                                                    string projectscheduleId, 
                                                                    string drawingId,
                                                                    List<string> taskCategoryCodeList,
                                                                    List<int> taskTypeIdList,
                                                                    List<int> materialIdList,
                                                                    List<int> progressIdList,
                                                                    string searchValue,
                                                                    string projectId,
                                                                    string disciplineCode,
                                                                    string grouppage)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetComponentProgressForScheduling(Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Int32.Parse(drawingId),
                                                                                                      taskCategoryCodeList, taskTypeIdList,
                                                                                                      materialIdList, progressIdList,
                                                                                                      searchValue, Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.GetWebrootUrl(), Int32.Parse(grouppage));
        }

        ///// <summary>
        ///// Retrieve assigned progress.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for (0 returns all)</param>
        ///// <param name="projectScheduleID">ProjectScheduleID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTODTO</returns>        
        //public List<MTODTO> GetComponentProgressByFIWP(int fiwpId, int projectScheduleID, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWP(fiwpId, projectScheduleID, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        /// <summary>
        /// Retrieve assigned progress.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="fiwpId">FIWPID to search for (0 returns all)</param>
        /// <param name="projectScheduleID">ProjectScheduleID to search for</param>
        /// <param name="projectId">ProjectID to search for</param>
        /// <param name="disciplineCode">DisciplineCode to search for</param>
        /// <returns>MTODTO</returns>        
        public List<MTODTO> JsonGetComponentProgressByFIWP(string iwpId, string scheduledWorkItemId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetComponentProgressByFIWP(Int32.Parse(iwpId), Int32.Parse(scheduledWorkItemId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        ///// <summary>
        ///// Retrieve assigned progress for SIWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for (0 returns all)</param>
        ///// <param name="projectScheduleID">ProjectScheduleID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> GetComponentProgressBySIWP(int fiwpId, int projectScheduleID, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressBySIWP(fiwpId, projectScheduleID, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve assigned progress for SIWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for (0 returns all)</param>
        ///// <param name="projectScheduleID">ProjectScheduleID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> JsonGetComponentProgressBySIWP(string fiwpId, string projectScheduleID, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressBySIWP(Int32.Parse(fiwpId), Int32.Parse(projectScheduleID), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve aviable (Material Take Off) objects contains which Progress has been uncompleted.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">Foreman PersonnelId to search for </param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>List<CollectionDTO></returns>
        //public List<CollectionDTO> GetAvailableCollectionForForemanUncompleted(int personnelId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetAvailableCollectionForForemanUncompleted(personnelId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        /// <summary>
        /// Retrieve aviable collection objects contains which Progress are uncompleted.
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="cwpId">Foreman PersonnelId to search for </param>
        /// <param name="projectId">ProjectID to search for</param>
        /// <param name="disciplineCode">DisciplineCode to search for</param>
        /// <returns>List<CollectionDTO></returns>
        public List<ComboBoxDTO> JsonGetAvailableCollectionForForemanUncompleted_Combo(string personnelId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.TimeProgress()).GetAvailableCollectionForForemanUncompleted_Combo(Helper.RemoveJsonParameterWrapper(personnelId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects contains which Progress has been uncompleted.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="workDate">WorkDate to search for</param>
        ///// <param name="ruleofcreditweightId">RuleofCreditWeightID to search for</param>
        ///// <param name="drawingIds">Multiple drawingID to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing GetComponentProgressByFIWPUncompleted(int cwpId, int materialcategoryId, int fiwpId, int projectId, string disciplineCode, DateTime workDate, int ruleofcreditweightId, List<int> drawingIds)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWPUncompleted(cwpId, materialcategoryId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), workDate, ruleofcreditweightId, drawingIds, Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects contains which Progress has been uncompleted.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="workDate">WorkDate to search for</param>
        ///// <param name="ruleofcreditweightId">RuleofCreditWeightID to search for</param>
        ///// <param name="drawingIds">Multiple drawingID to search for</param>
        ///// <returns>MTOAndDrawing</returns>
        //public MTOAndDrawing JsonGetComponentProgressByFIWPUncompleted(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId, string drawingIds)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWPUncompleted(Int32.Parse(cwpId), Int32.Parse(materialcategoryId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), DateTime.Parse(workDate), Int32.Parse(ruleofcreditweightId), Helper.GetIntParameter(drawingIds), Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects contains which Progress has been completed partially. 
        ///// The results are constrained by the workDate and flag parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="workDate">WorkDate to search for</param>
        ///// <param name="ruleofcreditweightId">RuleofCreditWeightID to search for</param>
        ///// <param name="timeallocationId">TimeAllocationIdID to search for</param>
        ///// <param name="flag">Whether it was selected or not (1:selected, 0:not)</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> GetComponentProgressByFIWPPartialComplete(int cwpId, int materialcategoryId, int fiwpId, int projectId, string disciplineCode, DateTime workDate, int ruleofcreditweightId, int timeallocationId, int flag)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWPPartialComplete(cwpId, materialcategoryId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), workDate, ruleofcreditweightId, timeallocationId, flag);
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects contains which Progress has been completed partially. 
        ///// The results are constrained by the workDate and flag parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="workDate">WorkDate to search for</param>
        ///// <param name="ruleofcreditweightId">RuleofCreditWeightID to search for</param>
        ///// <param name="timeallocationId">TimeAllocationIdID to search for</param>
        ///// <param name="flag">Whether it was selected or not (1:selected, 0:not)</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> JsonGetComponentProgressByFIWPPartialComplete(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId, string timeallocationId, string flag)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWPPartialComplete(Int32.Parse(cwpId), Int32.Parse(materialcategoryId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), DateTime.Parse(workDate), Int32.Parse(ruleofcreditweightId), Int32.Parse(timeallocationId), Int32.Parse(flag));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects contains which Progress has been completed. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="workDate">WorkDate to search for</param>
        ///// <param name="ruleofcreditweightId">RuleofCreditWeightID to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> GetComponentProgressByFIWPDone(int cwpId, int materialcategoryId, int fiwpId, int projectId, string disciplineCode, DateTime workDate, int ruleofcreditweightId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWPDone(cwpId, materialcategoryId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), workDate, ruleofcreditweightId);
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects contains which Progress has been completed. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="workDate">WorkDate to search for</param>
        ///// <param name="ruleofcreditweightId">RuleofCreditWeightID to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> JsonGetComponentProgressByFIWPDone(string cwpId, string materialcategoryId, string fiwpId, string projectId, string disciplineCode, string workDate, string ruleofcreditweightId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWPDone(Int32.Parse(cwpId), Int32.Parse(materialcategoryId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), DateTime.Parse(workDate), Int32.Parse(ruleofcreditweightId));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects consisted of Component, Material and Progress.
        ///// The results are constrained by the selected page, page size and fileId parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="fileId">The identifier of a specific imported file</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of MTO object to return</param>
        ///// <returns>MTOPageTotal</returns>
        //public MTOPageTotal GetFileuploadForMTO(int cwpId, int fileId, int projectId, string disciplineCode, int selectedPage, int pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFileuploadForMTO(cwpId, fileId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), selectedPage, pageSize);
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects consisted of Component, Material and Progress.
        ///// The results are constrained by the selected page, page size and fileId parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="fileId">The identifier of a specific imported file</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of MTO object to return</param>
        ///// <returns>MTOPageTotal</returns>
        //public MTOPageTotal JsonGetFileuploadForMTO(string cwpId, string fileId, string projectId, string disciplineCode, string selectedPage, string pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFileuploadForMTO(Int32.Parse(cwpId), Int32.Parse(fileId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(selectedPage), Int32.Parse(pageSize));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects consisted of Component, Material and Progress.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="drawigId">DrawingID to search for (0 returns all)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (0 returns all)</param>
        ///// <param name="divValue">Whether it is SD or not (1: SD, 0: not)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of MTO object to return</param>
        ///// <returns>MTOPageTotal</returns>
        //public MTOPageTotal GetComponentForMTO(int cwpId, int drawigId, int materialCategoryId, int divValue, int taskCategoryId, int projectId, string disciplineCode, int selectedPage, int pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentForMTO(cwpId, drawigId, materialCategoryId, divValue, taskCategoryId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), selectedPage, pageSize);
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects consisted of Component, Material and Progress.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="drawigId">DrawingID to search for (0 returns all)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (0 returns all)</param>
        ///// <param name="divValue">Whether it is SD or not (1: SD, 0: not)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of MTO object to return</param>
        ///// <returns>MTOPageTotal</returns>
        //public MTOPageTotal JsonGetComponentForMTO(string cwpId, string drawigId, string materialCategoryId, string divValue, string taskCategoryId, string projectId, string disciplineCode, string selectedPage, string pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentForMTO(Int32.Parse(cwpId), Int32.Parse(drawigId), Int32.Parse(materialCategoryId), Int32.Parse(divValue), Int32.Parse(taskCategoryId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(selectedPage), Int32.Parse(pageSize));
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects consisted of Component, Material and Progress.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="drawigId">DrawingID to search for (0 returns all)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (0 returns all)</param>
        ///// <param name="divValue">Whether it is SD or not (1: SD, 0: not)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of MTO object to return</param>
        ///// <returns>MTOPageTotal</returns>
        //public MTOPageTotal GetMaterialTakeOff(int cwpId, int drawigId, int materialCategoryId, int divValue, int taskCategoryId, int projectId, string disciplineCode, int selectedPage, int pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialTakeOff(cwpId, drawigId, materialCategoryId, divValue, taskCategoryId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), selectedPage, pageSize);
        //}

        ///// <summary>
        ///// Retrieve MTO (Material Take Off) objects consisted of Component, Material and Progress.
        ///// The results are constrained by the selected page and page size parameters.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="drawigId">DrawingID to search for (0 returns all)</param>
        ///// <param name="materialCategoryId">MaterialCategoryID to search for (0 returns all)</param>
        ///// <param name="divValue">Whether it is SD or not (1: SD, 0: not)</param>
        ///// <param name="taskCategoryId">TaskCategoryID to search for (0 returns all)</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="selectedPage">Which page of results to return</param>
        ///// <param name="pageSize">The maximum number of MTO object to return</param>
        ///// <returns>MTOPageTotal</returns>
        //public MTOPageTotal JsonGetMaterialTakeOff(string cwpId, string drawigId, string materialCategoryId, string divValue, string taskCategoryId, string projectId, string disciplineCode, string selectedPage, string pageSize)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetMaterialTakeOff(Int32.Parse(cwpId), Int32.Parse(drawigId), Int32.Parse(materialCategoryId), Int32.Parse(divValue), Int32.Parse(taskCategoryId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(selectedPage), Int32.Parse(pageSize));
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Progress unique identifier to search for </param>
        ///// <returns>ProgressDTO</returns>        
        //public ProgressDTO GetProgressById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Progress unique identifier to search for </param>
        ///// <returns>ProgressDTO</returns>
        //public ProgressDTO JsonGetProgressById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByID(Int32.Parse(Id));
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified componentId to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">ComponentID to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> GetProgressByComponentID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByComponentID(Id);
        //}

        //public List<ProgressDTO> GetProgressByComponent(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByComponent(Id);
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified componentId to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">ComponentID to search for</param>
        ///// <returns>MTODTO</returns>
        //public List<MTODTO> GetComponentByComponentForImport(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByComponentForImport(Id);
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified projectId to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> GetProgressByProjectID(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByProjectID(projectId);
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified costcodeId to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">MoudleID to search for</param>
        ///// <param name="costcodeId">CostCodeID to search for (0 returns all)</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> GetProgressByCostCode(int projectId, string disciplineCode, int costcodeId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByCostCode(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), costcodeId);
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress grouped by CostCode and UOM contains the specified cwpId and costcodeId to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">MoudleID to search for</param>
        ///// <param name="cwpId">CWPID to search for (0 returns all)</param>
        ///// <param name="costcodeId">CostCodeID to search for (0 returns all)</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> GetProgressByCostCodeForGrouping(int projectId, string disciplineCode, int cwpId, int costcodeId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByCostCodeForGrouping(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), cwpId, costcodeId);
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified unique identifiers to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Ids">Multiple progress unique identifiers to search for</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> GetProgressByIds(string Ids)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByIDs(Ids);
        //}

        ///// <summary>
        ///// Retrieve Progress objects which progress contains the specified unique identifiers to match
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Ids">Multiple progress unique identifiers to search for</param>
        ///// <returns>ProgressDTO</returns>
        //public List<ProgressDTO> JsonGetProgressByIds(string Ids)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetProgressByIDs(Ids);
        //}

        ///// <summary>
        ///// Retrieve component, progress and material which object contains the ReelNo to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="reelNo">ReelNo to search for</param>
        ///// <param name="qaqcFormTemplateId">QAQCFormTemplateID to search for</param>
        ///// <returns>ComponentAndMaterial</returns>
        //public ComponentAndMaterial GetQAQCByFIWPReelNumber(int fiwpId, string reelNo, int qaqcFormTemplateId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQAQCByFIWPReelNumber(fiwpId, reelNo, qaqcFormTemplateId);
        //}

        ///// <summary>
        ///// Retrieve component, progress and material which object contains the ReelNo to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="reelNo">ReelNo to search for</param>
        ///// <param name="qaqcFormTemplateId">QAQCFormTemplateID to search for</param>
        ///// <returns>ComponentAndMaterial</returns>
        //public ComponentAndMaterial JsonGetQAQCByFIWPReelNumber(string fiwpId, string reelNo, string qaqcFormTemplateId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQAQCByFIWPReelNumber(Int32.Parse(fiwpId), reelNo, Int32.Parse(qaqcFormTemplateId));
        //}

        ///// <summary>
        ///// Retrieve component, material and tagnumberdrawing which object contains the EngTagNumber to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="engTag">EngTagNumber to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">MoudleID to search for</param>
        ///// <returns>ComponentAndMaterial</returns>
        //public ComponentAndMaterial GetQAQCByEngTag(int fiwpId, string engTag, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQAQCByEngTag(fiwpId, engTag, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve component, material and tagnumberdrawing which object contains the EngTagNumber to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <param name="engTag">EngTagNumber to search for</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="disciplineCode">MoudleID to search for</param>
        ///// <returns>ComponentAndMaterial</returns>
        //public ComponentAndMaterial JsonGetQAQCByEngTag(string fiwpId, string engTag, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQAQCByEngTag(Int32.Parse(fiwpId), engTag, Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        ///// <summary>
        ///// Retrieve component, material and tagnumberdrawing which object contains the ComponentID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="componentId">ComponentID to search for</param>
        ///// <returns>ComponentAndMaterial</returns>
        //public ComponentAndMaterial GetQAQCByComponent(int componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQAQCByComponent(componentId);
        //}

        ///// <summary>
        ///// Retrieve component, material and tagnumberdrawing which object contains the ComponentID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="componentId">ComponentID to search for</param>
        ///// <returns>ComponentAndMaterial</returns>
        //public ComponentAndMaterial JsonGetQAQCByComponent(string componentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQAQCByComponent(Int32.Parse(componentId));
        //}

        //#endregion "Progress"

        //#region "Electrical Estimate Manhours"

        //public List<LibequipmanhourDTO> GetLibEquipManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEquipManhour();
        //}

        //public List<LibequipmanhourDTO> JsonGetLibEquipManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEquipManhour();
        //}

        //public List<LibgroundingmanhourDTO> GetLibGroundingManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibGroundingManhour();
        //}

        //public List<LibgroundingmanhourDTO> JsonGetLibGroundingManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibGroundingManhour();
        //}

        //public List<LibinstrmanhourDTO> GetLibInstrManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibInstrManhour();
        //}

        //public List<LibinstrmanhourDTO> JsonGetLibInstrManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibInstrManhour();
        //}

        //public List<LiblightingmanhourDTO> GetLibLightingManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibLightingManhour();
        //}

        //public List<LiblightingmanhourDTO> JsonGetLibLightingManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibLightingManhour();
        //}

        //public List<LibracewaymanhourDTO> GetLibRacewayManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibRacewayManhour();
        //}

        //public List<LibracewaymanhourDTO> JsonGetLibRacewayManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibRacewayManhour();
        //}

        //public List<LibehtmanhourDTO> GetLibEhtManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEhtManhour();
        //}

        //public List<LibehtmanhourDTO> JsonGetLibEhtManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEhtManhour();
        //}

        //public List<LibcablemanhourDTO> GetLibCableManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibCableManhour();
        //}

        //public List<LibcablemanhourDTO> JsonGetLibCableManhour()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibCableManhour();
        //}

        //public LibequipmanhourDTO GetLibEquipManhourById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEquipManhourById(Id);
        //}

        //public LibequipmanhourDTO JsonGetLibEquipManhourById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEquipManhourById(Int32.Parse(Id));
        //}

        //public LibgroundingmanhourDTO GetLibGroundingManhourById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibGroundingManhourById(Id);
        //}

        //public LibgroundingmanhourDTO JsonGetLibGroundingManhourById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibGroundingManhourById(Int32.Parse(Id));
        //}

        //public LibinstrmanhourDTO GetLibInstrManhourById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibInstrManhourById(Id);
        //}

        //public LibinstrmanhourDTO JsonGetLibInstrManhourById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibInstrManhourById(Int32.Parse(Id));
        //}

        //public LiblightingmanhourDTO GetLibLightingManhourById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibLightingManhourById(Id);
        //}

        //public LiblightingmanhourDTO JsonGetLibLightingManhourById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibLightingManhourById(Int32.Parse(Id));
        //}

        //public LibracewaymanhourDTO GetLibRacewayManhourById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibRacewayManhourById(Id);
        //}

        //public LibracewaymanhourDTO JsonGetLibRacewayManhourById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibRacewayManhourById(Int32.Parse(Id));
        //}

        //public LibehtmanhourDTO GetLibEhtManhourById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEhtManhourById(Id);
        //}

        //public LibehtmanhourDTO JsonGetLibEhtManhourById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEhtManhourById(Int32.Parse(Id));
        //}

        //public LibcablemanhourDTO GetLibCableManhourById(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibCableManhourById(Id);
        //}

        //public LibcablemanhourDTO JsonGetLibCableManhourById(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibCableManhourById(Int32.Parse(Id));
        //}

        //public LibracewaymanhourPageTotal GetLibRacewayManhourForPaging(int selectedPage, int pageSize, string RacewayType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibRacewayManhourForPaging(selectedPage, pageSize, RacewayType, PartNumber, Vendor);
        //}

        //public LibracewaymanhourPageTotal JsonGetLibRacewayManhourForPaging(string selectedPage, string pageSize, string RacewayType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibRacewayManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), RacewayType, PartNumber, Vendor);
        //}

        //public LibcablemanhourPageTotal GetLibCableManhourForPaging(int selectedPage, int pageSize, string CableType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibCableManhourForPaging(selectedPage, pageSize, CableType, PartNumber, Vendor);
        //}

        //public LibcablemanhourPageTotal JsonGetLibCableManhourForPaging(string selectedPage, string pageSize, string CableLibName, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibCableManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), CableLibName, PartNumber, Vendor);
        //}

        //public LiblightingmanhourPageTotal GetLibLightingManhourForPaging(int selectedPage, int pageSize, string LightingType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibLightingManhourForPaging(selectedPage, pageSize, LightingType, PartNumber, Vendor);
        //}

        //public LiblightingmanhourPageTotal JsonGetLibLightingManhourForPaging(string selectedPage, string pageSize, string LightingType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibLightingManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), LightingType, PartNumber, Vendor);
        //}

        //public LibequipmanhourPageTotal GetLibEquipManhourForPaging(int selectedPage, int pageSize, string EquipType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEquipManhourForPaging(selectedPage, pageSize, EquipType, PartNumber, Vendor);
        //}

        //public LibequipmanhourPageTotal JsonGetLibEquipManhourForPaging(string selectedPage, string pageSize, string EquipType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEquipManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), EquipType, PartNumber, Vendor);
        //}

        //public LibgroundingmanhourPageTotal GetLibGroundingManhourForPaging(int selectedPage, int pageSize, string TaskType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibGroundingManhourForPaging(selectedPage, pageSize, TaskType, PartNumber, Vendor);
        //}

        //public LibgroundingmanhourPageTotal JsonGetLibGroundingManhourForPaging(string selectedPage, string pageSize, string TaskType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibGroundingManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), TaskType, PartNumber, Vendor);
        //}

        //public LibinstrmanhourPageTotal GetLibInstrManhourForPaging(int selectedPage, int pageSize, string InstrType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibInstrManhourForPaging(selectedPage, pageSize, InstrType, PartNumber, Vendor);
        //}

        //public LibinstrmanhourPageTotal JsonGetLibInstrManhourForPaging(string selectedPage, string pageSize, string InstrType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibInstrManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), InstrType, PartNumber, Vendor);
        //}

        //public LibehtmanhourPageTotal GetLibEhtManhourForPaging(int selectedPage, int pageSize, string EHTType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEhtManhourForPaging(selectedPage, pageSize, EHTType, PartNumber, Vendor);
        //}

        //public LibehtmanhourPageTotal JsonGetLibEhtManhourForPaging(string selectedPage, string pageSize, string EHTType, string PartNumber, string Vendor)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibEhtManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), EHTType, PartNumber, Vendor);
        //}

        //public QaqcformDTO GetQaqcformByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByID(id);
        //}

        //public QaqcformDTO JsonGetQaqcformByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByID(Int32.Parse(id));
        //}

        //public List<QaqcformDTO> GetQaqcformByComponentSystem(int ComponentId, int SystemId, int QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByComponentSystem(ComponentId, SystemId, QAQCDataTypeLUID);
        //}

        //public QaqcformtemplateDTO GetSignleQAQCFormTemplateByName(string templateName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSignleQAQCFormTemplateByName(templateName);
        //}

        //public QaqcformtemplateDTO JsonGetSignleQAQCFormTemplateByName(string templateName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSignleQAQCFormTemplateByName(templateName);
        //}

        //public List<QaqcformtemplateDTO> GetQaqcformtemplateByFiwpUnassigned(int formtype, int fiwpId, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByFiwpUnassigned(formtype, fiwpId, projectId);
        //}

        //public List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByFiwpUnassigned(string formtype, string fiwpId, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByFiwpUnassigned(Int32.Parse(formtype), Int32.Parse(fiwpId), Int32.Parse(projectId));
        //}

        //public List<QaqcformtemplateDTO> GetQaqcformtemplateByFiwpIsQAQC(int cwpId, int fiwpId, int projectId, string disciplineCode, int doctypeId, int isQAQC)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByFiwpIsQAQC(cwpId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), doctypeId, isQAQC);
        //}

        //public List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByFiwpIsQAQC(string cwpId, string fiwpId, string projectId, string disciplineCode, string doctypeId, string isQAQC)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByFiwpIsQAQC(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(doctypeId), Int32.Parse(isQAQC));
        //}

        //public List<QaqcformtemplateDTO> GetQaqcformtemplateByNameProject(string templateName, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByNameProject(templateName, projectId);
        //}

        //public List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByNameProject(string templateName, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByNameProject(templateName, Int32.Parse(projectId));
        //}

        //public List<QaqcformtemplateDTO> GetQaqcformtemplateByFormtypeNameProject(int formtype, string templateName, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByFormtypeNameProject(formtype, templateName, projectId);
        //}

        //public List<QaqcformtemplateDTO> JsonGetQaqcformtemplateByFormtypeNameProject(string formtype, string templateName, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformtemplateByFormtypeNameProject(Int32.Parse(formtype), templateName, Int32.Parse(projectId));
        //}

        //public QaqcformDTO GetQaqcformByQaqcComponent(int componentId, int qaqcFormTemplateId, int QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByQaqcComponent(componentId, qaqcFormTemplateId, QAQCDataTypeLUID);
        //}

        //public QaqcformDTO JsonGetQaqcformByQaqcComponent(string componentId, string qaqcFormTemplateId, string QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByQaqcComponent(Int32.Parse(componentId), Int32.Parse(qaqcFormTemplateId), Int32.Parse(QAQCDataTypeLUID));
        //}

        //public QaqcformDTO GetQaqcformByReelNoFiwp(string reelNo, int fiwpId, int qaqcFormTemplateId, int QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByReelNoFiwp(reelNo, fiwpId, qaqcFormTemplateId, QAQCDataTypeLUID);
        //}

        //public QaqcformDTO JsonGetQaqcformByReelNoFiwp(string reelNo, string fiwpId, string qaqcFormTemplateId, string QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByReelNoFiwp(reelNo, Int32.Parse(fiwpId), Int32.Parse(qaqcFormTemplateId), Int32.Parse(QAQCDataTypeLUID));
        //}

        //public QaqcformDTO GetQaqcformByEngTagNoFiwp(string engTag, int fiwpId, int qaqcFormTemplateId, int QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByEngTagNoFiwp(engTag, fiwpId, qaqcFormTemplateId, QAQCDataTypeLUID);
        //}

        //public QaqcformDTO JsonGetQaqcformByEngTagNoFiwp(string engTag, string fiwpId, string qaqcFormTemplateId, string QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByEngTagNoFiwp(engTag, Int32.Parse(fiwpId), Int32.Parse(qaqcFormTemplateId), Int32.Parse(QAQCDataTypeLUID));
        //}

        //#endregion "Electrical Estimate Manhours"

        //#region "LibPipe"

        //public List<LibpipemanhourDTO> GetLibPipeManHourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManHourAll();
        //}

        //public List<LibpipemanhourDTO> JsonGetLibPipeManHourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManHourAll();
        //}

        //public List<LibpipeclassmanhourDTO> GetLibPipeClassManHourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeClassManHourAll();
        //}

        //public List<LibpipeclassmanhourDTO> JsonGetLibPipeClassManHourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeClassManHourAll();
        //}

        //public LibpipeclassmanhourDTO GetLibPipeClassManHourByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeClassManHourByID(Id);
        //}

        //public LibpipeclassmanhourDTO JsonGetLibPipeClassManHourByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeClassManHourByID(Int32.Parse(Id));
        //}

        //public LibpipeclassmanhourPageTotal GetLibPipeClassManHourForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeClassManHourForPaging(selectedPage, pageSize, PipeType, SearchOption, PipeSize, selectoption, luid1, luid2, luid3, luid4);
        //}

        //public LibpipeclassmanhourPageTotal JsonGetLibPipeClassManHourForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeClassManHourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), Int32.Parse(PipeType), Int32.Parse(SearchOption), Decimal.Parse(PipeSize), Int32.Parse(selectoption), Int32.Parse(luid1), Int32.Parse(luid2), Int32.Parse(luid3), Int32.Parse(luid4));
        //}

        //public List<LibpipemanhourratioDTO> GetLibPipeManhourRatioAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManhourRatioAll();
        //}

        //public List<LibpipemanhourratioDTO> JsonGetLibPipeManhourRatioAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManhourRatioAll();
        //}

        //public LibpipemanhourratioDTO GetLibPipeManhourRatioByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManhourRatioByID(Id);
        //}

        //public LibpipemanhourratioDTO JsonGetLibPipeManhourRatioByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManhourRatioByID(Int32.Parse(Id));
        //}

        //public LibpipemanhourratioPageTotal GetLibPipeManhourRatioForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManhourRatioForPaging(selectedPage, pageSize, PipeType, SearchOption, PipeSize, selectoption, luid1, luid2, luid3, luid4);
        //}

        //public LibpipemanhourratioPageTotal JsonGetLibPipeManhourRatioForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManhourRatioForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), Int32.Parse(PipeType), Int32.Parse(SearchOption), Decimal.Parse(PipeSize), Int32.Parse(selectoption), Int32.Parse(luid1), Int32.Parse(luid2), Int32.Parse(luid3), Int32.Parse(luid4));
        //}

        //public LibpipematerialgrpDTO GetLibPipeMaterailGrpByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeMaterailGrpByID(Id);
        //}

        //public LibpipematerialgrpDTO JsonGetLibPipeMaterailGrpByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeMaterailGrpByID(Int32.Parse(Id));
        //}

        //public List<LibpipesupmanhourDTO> GetLibPipeSupManhourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSupManhourAll();
        //}

        //public List<LibpipesupmanhourDTO> JsonGetLibPipeSupManhourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSupManhourAll();
        //}

        //public LibpipesupmanhourDTO GetLibPipeSupManhourByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSupManhourByID(Id);
        //}

        //public LibpipesupmanhourDTO JsonGetLibPipeSupManhourByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSupManhourByID(Int32.Parse(Id));
        //}

        //public LibpipesupmanhourPageTotal GetLibPipeSupManhourForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSupManhourForPaging(selectedPage, pageSize, PipeType, SearchOption, PipeSize, selectoption, luid1, luid2, luid3, luid4);
        //}

        //public LibpipesupmanhourPageTotal JsonGetLibPipeSupManhourForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSupManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), Int32.Parse(PipeType), Int32.Parse(SearchOption), Decimal.Parse(PipeSize), Int32.Parse(selectoption), Int32.Parse(luid1), Int32.Parse(luid2), Int32.Parse(luid3), Int32.Parse(luid4));
        //}

        //public List<LibpipematerialgrpDTO> GetLibpipematerialgrpAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibpipematerialgrpAll();
        //}

        //public List<LibpipeschmanhourDTO> GetLibPipeSchManhourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSchManhourAll();
        //}

        //public List<LibpipeschmanhourDTO> JsonGetLibPipeSchManhourAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSchManhourAll();
        //}

        //public LibpipeschmanhourDTO GetLibPipeSchManhourByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSchManhourByID(Id);
        //}

        //public LibpipeschmanhourDTO JsonGetLibPipeSchManhourByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSchManhourByID(Int32.Parse(Id));
        //}

        //public LibpipemanhourDTO GetLibPipeManhourByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManhourByID(Id);
        //}

        //public LibpipeschmanhourPageTotal GetLibPipeSchManhourForPaging(int selectedPage, int pageSize, int PipeType, int SearchOption, decimal PipeSize, int selectoption, int luid1, int luid2, int luid3, int luid4, string PipeThickSch)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSchManhourForPaging(selectedPage, pageSize, PipeType, SearchOption, PipeSize, selectoption, luid1, luid2, luid3, luid4, PipeThickSch);
        //}

        //public LibpipeschmanhourPageTotal JsonGetLibPipeSchManhourForPaging(string selectedPage, string pageSize, string PipeType, string SearchOption, string PipeSize, string selectoption, string luid1, string luid2, string luid3, string luid4, string PipeThickSch)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeSchManhourForPaging(Int32.Parse(selectedPage), Int32.Parse(pageSize), Int32.Parse(PipeType), Int32.Parse(SearchOption), Decimal.Parse(PipeSize), Int32.Parse(selectoption), Int32.Parse(luid1), Int32.Parse(luid2), Int32.Parse(luid3), Int32.Parse(luid4), PipeThickSch);
        //}

        //public LibpipemanhourPageTotal GetLibPipeManHourForPaging(int selectedPage, int pageSize, int PipeType, int MaterialType, decimal PipeSize, string PipeClass, string PipeSCH)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibPipeManHourForPaging(selectedPage, pageSize, PipeType, MaterialType, PipeSize, PipeClass, PipeSCH);
        //}

        //#endregion "LibPipe"


        //#region "Calendar"

        //public List<CalendarDTO> GetProjectCalendar(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetCalendarByID(Id);
        //}

        //public List<CalendarDTO> JsonGetProjectCalendar(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetCalendarByID(Int32.Parse(Id));
        //}

        //public List<CalendarDTO> GetCalendarByProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetCalendarByProject(projectId);
        //}

        //public List<CalendarDTO> JsonGetCalendarByProject(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetCalendarByProject(Int32.Parse(projectId));
        //}

        //#endregion "Calendar"

        //#region "Schedule"

        //public List<ProjectscheduleDTO> GetProjectScheduleAllByProjectID(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleAllByProjectID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<ProjectscheduleDTO> JsonGetProjectScheduleAllByProjectID(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleAllByProjectID(Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public List<ProjectscheduleDTO> GetProjectScheduleAllByProjectIDModuleID(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleAllByProjectIDModuleID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        public List<ProjectscheduleDTO> JsonGetProjectScheduleAllByProjectIDModuleID(string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetProjectScheduleAllByProjectIDModuleID(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<ProjectscheduleDTO> GetProjectScheduleByProjectWithWBS(int projectId, string disciplineCode)
        //{
         //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByProjectIDWidthWBS(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        public List<ProjectscheduleDTO> JsonGetProjectScheduleByProjectWithWBS(string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetScheduledWorkItemByProjectID(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), 1);
        }

        //public List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectIDWithWBS(int cwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByCwpProjectIDWithWBS(cwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        public List<ProjectscheduleDTO> JsonGetProjectScheduleByCwpProjectIDWithWBS(string cwpId, string projectId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetProjectScheduleByCwpProjectIDWithWBS(Int32.Parse(cwpId), Int32.Parse(projectId));
        }

        //public List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectWithWBS(int cwpId, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByCwpProjectWithWBS(cwpId, projectId);
        //}

        //public List<ProjectscheduleDTO> JsonGetProjectScheduleByCwpProjectWithWBS(string cwpId, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByCwpProjectWithWBS(Int32.Parse(cwpId), Int32.Parse(projectId));
        //}

        //public List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectPackageTypeWithWBS(int cwpId, int projectId, int packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByCwpProjectPackageTypeWithWBS(cwpId, projectId, packagetypeLuid);
        //}

        public List<ProjectscheduleDTO> JsonGetProjectScheduleByCwpProjectPackageTypeWithWBS(string cwpId, string projectId, string packageTypeCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetProjectScheduleByCwpProjectPackageTypeWithWBS(Int32.Parse(cwpId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(packageTypeCode));
        }

        //public List<ProjectscheduleDTO> GetProjectScheduleByProjectID(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByProjectID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        public List<ProjectscheduleDTO> JsonGetProjectScheduleByProjectID(string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetScheduledWorkItemByProjectID(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), 0);
        }

        //public List<ProjectscheduleDTO> GetProjectScheduleByCWPProjectID(int cwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByCWPProjectID(cwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<ProjectscheduleDTO> JsonGetProjectScheduleByCWPProjectID(string cwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetProjectScheduleByCWPProjectID(Int32.Parse(cwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public ProjectscheduleDTO GetProjectScheduleByFIWPID(int fiwpId)
        //{
        //    return (new BALC.ScheduleReader()).GetProjectScheduleByFIWPID(fiwpId);
        //}

        //public ProjectscheduleDTO JsonGetProjectScheduleByFIWPID(string fiwpId)
        //{
        //    return (new BALC.ScheduleReader()).GetProjectScheduleByFIWPID(Int32.Parse(fiwpId));
        //}

        //public ProjectscheduleDTO GetSignleProjscheduleByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetSignleProjscheduleByID(Id);
        //}

        public ProjectscheduleDTO JsonGetSignleProjscheduleByID(string scheduledWorkItemId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetSignleProjscheduleByID(Int32.Parse(scheduledWorkItemId));
        }

        //public List<ProjectscheduleDTO> GetProjectScheduleByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetScheduleByID(Id);
        //}

        //public List<ProjectscheduleDTO> JsonGetProjectScheduleByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetScheduleByID(Int32.Parse(Id));
        //}

        //public List<ProjectscheduleDTO> GetP6Project()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetP6Project();
        //}

        //public List<ProjectscheduleDTO> JsonGetP6Project()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetP6Project();
        //}

        //public int CompareDateEnd(FiwpDTO fiwp)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).CompareFinishDate(fiwp);
        //}

        //public int JsonCompareDateEnd(FiwpDTO fiwp)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).CompareFinishDate(fiwp);
        //}

        //public bool CheckAssignedFIWP(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).CheckAssignedFIWP(fiwpId);
        //}

        //#endregion "Schedule"

        //#region "Fiwp"

        //public List<FiwpDTO> GetFiwpByProjectID(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByProjectID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<FiwpDTO> JsonGetFiwpByProjectID(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByProjectID(Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public List<FiwpDTO> GetFiwpByScheduleID(int scheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByScheduleID(scheduleId);
        //}

        //public List<FiwpDTO> JsonGetFiwpByScheduleID(string scheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByScheduleID(Int32.Parse(scheduleId));
        //}

        //public List<FiwpDTO> GetFiwpByCwpSchedule(int cwpId, int projectScheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByCwpSchedule(cwpId, projectScheduleId);
        //}

        //public List<FiwpDTO> JsonGetFiwpByCwpSchedule(string cwpId, string projectScheduleId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByCwpSchedule(Int32.Parse(cwpId), Int32.Parse(projectScheduleId));
        //}

        //public List<FiwpDTO> GetFiwpByCwpSchedulePackageType(int cwpId, int projectScheduleId, int packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByCwpSchedulePackageType(cwpId, projectScheduleId, packagetypeLuid);
        //}

        public List<FiwpDTO> JsonGetFiwpByCwpSchedulePackageType(string cwpId, string scheduledWorkItemId, string packageTypeCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetFiwpByCwpSchedulePackageType(Int32.Parse(cwpId), Int32.Parse(scheduledWorkItemId), Helper.RemoveJsonParameterWrapper(packageTypeCode));
        }

        //public List<FiwpDTO> GetFiwpByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpByID(Id);
        //}

        public List<FiwpDTO> JsonGetFiwpByID(string iwpId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetFiwpByID(Int32.Parse(iwpId));
        }

        //public FiwpDTO GetSingleFiwpByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetSingleFiwpByID(Id);
        //}

        //public FiwpDTO JsonGetSingleFiwpByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetSingleFiwpByID(Int32.Parse(Id));
        //}

        //public List<FiwpDTO> GetFiwpBySystemID(int SystemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpBySystemID(SystemId);
        //}

        //public List<FiwpDTO> JsonGetFiwpBySystemID(string SystemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpBySystemID(Int32.Parse(SystemId));
        //}

        //public List<FiwpDTO> GetFiwpBySystemPackageType(int projectId, int systemId, int packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpBySystemPackageType(projectId, systemId, packagetypeLuid);
        //}

        //public List<FiwpDTO> JsonGetFiwpBySystemPackageType(string projectId, string systemId, string packagetypeLuid)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpBySystemPackageType(Int32.Parse(projectId), Int32.Parse(systemId), Int32.Parse(packagetypeLuid));
        //}

        //public FiwpDTO GetFiwpWithFiwpwfpByID(int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpWithFiwpwfpByID(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public FiwpDTO JsonGetFiwpWithFiwpwfpByID(string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpWithFiwpwfpByID(Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public List<FiwpworkflowDTO> GetFiwpworkflowByFiwp(int fiwpId, int isLatest)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpworkflowByFiwp(fiwpId, isLatest);
        //}

        //public List<FiwpworkflowDTO> JsonGetFiwpworkflowByFiwp(string fiwpId, string isLatest)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpworkflowByFiwp(Int32.Parse(fiwpId), Int32.Parse(isLatest));
        //}

        //public List<FiwpworkflowDTO> GetFiwpworkflowByFiwpPersonnel(int fiwpId, int personnelId, int approvalStatus, int forApproval, int projectId, string disciplineCode)
        //{
        //    return (new BALC.ScheduleReader()).GetFiwpworkflowByFiwpPersonnel(fiwpId, personnelId, approvalStatus, forApproval, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<FiwpworkflowDTO> JsonGetFiwpworkflowByFiwpPersonnel(string fiwpId, string personnelId, string approvalStatus, string forApproval, string projectId, string disciplineCode)
        //{
        //    return (new BALC.ScheduleReader()).GetFiwpworkflowByFiwpPersonnel(Int32.Parse(fiwpId), Int32.Parse(personnelId), Int32.Parse(approvalStatus), Int32.Parse(forApproval), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public FiwpworkflowDTO GetFiwpworkflowByID(int fiwpWPId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpworkflowByID(fiwpWPId);
        //}

        //public FiwpworkflowDTO JsonGetFiwpworkflowByID(string fiwpWPId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpworkflowByID(Int32.Parse(fiwpWPId));
        //}

        //public List<FiwpmanpowerDTO> GetFiwpManPowerByProjectScheduleID(int scheduleId, int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpManPowerByProjectScheduleID(scheduleId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<FiwpmanpowerDTO> JsonGetFiwpManPowerByProjectScheduleID(string scheduleId, string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpManPowerByProjectScheduleID(Int32.Parse(scheduleId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public List<FiwpcommentDTO> GetFiwpcommentByFiwp(int fiwpId, DateTime workdate)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpcommentByFiwp(fiwpId, workdate);
        //}

        //public List<FiwpcommentDTO> JsonGetFiwpcommentByFiwp(string fiwpId, string workdate)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpcommentByFiwp(Int32.Parse(fiwpId), DateTime.Parse(workdate));
        //}

        //public List<FiwpmaterialDTO> GetFiwpmaterialByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpmaterialByID(id);
        //}

        //public List<FiwpmaterialDTO> JsonGetFiwpmaterialByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpmaterialByID(Int32.Parse(id));
        //}

        //public List<FiwpmaterialDTO> GetFiwpMaterialByFIWP(int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpMaterialByFIWP(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        public List<FiwpmaterialDTO> JsonGetFiwpMaterialByFIWP(string fiwpId, string projectId, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).GetFiwpMaterialByFIWP(Int32.Parse(fiwpId), Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode));
        }

        //public List<FiwpmaterialDTO> GetFiwpmaterialAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpmaterialAll();
        //}

        //public List<FiwpmaterialDTO> JsonGetFiwpmaterialAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpmaterialAll();
        //}

        //#endregion "Fiwp"

        //#region "Timesheet"

        //public TimesheetDTO GetTimesheetByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByID(id);
        //}

        //public TimesheetDTO JsonGetTimesheetByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByID(Int32.Parse(id));
        //}

        //public TimeallocationDTO GetTimeallocationByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimeallocationByID(id);
        //}

        //public TimeallocationDTO JsonGetTimeallocationByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimeallocationByID(Int32.Parse(id));
        //}

        //public List<TimesheetDTO> GetTimesheetAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetAll();
        //}

        //public List<TimesheetDTO> JsonGetTimesheetAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetAll();
        //}

        //public List<TimesheetDTO> GetTimesheetByWorkdateCostcodeDepartstructure(DateTime workDate, int costcodeId, int departstructureId, int projectId, string disciplineCode, int ishistory)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByWorkdateCostcodeDepartstructure(workDate, costcodeId, departstructureId, 0, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), ishistory);
        //}

        //public List<TimesheetDTO> JsonGetTimesheetByWorkdateCostcodeDepartstructure(string workDate, string costcodeId, string departstructureId, string projectId, string disciplineCode, string ishistory)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByWorkdateCostcodeDepartstructure(DateTime.Parse(workDate), Int32.Parse(costcodeId), Int32.Parse(departstructureId), 0, Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(ishistory));
        //}

        //public List<TimesheetDTO> GetTimesheetByWorkdateDailyTimeSheet(DateTime workDate, int costcodeId, int departstructureId, int dailytimesheetId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByWorkdateCostcodeDepartstructure(workDate, costcodeId, departstructureId, dailytimesheetId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), 0);
        //}

        //public List<TimesheetDTO> JsonGetTimesheetByWorkdateDailyTimeSheet(string workDate, string costcodeId, string departstructureId, string dailytimesheetId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByWorkdateCostcodeDepartstructure(DateTime.Parse(workDate), Int32.Parse(costcodeId), Int32.Parse(departstructureId), Int32.Parse(dailytimesheetId), Int32.Parse(projectId), Int32.Parse(disciplineCode), 0);
        //}

        //public List<TimeallocationDTO> GetTimeallocationForGroup(int cwpId, int fiwpId, int materialCategoryId, DateTime installeddate, int ruleofcreditId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimeallocationForGroup(cwpId, fiwpId, materialCategoryId, installeddate, ruleofcreditId);
        //}

        //public List<TimeallocationDTO> JsonGetTimeallocationForGroup(string cwpId, string fiwpId, string materialCategoryId, string installeddate, string ruleofcreditId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimeallocationForGroup(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(materialCategoryId), DateTime.Parse(installeddate), Int32.Parse(ruleofcreditId));
        //}

        //public List<TimesheetAndProgress> GetTimesheetAndProgressByWorkdateDepartStructure(DateTime workdate, int departstructureId, int dailytimesheetId, int projectId, string disciplineCode, int ishistory)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetAndProgressByWorkdateDepartStructure(workdate, departstructureId, dailytimesheetId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), ishistory);
        //}

        //public List<TimesheetAndProgress> JasonGetTimesheetAndProgressByWorkdateDepartStructure(string workdate, string departstructureId, string dailytimesheetId, string projectId, string disciplineCode, string ishistory)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetAndProgressByWorkdateDepartStructure(DateTime.Parse(workdate), Int32.Parse(departstructureId), Int32.Parse(dailytimesheetId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(ishistory));
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="fiwpId"></param>
        ///// <param name="flg">2: retrieve all timesheet, 1: retrieve direct timesheet with progressId, 0: retrieve indirect tiemsheet.</param>
        ///// <returns></returns>
        //public List<TimesheetDTO> GetTimesheetByFiwp(int fiwpId, int flg)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByFiwp(fiwpId, flg);
        //}

        //public List<TimesheetDTO> JsonGetTimesheetByFiwp(string fiwpId, string flg)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByFiwp(Int32.Parse(fiwpId), Int32.Parse(flg));
        //}

        //public List<TimesheetDTO> GetTimesheetByTimeAllocationID(int timeallocationId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByTimeAllocationID(timeallocationId);
        //}

        //public List<TimesheetDTO> JsonGetTimesheetByTimeAllocationID(string timeallocationId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByTimeAllocationID(Int32.Parse(timeallocationId));
        //}

        //public List<TimesheetDTO> GetTimeSheetTableByCWP(int cwpId)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimeSheetTableByCWP(cwpId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<TimesheetDTO> JsonGetTimeSheetTableByCWP(string cwpId)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimeSheetTableByCWP(Int32.Parse(cwpId));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <param name="flg">2: retrieve all timesheet, 1: retrieve direct timesheet with progressId, 0: retrieve indirect tiemsheet.</param>
        //public List<TimesheetDTO> GetTimesheetByFiwpWorkdate(int fiwpId, DateTime workDate, int projectId, string disciplineCode, int flg)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByFiwpWorkdate(fiwpId, workDate, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), flg);
        //}

        //public List<TimesheetDTO> JsonGetTimesheetByFiwpWorkdate(string fiwpId, string workDate, string projectId, string disciplineCode, string flg)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByFiwpWorkdate(Int32.Parse(fiwpId), DateTime.Parse(workDate), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(flg));
        //}

        //public List<TimesheetDTO> GetTimesheetByWorkdatePersonnelID(int personnelId, DateTime workDate, int projectId, string disciplineCode, int flg)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByWorkdatePersonnelID(personnelId, workDate, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), flg);
        //}

        //public List<TimesheetDTO> JsonGetTimesheetByWorkdatePersonnelID(string personnelId, string workDate, string projectId, string disciplineCode, string flg)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByWorkdatePersonnelID(Int32.Parse(personnelId), DateTime.Parse(workDate), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(flg));
        //}

        //public TimesheetTaskAndValue GetTimesheetTaskByCrew(int cwpId, int fiwpId, int materialcategoryId, DateTime workDate, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetTaskByCrew(cwpId, fiwpId, materialcategoryId, workDate, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public TimesheetTaskAndValue JsonGetTimesheetTaskByCrew(string cwpId, string fiwpId, string materialcategoryId, string workDate, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetTaskByCrew(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(materialcategoryId), DateTime.Parse(workDate), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public TimesheetTaskAndValue GetTimesheetByCrewForMultiPool(int cwpId, int fiwpId, int materialcategoryId, DateTime workDate, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByCrewForMultiPool(cwpId, fiwpId, materialcategoryId, workDate, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public TimesheetTaskAndValue JsonGetTimesheetByCrewForMultiPool(string cwpId, string fiwpId, string materialcategoryId, string workDate, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetByCrewForMultiPool(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(materialcategoryId), DateTime.Parse(workDate), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public TimesheetTaskAndValue GetTimesheetForOtherByCrew(int cwpId, int fiwpId, int materialcategoryId, DateTime workDate, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetTaskByCrew(cwpId, fiwpId, materialcategoryId, workDate, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public TimesheetTaskAndValue JsonGetTimesheetForOtherByCrew(string cwpId, string fiwpId, string materialcategoryId, string workDate, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetTimesheetTaskByCrew(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(materialcategoryId), DateTime.Parse(workDate), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public List<DailytimesheetDTO> GetDailytimesheetByID(int Id)
        //{
        //    return (new BALC.ProjectReader()).GetDailytimesheetByID(Id);
        //}

        //public List<DailytimesheetDTO> JsonGetDailytimesheetByID(string Id)
        //{
        //    return (new BALC.ProjectReader()).GetDailytimesheetByID(Int32.Parse(Id));
        //}
        //#endregion "Timesheet"

        //#region "RFI"

        //public RfiDTO GetRfiByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiByID(Id);
        //}

        //public RfiDTO JsonGetRfiByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiByID(Int32.Parse(Id));
        //}

        //public List<RfiDTO> GetRfiByProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiByProject(projectId);
        //}

        //public List<RfiDTO> JsonGetRfiByProject(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiByProject(Int32.Parse(projectId));
        //}

        //public List<RfiDTO> GetRfiByProjectModule(int Id, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiByProjectModule(Id, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<RfiDTO> JsonGetRfiByProjectModule(string Id, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRfiByProjectModule(Int32.Parse(Id), Int32.Parse(disciplineCode));
        //}

        //public List<RfiDTO> GetRFIByCWPDrawing(int CWPID, int DrawingID, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRFIByCWPDrawing(CWPID, DrawingID, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<RfiDTO> JsonGetRFIByCWPDrawing(string CWPID, string DrawingID, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetRFIByCWPDrawing(Int32.Parse(CWPID), Int32.Parse(DrawingID), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //#endregion "End RFI"

        //#region "Lib"

        //public List<LibconsumableDTO> GetLibconsumableAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetLibconsumableAll();
        //}

        public List<LibconsumableDTO> JsonGetLibconsumableAll()
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetLibconsumableAll();
        }

        //#endregion

        //#region IOS
        //public List<string> JsonGetDocumentByFiwpForIOS(string fiwpid, string projectid, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDocumentByFiwpForIOS(Int32.Parse(fiwpid), Int32.Parse(projectid), Int32.Parse(disciplineCode));
        //}

        public List<string> JsonGetIwpDocumentFilterByIwp(string fiwpid, string projectid, string disciplineCode)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).GetIwpDocumentFilterByIwp(Int32.Parse(fiwpid), Int32.Parse(projectid), disciplineCode);
        }
        

        ////public List<DocumentnoteDTO> JsonSaveDocumentNoteByIOS(string documentnoteid, string spcollectionid, string fiwpid, string description, string updatedby, string updateddate, string locationx, string locationy)
        //public List<DocumentnoteDTO> JsonSaveDocumentNoteByIOS(DocumentnoteDTO list, string spcollectionid, string fiwpid)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveDocumentNoteByIOS(list, spcollectionid, fiwpid);
        //}

        public List<DrawingStickyNoteDTO> JsonSaveDrawingStickyNote(DrawingStickyNoteDTO list, string iwpId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).SaveDrawingStickyNote(list, Int32.Parse(iwpId));
        }

        //#endregion IOS

        //#region "DocumentMarkup"

        ///// <summary>
        ///// Retrieve Documentmarkup object which markup contains the specified unique identifier to match. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Documentmarkup unique identifier to search for</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public DocumentmarkupDTO GetDocumentmarkupByID(int Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDocumentmarkupByID(Id);
        //}

        ///// <summary>
        ///// Retrieve Documentmarkup object which markup contains the specified unique identifier to match. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="Id">Documentmarkup unique identifier to search for</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public DocumentmarkupDTO JsonGetDocumentmarkupByID(string Id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDocumentmarkupByID(Int32.Parse(Id));
        //}

        ///// <summary>
        ///// Retrieve Documentmarkup objects which markup contains the specified DrawingID and PersonnelID to match. 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="personnelId">PersonnelID to search for</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public List<DocumentmarkupDTO> GetDocumentmarkupByDrawingPersonnel(int drawingId, int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDocumentmarkupByDrawingPersonnel(drawingId, personnelId);
        //}

        /// <summary>
        /// Retrieve Documentmarkup objects which markup contains the specified DrawingID and PersonnelID to match. 
        /// </summary>
        /// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        /// <param name="drawingId">DrawingID to search for</param>
        /// <param name="personnelId">PersonnelID to search for</param>
        /// <returns>DocumentmarkupDTO</returns>
        public List<DocumentmarkupDTO> JsonGetDocumentmarkupByDrawingPersonnel(string drawingId, string personnelId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).GetDocumentmarkupByDrawingPersonnel(Int32.Parse(drawingId), Helper.RemoveJsonParameterWrapper(personnelId), Helper.GetWebrootUrl());
        }

        ///// <summary>
        ///// Retrieve all Documentmarkup objects
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public List<DocumentmarkupDTO> GetDocumentmarkupAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDocumentmarkupAll();
        //}

        ///// <summary>
        ///// Retrieve all Documentmarkup objects
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public List<DocumentmarkupDTO> JsonGetDocumentmarkupAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDocumentmarkupAll();
        //}

        ///// <summary>
        ///// Retrieve DrawingAndMarkup object which drawing contains the specified DrawingID and PersonnelID to match and related documentmakup.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="personnelId">PersonnelID to search for</param>
        ///// <returns>DrawingAndMarkup</returns>
        //public DrawingAndMarkup GetDrawingDocumentmarkupByDrawingPersonnel(int drawingId, int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingDocumentmarkupByDrawingPersonnel(drawingId, personnelId);
        //}

        ///// <summary>
        ///// Retrieve DrawingAndMarkup object which drawing contains the specified DrawingID and PersonnelID to match and related documentmakup.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="drawingId">DrawingID to search for</param>
        ///// <param name="personnelId">PersonnelID to search for</param>
        ///// <returns>DrawingAndMarkup</returns>
        //public DrawingAndMarkup JsonGetDrawingDocumentmarkupByDrawingPersonnel(string drawingId, string personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingDocumentmarkupByDrawingPersonnel(Int32.Parse(drawingId), Int32.Parse(personnelId));
        //}

        //#endregion

        //#region "Sigma Crew"
        ///// <summary>
        ///// Retrieve all ToolBoxTalksTemplate, Crew Picture Image Document List, TimeSheet Upload - by blee , 20130826~0829
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>DocumentDTO</returns>
        //public List<DocumentDTO> GetSafetyDocumentsList(int projectId, string collection, string docName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSafetyDocumentsList(projectId, collection, docName, null, Cookies.GetSPCredential());
        //}

        //public List<DocumentDTO> JsonGetSafetyDocumentsList(string projectId, string collection, string docName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSafetyDocumentsList(Int32.Parse(projectId), collection, docName, null, Cookies.GetSPCredential());
        //}

        //public List<DocumentDTO> GetCrewDocumentsList(int projectId, string collection, string[] docName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCrewDocumentsList(projectId, collection, docName, null, Cookies.GetSPCredential());
        //}

        //public List<DocumentDTO> JsonGetCrewDocumentsList(string projectId, string collection, string[] docName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetCrewDocumentsList(Int32.Parse(projectId), collection, docName, null, Cookies.GetSPCredential());
        //}

        //public List<DailybrassDTO> GetDailybrassByForemanPersonnelWorkDate(int projectId, string disciplineCode, int personnelId, DateTime workDate)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDailybrassByForemanPersonnelWorkDate(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), personnelId, workDate);
        //}

        public List<DailybrassDTO> JsonGetDailybrassByForemanWorkdate(string projectId, string disciplineCode, string foremanId, string workDate)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Brass()).GetDailybrassByForemanWorkdate(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(disciplineCode), Helper.RemoveJsonParameterWrapper(foremanId), DateTime.Parse(workDate));
        }

        //public List<DailytoolboxDTO> GetDailytoolboxByDailyBrass(int dailybrassId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDailytoolboxByDailyBrass(dailybrassId);
        //}

        //public List<DailytoolboxDTO> JsonGetDailytoolboxByDailyBrass(string dailybrassId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDailytoolboxByDailyBrass(Int32.Parse(dailybrassId));
        //}

        //public List<DailybrasssignDTO> GetDailybrasssignByDailyBrass(int dailybrassId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDailybrasssignByDailyBrass(dailybrassId);
        //}

        public List<DailybrasssignDTO> JsonGetDailybrasssignByDailyBrass(string dailybrassId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Brass()).GetDailybrasssignByDailyBrass(Int32.Parse(dailybrassId));
        }

        //#endregion "Sigma Crew"

        //#region "Sigma Cue(Message)"
        //public List<SigmacueDTO> GetSigmacueByPersonnel(int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSigmacueByPersonnel(personnelId);
        //}

        //public List<SigmacueDTO> JsonGetSigmacueByPersonnel(string personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSigmacueByPersonnel(Int32.Parse(personnelId));
        //}
        //#endregion "Sigma Cue(Message)"

        //#region "FiwpQAQC"

        ///// <summary>
        ///// Retrieve Fiwpqaqc objects which fiwpqaqc contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Fiwpqaqc unique identifier to search for</param>        
        ///// <returns>FiwpqaqcDTO</returns>
        //public FiwpqaqcDTO GetFiwpqaqcByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpqaqcByID(id);
        //}

        ///// <summary>
        ///// Retrieve Fiwpqaqc objects which fiwpqaqc contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Fiwpqaqc unique identifier to search for</param>
        ///// <returns>FiwpqaqcDTO</returns>
        //public FiwpqaqcDTO JsonGetFiwpqaqcByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpqaqcByID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve all Fiwpqaqc objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>List<FiwpqaqcDTO></returns>
        //public List<FiwpqaqcDTO> GetFiwpqaqcAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpqaqcAll();
        //}

        ///// <summary>
        ///// Retrieve all Fiwpqaqc objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>List<FiwpqaqcDTO></returns>
        //public List<FiwpqaqcDTO> JsonGetFiwpqaqcAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpqaqcAll();
        //}

        ///// <summary>
        ///// Retrieve Fiwpqaqc objects which fiwpqaqc contains the specified FIWPID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <returns>List<FiwpqaqcDTO></returns>
        //public List<FiwpqaqcDTO> GetFiwpqaqcByFIWP(int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpqaqcByFIWP(fiwpId);
        //}

        ///// <summary>
        ///// Retrieve Fiwpqaqc objects which fiwpqaqc contains the specified FIWPID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpId">FIWPID to search for</param>
        ///// <returns>List<FiwpqaqcDTO></returns>
        //public List<FiwpqaqcDTO> JsonGetFiwpqaqcByFIWP(string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleReader()).GetFiwpqaqcByFIWP(Int32.Parse(fiwpId));
        //}

        //#endregion "FiwpQAQC"

        //#region "QAQC config"

        ///// <summary>
        ///// Retrieve Qaqcconfig objects which qaqcconfig contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Qaqcconfig unique identifier to search for</param>        
        ///// <returns>QaqcconfigDTO</returns>
        //public QaqcconfigDTO GetQaqcconfigByID(int id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcconfigByID(id);
        //}

        ///// <summary>
        ///// Retrieve Qaqcconfig objects which qaqcconfig contains the specified unique identifier to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="id">Qaqcconfig unique identifier to search for</param>
        ///// <returns>QaqcconfigDTO</returns>
        //public QaqcconfigDTO JsonGetQaqcconfigByID(string id)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcconfigByID(Int32.Parse(id));
        //}

        ///// <summary>
        ///// Retrieve all Qaqcconfig objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>List<QaqcconfigDTO></returns>
        //public List<QaqcconfigDTO> GetQaqcconfigAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcconfigAll();
        //}

        ///// <summary>
        ///// Retrieve all Qaqcconfig objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <returns>List<QaqcconfigDTO></returns>
        //public List<QaqcconfigDTO> JsonGetQaqcconfigAll()
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcconfigAll();
        //}

        //#endregion "QAQC config"

        //#region "Quantity_Survey"
        ///// <summary>
        ///// GetFiwpByProgressCompleted
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">projectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="personnelId">personnelId to search for</param>
        ///// <returns>List<ProgressruleofcreditCompletedDTO></returns>
        //public List<ProgressruleofcreditCompletedDTO> GetFiwpByProgressCompleted(int projectId, string disciplineCode, int personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFiwpByProgressCompleted(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), personnelId);
        //}
        ///// <summary>
        ///// JsonGetFiwpByProgressCompleted
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">projectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="personnelId">personnelId to search for</param>
        ///// <returns>List<ProgressruleofcreditCompletedDTO></returns>
        //public List<ProgressruleofcreditCompletedDTO> JsonGetFiwpByProgressCompleted(string projectId, string disciplineCode, string personnelId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetFiwpByProgressCompleted(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(personnelId));
        //}

        ///// <summary>
        ///// GetDrawingByFiwpProgressCompleted
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">projectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpId">cwpId to search for</param>
        ///// <param name="projectscheduleId">projectscheduleId to search for</param>
        ///// <param name="fiwpId">fiwpId to search for</param>
        ///// <returns>List<DrawingDTO></returns>
        //public List<DrawingDTO> GetDrawingByFiwpProgressCompleted(int projectId, string disciplineCode, int cwpId, int projectscheduleId, int fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByFiwpProgressCompleted(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), cwpId, projectscheduleId, fiwpId, Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// JsonGetDrawingByFiwpProgressCompleted
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">projectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpId">cwpId to search for</param>
        ///// <param name="projectscheduleId">projectscheduleId to search for</param>
        ///// <param name="fiwpId">fiwpId to search for</param>
        ///// <returns>List<DrawingDTO></returns>
        //public List<DrawingDTO> JsonGetDrawingByFiwpProgressCompleted(string projectId, string disciplineCode, string cwpId, string projectscheduleId, string fiwpId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDrawingByFiwpProgressCompleted(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Int32.Parse(fiwpId), Helper.GetImageLocationURL());
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">projectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpId">cwpId to search for</param>
        ///// <param name="projectscheduleId">projectscheduleId to search for</param>
        ///// <param name="fiwpId">fiwpId to search for</param>
        ///// <param name="drawingId">drawingId to search for</param>
        ///// <returns>List<QuantityserveyDTO></returns>
        //public List<QuantityserveyDTO> GetComponentByDrawingProgressCompleted(int projectId, string disciplineCode, int cwpId, int projectscheduleId, int fiwpId, int drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByDrawingProgressCompleted(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), cwpId, projectscheduleId, fiwpId, drawingId);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">projectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <param name="cwpId">cwpId to search for</param>
        ///// <param name="projectscheduleId">projectscheduleId to search for</param>
        ///// <param name="fiwpId">fiwpId to search for</param>
        ///// <param name="drawingId">drawingId to search for</param>
        ///// <returns>List<QuantityserveyDTO></returns>
        //public List<QuantityserveyDTO> JsonGetComponentByDrawingProgressCompleted(string projectId, string disciplineCode, string cwpId, string projectscheduleId, string fiwpId, string drawingId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentByDrawingProgressCompleted(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(cwpId), Int32.Parse(projectscheduleId), Int32.Parse(fiwpId), Int32.Parse(drawingId));
        //}
        //#endregion "Quantity_Survey"

        //#region "Turnover"
        ///// <summary>
        ///// Retrieve ContractorProejct By OwnerProject
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <returns>List<ProjectDTO></returns>
        //public List<ProjectDTO> GetContractorProejctByOwnerProject(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetContractorProejctByOwnerProject(projectId);
        //}
        ///// <summary>
        ///// Retrieve ContractorProejct By OwnerProject
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <returns>List<ProjectDTO></returns>
        //public List<ProjectDTO> JsonGetContractorProejctByOwnerProject(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetContractorProejctByOwnerProject(Int32.Parse(projectId));
        //}

        ///// <summary>
        ///// Retrieve System By TurnoverProject
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <param name="constractorId">ConstractorId to search for</param>
        ///// <returns>List<SystemDTO></returns>
        //public List<SystemDTO> GetSystemByTurnoverProject(int projectId, int constractorId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSystemByTurnoverProject(projectId, constractorId);
        //}
        ///// <summary>
        ///// Retrieve System By Turnover Project
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <param name="constractorId">ConstractorId to search for</param>
        ///// <returns>List<SystemDTO></returns>
        //public List<SystemDTO> JsonGetSystemByTurnoverProject(string projectId, string constractorId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetSystemByTurnoverProject(Int32.Parse(projectId), Int32.Parse(constractorId));
        //}

        ///// <summary>
        ///// Retrieve Module By Turnover System
        ///// </summary>
        ///// <param name="dbname"></param>
        ///// <param name="projectId"></param>
        ///// <param name="constractorId"></param>
        ///// <param name="systemId"></param>
        ///// <returns>List<ModuleDTO></returns>
        //public List<ModuleDTO> GetModuleByTurnoverSystem(int projectId, int constractorId, int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetModuleByTurnoverSystem(projectId, constractorId, systemId);
        //}
        ///// <summary>
        ///// Retrieve Module By Turnover System
        ///// </summary>
        ///// <param name="dbname"></param>
        ///// <param name="projectId"></param>
        ///// <param name="constractorId"></param>
        ///// <param name="systemId"></param>
        ///// <returns>List<ModuleDTO></returns>
        //public List<ModuleDTO> JsonGetModuleByTurnoverSystem(string projectId, string constractorId, string systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetModuleByTurnoverSystem(Int32.Parse(projectId), Int32.Parse(constractorId), Int32.Parse(systemId));
        //}

        ///// <summary>
        ///// Retrieve WalkDown By System
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="projectId"></param>
        ///// <param name="constractorId"></param>
        ///// <param name="systemId"></param>
        ///// <param name="disciplineCode"></param>
        ///// <returns>WalkdownDTOSet</returns>
        //public WalkdownDTOSet GetWalkDownBySystem(int projectId, int constractorId, int systemId, List<int> disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetWalkDownBySystem(projectId, constractorId, systemId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}
        ///// <summary>
        ///// Retrieve WalkDown By System
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="projectId"></param>
        ///// <param name="constractorId"></param>
        ///// <param name="systemId"></param>
        ///// <param name="moduleIds"></param>
        ///// <returns>WalkdownDTOSet</returns>
        //public WalkdownDTOSet JsonGetWalkDownBySystem(string projectId, string constractorId, string systemId, string disciplineCodes)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetWalkDownBySystem(Int32.Parse(projectId), Int32.Parse(constractorId), Int32.Parse(systemId), Helper.GetIntParameter(moduleIds));
        //}

        ///// <summary>
        ///// Retrieve Qaqcform By System
        ///// </summary>
        ///// <param name="dbname"></param>
        ///// <param name="systemId"></param>
        ///// <returns>List<QaqcformDTO></returns>
        //public List<QaqcformDTO> GetQaqcformBySystem(int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformBySystem(systemId);
        //}
        ///// <summary>
        ///// Retrieve Qaqcform By System
        ///// </summary>
        ///// <param name="dbname"></param>
        ///// <param name="systemId"></param>
        ///// <returns>List<QaqcformDTO></returns>
        //public List<QaqcformDTO> JsonGetQaqcformBySystem(string systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformBySystem(Int32.Parse(systemId));
        //}

        ///// <summary>
        ///// Retrieve Qaqcform By SystemFormtype
        ///// </summary>
        ///// <param name="dbname"></param>
        ///// <param name="projectId"></param>
        ///// <param name="disciplineCode"></param>
        ///// <param name="systemId"></param>
        ///// <param name="formtype"></param>
        ///// <returns>List<QaqcformDTO></returns>
        //public List<QaqcformDTO> GetQaqcformBySystemFormtype(int projectId, string disciplineCode, int systemId, int formtype)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformBySystemFormtype(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), systemId, formtype);
        //}
        ///// <summary>
        ///// Retrieve Qaqcform By SystemFormtype
        ///// </summary>
        ///// <param name="dbname"></param>
        ///// <param name="projectId"></param>
        ///// <param name="disciplineCode"></param>
        ///// <param name="systemId"></param>
        ///// <param name="formtype"></param>
        ///// <returns>List<QaqcformDTO></returns>
        //public List<QaqcformDTO> JsonGetQaqcformBySystemFormtype(string projectId, string disciplineCode, string systemId, string formtype)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformBySystemFormtype(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(systemId), Int32.Parse(formtype));
        //}

        ///// <summary>
        ///// Retrieve Qaqcform By Personnel & Department
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="projectId"></param>
        ///// <param name="disciplineCode"></param>
        ///// <param name="personnelId"></param>
        ///// <param name="departmentId"></param>
        ///// <returns></returns>
        //public List<QaqcformdetailDTO> GetQaqcformByPersonnelDepartment(int projectId, string disciplineCode, int personnelId, int departmentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByPersonnelDepartment(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), personnelId, departmentId);
        //}
        ///// <summary>
        ///// Retrieve Qaqcform By Personnel & Department
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="projectId"></param>
        ///// <param name="disciplineCode"></param>
        ///// <param name="personnelId"></param>
        ///// <param name="departmentId"></param>
        ///// <returns></returns>
        //public List<QaqcformdetailDTO> JsonGetQaqcformByPersonnelDepartment(string projectId, string disciplineCode, string personnelId, string departmentId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformByPersonnelDepartment(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(personnelId), Int32.Parse(departmentId));
        //}

        //#endregion "Turnover"

        //#region "Turnover_PunchTicket"
        //public PunchDTOSet GetPunchListByQaqcform(int qaqcformId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPunchListByQaqcform(qaqcformId, Helper.GetImagePhysicalPath());
        //}

        //public WalkdownDTOSet GetPunchTicketByQaqcform(int qaqcformId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPunchTicketByQaqcform(qaqcformId);
        //}
        //public WalkdownDTOSet JsonGetPunchTicketByQaqcform(string qaqcformId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPunchTicketByQaqcform(Int32.Parse(qaqcformId));
        //}

        //#endregion "Turnover_PunchTicket"
                
        //#endregion "Get, SELECT"

        //#region "Update"

        //public List<ProgressDTO> DeleteMTO(List<MTODTO> progress, string updatedBy, string userName, string password, int rfiid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).DeleteMTO(progress, updatedBy, userName, password, rfiid);
        //}

        //public List<ProgressDTO> JsonDeleteMTO(List<MTODTO> progress, string updatedBy, string userName, string password, string rfiid)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).DeleteMTO(progress, updatedBy, userName, password, Int32.Parse(rfiid));
        //}

        ///// <summary>
        ///// Delete MTO and Importedfilename objects which object contains the specified ImportedfilenameID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="importedfilenameId">ImportedfilenameID to search for</param>
        ///// <returns></returns>
        //public List<ComponentDTO> DeleteMTOByImportedfilename(int importedfilenameId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).DeleteMTOByImportedfilename(importedfilenameId);
        //}

        ///// <summary>
        ///// Delete MTO and Importedfilename objects which object contains the specified ImportedfilenameID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="importedfilenameId">ImportedfilenameID to search for</param>
        ///// <returns></returns>
        //public List<ComponentDTO> JsonDeleteMTOByImportedfilename(string importedfilenameId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).DeleteMTOByImportedfilename(Int32.Parse(importedfilenameId));
        //}

        //public List<MTODTO> InsertUpdateMTO(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).InsertUpdateMTO(progress);
        //}

        //public List<MTODTO> JsonInsertUpdateMTO(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).InsertUpdateMTO(progress);
        //}

        //public List<MTODTO> InsertUpdatePipeMTO(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).InsertUpdatePipeMTO(progress);
        //}

        //public List<MTODTO> JsonInsertPipeUpdateMTO(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).InsertUpdatePipeMTO(progress);
        //}

        //public List<MTODTO> InsertUpdateInsulMTO(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).InsertUpdateInsulMTO(progress);
        //}

        //public List<MTODTO> JsonInsertUpdateInsulMTO(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).InsertUpdateInsulMTO(progress);
        //}

        //public void UpdateProgressCostCodeByProgressID(int p_ProgressId, int p_CostCodeId)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressCostCodeByProgressID(p_ProgressId, p_CostCodeId);
        //}

        //public void JsonUpdateProgressCostCodeByProgressID(string p_ProgressId, string p_CostCodeId)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressCostCodeByProgressID(Int32.Parse(p_ProgressId), Int32.Parse(p_CostCodeId));
        //}

        //public List<ComponentDTO> SaveComponent(List<ComponentDTO> component)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveComponent(component);
        //}

        //public List<ComponentDTO> JsonSaveComponent(List<ComponentDTO> component)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveComponent(component);
        //}

        //public List<RfidrawingDTO> SaveRFIDrawing(List<RfidrawingDTO> rfidrawing)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveRFIDrawing(rfidrawing);
        //}

        //public List<RfidrawingDTO> JsonSaveRFIDrawing(List<RfidrawingDTO> rfidrawing)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveRFIDrawing(rfidrawing);
        //}

        //public List<CostcodeDTO> SaveCostcode(List<CostcodeDTO> costcode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcode(costcode);
        //}

        //public List<CostcodeDTO> JsonSaveCostcode(List<CostcodeDTO> costcode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcode(costcode);
        //}

        //public CostcodeDTO SaveSingleCostcode(CostcodeDTO costcode)
        //{
        //    List<CostcodeDTO> list = new List<CostcodeDTO>();
        //    list.Add(costcode);

        //    list = (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcode(list);

        //    return list.FirstOrDefault();
        //}

        //public CostcodeDTO JsonSaveSingleCostcode(CostcodeDTO costcode)
        //{
        //    List<CostcodeDTO> list = new List<CostcodeDTO>();
        //    list.Add(costcode);

        //    list = (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcode(list);

        //    return list.FirstOrDefault();
        //}

        //public List<CostcodestructureDTO> SaveCostcodeStructureByProjectSchedule(int intProjectID, int intCwpID, int intProjectScheduleID, int intParentCostcodeStructureID, int intClassLevel)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodeStructureByProjectSchedule(intProjectID, intCwpID, intProjectScheduleID, intParentCostcodeStructureID, intClassLevel);
        //}

        //public List<CostcodestructureDTO> JsonSaveCostcodeStructureByProjectSchedule(string intProjectID, string intCwpID, string intProjectScheduleID, string intParentCostcodeStructureID, string intClassLevel)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodeStructureByProjectSchedule(Int32.Parse(intProjectID), Int32.Parse(intCwpID), Int32.Parse(intProjectScheduleID), Int32.Parse(intParentCostcodeStructureID), Int32.Parse(intClassLevel));
        //}

        //public List<CostcodestructureDTO> SaveCostcodestructure(List<CostcodestructureDTO> costcodestructure)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodestructure(costcodestructure);
        //}

        //public List<CostcodestructureDTO> SaveCostcodestructureProjectWizard(List<CostcodestructureDTO> costcodestructure)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodestructureProjectWizard(costcodestructure);
        //}

        //public List<CostcodestructureDTO> JsonSaveCostcodestructure(List<CostcodestructureDTO> costcodestructure)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodestructure(costcodestructure);
        //}

        //public List<CostcodetaleDTO> SaveCostcodetale(List<CostcodetaleDTO> costcodestail)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodetale(costcodestail);
        //}

        //public List<CostcodetaleDTO> JsonSaveCostcodetale(List<CostcodetaleDTO> costcodestail)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodetale(costcodestail);
        //}

        //public List<CostcodelockedDTO> SaveCostcodelocked(List<CostcodelockedDTO> list)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodelocked(list);
        //}

        //public List<CostcodelockedDTO> JsonSaveCostcodelocked(List<CostcodelockedDTO> list)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCostcodelocked(list);
        //}

        //public List<CwaDTO> SaveCwa(List<CwaDTO> cwas)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWA(cwas);
        //}

        //public List<CwaDTO> SaveCwaProjectWizard(List<CwaDTO> cwas)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWAProjectWizard(cwas);
        //}

        //public List<CwaDTO> JsonSaveCwa(List<CwaDTO> cwas)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWA(cwas);
        //}

        //public List<CwpDTO> SaveCwp(List<CwpDTO> cwps)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWP(cwps);
        //}

        //public List<CwpDTO> SaveCwpProjectWizard(List<CwpDTO> cwps)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWPProjectWizard(cwps);
        //}

        //public List<CwpDTO> JsonSaveCwp(List<CwpDTO> cwps)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWP(cwps);
        //}

        //public CwpDTO SaveSingleCwp(CwpDTO cwps)
        //{
        //    List<CwpDTO> list = new List<CwpDTO>();
        //    list.Add(cwps);

        //    list = (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWP(list);

        //    return list.FirstOrDefault();
        //}

        //public CwpDTO JsonSaveSingleCwp(CwpDTO cwps)
        //{
        //    List<CwpDTO> list = new List<CwpDTO>();
        //    list.Add(cwps);

        //    list = (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCWP(list);

        //    return list.FirstOrDefault();
        //}

        //public List<DrawingrevisionDTO> SaveDrawingRevision(List<DrawingrevisionDTO> drawingrev)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingRevision(drawingrev);
        //}

        //public List<DrawingrevisionDTO> JsonSaveDrawingRevision(List<DrawingrevisionDTO> drawingrev)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingRevision(drawingrev);
        //}

        //public List<DrawingreferenceDTO> SaveDrawingReference(List<DrawingreferenceDTO> DrawingReference)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingReference(DrawingReference);
        //}

        //public List<DrawingreferenceDTO> JsonSaveDrawingReference(List<DrawingreferenceDTO> DrawingReference)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingReference(DrawingReference);
        //}

        //public List<DrawingsdrefDTO> SaveDrawingsdre(List<DrawingsdrefDTO> DrawingReference)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingsdre(DrawingReference);
        //}

        //public List<DrawingsdrefDTO> JsonSaveDrawingsdre(List<DrawingsdrefDTO> DrawingReference)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingsdre(DrawingReference);
        //}

        //public List<DrawingcwpDTO> SaveDrawingCWP(List<DrawingcwpDTO> drawingcwp)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingCWP(drawingcwp);
        //}

        //public List<DrawingcwpDTO> JsonSaveDrawingCWP(List<DrawingcwpDTO> drawingcwp)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingCWP(drawingcwp);
        //}

        //public List<DrawingDTO> SaveDrawing(List<DrawingDTO> drawing)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawing(drawing);
        //}

        //public List<DrawingDTO> JsonSaveDrawing(List<DrawingDTO> drawing)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawing(drawing);
        //}

        //public List<DrawingDTO> SaveDrawingWithDrawingRevision(List<DrawingDTO> drawings)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingWithDrawingRevision(drawings);
        //}

        //public List<DrawingDTO> JsonSaveDrawingWithDrawingRevision(List<DrawingDTO> drawings)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingWithDrawingRevision(drawings);
        //}

        //public List<DrawingDTO> SaveDrawingWithDrawingReference(List<DrawingDTO> drawings)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingWithDrawingReference(drawings);
        //}

        //public List<DrawingDTO> JsonSaveDrawingWithDrawingReference(List<DrawingDTO> drawings)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingWithDrawingReference(drawings);
        //}

        //public List<TagnumberdrawingDTO> SaveTagnumberdrawing(List<TagnumberdrawingDTO> tagNumberDrawing)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveTagnumberdrawing(tagNumberDrawing);
        //}

        //public List<TagnumberdrawingDTO> JsonSaveTagnumberdrawing(List<TagnumberdrawingDTO> tagNumberDrawing)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveTagnumberdrawing(tagNumberDrawing);
        //}

        //public List<FiwpDTO> SaveSIWP(List<FiwpDTO> fiwp)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveSIWP(fiwp);
        //}

        //public List<FiwpDTO> SaveFIWP(List<FiwpDTO> fiwp, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFIWP(fiwp, userName, password);
        //}

        public List<FiwpDTO> JsonSaveFIWP(List<FiwpDTO> fiwp)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).SaveFIWP(fiwp);
        }

        //public List<FiwpDTO> SaveHydro(List<FiwpDTO> fiwp, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveHydro(fiwp, userName, password);
        //}

        //public List<FiwpDTO> JsonSaveHydro(List<FiwpDTO> fiwp, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveHydro(fiwp, userName, password);
        //}

        //public List<FiwpworkflowDTO> SaveFiwpworkflowWithSMTP(List<FiwpworkflowDTO> fiwpworkflow, string link)
        //{
        //    string[] smtp = Helper.SMTPINfo;
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpworkflowWithSMTP(fiwpworkflow, link, smtp[1], smtp[2], smtp[0]);
        //}

        //public List<FiwpworkflowDTO> SaveFiwpworkflow(FiwpworkflowDTO[] fiwpworkflow)
        //{
        //    //List<FiwpworkflowDTO> rtn = null;
        //    //try
        //    //{
        //    //    LogEntry _logentry = new LogEntry();
        //    //    _logentry.Categories.Add("AppLog");
        //    //    _logentry.Priority = 2;
        //    //    _logentry.EventId = 4000;
        //    //    _logentry.Severity = System.Diagnostics.TraceEventType.Information;
        //    //    _logentry.Title = "Reveal WCF";
        //    //    _logentry.Message = fiwpworkflow.ToString();
        //    //    Logger.Write(_logentry);
        //    //     //rtn = 
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    LogEntry _logentry = new LogEntry();
        //    //    _logentry.Categories.Add("AppLog"); 
        //    //    _logentry.Priority = 2; 
        //    //    _logentry.EventId = 4000; 
        //    //    _logentry.Severity = System.Diagnostics.TraceEventType.Information; 
        //    //    _logentry.Title = "Reveal WCF"; 
        //    //    _logentry.Message = ex.Message; 
        //    //    Logger.Write(_logentry);
        //    //}

        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpworkflow(fiwpworkflow.ToList());
        //}

        //public List<FiwpworkflowDTO> JsonSaveFiwpworkflow(List<FiwpworkflowDTO> fiwpworkflow, string link)
        //{
        //    string[] smtp = Helper.SMTPINfo;
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpworkflowWithSMTP(fiwpworkflow, link, smtp[1], smtp[2], smtp[0]);
        //}

        //public FiwpworkflowDTO SaveSingleFiwpworkflow(FiwpworkflowDTO fiwpworkflow)
        //{
        //    List<FiwpworkflowDTO> list = new List<FiwpworkflowDTO>();

        //    //fiwpworkflow.DTOStatus = (int)RowStatus.Update;

        //    list.Add(fiwpworkflow);

        //    list = (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpworkflow(list);

        //    return list.FirstOrDefault();
        //}

        //public FiwpworkflowDTO JsonSaveSingleFiwpworkflow(FiwpworkflowDTO fiwpworkflow)
        //{
        //    List<FiwpworkflowDTO> list = new List<FiwpworkflowDTO>();

        //    //fiwpworkflow.DTOStatus = (int)RowStatus.Update;

        //    list.Add(fiwpworkflow);

        //    list = (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpworkflow(list);

        //    return list.FirstOrDefault();
        //}

        //public List<FiwpmanpowerDTO> SaveFiwpManPower(List<FiwpmanpowerDTO> fiwpmanpower)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpManPower(fiwpmanpower).ToList();
        //}

        //public List<FiwpmanpowerDTO> JsonSaveFiwpManPower(List<FiwpmanpowerDTO> fiwpmanpower)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpManPower(fiwpmanpower).ToList();
        //}

        //public List<FiwpcommentDTO> SaveFiwpcomment(List<FiwpcommentDTO> fiwpcomment)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpcomment(fiwpcomment).ToList();
        //}

        //public List<FiwpcommentDTO> JsonSaveFiwpcomment(List<FiwpcommentDTO> fiwpcomment)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpcomment(fiwpcomment).ToList();
        //}

        //public List<FiwpmanonsiteDTO> SaveFiwpManonsite(List<FiwpmanonsiteDTO> fiwpManonsite)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpManonsite(fiwpManonsite).ToList();
        //}

        //public List<FiwpmanonsiteDTO> JsonSaveFiwpManonsite(List<FiwpmanonsiteDTO> fiwpManonsite)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpManonsite(fiwpManonsite).ToList();
        //}

        //public List<FiwpdocordinalDTO> SaveFiwpdocordinal(List<FiwpdocordinalDTO> fiwpDocordinal)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpdocordinal(fiwpDocordinal);
        //}

        //public List<FiwpdocordinalDTO> JsonSaveFiwpdocordinal(List<FiwpdocordinalDTO> fiwpDocordinal)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpdocordinal(fiwpDocordinal);
        //}

        //public List<FiwpwfpDTO> SaveFiwpwfp(List<FiwpwfpDTO> fiwpwfp)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpwfp(fiwpwfp);
        //}

        //public List<FiwpwfpDTO> JsonSaveFiwpwfp(List<FiwpwfpDTO> fiwpwfp)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpwfp(fiwpwfp);
        //}

        //public List<FiwpequipDTO> SaveFiwpequip(List<FiwpequipDTO> fiwpequip)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpequip(fiwpequip);
        //}

        public List<FiwpequipDTO> JsonSaveFiwpequip(List<FiwpequipDTO> fiwpequip)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).SaveFiwpequip(fiwpequip);
        }

        //public List<FiwpmaterialDTO> SaveFiwpMaterial(List<FiwpmaterialDTO> fiwpmaterial)
        //{
        //    fiwpmaterial = (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpMaterial(fiwpmaterial);
        //    return fiwpmaterial;
        //}

        public List<FiwpmaterialDTO> JsonSaveFiwpMaterial(List<FiwpmaterialDTO> fiwpmaterial)
        {
            fiwpmaterial = (new Element.Sigma.Web.Biz.TrueTask.Assemble()).SaveFiwpMaterial(fiwpmaterial);
            return fiwpmaterial;
        }

        //public List<DocumentDTO> SaveDocument(List<DocumentDTO> document)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveDocument(document);
        //}

        public List<DocumentDTO> JsonSaveDocument(List<DocumentDTO> document)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).SaveDocument(document);
        }

        //public List<DocumentnoteDTO> SaveDocumentNote(List<DocumentnoteDTO> documentnote)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveDocumentNote(documentnote);
        //}

        //public List<DocumentnoteDTO> JsonSaveDocumentNote(List<DocumentnoteDTO> documentnote)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveDocumentNote(documentnote);
        //}

        //public List<LibpipeclassmanhourDTO> SaveLibPipeClassManHour(List<LibpipeclassmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeClassManHour(lib);
        //}

        //public List<LibpipeclassmanhourDTO> JsonSaveLibPipeClassManHour(List<LibpipeclassmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeClassManHour(lib);
        //}

        //public List<LibpipemanhourratioDTO> SaveLibPipeManhourRatio(List<LibpipemanhourratioDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeManhourRatio(lib);
        //}

        //public List<LibpipemanhourratioDTO> JsonSaveLibPipeManhourRatio(List<LibpipemanhourratioDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeManhourRatio(lib);
        //}

        //public List<LibpipesupmanhourDTO> SaveLibPipeSupManhour(List<LibpipesupmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeSupManhour(lib);
        //}

        //public List<LibpipesupmanhourDTO> JsonSaveLibPipeSupManhour(List<LibpipesupmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeSupManhour(lib);
        //}

        //public List<LibpipeschmanhourDTO> SaveLibPipeSchManhour(List<LibpipeschmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeSchManhour(lib);
        //}

        //public List<LibpipeschmanhourDTO> JsonSaveLibPipeSchManhour(List<LibpipeschmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeSchManhour(lib);
        //}

        //public List<LibpipemanhourDTO> SaveLibPipeManhour(List<LibpipemanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibPipeManhour(lib);
        //}

        //public List<LibcablemanhourDTO> SaveLibcablemanhour(List<LibcablemanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibcablemanhour(lib);
        //}

        //public List<LibcablemanhourDTO> JsonSaveLibcablemanhour(List<LibcablemanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibcablemanhour(lib);
        //}

        //public List<LibracewaymanhourDTO> SaveLibracewaymanhour(List<LibracewaymanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibracewaymanhour(lib);
        //}

        //public List<LibracewaymanhourDTO> JsonSaveLibracewaymanhour(List<LibracewaymanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibracewaymanhour(lib);
        //}

        //public List<LibehtmanhourDTO> SaveLibehtmanhour(List<LibehtmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibehtmanhour(lib);
        //}

        //public List<LibehtmanhourDTO> JsonSaveLibehtmanhour(List<LibehtmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibehtmanhour(lib);
        //}

        //public List<LibequipmanhourDTO> SaveLibequipmanhour(List<LibequipmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibequipmanhour(lib);
        //}

        //public List<LibequipmanhourDTO> JsonSaveLibequipmanhour(List<LibequipmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibequipmanhour(lib);
        //}

        //public List<LibconsumableDTO> SaveLibconsumable(List<LibconsumableDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibconsumable(lib);
        //}

        //public List<LibconsumableDTO> JsonSaveLibconsumable(List<LibconsumableDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibconsumable(lib);
        //}

        //public List<LibgroundingmanhourDTO> SaveLibgroundingmanhour(List<LibgroundingmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibgroundingmanhour(lib);
        //}

        //public List<LibgroundingmanhourDTO> JsonSaveLibgroundingmanhour(List<LibgroundingmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibgroundingmanhour(lib);
        //}

        //public List<LiblightingmanhourDTO> SaveLiblightingmanhour(List<LiblightingmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLiblightingmanhour(lib);
        //}

        //public List<LiblightingmanhourDTO> JsonSaveLiblightingmanhour(List<LiblightingmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLiblightingmanhour(lib);
        //}

        //public List<LibinstrmanhourDTO> SaveLibinstrmanhour(List<LibinstrmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinstrmanhour(lib);
        //}

        //public List<LibinstrmanhourDTO> JsonSaveLibinstrmanhour(List<LibinstrmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinstrmanhour(lib);
        //}

        //public List<LibinsulfactorDTO> SaveLibInsulFactor(List<LibinsulfactorDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinsulfactor(lib);
        //}

        //public List<LibinsulfireproofDTO> SaveLibinsulfireproof(List<LibinsulfireproofDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinsulfireproof(lib);
        //}

        //public List<MaterialDTO> SaveMaterial(List<MaterialDTO> material)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveMaterial(material);
        //}

        //public List<MaterialCableDTO> SaveMaterialCable(List<MaterialCableDTO> materialCables)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveMaterialCable(materialCables);
        //}

        //public List<ProgressDTO> SaveProgress(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProgress(progress);
        //}

        //public ProjectAndModule SaveProjectAndProjectModule(ProjectAndModule projects)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProjectAndModule(projects);
        //}

        //public List<ProjectDTO> SaveProject(List<ProjectDTO> project)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProject(project, false, Helper.ProjectSPURL);
        //}

        //public ProjectWizard SaveProjectWizard(ProjectWizard projectwizard)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProjectWizard(projectwizard, Helper.ProjectSPURL);
        //}

        //public ProjectDTO DeleteProjectWizard(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).DeleteProjectWizard(projectId);
        //}

        //public ProjectDTO SaveSingleProject(ProjectDTO project)
        //{
        //    List<ProjectDTO> list = new List<ProjectDTO>();

        //    list.Add(project);

        //    list = (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProject(list, false, Helper.ProjectSPURL);

        //    return list.FirstOrDefault();
        //}

        //public List<ProjectDTO> SaveProjectAndSharePointProject(List<ProjectDTO> project)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProject(project, true, Helper.ProjectSPURL);
        //}

        //public List<QaqcformDTO> GetQaqcformByQcManager(int projectid, string disciplineCode, int loginId, int QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetQaqcformForQcManager(projectid, Helper.RemoveJsonParameterWrapper(disciplineCode), loginId, QAQCDataTypeLUID);
        //}

        //public List<QaqcformDTO> SaveQaqcformForDownload(int projectId, string disciplineCode, int cwpId, int fiwpId, List<QaqcformtemplateDTO> qaqcformtemplate, string updatedBy, int QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcformForDownload(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), cwpId, fiwpId, qaqcformtemplate, updatedBy, QAQCDataTypeLUID);
        //}

        //public List<QaqcformDTO> JsonSaveQaqcformForDownload(string projectId, string disciplineCode, string cwpId, string fiwpId, List<QaqcformtemplateDTO> qaqcformtemplate, string updatedBy, string QAQCDataTypeLUID)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcformForDownload(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(cwpId), Int32.Parse(fiwpId), qaqcformtemplate, updatedBy, Int32.Parse(QAQCDataTypeLUID));
        //}

        //public List<QaqcformDTO> SaveQaqcformForSubmit(List<QaqcformDTO> qaqcforms)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcformForSubmit(qaqcforms, Cookies.GetSPCredential());
        //}

        //public List<QaqcformDTO> JsonSaveQaqcformForSubmit(List<QaqcformDTO> qaqcforms)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcformForSubmit(qaqcforms, Cookies.GetSPCredential());
        //}

        //public QaqcformDTO SaveQaqcform(QaqcformDTO qaqcForm)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcform(qaqcForm);
        //}

        //public List<ProjectmoduleDTO> SaveProjectModule(List<ProjectmoduleDTO> projectmodule)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProjectModule(projectmodule);
        //}

        //public List<ProjectscheduleDTO> SaveProjectSchedule(List<ProjectscheduleDTO> schedule, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveProjectSchedule(schedule, userName, password);
        //}

        public List<ProjectscheduleDTO> JsonSaveProjectSchedule(List<ProjectscheduleDTO> schedule)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).SaveProjectSchedule(schedule);
        }

        //public List<ProjectscheduleDTO> CleanProjectSchedule(int projectscheduleid, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).ClearProjectSchedule(projectscheduleid, userName, password);
        //}

        //public List<RfiDTO> SaveRFI(List<RfiDTO> rfi)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveRFI(rfi);
        //}

        public List<RfiDTO> JsonSaveRFI(List<RfiDTO> rfi)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).SaveRFI(rfi);
        }

        //public ScaffoldAndRequest SaveScaffoldrequest(ScaffoldAndRequest dto)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveScaffoldrequest(dto);
        //}

        //public List<SystemDTO> SaveSystem(List<SystemDTO> system)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveSystem(system);
        //}

        //public List<SystemDTO> SaveSystemProjectWizard(List<SystemDTO> system)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveSystem(system);
        //}

        //public SystemDTO SaveSingleSystem(SystemDTO system)
        //{
        //    List<SystemDTO> list = new List<SystemDTO>();
        //    list.Add(system);

        //    list = (new Element.Reveal.Server.BALC.ProjectWriter()).SaveSystem(list);

        //    return list.FirstOrDefault();
        //}

        //public List<AreaDTO> SaveArea(List<AreaDTO> area)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveArea(area);
        //}

        //public List<TimesheetDTO> SaveTimesheet(List<TimesheetDTO> timesheet, List<MTODTO> progresses, decimal workhour, int timeallocationId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveTimesheet(timesheet, progresses, workhour, timeallocationId);
        //}

        //public List<TimesheetDTO> JsonSaveTimesheet(List<TimesheetDTO> timesheet, List<MTODTO> progresses, string workhour, string timeallocationId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveTimesheet(timesheet, progresses, decimal.Parse(workhour), Int32.Parse(timeallocationId));
        //}

        //public List<TimesheetDTO> SaveTimeAllocationRestore(int timeallocationId)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveTimeAllocationRestore(timeallocationId);
        //}

        //public bool SaveDailyTimehseet(DateTime workDate, int dataId, int isDirect, int dailyTimesheetId, int status, string updatedBy, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveDailyTimesheet(workDate, dataId, isDirect, dailyTimesheetId, status, updatedBy, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), Cookies.GetSPCredential());
        //}

        //public bool JsonSaveDailyTimehseet(string workDate, string intDataId, string intFlag, string dailyTimesheetId, string status, string updatedBy, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveDailyTimesheet(DateTime.Parse(workDate), Int32.Parse(intDataId), Int32.Parse(intFlag), Int32.Parse(dailyTimesheetId), Int32.Parse(status), updatedBy, Int32.Parse(projectId), Int32.Parse(disciplineCode), Cookies.GetSPCredential());
        //}

        //public ProgressAssignment UpdateFIWPProgressAssignment(ProgressAssignment progress, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateFIWPProgressAssignment(progress, userName, password);
        //}

        public ProgressAssignment JsonUpdateFIWPProgressAssignment(ProgressAssignment progress)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).UpdateIWPComponentprogressAssignment(progress, Helper.isUsingMpp);
        }
        
        //public ProgressAssignment UpdateSIWPProgressAssignment(ProgressAssignment progress, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressAssignment(progress, userName, password);
        //}

        //public ProgressAssignment UpdateSIWPProgressAssignmentByScope(ProgressAssignment progress, int startdrawingId, int enddrawingId, int startidfseq, int endidfseq,
        //                                                              List<int> withindrawingList, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressAssignmentByScope(progress, startdrawingId, enddrawingId, startidfseq, endidfseq, withindrawingList, userName, password);
        //}

        //public ProgressAssignment UpdateHydroProgressAssignmentByStartPoint(ProgressAssignment progress, int drawingId, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateHydroProgressAssignmentByStartPoint(progress, drawingId, userName, password);
        //}

        //public ProgressAssignment UpdateSIWPProgressAssignmentByRange(ProgressAssignment progress, int startprogressid, int endprogressid, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressAssignmentByRange(progress, startprogressid, endprogressid, userName, password);
        //}

        //public ProgressAssignment UpdateSIWPProgressUnAssignment(ProgressAssignment progress, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressUnAssignment(progress, userName, password);
        //}

        //public ProgressAssignment JsonUpdateSIWPProgressAssignment(ProgressAssignment progress, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressAssignment(progress, userName, password);
        //}

        //public ProgressAssignment UpdateSIWPProgressAssignmentForTurnOver(ProgressAssignment progress, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressAssignmentForTurnOver(progress, userName, password);
        //}

        //public ProgressAssignment UpdateSIWPProgressAssignmentForTurnOverByRange(ProgressAssignment progress, int startprogressid, int endprogressid, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressAssignmentForTurnOverByRange(progress, startprogressid, endprogressid, userName, password);
        //}

        //public ProgressAssignment JsonUpdateSIWPProgressAssignmentForTurnOver(ProgressAssignment progress, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateSIWPProgressAssignmentForTurnOver(progress, userName, password);
        //}

        //public List<FiwpmaterialDTO> RegenerateFIWPMaterial(int fiwpId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).RegenerateFIWPMaterial(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public List<FiwpmaterialDTO> JsonRegenerateFIWPMaterial(string fiwpId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).RegenerateFIWPMaterial(Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public ExtSchedulerDTO UpdateFiwpScheduler(ExtSchedulerDTO extscheduler, string userName, string password)
        //{
        //    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        //    {
        //        string[] info = (new P6ManagerService()).GetP6Login();
        //        userName = info[0];
        //        password = info[1];
        //    }
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateFiwpScheduler(extscheduler, userName, password);
        //}

        public ExtSchedulerDTO JsonUpdateFiwpScheduler(ExtSchedulerDTO extscheduler)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).UpdateFiwpScheduler(extscheduler, Helper.isUsingMpp);
        }

        //public ExtSchedulerDTO UpdateFiwpManpower(ExtSchedulerDTO fiwpMPower, int projectscheduleId, int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateFiwpManPower(fiwpMPower, projectscheduleId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public ExtSchedulerDTO JsonUpdateFiwpManpower(ExtSchedulerDTO fiwpMPower, string projectscheduleId, string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateFiwpManPower(fiwpMPower, Int32.Parse(projectscheduleId), Int32.Parse(projectId), Int32.Parse(disciplineCode));
        //}

        //public void UpdateManhoursEstimateByCostCode(int cwpId, int costcodeId, int projectId, string disciplineCode, decimal manhourRate, decimal baseQty, string updatedBy, string UpdateQty)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateManhoursEstimateByCostCode(cwpId, costcodeId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), manhourRate, baseQty, updatedBy, UpdateQty);
        //}

        //public void JsonUpdateManhoursEstimateByCostCode(string cwpId, string costcodeId, string projectId, string disciplineCode, string manhourRate, string baseQty, string updatedBy, string UpdateQty)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateManhoursEstimateByCostCode(Int32.Parse(cwpId), Int32.Parse(costcodeId), Int32.Parse(projectId), Int32.Parse(disciplineCode), decimal.Parse(manhourRate), decimal.Parse(baseQty), updatedBy, UpdateQty);
        //}

        //public void UpdateComponentWithAssociatedTag(int projectid, string disciplineCode, int tab, string isolineno, int componentid, int systemid)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateComponentWithAssociatedTag(projectid, Helper.RemoveJsonParameterWrapper(disciplineCode), tab, isolineno, componentid, systemid);
        //}

        //public void UpdateComponentWithSystem(int projectId, string disciplineCode, int tab, string firstid, string second, string third, int taskid, int isSystemEmpty, int systemId)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateComponentWithSystemID(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), tab, firstid, second, third, taskid, isSystemEmpty, systemId);
        //}

        //public void JsonUpdateComponentWithSystem(string projectId, string disciplineCode, string tab, string firstid, string second, string third, string taskid, string isSystemEmpty, string systemId)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateComponentWithSystemID(Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(tab), firstid, second, third, Int32.Parse(taskid), Int32.Parse(isSystemEmpty), Int32.Parse(systemId));
        //}

        //public void UpdateMaterialWithReelNo(int cwpId, int fiwpId, int projectId, string disciplineCode, string filterName, string filterValue, string newReelNo)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateMaterialWithReelNo(cwpId, fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), filterName, filterValue, newReelNo);
        //}

        //public void JsonUpdateMaterialWithReelNo(string cwpId, string fiwpId, string projectId, string disciplineCode, string filterName, string filterValue, string newReelNo)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateMaterialWithReelNo(Int32.Parse(cwpId), Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), filterName, filterValue, newReelNo);
        //}

        //public void UpdateProgressWithCWP(int cwpId, int materialCategoryId, int taskCategoryId, int projectId, string disciplineCode, int newCWPID)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressWithCWP(cwpId, materialCategoryId, taskCategoryId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), newCWPID);
        //}

        //public void JsonUpdateProgressWithCWP(string cwpId, string materialCategoryId, string taskCategoryId, string projectId, string disciplineCode, string newCWPID)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressWithCWP(Int32.Parse(cwpId), Int32.Parse(materialCategoryId), Int32.Parse(taskCategoryId), Int32.Parse(projectId), Int32.Parse(disciplineCode), Int32.Parse(newCWPID));
        //}

        //public void UpdateProgressCostCode(int cwpId, int materialcategoryid, int taskcategoryid, int componenttasktype, string engtag, int costcode, int projectid, string disciplineCode)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressCostCode(cwpId, materialcategoryid, taskcategoryid, componenttasktype, engtag, costcode, projectid, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}

        //public void JsonUpdateProgressCostCode(string cwpId, string materialcategoryid, string taskcategoryid, string componenttasktype, string engtag, string costcode, string projectid, string disciplineCode)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressCostCode(Int32.Parse(cwpId), Int32.Parse(materialcategoryid), Int32.Parse(taskcategoryid), Int32.Parse(componenttasktype), engtag, Int32.Parse(costcode), Int32.Parse(projectid), Int32.Parse(disciplineCode));
        //}

        //public List<ProgressDTO> UpdateProgressComponents(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateComponentProgressProjectSchedule(progress);
        //}

        //public List<ProgressDTO> JsonUpdateProgressComponents(List<ProgressDTO> progress)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateComponentProgressProjectSchedule(progress);
        //}

        //public ProgressAssignment UpdateProjectScheduleAssignment(ProgressAssignment progress, string userName, string password)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateProjectScheduleAssignment(progress, userName, password);
        //}

        //public ProgressAssignment JsonUpdateProjectScheduleAssignment(ProgressAssignment progress, string userName, string password)
        public ProgressAssignment JsonUpdateProjectScheduleAssignment(ProgressAssignment progress)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).UpdateProjectScheduleAssignment(progress, Helper.isUsingMpp);
        }

        public ProjectscheduleDTO JsonUpdateProjectSchedulePeriod(ProjectscheduleDTO schedule, string totalManhours)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).UpdateProjectSchedulePeriod(schedule, Convert.ToDecimal(totalManhours), null, null);
        }

        public FiwpDTO JsonUpdateIwpPeriod(FiwpDTO iwp, string totalManhours)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Build()).UpdateIwpPeriod(iwp, Convert.ToDecimal(totalManhours), null, null);
        }
        
        //public void UpdateQaqcformForSign(int qaqcformId, string savedUrl, int SPCollectionID, bool isSubmitted)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateQaqcformForSign(qaqcformId, savedUrl, SPCollectionID, isSubmitted);
        //}

        //public void JsonUpdateQaqcformForSign(string qaqcformId, string savedUrl, string SPCollectionID, string isSubmitted)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateQaqcformForSign(Int32.Parse(qaqcformId), savedUrl, Int32.Parse(SPCollectionID), bool.Parse(isSubmitted));
        //}

        //public void UpdateSingleMaterialWithReelNo(int materialId, string newReelNo)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateMaterialWithReelNo(materialId, newReelNo);
        //}

        //public void JsonUpdateSingleMaterialWithReelNo(string materialId, string newReelNo)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateMaterialWithReelNo(Int32.Parse(materialId), newReelNo);
        //}

        //public void UpdateSingleProgressWithCWP(int progressId, int newCwpId)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressWithCWP(progressId, newCwpId);
        //}

        //public void JsonUpdateSingleProgressWithCWP(string progressId, string newCwpId)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).UpdateProgressWithCWP(Int32.Parse(progressId), Int32.Parse(newCwpId));
        //}

        //public void UpdateTimesheetToP6(int fiwpId, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateTimesheetToP6(fiwpId, userName, password);
        //}

        //public void JsonUpdateTimesheetToP6(string fiwpId, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).UpdateTimesheetToP6(Int32.Parse(fiwpId), userName, password);
        //}

        //public void SyncProjectScheduleToP6(int projectscheduleId, int projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncProjectScheduleToP6(projectscheduleId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), userName, password);
        //}

        //public void JsonSyncProjectScheduleToP6(string projectscheduleId, string projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncProjectScheduleToP6(Int32.Parse(projectscheduleId), Int32.Parse(projectId), Int32.Parse(disciplineCode), userName, password);
        //}

        //public void SyncFIWPResourceToP6(int fiwpId, int projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncFIWPResourceToP6(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), userName, password);
        //}

        //public void JsonSyncFIWPResourceToP6(string fiwpId, string projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncFIWPResourceToP6(Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), userName, password);
        //}

        //public void SyncScheduleResourceToP6(int fiwpId, int projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncScheduleResourceToP6(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), userName, password);
        //}

        //public void JsonSyncScheduleResourceToP6(string fiwpId, string projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncScheduleResourceToP6(Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), userName, password);
        //}

        //public void SyncScheduleResourceToP6ByProjectSchedule(int projectscheduleId, int projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncScheduleResourceToP6ByProjectSchedule(projectscheduleId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), userName, password);
        //}

        //public void JsonSyncScheduleResourceToP6ByProjectSchedule(string projectscheduleId, string projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncScheduleResourceToP6ByProjectSchedule(Int32.Parse(projectscheduleId), Int32.Parse(projectId), Int32.Parse(disciplineCode), userName, password);
        //}

        //public void SyncScheduleFIWPResourceToP6(int fiwpId, int projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncScheduleFIWPResourceToP6(fiwpId, projectId, Helper.RemoveJsonParameterWrapper(disciplineCode), userName, password);
        //}

        //public void JsonSyncScheduleFIWPResourceToP6(string fiwpId, string projectId, string disciplineCode, string userName, string password)
        //{
        //    (new Element.Reveal.Server.BALC.ScheduleWriter()).SyncScheduleFIWPResourceToP6(Int32.Parse(fiwpId), Int32.Parse(projectId), Int32.Parse(disciplineCode), userName, password);
        //}

        ////LibInsul-------------------------------------------------------------
        //public List<LibinsulfactorDTO> SaveLibinsulfactor(List<LibinsulfactorDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinsulfactor(lib);
        //}

        //public List<LibinsulpaintmanhourDTO> SaveLibinsulpaintmanhour(List<LibinsulpaintmanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinsulpaintmanhour(lib);
        //}

        //public List<LibinsulpipefactorDTO> SaveLibinsulpipefactor(List<LibinsulpipefactorDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinsulpipefactor(lib);
        //}

        //public List<LibinsulpipemanhourDTO> SaveLibinsulpipemanhour(List<LibinsulpipemanhourDTO> lib)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveLibinsulpipemanhour(lib);
        //}

        //public int UploadSharePointForSPCollectionID(int projectId, string collection, string docName)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ProjectWriter()).UploadSharePointForSPCollectionID(projectId, collection, docName, null, null, null, null, null, Cookies.GetSPCredential());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public int JsonUploadSharePointForSPCollectionID(string projectId, string collection, string docName)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ProjectWriter()).UploadSharePointForSPCollectionID(Int32.Parse(projectId), collection, docName, null, null, null, null, null, Cookies.GetSPCredential());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// 2013-11-25 
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="DrawingData"></param>
        ///// <param name="drwaings"></param>
        ///// <param name="fileNm"></param>
        ///// <param name="siteInstance"></param>
        ///// <param name="webPath"></param>
        ///// <param name="physicalpath"></param>
        ///// <returns></returns>
        //public DrawingDTO SaveMultiDrawingAndUpload(byte[] DrawingData, DrawingDTO drwaings, string fileNm, string siteInstance, string webPath, string physicalpath)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveMultiDrawingAndUpload(DrawingData, drwaings, siteInstance, webPath, physicalpath, fileNm, Cookies.GetSPCredential());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<DrawingDTO> SaveMultiDrawingAndUpload2(List<DrawingDTO> drwaings)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveMultiDrawingAndUpload2(drwaings, Cookies.GetSPCredential());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DrawingDTO SaveDrawingAndUpload(DrawingDTO drwaings, string fileNm, string siteInstance, string webPath, string physicalpath)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingAndUpload(drwaings, siteInstance, webPath, physicalpath, fileNm, Cookies.GetSPCredential());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DrawingDTO SaveDrawingAndGenerate(DrawingDTO drwaings, string siteInstance, string webPath)
        //{
        //    try
        //    {
        //        return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDrawingAndGenerate(drwaings, siteInstance, webPath, Helper.GetImagePhysicalPath());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void RegenerateCXML(int projectId, string siteInstance, string webPath)
        //{
        //    (new Element.Reveal.Server.BALC.ProjectWriter()).RegenerateCXML(projectId, siteInstance, webPath, Helper.GetImagePhysicalPath());
        //}

        //public string GetImagePhysicalPath()
        //{
        //    try
        //    {
        //        return Helper.GetImagePhysicalPath();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string GetImageLocationURL()
        //{
        //    try
        //    {
        //        return Helper.GetImageLocationURL();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// Delete MTO and Importedfilename objects which object contains the specified ImportedfilenameID to match.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="importedfilenameId">ImportedfilenameID to search for</param>
        ///// <returns></returns>

        ///// <summary>
        ///// Save(contains Update and Delete) Documentmarkup objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="documentmarkup">Documentmarkup objects to save</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public List<DocumentmarkupDTO> SaveDocumentmarkup(List<DocumentmarkupDTO> documentmarkup)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDocumentmarkup(documentmarkup);
        //}

        ///// <summary>
        ///// Save(contains Update and Delete) Documentmarkup objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="documentmarkup">Documentmarkup objects to save</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public List<DocumentmarkupDTO> JsonSaveDocumentmarkup(List<DocumentmarkupDTO> documentmarkup)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDocumentmarkup(documentmarkup);
        //}

        ///// <summary>
        ///// Create Documentmarkup object and Make default sharepoint item.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="documentmarkup">Documentmarkup object to save</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public DocumentmarkupDTO SaveDocumentmarkupWithSharePoint(int projectId, DocumentmarkupDTO documentmarkup)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDocumentmarkupWithSharePoint(projectId, documentmarkup, Cookies.GetSPCredential());
        //}

        ///// <summary>
        ///// Create Documentmarkup object and Make default sharepoint item.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectID to search for</param>
        ///// <param name="documentmarkup">Documentmarkup object to save</param>
        ///// <returns>DocumentmarkupDTO</returns>
        //public DocumentmarkupDTO JsonSaveDocumentmarkupWithSharePoint(string projectId, DocumentmarkupDTO documentmarkup)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDocumentmarkupWithSharePoint(Int32.Parse(projectId), documentmarkup, Cookies.GetSPCredential());
        //}

        public DocumentmarkupDTO JsonSaveDocumentmarkupWithMarkupImage(DocumentmarkupDTO documentmarkup, UpfileDTOS upFileCollection)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Viewer()).SaveDocumentmarkupWithMarkupImage(documentmarkup, upFileCollection);
        }

        ///// <summary>
        ///// Create Document object and Make default sharepoint item.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="document">Document object to save</param>
        ///// <param name="docName">docName to save</param>
        ///// <param name="cwpName">cwpName to save</param>
        ///// <param name="fiwpName">fiwpName to save</param>
        ///// <returns>DocumentDTO</returns>
        //public DocumentDTO SaveProjectDocumentWithSharePointForModelView(List<FiwpDTO> fiwps, DocumentDTO document, string docName, string cwpName, string fiwpName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProjectDocumentWithSharePointForModelView(fiwps, document, docName, cwpName, fiwpName, Cookies.GetSPCredential());
        //}

        ///// <summary>
        ///// Create Document object and Make default sharepoint item.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="document">Document object to save</param>
        ///// <param name="docName">docName to save</param>
        ///// <param name="cwpName">cwpName to save</param>
        ///// <param name="fiwpName">fiwpName to save</param>
        ///// <returns>DocumentDTO</returns>
        //public DocumentDTO JsonSaveProjectDocumentWithSharePointForModelView(List<FiwpDTO> fiwps, DocumentDTO document, string docName, string cwpName, string fiwpName)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProjectDocumentWithSharePointForModelView(fiwps, document, docName, cwpName, fiwpName, Cookies.GetSPCredential());
        //}

        ///// <summary>
        ///// Save Document object and Upload sharepoint item.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="document">Document object to save</param>
        ///// <param name="cwpName">cwpName to save</param>
        ///// <param name="fiwpName">fiwpName to save</param>
        ///// <returns>List<DocumentDTO></returns>
        //public List<DocumentDTO> SaveProjectDocumentWithSharePointForWFP(DocumentDTO document, string cwpName, string fiwpName, int packagetypeLuid, int currentStep)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProjectDocumentWithSharePointForWFP(document, cwpName, fiwpName, packagetypeLuid, Cookies.GetSPCredential(), Helper.GetImageLocationURL(), currentStep);
        //}

        ///// <summary>
        ///// Create Document object and Make default sharepoint item.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="document">Document object to save</param>
        ///// <param name="cwpName">cwpName to save</param>
        ///// <param name="fiwpName">fiwpName to save</param>
        ///// <returns>List<DocumentDTO></returns>
        //public List<DocumentDTO> JsonSaveProjectDocumentWithSharePointForWFP(DocumentDTO document, string cwpName, string fiwpName, string packagetypeLuid, string currentStep)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveProjectDocumentWithSharePointForWFP(document, cwpName, fiwpName, Int32.Parse(packagetypeLuid), Cookies.GetSPCredential(), Helper.GetImageLocationURL(), Int32.Parse(currentStep));
        //}

        //public List<FiwpwfpDTO> SaveFiwpwfpForAssembleIWP(List<FiwpwfpDTO> fiwpwfps, List<FiwpDTO> fiwps, List<DocumentDTO> documents)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveFiwpwfpForAssembleIWP(fiwpwfps, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL());
        //}JsonGetDrawingForDrawingViewer

        //public List<FiwpwfpDTO> JsonSaveFiwpwfpForAssembleIWP(List<FiwpwfpDTO> fiwpwfps, List<FiwpDTO> fiwps, List<DocumentDTO> documents)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveFiwpwfpForAssembleIWP(fiwpwfps, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL());
        //}

        //public List<FiwpequipDTO> SaveFiwpequipForAssembleIWP(List<FiwpequipDTO> fiwpequips, List<FiwpDTO> fiwps, List<DocumentDTO> documents)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveFiwpequipForAssembleIWP(fiwpequips, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL());
        //}

        public List<FiwpequipDTO> JsonSaveFiwpequipForAssembleIWP(List<FiwpequipDTO> fiwpequips, List<FiwpDTO> fiwps, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).SaveFiwpequipForAssembleIWP(fiwpequips, fiwps, Helper.RemoveJsonParameterWrapper(userId));
        }

        //public List<FiwpmaterialDTO> SaveFiwpMaterialForAssembleIWP(List<FiwpmaterialDTO> fiwpmaterials, List<FiwpDTO> fiwps, List<DocumentDTO> documents)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveFiwpMaterialForAssembleIWP(fiwpmaterials, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL());
        //}

        public List<FiwpmaterialDTO> JsonSaveFiwpMaterialForAssembleIWP(List<FiwpmaterialDTO> fiwpmaterials, List<FiwpDTO> fiwps, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).SaveFiwpMaterialForAssembleIWP(fiwpmaterials, fiwps, Helper.RemoveJsonParameterWrapper(userId));
        }

        public List<DocumentDTO> JsonSaveDocumentForAssembleIWP(List<FiwpDTO> fiwps, List<DocumentDTO> documents, string curStepCode, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).SaveDocumentForAssembleIWP(fiwps, documents, Helper.RemoveJsonParameterWrapper(curStepCode), Helper.RemoveJsonParameterWrapper(userId), Helper.GetWebrootUrl());
        }

        public List<DocumentDTO> JsonSaveDocumentWithOZformForAssembleIWP(List<FiwpDTO> fiwps, UpfileDTOS upFileCollection, string curStepCode, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).SaveDocumentWithOZformForAssembleIWP(fiwps, upFileCollection, Helper.RemoveJsonParameterWrapper(curStepCode), Helper.RemoveJsonParameterWrapper(userId));
        }


        //public List<QaqcformDTO> CreateQaqcForm(string dbname, string updatedBy)
        //{
        //    //Test
        //    List<FiwpqaqcDTO> fiwpqaqclist = new List<FiwpqaqcDTO>();
        //    List<MTODTO> mtoList = new List<MTODTO>();
        //    FiwpDTO fiwpdto = new FiwpDTO();

        //    fiwpqaqclist = (new Element.Reveal.Server.DALC.FiwpqaqcDAL()).GetFiwpqaqcAll(dbname);
        //    fiwpdto = (new Element.Reveal.Server.DALC.FiwpDAL()).GetFiwpByID(dbname, 2).FirstOrDefault();
        //    mtoList = (new Element.Reveal.Server.BALC.ProjectReader()).GetComponentProgressByFIWP(dbname, fiwpdto.FiwpID, fiwpdto.ProjectScheduleID, fiwpdto.ProjectID, fiwpdto.ModuleID);

        //    //Test
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).CreateQaqcForm(dbname, fiwpqaqclist, mtoList, fiwpdto, updatedBy, Cookies.GetSPCredential());
        //}
        
        ///// <summary>
        ///// Save(contains Update and Delete) Fiwpqaqc objects for AssembleIWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpqaqcs">Fiwpqaqc objects to save</param>
        ///// <returns>FiwpqaqcDTO</returns>
        //public List<FiwpqaqcDTO> SaveFiwpqaqcForAssembleIWP(List<FiwpqaqcDTO> fiwpqaqcs, List<FiwpDTO> fiwps, List<DocumentDTO> documents)//, string userName, string password)
        //{
        //    string userName = string.Empty;
        //    string password = string.Empty;

        //    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        //    {
        //        string[] info = (new P6ManagerService()).GetP6Login();
        //        userName = info[0];
        //        password = info[1];
        //    }
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveFiwpqaqcForAssembleIWP(fiwpqaqcs, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL(), userName, password);
        //}

        ///// <summary>
        ///// Save(contains Update and Delete) Fiwpqaqc objects for AssembleIWP.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpqaqcs">Fiwpqaqc objects to save</param>
        ///// <returns>FiwpqaqcDTO</returns>
        //public List<FiwpqaqcDTO> JsonSaveFiwpqaqcForAssembleIWP(List<FiwpqaqcDTO> fiwpqaqcs, List<FiwpDTO> fiwps, List<DocumentDTO> documents)//, string userName, string password)
        //{
        //    string userName = string.Empty;
        //    string password = string.Empty;

        //    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        //    {
        //        string[] info = (new P6ManagerService()).GetP6Login();
        //        userName = info[0];
        //        password = info[1];
        //    }
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveFiwpqaqcForAssembleIWP(fiwpqaqcs, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL(), userName, password);
        //}

        //public List<DocumentDTO> SaveSafetyDocumentForAssembleIWP(List<DocumentDTO> safetys, List<FiwpDTO> fiwps, List<DocumentDTO> documents)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveSafetyDocumentForAssembleIWP(safetys, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL());
        //}

        //public List<DocumentDTO> JsonSaveSafetyDocumentForAssembleIWP(List<DocumentDTO> safetys, List<FiwpDTO> fiwps, List<DocumentDTO> documents)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveSafetyDocumentForAssembleIWP(safetys, fiwps, documents, Cookies.GetSPCredential(), Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> SavePnIDDrawingForBuildCSU(List<ComboBoxDTO> drawings, List<FiwpDTO> fiwps)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SavePnIDDrawingForBuildCSU(drawings, fiwps, Helper.GetImageLocationURL());
        //}

        //public List<ComboBoxDTO> JsonSavePnIDDrawingForBuildCSU(List<ComboBoxDTO> drawings, List<FiwpDTO> fiwps)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SavePnIDDrawingForBuildCSU(drawings, fiwps, Helper.GetImageLocationURL());
        //}

        //public List<DocumentDTO> SaveAssociatedDocumentForBuildCSU(List<DocumentDTO> associatedDocs, List<FiwpDTO> fiwps, int currentStep)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveAssociatedDocumentForBuildCSU(associatedDocs, fiwps, currentStep);
        //}

        //public List<DocumentDTO> JsonSaveAssociatedDocumentForBuildCSU(List<DocumentDTO> associatedDocs, List<FiwpDTO> fiwps, string currentStep)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveAssociatedDocumentForBuildCSU(associatedDocs, fiwps, Int32.Parse(currentStep));
        //}

        //public List<SigmacueDTO> SaveSigmacue(List<SigmacueDTO> cue, int dataId, string type)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveSimgacue(cue, dataId, type);
        //}

        //public List<SigmacueDTO> JsonSaveSigmacue(List<SigmacueDTO> cue, int dataId, string type)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveSimgacue(cue, dataId, type);
        //}

        //public List<DailybrassDTO> SaveDailybrass(List<DailybrassDTO> dailybrass)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDailybrass(dailybrass);
        //}

        public List<DailybrassDTO> JsonSaveDailybrass(List<DailybrassDTO> dailybrass)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Brass()).SaveDailybrass(dailybrass);
        }

        //public List<DailybrasssignDTO> SaveDailybrasssign(List<DailybrasssignDTO> dailybrasssign)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDailybrasssign(dailybrasssign);
        //}

        public List<DailybrasssignDTO> JsonSaveDailybrasssign(List<DailybrasssignDTO> dailybrasssign)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Brass()).SaveDailybrasssign(dailybrasssign);
        }

        //public List<DailybrasssignDTO> SaveDailybrasssignOffline(List<DailybrasssignDTO> dailybrasssign)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDailybrasssignOffline(dailybrasssign);
        //}

        //public List<DailybrasssignDTO> JsonSaveDailybrasssignOffline(List<DailybrasssignDTO> dailybrasssign)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDailybrasssignOffline(dailybrasssign);
        //}

        //public List<DailytoolboxDTO> SaveDailytoolbox(List<DailytoolboxDTO> dailytoolbox)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveDailytoolbox(dailytoolbox);
        //}

        public List<DailytoolboxDTO> JsonSaveDailybrasstoolbox(List<DailytoolboxDTO> dailytoolbox)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Brass()).SaveDailybrasstoolbox(dailytoolbox);
        }

        //public List<ToolboxsignDTO> SaveToolboxsign(List<ToolboxsignDTO> toolboxsign)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveToolboxsign(toolboxsign);
        //}

        //public List<ToolboxsignDTO> JsonSaveToolboxsign(List<ToolboxsignDTO> toolboxsign)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveToolboxsign(toolboxsign);
        //}

        //public List<ToolboxsignDTO> SaveToolboxsignOffline(List<ToolboxsignDTO> toolboxsign)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveToolboxsignOffline(toolboxsign);
        //}

        //public List<ToolboxsignDTO> JsonSaveToolboxsignOffline(List<ToolboxsignDTO> toolboxsign)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveToolboxsignOffline(toolboxsign);
        //}

        //public int SaveCrewAttendance(int dailybrassId, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCrewAttendance(dailybrassId, projectId, Cookies.GetSPCredential());
        //}

        //public int JsonSaveCrewAttendance(string dailybrassId, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveCrewAttendance(Int32.Parse(dailybrassId), Int32.Parse(projectId), Cookies.GetSPCredential());
        //}

        //public int SaveToolboxTalks(int dailybrassId, int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveToolboxTalks(dailybrassId, projectId, Cookies.GetSPCredential());
        //}

        //public int JsonSaveToolboxTalks(string dailybrassId, string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveToolboxTalks(Int32.Parse(dailybrassId), Int32.Parse(projectId), Cookies.GetSPCredential());
        //}

        ////public List<DailybrasssignDTO> GetDailybrasssignByDailyBrassPersonnelIDs(int dailybrassId, int gateNo, string personnelIds)
        ////{
        ////    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDailybrasssignByDailyBrassPersonnelIDs(dailybrassId, gateNo, personnelIds);
        ////}

        ////public List<DailybrasssignDTO> JsonGetDailybrasssignByDailyBrassPersonnelIDs(string dailybrassId, string gateNo, string personnelIds)
        ////{
        ////    return (new Element.Reveal.Server.BALC.ProjectReader()).GetDailybrasssignByDailyBrassPersonnelIDs(Int32.Parse(dailybrassId), Int32.Parse(gateNo), personnelIds);
        ////}

        ///// <summary>
        ///// Save(contains Update and Delete) Fiwpqaqc objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpqaqc">Fiwpqaqc objects to save</param>
        ///// <returns>FiwpqaqcDTO</returns>
        //public List<FiwpqaqcDTO> SaveFiwpqaqc(List<FiwpqaqcDTO> fiwpqaqc)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpqaqc(fiwpqaqc);
        //}

        ///// <summary>
        ///// Save(contains Update and Delete) Fiwpqaqc objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="fiwpqaqc">Fiwpqaqc objects to save</param>
        ///// <returns>FiwpqaqcDTO</returns>
        //public List<FiwpqaqcDTO> JsonSaveFiwpqaqc(List<FiwpqaqcDTO> fiwpqaqc)
        //{
        //    return (new Element.Reveal.Server.BALC.ScheduleWriter()).SaveFiwpqaqc(fiwpqaqc);
        //}

        ///// <summary>
        ///// Save(contains Update and Delete) Qaqcconfig objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="qaqcconfig">Qaqcconfig objects to save</param>
        ///// <returns>List<QaqcconfigDTO></returns>
        //public List<QaqcconfigDTO> SaveQaqcconfig(List<QaqcconfigDTO> qaqcconfig)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcconfig(qaqcconfig);
        //}

        ///// <summary>
        ///// Save(contains Update and Delete) Qaqcconfig objects.
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="qaqcconfig">Qaqcconfig objects to save</param>
        ///// <returns>List<QaqcconfigDTO></returns>
        //public List<QaqcconfigDTO> JsonSaveQaqcconfig(List<QaqcconfigDTO> qaqcconfig)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcconfig(qaqcconfig);
        //}

        //#region Quantity_Survey
        //public List<QuantityserveyDTO> SaveQuantitySurvey(List<QuantityserveyDTO> quantityservey)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQuantitySurvey(quantityservey);
        //}
        //public List<QuantityserveyDTO> JsonSaveQuantitySurvey(List<QuantityserveyDTO> quantityservey)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQuantitySurvey(quantityservey);
        //}
        //#endregion Quantity_Survey

        //#region Tunrover_PunchCard_SAVE
        ///// <summary>
        ///// SaveQaqcformWithSharepoint
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="turnoverDTOS"></param>
        ///// <param name="turnoverattendeeDTOS"></param>
        ///// <param name="qaqcformDTOS"></param>
        ///// <returns></returns>
        //public WalkdownDTOSet SaveQaqcformWithSharepoint(WalkdownDTOSet walkdownDs)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcformWithSharepoint(walkdownDs);
        //}
        ///// <summary>
        ///// JsonSaveQaqcformWithSharepoint
        ///// </summary>
        ///// <param name="dbInstance"></param>
        ///// <param name="turnoverDTOS"></param>
        ///// <param name="turnoverattendeeDTOS"></param>
        ///// <param name="qaqcformDTOS"></param>
        ///// <returns></returns>
        //public WalkdownDTOSet JsonSaveQaqcformWithSharepoint(WalkdownDTOSet walkdownDs)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveQaqcformWithSharepoint(walkdownDs);
        //}

        //#endregion Tunrover_PunchCard_SAVE

        //#region Turnover Package
        //public List<DocumentDTO> SaveTurnoverPackageWithSharePoint(DocumentDTO documentDTO, FiwpDTO fiwpDTO)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveTurnoverPackageWithSharePoint(documentDTO, fiwpDTO, Cookies.GetSPCredential());
        //}

        //public QaqcformDTO SaveTurnoverCertificateForMC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveTurnoverCertificateForMC(documentDTO, qaqcformDTO, systemId, Cookies.GetSPCredential());
        //}
        //public List<DocumentDTO> SaveTurnoverCertificatePDFForMC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveTurnoverCertificatePDFForMC(documentDTO, qaqcformDTO, systemId, Cookies.GetSPCredential());
        //}

        //public QaqcformDTO SaveTurnoverCertificateForTCCC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveTurnoverCertificateForTCCC(documentDTO, qaqcformDTO, systemId, Cookies.GetSPCredential());
        //}
        //public List<DocumentDTO> SaveTurnoverCertificatePDFForTCCC(DocumentDTO documentDTO, QaqcformDTO qaqcformDTO, int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectWriter()).SaveTurnoverCertificatePDFForTCCC(documentDTO, qaqcformDTO, systemId, Cookies.GetSPCredential());
        //}

        //#endregion


        //#endregion "End Update"

        //#region "Punch"
        ///// <summary>
        ///// PunchList by Discipline
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <returns>List<rptPunchDTO></returns>
        //public List<rptPunchDTO> GetPunchChartbyDiscipline(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPunchChartbyDiscipline(projectId);
        //}
        ///// <summary>
        ///// PunchList by Discipline
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <returns>List<rptPunchDTO></returns>
        //public List<rptPunchDTO> GetPunchChartbyCAT(int projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPunchChartbyCAT(projectId);
        //}
        ///// <summary>
        ///// Json PunchList by Discipline
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <returns>List<rptPunchDTO></returns>
        //public List<rptPunchDTO> JsonGetPunchChartbyDiscipline(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPunchChartbyDiscipline(Convert.ToInt32(projectId));
        //}
        ///// <summary>
        ///// Json PunchList by Discipline
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <returns>List<rptPunchDTO></returns>
        //public List<rptPunchDTO> JsonGetPunchChartbyCAT(string projectId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetPunchChartbyCAT(Convert.ToInt32(projectId));
        //}

        //public QaqcformDTO GetTurnoverCertificateForMC(int projectId, int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetTurnoverCertificateForMC(projectId, systemId);
        //}

        //public QaqcformDTO GetTurnoverCertificateForTCCC(int projectId, int systemId)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetTurnoverCertificateForTCCC(projectId, systemId);
        //}

        //#endregion


        //#region "ITR"
        ///// <summary>
        ///// ITR List by System
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>List<rptQAQCformDTO></returns>
        //public List<rptQAQCformDTO> GetITRChartbySystem(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetITRChartbySystem(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}
        ///// <summary>
        ///// ITR List by CWP
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>List<rptQAQCformDTO></returns>
        //public List<rptQAQCformDTO> GetITRChartbyCWP(int projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetITRChartbyCWP(projectId, Helper.RemoveJsonParameterWrapper(disciplineCode));
        //}
        ///// <summary>
        ///// Json ITR List by System
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>List<rptQAQCformDTO></returns>
        //public List<rptQAQCformDTO> JsonGetITRChartbySystem(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetITRChartbySystem(Convert.ToInt32(projectId), Convert.ToInt32(disciplineCode));
        //}
        ///// <summary>
        ///// Json ITR List by CWP
        ///// </summary>
        ///// <param name="dbInstance">The name of the database instance is what you use to refer to a particular connection string for a particular provider via code</param>
        ///// <param name="projectId">ProjectId to search for</param>
        ///// <param name="disciplineCode">DisciplineCode to search for</param>
        ///// <returns>List<rptQAQCformDTO></returns>
        //public List<rptQAQCformDTO> JsonGetITRChartbyCWP(string projectId, string disciplineCode)
        //{
        //    return (new Element.Reveal.Server.BALC.ProjectReader()).GetITRChartbyCWP(Convert.ToInt32(projectId), Convert.ToInt32(disciplineCode));
        //}

        //#endregion

        /// <summary>
        /// JsonGetProjectCwaIwpByIwp
        /// </summary>
        /// <param name="iwpId"></param>
        /// <returns></returns>
        public rptProjectCwaIwpDTO JsonGetProjectCwaIwpByIwp(string iwpId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).GetProjectCwaIwpByIwp(Int32.Parse(iwpId));
        }

        public SigmaResultTypeDTO JsonSaveCrewAttendance_Rpt(string dailybrassId, string SigmaUserId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Brass()).SaveCrewAttendance_Rpt(Int32.Parse(dailybrassId), SigmaUserId);
        }

        public SigmaResultTypeDTO JsonSaveTimeAndProgress_Rpt(string dailybrassId, string SigmaUserId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Brass()).SaveTimeAndProgress_Rpt(Int32.Parse(dailybrassId), SigmaUserId);
        }

        /// <summary>
        /// Temp Method For P6 Test
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="url"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public SigmaResultTypeDTO JsonReadP6WBSManager(string projectId, string url, string userName, string password, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.P6Manager()).ReadP6WBSManager(Int32.Parse(projectId), Helper.RemoveJsonParameterWrapper(url), Helper.RemoveJsonParameterWrapper(userName), Helper.RemoveJsonParameterWrapper(password), Helper.RemoveJsonParameterWrapper(userId));
        }

        public int JsongenerateRptTest(string div, string userId)
        {
            return (new Element.Sigma.Web.Biz.TrueTask.Assemble()).generateRptTest(Int32.Parse(div), userId);
        }
    }
}
