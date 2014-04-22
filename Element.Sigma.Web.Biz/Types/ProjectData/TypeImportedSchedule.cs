using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.ProjectData
{
    // Type Class
    [DataContract]
    [Serializable]
    public class TypeImportedSchedule
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ScheduledWorkItemId;
        [DataMember]
        public string Wbs;
        [DataMember]
        public string ScheduleLineItem;
        [DataMember]
        public string P6StartDate;
        [DataMember]
        public string P6FinishDate;
        [DataMember]
        public decimal P6Duration;
        [DataMember]
        public string SigmaStartDate;
        [DataMember]
        public string SigmaFinishDate;
        [DataMember]
        public decimal SigmaDuration;
        [DataMember]
        public decimal EstimatedManhours;
        [DataMember]
        public decimal AssignedCrew;
        [DataMember]
        public string DisciplineCode;
        [DataMember]
        public int CwpId;
        [DataMember]
        public string AssignedTo;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
