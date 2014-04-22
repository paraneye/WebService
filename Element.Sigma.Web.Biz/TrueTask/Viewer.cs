using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Element.Shared.Common;
using Element.Reveal.DataLibrary;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class Viewer
    {
        public DrawingPageTotal GetDrawingForDrawingViewer(int projectId, List<int> cwpId, List<int> fiwpId, List<int> drawingtype, string engtag, string title, string sortOption, int currpage, int pageSize, string path)
        {
            DrawingPageTotal rtn = new DrawingPageTotal();

            List<DrawingcwpDTO> drawingcwp = new List<DrawingcwpDTO>();
            List<DrawingreferenceDTO> Drawingreference = new List<DrawingreferenceDTO>();
            List<ComboBoxDTO> mtos = new List<ComboBoxDTO>();

            int[] cwpArray = cwpId == null ? null : cwpId.ToArray();
            int[] fiwpArray = fiwpId == null ? null : fiwpId.ToArray();
            int[] typeArray = drawingtype == null ? null : drawingtype.ToArray();

            string cwpIds = Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(cwpArray);
            string fiwpIds = Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(fiwpArray);
            string drawingtypes = Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(typeArray);

            path = path + "/SigmaStorage/";

            rtn = GetDrawingByXmlParameter(projectId, cwpIds, fiwpIds, drawingtypes, engtag, title, sortOption, currpage, pageSize, path);

            if (rtn.drawing != null)
            {
                var x = (from m in rtn.drawing select m.DrawingID).Distinct();
                string drawingIDs = Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(x.ToArray());

                if (!string.IsNullOrEmpty(drawingIDs))
                {
                    drawingcwp = GetDrawingCwpByIDs(drawingIDs);
                    Drawingreference = GetDrawingreferenceByIDs(drawingIDs);
                    mtos = GetMTOByDrawingIDs_Combo(drawingIDs);
                }

                if (rtn.drawing.Count > 0)
                {
                    for (int i = 0; i < rtn.drawing.Count; i++)
                    {
                        if (drawingcwp != null && drawingcwp.Count > 0)
                        {
                            List<DrawingcwpDTO> cwps = (from dcwp in drawingcwp where dcwp.DrawingID == rtn.drawing[i].DrawingID select dcwp).ToList();
                            if (cwps != null)
                                rtn.drawing[i].drawingcwp = cwps;
                        }

                        if (Drawingreference != null && Drawingreference.Count > 0)
                        {
                            var drawingrefs = Drawingreference.Where(y => y.DrawingID == rtn.drawing[i].DrawingID).ToList();
                            if (drawingrefs != null)
                                rtn.drawing[i].drawingref = drawingrefs;
                        }

                        if (mtos != null && mtos.Count > 0)
                        {
                            var mto = mtos.Where(y => y.DataID == rtn.drawing[i].DrawingID).ToList();
                            if (mto != null)
                                rtn.drawing[i].mto = mto;
                        }
                    }
                }
            }

            return rtn;

        }

        public List<ComboBoxDTO> GetMTOByDrawingIDs_Combo(string drawingIds)
        {

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@drawingIds", drawingIds)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboMTOByDrawingIDs", parameters);  //sp_get_combo_mto_by_drawingIDs
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        public List<DrawingreferenceDTO> GetDrawingreferenceByIDs(string drawingIds)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DrawingIDs", drawingIds)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetReferenceDrawingByDrawingIds", parameters);  //sp_findByIDs_drawingreference
            List<DrawingreferenceDTO> result = DTOHelper.DataTableToListDTO<DrawingreferenceDTO>(ds);
            return result;

        }

        public List<DrawingcwpDTO> GetDrawingCwpByIDs(string drawingIds)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DrawingIDs", drawingIds)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDrawingcwp_by_IDs", parameters);  //sp_get_drawingcwp_by_IDs
            List<DrawingcwpDTO> result = DTOHelper.DataTableToListDTO<DrawingcwpDTO>(ds);
            return result;

        }

        public DrawingPageTotal GetDrawingByXmlParameter(int projectId, string cwpId, string fiwpId, string drawingtype, string engtag, string title, string sortOption, int currpage, int pageSize, string path)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            DrawingPageTotal result = new DrawingPageTotal();


            // Compose parameters
            //List<SqlParameter> parameters = new List<SqlParameter>();

            //parameters.Add(new SqlParameter("@ProjectID", projectId));
            //parameters.Add(new SqlParameter("@CWPIDs", cwpId));
            //parameters.Add(new SqlParameter("@FIWPIDs", fiwpId));
            //parameters.Add(new SqlParameter("@DrawingTypeLUIDs", drawingtype));
            //parameters.Add(new SqlParameter("@EngTagNumber", engtag));
            //parameters.Add(new SqlParameter("@Description", title));
            //parameters.Add(new SqlParameter("@SortOption", sortOption));
            //parameters.Add(new SqlParameter("@CurrPage", currpage));
            //parameters.Add(new SqlParameter("@PageSize", pageSize));
            //parameters.Add(new SqlParameter("@Path", path));

            //SqlParameter outParam1 = new SqlParameter("@TotalPage", SqlDbType.Int);
            //SqlParameter outParam2 = new SqlParameter("@TotalCount", SqlDbType.Int);
            //outParam1.Direction = ParameterDirection.Output;
            //outParam2.Direction = ParameterDirection.Output;
            //parameters.Add(outParam1);
            //parameters.Add(outParam2);

            int totalPage = 0;
            int totalCount = 0;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectID", projectId),
                new SqlParameter("@CWPIDs", cwpId),
                new SqlParameter("@FIWPIDs", fiwpId),
                new SqlParameter("@DrawingTypeLUIDs", drawingtype),
                new SqlParameter("@EngTagNumber", engtag),
                new SqlParameter("@Description", title),
                new SqlParameter("@SortOption", sortOption),
                new SqlParameter("@CurrPage", currpage),
                new SqlParameter("@PageSize", pageSize),
                new SqlParameter("@Path", path),
                new SqlParameter("@TotalPage", SqlDbType.Int),
                new SqlParameter("@TotalCount", SqlDbType.Int)
            };
            int iNum = parameters.Length - 1;
            parameters[iNum].Direction = ParameterDirection.Output;
            parameters[iNum-1].Direction = ParameterDirection.Output;

            // Get Data 
            //DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDrawingXmlparameter", parameters);  //sp_get_drawing_xmlparameter
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "tsp_GetDrawingXmlparameter", parameters);  //sp_get_drawing_xmlparameter

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result.drawing = DTOHelper.DataTableToListDTO<DrawingDTO>(ds, 0);

                result.TotalPageCount = Convert.ToInt32(parameters[iNum-1].Value.ToString());
                result.TotalRowCount = Convert.ToInt32(parameters[iNum].Value.ToString());
            }
            result.CurrentPage = currpage;

            return result;
        }
                
        //GetFIWPDocDrawingsByFIWP 수정
        public DocumentAndDrawing GetIWPDocDrawingsByIWP(int fiwpId, int projectId, string disciplineCode, string path)
        {
            DocumentAndDrawing document = new DocumentAndDrawing();

            List<DocumentDTO> resultFIWPs = (new Assemble()).GetDocumentByFIWPDocType("", fiwpId, projectId, disciplineCode, path);
            //linq없이 모두 넘기고 ui에서 직접 처리함
            document.documents = resultFIWPs;

            //Drawing Add (SPCollectionName.Drawing)
            document.drawings = GetAllDrawingByIWP(fiwpId, path);

            //todo: 아랫부분 확인후 추가작업해야됨
            ////WFP Add (SPCollectionName.ProjectDoc)
            //document.WFP = resultFIWPs.Where(x => x.DocumentTypeLUID == DocType.WorkfacePlanning || x.DocumentTypeLUID == DocType.WorkfacePlanning1 || x.DocumentTypeLUID == DocType.WorkfacePlanning2).ToList();

            ////QAQC Add (SPCollectionName.QAQC)
            //document.QAQC = resultFIWPs.Where(x => x.DocumentTypeLUID == DocType.QC).ToList();

            ////Safetydocument Add (SPCollectionName.SafetyDoc)
            //document.SafetyDoc = resultFIWPs.Where(x => x.DocumentTypeLUID == DocType.SafteyDoc).ToList();

            ////RFI Add (SPCollectionName.RFIDoc)
            //document.RFIDoc = resultFIWPs.Where(x => x.DocumentTypeLUID == DocType.RFIDoc).ToList();
            //todo: 아랫부분 확인후 추가작업해야됨 end

            return document;
        }

        //GetAllDrawingByFIWP 수정
        public List<DrawingDTO> GetAllDrawingByIWP(int iwpId, string path)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@fiwpId", iwpId),
                    new SqlParameter("@path", path + "/SigmaStorage/")
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetAllDrawingByIwp", parameters);  //sp_get_alldrawing_by_fiwp
            List<DrawingDTO> result = DTOHelper.DataTableToListDTO<DrawingDTO>(ds);
            return result;
        }

        public List<DrawingStickyNoteDTO> GetDrawingStickyNoteByDrawing(int drawingId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@drawingId", drawingId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDrawingStickyNoteByDrawing", parameters);  //sp_get_documentnote_by_drawing
            List<DrawingStickyNoteDTO> result = DTOHelper.DataTableToListDTO<DrawingStickyNoteDTO>(ds);
            return result;
        }

        public List<DrawingStickyNoteDTO> SaveDrawingStickyNote(DrawingStickyNoteDTO paramDTO, int iwpId)
        {
            List<DrawingStickyNoteDTO> stickyNotes = new List<DrawingStickyNoteDTO>();
            DrawingStickyNoteDTO stickyNote = new DrawingStickyNoteDTO();

            //update
            if (paramDTO.DrawingStickyNoteId > 0)
            {
                stickyNote = GetDrawingStickyNote(paramDTO.DrawingStickyNoteId);
                stickyNote.DTOStatus = (int)RowStatusNo.Update;
                stickyNote.UpdatedBy = paramDTO.UpdatedBy;
            }
            //insert
            else
            {
                stickyNote.DTOStatus = (int)RowStatusNo.New;
                stickyNote.DrawingStickyNoteId = 0;
                stickyNote.DrawingId = paramDTO.DrawingId;
                stickyNote.CreatedBy = paramDTO.CreatedBy;
            }

            stickyNote.LocationX = paramDTO.LocationX;
            stickyNote.LocationY = paramDTO.LocationY;
            stickyNote.Description = paramDTO.Description;

            stickyNotes.Add(stickyNote);

            return DalSaveDrawingStickyNote(stickyNotes);
        }

        public DrawingStickyNoteDTO GetDrawingStickyNote(int drawingStickyNoteId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DrawingStickyNoteId", drawingStickyNoteId),
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDrawingStickyNote", parameters);  //sp_findByID_documentnote
            DrawingStickyNoteDTO result = DTOHelper.DataTableToSingleDTO<DrawingStickyNoteDTO>(ds);
            return result;
        }

        public List<DrawingStickyNoteDTO> DalSaveDrawingStickyNote(List<DrawingStickyNoteDTO> objList)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(objList.GetType(), objList);

            string insert_sp_name = "tsp_AddDrawingStickyNote";  //sp_insert_documentnote
            string update_sp_name = "tsp_UpdateDrawingStickyNote";  //sp_update_documentnote
            string delete_sp_name = "tsp_RemoveDrawingStickyNote";  //sp_delete_documentnote


            string[] insert_columns = { "DrawingStickyNoteId", "DrawingId", "LocationX", "LocationY", "Description", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] update_columns = { "DrawingStickyNoteId", "DrawingId", "LocationX", "LocationY", "Description", "CreatedBy", "CreatedDate", "UpdatedBy", "UpdatedDate" };
            string[] delete_columns = { "DrawingStickyNoteId" };

            ds = DAHelper.UpdateDataTableBySqlConnection(connStr, ds, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatusNo.None);

            objList = (List<DrawingStickyNoteDTO>)DTOHelper.DeserializeDTOList(objList.GetType(), ds);

            // Return the data transfer object.
            return objList;
        }

        public List<string> GetIwpDocumentFilterByIwp(int iwpId, int projectId, string disciplineCode)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            int m = 0;
            string drawingDoc = "";
            string projectDoc = "";
            string safetyDoc = "";
            string rfiDoc = "";
            string qaqcDoc = "";

            List<string> results = new List<string>();
            //List<DocumentDTO> rDocument = (new Element.Reveal.Server.DALC.DocumentDAL()).GetDocumentByFiwpID(dbname, fiwpid);
            List<DocumentDTO> rDocument = GetIwpDocumentByIwp(iwpId, projectId, disciplineCode);
            List<DrawingDTO> rDrawing = GetDrawingByIwpProjectDiscipline(iwpId, projectId, disciplineCode);

            if (rDocument.Count > 0)
            {
                projectDoc = SPCollectionName.ProjectDoc + "$filter=";
                safetyDoc = SPCollectionName.SafetyDoc + "$filter=";
                rfiDoc = SPCollectionName.RFIDoc + "$filter=";
                qaqcDoc = SPCollectionName.QAQC + "$filter=";

                //foreach (DocumentDTO dto in rDocument)
                //{
                //    if (dto.SPCollectionID > 0)
                //    {
                //        switch (dto.DocumentTypeLUID)
                //        {
                //            case DocType.WorkfacePlanning:
                //            case DocType.WorkfacePlanning1:
                //            case DocType.WorkfacePlanning2:
                //                {
                //                    if (i > 0)
                //                        projectDoc += "or";

                //                    projectDoc += "(Id eq " + dto.SPCollectionID + ")";
                //                    i++;
                //                    break;
                //                }
                //            case DocType.SafteyDoc:
                //                {
                //                    if (j > 0)
                //                        safetyDoc += "or";

                //                    safetyDoc += "(Id eq " + dto.SPCollectionID + ")";
                //                    j++;
                //                    break;
                //                }
                //            case DocType.RFIDoc:
                //                {
                //                    if (k > 0)
                //                        rfiDoc += "or";

                //                    rfiDoc += "(Id eq " + dto.SPCollectionID + ")";
                //                    k++;
                //                    break;
                //                }
                //            case DocType.QC:
                //                {
                //                    if (l > 0)
                //                        qaqcDoc += "or";

                //                    qaqcDoc += "(Id eq " + dto.SPCollectionID + ")";
                //                    l++;
                //                    break;
                //                }
                //        }
                //    }
                //}
            }

            if (rDrawing.Count > 0)
            {
                drawingDoc = SPCollectionName.Drawing + "$filter=";

                foreach (DrawingDTO dto in rDrawing)
                {
                    if (dto.SPCollectionID > 0)
                    {
                        if (m > 0)
                            drawingDoc += "or";

                        drawingDoc += "(Id eq " + dto.SPCollectionID + ")";
                        m++;
                    }
                }
            }

            if (i > 0)
                results.Add(projectDoc);
            if (m > 0)
                results.Add(drawingDoc);
            if (j > 0)
                results.Add(safetyDoc);
            if (k > 0)
                results.Add(rfiDoc);
            if (l > 0)
                results.Add(qaqcDoc);

            return results;
        }

        public List<DocumentDTO> GetIwpDocumentByIwp(int iwpId, int projectid, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@iwpId", iwpId),
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwpDocumentByIwp", parameters);  //sp_get_document_by_fiwp
            List<DocumentDTO> result = DTOHelper.DataTableToListDTO<DocumentDTO>(ds);
            return result;
        }

        public List<DrawingDTO> GetDrawingByIwpProjectDiscipline(int iwpId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@iwpId", iwpId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDrawingByIwpProjectDiscipline", parameters);  //sp_get_drawing_by_fiwp_projectid_moduleid
            List<DrawingDTO> result = DTOHelper.DataTableToListDTO<DrawingDTO>(ds);
            return result;
        }

        public List<DocumentmarkupDTO> GetDocumentmarkupByDrawingPersonnel(int drawingId, string personnelId, string webPath)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DrawingId", drawingId),
                    new SqlParameter("@SigmaUserId", personnelId),
                    new SqlParameter("@WebPath", webPath + "/SigmaStorage/")
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDocumentmarkupByDrawingSigmaUser", parameters);  //sp_get_documentmarkup_by_drawing_personnel
            List<DocumentmarkupDTO> result = DTOHelper.DataTableToListDTO<DocumentmarkupDTO>(ds);
            return result;
        }

        public List<DocumentmarkupDTO> SaveDrawingMarkup(List<DocumentmarkupDTO> documentmarkup)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(documentmarkup.GetType(), documentmarkup);

            string insert_sp_name = "tsp_AddDrawingMarkup";
            string update_sp_name = "tsp_UpdateDrawingMarkup";
            string delete_sp_name = "tsp_RemoveDrawingMarkup";

            string[] insert_columns = { "DocumentMarkupID", "FileStoreId", "PersonnelID", "DrawingID", "UpdatedBy" };
            string[] update_columns = { "DocumentMarkupID", "FileStoreId", "PersonnelID", "DrawingID", "UpdatedBy" };
            string[] delete_columns = { "DocumentMarkupID" };

            ds.Tables[0].TableName = TableName.Documentmarkup;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.Documentmarkup, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.Documentmarkup;
            documentmarkup = (List<DocumentmarkupDTO>)DTOHelper.DeserializeDTOList(documentmarkup.GetType(), ds);

            // Return the data transfer object.
            return documentmarkup;
        }

        public DocumentmarkupDTO SaveDocumentmarkupWithMarkupImage(DocumentmarkupDTO documentmarkup, UpfileDTOS upFileCollection)
        {
            //TransactionScope scope = null;
            //byte[] bytes = null;
            string fileType = Element.Reveal.DataLibrary.Utilities.FileType.DRAWING_MARKUP;            
            string fileName = documentmarkup.PersonnelID + "_" + documentmarkup.DrawingID + "_" + fileType;

            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            //{

            #region Upload Report File & Save File Info
            
            upFileCollection.fileStoreDTOList[0].FileTitle = fileName;
            upFileCollection.fileStoreDTOList[0].FileDescription = DateTime.Now.ToString();
            upFileCollection.fileStoreDTOList[0].FileCategory = Element.Reveal.DataLibrary.Utilities.FileCategory.REPORT;
            upFileCollection.fileStoreDTOList[0].FileTypeCode = fileType;
                        
            upFileCollection.uploadedFileDTOList[0].Name = fileName;
            upFileCollection.uploadedFileDTOList[0].UploadedBy = documentmarkup.UpdatedBy;
            upFileCollection.uploadedFileDTOList[0].UploadedDate = DateTime.Now;
            upFileCollection.uploadedFileDTOList[0].CreatedBy = documentmarkup.UpdatedBy;
            upFileCollection.uploadedFileDTOList[0].UpdatedBy = documentmarkup.UpdatedBy;
                        
            upFileCollection = (new TrueTask.Common()).SaveSingleUploadFile(upFileCollection, documentmarkup.PersonnelID);

            #endregion

            #region Save Report Document Info

            List<DocumentmarkupDTO> documentmarkups = new List<DocumentmarkupDTO>();

            //documentmarkup.SPCollectionID = upFileCollection.uploadedFileDTOList[0].UploadedFileInfoId;
            documentmarkup.FileStoreId = upFileCollection.uploadedFileDTOList[0].FileStoreId;               
            documentmarkups.Add(documentmarkup);

            documentmarkups = SaveDrawingMarkup(documentmarkups);

            if (documentmarkups != null && documentmarkups.Count > 0)
                documentmarkup = documentmarkups[0];

            #endregion

            //    scope.Complete();
            //}

            return documentmarkup;
        }

        public List<RfiDTO> SaveRFI(List<RfiDTO> rfi)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(rfi.GetType(), rfi);

            string insert_sp_name = "sp_insert_rfi";
            string update_sp_name = "sp_update_rfi";
            string delete_sp_name = "sp_delete_rfi";

            string[] insert_columns = { "RFIID", "RFINumber", "RFIDate", "ClientRFINumber", "SignedOff", "SignedOffDate", "ProjectID", "ModuleID", "ClientRFIFileLocation", "ChangeManagementCode", "Description", "CWPID", "CWAID", "DrawingID", "InformationRequested", "ReasonRequested", "DateReplyRequired", "RemindialProposal", "PreparedBy", "ContractorCompany", "DateSubmitted", "RFICoordinator", "RFICoordinatorDate", "ReponsibleEngineer", "ReponsibleEngineerDate", "ResponseImpacts", "ResponseBy", "ResponseDate", "IsSubmitted", "FollowUPDocTypeLUID" };
            string[] update_columns = { "RFIID", "RFINumber", "RFIDate", "ClientRFINumber", "SignedOff", "SignedOffDate", "ProjectID", "ModuleID", "ClientRFIFileLocation", "ChangeManagementCode", "Description", "CWPID", "CWAID", "DrawingID", "InformationRequested", "ReasonRequested", "DateReplyRequired", "RemindialProposal", "PreparedBy", "ContractorCompany", "DateSubmitted", "RFICoordinator", "RFICoordinatorDate", "ReponsibleEngineer", "ReponsibleEngineerDate", "ResponseImpacts", "ResponseBy", "ResponseDate", "IsSubmitted", "FollowUPDocTypeLUID" };
            string[] delete_columns = { "RFIID" };

            ds = DAHelper.UpdateDataTableBySqlConnection(connStr, ds, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatusNo.None);

            rfi = (List<RfiDTO>)DTOHelper.DeserializeDTOList(rfi.GetType(), ds);

            // Return the data transfer object.
            return rfi;

        }

    }

}
