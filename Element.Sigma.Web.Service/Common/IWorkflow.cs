using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Element.Sigma.Web.Service.Common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWorkflow" in both code and config file together.
    [ServiceContract]
    public interface IWorkflow
    {
        #region | DEFAULT |

        #region | WORKFLOW DESIGNER SETTING |

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowSchemeCode/{SchemeCode}")]
        SigmaResultType GetWorkflowSchemeCode(string SchemeCode);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowHierachyForDesigner/{SchemeCode}")]
        SigmaResultType GetWorkflowHierachyForDesigner(string SchemeCode);
       
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "DisplayWorkflowSchemeStyle/{NodeImageUrl}")]
        string DisplayWorkflowSchemeStyle(string NodeImageUrl);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "DisplayWorkflowSchemeScript/{MinWidth}/{MaxWidth}/{MinHeight}/{MaxHeight}")]
        string DisplayWorkflowSchemeScript(string MinWidth, string MaxWidth, string MinHeight, string MaxHeight);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "DisplayWorkflowSchemeDesigner")]
        string DisplayWorkflowSchemeDesigner(List<string> Titles, int StartWidth, int StartHeight);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AddWorkflowScheme")]
        SigmaResultType AddWorkflowScheme(string SchemeCode, int SchemeSeq, string CodeText, List<TypeWorkflowScheme> lstScheme, string ProcessName, string CreatedBy);

        #endregion

        #region | WORKFLOW MEMBER COUNT SETTING |

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowSchemeList/{SchemeCode}")]
        SigmaResultType GetWorkflowSchemeList(string SchemeCode);
        
        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowHierachy")]
        SigmaResultType GetWorkflowHierachy(string SchemeCode,  int SchemeSeq);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowHierachy/{SchemeCode}")]
        SigmaResultType GetWorkflowHierachySeq(string SchemeCode);
        
        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AddWorkflowHierachy")]
        SigmaResultType AddWorkflowHierachy(string SchemeCode);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ModifyWorkflowHierachyMemberCount")]
        SigmaResultType ModifyWorkflowHierachyMemberCount(string SchemeCode, int SchemeSeq, Dictionary<int, int> MemberList);
        
        #endregion

        #region | WORKFLOW POSITION TITLE SETTING |

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowHierachyInCharge")]
        SigmaResultType GetWorkflowHierachyInCharge(string SchemeCode, int SchemeSeq);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AddWorkflowRoleTitle")]
        SigmaResultType AddWorkflowRoleTitle(List<TypeTransition> TransitionDsLst, string CreateBy);
        
        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.WrappedRequest,
        //    UriTemplate = "GetWorkflowRoleTitle")]
        //SigmaResultType GetWorkflowRoleTitle(string SchemeCode, int SchemeSeq);

        #endregion

        #region | WORKFLOW IN-CHARGE SETTING |

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetSigmaUserListWithoutMe/{SigmaUserID}")]
        SigmaResultType GetSigmaUserListWithoutMe(string SigmaUserID);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AddWorkflowInitalInfo")]
        SigmaResultType AddWorkflowInitalInfo(string SchemeCode, int SchemeSeq, int TransitionStatusSeq, string LoginID, List<TypeTransition> TransitionLst, string Title, string Context, string Comment, string WorkflowTypeCode, int TargetId, int IwpId);
        
        #endregion

        #region | WORKFLOW SUBMIT AND REVIEW |

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetSigmaUser")]
        SigmaResultType GetSigmaUser();
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowTransitionHistoryList/{UserId}/{StartDt}/{EndDt}/{IsProcessStatus}")]
        SigmaResultType GetWorkflowTransitionHistoryList(string UserId, string StartDt, string EndDt, string IsProcessStatus);
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetSigmaUserByUserId/{SigmaUserId}")]
        SigmaResultType GetSigmaUserByUserId(string SigmaUserId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetSigmaUserCommand")]
        SigmaResultType GetSigmaUserCommand(Guid SigmaUserGuid, Guid ProcessGuId, int Order);
       
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ConfirmUsersOpinion")]
        SigmaResultType ConfirmUsersOpinion(string SchemeCode, Guid ProcessGuid, string ProcessStatusYn, Guid iuUser, string commandName, string Comment);
        
        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AddMessageContext")]
        SigmaResultType AddMessageContext(string MsgContext);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "AddMessageBox")]
        SigmaResultType AddMessageBox(string MsgTypeCode, string MsgTitle, string MsgTo, int ContextSeq, string MsgFrom);

        #endregion

        #endregion
        
        #region | USING - WEB |

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowMapInfoBySchemeCode/{SchemeCode}")]
        SigmaResultType GetWorkflowMapInfoBySchemeCode(string SchemeCode);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflow/{WorkflowTypeCode}")]
        SigmaResultType GetWorkflow(string WorkflowTypeCode);

        #endregion

        #region | USING - APP |

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowRoleTitle/{WorkflowTypeCode}")]
        SigmaResultType GetWorkflowRoleTitle(string WorkflowTypeCode);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetPendingWorkflow/{WorkflowTypeCode}/{TargetId}")]
        SigmaResultType GetPendingWorkflow(string WorkflowTypeCode, string TargetId);
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetDepartmentUsed/{ProjectId}")]
        SigmaResultType GetDepartmentUsed(string ProjectId);
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetCrewByDepartmentID/{ProjectId}/{SigmaRoleId}/{DrafterId}")]
        SigmaResultType GetCrewByDepartmentID(string ProjectId, string SigmaRoleId, string DrafterId);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SaveWorkflowCrew")]
        SigmaResultType SaveWorkflowCrew(string WorkflowTypeCode, int TransitionStatusSeq, string LoginID, List<TypeTransition> TransitionLst, string Title, string Context, string Comment, int TargetId, int IwpId);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "UpdateWorkflowCrew")]
        SigmaResultType UpdateWorkflowCrew(string WorkflowTypeCode, int TransitionStatusSeq, Guid WorkFlowId, List<TypeTransition> TransitionLst, int TargetId);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetDocumentTransitionStatusListGuid")]
        SigmaResultType GetDocumentTransitionStatusListGuid(Guid UserGuid, string StartDt, string EndDt, string IsProcessStatus);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetWorkflowTransitionHistory")]
        SigmaResultType GetWorkflowTransitionHistory(Guid processId);
        
        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SaveWorkflowForEasy")]
        SigmaResultType SaveWorkflowForEasy(string WorkflowTypeCode, int TargetId, int TargetSeq, bool IsAgree, string UserID, string Context, string Comment);
 
        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "SaveWorkflowForEasyEx")]
        SigmaResultType SaveWorkflowForEasyEx(string WorkflowTypeCode, int TargetId, int TargetSeq, string AgreeInfo, string UserID, string Context, string Comment);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "GetDocumentTransitionStatusTotalCountForEasy/{UserId}")]
        int GetDocumentTransitionStatusTotalCountForEasy(string UserId);

        #endregion
    }
}
