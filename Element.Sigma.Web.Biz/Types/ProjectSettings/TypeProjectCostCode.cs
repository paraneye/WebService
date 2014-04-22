using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeProjectCostCode
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProjectCostCodeId;
        [DataMember]
        public int CostCodeId;
        [DataMember]
        public string CostCode;
        [DataMember]
        public string Description;
        [DataMember]
        public string CostCodeType;
        [DataMember]
        public int ProjectId;
        [DataMember]
        public string UomCode;
        [DataMember]
        public string UomName;
        [DataMember]
        public decimal EstimatedQty;
        [DataMember]
        public decimal EstimatedManhour;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
