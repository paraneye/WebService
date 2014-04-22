using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.Common
{
    [DataContract]
    [Serializable]
    public class TypeSigmaMsg
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string MsgCode;
        [DataMember]
        public string MsgStr;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
