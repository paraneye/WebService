using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Common;
using Element.Sigma.Web.Biz.Workflow;

using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Text;

namespace Element.Sigma.Web.Service.Common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Workflow" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Workflow.svc or Workflow.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Workflow : IWorkflow
    {
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowSchemeCode
                result = workflowMgr.GetWorkflowSchemeCode(SchemeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowHierachyForDesigner
                result = workflowMgr.GetWorkflowHierachyForDesigner(SchemeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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
            string result = string.Empty;
            
            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                result = workflowMgr.DisplayWorkflowSchemeStyle(NodeImageUrl);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                return null;
            }
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
        public string DisplayWorkflowSchemeScript(string MinWidth, string MaxWidth, string MinHeight, string MaxHeight)
        {
            string result = string.Empty;

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                result = workflowMgr.DisplayWorkflowSchemeScript(Int32.Parse(MinWidth), Int32.Parse(MaxWidth), Int32.Parse(MinHeight), Int32.Parse(MaxHeight));
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                return null;
            }
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
            string result = string.Empty;

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                result = workflowMgr.DisplayWorkflowSchemeDesigner(Titles, StartWidth, StartHeight);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                return null;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_RemoveWorkflowScheme
                // wfp_AddWorkflowMap 
                // wfp_AddWorkflowCode  
                // wfp_AddWorkflowRoleHierachy
                result = workflowMgr.AddWorkflowScheme(SchemeCode, SchemeSeq, CodeText, lstScheme, ProcessName, CreatedBy);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowSchemeList
                result = workflowMgr.GetWorkflowSchemeList(SchemeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowHierachy
                result = workflowMgr.GetWorkflowHierachy(SchemeCode, SchemeSeq);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowHierachySeq
                result = workflowMgr.GetWorkflowHierachySeq(SchemeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_AddWorkflowSchemeInXml
                result = workflowMgr.AddWorkflowHierachy(SchemeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        #endregion

        #region ModifyWorkflowHierachyMemberCount: WorkflowHierachy의 담당자 수 수정

        /**********************************************************************************************
         * Mehtod   명 : ModifyWorkflowHierachyMemberCount
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-22
         * 용       도 : WorkflowHierachy에 따른 Sequence 조회
         * Input    값 : ModifyWorkflowHierachyMemberCount(Scheme Code, Scheme별 Sequence, 배정된담당목록)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// ModifyWorkflowHierachyMemberCount: WorkflowHierachy에 따른 Sequence 조회
        /// </summary>
        /// <param name="SchemeCode">Scheme Code</param>
        /// <param name="SchemeSeq">Scheme별 Sequence</param>
        /// <param name="MemberList">배정된담당목록</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType ModifyWorkflowHierachyMemberCount(string SchemeCode, int SchemeSeq, Dictionary<int, int> MemberList)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_ModifyWorkflowHierachyMember
                result = workflowMgr.ModifyWorkflowHierachyMemberCount(SchemeCode, SchemeSeq, MemberList);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowHierachyInCharge
                result = workflowMgr.GetWorkflowHierachyInCharge(SchemeCode, SchemeSeq);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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
        /// <returns>SigmaResultType</returns>
        public SigmaResultType AddWorkflowRoleTitle(List<TypeTransition> TransitionDsLst, string CreateBy)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_RemoveWorkflowRoleTitle
                // wfp_AddWorkflowRoleTitle
                result.AffectedRow = workflowMgr.AddWorkflowRoleTitle(TransitionDsLst, CreateBy);
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowRoleTitle
                result = workflowMgr.GetWorkflowRoleTitle(SchemeCode, SchemeSeq);
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaUserListWithoutMe
                result = workflowMgr.GetSigmaUserListWithoutMe(SigmaUserID);
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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
         * Ouput    값 : SigmaResultType
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
        public SigmaResultType AddWorkflowInitalInfo(string SchemeCode, int SchemeSeq, int TransitionStatusSeq, string LoginID, List<TypeTransition> TransitionLst, string Title, string Context, string Comment, string WorkflowTypeCode, int TargetId, int IwpId)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetTransitionStatusSeq
                // wfp_GetProcessNameBySchemeCode
                // wfp_AddWorkflow
                // wfp_AddWorkflowProcess
                // wfp_AddWorkflowTransitionHistory
                workflowMgr.AddWorkflowInitalInfo(SchemeCode, SchemeSeq, TransitionStatusSeq, LoginID, TransitionLst, Title, Context, Comment, WorkflowTypeCode, TargetId, IwpId);
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaUserList
                workflowMgr.GetSigmaUser();
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        #endregion

        #region GetWorkflowTransitionHistoryList : WorkflowTransitionHistory 목록을 조회함.

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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaUserByUserId
                // wfp_GetWorkflowTransitionHistoryList
                result = workflowMgr.GetWorkflowTransitionHistoryList(UserId, StartDt, EndDt, IsProcessStatus);
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowTransitionHistory
                result = workflowMgr.GetWorkflowTransitionHistory(processId);
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaUserByUserId
                result = workflowMgr.GetSigmaUserByUserId(SigmaUserId);
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaUserCommand
                result = workflowMgr.GetSigmaUserCommand(SigmaUserGuid, ProcessGuId, Order);
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetProcessNameBySchemeCode
                // wfp_ModifyWorkflowTransitionHistoryStatus
                // wfp_ModifyWorkflowProcess
                // wfp_ModifyWorkflowProcessHistory
                // wfp_ModifyWorkflow
                // wfp_GetEmailAppliedGuid
                // wfp_GetEmailSigmaUserGuID
                // wfp_AddMessageContext
                // wfp_AddMessageBox
                workflowMgr.ConfirmUsersOpinion(SchemeCode, ProcessGuid, ProcessStatusYn, iuUser, commandName, Comment);
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        #endregion

        #region AddMessageContext : MessageContext에 Message 내용 등록

        /**********************************************************************************************
         * Mehtod   명 : AddMessageContext
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-07
         * 용       도 : MessageContext에 Message 내용 등록
         * Input    값 : AddMessageContext(메세지 내용)
         * Ouput    값 : SigmaResultType
         **********************************************************************************************/
        /// <summary>
        /// AddMessageContext : MessageContext에 Message 내용 등록
        /// </summary>
        /// <param name="MsgContext">메세지 내용</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType AddMessageContext(string MsgContext)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_AddMessageContext
                result.AffectedRow = workflowMgr.AddMessageContext(MsgContext);
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_AddMessageBox
                result = workflowMgr.AddMessageBox(MsgTypeCode, MsgTitle, MsgTo, ContextSeq, MsgFrom);
                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowSchemeList
                result = workflowMgr.GetWorkflowMapInfoBySchemeCode(SchemeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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
        /// <param name="WorkflowTypeCode">Workflow Type 코드 또는 Package Type 코드</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetWorkflow(string WorkflowTypeCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowHierachyInCharge
                result = workflowMgr.GetWorkflow(WorkflowTypeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        #endregion

        #region AddWorkflowRoleTitle in WORKFLOW POSITION TITLE SETTING

        #endregion

        #endregion

        #region | USING - APP |

        #region GetWorkflowRoleTitle : WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowRoleTitle
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-11
         * 용       도 : WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.
         * Input    값 : GetWorkflowRoleTitle(Workflow Type 코드 또는 Package Type 코드)
         * Ouput    값 : DataTable
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowRoleTitle : WorkflowRoleTitle 테이블에서 부여된 타이틀을 조회한다.
        /// </summary>
        /// <param name="WorkflowTypeCode">Workflow Type 코드 또는 Package Type 코드</param>
        /// <returns>DataTable</returns>
        public SigmaResultType GetWorkflowRoleTitle(string WorkflowTypeCode)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowRoleTitle
                result = workflowMgr.GetWorkflowRoleTitle(WorkflowTypeCode);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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
        /// <param name="WorkflowTypeCode">워크플로워타입</param>
        /// <param name="TargetId">각타입별ID</param>
        /// <returns>SigmaResultType</returns>
        public SigmaResultType GetPendingWorkflow(string WorkflowTypeCode, string TargetId)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaUserCommand
                result = workflowMgr.GetPendingWorkflow(WorkflowTypeCode, Int32.Parse(TargetId));
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaRoleUsed
                result = workflowMgr.GetDepartmentUsed(ProjectId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetSigmaUserByRole
                result = workflowMgr.GetCrewByDepartmentID(ProjectId, SigmaRoleId, DrafterId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
        }

        #endregion
        
        #region SaveWorkflowCrew : Workflow 관련 테이블에 기본 정보들을 등록한다.

        /**********************************************************************************************
         * Mehtod   명 : SaveWorkflowCrew
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-03-04
         * 용       도 : Workflow 관련 테이블에 기본 정보들을 등록한다.
         * Input    값 : SaveWorkflowCrew(Workflow Type 코드, , TransitionStatus순번, 상세순번, 담당자순번, 담당자ID, 
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
        /// <param name="Context">기안내용</param>
        /// <param name="Comment">기안자코멘트</param>
        /// <param name="TargetId">각패키지별ID</param>
        /// <param name="IwpId">IWPID</param>
        /// <returns>Document용Guid</returns>
        public SigmaResultType SaveWorkflowCrew(string WorkflowTypeCode, int TransitionStatusSeq, string LoginID, List<TypeTransition> TransitionLst, string Title, string Context, string Comment, int TargetId, int IwpId)
        {
            SigmaResultType result = new SigmaResultType();

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                 workflowMgr.SaveWorkflowCrew(WorkflowTypeCode, TransitionStatusSeq, LoginID, TransitionLst, Title, Context, Comment, TargetId, IwpId);

                 result.AffectedRow = 1;
                 result.IsSuccessful = true;
                 return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetWorkflowMapInfo
                // wfp_GetTransitionStatusSeq
                // wfp_RemoveWorkflowTransitionHistory
                // wfp_AddWorkflowTransitionHistory
                // wfp_ModifyWorkflowController
                result = workflowMgr.UpdateWorkflowCrew(WorkflowTypeCode, TransitionStatusSeq, WorkFlowId, TransitionLst, TargetId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                result = workflowMgr.GetDocumentTransitionStatusListGuid(UserGuid, StartDt, EndDt, IsProcessStatus);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                workflowMgr.SaveWorkflowForEasy(WorkflowTypeCode, TargetId, TargetSeq, IsAgree, UserID, Context, Comment);

                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                workflowMgr.SaveWorkflowForEasyEx(WorkflowTypeCode, TargetId, TargetSeq, AgreeInfo, UserID, Context, Comment);

                result.AffectedRow = 1;
                result.IsSuccessful = true;
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
                return result;
            }
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

            try
            {
                WorkflowMgr workflowMgr = new WorkflowMgr();

                // wfp_GetDocumentTransitionStatusTotalCount
                result = workflowMgr.GetDocumentTransitionStatusTotalCountForEasy(UserId);
                return result;
            }
            catch (Exception ex)
            {
                // Log Exception
                ExceptionHelper.logException(ex);
                return result;
            }
        }

        #endregion

        #endregion
    }
}