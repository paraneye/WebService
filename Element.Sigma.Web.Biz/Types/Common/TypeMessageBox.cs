using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.Common
{
    [DataContract]
    [Serializable]
    public class TypeMessageBox
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public string MsgTypeCode;
        [DataMember]
        public int MsgSeq;
        [DataMember]
        public string MsgTitle;
        [DataMember]
        public string MsgTo;
        [DataMember]
        public string IsRead;
        [DataMember]
        public string IsDelete;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
        [DataMember]
        public int ContextSeq;
    }
}
