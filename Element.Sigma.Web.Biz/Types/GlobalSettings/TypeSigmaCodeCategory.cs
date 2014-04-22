using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeSigmaCodeCategory
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string CodeCategory;
        [DataMember]
        public string CategoryName;
        [DataMember]
        public string CategoryDescription;
        [DataMember]
        public string ParentCodeCategory;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
