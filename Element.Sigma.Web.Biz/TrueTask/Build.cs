using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Element.Shared.Common;
using Element.Reveal.DataLibrary;
using System.Transactions;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class Build
    {
        /// <summary>
        /// GetCwpsByProjectID
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        public List<CwpDTO> GetCwpsByProjectID(int projectId, string disciplineCode, string userId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode),
                    new SqlParameter("@SigmaUserId", userId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetCwpByProjectDiscipline", parameters);
            List<CwpDTO> result = DTOHelper.DataTableToListDTO<CwpDTO>(ds);
            return result;            
        }

        /// <summary>
        /// GetFiwpByID
        /// </summary>
        /// <param name="iwpId"></param>
        /// <returns></returns>
        public List<FiwpDTO> GetFiwpByID(int iwpId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IwpId", iwpId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwp", parameters);
            List<FiwpDTO> result = DTOHelper.DataTableToListDTO<FiwpDTO>(ds);
            return result;            
        }

        /// <summary>
        /// GetSigmaUserSigmaRoleBySigmaRoleReportToReportToRoleProject
        /// </summary>
        /// <param name="roleTypeCode"></param>
        /// <param name="reportTo"></param>
        /// <param name="reportToRoleTypeCode"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<ComboCodeBoxDTO> GetSigmaUserSigmaRoleBySigmaRoleReportToReportToRoleProject(string roleTypeCode, string reportTo, string reportToRoleTypeCode, int projectId, string webPath)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@RoleTypeCode", roleTypeCode),
                    new SqlParameter("@ReportTo", reportTo),
                    new SqlParameter("@ReportToRoleTypeCode", reportToRoleTypeCode),
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@WebPath", webPath + "/SigmaStorage/")
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetSigmaUserSigmaRoleBySigmaRoleReportToReportToRoleProject", parameters);
            List<ComboCodeBoxDTO> result = DTOHelper.DataTableToListDTO<ComboCodeBoxDTO>(ds);
            return result;            
        }

        /// <summary>
        /// GetProjectScheduleAllByProjectIDModuleID
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        public List<ProjectscheduleDTO> GetProjectScheduleAllByProjectIDModuleID(int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetScheduledWorkItemByProjectDiscipline", parameters);
            List<ProjectscheduleDTO> result = DTOHelper.DataTableToListDTO<ProjectscheduleDTO>(ds);
            return result;            
        }

        /// <summary>
        /// GetProjectScheduleByCwpProjectIDWithWBS
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<ProjectscheduleDTO> GetProjectScheduleByCwpProjectIDWithWBS(int cwpId, int projectId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CwpId", cwpId),
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@IncludedWBS", 1) 
                }; 

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetScheduledWorkItemByCwpProject", parameters);
            List<ProjectscheduleDTO> result = DTOHelper.DataTableToListDTO<ProjectscheduleDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetCWPByProject_Combo
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<ComboCodeBoxDTO> GetCWPByProject_Combo(int projectId, string disciplineCode, string userId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode),
                    new SqlParameter("@PanelBar", 0),
                    new SqlParameter("@SigmaUserId", userId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_ComboCwpByProject", parameters);
            List<ComboCodeBoxDTO> result = DTOHelper.DataTableToListDTO<ComboCodeBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetCWPByProject_Combo_Mobile
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        public List<ComboBoxDTO> GetCWPByProject_Combo_Mobile(int projectId, string disciplineCode, string userId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", projectId),
                    new SqlParameter("@DisciplineCode", disciplineCode),
                    new SqlParameter("@PanelBar", 0),
                    new SqlParameter("@SigmaUserId", userId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetCwpByProjectDisciplineForMobile", parameters);
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        /// <summary>
        /// GetFIWPByProjectSchedulePackageType_Combo
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns></returns>
        public List<ComboBoxDTO> GetFIWPByProjectSchedulePackageType_Combo(int scheduledWorkItemId, string packageTypeCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ScheduledWorkItemId", scheduledWorkItemId),
                    new SqlParameter("@PackageTypeCode", packageTypeCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwpByScheduledWorkItemPackageType", parameters);
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }         

        /// <summary>
        /// GetAvailableCollectionForScheduling
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="projectscheduleId"></param>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <returns>List<CollectionDTO></returns>
        public List<CollectionDTO> GetAvailableCollectionForScheduling(int cwpId, int projectscheduleId, int projectId, string disciplineCode, int iwpId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@cwpId", cwpId),
                    new SqlParameter("@projectscheduleId", projectscheduleId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@iwpId", iwpId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetAvialableCollectionForScheduling", parameters);
            List<CollectionDTO> result = DTOHelper.DataTableToList<CollectionDTO>(ds.Tables[0]);
            return result;

        }

        public List<DailybrassDTO> GetDailybrassByForemanPersonnelWorkDate(int projectId, string disciplineCode, string personnelId, DateTime workDate)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@personnelId", personnelId),
                    new SqlParameter("@workDate", workDate)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDailybrassByPersonnelWorkdate", parameters);
            List<DailybrassDTO> result = DTOHelper.DataTableToList<DailybrassDTO>(ds.Tables[0]);
            return result;
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cwpId"></param>
        /// <param name="drawingId"></param>
        /// <param name="taskCategoryCodeList"></param>
        /// <param name="taskTypeIdList"></param>
        /// <param name="materialIdList"></param>
        /// <param name="progressIdList"></param>
        /// <param name="searchcValue"></param>
        /// <param name="projectId"></param>
        /// <param name="disciplineCode"></param>
        /// <param name="path"></param>
        /// <param name="grouppage"></param>
        /// <returns></returns>
        public MTOAndDrawing  GetComponentProgressForScheduling(int cwpId
                                                                ,int projectscheduleId
                                                                ,int drawingId
                                                                ,List<string> taskCategoryCodeList
                                                                ,List<int> taskTypeIdList
                                                                ,List<int> materialIdList
                                                                ,List<int> progressIdList
                                                                ,string searchValue
                                                                ,int projectId
                                                                ,string disciplineCode
                                                                ,string path
                                                                ,int grouppage)
        {
            Common comm = new Common();

            MTOAndDrawing rtn = new MTOAndDrawing();
            MTOPageTotal p = new MTOPageTotal();

            string xmlID1s = (taskCategoryCodeList == null) ? "" : Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(taskCategoryCodeList.ToArray());
            string xmlID2s = (taskTypeIdList == null) ? "" : Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(taskTypeIdList.ToArray());
            string xmlID3s = (materialIdList == null) ? "" : Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(materialIdList.ToArray());
            string xmlID4s = (progressIdList == null) ? "" : Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(progressIdList.ToArray());

            //string projectpath = comm.GetProjectPath(projectId, "URL");
            //path = path + projectpath + "/";

            p = GetComponentProgressForSchedulingXmlParametrPaging(cwpId, projectscheduleId, drawingId, xmlID1s, xmlID2s, xmlID3s, xmlID4s, searchValue, projectId, disciplineCode, grouppage);

            rtn.mto = p.mto;
            rtn.TotalGroupPageCount = p.TotalPageCount;

            if (rtn.mto != null)
            {
                var x = (from m in rtn.mto select m.DrawingID).Distinct();
                string drawingIDs = Element.Shared.Common.Utilities.BuildIDArrayXMLParametr(x.ToArray());

                if (!string.IsNullOrEmpty(drawingIDs))
                {
                    rtn.drawing = comm.GetComboDrawingByIDs(path, drawingIDs);
                }
            }

            return rtn;
        }

        private MTOPageTotal GetComponentProgressForSchedulingXmlParametrPaging(
                                                                        int cwpId,
                                                                        int projectscheduleId,
                                                                        int drawingId,
                                                                        string taskCategoryCodeList,
                                                                        string taskTypeIdList,
                                                                        string materialIdList,
                                                                        string progressIdList,
                                                                        string searchValue,
                                                                        int projectId,
                                                                        string disciplineCode,
                                                                        int grouppage)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            int rtnValue = 0;
            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CWPID", cwpId),
                new SqlParameter("@ProjectScheduleID", projectscheduleId),
                new SqlParameter("@DrawingID", drawingId),

                new SqlParameter("@taskCategoryCodeList", taskCategoryCodeList),
                new SqlParameter("@taskTypeIdList", taskTypeIdList),
                new SqlParameter("@materialIdList", materialIdList),
                new SqlParameter("@progressIdList", progressIdList),

                new SqlParameter("@searchValue", searchValue),
                new SqlParameter("@ProjectID", projectId),
                new SqlParameter("@disciplineCode", disciplineCode),
                new SqlParameter("@GroupPage", grouppage),
                new SqlParameter("@TotalPage", rtnValue)
            };

            int iNum = parameters.Length - 1;
            parameters[iNum].Direction = ParameterDirection.Output;

            //DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetComponentprogressForSchedulingXmlparameter", parameters);  //sp_get_progress_for_scheduling_xmlparameter
            DataSet ds = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "tsp_GetComponentprogressForSchedulingXmlparameter", parameters);  //sp_get_progress_for_scheduling_xmlparameter

            MTOPageTotal result = new MTOPageTotal();
            result.mto = DTOHelper.DataTableToListDTO<MTODTO>(ds);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result.TotalPageCount = Convert.ToInt32(parameters[iNum].Value.ToString());
            }

            return result;
        }

        private string StringValuesArrayXMLParameter(List<ComboBoxDTO> stringValues)
        {
            System.Text.StringBuilder strXml = null;

            try
            {
                if (stringValues != null && stringValues.Count > 0)
                {
                    strXml = new System.Text.StringBuilder("<stringvalues>");

                    foreach (ComboBoxDTO child in stringValues)
                    {
                        strXml.Append("<stringvalue field=" + (char)34 + child.DataName + (char)34);
                        strXml.Append(" formular=" + (char)34 + child.ExtraValue1 + (char)34);
                        strXml.Append(" value=" + (char)34 + child.ExtraValue2 + (char)34 + "/>");
                    }

                    strXml.Append("</stringvalues>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to create xmlParameter.", ex);
            }

            return strXml == null ? null : strXml.ToString();
        }

        private string LocationArrayXMLParameter(List<ComboBoxDTO> locations)
        {
            System.Text.StringBuilder strXml = null;

            try
            {
                if (locations != null && locations.Count > 0)
                {
                    strXml = new System.Text.StringBuilder("<locations>");

                    foreach (ComboBoxDTO child in locations)
                    {
                        strXml.Append("<location field1=" + (char)34 + child.DataName + (char)34);
                        strXml.Append(" field2=" + (char)34 + child.ExtraValue3 + (char)34);
                        strXml.Append(" locationFrom=" + (char)34 + child.ExtraValue1 + (char)34);
                        strXml.Append(" locationTo=" + (char)34 + child.ExtraValue2 + (char)34);
                        strXml.Append(" formular=" + (char)34 + child.DataID + (char)34 + "/>");
                    }

                    strXml.Append("</locations>");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Not able to create xmlParameter.", ex);
            }

            return strXml == null ? null : strXml.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fiwpId"></param>
        /// <param name="projectScheduleID"></param>
        /// <param name="projectId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<MTODTO> GetComponentProgressByFIWP(int iwpId, int scheduledWorkItemId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@IwpId", iwpId),
                new SqlParameter("@ScheduledWorkItemId", scheduledWorkItemId),
                new SqlParameter("@ProjectId", projectId),
                new SqlParameter("@DisciplineCode", disciplineCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetComponentprogressByIwp", parameters);
            List<MTODTO> result = DTOHelper.DataTableToListDTO<MTODTO>(ds);
            return result;
        }

        /// <summary>
        /// SaveFIWP
        /// </summary>
        /// <param name="fiwps"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public List<FiwpDTO> SaveFIWP(List<FiwpDTO> fiwps)
        {
            string userName = string.Empty;
            string password = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    string[] P6LoginInfo = (new P6Manager()).GetP6Login();
                    userName = P6LoginInfo[0];
                    password = P6LoginInfo[1];
                }
                //if (isUsingMpp)
                //{
                //    // project id, so get last project loaded in projectschedule.
                //    //MppHelper.Instance.GetProjectInstance(fiwps[0].ProjectID);
                //}

                ProjectscheduleDTO projectSchedule = new ProjectscheduleDTO();
                //bool dochange = false;
                //List<ProjectscheduleDTO> schedule = new List<ProjectscheduleDTO>();                
                //int i = 0;
                foreach (FiwpDTO fiwp in fiwps)
                {
                    //if (fiwp.CrewMembersAssigned == 0)
                    //    fiwp.CrewMembersAssigned = GetFIWPManPower(dbname, fiwp.DepartStructureID, true);

                    //// Check to value in case of P6Calendar was haven't to higher than 0 when doing assignment
                    //if (fiwp.P6CalendarID > 0 && fiwp.DTOStatus != (int)RowStatus.New)
                    //    DoCheckProjectScheduleConstrain(dbname, fiwp, userName, password);

                    //if (!string.IsNullOrEmpty(fiwps[i].ExceptionMessage))
                    //{
                    //    if (fiwps[i].ExceptionMessage.Contains("Update ProjectSchedule"))
                    //        dochange = true;
                    //    else if (!string.IsNullOrEmpty(fiwps[i].ExceptionMessage))
                    //        throw new Exception(fiwps[i].ExceptionMessage);
                    //}

                    //if (fiwp.PackageTypeLUID == PackageType.SIWP && (fiwp.P6ActivityID == "0" || string.IsNullOrEmpty(fiwp.P6ActivityID)))
                    //{
                    //    fiwp.P6CalendarID = 0;
                    //    DoProcessFIWPWBS(dbname, fiwp, userName, password);
                    //}
                    //else
                    //{
                                        
                    switch (fiwp.DTOStatus)
                    {
                        case (int)RowStatusNo.New:                            
                            DoProcessFIWPWBS(fiwp, userName, password);
                            break;
                        case (int)RowStatusNo.Update:
                            DoUpdateFIWPToP6(fiwp, userName, password);
                            break;
                        case (int)RowStatusNo.Delete:
                            DoRemoveFIWPFromP6(fiwp, userName, password);
                            break;
                    }
                    //}
                    //if (dochange)
                    //    schedule = UpdateFIWPOutcomeProjectScheduleAndP6(dbname, fiwp, userName, password);
                }
                
                //if (fiwps[0].CWPID <= 0)
                //{
                //    ProjectscheduleDTO d = (new Element.Reveal.Server.DALC.ProjectscheduleDAL()).GetSignleProjscheduleByID(dbname, fiwps[0].ProjectScheduleID);
                //    fiwps[0].CWPID = d.CWPID;
                //}
                //fiwps = (new Element.Reveal.Server.DALC.FiwpDAL()).SaveIwp(dbname, fiwps, RowStatus.None);

                fiwps = SaveIwp(fiwps);                        
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #region "temp hidden"
            //finally
            //{
            //    if (isUsingMpp)
            //    {
            //        //MppHelper.Instance.Close(true);
            //        //MppHelper.Instance.CloseProjectInstance();
            //    }
            //}
            #endregion

            return fiwps;
        }

        public List<FiwpDTO> SaveIwp(List<FiwpDTO> fiwps)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(fiwps.GetType(), fiwps);

            string insert_sp_name = "tsp_AddIwp";
            string update_sp_name = "tsp_UpdateIwp";
            string delete_sp_name = "tsp_RemoveIwp";

            string[] insert_columns = { "FiwpID", "ExternalScheduleId", "ProjectScheduleID", "FiwpName", "StartDate", "FinishDate", "TotalManhours", "PackageTypeLUID", 
                                            "CrewMembersAssigned", "LeaderId", "WorkHours", "Description", "DocEstablishedLUID", "P6ActivityObjectID", "UpdatedBy" };
            string[] update_columns = { "FiwpID", "ExternalScheduleId", "ProjectScheduleID", "FiwpName", "StartDate", "FinishDate", "TotalManhours", "PackageTypeLUID", 
                                            "CrewMembersAssigned", "LeaderId", "WorkHours", "Description", "DocEstablishedLUID", "P6ActivityObjectID", "UpdatedBy" };
            string[] delete_columns = { "FiwpID" };

            //List<FiwphistoryDTO> fiwpHistories = FiwphistoryDAL.CreateFiwpHistory(fiwp);
            ds.Tables[0].TableName = TableName.FIWP;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.FIWP, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.FIWP;
            fiwps = (List<FiwpDTO>)DTOHelper.DeserializeDTOList(fiwps.GetType(), ds);

            // Return the data transfer object.
            return fiwps;
        }

        /// <summary>
        /// GetSignleProjscheduleByID
        /// </summary>
        /// <param name="scheduledWorkItemId"></param>
        /// <returns></returns>
        public ProjectscheduleDTO GetSignleProjscheduleByID(int scheduledWorkItemId)
        {
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ScheduledWorkItemId", scheduledWorkItemId)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetScheduledWorkItem", parameters);
            ProjectscheduleDTO result = DTOHelper.DataTableToSingleDTO<ProjectscheduleDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<FiwpmaterialDTO> GetFiwpMaterialByFIWP(int iwpId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@iwpId", iwpId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwpMaterialByIwp", parameters);  //sp_get_fiwpmaterial_by_fiwp
            List<FiwpmaterialDTO> result = DTOHelper.DataTableToListDTO<FiwpmaterialDTO>(ds);
            return result;
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        //public ProgressAssignment UpdateProjectScheduleAssignment(string dbname, ProgressAssignment list, string userName, string password)
        public ProgressAssignment UpdateProjectScheduleAssignment(ProgressAssignment list, bool isUsingMpp)
        {
            if (isUsingMpp)
            {
                // project id, so get last project loaded in projectschedule.
                //MppHelper.Instance.GetProjectInstanceByLastLoaded();
            }

            //This method is not able to do transcation process due to P6 updates 
            //First is updating all progresses for schedule assignments
            list.progress = UpdateProgressAssignment(list.progress);

            ////Create or Update ResourceAssingment for the project schedule 
            ////Return projectschedule after synchronizeing wiht P6 activity information
            //list.schedule = UpdateProjectSchedueAndP6(dbname, list.schedule, userName, password);

            //Update to projectschedule
            List<ProjectscheduleDTO> schedules = new List<ProjectscheduleDTO>();
            schedules.Add(list.schedule);
            schedules = SaveProjschedule(schedules);
            if (schedules.Count > 0)
                list.schedule = schedules[0];

            //#region "Sync ProjectSchedule Resource to P6"

            //SyncScheduleResourceToP6ByProjectSchedule(dbname, list.schedule.ProjectScheduleID, list.schedule.ProjectID, list.schedule.ModuleID, userName, password);

            //#endregion "Sync ProjectSchedule Resource to P6"

            return list;

        }

        private List<MTODTO> UpdateProgressAssignment(List<MTODTO> progress)
        {
            if (progress.Count() > 0)
            {
                string connStr = ConnStrHelper.getDbConnString();

                DataSet ds = new DataSet();

                ds = DTOHelper.SerializeDTOList(progress.GetType(), progress);

                string insert_sp_name = "tsp_UpdateComponentProgressAssignment";  //sp_update_progress_assignment
                string update_sp_name = "tsp_UpdateComponentProgressAssignment";  //sp_update_progress_assignment
                string delete_sp_name = "tsp_RemoveComponentProgress";  //sp_delete_progress
                                
                string[] insert_columns = { "ProgressID", "ProjectScheduleID", "FIWPID", "SIWPID", "UpdatedBy" }; 
                string[] update_columns = { "ProgressID", "ProjectScheduleID", "FIWPID", "SIWPID", "UpdatedBy" };                
                string[] delete_columns = { "ProgressID" };

                ds.Tables[0].TableName = TableName.Progress;
                ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.Progress, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

                ds.Tables[0].TableName = DTOName.ProgressMTO;
                progress = (List<MTODTO>)DTOHelper.DeserializeDTOList(progress.GetType(), ds);
            }
            // Return the data transfer object.
            return progress;
        }
        
        public ProjectscheduleDTO UpdateProjectSchedulePeriod(ProjectscheduleDTO schedule, decimal totalManhours, string userName, string password)
        {               
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                string[] P6LoginInfo = (new P6Manager()).GetP6Login();
                userName = P6LoginInfo[0];
                password = P6LoginInfo[1];
            }

            if (schedule != null)
            {
                List<ProjectscheduleDTO> schedules = new List<ProjectscheduleDTO>();                

                int estimatedWorker = 0;
                decimal workHours = 0;
                DateTime startDt = schedule.StartDate;
                DateTime endDt = schedule.FinishDate;                

                if (startDt != null && endDt != null)
                {
                    TimeSpan periodTs = endDt - startDt;

                    if (schedule.P6CalendarID > 0)
                    {
                        //Check P6Calendar
                        List<int> calendarIds = new List<int>();
                        calendarIds.Add(schedule.P6CalendarID);
                        (new TrueTask.P6Manager()).UpdateP6Calendar(calendarIds, userName, password, schedule.UpdatedBy);

                        //Calculate a workHours                
                        List<StandardworkweekDTO> standards = GetStandardWorkWeekByExternalCalendar(schedule.P6CalendarID);
                        List<HolidayorexceptionDTO> holiExs = GetHolidayOrExceptionByDateExternalCalendar(startDt, endDt, schedule.P6CalendarID);

                        for (int i = 0; i <= periodTs.Days; i++)
                        {
                            List<HolidayorexceptionDTO> tempHoliExs = new List<HolidayorexceptionDTO>();
                            if (holiExs != null && holiExs.Count > 0)
                                tempHoliExs = holiExs.Where(x => x.HldyExpDate == startDt.AddDays(i)).ToList();

                            if (tempHoliExs != null && tempHoliExs.Count > 0)
                            {
                                workHours += tempHoliExs[0].WorkHours;
                            }
                            else
                            {
                                List<StandardworkweekDTO> tempStandards = new List<StandardworkweekDTO>();
                                if (standards != null && standards.Count > 0)
                                    tempStandards = standards.Where(y => y.DayOfWeek == (int)startDt.AddDays(i).DayOfWeek).ToList();

                                if (tempStandards != null && tempStandards.Count > 0)
                                    workHours += tempStandards[0].WorkHours;
                            }
                        }                        
                    }
                    else
                    { 
                        //temp
                        int holiDays = (periodTs.Days / 7) * 2;
                        workHours = ((periodTs.Days + 1) - holiDays) * 10;
                    }

                    if (workHours > 0)
                        estimatedWorker = Convert.ToInt32(Math.Ceiling(totalManhours / workHours));
                }

                schedule.TotalWorkingHours = totalManhours;
                schedule.CrewMembersAssigned = estimatedWorker;
                schedules.Add(schedule);
                
                //Update to projectschedule 
                schedules = SaveProjschedule(schedules);
                if (schedules.Count > 0)
                    schedule = schedules[0];
            }
            return schedule;
        }

        public FiwpDTO UpdateIwpPeriod(FiwpDTO iwp, decimal totalManhours, string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                string[] P6LoginInfo = (new P6Manager()).GetP6Login();
                userName = P6LoginInfo[0];
                password = P6LoginInfo[1];
            }

            //TrueTask App에서 넘어오는 FiwpDTO가 완전한 형태가 아니기때문에 조회 후 update한다.
            List<FiwpDTO> iwps = new List<FiwpDTO>();

            FiwpDTO fiwp = GetSingleFiwpByID(iwp.FiwpID);
            fiwp.StartDate = iwp.StartDate;
            fiwp.FinishDate = iwp.FinishDate;
            fiwp.UpdatedBy = iwp.UpdatedBy;
            fiwp.DTOStatus = (int)RowStatusNo.Update;

            iwp = UpdateIwpPeriod_InnerCode(fiwp, totalManhours, userName, password);

            #region "Update FIWP info to P6"
            //switch (fiwp.DTOStatus)
            //{
                //case (int)RowStatus.New:
                //    DoProcessFIWPWBS(dbname, list.fiwp, userName, password);
                //    break;
                //case (int)RowStatus.Update:
            if (iwp.CrewMembersAssigned > 0)
                iwp.P6RemainingDuration = (decimal)Math.Round(iwp.TotalManhours / iwp.CrewMembersAssigned, 4);
            DoUpdateFIWPToP6(iwp, userName, password);
                    //break;
                //case (int)RowStatus.Delete:
                //    DoRemoveFIWPFromP6(dbname, list.fiwp, userName, password);
                //    break;
            //}
            #endregion

            iwps.Add(iwp);
            //Update to Iwp 
            iwps = SaveIwp(iwps);
            if (iwps.Count > 0)
                iwp = iwps[0];

            return iwp;
        }

        private FiwpDTO UpdateIwpPeriod_InnerCode(FiwpDTO iwp, decimal totalManhours, string userName, string password)
        {
            if (iwp != null)
            {                   
                int estimatedWorker = 0;
                decimal workHours = 0;
                DateTime startDt = iwp.StartDate;
                DateTime endDt = iwp.FinishDate;
                //string updatedBy = iwp.UpdatedBy;

                if (startDt != null && endDt != null)
                {
                    TimeSpan periodTs = endDt - startDt;

                    if (iwp.P6CalendarID > 0)
                    {
                        //Check P6Calendar
                        List<int> calendarIds = new List<int>();
                        calendarIds.Add(iwp.P6CalendarID);
                        (new TrueTask.P6Manager()).UpdateP6Calendar(calendarIds, userName, password, iwp.UpdatedBy);

                        //Calculate a workHours                
                        List<StandardworkweekDTO> standards = GetStandardWorkWeekByExternalCalendar(iwp.P6CalendarID);
                        List<HolidayorexceptionDTO> holiExs = GetHolidayOrExceptionByDateExternalCalendar(startDt, endDt, iwp.P6CalendarID);

                        for (int i = 0; i <= periodTs.Days; i++)
                        {
                            List<HolidayorexceptionDTO> tempHoliExs = new List<HolidayorexceptionDTO>();                            
                            if (holiExs != null && holiExs.Count > 0)
                                tempHoliExs = holiExs.Where(x => x.HldyExpDate == startDt.AddDays(i)).ToList();

                            if (tempHoliExs != null && tempHoliExs.Count > 0)
                            {
                                workHours += tempHoliExs[0].WorkHours;
                            }
                            else
                            {
                                List<StandardworkweekDTO> tempStandards = new List<StandardworkweekDTO>();
                                if (standards != null && standards.Count > 0)
                                    tempStandards = standards.Where(y => y.DayOfWeek == (int)startDt.AddDays(i).DayOfWeek).ToList();

                                if (tempStandards != null && tempStandards.Count > 0)
                                    workHours += tempStandards[0].WorkHours;
                            }
                        }
                    }
                    else
                    {
                        //temp
                        int holiDays = (periodTs.Days / 7) * 2;
                        workHours = ((periodTs.Days + 1) - holiDays) * 10;
                    }

                    if (workHours > 0)
                        estimatedWorker = Convert.ToInt32(Math.Ceiling(totalManhours / workHours));
                }
                                
                iwp.TotalManhours = totalManhours;
                iwp.CrewMembersAssigned = estimatedWorker;                
            }
            return iwp;
        }

        public List<StandardworkweekDTO> GetStandardWorkWeekByExternalCalendar(int externalCalendarId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ExternalCalendarId", externalCalendarId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetStandardWorkWeekByExternalCalendar", parameters); 
            List<StandardworkweekDTO> result = DTOHelper.DataTableToListDTO<StandardworkweekDTO>(ds);
            return result;
        }

        public List<HolidayorexceptionDTO> GetHolidayOrExceptionByDateExternalCalendar(DateTime startDate, DateTime endDate, int externalCalendarId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@StartDate", startDate),
                    new SqlParameter("@EndDate", endDate),
                    new SqlParameter("@ExternalCalendarId", externalCalendarId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetHolidayOrExceptionByDateExternalCalendar", parameters);
            List<HolidayorexceptionDTO> result = DTOHelper.DataTableToListDTO<HolidayorexceptionDTO>(ds);
            return result;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<ProjectscheduleDTO> GetScheduledWorkItemByProjectID(int projectId, string disciplineCode, int includeWBS)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode),
                    new SqlParameter("@includedWBS", includeWBS)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetAllScheduledWorkItemByProject", parameters);  //sp_get_allprojectschedule_by_projectId
            List<ProjectscheduleDTO> result = DTOHelper.DataTableToListDTO<ProjectscheduleDTO>(ds);
            return result;
        }

        //GetScheduledWorkItemByProjectID 에서 같이 처리함
        //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        //public List<ProjectscheduleDTO> GetProjectScheduleByProjectIDWithWBS(int projectId, string disciplineCode)
        //{
        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@projectId", projectId),
        //            new SqlParameter("@disciplineCode", disciplineCode),
        //            new SqlParameter("@includedWBS", 1)
        //        };

        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetAllScheduledWorkItemByProject", parameters);  //sp_get_allprojectschedule_by_projectId
        //    List<ProjectscheduleDTO> result = DTOHelper.DataTableToListDTO<ProjectscheduleDTO>(ds);
        //    return result;
        //}


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public ProgressAssignment UpdateIWPComponentprogressAssignment(ProgressAssignment list, bool isUsingMpp)
        {
            //string userName = string.Empty;
            //string password = string.Empty;

            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            //{
            //    string[] P6LoginInfo = (new P6Manager()).GetP6Login();
            //    userName = P6LoginInfo[0];
            //    password = P6LoginInfo[1];
            //}

            if (isUsingMpp)
            {
                // project id, so get last project loaded in projectschedule.
                //MppHelper.Instance.GetProjectInstance(list.fiwp.ProjectID);
            }

            List<FiwpmaterialDTO> fiwpMaterial_new = new List<FiwpmaterialDTO>();
            List<FiwpmaterialDTO> fiwpMaterial_old = new List<FiwpmaterialDTO>();

            //first update all progresses.
            if (list.progress != null && list.progress.Count > 0 && list.fiwp != null)
            {
                //bool dochange = false;
                string updatedBy = list.progress[0].UpdatedBy;

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {   
                        list.progress = UpdateProgressAssignment(list.progress);

                        //현재시점에서는 Device에서 ScheduleLineItem의 공사기간을 넘지못하도록 막고있기때문에 쓰이지 않는코드 - 2014.04.12         
                        /*
                        DoCheckProjectScheduleConstrain(dbname, list.fiwp, userName, password);
                        if (!string.IsNullOrEmpty(list.fiwp.ExceptionMessage))
                        {
                            if (list.fiwp.ExceptionMessage.Contains("Update ProjectSchedule"))
                                dochange = true;
                            else if (!string.IsNullOrEmpty(list.fiwp.ExceptionMessage))
                                throw new Exception(list.fiwp.ExceptionMessage);
                        }*/
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        if (scope != null) scope.Dispose();
                        throw new Exception("Fail to update ProgressAssignment", ex);
                    }
                }
                
                if (list.fiwp != null)
                {
                    #region "Update FIWP info to P6"
                    //Component를 Assign함으로써 TotalManhours와 EstimatedWorker가 변경된다.
                    //이 로직을 구현하기 위해 당 method리턴 후에
                    //Device에서 다른 UpdateIwpPeriod를 호출하고 있다. 
                    //추후 당method에 삽입하는 형태로 통합이 필요하다. - 2014.04.12

                    //switch (list.fiwp.DTOStatus)
                    //{                           
                    //    //case (int)RowStatus.New:
                    //    //    DoProcessFIWPWBS(dbname, list.fiwp, userName, password);
                    //    //    break;
                    //    case (int)RowStatus.Update:
                    //        DoUpdateFIWPToP6(list.fiwp, userName, password);
                    //        break;
                    //    //case (int)RowStatus.Delete:
                    //    //    DoRemoveFIWPFromP6(dbname, list.fiwp, userName, password);
                    //    //    break;
                    //}
                                        
                    //List<FiwpDTO> fiwps = new List<FiwpDTO>();
                    //fiwps.Add(list.fiwp);
                    //fiwps = SaveIwp(fiwps);

                    //if (fiwps != null && fiwps.Count > 0)
                    //    list.fiwp = fiwps[0];

                    //현재시점에서는 Device에서 ScheduleLineItem의 공사기간을 넘지못하도록 막고있기때문에 쓰이지 않는코드 - 2014.04.12    
                    //if (dochange)
                    //    UpdateFIWPOutcomeProjectScheduleAndP6(dbname, list.fiwp, userName, password);

                #endregion "Update FIWP info to P6"

                    #region "Insert/Update FIWP Material List"
                    try
                    {
                        List<FiwpmaterialDTO> fiwpMateriallist = new List<FiwpmaterialDTO>();
                        List<FiwpmaterialDTO> tempList = new List<FiwpmaterialDTO>();

                        tempList = GetFiwpMaterialByFIWP(list.fiwp.FiwpID, list.fiwp.ProjectID, list.fiwp.DisciplineCode);
                        if (tempList != null && tempList.Count() > 0)
                            fiwpMaterial_old = tempList;

                        tempList = GetMaterialForFiwpMaterialUpdating(list.fiwp.FiwpID, list.fiwp.ProjectID, list.fiwp.DisciplineCode);
                        if (tempList != null && tempList.Count() > 0)
                            fiwpMaterial_new = tempList;

                        foreach (FiwpmaterialDTO newRow in fiwpMaterial_new)
                        {
                            FiwpmaterialDTO fiwpmaterial = new FiwpmaterialDTO();
                            var result = fiwpMaterial_old.Where(x => newRow.EstMHLibID == x.EstMHLibID).FirstOrDefault();

                            if (result != null)
                            {
                                fiwpmaterial = result;
                                fiwpmaterial.Qty = newRow.Qty;
                                fiwpmaterial.UOMLUID = newRow.UOMLUID;
                                fiwpmaterial.DTOStatus = (int)RowStatusNo.Update;
                                fiwpmaterial.UpdatedBy = updatedBy;
                            }
                            else
                            {
                                fiwpmaterial = newRow;
                                fiwpmaterial.DTOStatus = (int)RowStatusNo.New;
                                fiwpmaterial.UpdatedBy = updatedBy;
                            }

                            fiwpmaterial.FIWPID = list.fiwp.FiwpID;

                            fiwpMateriallist.Add(fiwpmaterial);
                        }

                        if (fiwpMateriallist.Count > 0)
                            fiwpMateriallist = (new TrueTask.Assemble()).SaveFiwpMaterial(fiwpMateriallist); //SaveFiwpMaterial(fiwpMateriallist);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion "Insert/Update FIWP Material List"

                    #region useless
                    //#region "Insert/Update FIWP QAQC List"
                    //try
                    //{
                    //    List<FiwpqaqcDTO> fiwpqaqcs = new List<FiwpqaqcDTO>();
                    //    #region "Old"
                    //    /*
                    //    List<MTODTO> mtoList = (new DALC.ProgressDAL()).GetProgressByCwpFiwp(dbname, list.fiwp.ProjectID, list.fiwp.ModuleID, list.fiwp.CWPID, list.fiwp.FiwpID);
                    //    List<LibqaqcformtemplateDTO> libqaqcList = (new DALC.LibqaqcformtemplateDAL()).GetLibqaqcformtemplateByProject(dbname, list.fiwp.ProjectID);
                    //    List<QaqcformtemplateDTO> qaqctemplateList = (new DALC.QaqcformtemplateDAL()).GetQaqcformtemplateByFormtypeNameProject(dbname, QAQCFormType.IWP, string.Empty, list.fiwp.ProjectID);
                    //    List<FiwpqaqcDTO> fiwpqaqcList = (new DALC.FiwpqaqcDAL()).GetFiwpqaqcByFIWP(dbname, list.fiwp.FiwpID);

                    //    foreach (MTODTO progress in list.progress)
                    //    {
                    //        List<LibqaqcformtemplateDTO> libqaqcs = new List<LibqaqcformtemplateDTO>();
                    //        MTODTO mto = mtoList.Where(x => x.ProgressID == progress.ProgressID).FirstOrDefault();

                    //        libqaqcs = libqaqcList.Where(x => x.LibID == mto.LibEstManhrsID && x.TaskCategoryID == mto.TaskCategoryID).ToList();

                    //        foreach (LibqaqcformtemplateDTO libqaqc in libqaqcs)
                    //        {
                    //            int Qty = 1;
                    //            QaqcformtemplateDTO qaqctemplate = qaqctemplateList.Where(x => x.QAQCFormTemplateID == libqaqc.QAQCFormTemplateID).FirstOrDefault();
                    //            List<FiwpqaqcDTO> oldfiwpqaqcs = fiwpqaqcList.Where(x => x.QAQCFormTemplateID == libqaqc.QAQCFormTemplateID).ToList();

                    //            if (qaqctemplate.QAQCTypeLUID == QAQCType.Tag)
                    //            {
                    //                var mtos = mtoList.Where(x => x.LibEstManhrsID == libqaqc.LibID && x.TaskCategoryID == libqaqc.TaskCategoryID).GroupBy(y => y.EngTagNumber).Select(z => z.Key).ToList();
                    //                Qty = mtos.Count();
                    //            }

                    //            if (oldfiwpqaqcs.Count() > 0)
                    //            {
                    //                oldfiwpqaqcs.ForEach(x => { x.Qty = Qty; x.UpdatedBy = list.fiwp.UpdatedBy; x.UpdatedDate = DateTime.Now; x.DTOStatus = (int)RowStatus.Update; });

                    //                fiwpqaqcs.AddRange(oldfiwpqaqcs);
                    //            }
                    //            else
                    //            {
                    //                FiwpqaqcDTO newfiwpqaqc = new FiwpqaqcDTO();
                    //                newfiwpqaqc.FIWPID = list.fiwp.FiwpID;
                    //                newfiwpqaqc.CWPID = list.fiwp.CWPID;
                    //                newfiwpqaqc.ProjectID = list.fiwp.ProjectID;
                    //                newfiwpqaqc.ModuleID = list.fiwp.ModuleID;
                    //                newfiwpqaqc.Qty = Qty;
                    //                newfiwpqaqc.QAQCFormTemplateID = libqaqc.QAQCFormTemplateID;
                    //                newfiwpqaqc.QAQCFormTypeLUID = QAQCFormType.IWP;
                    //                newfiwpqaqc.UpdatedBy = list.fiwp.UpdatedBy;
                    //                newfiwpqaqc.UpdatedDate = DateTime.Now;
                    //                newfiwpqaqc.DTOStatus = (int)RowStatus.New;

                    //                fiwpqaqcs.Add(newfiwpqaqc);
                    //            }
                    //        }
                    //    }
                    //    */
                    //    #endregion
                    //    fiwpqaqcs = ProjectWriter.CreateFiwpQaqc(dbname, list.fiwp, list.progress);// (new Element.Reveal.Server.DALC.FiwpqaqcDAL()).SaveFiwpqaqc(dbname, fiwpqaqcs, RowStatus.None);
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw ex;
                    //}

                    //#endregion "Insert/Update FIWP QAQC List"

                    //#region "Sync FIWP_ProjectSchedule Resource to P6"

                    //SyncScheduleFIWPResourceToP6(dbname, list.fiwp.FiwpID, list.fiwp.ProjectID, list.fiwp.ModuleID, userName, password);

                    //#endregion "Sync FIWP_ProjectSchedule Resource to P6"

                    #endregion
                }
            }

            return list;

        }

        private void DoProcessFIWPWBS(FiwpDTO fiwp, string userName, string password)
        {
            int fipwWBSId = 0;
            P6ActivityDTO pWbs = (new P6Manager()).ReadWBSFilter(string.Format("ParentObjectId={0} and Code='{1}'", fiwp.P6ParentObjectID, "FIWP"), userName, password, fiwp.ProjectID);
            
            if (pWbs == null)
            {                
                //create fiwp Work Breakdown Structure to P6.
                P6WS.WBSService.WBS newWbs = new P6WS.WBSService.WBS();
                newWbs.ProjectObjectId = fiwp.P6ActivityObjectID;
                newWbs.ProjectObjectIdSpecified = true;
                newWbs.Name = "WBSFIWP";
                newWbs.ParentObjectId = fiwp.P6ParentObjectID; //  for p6
                newWbs.ParentObjectIdSpecified = true;
                newWbs.Code = "FIWP";
                newWbs.StartDate = Convert.ToDateTime(fiwp.StartDate.ToLongDateString() + " 07:00:00 AM");  //fiwp.StartDate;
                newWbs.StartDateSpecified = true;
                newWbs.FinishDate = Convert.ToDateTime(fiwp.FinishDate.ToLongDateString() + " 05:00:00 PM");  //fiwp.FinishDate;
                newWbs.FinishDateSpecified = true;
                int[] ids = (new P6Manager()).CreateWBS(newWbs, userName, password);
                fipwWBSId = ids[0];               
            }
            else
                fipwWBSId = pWbs.P6ActivityObjectID;

            //create P6 activity.
            P6WS.ActivityService.Activity act = new P6WS.ActivityService.Activity();
            act.Name = fiwp.FiwpName;
            act.StartDate = Convert.ToDateTime(fiwp.StartDate.ToLongDateString() + " 07:00:00 AM");  //fiwp.StartDate;
            act.FinishDate = Convert.ToDateTime(fiwp.FinishDate.ToLongDateString() + " 05:00:00 PM");  //fiwp.FinishDate;
            act.ProjectObjectId = fiwp.P6ParentObjectID;
            act.WBSObjectId = fipwWBSId;
            if (fiwp.DTOStatus == (int)RowStatusNo.Update) act.CalendarObjectId = fiwp.P6CalendarID;
            // fiwpAct should get calendar object id correctly.
            P6WS.ActivityService.Activity[] fiwpAct = (new P6Manager()).CreateActivity(act, userName, password);

            if (fiwpAct != null && fiwpAct.Count() > 0)
            {
                fiwp.P6ParentObjectID = (int)fiwpAct[0].WBSObjectId;
                fiwp.P6ActivityID = fiwpAct[0].Id;
                fiwp.P6ActivityObjectID = fiwpAct[0].ObjectId;
                fiwp.StartDate = fiwpAct[0].StartDate;
                fiwp.FinishDate = fiwpAct[0].FinishDate;
                fiwp.P6CalendarID = fiwpAct[0].CalendarObjectId;
                if (!CheckAndUpdateP6Calender(fiwp.P6CalendarID, userName, password, fiwp.UpdatedBy))
                    throw new Exception("Couldn't register new calendar");
                fiwp.WorkHours = 0m;
                List<StandardworkweekDTO> standardworkweek = GetStandardWorkWeekByExternalCalendar(fiwp.P6CalendarID);
                if (standardworkweek != null && standardworkweek.Count > 0)
                    fiwp.WorkHours = Convert.ToDecimal(standardworkweek.Average(x => x.WorkHours));
                //fiwp.P6RemainingDuration = (decimal)fiwpAct[0].RemainingDuration;
            }
            else
            {
                throw new Exception("Fail to create an activity for the Iwp.");
            }
            #region old code
            /*
            int fipwWBSId = 0;
            P6ActivityDTO pWbs;

            P6Manager manager = GetP6Manager();
            if (!isUsingMpp)
            {
                pWbs = manager.ReadWBSFilter(string.Format("ParentObjectId={0} and Code='{1}'", fiwp.P6ParentObjectID, "FIWP"), userName, password, fiwp.ProjectID);
            }
            else
            {
                pWbs = manager.ReadWBSFilter(string.Format("ParentObjectId={0} and Code='{1}'", fiwp.P6ActivityObjectID, "FIWP"), userName, password, fiwp.ProjectID);
            }


            if (pWbs == null)
            {
                if (!isUsingMpp)
                {
                    //create fiwp Work Breakdown Structure to P6.
                    P6WS.WBSService.WBS newWbs = new P6WS.WBSService.WBS();
                    newWbs.ProjectObjectId = fiwp.P6ActivityObjectID;
                    newWbs.ProjectObjectIdSpecified = true;
                    newWbs.Name = "WBSFIWP";

                    newWbs.ParentObjectId = fiwp.P6ParentObjectID; //  for p6

                    newWbs.ParentObjectIdSpecified = true;
                    newWbs.Code = "FIWP";
                    newWbs.StartDate = fiwp.StartDate;
                    newWbs.StartDateSpecified = true;
                    newWbs.FinishDate = fiwp.FinishDate;
                    newWbs.FinishDateSpecified = true;
                    int[] ids = (GetP6Manager()).CreateWBS(newWbs, userName, password);
                    fipwWBSId = ids[0];
                }
                else
                {
                    //create fiwp Work Breakdown Structure to P6.
                    P6WS.WBSService.WBS newWbs = new P6WS.WBSService.WBS();
                    newWbs.ProjectObjectId = fiwp.P6ActivityObjectID;
                    newWbs.ProjectObjectIdSpecified = true;
                    newWbs.Name = "WBSFIWP";

                    newWbs.ParentObjectId = fiwp.P6ActivityObjectID; // for mpp

                    newWbs.ParentObjectIdSpecified = true;
                    newWbs.Code = "FIWP";
                    newWbs.StartDate = fiwp.StartDate;
                    newWbs.StartDateSpecified = true;
                    newWbs.FinishDate = fiwp.FinishDate;
                    newWbs.FinishDateSpecified = true;
                    int[] ids = (GetP6Manager()).CreateWBS(newWbs, userName, password);
                    fipwWBSId = ids[0];

                }

            }
            else
                fipwWBSId = pWbs.P6ActivityObjectID;

            //create P6 activity.
            P6WS.ActivityService.Activity act = new P6WS.ActivityService.Activity();
            act.Name = fiwp.FiwpName;
            act.StartDate = fiwp.StartDate;
            act.FinishDate = fiwp.FinishDate;
            act.ProjectObjectId = fiwp.P6ParentObjectID;
            act.WBSObjectId = fipwWBSId;
            if (fiwp.DTOStatus == (int)RowStatus.Update) act.CalendarObjectId = fiwp.P6CalendarID;
            // fiwpAct should get calendar object id correctly.
            P6WS.ActivityService.Activity[] fiwpAct = (GetP6Manager()).CreateActivity(act, userName, password);

            if (fiwpAct.Count() > 0)
            {
                fiwp.P6ParentObjectID = (int)fiwpAct[0].WBSObjectId;
                fiwp.P6ActivityID = fiwpAct[0].Id;
                fiwp.P6ActivityObjectID = fiwpAct[0].ObjectId;
                fiwp.StartDate = fiwpAct[0].StartDate;
                fiwp.FinishDate = fiwpAct[0].FinishDate;
                fiwp.P6CalendarID = fiwpAct[0].CalendarObjectId;
                if (!CheckAndUpdateP6Calender(dbname, fiwp.P6CalendarID, userName, password))
                    throw new Exception("Couldn't register new calendar");

                fiwp.WorkHours = (new Reveal.Server.DALC.CalendarDAL()).GetStandardWorkhourByP6CalandarID(dbname, fiwp.P6CalendarID);
                fiwp.P6RemainingDuration = (decimal)fiwpAct[0].RemainingDuration;
            }
            else
            {
                throw new Exception("Fail to create an activity for a fiwp.");
            }*/
            #endregion
        }

        private void DoUpdateFIWPToP6(FiwpDTO fiwp, string userName, string password)
        {
            #region "update P6"
            P6WS.ActivityService.Activity[] fiwpAct = (new P6Manager()).ReadActivities(fiwp.P6ActivityObjectID, userName, password);
            if (fiwpAct != null && fiwpAct.Count() > 0)
            {

                fiwpAct[0].StartDate = Convert.ToDateTime(fiwp.StartDate.ToLongDateString() + " 07:00:00 AM");  //fiwp.StartDate;
                fiwpAct[0].StartDateSpecified = true;
                fiwpAct[0].RemainingDuration = (double)fiwp.P6RemainingDuration;
                fiwpAct[0].RemainingDurationSpecified = true;
                //fiwpAct[0].AtCompletionDuration = (double)fiwp.P6RemainingDuration;
                //fiwpAct[0].AtCompletionDurationSpecified = true;
                fiwpAct[0].Name = fiwp.FiwpName;
                fiwpAct[0].FinishDate = Convert.ToDateTime(fiwp.FinishDate.ToLongDateString() + " 05:00:00 PM");  //fiwp.FinishDate;
                fiwpAct[0].FinishDateSpecified = true;                                

                fiwpAct = (new P6Manager()).UpdateActivities(fiwpAct, userName, password);

                if (fiwpAct != null && fiwpAct.Count() > 0)
                {
                    //update fiwp
                    fiwp.DTOStatus = (int)RowStatusNo.Update;
                    fiwp.StartDate = fiwpAct[0].StartDate;
                    fiwp.FinishDate = fiwpAct[0].FinishDate;
                    //fiwp.P6RemainingDuration = (decimal)fiwpAct[0].RemainingDuration;
                }
            }
            #endregion "update P6"
        }

        private void DoRemoveFIWPFromP6(FiwpDTO fiwp, string userName, string password)
        {
            if (fiwp.TotalManhours == 0)
            {
                P6WS.ActivityService.Activity[] fiwpAct = (new P6Manager()).ReadActivities(fiwp.P6ActivityObjectID, userName, password);
                if (fiwpAct != null && fiwpAct.Count() > 0)
                {
                    int[] ids = new int[1];
                    ids[0] = (int)fiwpAct[0].ObjectId;
                    bool results = (new P6Manager()).DeleteActivities(ids, userName, password);

                    if (!results)
                        throw new Exception("Not able to delete IWP from P6.");
                }
            }
        }

        private bool CheckAndUpdateP6Calender(int p6calenderId, string userName, string password, string updatedBy)
        {
            bool retValue = false;
            try
            {
                (new P6Manager()).UpdateP6Calendar(new List<int>() { p6calenderId }, userName, password, updatedBy);
                retValue = true;
            }
            catch (Exception ex) { }

            return retValue;
        }

        //public List<ProjectscheduleDTO> SaveProjschedule(List<ProjectscheduleDTO> projschedule)
        public List<ProjectscheduleDTO> SaveProjschedule(List<ProjectscheduleDTO> projschedule)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(projschedule.GetType(), projschedule);

            string insert_sp_name = "tsp_AddScheduledWorkItem";  //sp_insert_projectschedule
            string update_sp_name = "tsp_UpdateScheduledWorkItem";  //sp_update_projectschedule
            string delete_sp_name = "tsp_RemoveScheduledWorkItem";  //sp_delete_projectschedule

            string[] insert_columns = { "ProjectScheduleID", "ExternalScheduleId", "CWPID", "ProjectScheduleName", "StartDate", "FinishDate", "CrewMembersAssigned", "TotalWorkingHours", "LeaderId", "DisciplineCode", "CreatedBy" };
            string[] update_columns = { "ProjectScheduleID", "ExternalScheduleId", "CWPID", "ProjectScheduleName", "StartDate", "FinishDate", "CrewMembersAssigned", "TotalWorkingHours", "LeaderId", "DisciplineCode", "UpdatedBy" };
            string[] delete_columns = { "ProjectScheduleID" };

            ds.Tables[0].TableName = TableName.Projectschedule;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.Projectschedule, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.Projectschedule;
            projschedule = (List<ProjectscheduleDTO>)DTOHelper.DeserializeDTOList(projschedule.GetType(), ds);

            // Return the data transfer object.
            return projschedule;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public List<FiwpmaterialDTO> GetMaterialForFiwpMaterialUpdating(int iwpId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@iwpId", iwpId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetMaterialForIwpmaterialUpdating", parameters);  //sp_get_material_for_fiwpmaterial_updating
            List<FiwpmaterialDTO> result = DTOHelper.DataTableToListDTO<FiwpmaterialDTO>(ds);
            return result;
        }

        public List<FiwpmaterialDTO> SaveFiwpMaterial(List<FiwpmaterialDTO> fiwpmaterials)
        {
            List<FiwpmaterialDTO> fiwpmaterialsInsert = new List<FiwpmaterialDTO>();
            List<FiwpmaterialDTO> fiwpmaterialsUpdate = new List<FiwpmaterialDTO>();
            List<FiwpmaterialDTO> fiwpmaterialsDelete = new List<FiwpmaterialDTO>();

            try
            {
                //calculate Added Qty
                //fiwpmaterials.ForEach(x => x.QtyAdd = (x.QtySum == null ? 0 : x.QtySum) - (x.Qty == null ? 0 : x.Qty));

                fiwpmaterialsInsert = fiwpmaterials.Where(x => x.DTOStatus == (int)RowStatus.New).ToList();
                fiwpmaterialsUpdate = fiwpmaterials.Where(x => x.DTOStatus == (int)RowStatus.Update).ToList();
                fiwpmaterialsDelete = fiwpmaterials.Where(x => x.DTOStatus == (int)RowStatus.Delete).ToList();

                fiwpmaterials.Clear();                

                if (fiwpmaterialsInsert != null && fiwpmaterialsInsert.Count() > 0)
                    fiwpmaterials.AddRange((new Assemble()).SaveFiwpMaterial(fiwpmaterialsInsert));
                if (fiwpmaterialsUpdate != null && fiwpmaterialsUpdate.Count() > 0)
                    fiwpmaterials.AddRange((new Assemble()).SaveFiwpMaterial(fiwpmaterialsUpdate));
                if (fiwpmaterialsDelete != null && fiwpmaterialsDelete.Count() > 0)
                    fiwpmaterials.AddRange((new Assemble()).SaveFiwpMaterial(fiwpmaterialsDelete));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fiwpmaterials;
        }

        // Assemble.cs에서 처리
        //public List<FiwpmaterialDTO> SaveIwpMaterialTable(List<FiwpmaterialDTO> fiwpmaterial)
        //{
        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    DataSet ds = new DataSet();

        //    ds = DTOHelper.SerializeDTOList(fiwpmaterial.GetType(), fiwpmaterial);

        //    string insert_sp_name = "sp_insert_fiwpmaterial";
        //    string update_sp_name = "sp_update_fiwpmaterial";
        //    string delete_sp_name = "sp_delete_fiwpmaterial";


        //    string[] insert_columns = {"FIWPMaterialID","FIWPID","MaterialCategoryID","MaterialLibID","EstMHLibID","EngTagNumber","PartNo",
        //                                "UOMLUID","Qty","QtyAdd","Description","PONo","RequisitionNo","VendorLUID","PromisedDeliveryDate","RevisedDeliveryDate",
        //                                "DelieveryDate","ETADate","ROSDate","LocationLUID","MaterialStatusLUID","RowTagging","ShelfTagging",
        //                                "UpdatedBy","UpdatedDate"};
        //    string[] update_columns = {"FIWPMaterialID","FIWPID","MaterialCategoryID","MaterialLibID","EstMHLibID","EngTagNumber","PartNo",
        //                                "UOMLUID","Qty","QtyAdd","Description","PONo","RequisitionNo","VendorLUID","PromisedDeliveryDate","RevisedDeliveryDate",
        //                                "DelieveryDate","ETADate","ROSDate","LocationLUID","MaterialStatusLUID","RowTagging","ShelfTagging",
        //                                "UpdatedBy","UpdatedDate"};

        //    string[] delete_columns = { "FIWPMaterialID" };

        //    ds.Tables[0].TableName = TableName.FiwpMaterial;
        //    ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.FiwpMaterial, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

        //    ds.Tables[0].TableName = DTOName.FiwpMaterial;
        //    fiwpmaterial = (List<FiwpmaterialDTO>)DTOHelper.DeserializeDTOList(fiwpmaterial.GetType(), ds);

        //    // Return the data transfer object.
        //    return fiwpmaterial;
        //}

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public List<ProjectscheduleDTO> SaveProjectSchedule(List<ProjectscheduleDTO> list)
        {
            //for (int i = 0; i < list.Count(); i++)
            //{
            //    if (list[i].DTOStatus == (int)RowStatus.Update)
            //    {
            //        if (!string.IsNullOrEmpty(list[i].P6ActivityID))
            //            list[i] = UpdateProjectSchedueAndP6(dbname, list[i], userName, password);
            //    }
            //}
            return SaveProjschedule(list);

        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public ExtSchedulerDTO UpdateFiwpScheduler(ExtSchedulerDTO extScheduler, bool isUsingMpp)
        {
            
            decimal totalMH = 0m;            
            int crewNumber = 0;
            DateTime startDt = new DateTime(); 
            DateTime endDt = new DateTime(); 

            string userName = string.Empty;
            string password = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    string[] P6LoginInfo = (new P6Manager()).GetP6Login();
                    userName = P6LoginInfo[0];
                    password = P6LoginInfo[1];
                }
    
                FiwpDTO fiwp = GetSingleFiwpByID(extScheduler.Id);                
                //update 실패시 기존 데이터를 리턴하기위해 계산하기 전의 데이터를 보관한다.                
                totalMH = fiwp.TotalManhours;
                crewNumber = fiwp.CrewMembersAssigned;
                startDt = fiwp.StartDate;
                endDt = fiwp.FinishDate;

                //계산
                fiwp.StartDate = extScheduler.StartDate;
                fiwp.FinishDate = extScheduler.EndDate;
                fiwp.UpdatedBy = extScheduler.UpdatedBy;
                fiwp.DTOStatus = (int)RowStatusNo.Update;                
                fiwp = UpdateIwpPeriod_InnerCode(fiwp, extScheduler.TotalMH, userName, password);
                                
                if (isUsingMpp)
                {
                    // project id, so get last project loaded in projectschedule.
                    //MppHelper.Instance.GetProjectInstanceByLastLoaded();
                }

                //bool dochange = false;                
                if (fiwp != null)
                {
                    ProjectscheduleDTO projectSchedule = GetSignleProjscheduleByID(fiwp.ProjectScheduleID);
                    if (projectSchedule != null)
                    {
                        decimal duration = 0m;

                        if (fiwp.CrewMembersAssigned > 0)
                            duration = (decimal)Math.Round(fiwp.TotalManhours / fiwp.CrewMembersAssigned, 4);

                        P6WS.ActivityService.Activity[] fiwpAct = (new P6Manager()).ReadActivities(projectSchedule.P6ActivityObjectID, userName, password);

                        if (fiwpAct != null && fiwpAct.Count() > 0)
                        {
                            //현재시점에서는 Device에서 ScheduleLineItem의 공사기간을 넘지못하도록 막고있기때문에 쓰이지 않는코드 - 2014.04.12                          
                            if (extScheduler.StartDate < fiwpAct[0].StartDate)
                                extScheduler.ExceptionMessage = string.Format("The IWP StartDate, {0:d} can not be eariler than the schedule StartDate {1:d}.", extScheduler.StartDate, fiwpAct[0].StartDate);
                            if (extScheduler.EndDate > fiwpAct[0].FinishDate)
                                extScheduler.ExceptionMessage = string.Format("The IWP FinishDate, {0:d} can not be later than the schedule FinishDate {1:d}.", extScheduler.EndDate, fiwpAct[0].FinishDate);
                                //dochange = true;
                            
                            #region UpdateToP6 & IWP

                            if (!string.IsNullOrEmpty(extScheduler.ExceptionMessage))
                            {
                                extScheduler.StartDate = startDt;
                                extScheduler.EndDate = endDt;
                                extScheduler.TotalMH = totalMH;
                                extScheduler.CrewMembers = crewNumber;
                            }
                            else
                            {
                                fiwpAct = (new P6Manager()).ReadActivities(fiwp.P6ActivityObjectID, userName, password);

                                fiwpAct[0].StartDate = Convert.ToDateTime(fiwp.StartDate.ToLongDateString() + " 07:00:00 AM");  //fiwp.StartDate;
                                fiwpAct[0].StartDateSpecified = true;
                                fiwpAct[0].RemainingDuration = (float)duration;
                                fiwpAct[0].RemainingDurationSpecified = true;
                                fiwpAct[0].FinishDate = Convert.ToDateTime(fiwp.FinishDate.ToLongDateString() + " 05:00:00 PM");  //fiwp.FinishDate;
                                fiwpAct[0].FinishDateSpecified = true;                                
                                fiwpAct = (new P6Manager()).UpdateActivities(fiwpAct, userName, password);

                                fiwpAct[0].StartDate = Convert.ToDateTime(fiwp.StartDate.ToLongDateString() + " 07:00:00 AM");  //fiwp.StartDate;
                                fiwpAct[0].StartDateSpecified = true;
                                fiwpAct[0].RemainingDuration = (float)duration;
                                fiwpAct[0].RemainingDurationSpecified = true;
                                fiwpAct[0].FinishDate = Convert.ToDateTime(fiwp.FinishDate.ToLongDateString() + " 05:00:00 PM");  //fiwp.FinishDate;
                                fiwpAct[0].FinishDateSpecified = true;                                
                                fiwpAct = (new P6Manager()).UpdateActivities(fiwpAct, userName, password);

                                if (fiwpAct != null && fiwpAct.Count() > 0)
                                {
                                    //update fiwp
                                    fiwp.DTOStatus = (int)RowStatusNo.Update;
                                    fiwp.StartDate = extScheduler.StartDate = fiwpAct[0].StartDate;
                                    fiwp.FinishDate = extScheduler.EndDate = fiwpAct[0].FinishDate;
                                    //fiwp.P6RemainingDuration = (fiwpAct[0].RemainingDuration != null) ? Math.Round(Convert.ToDecimal(fiwpAct[0].RemainingDuration), 4) : 0m;                                

                                    List<FiwpDTO> fiwps = new List<FiwpDTO>();
                                    fiwps.Add(fiwp);
                                    SaveIwp(fiwps);
                                }
                                //현재시점에서는 Device에서 ScheduleLineItem의 공사기간을 넘지못하도록 막고있기때문에 쓰이지 않는코드 - 2014.04.12
                                //if (dochange)
                                //    UpdateFIWPOutcomeProjectScheduleAndP6(projectSchedule, fiwp, userName, password);         

                            }

                            #endregion
                        }
                        else
                            extScheduler.ExceptionMessage = "Couldn't update server. Please contact administrator.";

                    }
                }
            }
            catch (Exception ex)
            {
                extScheduler.ExceptionMessage = "Couldn't update server. Please contact administrator.";
            }

            return extScheduler;
        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public FiwpDTO GetSingleFiwpByID(int iwpId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IwpId", iwpId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetIwp", parameters);  //sp_findByID_fiwp
            FiwpDTO result = DTOHelper.DataTableToSingleDTO<FiwpDTO>(ds);
            return result;            
        }

        public decimal GetTotalManhoursByFIWP(int iwpId)
        {
            decimal result = 0m;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IwpId", iwpId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetTotalEstimateManhoursByIwp", parameters);  //sp_get_total_manhoursestimate_by_fiwp
            try
            {
                result = decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch
            {
                result = 0m;
            }

            return result;

        }

        #region "P6 Calendar"
        
        public List<CalendarDTO> GetScheduleCalendarByExternalCalendar(int calendarId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ExternalCalendarId", calendarId)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetScheduleCalendarByExternalCalendar", parameters);  //sp_findByID_calendar
            List<CalendarDTO> result = DTOHelper.DataTableToListDTO<CalendarDTO>(ds);
            return result;
        }

        public List<CalendarDTO> SaveScheduleCalendar(List<CalendarDTO> calendars)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(calendars.GetType(), calendars);

            string insert_sp_name = "tsp_AddScheduleCalendar";  //sp_insert_calendar
            string update_sp_name = "tsp_UpdateScheduleCalendar";  //sp_update_calendar
            string delete_sp_name = "tsp_RemoveScheduleCalendar";  //sp_delete_calendar

            string[] insert_columns = { "CalendarID", "CalendarName", "P6CalendarID", "CreatedBy" };
            string[] update_columns = { "CalendarID", "CalendarName", "P6CalendarID", "UpdatedBy" };
            string[] delete_columns = { "CalendarID" };

            ds.Tables[0].TableName = TableName.Calendar;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.Calendar, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.Calendar;
            calendars = (List<CalendarDTO>)DTOHelper.DeserializeDTOList(calendars.GetType(), ds);

            // Return the data transfer object.
            return calendars;
        }

        public List<HolidayorexceptionDTO> SaveHolidayOrException(List<HolidayorexceptionDTO> holidayorexceptions)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(holidayorexceptions.GetType(), holidayorexceptions);

            string insert_sp_name = "tsp_AddHolidayOrException";  //sp_insert_holidayorexception
            string update_sp_name = "tsp_UpdateHolidayOrException";  //sp_update_holidayorexception
            string delete_sp_name = "tsp_RemoveHolidayOrException";  //sp_delete_holidayorexception

            string[] insert_columns = { "HolidayOrExceptionID", "HldyExpDate", "CalendarID", "WorkHours", "CreatedBy" };
            string[] update_columns = { "HolidayOrExceptionID", "HldyExpDate", "CalendarID", "WorkHours", "UpdatedBy" };
            string[] delete_columns = { "HolidayOrExceptionID" };

            ds.Tables[0].TableName = TableName.HolidayOrException;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.HolidayOrException, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.HolidayOrException;
            holidayorexceptions = (List<HolidayorexceptionDTO>)DTOHelper.DeserializeDTOList(holidayorexceptions.GetType(), ds);

            return holidayorexceptions;
        }

        public List<StandardworkweekDTO> SaveStandardWorkWeek(List<StandardworkweekDTO> Standardworkweeks)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(Standardworkweeks.GetType(), Standardworkweeks);

            string insert_sp_name = "tsp_AddStandardWorkWeek";  //sp_insert_Standardworkweek
            string update_sp_name = "tsp_UpdateStandardWorkWeek";  //sp_update_Standardworkweek
            string delete_sp_name = "tsp_RemoveStandardWorkWeek";  //sp_delete_Standardworkweek

            string[] insert_columns = { "StandardWorkWeekID", "DayOfWeek", "CalendarID", "WorkHours", "CreatedBy" };
            string[] update_columns = { "StandardWorkWeekID", "DayOfWeek", "CalendarID", "WorkHours", "UpdatedBy" };
            string[] delete_columns = { "StandardWorkWeekID" };

            ds.Tables[0].TableName = TableName.StandardWorkweek;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.StandardWorkweek, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.StandardWorkweek;
            Standardworkweeks = (List<StandardworkweekDTO>)DTOHelper.DeserializeDTOList(Standardworkweeks.GetType(), ds);

            return Standardworkweeks;
        }

        public List<WorktimeDTO> SaveWorkTime(List<WorktimeDTO> worktimes)
        {
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = new DataSet();

            ds = DTOHelper.SerializeDTOList(worktimes.GetType(), worktimes);

            string insert_sp_name = "tsp_AddWorkTime";  //sp_insert_worktime
            string update_sp_name = "tsp_UpdateWorkTime";  //sp_update_worktime
            string delete_sp_name = "tsp_RemoveWorkTime";  //sp_delete_worktime

            string[] insert_columns = { "WorkTimeID", "StartTime", "FinishTime", "StandardWorkWeekID", "CreatedBy" };
            string[] update_columns = { "WorkTimeID", "StartTime", "FinishTime", "StandardWorkWeekID", "UpdatedBy" };
            string[] delete_columns = { "WorkTimeID" };

            ds.Tables[0].TableName = TableName.Worktime;
            ds = DALHelper.UpdateDataTableBySqlConnection(connStr, ds, TableName.Worktime, insert_sp_name, insert_columns, update_sp_name, update_columns, delete_sp_name, delete_columns, RowStatus.None);

            ds.Tables[0].TableName = DTOName.Worktime;
            worktimes = (List<WorktimeDTO>)DTOHelper.DeserializeDTOList(worktimes.GetType(), ds);

            return worktimes;
        }

        #endregion
    }

}
