using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeProjectDiscipline
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProjectId;
        [DataMember]
        public string DisciplineCode;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
