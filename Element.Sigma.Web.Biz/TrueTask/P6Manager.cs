using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Element.Reveal.DataLibrary;
using Element.Shared.Common;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class P6Manager
    {
        //Types.Auth.TypeUserInfo userinfo = Auth.AuthMgr.GetUserInfo();
        protected const String P6WS_SERVICES_AUTHENTICATION_SERVICE = "P6WS.AuthenticationService";
        protected const String P6WS_SERVICES_WBS_SERVICE = "P6WS.WBSService";
        protected const String P6WS_SERVICES_PROJECT_SERVICE = "P6WS.ProjectService";
        protected const String P6WS_SERVICES_ACTIVITY_SERVICE = "P6WS.ActivityService";
        protected const String P6WS_SERVICES_CALENDAR_SERVICE = "P6WS.CalendarService";
        DataTable P6DT = null;
        DataRow[] projectRow = null;

        #region "Login"

        /// <summary>
        /// P6Login
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password"></param>
        /// <returns></returns>
        public System.Net.CookieContainer P6Login(string userName, string password)
        {
            P6WS.AuthenticationService.AuthenticationService authService = new P6WS.AuthenticationService.AuthenticationService();
            authService.CookieContainer = new System.Net.CookieContainer();
            // Add an entry to appSettings.
            authService.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_AUTHENTICATION_SERVICE].ToString();
            P6WS.AuthenticationService.Login loginObj = new P6WS.AuthenticationService.Login();
            loginObj.UserName = userName;
            loginObj.Password = password;
            loginObj.DatabaseInstanceId = 1;
            loginObj.DatabaseInstanceIdSpecified = true;
            loginObj.VerboseFaults = true;
            loginObj.VerboseFaultsSpecified = true;
            P6WS.AuthenticationService.LoginResponse loginReturn = authService.Login(loginObj);

            System.Net.CookieContainer cookie = new System.Net.CookieContainer();

            if (loginReturn.Return)
                cookie = authService.CookieContainer;

            return cookie;
        }

        public string[] GetP6Login()
        {
            //UserName=admin;Password=admin;
            string[] retValue = null;
            string P6LoginInfo = System.Configuration.ConfigurationManager.AppSettings["P6Login"].ToString();

            string[] strP6Login = P6LoginInfo.Split(';');
            //string[] strP6Login =  Helper.P6Login.Split(';');
            if (strP6Login.Length >= 2)
            {
                string[] id = strP6Login[0].Split('=');
                string[] pw = strP6Login[1].Split('=');

                if (id.Length == 2 && pw.Length == 2)
                {
                    retValue = new string[2];
                    retValue[0] = id[1];
                    retValue[1] = pw[1];
                }
            }

            return retValue;
        }

        #endregion

        #region "Calendar"

        public virtual P6WS.CalendarService.Calendar[] ReadCalendars(int CalendarObjectId, string userName, string password)
        {   
            P6WS.CalendarService.Calendar[] calendars = null;
            P6WS.CalendarService.CalendarPortBinding cpb = new P6WS.CalendarService.CalendarPortBinding();
            cpb.CookieContainer = P6Login(userName, password);
            cpb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_CALENDAR_SERVICE].ToString();

            P6WS.CalendarService.ReadCalendars rc = new P6WS.CalendarService.ReadCalendars();
            P6WS.CalendarService.CalendarFieldType[] fieldType = new P6WS.CalendarService.CalendarFieldType[10];
            rc.Field = fieldType;
            rc.Field[0] = P6WS.CalendarService.CalendarFieldType.ObjectId;
            rc.Field[1] = P6WS.CalendarService.CalendarFieldType.CreateDate;
            rc.Field[2] = P6WS.CalendarService.CalendarFieldType.HolidayOrExceptions;
            rc.Field[3] = P6WS.CalendarService.CalendarFieldType.IsBaseline;
            rc.Field[4] = P6WS.CalendarService.CalendarFieldType.IsDefault;
            rc.Field[5] = P6WS.CalendarService.CalendarFieldType.LastUpdateDate;
            rc.Field[6] = P6WS.CalendarService.CalendarFieldType.Name;
            rc.Field[7] = P6WS.CalendarService.CalendarFieldType.ProjectObjectId;
            rc.Field[8] = P6WS.CalendarService.CalendarFieldType.StandardWorkWeek;
            rc.Field[9] = P6WS.CalendarService.CalendarFieldType.Type;

            rc.Filter = string.Format("ObjectId={0}", CalendarObjectId);

            calendars = cpb.ReadCalendars(rc);

            return calendars;
        }

        public virtual void UpdateP6Calendar(List<int> calendars, string userName, string password, string updatedBy)
        {

            P6WS.CalendarService.Calendar[] cals = null;
            try
            {   
                foreach (int calendarobjectId in calendars)
                {
                    //If Calendar object was in the database?
                    List<CalendarDTO> results = (new TrueTask.Build()).GetScheduleCalendarByExternalCalendar(calendarobjectId);

                    if (results == null || results.Count() == 0)
                    {
                        //If Calendar does not exist in the database, read the calender from P6
                        cals = ReadCalendars(calendarobjectId, userName, password);

                        foreach (P6WS.CalendarService.Calendar cal in cals)
                        {
                            List<CalendarDTO> list = new List<CalendarDTO>();
                            CalendarDTO dto = new CalendarDTO();
                            dto.DTOStatus = (int)RowStatusNo.New;
                            dto.CreatedBy = updatedBy;
                            dto.CalendarName = cal.Name;
                            dto.P6CalendarID = cal.ObjectId;
                            
                            list.Add(dto);

                            list = (new TrueTask.Build()).SaveScheduleCalendar(list).ToList();

                            if (cal.HolidayOrExceptions != null)
                            {
                                List<HolidayorexceptionDTO> list_hor = new List<HolidayorexceptionDTO>();
                                foreach (P6WS.CalendarService.CalendarHolidayOrException che in cal.HolidayOrExceptions)
                                {
                                    HolidayorexceptionDTO hor = new HolidayorexceptionDTO();
                                    hor.DTOStatus = (int)RowStatusNo.New;
                                    hor.CreatedBy = updatedBy;
                                    hor.HldyExpDate = che.Date;
                                    hor.CalendarID = list[0].CalendarID;
                                    hor.WorkHours = 0m;
                                    
                                    if (che.WorkTime != null)
                                    {
                                        foreach (P6WS.CalendarService.CalendarHolidayOrExceptionWorkTime wt in che.WorkTime)
                                        {
                                            hor.WorkHours += Math.Round((wt.Finish != null && wt.Start != null) ? Convert.ToDecimal((wt.Finish - wt.Start).TotalHours) : 0m, 1);
                                        }
                                    }

                                    list_hor.Add(hor);
                                }
                                list_hor = (new TrueTask.Build()).SaveHolidayOrException(list_hor).ToList();
                            } //HolidayOrExceptions

                            if (cal.StandardWorkWeek != null)
                            {
                                foreach (P6WS.CalendarService.CalendarStandardWorkHours dow in cal.StandardWorkWeek)
                                {
                                    List<StandardworkweekDTO> list_swk = new List<StandardworkweekDTO>();
                                    StandardworkweekDTO wweek = new StandardworkweekDTO();
                                    wweek.DTOStatus = (int)RowStatusNo.New;
                                    wweek.CreatedBy = updatedBy;
                                    wweek.DayOfWeek = (int)dow.DayOfWeek;
                                    wweek.CalendarID = list[0].CalendarID;
                                    
                                    if (dow.WorkTime != null)
                                    {
                                        List<WorktimeDTO> list_wk = new List<WorktimeDTO>();
                                        foreach (P6WS.CalendarService.CalendarStandardWorkHoursWorkTime wt in dow.WorkTime)
                                        {
                                            WorktimeDTO wtime = new WorktimeDTO();
                                            wtime.DTOStatus = (int)RowStatusNo.New;
                                            wtime.CreatedBy = updatedBy;
                                            wtime.StartTime = new DateTime(1999, 1, 1, wt.Start.Hour, wt.Start.Minute, wt.Start.Second, wt.Start.Millisecond);
                                            wtime.FinishTime = new DateTime(1999, 1, 1, wt.Finish.Hour, wt.Finish.Minute, wt.Finish.Second, wt.Finish.Millisecond);                                            
                                            wweek.WorkHours += Math.Round((wt.Finish != null && wt.Start != null) ? Convert.ToDecimal((wt.Finish - wt.Start).TotalHours) : 0m, 1);
                                            list_wk.Add(wtime);
                                        }

                                        list_swk.Add(wweek);
                                        list_swk = (new TrueTask.Build()).SaveStandardWorkWeek(list_swk).ToList();

                                        foreach (WorktimeDTO wt in list_wk)
                                            wt.StandardWorkWeekID = list_swk[0].StandardWorkWeekID;

                                        list_wk = (new TrueTask.Build()).SaveWorkTime(list_wk).ToList();

                                    }
                                }

                            } //standardworkweek

                        } //calendar

                    } // calendar does not exist

                } //each calendear end

            } //try end
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region "Activity"

        public virtual P6WS.ActivityService.Activity[] ReadActivities(int activityObjectId, string userName, string password)
        {
            P6WS.ActivityService.ActivityPortBinding apb = new P6WS.ActivityService.ActivityPortBinding();
            apb.CookieContainer = P6Login(userName, password);
            apb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_ACTIVITY_SERVICE].ToString();

            P6WS.ActivityService.ReadActivities ra = new P6WS.ActivityService.ReadActivities();
            P6WS.ActivityService.ActivityFieldType[] actFields = new P6WS.ActivityService.ActivityFieldType[18];
            actFields[0] = P6WS.ActivityService.ActivityFieldType.Id;
            actFields[1] = P6WS.ActivityService.ActivityFieldType.ObjectId;
            actFields[2] = P6WS.ActivityService.ActivityFieldType.Name;
            actFields[3] = P6WS.ActivityService.ActivityFieldType.ProjectId;
            actFields[4] = P6WS.ActivityService.ActivityFieldType.ProjectObjectId;
            actFields[5] = P6WS.ActivityService.ActivityFieldType.RemainingDuration;
            actFields[6] = P6WS.ActivityService.ActivityFieldType.StartDate;
            actFields[7] = P6WS.ActivityService.ActivityFieldType.FinishDate;
            actFields[8] = P6WS.ActivityService.ActivityFieldType.WBSObjectId;
            actFields[9] = P6WS.ActivityService.ActivityFieldType.ActualDuration;
            actFields[10] = P6WS.ActivityService.ActivityFieldType.ActualStartDate;
            actFields[11] = P6WS.ActivityService.ActivityFieldType.ExpectedFinishDate;
            actFields[12] = P6WS.ActivityService.ActivityFieldType.DurationPercentComplete;
            actFields[13] = P6WS.ActivityService.ActivityFieldType.AtCompletionDuration;
            actFields[14] = P6WS.ActivityService.ActivityFieldType.RemainingDuration;
            actFields[15] = P6WS.ActivityService.ActivityFieldType.ActualStartDate;
            actFields[16] = P6WS.ActivityService.ActivityFieldType.Status;
            actFields[17] = P6WS.ActivityService.ActivityFieldType.CalendarObjectId;

            ra.Field = actFields;
            ra.Filter = string.Format("ObjectId={0}", activityObjectId);
            P6WS.ActivityService.Activity[] acts = apb.ReadActivities(ra);

            return acts;
        }

        public virtual P6WS.ActivityService.Activity[] CreateActivity(P6WS.ActivityService.Activity newActivity, string userName, string password)
        {
            P6WS.ActivityService.Activity[] results = null;
            P6WS.ActivityService.Activity[] act = new P6WS.ActivityService.Activity[1];

            P6WS.ActivityService.ActivityPortBinding apb = new P6WS.ActivityService.ActivityPortBinding();
            apb.CookieContainer = P6Login(userName, password);
            apb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_ACTIVITY_SERVICE].ToString();

            act[0] = newActivity;
            act[0].StartDateSpecified = true;
            act[0].FinishDateSpecified = true;
            act[0].ProjectObjectIdSpecified = true;
            act[0].WBSObjectIdSpecified = true;
            //act[0].CalendarObjectIdSpecified = true;

            int[] ids = apb.CreateActivities(act);

            if (ids.Length > 0)
            {
                results = new P6WS.ActivityService.Activity[ids.Length];
                for (int i = 0; i < ids.Length; i++)
                {
                    P6WS.ActivityService.Activity[] added = ReadActivities(ids[0], userName, password);
                    if (added.Length > 0)
                        results[i] = added[0];
                }

            }

            return results;
        }

        public virtual P6WS.ActivityService.Activity[] UpdateActivities(P6WS.ActivityService.Activity[] acts, string userName, string password)
        {
            P6WS.ActivityService.Activity[] results = null;
            P6WS.ActivityService.ActivityPortBinding apb = new P6WS.ActivityService.ActivityPortBinding();
            apb.CookieContainer = P6Login(userName, password);
            apb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_ACTIVITY_SERVICE].ToString();

            P6WS.ActivityService.UpdateActivitiesResponse rtn = apb.UpdateActivities(acts);
            if (rtn.Return)
            {
                results = new P6WS.ActivityService.Activity[acts.Length];
                for (int i = 0; i < acts.Length; i++)
                {
                    P6WS.ActivityService.Activity[] updated = ReadActivities(acts[0].ObjectId, userName, password);
                    if (updated.Length > 0)
                        results[i] = updated[0];
                }
            }
            return results;
        }

        public virtual bool DeleteActivities(int[] Ids, string userName, string password)
        {
            P6WS.ActivityService.ActivityPortBinding apb = new P6WS.ActivityService.ActivityPortBinding();
            apb.CookieContainer = P6Login(userName, password);
            apb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_ACTIVITY_SERVICE].ToString();

            P6WS.ActivityService.DeleteActivitiesResponse rtn = apb.DeleteActivities(Ids);

            return rtn.Return;
        }

        #endregion

        #region "WBS"

        public virtual P6ActivityDTO ReadWBSFilter(string filter, string userName, string password, int projectId = 0)
        {
            P6WS.WBSService.WBSPortBinding wbsp = new P6WS.WBSService.WBSPortBinding();

            wbsp.CookieContainer = P6Login(userName, password);
            wbsp.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_WBS_SERVICE].ToString();

            P6WS.WBSService.ReadWBS rwbs = new P6WS.WBSService.ReadWBS();
            P6WS.WBSService.WBSFieldType[] wbsFields = new P6WS.WBSService.WBSFieldType[17];

            wbsFields[0] = P6WS.WBSService.WBSFieldType.ObjectId;
            wbsFields[2] = P6WS.WBSService.WBSFieldType.Name;
            wbsFields[3] = P6WS.WBSService.WBSFieldType.ProjectId;
            wbsFields[4] = P6WS.WBSService.WBSFieldType.ProjectObjectId;
            wbsFields[5] = P6WS.WBSService.WBSFieldType.SummaryRemainingDuration;
            wbsFields[6] = P6WS.WBSService.WBSFieldType.StartDate;
            wbsFields[7] = P6WS.WBSService.WBSFieldType.FinishDate;
            wbsFields[8] = P6WS.WBSService.WBSFieldType.ObjectId;
            wbsFields[9] = P6WS.WBSService.WBSFieldType.Code;
            wbsFields[10] = P6WS.WBSService.WBSFieldType.Name;
            wbsFields[11] = P6WS.WBSService.WBSFieldType.SequenceNumber;
            wbsFields[12] = P6WS.WBSService.WBSFieldType.Code;
            wbsFields[13] = P6WS.WBSService.WBSFieldType.ParentObjectId;

            rwbs.Field = wbsFields;
            rwbs.Filter = filter; // "ObjectId='" + wbsObjectId + "'";

            P6WS.WBSService.WBS[] wbs = wbsp.ReadWBS(rwbs);

            P6ActivityDTO dto = null;

            if (wbs != null && wbs.Length > 0)
            {
                dto = new P6ActivityDTO();
                dto.P6ActivityObjectID = wbs[0].ObjectId;
                dto.P6ProjectID = wbs[0].ProjectId;
                dto.P6ProjectObjectID = wbs[0].ProjectObjectId;
                dto.P6RemainingDuration = Convert.ToSingle(wbs[0].SummaryRemainingDuration);
                dto.P6StartDate = wbs[0].StartDate;
                dto.P6FinishDate = wbs[0].FinishDate;
                dto.P6WBSName = wbs[0].Name;
                dto.P6WBSCode = wbs[0].Code;
                dto.P6WBSObjectID = wbs[0].ObjectId;
                dto.P6ActivitySeq = 0;
                dto.P6ActivityLevel = 0;
                dto.P6ParentObjectId = Convert.ToInt32(wbs[0].ParentObjectId);
                dto.CalendarObjectID = 0;
            }

            return dto;
        }

        public virtual int[] CreateWBS(P6WS.WBSService.WBS newWbs, string userName, string password)
        {
            //not working because of Code
            P6WS.WBSService.WBS[] wbs = new P6WS.WBSService.WBS[1];

            P6WS.WBSService.WBSPortBinding wpb = new P6WS.WBSService.WBSPortBinding();
            wpb.CookieContainer = P6Login(userName, password);
            wpb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_WBS_SERVICE].ToString();

            wbs[0] = newWbs;

            int[] retValue = wpb.CreateWBS(wbs);

            return retValue;
        }

        #endregion

        #region "For P6 Test"

        /// <summary>
        /// 2014-02-28 
        /// ReadWBS & Set
        /// </summary>
        /// <param name="projectObjectId">projectId</param>
        /// /// <param name="Url">Url</param>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        public SigmaResultTypeDTO ReadP6WBSManager(int projectId, string Url, string userName, string password, string userId)
        {
            UserInfoDTO userinfo = new UserInfoDTO();
            userinfo = (new TrueTask.Common()).GetUserInfo(userId);

            SigmaResultTypeDTO Result = new SigmaResultTypeDTO();
            Web.Biz.Common.CommonCodeMgr commonMgr = new Web.Biz.Common.CommonCodeMgr();
            string getUrl = Url;

            P6WS.WBSService.WBSPortBinding wbsp = new P6WS.WBSService.WBSPortBinding();
            wbsp.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_WBS_SERVICE].ToString();            
            P6WS.WBSService.ReadWBS rwbs = new P6WS.WBSService.ReadWBS();

            //For Test
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                string[] P6LoginInfo = GetP6Login();
                userName = P6LoginInfo[0];
                password = P6LoginInfo[1];
            }

            wbsp.CookieContainer = P6Login(userName, password);
            P6WS.WBSService.WBSFieldType[] wbsFields = new P6WS.WBSService.WBSFieldType[17];

            P6ProjectCombo(userName, password);
            projectRow = P6DT.Select("ProjectObjectId ='" + projectId.ToString() + "'");


            #region set p6
            wbsFields[0] = P6WS.WBSService.WBSFieldType.ObjectId;
            wbsFields[2] = P6WS.WBSService.WBSFieldType.Name;
            wbsFields[3] = P6WS.WBSService.WBSFieldType.ProjectId;
            wbsFields[4] = P6WS.WBSService.WBSFieldType.ProjectObjectId;
            wbsFields[5] = P6WS.WBSService.WBSFieldType.SummaryRemainingDuration;
            wbsFields[6] = P6WS.WBSService.WBSFieldType.StartDate;
            wbsFields[7] = P6WS.WBSService.WBSFieldType.FinishDate;
            wbsFields[8] = P6WS.WBSService.WBSFieldType.ObjectId;
            wbsFields[9] = P6WS.WBSService.WBSFieldType.Code;
            wbsFields[10] = P6WS.WBSService.WBSFieldType.Name;
            wbsFields[11] = P6WS.WBSService.WBSFieldType.SequenceNumber;
            wbsFields[12] = P6WS.WBSService.WBSFieldType.Code;
            wbsFields[13] = P6WS.WBSService.WBSFieldType.ParentObjectId;
            rwbs.Field = wbsFields;
            rwbs.Filter = "ProjectObjectId='" + projectId + "'";
            P6WS.WBSService.WBS[] wbs = wbsp.ReadWBS(rwbs);
            #endregion

            if (wbs != null && wbs.Length > 0)
            {
                for (int i = 0; i < wbs.Length; i++)
                {
                    Types.Common.TypeExternalSchedule TypeExSchedule = new Types.Common.TypeExternalSchedule();
                    Types.Common.TypeScheduledWorkItem TypeSWI = new Types.Common.TypeScheduledWorkItem();
                    Web.Biz.Common.ExternalScheduleMgr ExSchMgr = new Web.Biz.Common.ExternalScheduleMgr();
                    Web.Biz.Common.ScheduledWorkItemMgr SchMgr = new Web.Biz.Common.ScheduledWorkItemMgr();

                    if (wbs[i].Name != "WBSFIWP" && wbs[i].Code != "FIWP")
                    {
                        #region  set Level = 3
                        // Set TypeExternalSchedule
                        TypeExSchedule.Level = "3";
                        TypeExSchedule.StartDate = wbs[i].StartDate.ToString();
                        TypeExSchedule.EndDate = wbs[i].FinishDate.ToString();
                        TypeExSchedule.ProjectObjectId = projectId;
                        TypeExSchedule.ParentObjectId = 0;
                        TypeExSchedule.OriginalDuration = Convert.ToInt32(wbs[i].SummaryRemainingDuration);
                        TypeExSchedule.RemainingDuration = Convert.ToInt32(wbs[i].SummaryRemainingDuration);
                        TypeExSchedule.ActivityObjectId = wbs[i].ObjectId;
                        TypeExSchedule.ExternalProjectName = projectRow[0]["P6ProjectName"].ToString();
                        TypeExSchedule.CalendarId = 0;
                        TypeExSchedule.CreatedBy = userinfo.SigmaUserId;
                        //Result = ExSchMgr.AddExternalSchedule(TypeExSchedule);//////////////////////

                        // Set TypeScheduledWorkItem
                        TypeSWI.ExternalScheduleId = Result.ScalarValue;
                        TypeSWI.CwpId = null;
                        TypeSWI.ScheduleName = wbs[i].Name;
                        TypeSWI.StartDate = wbs[i].StartDate.ToString();
                        TypeSWI.EndDate = wbs[i].FinishDate.ToString();
                        TypeSWI.CrewMemebersAssigned = 0;
                        TypeSWI.TotalWorkingHours = 0;
                        TypeSWI.LeaderId = "0";
                        TypeSWI.CreatedBy = userinfo.SigmaUserId;
                        //Result = SchMgr.AddScheduledWorkItem(TypeSWI);//////////////////////
                        #endregion

                        //Level 4 로 Input
                        ReadActivities(TypeExSchedule.ActivityObjectId, projectId, userName, password, userinfo);
                    }

                }
            }

            return Result;
        }

        /// <summary>
        /// ReadActivities & Set 
        /// </summary>
        /// <param name="activityObjectId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual SigmaResultTypeDTO ReadActivities(int activityObjectId, int projectId, string userName, string password, UserInfoDTO userinfo)
        {
            SigmaResultTypeDTO Result = new SigmaResultTypeDTO();
            Types.Common.TypeExternalSchedule TypeExSchedule = new Types.Common.TypeExternalSchedule();
            Types.Common.TypeScheduledWorkItem TypeSWI = new Types.Common.TypeScheduledWorkItem();
            Web.Biz.Common.ExternalScheduleMgr ExSchMgr = new Web.Biz.Common.ExternalScheduleMgr();
            Web.Biz.Common.ScheduledWorkItemMgr SchMgr = new Web.Biz.Common.ScheduledWorkItemMgr();

            P6WS.ActivityService.ActivityPortBinding apb = new P6WS.ActivityService.ActivityPortBinding();
            apb.CookieContainer = P6Login(userName, password);
            apb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_ACTIVITY_SERVICE].ToString();            
            P6WS.ActivityService.ReadActivities ra = new P6WS.ActivityService.ReadActivities();
            P6WS.ActivityService.ActivityFieldType[] actFields = new P6WS.ActivityService.ActivityFieldType[18];

            #region   set Activity Data
            actFields[0] = P6WS.ActivityService.ActivityFieldType.Id;
            actFields[1] = P6WS.ActivityService.ActivityFieldType.ObjectId;
            actFields[2] = P6WS.ActivityService.ActivityFieldType.Name;
            actFields[3] = P6WS.ActivityService.ActivityFieldType.ProjectId;
            actFields[4] = P6WS.ActivityService.ActivityFieldType.ProjectObjectId;
            actFields[5] = P6WS.ActivityService.ActivityFieldType.RemainingDuration;
            actFields[6] = P6WS.ActivityService.ActivityFieldType.StartDate;
            actFields[7] = P6WS.ActivityService.ActivityFieldType.FinishDate;
            actFields[8] = P6WS.ActivityService.ActivityFieldType.WBSObjectId;
            actFields[9] = P6WS.ActivityService.ActivityFieldType.ActualDuration;
            actFields[10] = P6WS.ActivityService.ActivityFieldType.ActualStartDate;
            actFields[11] = P6WS.ActivityService.ActivityFieldType.ExpectedFinishDate;
            actFields[12] = P6WS.ActivityService.ActivityFieldType.DurationPercentComplete;
            actFields[13] = P6WS.ActivityService.ActivityFieldType.AtCompletionDuration;
            actFields[14] = P6WS.ActivityService.ActivityFieldType.RemainingDuration;
            actFields[15] = P6WS.ActivityService.ActivityFieldType.ActualStartDate;
            actFields[16] = P6WS.ActivityService.ActivityFieldType.Status;
            actFields[17] = P6WS.ActivityService.ActivityFieldType.CalendarObjectId;
            #endregion

            ra.Field = actFields;
            ra.Filter = string.Format("WBSObjectId={0}", activityObjectId);
            P6WS.ActivityService.Activity[] acts = apb.ReadActivities(ra);

            if (acts != null && acts.Length > 0)
            {
                for (int i = 0; i < acts.Length; i++)
                {
                    // Set TypeExternalSchedule
                    TypeExSchedule.Level = "4";
                    TypeExSchedule.StartDate = acts[i].StartDate.ToString();
                    TypeExSchedule.EndDate = acts[i].FinishDate.ToString();
                    TypeExSchedule.ProjectObjectId = projectId;
                    TypeExSchedule.ParentObjectId = activityObjectId;
                    TypeExSchedule.OriginalDuration = Convert.ToInt32(acts[i].ActualDuration);
                    TypeExSchedule.RemainingDuration = Convert.ToInt32(acts[i].RemainingDuration);
                    TypeExSchedule.ActivityObjectId = Convert.ToInt32(acts[i].ObjectId);
                    TypeExSchedule.CalendarId = Convert.ToInt32(acts[i].CalendarObjectId);
                    TypeExSchedule.ExternalProjectName = projectRow[0]["P6ProjectName"].ToString();
                    TypeExSchedule.CreatedBy = userinfo.SigmaUserId;
                    //Result = ExSchMgr.AddExternalSchedule(TypeExSchedule);//////////////////////

                    // Set TypeScheduledWorkItem
                    TypeSWI.ExternalScheduleId = Result.ScalarValue;
                    TypeSWI.CwpId = null;
                    TypeSWI.ScheduleName = acts[i].Name.ToString();
                    TypeSWI.StartDate = acts[i].StartDate.ToString();
                    TypeSWI.EndDate = acts[i].FinishDate.ToString();
                    TypeSWI.CrewMemebersAssigned = 0;
                    TypeSWI.TotalWorkingHours = 0;//차후 확인 필요
                    TypeSWI.LeaderId = "";//차후 확인 필요
                    TypeSWI.CreatedBy = userinfo.SigmaUserId;
                    //Result = SchMgr.AddScheduledWorkItem(TypeSWI);//////////////////////

                    ReadCalendars(TypeExSchedule.CalendarId, userName, password);
                }
            }

            return Result;
        }

        /// <summary>
        ///  Set P6Project Info To ComboBox 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SigmaResultTypeDTO P6ProjectCombo(string userName, string password)
        {
            SigmaResultTypeDTO result = new SigmaResultTypeDTO();
            P6WS.ProjectService.ProjectPortBinding apb = new P6WS.ProjectService.ProjectPortBinding();

            apb.CookieContainer = P6Login(userName, password);
            apb.Url = System.Configuration.ConfigurationManager.AppSettings[P6WS_SERVICES_PROJECT_SERVICE].ToString();            
            P6WS.ProjectService.ReadProjects rp = new P6WS.ProjectService.ReadProjects();
            P6WS.ProjectService.ProjectFieldType[] projectFields = new P6WS.ProjectService.ProjectFieldType[3];

            projectFields[0] = P6WS.ProjectService.ProjectFieldType.ObjectId;
            projectFields[1] = P6WS.ProjectService.ProjectFieldType.Id;
            projectFields[2] = P6WS.ProjectService.ProjectFieldType.Name;
            rp.Field = projectFields;
            P6WS.ProjectService.Project[] projects = apb.ReadProjects(rp);

            P6DT = new DataTable("P6ProjectList");
            P6DT.Columns.Add("ProjectObjectID");
            P6DT.Columns.Add("P6ProjectID");
            P6DT.Columns.Add("P6ProjectName");

            if (projects != null && projects.Length > 0)
            {
                for (int i = 0; i < projects.Length; i++)
                {
                    if (!projects[i].Name.ToLower().Contains("reflection"))
                    {
                        DataRow newRow = P6DT.NewRow();
                        newRow["ProjectObjectID"] = projects[i].ObjectId;
                        newRow["P6ProjectID"] = projects[i].Id;
                        newRow["P6ProjectName"] = projects[i].Name;
                        P6DT.Rows.Add(newRow);
                    }
                }
            }

            result.JsonDataSet = JsonHelper.convertDataTableToJson(P6DT);
            result.IsSuccessful = true;

            return result;
        }
        
        #endregion

    }
}
