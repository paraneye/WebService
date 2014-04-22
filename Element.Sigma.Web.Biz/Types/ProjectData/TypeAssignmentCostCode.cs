using System;
using System.Runtime.Serialization;


namespace Element.Sigma.Web.Biz.Types.ProjectData
{
    [DataContract]
    [Serializable]
    public class TypeAssignmentCostCode
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ComponentProgressId;
        [DataMember]
        public int CostCodeId;
    }
}
