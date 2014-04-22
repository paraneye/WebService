using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Element.Sigma.Web.Biz.Types.GlobalSettings;

namespace Element.Sigma.Web.Biz.Types.ProjectSettings
{
    [DataContract]
    [Serializable]
    public class TypeMember
    {
        [DataMember]
        public List<TypeProjectUserDiscipline> typeProjectUserDiscipline;
        [DataMember]
        public List<TypeSigmaUserSigmaRole> typeSigmaUserSigmaRole;
    }

    public class TypeMemberList
    {
        [DataMember]
        public string SigmaUserId;
        [DataMember]
        public string Name;
        [DataMember]
        public string RoleName;
        [DataMember]
        public string DisciplineName;
    }

    public class TypeHierarchy
    {
        [DataMember]
        public string SigmaRoleId;
        [DataMember]
        public string SigmaUserId;
        [DataMember]
        public string ReportTo;
        [DataMember]
        public string ReportRole;
        [DataMember]
        public List<TypeSigmaUserSigmaRole> typeProjectUserDiscipline;
    }
}
