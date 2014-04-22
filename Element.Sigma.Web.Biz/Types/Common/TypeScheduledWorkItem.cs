using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.Common
{
    [DataContract]
    [Serializable]
    public class TypeScheduledWorkItem
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ScheduledWorkItemId;
        [DataMember]
        public int ExternalScheduleId;
        [DataMember]
        public int? CwpId;
        [DataMember]
        public string ScheduleName;
        [DataMember]
        public string StartDate;
        [DataMember]
        public string EndDate;
        [DataMember]
        public int CrewMemebersAssigned;
        [DataMember]
        public decimal TotalWorkingHours;
        [DataMember]
        public string LeaderId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
