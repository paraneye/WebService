using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
    [Serializable]
    public class TypeSigmaJob
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int SigmaJobId;
        [DataMember]
        public string SigmaJobName;
        [DataMember]
        public string JobCategoryCode;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }
}
