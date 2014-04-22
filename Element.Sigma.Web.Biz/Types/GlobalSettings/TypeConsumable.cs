using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeConsumable
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ConsumableId;
        [DataMember]
        public string Description;
        [DataMember]
        public string PartNumber;
        [DataMember]
        public string Vendor;
        [DataMember]
        public string UomCode;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
