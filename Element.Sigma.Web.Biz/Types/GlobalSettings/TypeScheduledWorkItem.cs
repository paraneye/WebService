using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeScheduledWorkItem
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string ScheduledWorkItemId;
        [DataMember]
        public string ExternalScheduleId;
        [DataMember]
        public string CwpId;
        [DataMember]
        public string ScheduleName;
        [DataMember]
        public string StartDate;
        [DataMember]
        public string EndDate;
        [DataMember]
        public string CrewMemebersAssigned;
        [DataMember]
        public string TotalWorkingHours;
        [DataMember]
        public string LeaderId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;

    }
}
