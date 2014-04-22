using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeMaterialCustomField
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int MaterialId;
        [DataMember]
        public int CustomFieldId;
        [DataMember]
        public string Value;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }

}
