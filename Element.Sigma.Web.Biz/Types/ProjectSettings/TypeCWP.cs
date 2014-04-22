using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeCWP
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int CwpId;
        [DataMember]
        public int CwaId;
        [DataMember]
        public string CwpName;
        [DataMember]
        public string DisciplineCode;
        [DataMember]
        public string Description;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
