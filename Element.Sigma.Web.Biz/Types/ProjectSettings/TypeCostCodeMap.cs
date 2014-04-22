using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeCostCodeMap
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string CostCodeMapId;
        [DataMember]
        public string ClientCostCodeId;
        [DataMember]
        public string ProjectCostCodeId;
        [DataMember]
        public string ClientCostCode;//external
        [DataMember]
        public string ClientCostCodeName;//external
        [DataMember]
        public string ProjectCostCode;//external
        [DataMember]
        public string ProjectCostCodeName;//external
    }
}
