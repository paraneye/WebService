using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeProjectUserDiscipline
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProjectId;
        [DataMember]
        public string SigmaUserId;
        [DataMember]
        public string DisciplineCode;
        [DataMember]
        public string IsDefault;
    }
}
