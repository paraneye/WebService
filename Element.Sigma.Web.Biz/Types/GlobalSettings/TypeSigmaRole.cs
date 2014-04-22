using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeSigmaRole
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int SigmaRoleId;
        [DataMember]
        public string Name;
        [DataMember]
        public string SubSystem;
        [DataMember]
        public string RoleTypeCode;
        [DataMember]
        public string RoleDescription;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public string SigmaRoleGuid;
        [DataMember]
        public List<TypeSigmaRoleSigmaJob> typeSigmaRoleSigmaJob;
    }
}
