using System;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.Common
{
    [DataContract]
    [Serializable]
    public class TypeSigmaLog
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int Id;
        [DataMember]
        public string Date;
        [DataMember]
        public string Thread;
        [DataMember]
        public string Level;
        [DataMember]
        public string Logger;
        [DataMember]
        public string Message;
        [DataMember]
        public string Exception;
    }
}
