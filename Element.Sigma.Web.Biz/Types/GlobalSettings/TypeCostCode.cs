using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeCostCode
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string CostCodeId;
        [DataMember]
        public string CostCode;
        [DataMember]
        public string Description;
        [DataMember]
        public string CompanyId;
        [DataMember]
        public string CodeRegisterCompanyId;
        [DataMember]
        public string CostCodeType;
        [DataMember]
        public string UomCode;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
