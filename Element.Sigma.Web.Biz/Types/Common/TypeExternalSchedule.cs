using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.Common
{
    [DataContract]
    [Serializable]
    public class TypeExternalSchedule
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ExternalScheduleId;
        [DataMember]
        public string Level;
        [DataMember]
        public string StartDate;
        [DataMember]
        public string EndDate;
        [DataMember]
        public decimal OriginalDuration;
        [DataMember]
        public int ProjectObjectId;
        [DataMember]
        public string ExternalProjectName;
        [DataMember]
        public int ActivityObjectId;
        [DataMember]
        public int ParentObjectId;
        [DataMember]
        public int RemainingDuration;
        [DataMember]
        public int CalendarId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public int ProjectId;
    }

}
