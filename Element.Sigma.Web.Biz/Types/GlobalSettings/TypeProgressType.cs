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
    public class TypeProgressType
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int ProgressTypeId;
        [DataMember]
        public string Name;
        [DataMember]
        public string Description;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;

        [DataMember]
        public List<TypeProgressStep> ProgressStep;
    }
}
