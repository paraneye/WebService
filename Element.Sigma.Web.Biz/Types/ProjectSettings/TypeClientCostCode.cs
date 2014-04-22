using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeClientCostCode
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ClientCostCodeId;
        [DataMember]
        public int ClientCompanyId;
        [DataMember]
        public string ClientCostCode;
        [DataMember]
        public string ClientCostCodeName;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
