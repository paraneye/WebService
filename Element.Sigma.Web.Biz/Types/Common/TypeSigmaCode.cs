using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.Common
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
        public int RefNo;
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
