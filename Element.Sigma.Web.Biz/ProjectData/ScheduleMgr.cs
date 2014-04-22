using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Common;
using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types;
using Element.Sigma.Web.Biz.Types.ProjectData;
using Element.Sigma.Web.Biz.Types.Common;

namespace Element.Sigma.Web.Biz.ProjectData
{
    public class ScheduleMgr
    {
        TypeUserInfo userinfo = AuthMgr.GetUserInfo();
        protected const String P6WS_SERVICES_AUTHENTICATION_SERVICE = "P6WS.AuthenticationService";
        protected const String P6WS_SERVICES_WBS_SERVICE = "P6WS.WBSService";
        protected const String P6WS_SERVICES_PROJECT_SERVICE = "P6WS.ProjectService";
        protected const String P6WS_SERVICES_ACTIVITY_SERVICE = "P6WS.ActivityService";
        DataTable P6DT = null;
        DataRow[] projectRow = null;

        /// <summary>
        /// 2014-03-09
        /// Get GeneralForeman
        /// Data > Schedule > Edit
        /// </summary>
        /// <returns></returns>
        public SigmaResultType GetGeneralForeManCombo()
        {
           SigmaResultType result = new SigmaResultType();
           TypeUserInfo userinfo = AuthMgr.GetUserInfo();

           string connStr = ConnStrHelper.getDbConnString();
           SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
           };
           DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetGeneralForemanCombo", parameters);
           result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
           result.IsSuccessful = true;
           return result;
        }

