using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Common;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Transactions;
using Diagrams;

namespace Element.Sigma.Web.Biz.Workflow
{
    public class WorkflowMgr
    {
        public string SMTPServerUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPServerUrl"].ToString();
        public string SMTPServerPort = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPServerPort"].ToString();
        public string SMTPAccessId = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPAccessId"].ToString();
        public string SMTPAccessPWD = System.Web.Configuration.WebConfigurationManager.AppSettings["SMTPAccessPWD"].ToString();

        public const int WORKFLOW_STATUS_APPROVAL = 1;
        public const int WORKFLOW_STATUS_DENIAL = 99;
        public const int WORKFLOW_STATUS_PENDING = 2;
        
        #region | DEFAULT |

        #region | WORKFLOW DESIGNER SETTING |

        #region GetWorkflowSchemeCode : Workflow Mapping 테이블 조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowSchemeCode
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-24
         * 용       도 : SchemeCode를 이용하여 해당 Workflow를 조회
         * Input    값 : GetWorkflowSchemeCode(Scheme Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowSchemeCode : SchemeCode를 이용하여 해당 Workflow를 조회
        /// </summary>
        /// <param name="SchemeCode">SchemeCode</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowSchemeCode(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SchemeCode", SchemeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowSchemeCode", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region GetWorkflowHierachyForDesigner : SchemeCode를 이용하여 해당 Workflow를 조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowHierachyForDesigner
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-24
         * 용       도 : SchemeCode를 이용하여 해당 Workflow를 조회
         * Input    값 : GetWorkflowHierachyForDesigner(Scheme Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowHierachyForDesigner : SchemeCode를 이용하여 해당 Workflow를 조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowHierachyForDesigner(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SchemeCode", SchemeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowHierachyForDesigner", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region DisplayWorkflowSchemeStyle : WorkflowSchemeStyle을 화면에 보여줌.

        /**********************************************************************************************
         * Mehtod   명 : DisplayWorkflowSchemeStyle
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-04-02
         * 용       도 : WorkflowSchemeStyle을 화면에 보여줌.
         * Input    값 : DisplayWorkflowSchemeStyle(Node안에 들어갈 이미지 경로(Full 경로가 아닌 절대경로))
         * Ouput    값 : string
         **********************************************************************************************/
        /// <summary>
        /// DisplayWorkflowSchemeStyle : WorkflowSchemeStyle을 화면에 보여줌.
        /// </summary>
        /// <param name="NodeImageUrl">Node안에 들어갈 이미지 경로(Full 경로가 아닌 절대경로)</param>
        /// <returns>string</returns>
        public string DisplayWorkflowSchemeStyle(string NodeImageUrl)
        {
            string strReturn = string.Empty;

            strReturn = Designers.GenerateStyle(NodeImageUrl);

            return strReturn;
        }

        #endregion

        #region DisplayWorkflowSchemeScript : WorkflowSchemeScript을 화면에 보여줌.

        /**********************************************************************************************
         * Mehtod   명 : DisplayWorkflowSchemeScript
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-04-02
         * 용       도 : WorkflowSchemeScript을 화면에 보여줌.
         * Input    값 : DisplayWorkflowSchemeScript(가로최소Point, 가로최대Point, 세로최소Point, 세로최대Point)
         * Ouput    값 : string
         **********************************************************************************************/
        /// <summary>
        /// DisplayWorkflowSchemeScript : WorkflowSchemeScript을 화면에 보여줌.
        /// </summary>
        /// <param name="MinWidth">가로최소Point</param>
        /// <param name="MaxWidth">가로최대Point</param>
        /// <param name="MinHeight">세로최소Point</param>
        /// <param name="MaxHeight">세로최대Point</param>
        /// <returns>string</returns>
        public string DisplayWorkflowSchemeScript(int MinWidth, int MaxWidth, int MinHeight, int MaxHeight)
        {
            string strReturn = string.Empty;

            strReturn = Designers.GenerateScript(MinWidth, MaxWidth, MinHeight, MaxHeight);

            return strReturn;
        }

        #endregion

        #region DisplayWorkflowSchemeDesigner : WorkflowSchemeDesigner을 화면에 보여줌.

        /**********************************************************************************************
         * Mehtod   명 : DisplayWorkflowSchemeDesigner
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-04-02
         * 용       도 : WorkflowSchemeDesigner을 화면에 보여줌.
         * Input    값 : DisplayWorkflowSchemeDesigner(가로최소Point, 가로최대Point, 세로최소Point, 세로최대Point)
         * Ouput    값 : string
         **********************************************************************************************/
        /// <summary>
        /// DisplayWorkflowSchemeDesigner : WorkflowSchemeDesigner을 화면에 보여줌.
        /// </summary>
        /// <param name="Titles">각노드제목 리스트</param>
        /// <param name="StartWidth">노드의 가로시작Point</param>
        /// <param name="StartHeight">노드의 세로시작Point</param>
        /// <returns>string</returns>
        public string DisplayWorkflowSchemeDesigner(List<string> Titles, int StartWidth, int StartHeight)
        {
            string strReturn = string.Empty;

            strReturn = Designers.GenareteDesigner(Titles, "", StartWidth, StartHeight);

            return strReturn;
        }

        #endregion

        #region RemoveWorkflowScheme : WorkflowScheme 관련 정보 삭제

        /**********************************************************************************************
         * Mehtod   명 : RemoveWorkflowScheme
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-24
         * 용       도 : SchemeCode를 이용하여 해당 Workflow를 조회
         * Input    값 : RemoveWorkflowScheme(Scheme Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// RemoveWorkflowScheme : SchemeCode를 이용하여 해당 Workflow를 조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <returns>SigmaResultType</returns>
        private SigmaResultType RemoveWorkflowScheme(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@SchemeCode", SchemeCode));

            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_RemoveWorkflowScheme", paramList.ToArray());
            result.IsSuccessful = true;

            return result;
        }

        #endregion

        #region AddWorkflowMap : WorkflowMap 관련 정보 등록

        /**********************************************************************************************
         * Mehtod   명 : AddWorkflowMap
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-04-02
         * 용       도 : WorkflowMap 관련 정보 등록
         * Input    값 : AddWorkflowMap(Scheme Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// AddWorkflowMap : WorkflowMap 관련 정보 등록
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <returns>SigmaResultType</returns>
        private SigmaResultType AddWorkflowMap(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@SchemeCode", SchemeCode));

            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_AddWorkflowMap", paramList.ToArray());
            result.IsSuccessful = true;

            return result;
        }

        #endregion

        #region AddWorkflowCode : WorkflowCode 테이블에 정보 등록

        /**********************************************************************************************
         * Mehtod   명 : AddWorkflowCode
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-04-02
         * 용       도 : WorkflowCode 테이블에 정보 등록
         * Input    값 : AddWorkflowCode(워크플로워코드타입, 코드명)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// AddWorkflowCode : WorkflowCode 테이블에 정보 등록
        /// </summary>
        /// <param name="WorkflowCodeType">워크플로워코드타입</param>
        /// <param name="CodeText">코드명</param>
        /// <returns>SigmaResultType</returns>
        private SigmaResultType AddWorkflowCode(int WorkflowCodeType, string CodeText)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@WorkflowCodeType", WorkflowCodeType));
            paramList.Add(new SqlParameter("@CodeText", CodeText));

            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_AddWorkflowCode", paramList.ToArray());
            result.IsSuccessful = true;

            return result;
        }

        #endregion

        #region AddWorkflowRoleHierachy : WorkflowRoleHierachy 테이블에 정보 등록

        /**********************************************************************************************
         * Mehtod   명 : AddWorkflowRoleHierachy
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-04-02
         * 용       도 : WorkflowRoleHierachy 테이블에 정보 등록
         * Input    값 : AddWorkflowRoleHierachy(Scheme Code, Schemem 순번, 현처리코드, 다음처리코드, 상태코드, 진행방향코드, 명령코드, Process명, 생성자)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// AddWorkflowRoleHierachy : WorkflowRoleHierachy 테이블에 정보 등록
        /// </summary>
        /// <param name="SchemeCode">Schemem Code</param>
        /// <param name="SchemeSeq">Schemem 순번</param>
        /// <param name="SchemePosId">현처리코드</param>
        /// <param name="ReportToPosId">다음처리코드</param>
        /// <param name="HierachyStatusCode">상태코드(1:Command, 2:Auto)</param>
        /// <param name="HierachyDirectionCode">진행방향코드(1:Direct, 2:Reverse)</param>
        /// <param name="CommandCode">명령코드(1:Agree, 2:Suspend, 99:Denial)</param>
        /// <param name="ProcessName">Process명</param>
        /// <param name="CreatedBy">생성자</param>
        /// <returns>SigmaResultType</returns>
        private SigmaResultType AddWorkflowRoleHierachy(string SchemeCode, int SchemeSeq, string SchemePosId, string ReportToPosId, int HierachyStatusCode,
                                                        int HierachyDirectionCode, int CommandCode, string ProcessName, string CreatedBy)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@SchemeCode", SchemeCode));
            paramList.Add(new SqlParameter("@SchemeSeq", SchemeSeq));
            paramList.Add(new SqlParameter("@SchemePosId", SchemePosId));
            paramList.Add(new SqlParameter("@ReportToPosId", ReportToPosId));
            paramList.Add(new SqlParameter("@HierachyStatusCode", HierachyStatusCode));
            paramList.Add(new SqlParameter("@HierachyDirectionCode", HierachyDirectionCode));
            paramList.Add(new SqlParameter("@CommandCode", CommandCode));
            paramList.Add(new SqlParameter("@ProcessName", ProcessName));
            paramList.Add(new SqlParameter("@CreatedBy", CreatedBy));

            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_AddWorkflowRoleHierachy", paramList.ToArray());
            result.IsSuccessful = true;

            return result;
        }

        #endregion

        #region AddWorkflowScheme : WorkflowScheme 관련 테이블에 정보 등록

        /**********************************************************************************************
         * Mehtod   명 : AddWorkflowScheme
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-04-02
         * 용       도 : WorkflowScheme 관련 테이블에 정보 등록
         * Input    값 : AddWorkflowScheme(Scheme Code, Schemem 순번, 코드명, 각단계정보, Process명, 생성자)
         * Ouput    값 : DataTable
         **********************************************************************************************/
        /// <summary>
        /// AddWorkflowScheme : WorkflowScheme 관련 테이블에 정보 등록
        /// </summary>
        /// <param name="SchemeCode">Schemem Code</param>
        /// <param name="SchemeSeq">Schemem 순번</param>
        /// <param name="CodeText">코드명</param>
        /// <param name="lstScheme">각단계정보</param>
        /// <param name="ProcessName">Process명</param>
        /// <param name="CreatedBy">생성자</param>
        /// <returns>DataTable</returns>
        public SigmaResultType AddWorkflowScheme(string SchemeCode, int SchemeSeq, string CodeText, List<TypeWorkflowScheme> lstScheme, string ProcessName, string CreatedBy)
        {
            SigmaResultType result = new SigmaResultType();

            using (var scope = new TransactionScope())
            {
                // wfp_RemoveWorkflowScheme
                result = RemoveWorkflowScheme(SchemeCode);

                if (result.IsSuccessful)
                {
                    // wfp_AddWorkflowMap
                    result = AddWorkflowMap(SchemeCode);

                    if (result.IsSuccessful)
                    {
                        // wfp_AddWorkflowCode
                        result = AddWorkflowCode(7, CodeText);

                        if (result.IsSuccessful)
                        {
                            int intRowCnt = 0;

                            foreach (TypeWorkflowScheme scheme in lstScheme)
                            {
                                int intCommandCode = 0;

                                if (intRowCnt == 0 && scheme.HierachyCommandTypeCode == 1)
                                {
                                    // IWP방식의 시작
                                    intCommandCode = 1;
                                }
                                else if (intRowCnt == 0 && scheme.HierachyCommandTypeCode == 2)
                                {
                                    // RFI방식의 시작
                                    intCommandCode = 4;
                                }
                                else if (intRowCnt == lstScheme.Count - 1 && scheme.HierachyCommandTypeCode == 1)
                                {
                                    // IWP방식의 종료
                                    intCommandCode = 3;
                                }
                                else if (intRowCnt == lstScheme.Count - 1 && scheme.HierachyCommandTypeCode == 2)
                                {
                                    // RFI방식의 종료
                                    intCommandCode = 6;
                                }
                                else if (scheme.HierachyCommandTypeCode == 1)
                                {
                                    // IWP방식의 진행
                                    intCommandCode = 2;
                                }
                                else if (scheme.HierachyCommandTypeCode == 2)
                                {
                                    // RFI방식의 진행
                                    intCommandCode = 5;
                                }

                                // wfp_AddWorkflowRoleHierachy
                                result = AddWorkflowRoleHierachy(SchemeCode, SchemeSeq, scheme.SchemePosId, scheme.ReportToPosId, scheme.HierachyStatusCode, scheme.HierachyDirectionCode, intCommandCode, ProcessName, CreatedBy);

                                intRowCnt++;
                            }

                            // Execute 처리
                            // wfp_AddWorkflowRoleHierachy
                            result = AddWorkflowRoleHierachy(SchemeCode, SchemeSeq, "Execute", "", 0, 0, 0, ProcessName, CreatedBy);
                        }
                    }
                }

                scope.Complete();
            }

            return result;
        }

        #endregion

        #endregion

        #region | WORKFLOW MEMBER COUNT SETTING |

        #region GetWorkflowSchemeList : WorkflowScheme 테이블 조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowSchemeList
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-24
         * 용       도 : WorkflowScheme 테이블 조회
         * Input    값 : GetWorkflowSchemeList(Scheme Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowSchemeList : WorkflowScheme 테이블 조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowSchemeList(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Code", SchemeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowSchemeList", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region GetWorkflowHierachy: WorkflowHierachy 목록조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowHierachy
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-22
         * 용       도 : WorkflowHierachy 목록조회
         * Input    값 : GetWorkflowHierachy(Scheme Code, Scheme Sequence)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowHierachy: WorkflowHierachy 목록조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <param name="SchemeSeq">Scheme Sequence</param>
        /// <returns></returns>
        public SigmaResultType GetWorkflowHierachy(string SchemeCode, int SchemeSeq)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SchemeCode", SchemeCode));
            parameters.Add(new SqlParameter("@SchemeSeq", SchemeSeq));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowHierachy", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region GetWorkflowHierachySeq: WorkflowHierachy에 따른 Sequence 조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowHierachySeq
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-22
         * 용       도 : WorkflowHierachy에 따른 Sequence 조회
         * Input    값 : GetWorkflowHierachySeq(SchemeCode)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowHierachySeq: WorkflowHierachy에 따른 Sequence 조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowHierachySeq(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SchemeCode", SchemeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowHierachySeq", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region AddWorkflowHierachy: 새 WorkflowHierachy 등록

        /**********************************************************************************************
         * Mehtod   명 : AddWorkflowHierachy
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-22
         * 용       도 : 새 WorkflowHierachy 등록
         * Input    값 : AddWorkflowHierachy(Scheme Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// AddWorkflowHierachy: 새 WorkflowHierachy 등록
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType AddWorkflowHierachy(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SchemeCode", SchemeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_AddWorkflowSchemeInXml", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region ModifyWorkflowHierachyMemberCount: WorkflowHierachy의 담당자 수 수정

        /**********************************************************************************************
         * Mehtod   명 : ModifyWorkflowHierachyMemberCount
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-22
         * 용       도 : WorkflowHierachy에 따른 Sequence 조회
         * Input    값 : ModifyWorkflowHierachyMemberCount(Scheme Code, Scheme별 Sequence, 배정된담당자수)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// ModifyWorkflowHierachyMemberCount: WorkflowHierachy에 따른 Sequence 조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <param name="SchemeSeq">Scheme별 Sequence</param>
        /// <param name="MemberCount">배정된담당자수</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType ModifyWorkflowHierachyMemberCount(string SchemeCode, int SchemeSeq, Dictionary<int, int> MemberList)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            foreach (var Member in MemberList)
            {
                // Compose parameters
                List<SqlParameter> paramList = new List<SqlParameter>();

                paramList.Add(new SqlParameter("@SchemeCode", SchemeCode));
                paramList.Add(new SqlParameter("@SchemeSeq", SchemeSeq));
                paramList.Add(new SqlParameter("@SchemeDetSeq", Member.Key));
                paramList.Add(new SqlParameter("@MemberCount", Member.Value));

                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflowHierachyMember", paramList.ToArray());
                result.IsSuccessful = true;
            }

            return result;
        }

        #endregion

        #endregion

        #region | WORKFLOW POSITION TITLE SETTING |

        #region GetWorkflowHierachyInCharge : WorkflowHierachy 인력배정용 목록조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowHierachyInCharge
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-22
         * 용       도 : WorkflowHierachy 인력배정용 목록조회
         * Input    값 : GetWorkflowHierachyInCharge(Scheme Code, Scheme Sequence)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowHierachyInCharge : WorkflowHierachy 인력배정용 목록조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <param name="SchemeSeq">Scheme Sequence</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowHierachyInCharge(string SchemeCode, int SchemeSeq)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SchemeCode", SchemeCode));
            parameters.Add(new SqlParameter("@SchemeSeq", SchemeSeq));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowHierachyInCharge", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region AddWorkflowRoleTitle : WorkflowRoleTitle 테이블에 부여된 타이틀을 등록한다.

        /**********************************************************************************************
         * Mehtod   명 : AddWorkflowRoleTitle
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : WorkflowRoleTitle 테이블에 부여된 타이틀을 등록한다.
         * Input    값 : AddWorkflowRoleTitle(TransitionDs 데이터셋, 등록자ID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// AddWorkflowRoleTitle : WorkflowRoleTitle 테이블에 부여된 타이틀을 등록한다.
        /// </summary>
        /// <param name="TransitionDsLst">TransitionDs 데이터셋</param>
        /// <param name="CreateBy">등록자ID</param>
        /// <returns>TransitionStatusDetSeq</returns>
        public int AddWorkflowRoleTitle(List<TypeTransition> TransitionDsLst, string CreateBy)
        {
            int result = 0;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // 기존 정보 삭제
            foreach (TypeTransition item in TransitionDsLst)
            {
                List<SqlParameter> parameterDel = new List<SqlParameter>();

                // wfp_RemoveWorkflowRoleTitle
                parameterDel.Add(new SqlParameter("@TransitionStatusSeq", item.Row));

                SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_RemoveWorkflowRoleTitle", parameterDel.ToArray());
            }

            // 새로운 행 추가
            foreach (TypeTransition item in TransitionDsLst)
            {
                List<SqlParameter> parameterAdd = new List<SqlParameter>();

                parameterAdd.Add(new SqlParameter("@TransitionStatusSeq", item.Row));
                parameterAdd.Add(new SqlParameter("@TransitionStatusDetSeq", 0));
                parameterAdd.Add(new SqlParameter("@PositionTitle", item.UserId));
                parameterAdd.Add(new SqlParameter("@CreateBy", CreateBy));

                DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_AddWorkflowRoleTitle", parameterAdd.ToArray());

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = Int32.Parse(ds.Tables[0].Rows[0]["TransitionStatusDetSeq"].ToString());
                    }
                }
            }

            // return
            return result;
        }

        #endregion

        #region GetWorkflowRoleTitle : WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowRoleTitle
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.
         * Input    값 : GetWorkflowRoleTitle(Scheme Code, Scheme Sequence)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowRoleTitle : WorkflowRoleTitle 테이블에 부여된 타이틀을 등록한다.
        /// </summary>
        /// <param name="SchemeCode">SchemeSeq</param>
        /// <param name="SchemeSeq">SchemeSeq</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowRoleTitle(string SchemeCode, int SchemeSeq)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@SchemeCode", SchemeCode));
            parameter.Add(new SqlParameter("@SchemeSeq", SchemeSeq));

            DataSet dsTitle = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowRoleTitle", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(dsTitle.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;

            return result;
        }

        #endregion

        #endregion

        #region | WORKFLOW IN-CHARGE SETTING |

        #region GetSigmaUserListWithoutMe : SigmaUser 테이블에서 해당인을 제외한 나머지 대상을 조회한다.

        /**********************************************************************************************
         * Mehtod   명 : GetSigmaUserListWithoutMe
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-27
         * 용       도 : SigmaUser 테이블에서 해당인을 제외한 나머지 대상을 조회한다.
         * Input    값 : GetSigmaUserListWithoutMe(SigmaUserID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetSigmaUserListWithoutMe : SigmaUser 테이블에서 해당인을 제외한 나머지 대상을 조회한다.
        /// </summary>
        /// <param name="SigmaUserID">SigmaUserID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetSigmaUserListWithoutMe(string SigmaUserID)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@SigmaUserId", SigmaUserID));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserListWithoutMe", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region AddWorkflowInitalInfo : Workflow 관련 테이블에 기본 정보들을 등록한다.

        /**********************************************************************************************
         * Mehtod   명 : AddWorkflowInitalInfo
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-24
         * 용       도 : Workflow 관련 테이블에 기본 정보들을 등록한다.
         * Input    값 : AddWorkflowInitalInfo(Scheme Code, Scheme Sequence, TransitionStatus순번, 상세순번, 담당자순번, 담당자ID, 업무ID, 
         *                                     상태코드(Y:승인, N:대기; X:거부), 패키지타입코드, 각패키지별ID, IWP ID)
         * Ouput    값 : Document용 Guid
         **********************************************************************************************/
        /// <summary>
        /// AddWorkflowInitalInfo : Workflow 관련 테이블에 기본 정보들을 등록한다.
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <param name="SchemeSeq">Scheme Sequence</param>
        /// <param name="TransitionStatusSeq">TransitionStatus순번</param>
        /// <param name="LoginIdRole">기안자RoleId</param>
        /// <param name="LoginID">기안자ID</param>
        /// <param name="TransitionLst">각단계별승인자정보</param>
        /// <param name="Title">기안제목</param>
        /// <param name="Context">기안내용</param>
        /// <param name="Comment">기안자코멘트</param>
        /// <param name="WorkflowTypeCode">Workflow타입코드</param>
        /// <param name="TargetId">각패키지별ID</param>
        /// <param name="IwpId">Iwp ID</param>
        /// <returns>Document용Guid</returns>
        public string AddWorkflowInitalInfo(string SchemeCode, int SchemeSeq, int TransitionStatusSeq, string LoginID,
                                            List<TypeTransition> TransitionLst, string Title, string Context, string Comment, string WorkflowTypeCode, int TargetId, int IwpId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            string strReturn = string.Empty;
            string strInstance = string.Empty;
            string strControllerUserId = string.Empty;

            int intControllerRoleId = 0;

            // TransitionStatus의 Seq값을 모를 경우(0인 경우) SchemeCode와 SchemeSeq를 가지고 조회함.
            if (TransitionStatusSeq == 0)
            {
                List<SqlParameter> parameterTransitionStatus = new List<SqlParameter>();

                parameterTransitionStatus.Add(new SqlParameter("@SchemeCode", SchemeCode));
                parameterTransitionStatus.Add(new SqlParameter("@SchemeSeq", SchemeSeq));
                parameterTransitionStatus.Add(new SqlParameter("@SchemeDetSeq", 0));

                DataSet dsTransitionStatus = SqlHelper.ExecuteDataset(connStr, "wfp_GetTransitionStatusSeq", parameterTransitionStatus.ToArray());

                if (dsTransitionStatus != null)
                {
                    if (dsTransitionStatus.Tables[0].Rows.Count > 0)
                    {
                        TransitionStatusSeq = Int32.Parse(dsTransitionStatus.Tables[0].Rows[0]["TransitionStatusSeq"].ToString());
                    }
                }
            }

            // Process Name 정보 조회
            List<SqlParameter> parameterInstance = new List<SqlParameter>();

            parameterInstance.Add(new SqlParameter("@SchemeCode", SchemeCode));

            DataSet dsInstance = SqlHelper.ExecuteDataset(connStr, "wfp_GetProcessNameBySchemeCode", parameterInstance.ToArray());

            if (dsInstance != null)
            {
                if (dsInstance.Tables[0].Rows.Count > 0)
                {
                    strInstance = dsInstance.Tables[0].Rows[0]["ProcessName"].ToString();
                }
            }

            // 최종 책임자 정보 조회
            foreach (TypeTransition tr in TransitionLst)
            {
                strControllerUserId = tr.UserId;
                intControllerRoleId = tr.Role;
            }

            if (string.IsNullOrEmpty(Title))
            {
                Title = SchemeCode + "-" + TargetId.ToString() + "-" + IwpId.ToString();
            }

            // Workflow 본 테이블에 정보 등록
            List<SqlParameter> parameterWorkflow = new List<SqlParameter>();

            parameterWorkflow.Add(new SqlParameter("@SigmaUserId", LoginID));
            parameterWorkflow.Add(new SqlParameter("@WorkFlowName", Title));
            parameterWorkflow.Add(new SqlParameter("@WorkflowContext", Context));
            parameterWorkflow.Add(new SqlParameter("@ControllerUserId", strControllerUserId));
            parameterWorkflow.Add(new SqlParameter("@ControllerRoleId", intControllerRoleId));
            parameterWorkflow.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));
            parameterWorkflow.Add(new SqlParameter("@TargetId", TargetId));
            parameterWorkflow.Add(new SqlParameter("@IwpId", IwpId));

            DataSet dsWorkflow = SqlHelper.ExecuteDataset(connStr, "wfp_AddWorkflow", parameterWorkflow.ToArray());

            if (dsWorkflow != null)
            {
                if (dsWorkflow.Tables[0].Rows.Count > 0)
                {
                    string strDocGuiD = dsWorkflow.Tables[0].Rows[0]["WorkflowId"].ToString();

                    Guid uiDocID = new Guid(strDocGuiD);

                    // WorkflowProcess 테이블에 Process 정보 등록
                    List<SqlParameter> parameterProcess = new List<SqlParameter>();

                    parameterProcess.Add(new SqlParameter("@WorkflowGuid", uiDocID));
                    parameterProcess.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));

                    DataSet dsProcess = SqlHelper.ExecuteDataset(connStr, "wfp_AddWorkflowProcess", parameterProcess.ToArray());

                    if (dsProcess != null)
                    {
                        if (dsProcess.Tables[0].Rows.Count > 0)
                        {
                            // WorkflowTransitionHistory 테이블에 기안자 관련 정보 등록
                            List<SqlParameter> parameterHistory = new List<SqlParameter>();

                            parameterHistory.Add(new SqlParameter("@WorkflowGuid", uiDocID));
                            parameterHistory.Add(new SqlParameter("@TransitionStatusSeq", TransitionStatusSeq));
                            parameterHistory.Add(new SqlParameter("@TransitionStatusDetSeq", 0));
                            parameterHistory.Add(new SqlParameter("@SigmaUserId", LoginID));
                            parameterHistory.Add(new SqlParameter("@SigmaRoleId", 0));
                            parameterHistory.Add(new SqlParameter("@Comment", Comment));
                            parameterHistory.Add(new SqlParameter("@ProcessStatus", "N"));

                            DataSet dsHistory = SqlHelper.ExecuteDataset(connStr, "wfp_AddWorkflowTransitionHistory", parameterHistory.ToArray());

                            if (dsHistory != null)
                            {
                                if (dsHistory.Tables[0].Rows.Count > 0)
                                {
                                    int intTransitionStatusDetSeq = Int32.Parse(dsHistory.Tables[0].Rows[0]["TransitionStatusDetSeq"].ToString());

                                    foreach (TypeTransition tr in TransitionLst)
                                    {
                                        // WorkflowTransitionHistory 테이블에 담당자 관련 정보 등록
                                        List<SqlParameter> parameterInCharge = new List<SqlParameter>();

                                        parameterInCharge.Add(new SqlParameter("@WorkflowGuid", uiDocID));
                                        parameterInCharge.Add(new SqlParameter("@TransitionStatusSeq", TransitionStatusSeq + tr.Row + 1));
                                        parameterInCharge.Add(new SqlParameter("@TransitionStatusDetSeq", 0));
                                        parameterInCharge.Add(new SqlParameter("@SigmaUserId", tr.UserId));
                                        parameterInCharge.Add(new SqlParameter("@SigmaRoleId", tr.Role));
                                        parameterInCharge.Add(new SqlParameter("@Comment", ""));
                                        parameterInCharge.Add(new SqlParameter("@ProcessStatus", "N"));

                                        DataSet dsInCharge = SqlHelper.ExecuteDataset(connStr, "wfp_AddWorkflowTransitionHistory", parameterInCharge.ToArray());

                                        if (dsInCharge != null)
                                        {
                                            if (dsInCharge.Tables[0].Rows.Count > 0)
                                            {
                                                strReturn = dsInCharge.Tables[0].Rows[0]["TransitionStatusDetSeq"].ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return strReturn;
        }

        #endregion

        #endregion

        #region | WORKFLOW SUBMIT AND REVIEW |

        #region GetSigmaUser: SigmaUser 목록조회

        /**********************************************************************************************
         * Mehtod   명 : GetSigmaUser
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-13
         * 용       도 : SigmaUser 목록조회
         * Input    값 : GetSigmaUser()
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetSigmaUser: 등록된SigmaUser 목록조회
        /// </summary>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetSigmaUser()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserList");

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region GetWorkflowTransitionHistoryList : WorkflowTransitionHistory 목록을 조회함.

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowTransitionHistoryList
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-27
         * 용       도 : WorkflowTransitionHistory 목록을 조회함.
         * Input    값 : GetWorkflowTransitionHistoryList(사용자Guid, 시작일, 종료일, 결재여부(N-Pending, Y-Accept Or Denial))
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowTransitionHistoryList : WorkflowTransitionHistory 목록을 조회함.
        /// </summary>
        /// <param name="UserGuid">사용자Guid</param>
        /// <param name="StartDt">시작일</param>
        /// <param name="EndDt">종료일</param>
        /// <param name="IsProcessStatus">결재여부(N-Pending, Y-Accept Or Denial)</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowTransitionHistoryList(Guid UserGuid, string StartDt, string EndDt, string IsProcessStatus)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@UserGuiD", UserGuid));
            parameter.Add(new SqlParameter("@StartDt", StartDt));
            parameter.Add(new SqlParameter("@EndDt", EndDt));
            parameter.Add(new SqlParameter("@IsProcessStatus", IsProcessStatus));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowTransitionHistoryList", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowTransitionHistoryList
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-27
         * 용       도 : WorkflowTransitionHistory 목록을 조회함.
         * Input    값 : GetWorkflowTransitionHistoryList(사용자ID, 시작일, 종료일, 결재여부(N-Pending, Y-Accept Or Denial))
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowTransitionHistoryList : WorkflowTransitionHistory 목록을 조회함.
        /// </summary>
        /// <param name="UserId">사용자ID</param>
        /// <param name="StartDt">시작일</param>
        /// <param name="EndDt">종료일</param>
        /// <param name="IsProcessStatus">결재여부(N-Pending, Y-Accept Or Denial)</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowTransitionHistoryList(string UserId, string StartDt, string EndDt, string IsProcessStatus)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameterEmail = new List<SqlParameter>();

            parameterEmail.Add(new SqlParameter("@SigmaUserId", UserId));

            DataSet dsEmail = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserByUserId", parameterEmail.ToArray());

            if (dsEmail != null)
            {
                if (dsEmail.Tables[0].Rows.Count > 0)
                {
                    Guid uiUserGuid = new Guid(dsEmail.Tables[0].Rows[0]["SigmaUserGuid"].ToString());

                    List<SqlParameter> parameter = new List<SqlParameter>();

                    parameter.Add(new SqlParameter("@UserGuiD", uiUserGuid));
                    parameter.Add(new SqlParameter("@StartDt", StartDt));
                    parameter.Add(new SqlParameter("@EndDt", EndDt));
                    parameter.Add(new SqlParameter("@IsProcessStatus", IsProcessStatus));

                    DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowTransitionHistoryList", parameter.ToArray());

                    // Convert to REST/JSON String
                    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
                    result.AffectedRow = 1;
                    result.IsSuccessful = true;
                }
            }

            // return
            return result;
        }

        #endregion

        #region GetWorkflowTransitionHistory : WorkflowTransitionHistory 상세내용을 조회함.

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowTransitionHistory
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-27
         * 용       도 : WorkflowTransitionHistory 상세내용을 조회함.
         * Input    값 : GetWorkflowTransitionHistory(User의 ID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowTransitionHistory : WorkflowTransitionHistory 상세내용을 조회함.
        /// </summary>
        /// <param name="processId">작성한 Process GuID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowTransitionHistory(Guid processId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@ProcessGuiD", processId));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowTransitionHistory", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region GetSigmaUserByUserId : 해당 ID를 가지고 있는 사용자 조회

        /**********************************************************************************************
         * Mehtod   명 : GetSigmaUserByUserId
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-26
         * 용       도 : 해당 ID를 가지고 있는 사용자 조회
         * Input    값 : GetSigmaUserByUserId(User의 ID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetSigmaUserByUserId : 해당 ID를 가지고 있는 사용자 조회
        /// </summary>
        /// <param name="SigmaUserId">User의 ID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetSigmaUserByUserId(string SigmaUserId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@SigmaUserId", SigmaUserId));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserByUserId", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion
        
        #region GetSigmaUserCommand : WorkflowRoleHierachy 테이블에서 해당인의 가능한 명령어를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetSigmaUserCommand
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-27
         * 용       도 : WorkflowRoleHierachy 테이블에서 해당인의 가능한 명령어를 가져온다.
         * Input    값 : GetSigmaUserCommand(사용자의 GuiD, Process의 GuiD, 순번)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetSigmaUserCommand : WorkflowRoleHierachy 테이블에서 해당인의 가능한 명령어를 가져온다.
        /// </summary>
        /// <param name="SigmaUserGuid">사용자의 GuiD</param>
        /// <param name="ProcessGuId">해당Process의 GuiD</param>
        /// <param name="Order">순번</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetSigmaUserCommand(Guid SigmaUserGuid, Guid ProcessGuId, int Order)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@SigmaUserGuid", SigmaUserGuid));
            parameter.Add(new SqlParameter("@ProcessId", ProcessGuId));
            parameter.Add(new SqlParameter("@Order", Order));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserCommand", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region ConfirmUsersOpinion : 해당 Workflow에 대한 의견을 확정한다.

        /**********************************************************************************************
         * Mehtod   명 : ConfirmUsersOpinion
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-22
         * 용       도 : WorkflowHierachy 인력배정용 목록조회
         * Input    값 : ConfirmUsersOpinion(제네레이터명, 작성한 Process Guid, 처리명령코드, 현사용자, 처리명령어, 비고)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// ConfirmUsersOpinion : WorkflowHierachy 목록조회
        /// </summary>
        /// <param name="SchemeCode">제네레이터명</param>
        /// <param name="ProcessGuid">작성한 Process Guid</param>
        /// <param name="ProcessStatusYn">처리명령코드</param>
        /// <param name="iuUser">승인자Guid</param>
        /// <param name="commandName">처리명령어</param>
        /// <param name="Comment">비고</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType ConfirmUsersOpinion(string SchemeCode, Guid ProcessGuid, string ProcessStatusYn, Guid iuUser, string commandName, string Comment)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            string strInstance = string.Empty;
            string strComment = string.Empty;
            string strCommandName = string.Empty;
            int intOrderCode;

            // 빈칸생략
            strCommandName = commandName.Replace(" ", "");

            // ProcessName 정보 조회
            List<SqlParameter> parameterInstance = new List<SqlParameter>();

            parameterInstance.Add(new SqlParameter("@SchemeCode", SchemeCode));

            DataSet dsInstance = SqlHelper.ExecuteDataset(connStr, "wfp_GetProcessNameBySchemeCode", parameterInstance.ToArray());

            if (dsInstance != null)
            {
                if (dsInstance.Tables[0].Rows.Count > 0)
                {
                    strInstance = dsInstance.Tables[0].Rows[0]["ProcessName"].ToString();
                }
            }

            if (ProcessStatusYn.ToUpper().Equals("Y"))
            {
                intOrderCode = WORKFLOW_STATUS_APPROVAL;
            }
            else if (ProcessStatusYn.ToUpper().Equals("X"))
            {
                intOrderCode = WORKFLOW_STATUS_DENIAL;
            }
            else
            {
                intOrderCode = WORKFLOW_STATUS_PENDING;
            }

            using (var scope = new TransactionScope())
            {
                // WorkflowTransitionHistory 테이블에 의사결정정보를 등록
                List<SqlParameter> paramHistoryStatus = new List<SqlParameter>();

                paramHistoryStatus.Add(new SqlParameter("@WorkflowGuid", ProcessGuid));
                paramHistoryStatus.Add(new SqlParameter("@SigmaUserGuid", iuUser));
                paramHistoryStatus.Add(new SqlParameter("@Comment", Comment));
                paramHistoryStatus.Add(new SqlParameter("@ProcessStatusYn", ProcessStatusYn));

                SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflowTransitionHistoryStatus", paramHistoryStatus.ToArray());

                // WorkflowProcess 테이블의 STATUS를 수정
                List<SqlParameter> paramProcess = new List<SqlParameter>();

                paramProcess.Add(new SqlParameter("@WorkflowGuid", ProcessGuid));

                SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflowProcess", paramProcess.ToArray());

                // WorkflowProcessHistory 테이블에 상태값을 등록
                List<SqlParameter> paramHistory = new List<SqlParameter>();

                paramHistory.Add(new SqlParameter("@WorkflowGuid", ProcessGuid));
                paramHistory.Add(new SqlParameter("@SigmaUserGuid", iuUser));
                paramHistory.Add(new SqlParameter("@OrderCode", intOrderCode));

                SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflowProcessHistory", paramHistory.ToArray());

                // Workflow 테이블에 상태값을 수정한다.
                List<SqlParameter> paramWorkflowStatus = new List<SqlParameter>();

                paramWorkflowStatus.Add(new SqlParameter("@WorkflowGuid", ProcessGuid));
                paramWorkflowStatus.Add(new SqlParameter("@SigmaUserGuid", iuUser));
                paramWorkflowStatus.Add(new SqlParameter("@OrderCode", intOrderCode));
                
                SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflow", paramWorkflowStatus.ToArray());

                scope.Complete();
            }

            // 다음 단계의 사용자에게 메일을 보냄
            // 메일보내기 시작
            // 1. 거부인지 상신인지 아닌지 확인.
            if (strCommandName.ToLower().Equals("denial"))
            {
                #region | DENIAL |

                // 1-1. 거부일 경우 기안자에게 메일을 보냄
                List<SqlParameter> parameterDenyMail = new List<SqlParameter>();

                parameterDenyMail.Add(new SqlParameter("@WorkflowId", ProcessGuid));

                DataSet dsDenyMail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailAppliedGuid", parameterDenyMail.ToArray());

                if (dsDenyMail != null)
                {
                    if (dsDenyMail.Tables[0].Rows.Count > 0)
                    {
                        List<SqlParameter> parameterMail = new List<SqlParameter>();

                        parameterMail.Add(new SqlParameter("@WorkflowId", ProcessGuid));
                        parameterMail.Add(new SqlParameter("@SigmaUserGuId", iuUser));

                        DataSet dsEmail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailSigmaUserGuID", parameterMail.ToArray());

                        if (dsEmail != null)
                        {
                            if (dsEmail.Tables[0].Rows.Count > 0)
                            {
                                // 사용할 이메일 문구 조회함.
                                // wfp_GetEmailText
                                DataTable dtEmailReturn = GetEmailText(dsEmail.Tables[0].Rows[0]["WorkflowCode"].ToString(), "", "");

                                if (dtEmailReturn != null)
                                {
                                    if (dtEmailReturn.Rows.Count > 0)
                                    {
                                        MailMessage mail = new MailMessage();
                                        // mail.From = new MailAddress("보내는 사람 메일 주소", "보내는 사람 이름", System.Text.Encoding.UTF8);
                                        // mail.From = new MailAddress(dsEmail.Tables[0].Rows[0]["SigmaUserEmail"].ToString(), dsEmail.Tables[0].Rows[0]["SigmaUserName"].ToString(), System.Text.Encoding.UTF8);
                                        mail.From = new MailAddress("no-reply@elementindustrial.com", "Sigma Service", System.Text.Encoding.UTF8);
                                        // mail.To.Add("받는 사람 메일 주소");

                                        foreach (DataRow dr in dsEmail.Tables[0].Select())
                                        {
                                            // mail.To.Add("받는 사람 메일 주소");
                                            mail.To.Add(dr["SigmaUserEmail"].ToString());
                                        }

                                        mail.IsBodyHtml = true;

                                        if (!string.IsNullOrEmpty(Comment))
                                        {
                                            strComment = "Comment : " + Comment;
                                        }

                                        string[] strEmailReturn = GetEmailText(dtEmailReturn, "REJECT", dsEmail.Tables[0], dsEmail.Tables[0].Rows[0]["WorkflowTitle"].ToString(), dsEmail.Tables[0].Rows[dsEmail.Tables[0].Rows.Count - 1]["SigmaUserName"].ToString(), dsDenyMail.Tables[0].Rows[0]["SigmaUserName"].ToString(), Comment);

                                        mail.Subject = strEmailReturn[0];
                                        mail.Body = strEmailReturn[1];
                                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                                        mail.SubjectEncoding = System.Text.Encoding.UTF8;

                                        // 양영석 : SMTP서버가 외부 웹서버일 쓸경우
                                        SmtpClient scClient = new SmtpClient(SMTPServerUrl, Int32.Parse(SMTPServerPort));
                                        scClient.EnableSsl = true; //SSL 설정
                                        scClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        scClient.Credentials = new System.Net.NetworkCredential(SMTPAccessId, SMTPAccessPWD);

                                        // 양영석 : SMTP서버가 자체 웹서버일경우
                                        // SmtpClient scClient = new SmtpClient("웹서버IP", 25);
                                        // scClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                                        // scClient.PickupDirectoryLocation = "C:\\inetpub\\mailroot\\Pickup";

                                        scClient.Send(mail); // 메일 발송
                                        mail.Dispose();

                                        string[] strMsgReturn = GetEmailForm(3, GetWorkFlowType(dsDenyMail.Tables[0].Rows[0]["WorkflowTypeCode"].ToString(), dsDenyMail.Tables[0].Rows[0]["TargetId"].ToString()), dsDenyMail.Tables[0].Rows[0]["SigmaUserName"].ToString(), strComment);

                                        // wfp_AddMessageContext
                                        int intContextSeq = AddMessageContext(strMsgReturn[1]);

                                        // wfp_AddMessageBox
                                        AddMessageBox("MSG_TYPE_MAIL", "[" + dsEmail.Tables[0].Rows[0]["ProjectName"].ToString() + "] " + strMsgReturn[0], dsDenyMail.Tables[0].Rows[0]["SigmaUserId"].ToString(), intContextSeq, dsEmail.Tables[0].Rows[0]["SigmaUserId"].ToString());

                                        // wfp_ModifyDocumentTransitionStatusByUserGuID
                                        // 거부시 기안자에게는 거부시간을 알릴 필요없음.
                                        // ModifyDocumentTransitionStatusByUserGuID(ProcessGuid, iuUser);
                                    }
                                }
                            }
                        }
                    }
                }

                #endregion
            }
            else if (strCommandName.ToLower().Equals("pending"))
            {
                #region | PENDING |

                // 1-2. 보류일 경우 기안자에게 메일을 보냄
                // wfp_GetEmailAppliedGuid
                List<SqlParameter> parameterDenyMail = new List<SqlParameter>();

                parameterDenyMail.Add(new SqlParameter("@WorkflowId", ProcessGuid));

                DataSet dsDenyMail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailAppliedGuid", parameterDenyMail.ToArray());

                if (dsDenyMail != null)
                {
                    if (dsDenyMail.Tables[0].Rows.Count > 0)
                    {
                        // wfp_GetEmailSigmaUserGuID
                        List<SqlParameter> parameterMail = new List<SqlParameter>();

                        parameterMail.Add(new SqlParameter("@WorkflowId", ProcessGuid));
                        parameterMail.Add(new SqlParameter("@SigmaUserGuId", iuUser));

                        DataSet dsEmail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailSigmaUserGuID", parameterMail.ToArray());

                        if (dsEmail != null)
                        {
                            if (dsEmail.Tables[0].Rows.Count > 0)
                            {
                                // 사용할 이메일 문구 조회함.
                                // wfp_GetEmailText
                                DataTable dtEmailReturn = GetEmailText(dsEmail.Tables[0].Rows[0]["WorkflowCode"].ToString(), "", "");

                                if (dtEmailReturn != null)
                                {
                                    if (dtEmailReturn.Rows.Count > 0)
                                    {
                                        MailMessage mail = new MailMessage();
                                        // mail.From = new MailAddress("보내는 사람 메일 주소", "보내는 사람 이름", System.Text.Encoding.UTF8);
                                        mail.From = new MailAddress("no-reply@elementindustrial.com", "Sigma Service", System.Text.Encoding.UTF8);

                                        foreach (DataRow dr in dsEmail.Tables[0].Select())
                                        {
                                            // mail.To.Add("받는 사람 메일 주소");
                                            mail.To.Add(dr["SigmaUserEmail"].ToString());
                                        }

                                        mail.IsBodyHtml = true;

                                        if (!string.IsNullOrEmpty(Comment))
                                        {
                                            strComment = "Comment : " + Comment;
                                        }

                                        string[] strEmailReturn = GetEmailText(dtEmailReturn, "SUSPEND", dsEmail.Tables[0], dsEmail.Tables[0].Rows[0]["WorkflowTitle"].ToString(), dsEmail.Tables[0].Rows[dsEmail.Tables[0].Rows.Count - 1]["SigmaUserName"].ToString(), dsDenyMail.Tables[0].Rows[0]["SigmaUserName"].ToString(), Comment);

                                        mail.Subject = strEmailReturn[0];
                                        mail.Body = strEmailReturn[1];
                                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                                        mail.SubjectEncoding = System.Text.Encoding.UTF8;

                                        // 양영석 : SMTP서버가 외부 웹서버일 쓸경우
                                        SmtpClient scClient = new SmtpClient(SMTPServerUrl, Int32.Parse(SMTPServerPort));
                                        scClient.EnableSsl = true; //SSL 설정
                                        scClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        scClient.Credentials = new System.Net.NetworkCredential(SMTPAccessId, SMTPAccessPWD);

                                        // 양영석 : SMTP서버가 자체 웹서버일경우
                                        // SmtpClient scClient = new SmtpClient("웹서버IP", 25);
                                        // scClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                                        // scClient.PickupDirectoryLocation = "C:\\inetpub\\mailroot\\Pickup";

                                        scClient.Send(mail); // 메일 발송
                                        mail.Dispose();

                                        // 메세지 처리용도
                                        // E-Mail 처리방식이 바뀌어 이름변경없이 기존 메세지만 활용함.
                                        string[] strMsgReturn = GetEmailForm(4, GetWorkFlowType(dsDenyMail.Tables[0].Rows[0]["WorkflowTypeCode"].ToString(), dsDenyMail.Tables[0].Rows[0]["TargetId"].ToString()), dsDenyMail.Tables[0].Rows[0]["SigmaUserName"].ToString(), strComment);

                                        // wfp_AddMessageContext
                                        int intContextSeq = AddMessageContext(strMsgReturn[1]);

                                        // wfp_AddMessageBox
                                        AddMessageBox("MSG_TYPE_MAIL", "[" + dsEmail.Tables[0].Rows[0]["ProjectName"].ToString() + "] " + strMsgReturn[0], dsDenyMail.Tables[0].Rows[0]["SigmaUserId"].ToString(), intContextSeq, dsEmail.Tables[0].Rows[0]["SigmaUserId"].ToString());

                                        // wfp_ModifyDocumentTransitionStatusByUserGuID
                                        // 펜딩시 기안자에게는 보류시간을 알릴 필요없음.
                                        // ModifyDocumentTransitionStatusByUserGuID(ProcessGuid, iuUser);
                                    }
                                }
                            }
                        }
                    }
                }

                #endregion
            }
            else if (strCommandName.ToLower().Equals("startprocessing"))
            {
                #region | START PROCESSING |

                // 1-3. 상신일 경우 1번째 승인자에게 메일을 보냄
                // wfp_GetEmailSigmaUserGuID
                List<SqlParameter> parameterMail = new List<SqlParameter>();

                parameterMail.Add(new SqlParameter("@WorkflowId", ProcessGuid));
                parameterMail.Add(new SqlParameter("@SigmaUserID", iuUser));

                DataSet dsEmail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailSigmaUserGuID", parameterMail.ToArray());

                if (dsEmail != null)
                {
                    if (dsEmail.Tables[0].Rows.Count > 0)
                    {
                        // 사용할 이메일 문구 조회함.
                        // wfp_GetEmailText
                        DataTable dtEmailReturn = GetEmailText(dsEmail.Tables[0].Rows[0]["WorkflowCode"].ToString(), "", "REQUEST");

                        if (dtEmailReturn != null)
                        {
                            if (dtEmailReturn.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dsEmail.Tables[1].Select())
                                {
                                    // 메일보내기 시작
                                    MailMessage mail = new MailMessage();
                                    // mail.From = new MailAddress("보내는 사람 메일 주소", "보내는 사람 이름", System.Text.Encoding.UTF8);
                                    mail.From = new MailAddress("no-reply@elementindustrial.com", "Sigma Service", System.Text.Encoding.UTF8);
                                    // mail.To.Add("받는 사람 메일 주소");
                                    mail.To.Add(dr["SigmaUserEmail"].ToString());
                                    mail.IsBodyHtml = true;

                                    if (!string.IsNullOrEmpty(Comment))
                                    {
                                        strComment = "Comment : " + Comment;
                                    }

                                    string[] strEmailReturn = GetEmailText(dtEmailReturn, dsEmail.Tables[0].Rows[0]["WorkflowTitle"].ToString(), "Sigma Service", dr["SigmaUserName"].ToString(), strComment);

                                    mail.Subject = strEmailReturn[0];
                                    mail.Body = strEmailReturn[1];
                                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                                    // 양영석 : SMTP서버가 외부 웹서버일 쓸경우
                                    SmtpClient scClient = new SmtpClient(SMTPServerUrl, Int32.Parse(SMTPServerPort));
                                    scClient.EnableSsl = true; //SSL 설정
                                    scClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    scClient.Credentials = new System.Net.NetworkCredential(SMTPAccessId, SMTPAccessPWD);

                                    // 양영석 : SMTP서버가 자체 웹서버일경우
                                    // SmtpClient scClient = new SmtpClient("웹서버IP", 25);
                                    // scClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                                    // scClient.PickupDirectoryLocation = "C:\\inetpub\\mailroot\\Pickup";

                                    scClient.Send(mail); // 메일 발송
                                    mail.Dispose();
                                    // 메일보내기 끝

                                    string[] strMsgReturn = GetEmailForm(1, GetWorkFlowType(dr["PackageTypeCode"].ToString(), dr["TargetId"].ToString()), dr["SigmaUserName"].ToString(), strComment);

                                    // wfp_AddMessageContext
                                    int intContextSeq = AddMessageContext(strMsgReturn[1]);

                                    // wfp_AddMessageBox
                                    AddMessageBox("MSG_TYPE_MAIL", "[" + dsEmail.Tables[0].Rows[0]["ProjectName"].ToString() + "] " + strMsgReturn[0], dr["SigmaUserId"].ToString(), intContextSeq, dsEmail.Tables[0].Rows[0]["SigmaUserId"].ToString());

                                    // wfp_ModifyWorkflowTransitionHistoryReceived
                                    List<SqlParameter> paramHistoryReceived = new List<SqlParameter>();

                                    paramHistoryReceived.Add(new SqlParameter("@WorkflowGuid", ProcessGuid));
                                    paramHistoryReceived.Add(new SqlParameter("@SigmaUserGuid", new Guid(dr["SigmaUserGuid"].ToString())));

                                    SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflowTransitionHistoryReceived", paramHistoryReceived.ToArray());
                                }
                            }
                        }
                    }
                }

                #endregion
            }
            else
            {
                // 1-4. 승인일 경우 모두 승인했는지 확인.
                // wfp_GetEmailAppliedGuid
                List<SqlParameter> parameterAgreeMail = new List<SqlParameter>();

                parameterAgreeMail.Add(new SqlParameter("@WorkflowId", ProcessGuid));

                DataSet dsAgreeMail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailAppliedGuid", parameterAgreeMail.ToArray());

                if (dsAgreeMail != null)
                {
                    if (dsAgreeMail.Tables[0].Rows.Count > 0)
                    {
                        // 1-4-1. 모두 승인일 겨우 다음 단계를 확인할 것.
                        if (dsAgreeMail.Tables[0].Rows[0]["EmailToNext"].Equals("Y"))
                        {
                            List<SqlParameter> parameterMail = new List<SqlParameter>();

                            parameterMail.Add(new SqlParameter("@WorkflowId", ProcessGuid));
                            parameterMail.Add(new SqlParameter("@SigmaUserGuId", iuUser));

                            DataSet dsEmail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailSigmaUserGuID", parameterMail.ToArray());

                            if (dsEmail.Tables[1].Rows.Count > 0)
                            {
                                #region | Send Request |

                                // 사용할 이메일 문구 조회함.
                                // wfp_GetEmailText
                                DataTable dtEmailReturn = GetEmailText(dsEmail.Tables[0].Rows[0]["WorkflowCode"].ToString(), "", "");

                                if (dtEmailReturn != null)
                                {
                                    if (dtEmailReturn.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in dsEmail.Tables[1].Select())
                                        {
                                            // 1-4-1-1. 다음 단계가 남아있을 경우 대상자에게 메일을 보냄
                                            MailMessage mail = new MailMessage();
                                            mail.From = new MailAddress("no-reply@elementindustrial.com", "Sigma Service", System.Text.Encoding.UTF8);
                                            mail.To.Add(dr["SigmaUserEmail"].ToString());
                                            mail.IsBodyHtml = true;

                                            if (!string.IsNullOrEmpty(Comment))
                                            {
                                                strComment = "Comment : " + Comment;
                                            }

                                            string[] strEmailReturn = GetEmailText(dtEmailReturn, "REQUEST", dsEmail.Tables[0], dsEmail.Tables[0].Rows[0]["WorkflowTitle"].ToString(), "Sigma Service", dr["SigmaUserName"].ToString(), Comment);

                                            mail.Subject = strEmailReturn[0];
                                            mail.Body = strEmailReturn[1];
                                            mail.BodyEncoding = System.Text.Encoding.UTF8;
                                            mail.SubjectEncoding = System.Text.Encoding.UTF8;

                                            // 양영석 : SMTP서버가 외부 웹서버일 쓸경우
                                            SmtpClient scClient = new SmtpClient(SMTPServerUrl, Int32.Parse(SMTPServerPort));
                                            scClient.EnableSsl = true; //SSL 설정
                                            scClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                            scClient.Credentials = new System.Net.NetworkCredential(SMTPAccessId, SMTPAccessPWD);

                                            // 양영석 : SMTP서버가 자체 웹서버일경우
                                            // SmtpClient scClient = new SmtpClient("웹서버IP", 25);
                                            // scClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                                            // scClient.PickupDirectoryLocation = "C:\\inetpub\\mailroot\\Pickup";

                                            scClient.Send(mail); // 메일 발송
                                            mail.Dispose();
                                            // 메일보내기 끝

                                            string[] strMsgReturn = GetEmailForm(1, GetWorkFlowType(dr["PackageTypeCode"].ToString(), dr["TargetId"].ToString()), dr["SigmaUserName"].ToString(), Comment);

                                            // wfp_AddMessageContext
                                            int intContextSeq = AddMessageContext(strMsgReturn[1]);

                                            // wfp_AddMessageBox
                                            AddMessageBox("MSG_TYPE_MAIL", "[" + dsEmail.Tables[0].Rows[0]["ProjectName"].ToString() + "] " + strMsgReturn[0], dr["SigmaUserId"].ToString(), intContextSeq, dsEmail.Tables[0].Rows[0]["SigmaUserId"].ToString());

                                            // wfp_ModifyWorkflowTransitionHistoryReceived
                                            List<SqlParameter> paramHistoryReceived = new List<SqlParameter>();

                                            paramHistoryReceived.Add(new SqlParameter("@WorkflowGuid", ProcessGuid));
                                            paramHistoryReceived.Add(new SqlParameter("@SigmaUserGuid", new Guid(dr["SigmaUserGuid"].ToString())));

                                            SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflowTransitionHistoryReceived", paramHistoryReceived.ToArray());
                                        }
                                    }
                                }

                                #endregion
                            }
                            else
                            {
                                #region | Completed |

                                // 사용할 이메일 문구 조회함.
                                // wfp_GetEmailText
                                DataTable dtEmailReturn = GetEmailText(dsEmail.Tables[0].Rows[0]["WorkflowCode"].ToString(), "", "");

                                if (dtEmailReturn != null)
                                {
                                    if (dtEmailReturn.Rows.Count > 0)
                                    {
                                        // 1-4-1-2. 다음 단계가 없을 경우 기안자에게 메일을 보냄
                                        MailMessage mail = new MailMessage();
                                        // mail.From = new MailAddress("보내는 사람 메일 주소", "보내는 사람 이름", System.Text.Encoding.UTF8);
                                        mail.From = new MailAddress("no-reply@elementindustrial.com", "Sigma Service", System.Text.Encoding.UTF8);
                                        // mail.To.Add("받는 사람 메일 주소");
                                        mail.To.Add(dsAgreeMail.Tables[0].Rows[0]["SigmaUserEmail"].ToString());
                                        mail.IsBodyHtml = true;

                                        string[] strEmailReturn = GetEmailText(dtEmailReturn, "COMPLETE", dsEmail.Tables[0], dsEmail.Tables[0].Rows[0]["WorkflowTitle"].ToString(), dsEmail.Tables[0].Rows[dsEmail.Tables[0].Rows.Count - 1]["SigmaUserName"].ToString(), dsAgreeMail.Tables[0].Rows[0]["SigmaUserName"].ToString(), Comment);

                                        mail.Subject = strEmailReturn[0];
                                        mail.Body = strEmailReturn[1];
                                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                                        mail.SubjectEncoding = System.Text.Encoding.UTF8;

                                        // 양영석 : SMTP서버가 외부 웹서버일 쓸경우
                                        SmtpClient scClient = new SmtpClient(SMTPServerUrl, Int32.Parse(SMTPServerPort));
                                        scClient.EnableSsl = true; //SSL 설정
                                        scClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        scClient.Credentials = new System.Net.NetworkCredential(SMTPAccessId, SMTPAccessPWD);

                                        // 양영석 : SMTP서버가 자체 웹서버일경우
                                        // SmtpClient scClient = new SmtpClient("웹서버IP", 25);
                                        // scClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                                        // scClient.PickupDirectoryLocation = "C:\\inetpub\\mailroot\\Pickup";

                                        scClient.Send(mail); // 메일 발송
                                        mail.Dispose();
                                        // 메일보내기 끝

                                        // wfp_GetEmailForm
                                        string[] strMsgReturn = GetEmailForm(2, GetWorkFlowType(dsAgreeMail.Tables[0].Rows[0]["WorkflowTypeCode"].ToString(), dsAgreeMail.Tables[0].Rows[0]["TargetId"].ToString()), dsAgreeMail.Tables[0].Rows[0]["SigmaUserName"].ToString(), "");

                                        // wfp_AddMessageContext
                                        int intContextSeq = AddMessageContext(strMsgReturn[1]);

                                        // wfp_AddMessageBox
                                        AddMessageBox("MSG_TYPE_MAIL", "[" + dsEmail.Tables[0].Rows[0]["ProjectName"].ToString() + "] " + strMsgReturn[0], dsAgreeMail.Tables[0].Rows[0]["SigmaUserId"].ToString(), intContextSeq, dsEmail.Tables[0].Rows[0]["SigmaUserId"].ToString());
                                    }
                                }
                                #endregion
                            }
                        }

                        // 1-4-2. 아직 미승인자가 남았을 경우 건너뜀.
                    }
                }
            }

            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region GetEmailText : Email Text 정보를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetEmailText
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : Email Text 정보를 가져온다.
         * Input    값 : GetEmailText(E-mail워크플로워타입, 텍스트종류, 내용종류)
         *               1. EmailWorkflowType   - IWP / RFI / ITR
         *               2. EmailTextType       - TITLE / CONTENTS
         *               3. EmailContentsType   - REQUEST / SUSPEND / COMPLETE / REJECT
         * Ouput    값 : DataTable
         **********************************************************************************************/
        /// <summary>
        /// GetEmailText : Email Text 정보를 가져온다.
        /// </summary>
        /// <param name="EmailWorkflowType">E-mail워크플로워타입</param>
        /// <param name="EmailTextType">텍스트종류</param>
        /// <param name="EmailContentsType">내용종류</param>
        /// <returns>DataTable</returns>
        private DataTable GetEmailText(string EmailWorkflowType, string EmailTextType, string EmailContentsType)
        {
            DataTable result = new DataTable();

            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@EmailWorkflowType", EmailWorkflowType));
            parameter.Add(new SqlParameter("@EmailTextType", EmailTextType));
            parameter.Add(new SqlParameter("@EmailContentsType", EmailContentsType));

            DataSet dsEmail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailText", parameter.ToArray());

            if (dsEmail != null)
            {
                if (dsEmail.Tables[0].Rows.Count > 0)
                {
                    result = dsEmail.Tables[0];
                }
            }

            // return
            return result;
        }

        #endregion
                
        #region GetEmailText: Email Text 정보를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetEmailText
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : Email Text 정보를 가져온다.
         * Input    값 : GetEmailText(상태값데이터테이블, 상태값, 내용데이터테이블, 제목, 보내는사람, 받는사람, 비고)
         *               1. 상태값 - REQUEST / SUSPEND / COMPLETE / REJECT
         * Ouput    값 : string[]
         **********************************************************************************************/
        /// <summary>
        /// GetEmailForm : Email Form 정보를 가져온다.
        /// </summary>
        /// <param name="dtStatusParam">상태값데이터테이블</param>
        /// <param name="strStatusType">상태값(REQUEST / SUSPEND / COMPLETE / REJECT)</param>
        /// <param name="dtHistoryParam">히스토리데이터테이블</param>
        /// <param name="Title">제목</param>
        /// <param name="Sender">보내는사람</param>
        /// <param name="Reciever">받는사람</param>
        /// <param name="Comment">비고</param>
        /// <returns>string[]</returns>
        private string[] GetEmailText(DataTable dtStatusParam, string strStatusType, DataTable dtHistoryParam, string Title, string Sender, string Reciever, string Comment)
        {
            string[] strReturn = new string[2];

            string strContent = string.Empty;
            string strComment = string.Empty;

            // 제목처리
            foreach (DataRow dr in dtStatusParam.Select())
            {
                // 제목처리 부분
                if (dr["EmailTextType"].ToString().Equals("TITLE") &&
                    dr["EmailContentsType"].ToString().Equals(strStatusType))
                {
                    strContent = dr["EmailText"].ToString();
                    strContent = strContent.Replace("#TITLE", Title);
                    strContent = strContent.Replace("#SENDER", Sender);
                    strContent = strContent.Replace("#RECEIVER", Reciever);

                    if (!string.IsNullOrEmpty(Comment))
                    {
                        strComment = "COMMENT : " + Comment;
                    }
                    else
                    {
                        strComment = "";
                    }

                    strContent = strContent.Replace("#COMMENT", strComment);

                    // 양영석 : 수정사항 존재
                    strContent = strContent.Replace("#DATETIME", dr["ReceivedDate"].ToString() + " " + dr["ReceivedTime"].ToString());

                    strReturn[0] = strContent;
                    break;
                }
            }

            strContent = "";

            // 내용처리
            foreach (DataRow drHistory in dtHistoryParam.Select())
            {
                // 기안자 상신 체크
                if (drHistory["IsMinSeq"].ToString().Equals("Y") && drHistory["IsProcessStatus"].ToString().Equals("Y"))
                {
                    // 기안내용 처리
                    foreach (DataRow drStatus in dtStatusParam.Select())
                    {
                        if (drStatus["EmailTextType"].ToString().Equals("CONTENTS") &&
                            drStatus["EmailContentsType"].ToString().Equals("REQUEST"))
                        {
                            strContent = strContent + drStatus["EmailText"].ToString();

                            strContent = strContent.Replace("#SENDER", drHistory["SigmaUserName"].ToString());

                            if (!string.IsNullOrEmpty(drHistory["Comment"].ToString()))
                            {
                                strComment = "COMMENT : " + drHistory["Comment"].ToString();
                            }
                            else
                            {
                                strComment = "";
                            }

                            strContent = strContent.Replace("#COMMENT", strComment);
                            strContent = strContent.Replace("#DATETIME", drHistory["TransitionTime"].ToString());

                            break;
                        }
                    }
                }
                else if (drHistory["IsMinSeq"].ToString().Equals("N"))
                {
                    string strStatus = "";

                    // 각 담당자별 내용 체크
                    if (drHistory["IsProcessStatus"].ToString().Equals("Y"))
                    {
                        strStatus = "COMPLETE";
                    }
                    else if (drHistory["IsProcessStatus"].ToString().Equals("X"))
                    {
                        strStatus = "REJECT";
                    }
                    else
                    {
                        strStatus = "SUSPEND";
                    }

                    if (!string.IsNullOrEmpty(strStatus))
                    {
                        // 기안내용 처리
                        foreach (DataRow drStatus in dtStatusParam.Select())
                        {
                            if (drStatus["EmailTextType"].ToString().Equals("CONTENTS") &&
                                drStatus["EmailContentsType"].ToString().Equals(strStatus))
                            {
                                strContent = strContent + drStatus["EmailText"].ToString();

                                strContent = strContent.Replace("#RECEIVER", drHistory["SigmaUserName"].ToString());

                                if (!string.IsNullOrEmpty(drHistory["Comment"].ToString()))
                                {
                                    strComment = "COMMENT : " + drHistory["Comment"].ToString();
                                }
                                else
                                {
                                    strComment = "";
                                }

                                strContent = strContent.Replace("#COMMENT", strComment);

                                if (strStatus.Equals("SUSPEND"))
                                {
                                    strContent = strContent.Replace("#DATETIME", drHistory["PendingTime"].ToString());
                                }
                                else
                                {
                                    strContent = strContent.Replace("#DATETIME", drHistory["TransitionTime"].ToString());
                                }

                                break;
                            }
                        }
                    }
                }
            }

            strContent = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><title></title><style type=\"text/css\">p.MsoNormal {font-family:\"Calibri\",\"sans-serif\";}.auto-style1 {font-family: Calibri;font-style: italic;font-weight: bold;color: #0000FF;}</style></head><body><form id=\"form1\" runat=\"server\"><div><table><tr><td style=\"height:100px\"><p class=\"MsoNormal\">" + strContent + "</p></td></tr></table></div></form></body></html>";

            strReturn[1] = strContent;

            return strReturn;
        }

        #endregion

        #region GetEmailForm: Email Form 정보를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetEmailForm
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-13
         * 용       도 : Email Form 정보를 가져온다.
         * Input    값 : GetEmailForm((이메일코드ID, 제목, 받는사람이름, 비고)
         * Ouput    값 : string[]
         **********************************************************************************************/
        /// <summary>
        /// GetEmailForm : Email Form 정보를 가져온다.
        /// </summary>
        /// <param name="intEmailID"></param>
        /// <param name="strTitle"></param>
        /// <param name="strReciever"></param>
        /// <param name="strComment">비고</param>
        /// <returns>string[]</returns>
        private string[] GetEmailForm(int intEmailID, string strTitle, string strReciever, string strComment)
        {
            string[] strReturn = new string[2];

            string strDBContext = string.Empty;
            string strDBReciever = string.Empty;
            string strDBAccessLink = string.Empty;
            string strDBTitle = string.Empty;
            string strReceivedDate = string.Empty;
            string strReceivedTime = string.Empty;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@EmailFormId", intEmailID));

            DataSet dsEmail = SqlHelper.ExecuteDataset(connStr, "wfp_GetEmailForm", parameter.ToArray());

            if (dsEmail != null)
            {
                if (dsEmail.Tables[0].Rows.Count > 0)
                {
                    strDBContext = dsEmail.Tables[0].Rows[0]["EmailContext"].ToString();

                    strDBTitle = dsEmail.Tables[0].Rows[0]["EmailTitle"].ToString();
                    strDBReciever = dsEmail.Tables[0].Rows[0]["EmailReciever"].ToString();
                    strDBAccessLink = dsEmail.Tables[0].Rows[0]["AccessLink"].ToString();
                    strReceivedDate = dsEmail.Tables[0].Rows[0]["ReceivedDate"].ToString();
                    strReceivedTime = dsEmail.Tables[0].Rows[0]["ReceivedTime"].ToString();

                    strDBTitle = strDBTitle.Replace("#TITLE", strTitle);

                    if (!string.IsNullOrEmpty(strReciever))
                    {
                        strDBContext = strDBContext.Replace("#USERNAME", strReciever);
                    }
                    else
                    {
                        strDBContext = strDBContext.Replace("#USERNAME", strDBReciever);
                    }

                    if (intEmailID == 3 ||
                        intEmailID == 4)
                    {
                        strDBContext = strDBContext.Replace("#COMMENT", strComment);
                    }

                    strDBContext = strDBContext.Replace("#DATETIME", strReceivedDate + " " + strReceivedTime);

                    strReturn[0] = strDBTitle;
                    strReturn[1] = strDBContext;
                }
            }

            return strReturn;
        }

        #endregion

        #region GetWorkFlowType: Workflow Type 정보를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetWorkFlowType
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : Workflow Type 정보를 가져온다.
         * Input    값 : GetWorkFlowType(워크플로워타입, ID)
         * Ouput    값 : string
         **********************************************************************************************/
        /// <summary>
        /// GetWorkFlowType : Workflow Type 정보를 가져온다.
        /// </summary>
        /// <param name="strWorkflowType">워크플로워타입</param>
        /// <param name="intTargetId">ID</param>
        /// <returns>string</returns>
        private string GetWorkFlowType(string strWorkflowType, string strTargetId)
        {
            string strReturn = string.Empty;

            switch (strWorkflowType.ToUpper())
            {
                case "WORKFLOW_TYPE_IWP":
                    strReturn = "IWP SignOff" + "-" + DateTime.Now.Year.ToString() + strTargetId.PadLeft(6, '0');
                    break;
                case "WORKFLOW_TYPE_ITR":
                    strReturn = "ITR" + "-" + DateTime.Now.Year.ToString() + strTargetId.PadLeft(6, '0');
                    break;
                case "WORKFLOW_TYPE_RFI":
                    strReturn = "RFI" + "-" + DateTime.Now.Year.ToString() + strTargetId.PadLeft(6, '0');
                    break;
            }

            return strReturn;
        }

        #endregion

        #region AddMessageContext : MessageContext에 Message 내용 등록

        /**********************************************************************************************
         * Mehtod   명 : AddMessageContext
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-07
         * 용       도 : MessageContext에 Message 내용 등록
         * Input    값 : AddMessageContext(메세지 내용)
         * Ouput    값 : int
         **********************************************************************************************/
        /// <summary>
        /// AddMessageContext : MessageContext에 Message 내용 등록
        /// </summary>
        /// <param name="MsgContext">메세지 내용</param>
        /// <returns>Context 순번</returns>
        public int AddMessageContext(string MsgContext)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            int result = 0;

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@MsgContext", MsgContext));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_AddMessageContext", parameter.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = Int32.Parse(ds.Tables[0].Rows[0]["ContextSeq"].ToString());
                }
            }

            return result;
        }

        #endregion
        
        #region AddMessageBox : MessageBox에 Message 등록

        /**********************************************************************************************
         * Mehtod   명 : AddMessageBox
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-07
         * 용       도 : MessageBox에 Message 등록
         * Input    값 : AddMessageBox(메세지타입코드, 메세지제목, 대상자ID, 내용순번, 발신자ID)
         * Ouput    값 : DataTable
         * Input    값 : AddMessageBox(메세지 내용)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// AddMessageBox : MessageBox에 Message 등록
        /// </summary>
        /// <param name="MsgTypeCode">메세지타입코드</param>
        /// <param name="MsgTitle">메세지제목</param>
        /// <param name="MsgTo">대상자ID</param>
        /// <param name="ContextSeq">내용순번</param>
        /// <param name="MsgFrom">발신자ID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType AddMessageBox(string MsgTypeCode, string MsgTitle, string MsgTo, int ContextSeq, string MsgFrom)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@MsgTypeCode", MsgTypeCode));
            parameter.Add(new SqlParameter("@MsgTitle", MsgTitle));
            parameter.Add(new SqlParameter("@MsgTo", MsgTo));
            parameter.Add(new SqlParameter("@ContextSeq", ContextSeq));
            parameter.Add(new SqlParameter("@CreateBy", MsgFrom));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_AddMessageBox", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;

            return result;
        }

        #endregion

        #region GetEmailText: Email Text 정보를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetEmailText
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : Email Text 정보를 가져온다.
         * Input    값 : GetEmailText(상태값데이터테이블, 제목, 보내는사람, 받는사람, 비고)
         * Ouput    값 : string[]
         **********************************************************************************************/
        /// <summary>
        /// GetEmailForm : Email Form 정보를 가져온다.
        /// </summary>
        /// <param name="dtParam">상태값데이터테이블</param>
        /// <param name="Title">제목</param>
        /// <param name="Sender">보내는사람</param>
        /// <param name="Reciever">받는사람</param>
        /// <param name="Comment">비고</param>
        /// <returns>string[]</returns>
        private string[] GetEmailText(DataTable dtParam, string Title, string Sender, string Reciever, string Comment)
        {
            string[] strReturn = new string[2];

            foreach (DataRow dr in dtParam.Select())
            {
                string strContent = string.Empty;
                string strComment = string.Empty;

                strContent = dr["EmailText"].ToString();
                strContent = strContent.Replace("#TITLE", Title);
                strContent = strContent.Replace("#SENDER", Sender);
                strContent = strContent.Replace("#RECEIVER", Reciever);

                if (!string.IsNullOrEmpty(Comment))
                {
                    strComment = "COMMENT : " + Comment;
                }

                strContent = strContent.Replace("#COMMENT", Comment);
                strContent = strContent.Replace("#DATETIME", dr["ReceivedDate"].ToString() + " " + dr["ReceivedTime"].ToString());

                if (dr["EmailTextType"].ToString().Equals("TITLE"))
                {
                    strReturn[0] = strContent;
                }

                if (dr["EmailTextType"].ToString().Equals("CONTENTS"))
                {
                    strContent = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><title></title><style type=\"text/css\">p.MsoNormal {font-family:\"Calibri\",\"sans-serif\";}.auto-style1 {font-family: Calibri;font-style: italic;font-weight: bold;color: #0000FF;}</style></head><body><form id=\"form1\" runat=\"server\"><div><table><tr><td style=\"height:100px\"><p class=\"MsoNormal\">" + strContent + "</p></td></tr></table></div></form></body></html>";
                    strReturn[1] = strContent;
                }
            }

            return strReturn;
        }

        #endregion

        #endregion

        #endregion

        #region | USING - WEB | 

        #region GetWorkflowMapInfoBySchemeCode : SchemeCode를 이용하여 해당 Workflow를 조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowMapInfoBySchemeCode
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-14
         * 용       도 : SchemeCode를 이용하여 해당 Workflow를 조회
         * Input    값 : GetWorkflowMapInfoBySchemeCode(Scheme Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowMapInfoBySchemeCode : SchemeCode를 이용하여 해당 Workflow를 조회
        /// </summary>
        /// <param name="SchemeCode">SchemeSeq</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowMapInfoBySchemeCode(string SchemeCode)
        {
            SigmaResultType result = new SigmaResultType();
            
            result = GetWorkflowSchemeList(SchemeCode);
            
            return result;
        }

        #endregion

        #region GetWorkflow : WorkflowType Code를 이용하여 해당하는 빈 Workflow를 조회

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflow
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-07
         * 용       도 : WorkflowType Code를 이용하여 해당하는 빈 Workflow를 조회
         * Input    값 : GetWorkflow(WorkflowTypeCode 또는 PackageTypeCode)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflow : WorkflowType Code를 이용하여 해당하는 빈 Workflow를 조회
        /// </summary>
        /// <param name="WorkflowTypeCode">Workflow Type 코드</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflow(string WorkflowTypeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowMapInfo", parameter.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strSchemeCode = ds.Tables[0].Rows[0]["SchemeCode"].ToString();
                    int intSchemeSeq = Int32.Parse(ds.Tables[0].Rows[0]["SchemeSeq"].ToString());

                    // wfp_GetWorkflowHierachyInCharge
                    result = GetWorkflowHierachyInCharge(strSchemeCode, intSchemeSeq);
                }
            }

            return result;
        }

        #endregion

        #region AddWorkflowRoleTitle in WORKFLOW POSITION TITLE SETTING

        #endregion

        #endregion

        #region | USING - APP |

        #region GetWorkflowRoleTitle : WorkflowType Code를 이용하여 WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowRoleTitle
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : WorkflowType Code를 이용하여 WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.
         * Input    값 : GetWorkflowRoleTitle(WorkflowType Code)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowRoleTitle : WorkflowType Code를 이용하여 WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.
        /// </summary>
        /// <param name="WorkflowTypeCode">Workflow Type 코드</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflowRoleTitle(string WorkflowTypeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowMapInfo", parameter.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strSchemeCode = ds.Tables[0].Rows[0]["SchemeCode"].ToString();
                    int intSchemeSeq = Int32.Parse(ds.Tables[0].Rows[0]["SchemeSeq"].ToString());

                    // wfp_GetWorkflowRoleTitle
                    result = GetWorkflowRoleTitle(strSchemeCode, intSchemeSeq);
                }
            }

            return result;
        }

        #endregion

        #region GetPendingWorkflow : 대기중인 Workflow 조회한다.

        /**********************************************************************************************
         * Mehtod   명 : GetPendingWorkflow
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-06
         * 용       도 : 대기중인 Workflow 조회한다.
         * Input    값 : GetPendingWorkflow(워크플로워타입, 각타입별ID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetPendingWorkflow : 대기중인 Workflow 조회한다.
        /// </summary>
        /// <param name="PackageTypeCode">워크플로워타입</param>
        /// <param name="TargetId">각타입별ID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetPendingWorkflow(string PackageTypeCode, int TargetId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@PackageTypeCode", PackageTypeCode));
            parameter.Add(new SqlParameter("@TargetId", TargetId));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetDocumentTransitionStatusForPending", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;

            // return
            return result;
        }

        #endregion
       
        #region GetDepartmentUsed : 사용되고 있는 SigmaRole를 조회

        /**********************************************************************************************
         * Mehtod   명 : GetDepartmentUsed
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-04
         * 용       도 : 사용되고 있는 SigmaRole를 조회
         * Input    값 : GetDepartmentUsed(프로젝트ID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetDepartmentUsed : 사용되고 있는 SigmaRole를 조회
        /// </summary>
        /// <param name="ProjectId">프로젝트ID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetDepartmentUsed(string ProjectId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@ProjectId", Int32.Parse(ProjectId)));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaRoleUsed", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //#endregion

        #endregion

        #region GetCrewByDepartmentID : 해당 Role을 가진 SigmaUser들을 조회

        /**********************************************************************************************
         * Mehtod   명 : GetCrewByDepartmentID
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-04
         * 용       도 : 해당 Role을 가진 SigmaUser들을 조회
         * Input    값 : GetCrewByDepartmentID(프로젝트ID, SigmaRole ID, 기안자ID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetCrewByDepartmentID : 해당 Role을 가진 SigmaUser들을 조회
        /// </summary>
        /// <param name="ProjectId">프로젝트ID</param>
        /// <param name="SigmaRoleId">SigmaRole ID</param>
        /// <param name="DrafterId">기안자ID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetCrewByDepartmentID(string ProjectId, string SigmaRoleId, string DrafterId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@ProjectId", Int32.Parse(ProjectId)));
            parameter.Add(new SqlParameter("@SigmaRoleId", Int32.Parse(SigmaRoleId)));
            parameter.Add(new SqlParameter("@SigmaUserId", DrafterId));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUserByRole", parameter.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;

            // return
            return result;
        }

        #endregion

        #region SaveWorkflowCrew : Workflow 관련 테이블에 기본 정보들을 등록한다.

        /**********************************************************************************************
         * Mehtod   명 : SaveWorkflowCrew
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-04
         * 용       도 : Workflow 관련 테이블에 기본 정보들을 등록한다.
         * Input    값 : SaveWorkflowCrew(Workflow Type 코드, TransitionStatus순번, 상세순번, 담당자순번, 담당자ID, 
         *                                상태코드(Y:승인, N:대기; X:거부), 각패키지별ID, IWPID)
         * Ouput    값 : string
         **********************************************************************************************/
        /// <summary>
        /// SaveWorkflowCrew : Workflow 관련 테이블에 기본 정보들을 등록한다.
        /// </summary>
        /// <param name="WorkflowTypeCode">Workflow Type 코드</param>
        /// <param name="TransitionStatusSeq">TransitionStatus순번</param>
        /// <param name="LoginID">기안자ID</param>
        /// <param name="TransitionLst">각단계별승인자정보</param>
        /// <param name="Title">기안제목</param>
        /// <param name="Comment">기안자코멘트</param>
        /// <param name="TargetId">각패키지별ID</param>
        /// <param name="IwpId">IWPID</param>
        /// <returns>Document용Guid</returns>
        public SigmaResultType SaveWorkflowCrew(string WorkflowTypeCode, int TransitionStatusSeq, string LoginID, List<TypeTransition> TransitionLst, string Title, string Context, string Comment, int TargetId, int IwpId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowMapInfo", parameter.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strSchemeCode = ds.Tables[0].Rows[0]["SchemeCode"].ToString();
                    int intSchemeSeq = Int32.Parse(ds.Tables[0].Rows[0]["SchemeSeq"].ToString());

                    string strReturn = AddWorkflowInitalInfo(strSchemeCode, intSchemeSeq, TransitionStatusSeq, LoginID, TransitionLst, Title, Context, Comment, WorkflowTypeCode, TargetId, IwpId);

                    if (!string.IsNullOrEmpty(WorkflowTypeCode) && WorkflowTypeCode == Element.Reveal.DataLibrary.Utilities.WorklowTypeCode.IWP)
                    {
                        List<Element.Reveal.DataLibrary.FiwpDTO> iwpList = new List<Element.Reveal.DataLibrary.FiwpDTO>();

                        Element.Reveal.DataLibrary.FiwpDTO iwpDto = (new TrueTask.Build()).GetSingleFiwpByID(IwpId);
                        iwpDto.DocEstablishedLUID = Element.Reveal.DataLibrary.Utilities.AssembleStep.APPROVER;
                        iwpDto.UpdatedBy = LoginID;
                        iwpDto.DTOStatus = (int)RowStatusNo.Update;

                        iwpList.Add(iwpDto);
                        iwpList = (new TrueTask.Build()).SaveIwp(iwpList);
                    }

                    result.AffectedRow = 1;
                    result.IsSuccessful = true;
                }
                else
                {
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                }
            }
            else
            {
                result.AffectedRow = 0;
                result.IsSuccessful = false;
            }

            return result;
        }

        #endregion

        #region UpdateWorkflowCrew : DocumentTransition 관련 테이블의 담당자 정보를 수정한다.

        /**********************************************************************************************
         * Mehtod   명 : UpdateWorkflowCrew
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-07
         * 용       도 : DocumentTransition 관련 테이블의 담당자 정보를 수정한다.
         * Input    값 : UpdateWorkflowCrew(Workflow Type 코드, TransitionStatus순번, 작성한 Process Guid, 각단계별승인자정보, 각패키지별ID)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// UpdateWorkflowCrew : DocumentTransition 관련 테이블의 담당자 정보를 수정한다.
        /// </summary>
        /// <param name="WorkflowTypeCode">Workflow Type 코드</param>
        /// <param name="TransitionStatusSeq">TransitionStatus순번</param>
        /// <param name="WorkFlowId">Process GuiD</param>
        /// <param name="TransitionLst">각단계별승인자정보</param>
        /// <param name="TargetId">각패키지별ID</param>
        /// <returns></returns>
        public SigmaResultType UpdateWorkflowCrew(string WorkflowTypeCode, int TransitionStatusSeq, Guid WorkFlowId, List<TypeTransition> TransitionLst, int TargetId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            string strController = string.Empty;
            int intControllerRole = 0;

            List<SqlParameter> parameterMap = new List<SqlParameter>();

            parameterMap.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));

            DataSet dsMap = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowMapInfo", parameterMap.ToArray());

            if (dsMap != null)
            {
                if (dsMap.Tables[0].Rows.Count > 0)
                {
                    string strSchemeCode = dsMap.Tables[0].Rows[0]["SchemeCode"].ToString();
                    int intSchemeSeq = Int32.Parse(dsMap.Tables[0].Rows[0]["SchemeSeq"].ToString());

                    if (TransitionStatusSeq == 0)
                    {
                        // Compose parameters
                        List<SqlParameter> parameterTSS = new List<SqlParameter>();

                        // TransitionStatus의 Seq값을 모를 경우(0인 경우) SchemeCode와 SchemeSeq를 가지고 조회함.
                        // wfp_GetTransitionStatusSeq
                        parameterTSS.Add(new SqlParameter("@SchemeCode", strSchemeCode));
                        parameterTSS.Add(new SqlParameter("@SchemeSeq", intSchemeSeq));
                        parameterTSS.Add(new SqlParameter("@SchemeDetSeq", 0));

                        DataSet dsTSS = SqlHelper.ExecuteDataset(connStr, "wfp_GetTransitionStatusSeq", parameterTSS.ToArray());

                        if (dsTSS != null)
                        {
                            if (dsTSS.Tables[0].Rows.Count > 0)
                            {
                                TransitionStatusSeq = Int32.Parse(dsTSS.Tables[0].Rows[0]["TransitionStatusSeq"].ToString());
                            }
                        }
                    }

                    using (var scope = new TransactionScope())
                    {
                        // 기존 정보 삭제
                        // Compose parameters
                        List<SqlParameter> parameterRDT = new List<SqlParameter>();

                        // wfp_RemoveDocumentTransition
                        parameterRDT.Add(new SqlParameter("@WorkFlowId", WorkFlowId));

                        SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_RemoveWorkflowTransitionHistory", parameterRDT.ToArray());

                        foreach (TypeTransition tr in TransitionLst)
                        {
                            // WorkflowTransitionHistory 테이블에 담당자 관련 정보 등록
                            List<SqlParameter> parameterInCharge = new List<SqlParameter>();

                            parameterInCharge.Add(new SqlParameter("@WorkflowGuid", WorkFlowId));
                            parameterInCharge.Add(new SqlParameter("@TransitionStatusSeq", TransitionStatusSeq + tr.Row + 1));
                            parameterInCharge.Add(new SqlParameter("@TransitionStatusDetSeq", 0));
                            parameterInCharge.Add(new SqlParameter("@SigmaUserId", tr.UserId));
                            parameterInCharge.Add(new SqlParameter("@SigmaRoleId", tr.Role));
                            parameterInCharge.Add(new SqlParameter("@Comment", ""));
                            parameterInCharge.Add(new SqlParameter("@ProcessStatus", "N"));

                            DataSet dsInCharge = SqlHelper.ExecuteDataset(connStr, "wfp_AddWorkflowTransitionHistory", parameterInCharge.ToArray());

                            if (dsInCharge != null)
                            {
                                if (dsInCharge.Tables[0].Rows.Count > 0)
                                {
                                    dsInCharge.Tables[0].Rows[0]["TransitionStatusDetSeq"].ToString();
                                }
                            }

                            strController = tr.UserId;
                            intControllerRole = tr.Role;
                        }

                        // wfp_ModifyWorkflowController
                        List<SqlParameter> parameterDC = new List<SqlParameter>();

                        parameterDC.Add(new SqlParameter("@WorkflowGuID", WorkFlowId));
                        parameterDC.Add(new SqlParameter("@ControllerId", strController));
                        parameterDC.Add(new SqlParameter("@ControllerRoleID", intControllerRole));

                        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "wfp_ModifyWorkflowController", parameterDC.ToArray());
                        result.IsSuccessful = true;

                        scope.Complete();
                    }

                    result.AffectedRow = 1;
                    result.IsSuccessful = true;
                }
                else
                {
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                }
            }
            else
            {
                result.AffectedRow = 0;
                result.IsSuccessful = false;
            }

            return result;
        }

        #endregion

        #region GetDocumentTransitionStatusListGuid : DocumentTransitionStatus 목록을 조회함.

        /**********************************************************************************************
         * Mehtod   명 : GetDocumentTransitionStatusListGuid
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-25
         * 용       도 : DocumentTransitionStatus 목록을 조회함.
         * Input    값 : GetDocumentTransitionStatusListGuid(사용자Guid, 시작일, 종료일, 결재여부(N-Pending, Y-Accept Or Denial))
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// GetDocumentTransitionStatusListGuid : DocumentTransitionStatus 목록을 조회함.
        /// </summary>
        /// <param name="UserGuid">사용자Guid</param>
        /// <param name="StartDt">시작일</param>
        /// <param name="EndDt">종료일</param>
        /// <param name="IsProcessStatus">결재여부(N-Pending, Y-Accept Or Denial)</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetDocumentTransitionStatusListGuid(Guid UserGuid, string StartDt, string EndDt, string IsProcessStatus)
        {
            SigmaResultType result = new SigmaResultType();

            result = GetWorkflowTransitionHistoryList(UserGuid, StartDt, EndDt, IsProcessStatus);

            return result;
        }

        #endregion

        #region SaveWorkflowForEasy : 해당 Workflow에 대한 의견을 확정한다.(승인/거부전용)

        /**********************************************************************************************
         * Mehtod   명 : SaveWorkflowForEasy
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-05
         * 용       도 : 해당 Workflow에 대한 의견을 확정한다.(승인/거부전용)
         * Input    값 : SaveWorkflowForEasy(Workflow Type 코드, 해당ID, 해당순번, 승인여부, 로그인ID, 내용, 결재사유)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// SaveWorkflowForEasy : 해당 Workflow에 대한 의견을 확정한다.(승인/거부전용)
        /// </summary>
        /// <param name="WorkflowTypeCode">Workflow Type 코드</param>
        /// <param name="TargetId">해당ID</param>
        /// <param name="TargetSeq">해당순번(0일때 가장 마지막 값로딩)</param>
        /// <param name="IsAgree">승인여부</param>
        /// <param name="UserID">로그인ID</param>
        /// <param name="Context">내용</param>
        /// <param name="Comment">결재사유</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType SaveWorkflowForEasy(string WorkflowTypeCode, int TargetId, int TargetSeq, bool IsAgree, string UserID, string Context, string Comment)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            string CommandName = string.Empty;
            string ProcessStatusYn = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowMapInfo", parameter.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strSchemeCode = ds.Tables[0].Rows[0]["SchemeCode"].ToString();
                    int intSchemeSeq = Int32.Parse(ds.Tables[0].Rows[0]["SchemeSeq"].ToString());


                    List<SqlParameter> parameterBasic = new List<SqlParameter>();

                    parameterBasic.Add(new SqlParameter("@PackageTypeCode", WorkflowTypeCode));
                    parameterBasic.Add(new SqlParameter("@TargetId", TargetId));
                    parameterBasic.Add(new SqlParameter("@TargetSeq", TargetSeq));
                    parameterBasic.Add(new SqlParameter("@UserID", UserID));
                    parameterBasic.Add(new SqlParameter("@SchememCode", strSchemeCode));
                    parameterBasic.Add(new SqlParameter("@SchememSeq", intSchemeSeq));

                    DataSet dsBasicInfo = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowForTruetask", parameterBasic.ToArray());

                    if (dsBasicInfo != null)
                    {
                        if (dsBasicInfo.Tables[0].Rows.Count > 0)
                        {
                            Guid ProcessGuid = new Guid(dsBasicInfo.Tables[0].Rows[0]["id"].ToString());
                            Guid ApprovalGuid = new Guid(dsBasicInfo.Tables[0].Rows[0]["EmployeeId"].ToString());
                            string CurrentStatus = dsBasicInfo.Tables[0].Rows[0]["StateName"].ToString();

                            int TransitionStatusSeq = Int32.Parse(dsBasicInfo.Tables[0].Rows[0]["TransitionStatusSeq"].ToString());

                            if (IsAgree)
                            {
                                CommandName = dsBasicInfo.Tables[0].Rows[0]["Command"].ToString();
                                ProcessStatusYn = "Y";
                            }
                            else
                            {
                                CommandName = "Denial";
                                ProcessStatusYn = "X";
                            }

                            ConfirmUsersOpinion(strSchemeCode, ProcessGuid, ProcessStatusYn, ApprovalGuid, CommandName, Comment);
                        }
                    }

                    result.AffectedRow = 1;
                    result.IsSuccessful = true;
                }
                else
                {
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                }
            }
            else
            {
                result.AffectedRow = 0;
                result.IsSuccessful = false;
            }

            return result;
        }

        #endregion

        #region SaveWorkflowForEasyEx : 해당 Workflow에 대한 의견을 확정한다.(확장용)

        /**********************************************************************************************
         * Mehtod   명 : SaveWorkflowForEasyEx
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-05
         * 용       도 : 해당 Workflow에 대한 의견을 확정한다.(확장용)
         * Input    값 : SaveWorkflowForEasyEx(Workflow Type 코드, 해당ID, 해당순번, 승인여부, 로그인ID, 내용, 결재사유)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// SaveWorkflowForEasyEx : 해당 Workflow에 대한 의견을 확정한다.(확장용)
        /// </summary>
        /// <param name="WorkflowTypeCode">Workflow Type 코드</param>
        /// <param name="TargetId">해당ID</param>
        /// <param name="TargetSeq">해당순번(0일때 가장 마지막 값로딩)</param>
        /// <param name="AgreeInfo">승인여부(Y:승인, N:보류, X:거절)</param>
        /// <param name="UserID">로그인ID</param>
        /// <param name="Context">내용</param>
        /// <param name="Comment">결재사유</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType SaveWorkflowForEasyEx(string WorkflowTypeCode, int TargetId, int TargetSeq, string AgreeInfo, string UserID, string Context, string Comment)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            string CommandName = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();

            parameter.Add(new SqlParameter("@WorkflowTypeCode", WorkflowTypeCode));

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowMapInfo", parameter.ToArray());

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strSchemeCode = ds.Tables[0].Rows[0]["SchemeCode"].ToString();
                    int intSchemeSeq = Int32.Parse(ds.Tables[0].Rows[0]["SchemeSeq"].ToString());


                    List<SqlParameter> parameterBasic = new List<SqlParameter>();

                    parameterBasic.Add(new SqlParameter("@PackageTypeCode", WorkflowTypeCode));
                    parameterBasic.Add(new SqlParameter("@TargetId", TargetId));
                    parameterBasic.Add(new SqlParameter("@TargetSeq", TargetSeq));
                    parameterBasic.Add(new SqlParameter("@UserID", UserID));
                    parameterBasic.Add(new SqlParameter("@SchememCode", strSchemeCode));
                    parameterBasic.Add(new SqlParameter("@SchememSeq", intSchemeSeq));

                    DataSet dsBasicInfo = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowForTruetask", parameterBasic.ToArray());

                    if (dsBasicInfo != null)
                    {
                        if (dsBasicInfo.Tables[0].Rows.Count > 0)
                        {
                            Guid ProcessGuid = new Guid(dsBasicInfo.Tables[0].Rows[0]["id"].ToString());
                            Guid ApprovalGuid = new Guid(dsBasicInfo.Tables[0].Rows[0]["EmployeeId"].ToString());
                            string CurrentStatus = dsBasicInfo.Tables[0].Rows[0]["StateName"].ToString();

                            int TransitionStatusSeq = Int32.Parse(dsBasicInfo.Tables[0].Rows[0]["TransitionStatusSeq"].ToString());

                            if (AgreeInfo.ToUpper().Equals("Y"))
                            {
                                CommandName = dsBasicInfo.Tables[0].Rows[0]["Command"].ToString();
                            }
                            else if (AgreeInfo.ToUpper().Equals("X"))
                            {
                                CommandName = "Denial";
                            }
                            else if (AgreeInfo.ToUpper().Equals("N"))
                            {
                                CommandName = "Pending";
                            }

                            ConfirmUsersOpinion(strSchemeCode, ProcessGuid, AgreeInfo.ToUpper(), ApprovalGuid, CommandName, Comment);
                        }
                    }

                    result.AffectedRow = 1;
                    result.IsSuccessful = true;
                }
                else
                {
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                }
            }
            else
            {
                result.AffectedRow = 0;
                result.IsSuccessful = false;
            }

            return result;
        }

        #endregion

        #region GetDocumentTransitionStatusTotalCountForEasy : 조회된 DocumentTransitionStatus의 Row수를 반환함.

        /**********************************************************************************************
         * Mehtod   명 : GetDocumentTransitionStatusTotalCountForEasy
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : 조회된 DocumentTransitionStatus의 Row수를 반환함.
         * Input    값 : GetDocumentTransitionStatusTotalCountForEasy(사용자ID)
         * Ouput    값 : DataTable
         **********************************************************************************************/
        /// <summary>
        /// GetDocumentTransitionStatusTotalCountForEasy : 조회된 DocumentTransitionStatus의 Row수를 반환함.
        /// </summary>
        /// <param name="UserID">사용자ID</param>
        /// <returns>DataTable</returns>
        public int GetDocumentTransitionStatusTotalCountForEasy(string UserId)
        {
            int result = 0;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> parameterMem = new List<SqlParameter>();

            parameterMem.Add(new SqlParameter("@SigmaUserId", UserId));

            DataSet dsMem = SqlHelper.ExecuteDataset(connStr, "wfp_GetSigmaUser", parameterMem.ToArray());

            DataSet dsReturn = new DataSet();

            string EndDt = DateTime.Now.ToString("s").Substring(0, 10).Replace("/", "").Replace("-", "");
            string StartDt = DateTime.Now.AddMonths(-3).ToString("s").Substring(0, 10).Replace("/", "").Replace("-", "");

            if (dsMem != null)
            {
                if (dsMem.Tables[0].Rows.Count > 0)
                {
                    Guid uiUserGuid = new Guid(dsMem.Tables[0].Rows[0]["SigmaUserGuId"].ToString());

                    List<SqlParameter> parameter = new List<SqlParameter>();

                    parameter.Add(new SqlParameter("@UserGuiD", uiUserGuid));
                    parameter.Add(new SqlParameter("@StartDt", StartDt));
                    parameter.Add(new SqlParameter("@EndDt", EndDt));
                    parameter.Add(new SqlParameter("@IsProcessStatus", "N"));

                    dsReturn = SqlHelper.ExecuteDataset(connStr, "wfp_GetWorkflowTransitionHistoryTotalCount", parameter.ToArray());

                    result = Int32.Parse(dsReturn.Tables[0].Rows[0]["TotalCnt"].ToString());
                }
            }
            else
            {
                result = 0;
            }


            // return
            return result;
        }

        #endregion

        #endregion
    }
}
