using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeSigmaUserSigmaRole
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int SigmaTrgRoleId;
        [DataMember]
        public int SigmaRoleId;
        [DataMember]
        public string SigmaUserId;
        [DataMember]
        public string ReportTo;
        [DataMember]
        public int ReportToRole;
        [DataMember]
        public string IsDefault;
        [DataMember]
        public int ProjectId;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