        /// <summary>
        /// 2014-02-28 
        /// ReadWBS & Set
        /// </summary>
        /// <param name="projectObjectId">projectId</param>
        /// /// <param name="Url">Url</param>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        public SigmaResultType ReadP6WBSManager(int p6projectId)
        {
            SigmaResultType Result = new SigmaResultType();
            CommonCodeMgr commonMgr = new CommonCodeMgr();
            string p6username, p6password, p6login;

            p6login = System.Configuration.ConfigurationManager.AppSettings["P6Login"].ToString();
            p6username = p6login.Split(';')[0].Split('=')[1].Trim();
            p6password = p6login.Split(';')[1].Split('=')[1].Trim();
            


            P6WS.WBSService.WBSPortBinding wbsp = new P6WS.WBSService.WBSPortBinding();
            //wbsp.Url = ConfigurationManager.AppSettings[P6WS_SERVICES_WBS_SERVICE].ToString();//임시루
            
            wbsp.Url = System.Configuration.ConfigurationManager.AppSettings["P6WS.WBSService"];


            P6WS.WBSService.ReadWBS rwbs = new P6WS.WBSService.ReadWBS();

            wbsp.CookieContainer = P6Login(p6username, p6password);
            P6WS.WBSService.WBSFieldType[] wbsFields = new P6WS.WBSService.WBSFieldType[17];

            P6ProjectCombo(p6username, p6password); // 이 구문이 실행되면 P6DT에 값이 채워짐.
            projectRow = P6DT.Select("ProjectObjectId ='" + p6projectId.ToString() + "'");


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
            rwbs.Filter = "ProjectObjectId='" + p6projectId + "'";
            P6WS.WBSService.WBS[] wbs = wbsp.ReadWBS(rwbs);
            #endregion

            if (wbs != null && wbs.Length > 0)
            {
                for (int i = 0; i < wbs.Length; i++)
                {
                    TypeExternalSchedule TypeExSchedule = new TypeExternalSchedule();
                    TypeScheduledWorkItem TypeSWI = new TypeScheduledWorkItem();
                    ExternalScheduleMgr ExSchMgr = new ExternalScheduleMgr();
                    ScheduledWorkItemMgr SchMgr = new ScheduledWorkItemMgr();

                    if (wbs[i].Name != "WBSFIWP" && wbs[i].Code != "FIWP") // 뭐냐 이건...
                    {
                        #region  set Level = 3
                        // Set TypeExternalSchedule
                        TypeExSchedule.Level = "3";
                        TypeExSchedule.StartDate = wbs[i].StartDate.ToString();
                        TypeExSchedule.EndDate = wbs[i].FinishDate.ToString();
                        TypeExSchedule.ProjectObjectId = p6projectId;
                        TypeExSchedule.ParentObjectId = 0;
                        TypeExSchedule.OriginalDuration = Convert.ToInt32(wbs[i].SummaryRemainingDuration);
                        TypeExSchedule.RemainingDuration = Convert.ToInt32(wbs[i].SummaryRemainingDuration);
                        TypeExSchedule.ActivityObjectId = wbs[i].ObjectId;
                        TypeExSchedule.ExternalProjectName = projectRow[0]["P6ProjectName"].ToString();
                        TypeExSchedule.CalendarId = 0;
                        TypeExSchedule.CreatedBy = userinfo.SigmaUserId;
                        TypeExSchedule.ProjectId = userinfo.CurrentProjectId;
                        Result = ExSchMgr.AddExternalSchedule(TypeExSchedule);

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
                        Result = SchMgr.AddScheduledWorkItem(TypeSWI);
                        #endregion

                        //Level 4 로 Input
                        ReadActivities(TypeExSchedule.ActivityObjectId,  p6projectId, p6username, p6password);
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
        public virtual SigmaResultType ReadActivities(int activityObjectId, int projectId, string userName, string password)
        {
            SigmaResultType Result = new SigmaResultType();
            TypeExternalSchedule TypeExSchedule = new TypeExternalSchedule();
            TypeScheduledWorkItem TypeSWI = new TypeScheduledWorkItem();
            ExternalScheduleMgr ExSchMgr = new ExternalScheduleMgr();
            ScheduledWorkItemMgr SchMgr = new ScheduledWorkItemMgr();

            P6WS.ActivityService.ActivityPortBinding apb = new P6WS.ActivityService.ActivityPortBinding();
            apb.CookieContainer = P6Login(userName, password);

            apb.Url = System.Configuration.ConfigurationManager.AppSettings["P6WS.ActivityService"];
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
                    TypeExSchedule.OriginalDuration = Convert.ToInt32(acts[i].RemainingDuration);
                    TypeExSchedule.RemainingDuration = Convert.ToInt32(acts[i].ActualDuration);
                    TypeExSchedule.ActivityObjectId = Convert.ToInt32(acts[i].ObjectId);
                    TypeExSchedule.CalendarId = Convert.ToInt32(acts[i].CalendarObjectId);
                    TypeExSchedule.ExternalProjectName = projectRow[0]["P6ProjectName"].ToString();
                    TypeExSchedule.CreatedBy = userinfo.SigmaUserId;
                    TypeExSchedule.ProjectId = userinfo.CurrentProjectId;
                    Result = ExSchMgr.AddExternalSchedule(TypeExSchedule);

                    // Set TypeScheduledWorkItem
                    TypeSWI.ExternalScheduleId = Result.ScalarValue;
                    TypeSWI.CwpId = null;
                    TypeSWI.ScheduleName = acts[i].Name.ToString();
                    TypeSWI.StartDate = acts[i].StartDate.ToString();
                    TypeSWI.EndDate = acts[i].FinishDate.ToString();
                    TypeSWI.CrewMemebersAssigned = 0;
                    TypeSWI.TotalWorkingHours = 0; //차후 확인 필요
                    TypeSWI.LeaderId = null;//차후 확인 필요
                    TypeSWI.CreatedBy = userinfo.SigmaUserId;
                    Result = SchMgr.AddScheduledWorkItem(TypeSWI);
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
        public SigmaResultType P6ProjectCombo(string userName, string password)
        {
            SigmaResultType result = new SigmaResultType();
            P6WS.ProjectService.ProjectPortBinding apb = new P6WS.ProjectService.ProjectPortBinding();

            apb.CookieContainer = P6Login(userName, password);
            //apb.Url = ConfigurationManager.AppSettings[P6WS_SERVICES_PROJECT_SERVICE].ToString();

            apb.Url = System.Configuration.ConfigurationManager.AppSettings["P6WS.ProjectService"];
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


        #region P6Login
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
        #endregion 

        public SigmaResultType GetImportedSchedule(string scheduledworkitemid)
        {
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            
            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId),
                new SqlParameter("@ScheduledWorkItemId", Utilities.ToInt32(scheduledworkitemid))
            };

            // Get Data            
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetImportedSchedule", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }


        /// <summary>
        /// P6 리스트 하기 전에 항상 유무 확인  
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        private SigmaResultType CheckProjectId(int projectId)
        {
            //CommonCodeMgr common = new CommonCodeMgr();
            //SigmaResultType result = new SigmaResultType();

            //string Where = "Where ProjectObjectId = '"+projectId+"'";

            //DataRow[] ProjectRow = common.GetCommonCode("*", "ExternalSchedule", Where).Select();

            //if (ProjectRow.Length > 0)
            //{
            //    result = RemoveImportedSchedule(int.Parse(ProjectRow[0]["ExternalScheduleId"].ToString()), projectId);
            //}

            // ExternalSchedule Table에 추가된 ProjectId를 이용하여 삭제하는 것으로 변경함.
            SigmaResultType result = new SigmaResultType();
            result = RemoveImportedSchedule(projectId);
            return result;
        }
        /// <summary>
        /// P6 List
        /// Data > SChedule > List 
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public SigmaResultType ListImportedSchedule(NameValueCollection queryParams)
        {
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            List<SqlParameter> paramList = new List<SqlParameter>();

            string max = queryParams["max"];
            string offset = queryParams["offset"];
            string o_option = queryParams["o_option"];
            string o_desc = queryParams["o_desc"];

            if (queryParams["projectId"] != null && queryParams["projectId"] == "null")
            {
                queryParams["projectId"] = null;
            }

            int p6projectId = (queryParams["projectId"] == null ? 0 : int.Parse(queryParams["projectId"]));


            //ProjectID의 값에 따라 메뉴에서 들어온 것인지, 아니면 모달 창에서 임포트할 프로젝트를 선택한 것인지 결정하고 있음.
            // 아래는 임포트할 P6프로젝트가 선택되었을 때 해당 데이터를 삭제하고 다시 입력하는 코드를 담고 있음.
            // 이 모든 과정이 GET 메소드로 진행되는 것이 타당한가에 대한 의문이 있음.
            // by Andy
            if (p6projectId != 0)
            {
                //Project 존재 유무 확인 및 삭제 
                //CheckProjectId(projectId); // 여기서 프로젝트ID는 p6의 프로젝트 id임. 무의미하게 삭제 쿼리를 실행함. 주석 처리함. Andy

                // ExternalSchedule Table에 ProjectId가 추가되었음. 이는 sigma의 ProjectId임. 
                // 기존 코드를 변경하여 현재 프로젝트가 참조하고 있는 데이터를 삭제하는 것으로 변경함.
                TypeUserInfo userinfo = AuthMgr.GetUserInfo();
                CheckProjectId(userinfo.CurrentProjectId);

                result = ReadP6WBSManager(p6projectId);
            }

            // max = null; // to set max = 10000

            paramList.Add(new SqlParameter("@ProjectObjectId", p6projectId));
            
            // 모두 한 페이지에 보이라는 요구사항 처리로 아래와 같이 변경함
            //paramList.Add(new SqlParameter("@MaxNumRows", (max == null ? 10000 : int.Parse(max))));
            paramList.Add(new SqlParameter("@MaxNumRows", 100000));
            //paramList.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            paramList.Add(new SqlParameter("@RetrieveOffset", (int)0));


            paramList.Add(new SqlParameter("@SortColumn", (o_option != null ? o_option.ToUpper() : "CreatedDate")));
            paramList.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : "DESC")));

            TypeUserInfo currentInfo = AuthMgr.GetUserInfo();
            paramList.Add(new SqlParameter("@ProjectId", currentInfo.CurrentProjectId));
            
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListImportedSchedule", paramList.ToArray());
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            return result;
        }

        public SigmaResultType AddImportedSchedule(TypeImportedSchedule objImportedSchedule)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Wbs", objImportedSchedule.Wbs));
            paramList.Add(new SqlParameter("@ScheduleLineItem", objImportedSchedule.ScheduleLineItem));
            paramList.Add(new SqlParameter("@P6StartDate", objImportedSchedule.P6StartDate));
            paramList.Add(new SqlParameter("@P6FinishDate", objImportedSchedule.P6FinishDate));
            paramList.Add(new SqlParameter("@P6Duration", objImportedSchedule.P6Duration));
            paramList.Add(new SqlParameter("@SigmaStartDate", objImportedSchedule.SigmaStartDate));
            paramList.Add(new SqlParameter("@SigmaFinishDate", objImportedSchedule.SigmaFinishDate));
            paramList.Add(new SqlParameter("@SigmaDuration", objImportedSchedule.SigmaDuration));
            paramList.Add(new SqlParameter("@EstimatedManhours", objImportedSchedule.EstimatedManhours));
            paramList.Add(new SqlParameter("@AssignedCrew", objImportedSchedule.AssignedCrew));
            paramList.Add(new SqlParameter("@DisciplineCode", objImportedSchedule.DisciplineCode));
            paramList.Add(new SqlParameter("@CwpId", objImportedSchedule.CwpId));
            paramList.Add(new SqlParameter("@AssignedTo", objImportedSchedule.AssignedTo));
            paramList.Add(new SqlParameter("@CreatedBy", objImportedSchedule.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddImportedSchedule", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }

        /// <summary>
        /// Update P6 Data
        /// Project Control > Data > Schedule > Update
        /// </summary>
        /// <param name="objImportedSchedule"></param>
        /// <returns></returns>
        public SigmaResultType UpdateImportedSchedule(TypeImportedSchedule objImportedSchedule)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ScheduledWorkItemId", objImportedSchedule.ScheduledWorkItemId));
            paramList.Add(new SqlParameter("@DisciplineCode", objImportedSchedule.DisciplineCode));
            paramList.Add(new SqlParameter("@CwpId", objImportedSchedule.CwpId));
            paramList.Add(new SqlParameter("@AssignedTo", objImportedSchedule.AssignedTo));
            paramList.Add(new SqlParameter("@UpdatedBy", objImportedSchedule.UpdatedBy));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateImportedSchedule", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        /// <summary>
        /// 2014-03-09
        /// Project Control > Data> Schedule > Remove before Insert 
        /// </summary>
        /// <param name="ExternalId">ExternalScheduleId</param>
        /// <param name="projectId">P6 Project Id</param>
        /// <returns></returns>
        //public SigmaResultType RemoveImportedSchedule(int ExternalId, int projectId) -- by Andy
        public SigmaResultType RemoveImportedSchedule( int projectId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjcetId", projectId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveImportedSchedule", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }
            return result;
        }


        /// <summary>
        /// 2014-03-07
        /// Project Control > Data > Schedule  > Remove ScheduleWorkItem
        /// </summary>
        /// <param name="objImportedSchedule"></param>
        /// <returns></returns>
        public SigmaResultType MultiImportedSchedule()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;
            //string connStr = ConnStrHelper.getDbConnString();


            result = RemoveImportedSchedule(userinfo.CurrentProjectId);
            return result;

            // 동일 코드 반복으로 인해 삭제함.
            //// Compose parameters
            //SqlParameter[] parameters = new SqlParameter[] {
            //    new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
            //};

            //using (scope = new TransactionScope(TransactionScopeOption.Required))
            //{
            //    result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveScheduledWorkItem", parameters);
            //    result.IsSuccessful = true;
            //    scope.Complete();
            //}
            //return result;
        }

    }
}
