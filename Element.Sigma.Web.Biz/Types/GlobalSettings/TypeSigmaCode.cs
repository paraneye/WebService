using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeSigmaCode
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string Code;
        [DataMember]
        public string CodeCategory;
        [DataMember]
        public string CodeName;
        [DataMember]
        public string CodeShortName;
        [DataMember]
        public string RefChar;
        [DataMember]
        public string RefNo;
        [DataMember]
        public string Description;
        [DataMember]
        public string IsActive;
        [DataMember]
        public string SortOrder;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
