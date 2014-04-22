using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeProjectSubcontractor
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProjectId;
        [DataMember]
        public int CompanyId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
