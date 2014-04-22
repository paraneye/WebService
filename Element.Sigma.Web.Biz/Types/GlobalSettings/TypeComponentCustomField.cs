using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
        [DataContract]
        [Serializable]
        public class TypeComponentCustomField
        {
            [DataMember]
            public string SigmaOperation; // CRUD
            [DataMember]
            public int ComponentId;
            [DataMember]
            public int CustomFieldId;
            [DataMember]
            public string Value;
            [DataMember]
            public string CreatedBy;
            [DataMember]
            public string UpdatedBy;
            [DataMember]
            public string FieldName;
            [DataMember]
            public string IsDisplayable;
        }
}
