using System;
using System.Runtime.Serialization;


namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeComponentProgress
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ComponentProgressId;
        [DataMember]
        public int ProgressStepId;
        [DataMember]
        public int CostCodeId;
        [DataMember]
        public int ComponentId;
        [DataMember]
        public int IwpId;
        [DataMember]
        public string IsCompleted;
        [DataMember]
        public int AmountInstalled;
        [DataMember]
        public decimal EstimatedManhours;
        [DataMember]
        public int OwnerCostCodeId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
