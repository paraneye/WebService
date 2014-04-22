using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeCWA
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int CwaId;
        [DataMember]
        public int ProjectId;
        [DataMember]
        public string Name;
        [DataMember]
        public string Area;
        [DataMember]
        public string Description;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;

        [DataMember]
        public List<TypeCWP> CWP;
    }
}
