using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.Auth
{
    [DataContract]
    [Serializable]
    public class TypeUserAuth
    {
        /*
         * /Auth/SigmaAuth.svc/rest/Login
         * 
         * {
         * "AffectedRow":1,
         * "ErrorCode":null,
         * "ErrorMessage":null,
         * "IsSuccessful":true,
         * "JsonDataSet":"[{\"SigmaUserId\":\"userb\",\"CompanyId\":1,\"ProjectId\":null,\"SigmaRoleId\":null}]",
         * "ScalarValue":0,
         * "StringValue":null
         * }
         */
        [DataMember]
        public string SigmaUserId;
        [DataMember]
        public int CompanyId;
        [DataMember]
        public int ProjectId;
        [DataMember]
        public int SigmaRoleId;
    }
}
