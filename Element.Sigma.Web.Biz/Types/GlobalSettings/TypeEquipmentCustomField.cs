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
    public class TypeEquipmentCustomField
    {
        [DataMember]
        public string SigmaOperation; // CRUD
        [DataMember]
        public int EquipmentId;
        [DataMember]
        public int CustomFieldId;
        [DataMember]
        public string Value;
        [DataMember]
        public string CreatedBy;
        [DataMember]
        public string UpdatedBy;
    }

}
