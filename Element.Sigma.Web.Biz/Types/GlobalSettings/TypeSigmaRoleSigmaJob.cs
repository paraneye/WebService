using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeSigmaRoleSigmaJob
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int SigmaJobId;
        [DataMember]
        public int SigmaRoleId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
